namespace app
{
    partial class Main
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPick = new System.Windows.Forms.Button();
            this.hostSoftwareSite = new System.Windows.Forms.LinkLabel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.numBaseHeight = new System.Windows.Forms.NumericUpDown();
            this.numModelHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.chkAutoBackup = new System.Windows.Forms.CheckBox();
            this.gbOutputPath = new System.Windows.Forms.GroupBox();
            this.btnCustom = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.radOutCustom = new System.Windows.Forms.RadioButton();
            this.radOutSource = new System.Windows.Forms.RadioButton();
            this.radOutProgram = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numModelHeight)).BeginInit();
            this.gbOutputPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(359, 24);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(53, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(9, 25);
            this.txtFile.Margin = new System.Windows.Forms.Padding(2);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(319, 20);
            this.txtFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Heightmap Source";
            // 
            // btnPick
            // 
            this.btnPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPick.Location = new System.Drawing.Point(331, 24);
            this.btnPick.Margin = new System.Windows.Forms.Padding(2);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(26, 23);
            this.btnPick.TabIndex = 2;
            this.btnPick.Text = "...";
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // hostSoftwareSite
            // 
            this.hostSoftwareSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hostSoftwareSite.AutoSize = true;
            this.hostSoftwareSite.Location = new System.Drawing.Point(47, 297);
            this.hostSoftwareSite.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hostSoftwareSite.Name = "hostSoftwareSite";
            this.hostSoftwareSite.Size = new System.Drawing.Size(72, 13);
            this.hostSoftwareSite.TabIndex = 11;
            this.hostSoftwareSite.TabStop = true;
            this.hostSoftwareSite.Tag = "https://sourceforge.net/projects/heightmap2stl/";
            this.hostSoftwareSite.Text = "heightmap2stl";
            this.hostSoftwareSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.hostSoftwareSite_LinkClicked);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(9, 170);
            this.txtLog.Margin = new System.Windows.Forms.Padding(2);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(404, 118);
            this.txtLog.TabIndex = 10;
            // 
            // numBaseHeight
            // 
            this.numBaseHeight.Location = new System.Drawing.Point(76, 127);
            this.numBaseHeight.Margin = new System.Windows.Forms.Padding(2);
            this.numBaseHeight.Name = "numBaseHeight";
            this.numBaseHeight.Size = new System.Drawing.Size(45, 20);
            this.numBaseHeight.TabIndex = 5;
            // 
            // numModelHeight
            // 
            this.numModelHeight.Location = new System.Drawing.Point(199, 127);
            this.numModelHeight.Margin = new System.Windows.Forms.Padding(2);
            this.numModelHeight.Name = "numModelHeight";
            this.numModelHeight.Size = new System.Drawing.Size(45, 20);
            this.numModelHeight.TabIndex = 7;
            this.numModelHeight.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Base Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Model Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 155);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Program Output";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(360, 292);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(53, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 297);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Uses: ";
            // 
            // chkAutoBackup
            // 
            this.chkAutoBackup.AutoSize = true;
            this.chkAutoBackup.Checked = true;
            this.chkAutoBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoBackup.Location = new System.Drawing.Point(240, 6);
            this.chkAutoBackup.Margin = new System.Windows.Forms.Padding(2);
            this.chkAutoBackup.Name = "chkAutoBackup";
            this.chkAutoBackup.Size = new System.Drawing.Size(88, 17);
            this.chkAutoBackup.TabIndex = 19;
            this.chkAutoBackup.Text = "Auto Backup";
            this.chkAutoBackup.UseVisualStyleBackColor = true;
            // 
            // gbOutputPath
            // 
            this.gbOutputPath.Controls.Add(this.btnCustom);
            this.gbOutputPath.Controls.Add(this.txtOutput);
            this.gbOutputPath.Controls.Add(this.radOutCustom);
            this.gbOutputPath.Controls.Add(this.radOutSource);
            this.gbOutputPath.Controls.Add(this.radOutProgram);
            this.gbOutputPath.Location = new System.Drawing.Point(9, 50);
            this.gbOutputPath.Name = "gbOutputPath";
            this.gbOutputPath.Size = new System.Drawing.Size(403, 72);
            this.gbOutputPath.TabIndex = 20;
            this.gbOutputPath.TabStop = false;
            this.gbOutputPath.Text = "Output Path";
            // 
            // btnCustom
            // 
            this.btnCustom.Location = new System.Drawing.Point(200, 15);
            this.btnCustom.Margin = new System.Windows.Forms.Padding(2);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(26, 23);
            this.btnCustom.TabIndex = 23;
            this.btnCustom.Text = "...";
            this.btnCustom.UseVisualStyleBackColor = true;
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(5, 42);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(2);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(392, 20);
            this.txtOutput.TabIndex = 22;
            // 
            // radOutCustom
            // 
            this.radOutCustom.AutoSize = true;
            this.radOutCustom.Location = new System.Drawing.Point(136, 18);
            this.radOutCustom.Margin = new System.Windows.Forms.Padding(2);
            this.radOutCustom.Name = "radOutCustom";
            this.radOutCustom.Size = new System.Drawing.Size(60, 17);
            this.radOutCustom.TabIndex = 21;
            this.radOutCustom.Text = "Custom";
            this.radOutCustom.UseVisualStyleBackColor = true;
            this.radOutCustom.Click += new System.EventHandler(this.radOutput_Click);
            // 
            // radOutSource
            // 
            this.radOutSource.AutoSize = true;
            this.radOutSource.Location = new System.Drawing.Point(73, 18);
            this.radOutSource.Margin = new System.Windows.Forms.Padding(2);
            this.radOutSource.Name = "radOutSource";
            this.radOutSource.Size = new System.Drawing.Size(59, 17);
            this.radOutSource.TabIndex = 20;
            this.radOutSource.Text = "Source";
            this.radOutSource.UseVisualStyleBackColor = true;
            this.radOutSource.Click += new System.EventHandler(this.radOutput_Click);
            // 
            // radOutProgram
            // 
            this.radOutProgram.AutoSize = true;
            this.radOutProgram.Checked = true;
            this.radOutProgram.Location = new System.Drawing.Point(5, 18);
            this.radOutProgram.Margin = new System.Windows.Forms.Padding(2);
            this.radOutProgram.Name = "radOutProgram";
            this.radOutProgram.Size = new System.Drawing.Size(64, 17);
            this.radOutProgram.TabIndex = 19;
            this.radOutProgram.TabStop = true;
            this.radOutProgram.Text = "Program";
            this.radOutProgram.UseVisualStyleBackColor = true;
            this.radOutProgram.Click += new System.EventHandler(this.radOutput_Click);
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 322);
            this.Controls.Add(this.gbOutputPath);
            this.Controls.Add(this.chkAutoBackup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numModelHeight);
            this.Controls.Add(this.numBaseHeight);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.hostSoftwareSite);
            this.Controls.Add(this.btnPick);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnCreate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Text = "heightmap2stl";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.numBaseHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numModelHeight)).EndInit();
            this.gbOutputPath.ResumeLayout(false);
            this.gbOutputPath.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.LinkLabel hostSoftwareSite;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.NumericUpDown numBaseHeight;
        private System.Windows.Forms.NumericUpDown numModelHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkAutoBackup;
        private System.Windows.Forms.GroupBox gbOutputPath;
        private System.Windows.Forms.Button btnCustom;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.RadioButton radOutCustom;
        private System.Windows.Forms.RadioButton radOutSource;
        private System.Windows.Forms.RadioButton radOutProgram;
    }
}

