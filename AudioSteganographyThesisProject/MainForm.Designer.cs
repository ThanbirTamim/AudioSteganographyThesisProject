
namespace AudioSteganographyThesisProject
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseCoverAudio = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.playPicBox = new System.Windows.Forms.PictureBox();
            this.pausePicBox = new System.Windows.Forms.PictureBox();
            this.txtSecretMessage = new System.Windows.Forms.RichTextBox();
            this.txtMeaturement = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.lblTxtCount = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.radioProposed = new System.Windows.Forms.RadioButton();
            this.radioAlgorithm1 = new System.Windows.Forms.RadioButton();
            this.radioAlgorithm2 = new System.Windows.Forms.RadioButton();
            this.lblMaxLetter = new System.Windows.Forms.Label();
            this.radioAlgorithm4 = new System.Windows.Forms.RadioButton();
            this.radioAlgorithm3 = new System.Windows.Forms.RadioButton();
            this.radioAlgorithm5 = new System.Windows.Forms.RadioButton();
            this.btnCoverWavDownload = new System.Windows.Forms.Button();
            this.btnStegoWavDownload = new System.Windows.Forms.Button();
            this.pictureBoxStegoWave = new System.Windows.Forms.PictureBox();
            this.pictureBoxCoverWave = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pausePicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStegoWave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverWave)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(239, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Audio Steganography";
            // 
            // btnBrowseCoverAudio
            // 
            this.btnBrowseCoverAudio.BackColor = System.Drawing.Color.OldLace;
            this.btnBrowseCoverAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseCoverAudio.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseCoverAudio.Location = new System.Drawing.Point(454, 83);
            this.btnBrowseCoverAudio.Name = "btnBrowseCoverAudio";
            this.btnBrowseCoverAudio.Size = new System.Drawing.Size(98, 38);
            this.btnBrowseCoverAudio.TabIndex = 1;
            this.btnBrowseCoverAudio.Text = "Browse";
            this.btnBrowseCoverAudio.UseVisualStyleBackColor = false;
            this.btnBrowseCoverAudio.Click += new System.EventHandler(this.btnBrowseCoverAudio_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFileName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(111, 90);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(336, 25);
            this.txtFileName.TabIndex = 2;
            // 
            // playPicBox
            // 
            this.playPicBox.BackColor = System.Drawing.Color.Transparent;
            this.playPicBox.Image = global::AudioSteganographyThesisProject.Properties.Resources.playremovebg;
            this.playPicBox.Location = new System.Drawing.Point(61, 83);
            this.playPicBox.Name = "playPicBox";
            this.playPicBox.Size = new System.Drawing.Size(43, 38);
            this.playPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playPicBox.TabIndex = 5;
            this.playPicBox.TabStop = false;
            this.playPicBox.Click += new System.EventHandler(this.playPicBox_Click);
            // 
            // pausePicBox
            // 
            this.pausePicBox.BackColor = System.Drawing.Color.Transparent;
            this.pausePicBox.Image = global::AudioSteganographyThesisProject.Properties.Resources.pauseremovebg;
            this.pausePicBox.Location = new System.Drawing.Point(61, 83);
            this.pausePicBox.Name = "pausePicBox";
            this.pausePicBox.Size = new System.Drawing.Size(43, 38);
            this.pausePicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pausePicBox.TabIndex = 6;
            this.pausePicBox.TabStop = false;
            this.pausePicBox.Visible = false;
            this.pausePicBox.Click += new System.EventHandler(this.pausePicBox_Click);
            // 
            // txtSecretMessage
            // 
            this.txtSecretMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecretMessage.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecretMessage.Location = new System.Drawing.Point(61, 127);
            this.txtSecretMessage.Name = "txtSecretMessage";
            this.txtSecretMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtSecretMessage.Size = new System.Drawing.Size(491, 155);
            this.txtSecretMessage.TabIndex = 7;
            this.txtSecretMessage.Text = "";
            this.txtSecretMessage.TextChanged += new System.EventHandler(this.txtSecretMessage_TextChanged);
            // 
            // txtMeaturement
            // 
            this.txtMeaturement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMeaturement.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeaturement.Location = new System.Drawing.Point(61, 542);
            this.txtMeaturement.Name = "txtMeaturement";
            this.txtMeaturement.ReadOnly = true;
            this.txtMeaturement.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtMeaturement.Size = new System.Drawing.Size(667, 89);
            this.txtMeaturement.TabIndex = 8;
            this.txtMeaturement.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(564, 518);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Meaturement Metrix ";
            // 
            // btnExtract
            // 
            this.btnExtract.BackColor = System.Drawing.Color.Thistle;
            this.btnExtract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtract.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtract.Location = new System.Drawing.Point(374, 288);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(86, 38);
            this.btnExtract.TabIndex = 11;
            this.btnExtract.Text = "Extract";
            this.btnExtract.UseVisualStyleBackColor = false;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // btnHide
            // 
            this.btnHide.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHide.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHide.Location = new System.Drawing.Point(466, 288);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(86, 38);
            this.btnHide.TabIndex = 12;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = false;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // lblTxtCount
            // 
            this.lblTxtCount.AutoSize = true;
            this.lblTxtCount.BackColor = System.Drawing.Color.Transparent;
            this.lblTxtCount.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtCount.Location = new System.Drawing.Point(57, 306);
            this.lblTxtCount.Name = "lblTxtCount";
            this.lblTxtCount.Size = new System.Drawing.Size(122, 21);
            this.lblTxtCount.TabIndex = 13;
            this.lblTxtCount.Text = "Letter Count: 0";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gainsboro;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(282, 288);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 38);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(602, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "  Algorithms  ";
            // 
            // radioProposed
            // 
            this.radioProposed.AutoSize = true;
            this.radioProposed.BackColor = System.Drawing.Color.Transparent;
            this.radioProposed.Checked = true;
            this.radioProposed.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioProposed.Location = new System.Drawing.Point(577, 188);
            this.radioProposed.Name = "radioProposed";
            this.radioProposed.Size = new System.Drawing.Size(151, 23);
            this.radioProposed.TabIndex = 16;
            this.radioProposed.TabStop = true;
            this.radioProposed.Text = "Proposed Technique";
            this.radioProposed.UseVisualStyleBackColor = false;
            this.radioProposed.CheckedChanged += new System.EventHandler(this.radioProposed_CheckedChanged);
            // 
            // radioAlgorithm1
            // 
            this.radioAlgorithm1.AutoSize = true;
            this.radioAlgorithm1.BackColor = System.Drawing.Color.Transparent;
            this.radioAlgorithm1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAlgorithm1.Location = new System.Drawing.Point(577, 217);
            this.radioAlgorithm1.Name = "radioAlgorithm1";
            this.radioAlgorithm1.Size = new System.Drawing.Size(133, 23);
            this.radioAlgorithm1.TabIndex = 17;
            this.radioAlgorithm1.Text = "Exist Technique 1";
            this.radioAlgorithm1.UseVisualStyleBackColor = false;
            this.radioAlgorithm1.CheckedChanged += new System.EventHandler(this.radioAlgorithm1_CheckedChanged);
            // 
            // radioAlgorithm2
            // 
            this.radioAlgorithm2.AutoSize = true;
            this.radioAlgorithm2.BackColor = System.Drawing.Color.Transparent;
            this.radioAlgorithm2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAlgorithm2.Location = new System.Drawing.Point(577, 246);
            this.radioAlgorithm2.Name = "radioAlgorithm2";
            this.radioAlgorithm2.Size = new System.Drawing.Size(133, 23);
            this.radioAlgorithm2.TabIndex = 18;
            this.radioAlgorithm2.Text = "Exist Technique 2";
            this.radioAlgorithm2.UseVisualStyleBackColor = false;
            this.radioAlgorithm2.CheckedChanged += new System.EventHandler(this.radioAlgorithm2_CheckedChanged);
            // 
            // lblMaxLetter
            // 
            this.lblMaxLetter.AutoSize = true;
            this.lblMaxLetter.BackColor = System.Drawing.Color.Transparent;
            this.lblMaxLetter.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxLetter.Location = new System.Drawing.Point(57, 285);
            this.lblMaxLetter.Name = "lblMaxLetter";
            this.lblMaxLetter.Size = new System.Drawing.Size(109, 21);
            this.lblMaxLetter.TabIndex = 19;
            this.lblMaxLetter.Text = "Max Letter: 0";
            // 
            // radioAlgorithm4
            // 
            this.radioAlgorithm4.AutoSize = true;
            this.radioAlgorithm4.BackColor = System.Drawing.Color.Transparent;
            this.radioAlgorithm4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAlgorithm4.Location = new System.Drawing.Point(577, 304);
            this.radioAlgorithm4.Name = "radioAlgorithm4";
            this.radioAlgorithm4.Size = new System.Drawing.Size(133, 23);
            this.radioAlgorithm4.TabIndex = 21;
            this.radioAlgorithm4.Text = "Exist Technique 4";
            this.radioAlgorithm4.UseVisualStyleBackColor = false;
            this.radioAlgorithm4.CheckedChanged += new System.EventHandler(this.radioAlgorithm4_CheckedChanged);
            // 
            // radioAlgorithm3
            // 
            this.radioAlgorithm3.AutoSize = true;
            this.radioAlgorithm3.BackColor = System.Drawing.Color.Transparent;
            this.radioAlgorithm3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAlgorithm3.Location = new System.Drawing.Point(577, 275);
            this.radioAlgorithm3.Name = "radioAlgorithm3";
            this.radioAlgorithm3.Size = new System.Drawing.Size(133, 23);
            this.radioAlgorithm3.TabIndex = 20;
            this.radioAlgorithm3.Text = "Exist Technique 3";
            this.radioAlgorithm3.UseVisualStyleBackColor = false;
            this.radioAlgorithm3.CheckedChanged += new System.EventHandler(this.radioAlgorithm3_CheckedChanged);
            // 
            // radioAlgorithm5
            // 
            this.radioAlgorithm5.AutoSize = true;
            this.radioAlgorithm5.BackColor = System.Drawing.Color.Transparent;
            this.radioAlgorithm5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioAlgorithm5.Location = new System.Drawing.Point(577, 329);
            this.radioAlgorithm5.Name = "radioAlgorithm5";
            this.radioAlgorithm5.Size = new System.Drawing.Size(133, 23);
            this.radioAlgorithm5.TabIndex = 22;
            this.radioAlgorithm5.Text = "Exist Technique 5";
            this.radioAlgorithm5.UseVisualStyleBackColor = false;
            this.radioAlgorithm5.Visible = false;
            // 
            // btnCoverWavDownload
            // 
            this.btnCoverWavDownload.BackColor = System.Drawing.Color.OldLace;
            this.btnCoverWavDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCoverWavDownload.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCoverWavDownload.Location = new System.Drawing.Point(466, 363);
            this.btnCoverWavDownload.Name = "btnCoverWavDownload";
            this.btnCoverWavDownload.Size = new System.Drawing.Size(86, 34);
            this.btnCoverWavDownload.TabIndex = 23;
            this.btnCoverWavDownload.Text = "Download";
            this.btnCoverWavDownload.UseVisualStyleBackColor = false;
            this.btnCoverWavDownload.Visible = false;
            this.btnCoverWavDownload.Click += new System.EventHandler(this.btnCoverWavDownload_Click);
            // 
            // btnStegoWavDownload
            // 
            this.btnStegoWavDownload.BackColor = System.Drawing.Color.OldLace;
            this.btnStegoWavDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStegoWavDownload.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStegoWavDownload.Location = new System.Drawing.Point(466, 449);
            this.btnStegoWavDownload.Name = "btnStegoWavDownload";
            this.btnStegoWavDownload.Size = new System.Drawing.Size(86, 34);
            this.btnStegoWavDownload.TabIndex = 24;
            this.btnStegoWavDownload.Text = "Download";
            this.btnStegoWavDownload.UseVisualStyleBackColor = false;
            this.btnStegoWavDownload.Visible = false;
            this.btnStegoWavDownload.Click += new System.EventHandler(this.btnStegoWavDownload_Click);
            // 
            // pictureBoxStegoWave
            // 
            this.pictureBoxStegoWave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxStegoWave.Location = new System.Drawing.Point(123, 432);
            this.pictureBoxStegoWave.Name = "pictureBoxStegoWave";
            this.pictureBoxStegoWave.Size = new System.Drawing.Size(337, 61);
            this.pictureBoxStegoWave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxStegoWave.TabIndex = 25;
            this.pictureBoxStegoWave.TabStop = false;
            // 
            // pictureBoxCoverWave
            // 
            this.pictureBoxCoverWave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxCoverWave.Location = new System.Drawing.Point(123, 349);
            this.pictureBoxCoverWave.Name = "pictureBoxCoverWave";
            this.pictureBoxCoverWave.Size = new System.Drawing.Size(337, 64);
            this.pictureBoxCoverWave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCoverWave.TabIndex = 26;
            this.pictureBoxCoverWave.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 21);
            this.label4.TabIndex = 27;
            this.label4.Text = "Cover";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(64, 443);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 21);
            this.label5.TabIndex = 28;
            this.label5.Text = "Stego";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(61, 384);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 21);
            this.label6.TabIndex = 29;
            this.label6.Text = "Wave";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(66, 466);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 21);
            this.label7.TabIndex = 30;
            this.label7.Text = "Wave";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AudioSteganographyThesisProject.Properties.Resources.background5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(779, 672);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBoxCoverWave);
            this.Controls.Add(this.pictureBoxStegoWave);
            this.Controls.Add(this.btnStegoWavDownload);
            this.Controls.Add(this.btnCoverWavDownload);
            this.Controls.Add(this.radioAlgorithm5);
            this.Controls.Add(this.radioAlgorithm4);
            this.Controls.Add(this.radioAlgorithm3);
            this.Controls.Add(this.lblMaxLetter);
            this.Controls.Add(this.radioAlgorithm2);
            this.Controls.Add(this.radioAlgorithm1);
            this.Controls.Add(this.radioProposed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblTxtCount);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMeaturement);
            this.Controls.Add(this.txtSecretMessage);
            this.Controls.Add(this.pausePicBox);
            this.Controls.Add(this.playPicBox);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnBrowseCoverAudio);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AudioSteganography";
            ((System.ComponentModel.ISupportInitialize)(this.playPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pausePicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStegoWave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverWave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseCoverAudio;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.PictureBox playPicBox;
        private System.Windows.Forms.PictureBox pausePicBox;
        private System.Windows.Forms.RichTextBox txtSecretMessage;
        private System.Windows.Forms.RichTextBox txtMeaturement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Label lblTxtCount;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioProposed;
        private System.Windows.Forms.RadioButton radioAlgorithm1;
        private System.Windows.Forms.RadioButton radioAlgorithm2;
        private System.Windows.Forms.Label lblMaxLetter;
        private System.Windows.Forms.RadioButton radioAlgorithm4;
        private System.Windows.Forms.RadioButton radioAlgorithm3;
        private System.Windows.Forms.RadioButton radioAlgorithm5;
        private System.Windows.Forms.Button btnCoverWavDownload;
        private System.Windows.Forms.Button btnStegoWavDownload;
        private System.Windows.Forms.PictureBox pictureBoxStegoWave;
        private System.Windows.Forms.PictureBox pictureBoxCoverWave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

