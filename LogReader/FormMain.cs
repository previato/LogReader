using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace LogReader
{
    public partial class FormMain : Form
    {
        private List<String> _threadList;
        private String _currentThreadId;
        private Boolean _cancellAll;
        private Thread _logThread;

        private Boolean _clearWhenNewFile;
        private Int32 _clearLineCount;

        public FormMain()
        {
            InitializeComponent();

            _threadList = new List<string>();
        }

        private String GetMostRecentFile(String path)
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

            var fw = new FileSystemWatcher(path);
            fw.Filter = "*.*";
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

            Action<String> logAppend = (x) =>
            {
                if (lineCount >= _clearLineCount)
                {
                    this.txtLog.Text = string.Concat("==== LIMPANDO DEVIDO AO NÚMERO MÁXIMO DE LINHAS TER ATINGIDO ====", "\r\n");
                    lineCount = 0;
                }
                this.txtLog.AppendText(string.Concat(x, "\r\n"));
                lineCount++;
            };

            Action<String> logText = (x) =>
            {
                this.txtLog.Text = x;
            };

            try
            {
                while (true)
                {
                    logFile = this.GetMostRecentFile(path);
                    if (string.IsNullOrEmpty(logFile))
                    {
                        this.Invoke(logAppend, "Não há arquivos no diretório. Nova tentativa em 2 segundos");
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
                                    this.Invoke(logAppend, firstRead.TrimEnd('\n').TrimEnd('\r'));
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
                                        this.Invoke(logAppend, log);
                                    }

                                    reset.WaitOne(1000);

                                    if (_cancellAll) break;

                                    // verificar se há um arquivo mais recente.
                                    if (hasNewFile)
                                    {
                                        logFile = this.GetMostRecentFile(path);
                                        var act = default(Action<string>);
                                        if (_clearWhenNewFile)
                                        {
                                            act = logText;
                                        }
                                        else
                                        {
                                            act = logAppend;
                                        }
                                        this.Invoke(act, string.Format("------------------- NOVO ARQUIVO: {0} -------------------", logFile));
                                        break;
                                    }
                                }
                            }
                        }
                    } while (hasNewFile);
                }
            }
            catch (System.Threading.ThreadAbortException ex)
            {
                this.Invoke(logAppend, "Leitura de log parada");
                lock (_threadList)
                {
                    _threadList.Remove(id);
                }
            }
            catch (Exception ex)
            {
                this.Invoke(logAppend, ex.ToString());
            }

            lock (_threadList)
            {
                this.Invoke(logAppend, string.Format("Finalizando thread: {0}", id));
                _threadList.Remove(id);
            }
        }

        private void ProcessClose()
        {
            Action act = () =>
            {
                this.Close();
            };
            while (true)
            {
                lock (_threadList)
                {
                    if (_threadList.Count == 0)
                    {
                        this.Invoke(act);
                        break;
                    }
                }
                Thread.Sleep(50);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var threadId = Guid.NewGuid().ToString();

            _logThread = new Thread(new ParameterizedThreadStart(this.ProcessLog));
            _currentThreadId = _logThread.Name = threadId;
            _threadList.Add(threadId);

            _clearLineCount = Convert.ToInt32(this.upClearLineCount.Value);
            _clearWhenNewFile = this.chkClearWhenNewFile.Checked;
            this.txtLog.Clear();

            _logThread.Start(this.txtPath.Text);

            Properties.Settings.Default.LastPath = this.txtPath.Text;
            Properties.Settings.Default.Save();

            this.upClearLineCount.Enabled = false;
            this.chkClearWhenNewFile.Enabled = false;
            this.txtPath.Enabled = false;
            this.btnBrowserFolder.Enabled = false;
            this.btnStartLog.Enabled = false;
            this.btnStopLog.Enabled = true;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_threadList.Count > 0)
            {
                System.Diagnostics.Debug.WriteLine("Aguardando cancelamento das Threads");
                _cancellAll = true;
                e.Cancel = true;

                var t = new Thread(new ThreadStart(this.ProcessClose));
                t.Start();
            }
        }

        private void btnStopLog_Click(object sender, EventArgs e)
        {
            _logThread.Abort();
            this.btnStopLog.Enabled = false;

            this.upClearLineCount.Enabled = true;
            this.chkClearWhenNewFile.Enabled = true;
            this.txtPath.Enabled = true;
            this.btnStartLog.Enabled = true;
            this.btnBrowserFolder.Enabled = true;
        }

        private void btnBrowserFolder_Click(object sender, EventArgs e)
        {
            using (var f = new FolderBrowserDialog() { SelectedPath = this.txtPath.Text })
            {
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.txtPath.Text = f.SelectedPath.TrimEnd('\\') + "\\";
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var lastPath = Properties.Settings.Default.LastPath;
            if (!string.IsNullOrEmpty(lastPath))
            {
                this.txtPath.Text = lastPath;
            }
        }
    }
}
