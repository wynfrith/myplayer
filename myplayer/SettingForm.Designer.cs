namespace myplayer
{
    partial class SettingForm
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
            this.closeBtn = new DMSkin.Controls.DMButtonCloseLight();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dmCheckBox1 = new DMSkin.Controls.DMCheckBox();
            this.dmCheckBox2 = new DMSkin.Controls.DMCheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.picBtn = new System.Windows.Forms.Button();
            this.metroComboBox1 = new DMSkin.Metro.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Location = new System.Drawing.Point(682, 1);
            this.closeBtn.MaximumSize = new System.Drawing.Size(30, 27);
            this.closeBtn.MinimumSize = new System.Drawing.Size(30, 27);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(30, 27);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(60)))), ((int)(((byte)(67)))));
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(13, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "设置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "皮肤：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dmCheckBox1
            // 
            this.dmCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.dmCheckBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dmCheckBox1.Checked = false;
            this.dmCheckBox1.Location = new System.Drawing.Point(31, 92);
            this.dmCheckBox1.Name = "dmCheckBox1";
            this.dmCheckBox1.Size = new System.Drawing.Size(65, 32);
            this.dmCheckBox1.TabIndex = 5;
            this.dmCheckBox1.Text = " 深色";
            // 
            // dmCheckBox2
            // 
            this.dmCheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.dmCheckBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dmCheckBox2.Checked = true;
            this.dmCheckBox2.Location = new System.Drawing.Point(96, 92);
            this.dmCheckBox2.Name = "dmCheckBox2";
            this.dmCheckBox2.Size = new System.Drawing.Size(64, 32);
            this.dmCheckBox2.TabIndex = 5;
            this.dmCheckBox2.Text = " 浅色";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "截图：";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "保存路径";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "保存类型";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.BackColor = System.Drawing.SystemColors.Control;
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.Location = new System.Drawing.Point(96, 179);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(191, 21);
            this.tbName.TabIndex = 16;
            // 
            // picBtn
            // 
            this.picBtn.Location = new System.Drawing.Point(293, 177);
            this.picBtn.Name = "picBtn";
            this.picBtn.Size = new System.Drawing.Size(75, 23);
            this.picBtn.TabIndex = 17;
            this.picBtn.Text = "浏览";
            this.picBtn.UseVisualStyleBackColor = true;
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.DM_UseSelectable = true;
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 24;
            this.metroComboBox1.Items.AddRange(new object[] {
            "JPG",
            "PNG",
            "BMP"});
            this.metroComboBox1.Location = new System.Drawing.Point(97, 207);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(121, 30);
            this.metroComboBox1.TabIndex = 18;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 478);
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.picBtn);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dmCheckBox2);
            this.Controls.Add(this.dmCheckBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeBtn);
            this.Name = "SettingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DMSkin.Controls.DMButtonCloseLight closeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DMSkin.Controls.DMCheckBox dmCheckBox1;
        private DMSkin.Controls.DMCheckBox dmCheckBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button picBtn;
        private DMSkin.Metro.Controls.MetroComboBox metroComboBox1;
    }
}