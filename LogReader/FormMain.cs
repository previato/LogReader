using System;
using System.Windows.Forms;
using NAudio.Wave;
using System.IO;

namespace LogReader
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private WaveOutEvent _outputDevice;
        private WaveFileReader _audioFile;
        private DateTime _lastPlayedAlert;
        private int _textSelection;

        private void PlayAlert()
        {
            if (DateTime.Now > _lastPlayedAlert.AddSeconds(30))
            {
                try
                {
                    var path = Path.Combine(new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location).DirectoryName, "alert.wav");

                    _outputDevice = new WaveOutEvent();
                    _audioFile = new WaveFileReader(path);

                    _outputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;

                    _outputDevice.Init(_audioFile);
                    _outputDevice.Play();
                    _lastPlayedAlert = DateTime.Now;

                    btnEnableScrolling.Enabled = true;
                    _textSelection = txtLog.TextLength;
                }
                catch { }
            }
        }

        private void OutputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            _audioFile?.Dispose();
            _audioFile = null;

            _outputDevice?.Dispose();
            _outputDevice = null;
        }

        private void BtnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Tag?.Equals("0") == true)
            {
                txtLog.Clear();

                logReaderComponent1.Path = txtPath.Text;
                logReaderComponent1.StartListening();

                Properties.Settings.Default.LastPath = txtPath.Text;
                Properties.Settings.Default.Save();

                chkClearWhenNewFile.Enabled = false;
                txtPath.Enabled = false;
                btnBrowserFolder.Enabled = false;

                btnStartStop.Text = "Stop";
                btnStartStop.Tag = "1";
            }
            else
            {
                logReaderComponent1.StopListening();

                chkClearWhenNewFile.Enabled = true;
                txtPath.Enabled = true;
                btnBrowserFolder.Enabled = true;

                btnStartStop.Text = "Start";
                btnStartStop.Tag = "0";
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            logReaderComponent1.StopListening();

            _outputDevice?.Dispose();
            _audioFile?.Dispose();
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

                logReaderComponent1.AlertCondition = txtAlertCondition.Text;
            }
            catch (Exception) { }
        }

        private void LogReaderComponent1_LogChanged(object sender, LogChangedEventArgs e)
        {
            if (!btnEnableScrolling.Enabled)
            {
                txtLog.AppendText(e.Text);
            }
            else
            {
                txtLog.Text += string.Concat(e.Text, "\n");

                txtLog.SelectionStart = _textSelection;
                txtLog.ScrollToCaret();
            }
        }

        private void LogReaderComponent1_LogFileChanged(object sender, LogFileChangedEventArgs e)
        {
            if (chkClearWhenNewFile.Checked)
            {
                txtLog.Clear();
            }

            txtLog.Text += string.Format("---------------- New file created: {0} --------------------", e.FileName);
        }

        private void chkPlayAlert_CheckedChanged(object sender, EventArgs e)
        {
            txtAlertCondition.Enabled = !chkPlayAlert.Checked;
            logReaderComponent1.EnableAlertEvent = chkPlayAlert.Enabled;
        }

        private void txtAlertCondition_TextChanged(object sender, EventArgs e)
        {
            logReaderComponent1.AlertCondition = txtAlertCondition.Text;
        }

        private void logReaderComponent1_AlertConditionOcurred(object sender, EventArgs e)
        {
            PlayAlert();
        }

        private void btnEnableScrolling_Click(object sender, EventArgs e)
        {
            btnEnableScrolling.Enabled = false;

            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.ScrollToCaret();
        }
    }
}
