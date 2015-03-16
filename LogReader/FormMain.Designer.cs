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
            this.btnStartLog = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowserFolder = new System.Windows.Forms.Button();
            this.btnStopLog = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.upClearLineCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkClearWhenNewFile = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.upClearLineCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartLog
            // 
            this.btnStartLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartLog.Location = new System.Drawing.Point(638, 10);
            this.btnStartLog.Name = "btnStartLog";
            this.btnStartLog.Size = new System.Drawing.Size(75, 48);
            this.btnStartLog.TabIndex = 0;
            this.btnStartLog.Text = "Iniciar";
            this.btnStartLog.UseVisualStyleBackColor = true;
            this.btnStartLog.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(92, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(377, 20);
            this.txtPath.TabIndex = 1;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.Lime;
            this.txtLog.Location = new System.Drawing.Point(12, 64);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(782, 496);
            this.txtLog.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Caminho:";
            // 
            // btnBrowserFolder
            // 
            this.btnBrowserFolder.Location = new System.Drawing.Point(475, 10);
            this.btnBrowserFolder.Name = "btnBrowserFolder";
            this.btnBrowserFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowserFolder.TabIndex = 4;
            this.btnBrowserFolder.Text = "Selecionar";
            this.btnBrowserFolder.UseVisualStyleBackColor = true;
            this.btnBrowserFolder.Click += new System.EventHandler(this.btnBrowserFolder_Click);
            // 
            // btnStopLog
            // 
            this.btnStopLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopLog.Enabled = false;
            this.btnStopLog.Location = new System.Drawing.Point(719, 10);
            this.btnStopLog.Name = "btnStopLog";
            this.btnStopLog.Size = new System.Drawing.Size(75, 48);
            this.btnStopLog.TabIndex = 5;
            this.btnStopLog.Text = "Parar";
            this.btnStopLog.UseVisualStyleBackColor = true;
            this.btnStopLog.Click += new System.EventHandler(this.btnStopLog_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Limpar a cada";
            // 
            // upClearLineCount
            // 
            this.upClearLineCount.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.upClearLineCount.Location = new System.Drawing.Point(92, 38);
            this.upClearLineCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.upClearLineCount.Name = "upClearLineCount";
            this.upClearLineCount.Size = new System.Drawing.Size(87, 20);
            this.upClearLineCount.TabIndex = 7;
            this.upClearLineCount.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "linhas";
            // 
            // chkClearWhenNewFile
            // 
            this.chkClearWhenNewFile.AutoSize = true;
            this.chkClearWhenNewFile.Checked = true;
            this.chkClearWhenNewFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClearWhenNewFile.Location = new System.Drawing.Point(254, 39);
            this.chkClearWhenNewFile.Name = "chkClearWhenNewFile";
            this.chkClearWhenNewFile.Size = new System.Drawing.Size(158, 17);
            this.chkClearWhenNewFile.TabIndex = 9;
            this.chkClearWhenNewFile.Text = "Limpar a cada novo arquivo";
            this.chkClearWhenNewFile.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 572);
            this.Controls.Add(this.chkClearWhenNewFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.upClearLineCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStopLog);
            this.Controls.Add(this.btnBrowserFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnStartLog);
            this.Name = "FormMain";
            this.Text = "Log Reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.upClearLineCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartLog;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowserFolder;
        private System.Windows.Forms.Button btnStopLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown upClearLineCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkClearWhenNewFile;
    }
}

