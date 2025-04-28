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
            this.chkPlayAlert = new System.Windows.Forms.CheckBox();
            this.txtAlertCondition = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnableScrolling = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartStop.Enabled = false;
            this.btnStartStop.Location = new System.Drawing.Point(858, 12);
            this.btnStartStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(88, 59);
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
            this.txtPath.Size = new System.Drawing.Size(592, 23);
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
            this.txtLog.Location = new System.Drawing.Point(14, 78);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(931, 568);
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
            this.btnBrowserFolder.Location = new System.Drawing.Point(707, 12);
            this.btnBrowserFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBrowserFolder.Name = "btnBrowserFolder";
            this.btnBrowserFolder.Size = new System.Drawing.Size(139, 27);
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
            this.chkClearWhenNewFile.Location = new System.Drawing.Point(14, 50);
            this.chkClearWhenNewFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkClearWhenNewFile.Name = "chkClearWhenNewFile";
            this.chkClearWhenNewFile.Size = new System.Drawing.Size(114, 19);
            this.chkClearWhenNewFile.TabIndex = 9;
            this.chkClearWhenNewFile.Text = "Clear on new file";
            this.chkClearWhenNewFile.UseVisualStyleBackColor = true;
            // 
            // logReaderComponent1
            // 
            this.logReaderComponent1.AlertCondition = null;
            this.logReaderComponent1.EnableAlertEvent = false;
            this.logReaderComponent1.Path = null;
            this.logReaderComponent1.LogChanged += new System.EventHandler<LogReader.LogChangedEventArgs>(this.LogReaderComponent1_LogChanged);
            this.logReaderComponent1.LogFileChanged += new System.EventHandler<LogReader.LogFileChangedEventArgs>(this.LogReaderComponent1_LogFileChanged);
            this.logReaderComponent1.AlertConditionOcurred += new System.EventHandler(this.logReaderComponent1_AlertConditionOcurred);
            // 
            // chkPlayAlert
            // 
            this.chkPlayAlert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPlayAlert.AutoSize = true;
            this.chkPlayAlert.Location = new System.Drawing.Point(612, 50);
            this.chkPlayAlert.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkPlayAlert.Name = "chkPlayAlert";
            this.chkPlayAlert.Size = new System.Drawing.Size(87, 19);
            this.chkPlayAlert.TabIndex = 10;
            this.chkPlayAlert.Text = "Enable alert";
            this.chkPlayAlert.UseVisualStyleBackColor = true;
            this.chkPlayAlert.CheckedChanged += new System.EventHandler(this.chkPlayAlert_CheckedChanged);
            // 
            // txtAlertCondition
            // 
            this.txtAlertCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlertCondition.Location = new System.Drawing.Point(246, 48);
            this.txtAlertCondition.Name = "txtAlertCondition";
            this.txtAlertCondition.Size = new System.Drawing.Size(359, 23);
            this.txtAlertCondition.TabIndex = 11;
            this.txtAlertCondition.Text = "exception";
            this.txtAlertCondition.TextChanged += new System.EventHandler(this.txtAlertCondition_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Alert condition:";
            // 
            // btnEnableScrolling
            // 
            this.btnEnableScrolling.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnableScrolling.Enabled = false;
            this.btnEnableScrolling.Location = new System.Drawing.Point(707, 45);
            this.btnEnableScrolling.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEnableScrolling.Name = "btnEnableScrolling";
            this.btnEnableScrolling.Size = new System.Drawing.Size(139, 27);
            this.btnEnableScrolling.TabIndex = 13;
            this.btnEnableScrolling.Tag = "0";
            this.btnEnableScrolling.Text = "Enable Scrolling";
            this.btnEnableScrolling.UseVisualStyleBackColor = true;
            this.btnEnableScrolling.Click += new System.EventHandler(this.btnEnableScrolling_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 660);
            this.Controls.Add(this.btnEnableScrolling);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAlertCondition);
            this.Controls.Add(this.chkPlayAlert);
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
        private System.Windows.Forms.CheckBox chkPlayAlert;
        private System.Windows.Forms.TextBox txtAlertCondition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnableScrolling;
    }
}

