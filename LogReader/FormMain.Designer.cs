namespace LogReader
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowserFolder = new System.Windows.Forms.Button();
            this.chkClearWhenNewFile = new System.Windows.Forms.CheckBox();
            this.logReaderComponent1 = new LogReader.LogReaderComponent(this.components);
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartStop.Enabled = false;
            this.btnStartStop.Location = new System.Drawing.Point(839, 12);
            this.btnStartStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(88, 55);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Tag = "0";
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.BtnStartStop_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(107, 14);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(556, 23);
            this.txtPath.TabIndex = 1;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLog.ForeColor = System.Drawing.Color.Lime;
            this.txtLog.Location = new System.Drawing.Point(14, 74);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(912, 572);
            this.txtLog.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Directory Path:";
            // 
            // btnBrowserFolder
            // 
            this.btnBrowserFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowserFolder.Location = new System.Drawing.Point(671, 14);
            this.btnBrowserFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBrowserFolder.Name = "btnBrowserFolder";
            this.btnBrowserFolder.Size = new System.Drawing.Size(88, 27);
            this.btnBrowserFolder.TabIndex = 4;
            this.btnBrowserFolder.Text = "Browser";
            this.btnBrowserFolder.UseVisualStyleBackColor = true;
            this.btnBrowserFolder.Click += new System.EventHandler(this.BtnBrowserFolder_Click);
            // 
            // chkClearWhenNewFile
            // 
            this.chkClearWhenNewFile.AutoSize = true;
            this.chkClearWhenNewFile.Checked = true;
            this.chkClearWhenNewFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClearWhenNewFile.Location = new System.Drawing.Point(14, 48);
            this.chkClearWhenNewFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkClearWhenNewFile.Name = "chkClearWhenNewFile";
            this.chkClearWhenNewFile.Size = new System.Drawing.Size(114, 19);
            this.chkClearWhenNewFile.TabIndex = 9;
            this.chkClearWhenNewFile.Text = "Clear on new file";
            this.chkClearWhenNewFile.UseVisualStyleBackColor = true;
            // 
            // logReaderComponent1
            // 
            this.logReaderComponent1.Path = null;
            this.logReaderComponent1.LogChanged += new System.EventHandler<LogReader.LogChangedEventArgs>(this.LogReaderComponent1_LogChanged);
            this.logReaderComponent1.LogFileChanged += new System.EventHandler<LogReader.LogFileChangedEventArgs>(this.LogReaderComponent1_LogFileChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 660);
            this.Controls.Add(this.chkClearWhenNewFile);
            this.Controls.Add(this.btnBrowserFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnStartStop);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormMain";
            this.Text = "Log Reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowserFolder;
        private System.Windows.Forms.CheckBox chkClearWhenNewFile;
        private LogReaderComponent logReaderComponent1;
    }
}

