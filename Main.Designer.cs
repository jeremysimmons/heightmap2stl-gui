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
            this.radOutProgram = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.radOutSource = new System.Windows.Forms.RadioButton();
            this.radOutCustom = new System.Windows.Forms.RadioButton();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnCustom = new System.Windows.Forms.Button();
            this.chkAutoBackup = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numBaseHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numModelHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(538, 37);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(80, 35);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(14, 38);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(476, 26);
            this.txtFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Heightmap Source";
            // 
            // btnPick
            // 
            this.btnPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPick.Location = new System.Drawing.Point(492, 37);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(39, 35);
            this.btnPick.TabIndex = 2;
            this.btnPick.Text = "...";
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // hostSoftwareSite
            // 
            this.hostSoftwareSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hostSoftwareSite.AutoSize = true;
            this.hostSoftwareSite.Location = new System.Drawing.Point(60, 463);
            this.hostSoftwareSite.Name = "hostSoftwareSite";
            this.hostSoftwareSite.Size = new System.Drawing.Size(109, 20);
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
            this.txtLog.Location = new System.Drawing.Point(14, 235);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(604, 205);
            this.txtLog.TabIndex = 10;
            // 
            // numBaseHeight
            // 
            this.numBaseHeight.Location = new System.Drawing.Point(117, 174);
            this.numBaseHeight.Name = "numBaseHeight";
            this.numBaseHeight.Size = new System.Drawing.Size(68, 26);
            this.numBaseHeight.TabIndex = 5;
            // 
            // numModelHeight
            // 
            this.numModelHeight.Location = new System.Drawing.Point(302, 174);
            this.numModelHeight.Name = "numModelHeight";
            this.numModelHeight.Size = new System.Drawing.Size(68, 26);
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
            this.label2.Location = new System.Drawing.Point(14, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Base Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Model Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Program Output";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(540, 446);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 43);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 463);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Uses: ";
            // 
            // radOutProgram
            // 
            this.radOutProgram.AutoSize = true;
            this.radOutProgram.Checked = true;
            this.radOutProgram.Location = new System.Drawing.Point(12, 109);
            this.radOutProgram.Name = "radOutProgram";
            this.radOutProgram.Size = new System.Drawing.Size(94, 24);
            this.radOutProgram.TabIndex = 13;
            this.radOutProgram.TabStop = true;
            this.radOutProgram.Text = "Program";
            this.radOutProgram.UseVisualStyleBackColor = true;
            this.radOutProgram.Click += new System.EventHandler(this.radOutput_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Output Path";
            // 
            // radOutSource
            // 
            this.radOutSource.AutoSize = true;
            this.radOutSource.Location = new System.Drawing.Point(112, 109);
            this.radOutSource.Name = "radOutSource";
            this.radOutSource.Size = new System.Drawing.Size(85, 24);
            this.radOutSource.TabIndex = 15;
            this.radOutSource.Text = "Source";
            this.radOutSource.UseVisualStyleBackColor = true;
            this.radOutSource.Click += new System.EventHandler(this.radOutput_Click);
            // 
            // radOutCustom
            // 
            this.radOutCustom.AutoSize = true;
            this.radOutCustom.Location = new System.Drawing.Point(203, 109);
            this.radOutCustom.Name = "radOutCustom";
            this.radOutCustom.Size = new System.Drawing.Size(89, 24);
            this.radOutCustom.TabIndex = 16;
            this.radOutCustom.Text = "Custom";
            this.radOutCustom.UseVisualStyleBackColor = true;
            this.radOutCustom.Click += new System.EventHandler(this.radOutput_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(13, 138);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(606, 26);
            this.txtOutput.TabIndex = 17;
            // 
            // btnCustom
            // 
            this.btnCustom.Location = new System.Drawing.Point(298, 108);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(39, 27);
            this.btnCustom.TabIndex = 18;
            this.btnCustom.Text = "...";
            this.btnCustom.UseVisualStyleBackColor = true;
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // chkAutoBackup
            // 
            this.chkAutoBackup.AutoSize = true;
            this.chkAutoBackup.Checked = true;
            this.chkAutoBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoBackup.Location = new System.Drawing.Point(491, 109);
            this.chkAutoBackup.Name = "chkAutoBackup";
            this.chkAutoBackup.Size = new System.Drawing.Size(127, 24);
            this.chkAutoBackup.TabIndex = 19;
            this.chkAutoBackup.Text = "Auto Backup";
            this.chkAutoBackup.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 496);
            this.Controls.Add(this.chkAutoBackup);
            this.Controls.Add(this.btnCustom);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.radOutCustom);
            this.Controls.Add(this.radOutSource);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.radOutProgram);
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
            this.Name = "Main";
            this.Text = "heightmap2stl";
            ((System.ComponentModel.ISupportInitialize)(this.numBaseHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numModelHeight)).EndInit();
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
        private System.Windows.Forms.RadioButton radOutProgram;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radOutSource;
        private System.Windows.Forms.RadioButton radOutCustom;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnCustom;
        private System.Windows.Forms.CheckBox chkAutoBackup;
    }
}

