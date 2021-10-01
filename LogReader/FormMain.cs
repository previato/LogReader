using System;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace LogReader
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
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

        private void LogReaderComponent1_LogChanged(object sender, LogChangedEventArgs e)
        {
            txtLog.AppendText(e.Text);
        }

        private void LogReaderComponent1_LogFileChanged(object sender, LogFileChangedEventArgs e)
        {
            if (chkClearWhenNewFile.Checked) {
                txtLog.Clear();
            }

            txtLog.Text += string.Format("---------------- New file created: {0} --------------------", e.FileName);
        }
    }
}
