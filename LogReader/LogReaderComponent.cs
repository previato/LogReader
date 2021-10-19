using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LogReader
{
    public partial class LogReaderComponent : Component
    {
        private readonly SynchronizationContext _context;
        private readonly SendOrPostCallback _postCallbackLogChanged;
        private readonly SendOrPostCallback _postCallbackAlertConditionOccurred;

        public LogReaderComponent() : this(null)
        {
        }

        public LogReaderComponent(IContainer container)
        {
            if (container != default)
            {
                container.Add(this);
            }

            InitializeComponent();

            _context = SynchronizationContext.Current;
            _postCallbackLogChanged = new SendOrPostCallback(OnLogChanged);
            _postCallbackAlertConditionOccurred = new SendOrPostCallback(_ => AlertConditionOcurred?.Invoke(this, EventArgs.Empty));
        }

        private CancellationTokenSource _cts;
        private Task _mainTask = Task.CompletedTask;

        private void OnLogChanged(object args)
        {
            try
            {
                LogChanged?.Invoke(this, new LogChangedEventArgs((string)args));
            }
            catch { }
        }

        [Description("Occurs when new text is read from the current log file.")]
        public event EventHandler<LogChangedEventArgs> LogChanged;

        [Description("Occurs when starts to listening to a new log file.")]
        public event EventHandler<LogFileChangedEventArgs> LogFileChanged;

        [Description("Occurs when log read detectect the text specified on the property AlertCondition.")]
        public event EventHandler AlertConditionOcurred;

        [Description("Directory path of log files.")]
        public string Path { get; set; }

        [Description("Determine de text in which the alert event will be triggered.")]
        public string AlertCondition { get;set; }   

        [Description("When defined, the AlertConditionOccured event will be triggered when a log line matches the value specified in AlertCondition property.")]
        public bool EnableAlertEvent { get; set; }

        public void StartListening()
        {
            if (string.IsNullOrEmpty(Path))
            {
                throw new ArgumentNullException(nameof(Path));
            }

            _cts = new CancellationTokenSource();
            _mainTask = Task.Factory.StartNew(ProcessLog);
        }

        public void StopListening()
        {
            _cts?.Cancel();
            _mainTask.Wait();
        }

        private string GetMostRecentFile()
        {
            var logFile = default(string);
            var files = Directory.GetFiles(Path);
            var lastDate = default(DateTime);

            // determinar o arquivo mais recente.
            foreach (var file in files)
            {
                var fi = new FileInfo(file);
                if (fi.LastWriteTime > lastDate)
                {
                    lastDate = fi.LastWriteTime;
                    logFile = file;
                }
            }

            return logFile;
        }

        private void ProcessLog()
        {
            bool hasNewFile = false;

            var reset = new AutoResetEvent(false);

            var fw = new FileSystemWatcher(Path)
            {
                Filter = "*.*"
            };
            fw.Changed += (s, e) =>
            {
                reset.Set();
            };
            fw.Created += (s, e) =>
            {
                hasNewFile = true;
                reset.Set();
            };
            fw.EnableRaisingEvents = true;

            try
            {
                while (!_cts.IsCancellationRequested)
                {
                    var logFile = GetMostRecentFile();
                    if (string.IsNullOrEmpty(logFile))
                    {
                        _context.Post(_postCallbackLogChanged, "Não há arquivos no diretório. Nova tentativa em 2 segundos");
                        try { Task.Delay(2000, _cts.Token); } catch { }
                        continue;
                    }

                    do
                    {
                        hasNewFile = false;

                        using var fs = new FileStream(logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
                        using var reader = new StreamReader(fs);

                        var firstRead = reader.ReadToEnd(); //.TrimEnd('\n').TrimEnd('\r');
                        _context.Post(_postCallbackLogChanged, firstRead);

                        while (!_cts.IsCancellationRequested)
                        {
                            var line = default(string);
                            var log = "";

                            while ((line = reader.ReadLine()) != null)
                            {
                                if (line.Contains(AlertCondition, StringComparison.InvariantCultureIgnoreCase)) {
                                    _context.Post(_postCallbackAlertConditionOccurred, log);
                                }
                                log = string.Concat(log, line, Environment.NewLine);
                            }
                            //log = log.TrimEnd('\n').TrimEnd('\r');

                            _context.Post(_postCallbackLogChanged, log);

                            reset.WaitOne(1000);

                            // verificar se há um arquivo mais recente.
                            if (hasNewFile)
                            {
                                logFile = GetMostRecentFile();
                                _context.Post(x => LogFileChanged?.Invoke(this, new LogFileChangedEventArgs((string)x)), logFile);
                                break;
                            }
                        }
                    } while (hasNewFile);
                }
            }
            catch (Exception ex)
            {
                _context.Post(_postCallbackLogChanged, ex.Message);
            }
        }
    }
}
