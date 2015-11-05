namespace myplayer
{
    partial class PlayerForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            this.player = new AxAPlayer3Lib.AxPlayer();
            this.openBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.processBar = new System.Windows.Forms.TrackBar();
            this.stopBtn = new System.Windows.Forms.Button();
            this.timeLbl = new System.Windows.Forms.Label();
            this.mirrorBtn = new System.Windows.Forms.Button();
            this.snapshot = new System.Windows.Forms.Button();
            this.rotateL90 = new System.Windows.Forms.Button();
            this.gifShot = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.rotateR90 = new System.Windows.Forms.Button();
            this.rotate180 = new System.Windows.Forms.Button();
            this.rotateNormal = new System.Windows.Forms.Button();
            this.gifShotEnd = new System.Windows.Forms.Button();
            this.videoCut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(20, 40);
            this.player.Name = "player";
            this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
            this.player.Size = new System.Drawing.Size(536, 313);
            this.player.TabIndex = 0;
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(577, 33);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 23);
            this.openBtn.TabIndex = 1;
            this.openBtn.Text = "打开";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(577, 76);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(75, 23);
            this.playBtn.TabIndex = 1;
            this.playBtn.Text = "播放";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // processBar
            // 
            this.processBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processBar.Location = new System.Drawing.Point(20, 431);
            this.processBar.Maximum = 1000;
            this.processBar.Name = "processBar";
            this.processBar.Size = new System.Drawing.Size(458, 45);
            this.processBar.TabIndex = 2;
            this.processBar.TabStop = false;
            this.processBar.Scroll += new System.EventHandler(this.processBar_Scroll);
            this.processBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.processBar_MouseUp);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(577, 120);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(75, 23);
            this.stopBtn.TabIndex = 1;
            this.stopBtn.Text = "停止";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // timeLbl
            // 
            this.timeLbl.AutoSize = true;
            this.timeLbl.Location = new System.Drawing.Point(529, 448);
            this.timeLbl.Name = "timeLbl";
            this.timeLbl.Size = new System.Drawing.Size(71, 12);
            this.timeLbl.TabIndex = 3;
            this.timeLbl.Text = "00:00/00:00";
            // 
            // mirrorBtn
            // 
            this.mirrorBtn.Location = new System.Drawing.Point(577, 165);
            this.mirrorBtn.Name = "mirrorBtn";
            this.mirrorBtn.Size = new System.Drawing.Size(75, 23);
            this.mirrorBtn.TabIndex = 4;
            this.mirrorBtn.Text = "镜面";
            this.mirrorBtn.UseVisualStyleBackColor = true;
            this.mirrorBtn.Click += new System.EventHandler(this.mirrorBtn_Click);
            // 
            // snapshot
            // 
            this.snapshot.Location = new System.Drawing.Point(577, 211);
            this.snapshot.Name = "snapshot";
            this.snapshot.Size = new System.Drawing.Size(75, 23);
            this.snapshot.TabIndex = 4;
            this.snapshot.Text = "截图";
            this.snapshot.UseVisualStyleBackColor = true;
            this.snapshot.Click += new System.EventHandler(this.snapshot_Click);
            // 
            // rotateL90
            // 
            this.rotateL90.Location = new System.Drawing.Point(684, 91);
            this.rotateL90.Name = "rotateL90";
            this.rotateL90.Size = new System.Drawing.Size(75, 23);
            this.rotateL90.TabIndex = 4;
            this.rotateL90.Text = "逆时针90";
            this.rotateL90.UseVisualStyleBackColor = true;
            this.rotateL90.Click += new System.EventHandler(this.rotateL90_Click);
            // 
            // gifShot
            // 
            this.gifShot.Location = new System.Drawing.Point(577, 255);
            this.gifShot.Name = "gifShot";
            this.gifShot.Size = new System.Drawing.Size(75, 23);
            this.gifShot.TabIndex = 4;
            this.gifShot.Text = "gif截图";
            this.gifShot.UseVisualStyleBackColor = true;
            this.gifShot.Click += new System.EventHandler(this.gifShot_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(529, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "播放速度调节";
            // 
            // speedBar
            // 
            this.speedBar.Location = new System.Drawing.Point(644, 441);
            this.speedBar.Maximum = 20;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(104, 45);
            this.speedBar.TabIndex = 6;
            this.speedBar.TabStop = false;
            this.speedBar.Value = 10;
            this.speedBar.Scroll += new System.EventHandler(this.speedBar_Scroll);
            this.speedBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.speedBar_MouseDown);
            this.speedBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.speedBar_MouseUp);
            // 
            // rotateR90
            // 
            this.rotateR90.Location = new System.Drawing.Point(684, 33);
            this.rotateR90.Name = "rotateR90";
            this.rotateR90.Size = new System.Drawing.Size(75, 23);
            this.rotateR90.TabIndex = 4;
            this.rotateR90.Text = "顺时针90";
            this.rotateR90.UseVisualStyleBackColor = true;
            this.rotateR90.Click += new System.EventHandler(this.rotateR90_Click);
            // 
            // rotate180
            // 
            this.rotate180.Location = new System.Drawing.Point(684, 120);
            this.rotate180.Name = "rotate180";
            this.rotate180.Size = new System.Drawing.Size(75, 23);
            this.rotate180.TabIndex = 4;
            this.rotate180.Text = "顺时针180";
            this.rotate180.UseVisualStyleBackColor = true;
            this.rotate180.Click += new System.EventHandler(this.rotate180_Click);
            // 
            // rotateNormal
            // 
            this.rotateNormal.Location = new System.Drawing.Point(684, 165);
            this.rotateNormal.Name = "rotateNormal";
            this.rotateNormal.Size = new System.Drawing.Size(75, 23);
            this.rotateNormal.TabIndex = 4;
            this.rotateNormal.Text = "还原";
            this.rotateNormal.UseVisualStyleBackColor = true;
            this.rotateNormal.Click += new System.EventHandler(this.rotateNormal_Click);
            // 
            // gifShotEnd
            // 
            this.gifShotEnd.Location = new System.Drawing.Point(577, 341);
            this.gifShotEnd.Name = "gifShotEnd";
            this.gifShotEnd.Size = new System.Drawing.Size(75, 23);
            this.gifShotEnd.TabIndex = 4;
            this.gifShotEnd.Text = "gif结束";
            this.gifShotEnd.UseVisualStyleBackColor = true;
            this.gifShotEnd.Click += new System.EventHandler(this.gifShotEnd_Click);
            // 
            // videoCut
            // 
            this.videoCut.Location = new System.Drawing.Point(577, 298);
            this.videoCut.Name = "videoCut";
            this.videoCut.Size = new System.Drawing.Size(75, 23);
            this.videoCut.TabIndex = 4;
            this.videoCut.Text = "视频截取";
            this.videoCut.UseVisualStyleBackColor = true;
            this.videoCut.Click += new System.EventHandler(this.videoCut_Click);
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 493);
            this.Controls.Add(this.speedBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rotateNormal);
            this.Controls.Add(this.gifShotEnd);
            this.Controls.Add(this.videoCut);
            this.Controls.Add(this.gifShot);
            this.Controls.Add(this.rotateL90);
            this.Controls.Add(this.rotate180);
            this.Controls.Add(this.rotateR90);
            this.Controls.Add(this.snapshot);
            this.Controls.Add(this.mirrorBtn);
            this.Controls.Add(this.timeLbl);
            this.Controls.Add(this.processBar);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.player);
            this.Name = "PlayerForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxAPlayer3Lib.AxPlayer player;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.TrackBar processBar;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Label timeLbl;
        private System.Windows.Forms.Button mirrorBtn;
        private System.Windows.Forms.Button snapshot;
        private System.Windows.Forms.Button rotateL90;
        private System.Windows.Forms.Button gifShot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.Button rotateR90;
        private System.Windows.Forms.Button rotate180;
        private System.Windows.Forms.Button rotateNormal;
        private System.Windows.Forms.Button gifShotEnd;
        private System.Windows.Forms.Button videoCut;
    }
}

