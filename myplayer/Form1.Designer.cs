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
            this.CloseBtn = new DMSkin.Controls.DMButtonCloseLight();
            this.minBtn = new DMSkin.Controls.DMButtonMinLight();
            this.dmProgressBar = new DMSkin.Controls.DMProgressBar();
            this.dmLabel1 = new DMSkin.Controls.DMLabel();
            this.dmLabel2 = new DMSkin.Controls.DMLabel();
            this.dmLabel3 = new DMSkin.Controls.DMLabel();
            this.dmLabel4 = new DMSkin.Controls.DMLabel();
            this.dmLabel5 = new DMSkin.Controls.DMLabel();
            this.dmVolumeProgress = new DMSkin.Controls.DMProgressBar();
            this.settingBtn = new DMSkin.Controls.DMLabel();
            this.fullBtn = new DMSkin.Controls.DMLabel();
            this.speedPanel = new DMSkin.Metro.Controls.MetroPanel();
            this.metroScrollBar1 = new DMSkin.Metro.Controls.MetroScrollBar();
            this.speedLbl = new System.Windows.Forms.Label();
            this.speedLbl0 = new System.Windows.Forms.Label();
            this.player = new AxAPlayer3Lib.AxPlayer();
            this.playListGrid = new DMPlay.DMControl();
            this.speedPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.BackColor = System.Drawing.Color.Transparent;
            this.CloseBtn.Location = new System.Drawing.Point(977, 2);
            this.CloseBtn.MaximumSize = new System.Drawing.Size(30, 27);
            this.CloseBtn.MinimumSize = new System.Drawing.Size(30, 27);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(30, 27);
            this.CloseBtn.TabIndex = 25;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // minBtn
            // 
            this.minBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minBtn.BackColor = System.Drawing.Color.Transparent;
            this.minBtn.Location = new System.Drawing.Point(941, 2);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(30, 27);
            this.minBtn.TabIndex = 27;
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click);
            // 
            // dmProgressBar
            // 
            this.dmProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dmProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(60)))), ((int)(((byte)(67)))));
            this.dmProgressBar.DM_BackColor = System.Drawing.Color.Gray;
            this.dmProgressBar.DM_BlockColor = System.Drawing.SystemColors.MenuHighlight;
            this.dmProgressBar.DM_BufferColor = System.Drawing.Color.Empty;
            this.dmProgressBar.DM_BufferValue = 0D;
            this.dmProgressBar.DM_DrawRound = true;
            this.dmProgressBar.Dm_OperationModel = DMSkin.Controls.DMProgressBar.OperationModel.Slide;
            this.dmProgressBar.DM_RoundColor = System.Drawing.Color.WhiteSmoke;
            this.dmProgressBar.DM_RoundSize = 10;
            this.dmProgressBar.DM_RoundX = 2;
            this.dmProgressBar.DM_RoundY = 7;
            this.dmProgressBar.DM_Value = 10.1D;
            this.dmProgressBar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.dmProgressBar.Location = new System.Drawing.Point(15, 487);
            this.dmProgressBar.Name = "dmProgressBar";
            this.dmProgressBar.Size = new System.Drawing.Size(977, 25);
            this.dmProgressBar.TabIndex = 28;
            this.dmProgressBar.Text = "dmProgressBar1";
            // 
            // dmLabel1
            // 
            this.dmLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dmLabel1.BackColor = System.Drawing.Color.Transparent;
            this.dmLabel1.DM_Color = System.Drawing.SystemColors.Highlight;
            this.dmLabel1.DM_Font_Size = 22F;
            this.dmLabel1.DM_Key = DMSkin.Controls.DMLabelKey.播放;
            this.dmLabel1.DM_Text = "";
            this.dmLabel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dmLabel1.Location = new System.Drawing.Point(120, 519);
            this.dmLabel1.Name = "dmLabel1";
            this.dmLabel1.Size = new System.Drawing.Size(28, 30);
            this.dmLabel1.TabIndex = 29;
            this.dmLabel1.Text = "dmLabel1";
            // 
            // dmLabel2
            // 
            this.dmLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dmLabel2.BackColor = System.Drawing.Color.Transparent;
            this.dmLabel2.DM_Color = System.Drawing.SystemColors.ControlDark;
            this.dmLabel2.DM_Font_Size = 13F;
            this.dmLabel2.DM_Key = DMSkin.Controls.DMLabelKey.菜单;
            this.dmLabel2.DM_Text = "";
            this.dmLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dmLabel2.Location = new System.Drawing.Point(935, 526);
            this.dmLabel2.Name = "dmLabel2";
            this.dmLabel2.Size = new System.Drawing.Size(28, 30);
            this.dmLabel2.TabIndex = 29;
            this.dmLabel2.Text = "dmLabel1";
            // 
            // dmLabel3
            // 
            this.dmLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dmLabel3.BackColor = System.Drawing.Color.Transparent;
            this.dmLabel3.DM_Color = System.Drawing.SystemColors.ControlDark;
            this.dmLabel3.DM_Font_Size = 14F;
            this.dmLabel3.DM_Key = DMSkin.Controls.DMLabelKey.打开;
            this.dmLabel3.DM_Text = "";
            this.dmLabel3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dmLabel3.Location = new System.Drawing.Point(23, 524);
            this.dmLabel3.Name = "dmLabel3";
            this.dmLabel3.Size = new System.Drawing.Size(28, 30);
            this.dmLabel3.TabIndex = 29;
            this.dmLabel3.Text = "dmLabel1";
            // 
            // dmLabel4
            // 
            this.dmLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dmLabel4.BackColor = System.Drawing.Color.Transparent;
            this.dmLabel4.DM_Color = System.Drawing.SystemColors.ControlDark;
            this.dmLabel4.DM_Font_Size = 13F;
            this.dmLabel4.DM_Key = DMSkin.Controls.DMLabelKey.停止;
            this.dmLabel4.DM_Text = "";
            this.dmLabel4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dmLabel4.Location = new System.Drawing.Point(88, 525);
            this.dmLabel4.Name = "dmLabel4";
            this.dmLabel4.Size = new System.Drawing.Size(28, 30);
            this.dmLabel4.TabIndex = 29;
            this.dmLabel4.Text = "dmLabel1";
            // 
            // dmLabel5
            // 
            this.dmLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dmLabel5.BackColor = System.Drawing.Color.Transparent;
            this.dmLabel5.DM_Color = System.Drawing.SystemColors.ControlDark;
            this.dmLabel5.DM_Font_Size = 15F;
            this.dmLabel5.DM_Key = DMSkin.Controls.DMLabelKey.音量_小;
            this.dmLabel5.DM_Text = "";
            this.dmLabel5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dmLabel5.Location = new System.Drawing.Point(825, 523);
            this.dmLabel5.Name = "dmLabel5";
            this.dmLabel5.Size = new System.Drawing.Size(28, 30);
            this.dmLabel5.TabIndex = 29;
            this.dmLabel5.Text = "dmLabel1";
            // 
            // dmVolumeProgress
            // 
            this.dmVolumeProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dmVolumeProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(60)))), ((int)(((byte)(67)))));
            this.dmVolumeProgress.DM_BackColor = System.Drawing.Color.Silver;
            this.dmVolumeProgress.DM_BlockColor = System.Drawing.Color.White;
            this.dmVolumeProgress.DM_BufferColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dmVolumeProgress.DM_BufferValue = 0D;
            this.dmVolumeProgress.DM_DrawRound = true;
            this.dmVolumeProgress.Dm_OperationModel = DMSkin.Controls.DMProgressBar.OperationModel.Slide;
            this.dmVolumeProgress.DM_RoundColor = System.Drawing.Color.White;
            this.dmVolumeProgress.DM_RoundSize = 10;
            this.dmVolumeProgress.DM_RoundX = 2;
            this.dmVolumeProgress.DM_RoundY = 6;
            this.dmVolumeProgress.DM_Value = 0D;
            this.dmVolumeProgress.Location = new System.Drawing.Point(841, 521);
            this.dmVolumeProgress.Name = "dmVolumeProgress";
            this.dmVolumeProgress.Size = new System.Drawing.Size(80, 23);
            this.dmVolumeProgress.TabIndex = 30;
            this.dmVolumeProgress.Text = "dmProgressBar1";
            // 
            // settingBtn
            // 
            this.settingBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingBtn.BackColor = System.Drawing.Color.Transparent;
            this.settingBtn.DM_Color = System.Drawing.SystemColors.ControlDark;
            this.settingBtn.DM_Font_Size = 13F;
            this.settingBtn.DM_Key = DMSkin.Controls.DMLabelKey.设置;
            this.settingBtn.DM_Text = "";
            this.settingBtn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.settingBtn.Location = new System.Drawing.Point(911, 10);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(28, 30);
            this.settingBtn.TabIndex = 29;
            this.settingBtn.Text = "settingBtn";
            this.settingBtn.Click += new System.EventHandler(this.settingBtn_Click);
            // 
            // fullBtn
            // 
            this.fullBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fullBtn.BackColor = System.Drawing.Color.Transparent;
            this.fullBtn.DM_Color = System.Drawing.SystemColors.ControlDark;
            this.fullBtn.DM_Font_Size = 13F;
            this.fullBtn.DM_Key = DMSkin.Controls.DMLabelKey.拉伸_放大;
            this.fullBtn.DM_Text = "";
            this.fullBtn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fullBtn.Location = new System.Drawing.Point(967, 525);
            this.fullBtn.Name = "fullBtn";
            this.fullBtn.Size = new System.Drawing.Size(28, 30);
            this.fullBtn.TabIndex = 29;
            this.fullBtn.Text = "fullBtn";
            // 
            // speedPanel
            // 
            this.speedPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.speedPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.speedPanel.Controls.Add(this.metroScrollBar1);
            this.speedPanel.Controls.Add(this.speedLbl);
            this.speedPanel.DM_HorizontalScrollbarBarColor = true;
            this.speedPanel.DM_HorizontalScrollbarDM_HighlightOnWheel = false;
            this.speedPanel.DM_HorizontalScrollbarSize = 10;
            this.speedPanel.DM_ThumbColor = System.Drawing.Color.Gray;
            this.speedPanel.DM_ThumbNormalColor = System.Drawing.Color.Gray;
            this.speedPanel.DM_UseBarColor = true;
            this.speedPanel.DM_UseCustomBackColor = true;
            this.speedPanel.DM_UseCustomForeColor = true;
            this.speedPanel.DM_UseStyleColors = true;
            this.speedPanel.DM_VerticalScrollbar = true;
            this.speedPanel.DM_VerticalScrollbarBarColor = true;
            this.speedPanel.DM_VerticalScrollbarDM_HighlightOnWheel = false;
            this.speedPanel.DM_VerticalScrollbarSize = 10;
            this.speedPanel.Location = new System.Drawing.Point(773, 373);
            this.speedPanel.Name = "speedPanel";
            this.speedPanel.Size = new System.Drawing.Size(42, 178);
            this.speedPanel.TabIndex = 32;
            this.speedPanel.Visible = false;
            this.speedPanel.MouseLeave += new System.EventHandler(this.speedPanel_MouseLeave);
            this.speedPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.speedPanel_MouseMove);
            // 
            // metroScrollBar1
            // 
            this.metroScrollBar1.DM_LargeChange = 10;
            this.metroScrollBar1.DM_Maximum = 100;
            this.metroScrollBar1.DM_Minimum = 0;
            this.metroScrollBar1.DM_MouseWheelBarPartitions = 10;
            this.metroScrollBar1.DM_ScrollbarSize = 10;
            this.metroScrollBar1.DM_ThumbColor = System.Drawing.Color.Gray;
            this.metroScrollBar1.DM_ThumbNormalColor = System.Drawing.Color.Gray;
            this.metroScrollBar1.DM_UseBarColor = true;
            this.metroScrollBar1.DM_UseSelectable = true;
            this.metroScrollBar1.Location = new System.Drawing.Point(15, 11);
            this.metroScrollBar1.Name = "metroScrollBar1";
            this.metroScrollBar1.Orientation = DMSkin.Metro.Controls.MetroScrollOrientation.Vertical;
            this.metroScrollBar1.Size = new System.Drawing.Size(10, 131);
            this.metroScrollBar1.TabIndex = 33;
            this.metroScrollBar1.MouseEnter += new System.EventHandler(this.metroScrollBar1_MouseEnter);
            // 
            // speedLbl
            // 
            this.speedLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.speedLbl.AutoSize = true;
            this.speedLbl.Location = new System.Drawing.Point(6, 153);
            this.speedLbl.Name = "speedLbl";
            this.speedLbl.Size = new System.Drawing.Size(29, 12);
            this.speedLbl.TabIndex = 2;
            this.speedLbl.Text = "常速";
            // 
            // speedLbl0
            // 
            this.speedLbl0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.speedLbl0.AutoSize = true;
            this.speedLbl0.Location = new System.Drawing.Point(780, 527);
            this.speedLbl0.Name = "speedLbl0";
            this.speedLbl0.Size = new System.Drawing.Size(29, 12);
            this.speedLbl0.TabIndex = 2;
            this.speedLbl0.Text = "常速";
            this.speedLbl0.MouseEnter += new System.EventHandler(this.speedLbl0_MouseEnter);
            this.speedLbl0.MouseHover += new System.EventHandler(this.speedLbl0_MouseHover);
            // 
            // player
            // 
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(194, 108);
            this.player.Name = "player";
            this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
            this.player.Size = new System.Drawing.Size(336, 234);
            this.player.TabIndex = 33;
            // 
            // playListGrid
            // 
            this.playListGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playListGrid.ArrowColor = System.Drawing.Color.Empty;
            this.playListGrid.BackColor = System.Drawing.Color.Transparent;
            this.playListGrid.ItemColor = System.Drawing.Color.Empty;
            this.playListGrid.ItemMouseOnColor = System.Drawing.Color.Empty;
            this.playListGrid.Location = new System.Drawing.Point(792, 37);
            this.playListGrid.Name = "playListGrid";
            this.playListGrid.ScrollArrowBackColor = System.Drawing.Color.Silver;
            this.playListGrid.ScrollBackColor = System.Drawing.Color.Transparent;
            this.playListGrid.ScrollSliderDefaultColor = System.Drawing.Color.LightGray;
            this.playListGrid.ScrollSliderDownColor = System.Drawing.Color.Gainsboro;
            this.playListGrid.SelectItem = null;
            this.playListGrid.Size = new System.Drawing.Size(215, 442);
            this.playListGrid.SubItemColor = System.Drawing.Color.Empty;
            this.playListGrid.SubItemMouseOnColor = System.Drawing.Color.Empty;
            this.playListGrid.SubItemSelectColor = System.Drawing.Color.Empty;
            this.playListGrid.TabIndex = 31;
            this.playListGrid.Text = "PlayList";
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(60)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(1014, 566);
            this.Controls.Add(this.player);
            this.Controls.Add(this.speedPanel);
            this.Controls.Add(this.playListGrid);
            this.Controls.Add(this.dmVolumeProgress);
            this.Controls.Add(this.speedLbl0);
            this.Controls.Add(this.settingBtn);
            this.Controls.Add(this.fullBtn);
            this.Controls.Add(this.dmLabel2);
            this.Controls.Add(this.dmLabel5);
            this.Controls.Add(this.dmLabel4);
            this.Controls.Add(this.dmLabel3);
            this.Controls.Add(this.dmLabel1);
            this.Controls.Add(this.dmProgressBar);
            this.Controls.Add(this.minBtn);
            this.Controls.Add(this.CloseBtn);
            this.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(540, 350);
            this.Name = "PlayerForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.speedPanel.ResumeLayout(false);
            this.speedPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DMSkin.Controls.DMButtonCloseLight CloseBtn;
        private DMSkin.Controls.DMButtonMinLight minBtn;
        private DMSkin.Controls.DMProgressBar dmProgressBar;
        private DMSkin.Controls.DMLabel dmLabel1;
        private DMSkin.Controls.DMLabel dmLabel2;
        private DMSkin.Controls.DMLabel dmLabel3;
        private DMSkin.Controls.DMLabel dmLabel4;
        private DMSkin.Controls.DMLabel dmLabel5;
        private DMSkin.Controls.DMProgressBar dmVolumeProgress;
        private DMPlay.DMControl playListGrid;
        private DMSkin.Controls.DMLabel settingBtn;
        private DMSkin.Controls.DMLabel fullBtn;
        private DMSkin.Metro.Controls.MetroPanel speedPanel;
        private System.Windows.Forms.Label speedLbl;
        private DMSkin.Metro.Controls.MetroScrollBar metroScrollBar1;
        private System.Windows.Forms.Label speedLbl0;
        private AxAPlayer3Lib.AxPlayer player;
    }
}

