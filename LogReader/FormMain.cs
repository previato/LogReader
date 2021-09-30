using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace LogReader
{
    public partial class FormMain : Form
    {
        private readonly List<string> _threadList;

        public FormMain()
        {
            InitializeComponent();

            _threadList = new List<string>();
        }

        private string _currentThreadId;
        private bool _cancellAll;
        private Thread _logThread;

        private bool _clearWhenNewFile;
        private int _clearLineCount;

        private string GetMostRecentFile(String path)
        {
            var logFile = default(string);
            var files = Directory.GetFiles(path);
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

        private void ProcessLog(object args)
        {
            var hasNewFile = false;
            string path = args.ToString();
            string logFile = "";
            string id = Thread.CurrentThread.Name;

            var reset = new AutoResetEvent(false);

            var fw = new FileSystemWatcher(path)
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

            var lineCount = 0;

            Action<string> logAppend = (x) =>
            {
                if (lineCount >= _clearLineCount)
                {
                    txtLog.Text = string.Concat("==== LIMPANDO DEVIDO AO NÚMERO MÁXIMO DE LINHAS TER ATINGIDO ====", "\r\n");
                    lineCount = 0;
                }
                txtLog.AppendText(string.Concat(x, "\r\n"));
                lineCount++;
            };

            Action<string> logText = (x) =>
            {
                txtLog.Text = x;
            };

            try
            {
                while (true)
                {
                    logFile = GetMostRecentFile(path);
                    if (string.IsNullOrEmpty(logFile))
                    {
                        _ = Invoke(logAppend, "Não há arquivos no diretório. Nova tentativa em 2 segundos");
                        Thread.Sleep(2000);
                        continue;
                    }
                    do
                    {
                        hasNewFile = false;

                        using (var fs = new FileStream(logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
                        {
                            using (var reader = new StreamReader(fs))
                            {
                                var firstRead = reader.ReadToEnd();

                                if (_currentThreadId == id)
                                {
                                    _ = Invoke(logAppend, firstRead.TrimEnd('\n').TrimEnd('\r'));
                                }

                                while (true)
                                {
                                    var line = default(string);
                                    var log = "";

                                    while ((line = reader.ReadLine()) != null)
                                    {
                                        log = string.Concat(log, line, "\r\n");
                                    }
                                    log = log.TrimEnd('\n').TrimEnd('\r');

                                    if (_currentThreadId == id && !string.IsNullOrEmpty(log))
                                    {
                                        _ = Invoke(logAppend, log);
                                    }

                                    reset.WaitOne(1000);

                                    if (_cancellAll) break;

                                    // verificar se há um arquivo mais recente.
                                    if (hasNewFile)
                                    {
                                        logFile = GetMostRecentFile(path);
                                        var act = default(Action<string>);
                                        if (_clearWhenNewFile)
                                        {
                                            act = logText;
                                        }
                                        else
                                        {
                                            act = logAppend;
                                        }
                                        _ = Invoke(act, string.Format("------------------- NOVO ARQUIVO: {0} -------------------", logFile));
                                        break;
                                    }
                                }
                            }
                        }
                    } while (hasNewFile);
                }
            }
            catch (ThreadAbortException ex)
            {
                _ = Invoke(logAppend, "Leitura de log parada");
                lock (_threadList)
                {
                    _threadList.Remove(id);
                }
            }
            catch (Exception ex)
            {
                _ = Invoke(logAppend, ex.ToString());
            }

            lock (_threadList)
            {
                _ = Invoke(logAppend, string.Format("Finalizando thread: {0}", id));
                _threadList.Remove(id);
            }
        }

        private void ProcessClose()
        {
            Action act = () =>
            {
                Close();
            };
            while (true)
            {
                lock (_threadList)
                {
                    if (_threadList.Count == 0)
                    {
                        Invoke(act);
                        break;
                    }
                }
                Thread.Sleep(50);
            }
        }

        private void BtnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Tag?.Equals("0") == true)
            {
                var threadId = Guid.NewGuid().ToString();

                _logThread = new Thread(new ParameterizedThreadStart(ProcessLog));
                _currentThreadId = _logThread.Name = threadId;
                _threadList.Add(threadId);

                _clearLineCount = Convert.ToInt32(this.upClearLineCount.Value);
                _clearWhenNewFile = chkClearWhenNewFile.Checked;
                txtLog.Clear();

                _logThread.Start(txtPath.Text);

                Properties.Settings.Default.LastPath = txtPath.Text;
                Properties.Settings.Default.Save();

                upClearLineCount.Enabled = false;
                chkClearWhenNewFile.Enabled = false;
                txtPath.Enabled = false;
                btnBrowserFolder.Enabled = false;

                btnStartStop.Text = "Stop";
                btnStartStop.Tag = "1";
            }
            else
            {
                _logThread.Abort();

                upClearLineCount.Enabled = true;
                chkClearWhenNewFile.Enabled = true;
                txtPath.Enabled = true;
                btnBrowserFolder.Enabled = true;

                btnStartStop.Text = "Start";
                btnStartStop.Tag = "0";
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_threadList.Count > 0)
            {
                Debug.WriteLine("Aguardando cancelamento das Threads");
                _cancellAll = true;
                e.Cancel = true;

                var t = new Thread(new ThreadStart(ProcessClose));
                t.Start();
            }
        }

        private void BtnBrowserFolder_Click(object sender, EventArgs e)
        {
            using var f = new FolderBrowserDialog() { SelectedPath = txtPath.Text };
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                txtPath.Text = f.SelectedPath;
                btnStartStop.Enabled = true;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                var lastPath = Properties.Settings.Default.LastPath;
                if (!string.IsNullOrEmpty(lastPath))
                {
                    txtPath.Text = lastPath;
                    btnStartStop.Enabled = true;
                }
            }
            catch (Exception) { }
        }
    }
}
