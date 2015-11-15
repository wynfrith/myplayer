namespace myplayer
{
    partial class Snapshot
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
            this.pathLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.numBox = new System.Windows.Forms.NumericUpDown();
            this.timesBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.dirBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timesBox)).BeginInit();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Location = new System.Drawing.Point(417, 0);
            this.closeBtn.MaximumSize = new System.Drawing.Size(30, 27);
            this.closeBtn.MinimumSize = new System.Drawing.Size(30, 27);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(30, 27);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(191)))), ((int)(((byte)(99)))));
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(14, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "连续截图";
            // 
            // pathLbl
            // 
            this.pathLbl.AutoSize = true;
            this.pathLbl.Location = new System.Drawing.Point(31, 54);
            this.pathLbl.Name = "pathLbl";
            this.pathLbl.Size = new System.Drawing.Size(77, 12);
            this.pathLbl.TabIndex = 4;
            this.pathLbl.Text = "存储文件夹：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "截图张数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "截取间隔：";
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(319, 50);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 23);
            this.openBtn.TabIndex = 5;
            this.openBtn.Text = "浏览";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(193, 176);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 5;
            this.startBtn.Text = "开始截图";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // numBox
            // 
            this.numBox.Location = new System.Drawing.Point(114, 90);
            this.numBox.Name = "numBox";
            this.numBox.Size = new System.Drawing.Size(44, 21);
            this.numBox.TabIndex = 7;
            // 
            // timesBox
            // 
            this.timesBox.Location = new System.Drawing.Point(113, 131);
            this.timesBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.timesBox.Name = "timesBox";
            this.timesBox.Size = new System.Drawing.Size(45, 21);
            this.timesBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "ms";
            // 
            // dirBox
            // 
            this.dirBox.Location = new System.Drawing.Point(113, 51);
            this.dirBox.Name = "dirBox";
            this.dirBox.Size = new System.Drawing.Size(196, 21);
            this.dirBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "(限制100张)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "(0-1000毫秒)";
            // 
            // Snapshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 238);
            this.Controls.Add(this.dirBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.timesBox);
            this.Controls.Add(this.numBox);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pathLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeBtn);
            this.Name = "Snapshot";
            this.Text = "Snapshot";
            this.Load += new System.EventHandler(this.Snapshot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timesBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DMSkin.Controls.DMButtonCloseLight closeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pathLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.NumericUpDown numBox;
        private System.Windows.Forms.NumericUpDown timesBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dirBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}