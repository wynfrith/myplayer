using DMPlay;
using DMSkin.Controls;
using myplayer.helpers;
using myplayer.model;
using myplayer.Properties;
using myplayer.service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace myplayer
{
    public partial class PlayerForm :DMSkin.Main
    {
        SettingForm s; //设置
        Snapshot snapForm; //多张截图窗体

        public System.Windows.Forms.Timer timer;
        public System.Windows.Forms.Timer backTimer;
        
        private List<VideoItem> videoList = new List<VideoItem>();
        private VideoItem playingItem = null; //正在播放的item
        private VideoItem currItem = null; //当前鼠标选中的item
        private long duration = 0;
        private long position = 0;
        public int volume = 0;
        private bool Full = false;
        private Rectangle Nor = new Rectangle(0, 0, 0, 0);
        public int LastCursorX;
        public int LastCursorY;
        public int LastHeight;
        public int LastLeft;
        public int LastTop;
        public int LastWidth;
        public int CursorStayMaxTime = 10;
        public int CursorStayTime = 0;
        public bool isMaxSize = false;
        public bool manualOperation = false; //是否是手动移动进度条， 判断ab循环用
        public int defaultLoopPlay;
        private bool twoPlay = false; //是否是分镜播放

        public PlayerForm()
        {
            InitializeComponent();
            this.timer = new System.Windows.Forms.Timer();
            this.timer.Tick += new EventHandler(this.time_Tick);
            this.timer.Interval = 50;
            this.timer.Enabled = true;
            this.player.Focus();
        }

        /// <summary>
        /// 重新绘制窗体
        /// </summary>
        SolidBrush sb = new SolidBrush(Color.LightCoral);
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.Bilinear;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.FillRectangle(sb, -1, -1, Width + 30, Height + 30);
        }


        /// <summary>
        /// 重绘播放列表
        /// </summary>
        public void InitPlayListView(VideoItem playingItem)
        {
            playListGrid.Items.Clear();
            Font f = new Font("微软雅黑", 10);
            if (videoList != null)
            {
                int indexY = 0;
                for (int i = 0; i < videoList.Count; i++)
                {
                    Item it = new Item();
                    it.Bounds = new Rectangle(0, indexY, 1920, 28);
                    it.Text = videoList[i].Name;
                    it.Url = videoList[i].Url;
                    it.OnLine = videoList[i].IsPlaying;
                    //it.OnLine =videoList[i].IsPlaying;
                    playListGrid.Items.Add(it);
                    indexY += 28;
                }
            }
        }

        Point pt;
        private void canMove_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            pt = Cursor.Position;
        }

        private void canMove_Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int px = Cursor.Position.X - pt.X;
                int py = Cursor.Position.Y - pt.Y;
                this.Location = new Point(this.Location.X + px, this.Location.Y + py);
                pt = Cursor.Position;
            }
        }


        /// <summary>
        /// 初始化主窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Image img = Image.FromFile(@"dance.jpg");
                Bitmap bmp = new Bitmap(img, 200, 300);
                Console.WriteLine(bmp);
                IntPtr pic = bmp.GetHbitmap();
                this.player.SetCustomLogo((int)pic);
            }
            catch
            {
                this.player.SetCustomLogo(-1);
            }
          

            this.volume = Settings.Default.volume;
            if (Settings.Default.picDir == "" || Settings.Default.picDir == null)
            {
                Settings.Default.picDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            }
            UpdateVol();

            InitPlayListView(null);
            this.player.SetConfig(119, "1");
            this.vicePlayer.SetConfig(119, "1");
            this.vicePanel.Width = 0; //默认不显示
            this.player.Focus();

        }

        private void dmControl1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 关闭程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Settings.Default.volume = this.volume;
            Settings.Default.Save();
            if (this.timer.Enabled)
            {
                this.timer.Enabled = false;
            }
            Close();
        }

        private void minBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void fullBtn_Click(object sender, EventArgs e)
        {
            this.FullScreen();
        }

        private void settingBtn_Click(object sender, EventArgs e)
        {
            if (s == null || s.IsDisposed)
            {
                s = new SettingForm();
            }
            s.Show();
        }

        private void ListShowOrHide_Click(object sender, EventArgs e)
        {
            //播放列表的显示和隐藏
            Console.WriteLine(rightPanel.Visible);
            if (!this.Full)
            {
                if (rightPanel.Visible)
                {
                    rightPanel.Hide();
                    player.Dock = DockStyle.Fill;
                }
                else
                {
                    rightPanel.Show();
                }

            }
           
        }
        private void vicePlayer_OnMessage(object sender, AxAPlayer3Lib._IPlayerEvents_OnMessageEvent e)
        {
            Constant.N_MESSAGE nMessage = (Constant.N_MESSAGE)e.nMessage;
            Constant.PLAY_STATE state = (Constant.PLAY_STATE)this.vicePlayer.GetState();
            switch (nMessage)
            {
                case Constant.N_MESSAGE.DOUBLE_LEFT_CLICK:
                    this.FullScreen();
                    break;
                case Constant.N_MESSAGE.RIGHT_CLICK_OUT:
                    int x = e.lParam & 0xffff;
                    int y = e.lParam >> 16;
                    this.metroContextMenu1.Show(this.vicePlayer, new Point(x, y));
                    break;

            }
        }

        private void player_OnMessage(object sender, AxAPlayer3Lib._IPlayerEvents_OnMessageEvent e)
        {
            Constant.N_MESSAGE nMessage = (Constant.N_MESSAGE)e.nMessage;
            Constant.PLAY_STATE state = (Constant.PLAY_STATE)this.player.GetState();
            switch (nMessage)
            {
                case Constant.N_MESSAGE.DOUBLE_LEFT_CLICK:
                    this.FullScreen();
                    break;
                case Constant.N_MESSAGE.RIGHT_CLICK_OUT:
                    int x = e.lParam & 0xffff;
                    int y = e.lParam >> 16;
                    this.metroContextMenu1.Show(player, new Point(x, y));
                    break;

            }
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenAndPlay();
            this.SwitchLoop(false);
            this.speedLbl.Text = "常速";
            this.player.Focus();
        }

        private void Btnplay_Click(object sender, EventArgs e)
        {
            Constant.PLAY_STATE state = (Constant.PLAY_STATE)this.player.GetState();
            if (state == Constant.PLAY_STATE.PS_PLAY)
            {
                this.player.SetConfig(602, "1");
                this.player.SetConfig(621, "1");
                this.player.SetConfig(612, "暂停");
                ClearTip.Clear(player, 1000);

                this.player.Pause();
                if (this.twoPlay)  //副播放器
                {
                    Thread _td = new Thread(new ThreadStart(() => {
                        DeterMineCall(() => { this.vicePlayer.Pause(); });
                    }));
                    _td.Start();
                    
                }
                this.Btnplay.DM_Key = DMSkin.Controls.DMLabelKey.播放;
               
            }
            else if (state == Constant.PLAY_STATE.PS_PAUSED)
            {
                this.player.SetConfig(602, "1");
                this.player.SetConfig(621, "1");
                this.player.SetConfig(612, "播放");
                ClearTip.Clear(player, 1000);
                this.player.Play();
                if (this.twoPlay)  //副播放器
                {
                    this.vicePlayer.Play();
                }
                this.Btnplay.DM_Key = DMSkin.Controls.DMLabelKey.暂停;
            }
        }


        /// <summary>
        /// 主计时器 (核心方法) 
        /// 每50ms自动根据播放器的状态来控制播放器的动作和重绘视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void time_Tick(Object sender, EventArgs e)
        {
            Constant.PLAY_STATE state = (Constant.PLAY_STATE)this.player.GetState();
            
            if (this.isLoop & !this.manualOperation) //处于ab循环状态并且没有手动操作过
            {
                Console.WriteLine("LoopEnd");
                if(this.player.GetPosition() >= this.LoopEnd)
                {
                    this.player.SetPosition(this.LoopStart);
                    if(this.twoPlay)
                    {
                        Thread _td = new Thread(new ThreadStart(() => {
                            DeterMineCall(() => { this.vicePlayer.SetPosition(this.LoopStart); });
                        }));
                        _td.Start();

                        
                    }
                }
                if (this.player.GetPosition() < this.LoopStart)
                {
                    this.player.SetPosition(this.LoopStart);
                    if (this.twoPlay)
                    {
                        Thread _td = new Thread(new ThreadStart(() => {
                            DeterMineCall(() => { this.vicePlayer.SetPosition(this.LoopStart); });
                        }));
                        _td.Start();
                    }
                }
            }
            if (this.player.GetPosition() > this.LoopStart && this.player.GetPosition() < this.LoopEnd)
            {
                this.manualOperation = false;
            }
            switch (state)
            {
                case Constant.PLAY_STATE.PS_PLAY:
                case Constant.PLAY_STATE.PS_PAUSED:  //暂停播放状态
                    this.position = this.player.GetPosition();
                    this.duration = this.player.GetDuration();
                    this.dmProgressBar.DM_Value = this.position / Convert.ToDouble(this.duration) * 100.0;
                    this.posLbl.Text =PlayHelper.GetTime(this.position) + " / " + PlayHelper.GetTime(this.duration);
                    this.dmProgressBar.Invalidate();
                    //this.manualOperation = false;
                    UpdateVol();
                    break;
            }
            if ((state == Constant.PLAY_STATE.PS_READY) && (this.position > 0))
            {
                // this.stopBtn_Click(sender, e);
            }

            if (this.Full)
            {
                if ((this.LastCursorX == Cursor.Position.X) && (this.LastCursorY == Cursor.Position.Y))
                {
                    this.CursorStayTime++;
                }
                else
                {
                    this.CursorStayTime = 0;
                }
                if (Cursor.Position.Y >= (Screen.PrimaryScreen.Bounds.Height - this.menuPanel.Height))
                {
                    this.menuPanel.BringToFront();
                }
                else if (this.CursorStayTime >= this.CursorStayMaxTime)
                {
                    this.player.BringToFront();
                    if (twoPlay)
                    {
                        this.vicePlayer.BringToFront();
                    }
                }
                this.LastCursorX = Cursor.Position.X;
                this.LastCursorY = Cursor.Position.Y;
            }

        }
        /// <summary>
        /// 停止播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dmLabel4_Click(object sender, EventArgs e)
        {
            this.player.Close();
            CloseTwoPlay();
            this.Btnplay.DM_Key = DMSkin.Controls.DMLabelKey.播放;
            this.dmProgressBar.DM_Value = 0;
            this.SwitchLoop(false);
            this.speedLbl.Text = "常速";
            Console.WriteLine("playerPanel:" + this.playerPanel.Width);
            Console.WriteLine("master:" + this.masterPanel.Width);
            Console.WriteLine("master player:" +this.player.Width);
            Console.WriteLine("vice:" + this.vicePanel.Width);
        }

        /// <summary>
        /// 更新音量
        /// </summary>
        public void UpdateVol()
        {
            this.player.SetVolume(this.volume);
            this.dmVolumeProgress.DM_Value = this.volume;
            if(this.volume == 0)
            {
                volLbl.DM_Key = DMSkin.Controls.DMLabelKey.音量_无;
            }
            else if(this.volume > 0 && this.volume <= 30){
                volLbl.DM_Key = DMSkin.Controls.DMLabelKey.音量_小;

            }
            else if (this.volume > 30 && this.volume <= 50)
            {
                volLbl.DM_Key = DMSkin.Controls.DMLabelKey.音量_小;
            }
            else
            {
                volLbl.DM_Key = DMSkin.Controls.DMLabelKey.音量_大;
            }
        }


        /// <summary>
        /// 全屏操作
        /// </summary>
        private Rectangle nor2;
        public void FullScreen()
        {
            if (this.Full)
            {
                base.WindowState = FormWindowState.Normal;
                this.player.Parent = this.masterPanel;
                this.player.Dock = DockStyle.Fill;
                this.vicePlayer.Dock = DockStyle.Fill;
                this.player.BringToFront();
                this.player.Location = this.Nor.Location;
                this.player.Size = this.Nor.Size;
                if (twoPlay)
                {
                    this.vicePlayer.Parent = this.vicePanel;
                    this.vicePlayer.Location = this.nor2.Location;
                    this.vicePlayer.Size = this.nor2.Size;
                }
                this.Full = false;
            }
            else
            {
                this.Nor = new Rectangle(this.player.Location, this.player.Size);
                if (!twoPlay)
                {
                    this.player.Parent = this;
                    this.player.Dock = DockStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    this.player.BringToFront();
                    this.player.Location = new System.Drawing.Point(0, 0);
                    this.player.Size = this.Size;
                }
                else
                {
                    this.nor2 = new Rectangle(this.vicePlayer.Location, this.vicePlayer.Size);
                    this.player.Parent = this;
                    this.vicePlayer.Parent = this;
                    this.player.Dock = DockStyle.None;
                    this.vicePlayer.Dock = DockStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    this.player.BringToFront();
                    this.vicePlayer.BringToFront();
                    this.player.Location = new System.Drawing.Point(0, 0);
                    this.player.Height = this.vicePlayer.Height = this.Height;
                    this.player.Width =this.vicePlayer.Width = this.Width / 2;
                    this.vicePlayer.Location = new System.Drawing.Point(this.player.Width, 0);

                    // this.pla
                }
                
                this.Full = true;
            }
            this.player.Focus();
        }

        /// <summary>
        /// 点击进度条, 根据当前光标位置计算进度条的百分比, 修改播放进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dmProgressBar_Click(object sender, EventArgs e)
        {
            var leftSpace = 10;
            var rightSpace = 10;
            var width = this.dmProgressBar.Size.Width;

            Point p = dmProgressBar.PointToClient(MousePosition);
            // 先判断一下p点的y坐标， 在进度条间距内
            bool validY = p.Y <= 20 && p.Y >= 8;
            bool validX = p.X >= leftSpace && p.X <= width - rightSpace;
            if( validX && validY)
            {
                var offset = p.X - leftSpace;
                var realLength = width - leftSpace - rightSpace;
                //var value = (int)(100.0 * offset / realLength); //鼠标点击对应的value
                //this.dmProgressBar.DM_Value = value;
                var dur = this.player.GetDuration();
                var pos = (int)(1.0 * dur * offset / realLength);
                timer.Stop();
                this.player.SetPosition(pos);
                if (this.twoPlay)  //副播放器
                {
                    
                    Thread _td = new Thread(new ThreadStart(() => {
                        DeterMineCall(() => { this.vicePlayer.SetPosition(pos);  });
                    }));
                    _td.Start();
                }
                //AB区间做判断
                if (this.player.GetPosition() > this.LoopEnd && this.bLbl.Visible == true)
                {
                    this.manualOperation = true;
                }
                else if (this.player.GetPosition() < this.LoopStart && this.bLbl.Visible == true)
                {
                    this.manualOperation = true;
                }
                else
                {
                    this.manualOperation = false;
                }
                timer.Start();
            }
            

        }

        private bool IsMouseDown = false;

        private void dmProgressBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.dmProgressBar.Cursor == Cursors.Hand)
            {
                this.IsMouseDown = true;
                this.timer.Stop();
            }
        }

        private void dmProgressBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsMouseDown)
            {
            }
        }

        private void dmProgressBar_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsMouseDown = false;
            switch (((Constant.PLAY_STATE)this.player.GetState()))
            {
                case Constant.PLAY_STATE.PS_PLAY:
                case Constant.PLAY_STATE.PS_PAUSED:
                    Console.WriteLine(this.player.GetPosition());
                    if (!(this.timer.Enabled || (this.player.GetPosition() == 0)))
                    {
                        double num = this.dmProgressBar.DM_Value;
                        double num2 = num / (100.0) * this.duration;
                        this.player.SetPosition(Convert.ToInt32(num2));
                        if (this.twoPlay)
                        {
                            Thread _td = new Thread(new ThreadStart(() => {
                                DeterMineCall(() => { this.vicePlayer.SetPosition(Convert.ToInt32(num2)); });
                            }));
                            _td.Start();
                            
                        }
                        if(this.player.GetPosition() > this.LoopEnd && this.bLbl.Visible == true)
                        {
                            this.manualOperation = true;
                        }
                        else if(this.player.GetPosition() < this.LoopStart && this.bLbl.Visible == true)
                        {
                            this.manualOperation = true;
                        }
                        else
                        {
                            this.manualOperation = false;
                        }
                        //this.label1.Text = Helper.GetTime(this.axPlayer1.GetPosition()) + "/" + Helper.GetTime(this.axPlayer1.GetDuration());
                        this.timer.Start();
                    }
                    break;
            }
        }

        private void dmVolumeProgress_MouseMove(object sender, MouseEventArgs e)
        {
            int num = 1;
            if (this.IsMouseDown)
            {
                this.volume = ((int)this.dmVolumeProgress.DM_Value) * num;
                this.player.SetConfig(602, "1");
                this.player.SetConfig(621, "1");
                this.player.SetConfig(612, "音量 ("+this.volume+"%)");
                ClearTip.Clear(player, 1000);
                UpdateVol();
            }

        }

        private void dmVolumeProgress_MouseUp(object sender, MouseEventArgs e)
        {
             this.IsMouseDown = false;
             this.player.Focus();
        }

        private void dmVolumeProgress_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.dmVolumeProgress.Cursor == Cursors.Hand)
            {
                this.IsMouseDown = true;
            }

        }

        private void dmVolumeProgress_Click(object sender, EventArgs e)
        {

        }
        private void btns_MouseEnter(object sender, DragEventArgs e)
        {

        }
        private void btns_MouseLeave(object sender, DragEventArgs e)
        {

        }

        private void btns_MouseEnter(object sender, EventArgs e)
        {
            DMLabel label = (DMLabel)sender;
            label.DM_Color = Color.LightPink;
        }

        private void btns_MouseLeave(object sender, EventArgs e)
        {
            DMLabel label = (DMLabel)sender;
            label.DM_Color = Color.White;
        }

        private void topPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.isMaxSize)
            {
                base.Width = this.LastWidth;
                base.Height = this.LastHeight;
                base.Top = this.LastTop;
                base.Left = this.LastLeft;
                this.isMaxSize = false;
                base.CanMove = true;
                base.CanResize = true;
            }
            else
            {
                this.LastWidth = base.Width;
                this.LastHeight = base.Height;
                this.LastTop = base.Top;
                this.LastLeft = base.Left;
                this.isMaxSize = true;
                base.Top = 0;
                base.Left = 0;
                base.Width = Screen.PrimaryScreen.WorkingArea.Width;
                base.Height = Screen.PrimaryScreen.WorkingArea.Height;
                base.CanResize = false;
                base.CanMove = false;
            }
        }

        private void player_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Console.WriteLine((int)e.KeyData);
            if (e.KeyData == Keys.Escape)
            {
                base.WindowState = FormWindowState.Normal;
                this.player.Parent = this.masterPanel;
                this.player.BringToFront();
                this.player.Location = this.Nor.Location;
                this.player.Size = this.Nor.Size;
                this.Full = false;
            }
            else if (e.KeyData == Keys.Enter)
            {
                Btnplay_Click(sender, e);
            }
            else if(e.Modifiers == Keys.Control && e.KeyCode == Keys.D1)
            {
                设置A点ctrl1ToolStripMenuItem_Click(sender, e);
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D2)
            {
                设置B点ctrl2ToolStripMenuItem_Click(sender, e);
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D3)
            {
                取消循环ctrlcToolStripMenuItem_Click(sender, e);
            }

            /**
             *   速度控制快捷键
            **/
            else if (e.Modifiers == Keys.Control && (int)e.KeyCode == 189)
            {
                减少01ToolStripMenuItem_Click(sender, e);
            }
            else if(e.Modifiers == Keys.Control && (int)e.KeyCode == 187)
            {
                增加01ToolStripMenuItem_Click(sender, e);
            }
            else if (e.KeyCode == Keys.R || (e.Modifiers == Keys.Control &&e.KeyCode == Keys.R))
            {
                常速ToolStripMenuItem_Click(sender, e);
            }

            /*
            *   截屏快捷键
            */

            else if(e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                截图altsToolStripMenuItem_Click(sender, e);

            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                连续截图altwToolStripMenuItem_Click(sender, e);
            }

            else
            {
                if (e.KeyData == Keys.Left)
                {
                    快退5秒ToolStripMenuItem_Click(sender, e);
                }
                else if (e.KeyData == Keys.Right)
                {
                    //int maximum = this.metroTrackBar1.Maximum;
                    快进5秒ToolStripMenuItem_Click(sender, e);
                }
                else if (e.KeyData == Keys.Space)
                {
                    Btnplay_Click(sender, e);
                }
                else if (e.KeyData == Keys.Up)
                {
                    音量ToolStripMenuItem1_Click(sender, e);
                }
                else if (e.KeyData == Keys.Down)
                {
                    音量ToolStripMenuItem2_Click(sender, e);
                }
            }
        }

        private void playListGrid_Click(object sender, EventArgs e)
        {
        }

        private void playListGrid_MouseClick(object sender, MouseEventArgs e)
        {

            if(e.Button == MouseButtons.Right)
            {
                var x = this.PointToClient(Control.MousePosition).X;
                var y = this.PointToClient(Control.MousePosition).Y - 40;
                this.metroContextMenu2.Show(player, new Point(x, y));

            }
            

        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           OpenAndPlay();
            this.SwitchLoop(false);
            this.speedLbl.Text = "常速";
            this.player.Focus();
        }

        private void OpenAndPlay()
        {
            VideoItem item = PlayOp.OpenFile();
            if (item == null) return;
            item.IsPlaying = true;
            playingItem = item;
            bool isEqual = false;
            foreach (var item2 in this.videoList)
            {
                if (item2.Name == item.Name)
                {
                    isEqual = true;
                    item2.IsPlaying = true;
                }
                else
                {

                    item2.IsPlaying = false;
                }
            }
            if (!isEqual)
            {
                this.videoList.Add(item);
            }
            InitPlayListView(playingItem);
                CloseTwoPlay();
            this.player.Open(playingItem.Url);
            Btnplay.DM_Key = DMSkin.Controls.DMLabelKey.暂停;
        }

        private void 打开文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                bool isEqual = false;
                PlayHelper.LoopFolder(dialog.SelectedPath, delegate (FileInfo file) {
                    VideoItem item = new VideoItem(file.Name, file.FullName);
                    if (PlayHelper.isRightExt(item))
                    {
                        isEqual = false;
                        foreach (var item2 in this.videoList)
                        {
                            if (item2.Name == item.Name)
                            {
                                isEqual = true;
                                break;
                            }
                        }
                        if (!isEqual)
                        {
                            this.videoList.Add(item);
                        }
                    }
                });
                if (this.player.GetState() == 0)
                {
                    this.InitPlayListView(null);
                }
                else
                {
                    this.InitPlayListView(this.playingItem);
                }
            }
        }

        private void playListGrid_ItemClick(object sender, EventArgs e)
        {
            Console.WriteLine("click");
            Item clickedItem = (Item)sender;

            foreach (var item in this.videoList)
            {
                if (item.Name == clickedItem.Text)
                {
                    Console.WriteLine(clickedItem.Text);
                    this.playingItem = item;
                    item.IsPlaying = true;
                }
                else
                {
                    item.IsPlaying = false; 
                }
            }
            this.InitPlayListView(playingItem);
            this.player.Open(playingItem.Url);
            this.CloseTwoPlay();
            Btnplay.DM_Key = DMSkin.Controls.DMLabelKey.暂停;
            this.player.Focus();

        }

        private void 删除当前项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in this.videoList)
            {
                if (item == currItem)
                {
                    if (currItem.IsPlaying)
                    {
                        closePlayer();
                        this.SwitchLoop(false);
                        this.speedLbl.Text = "常速";
                    }
                    this.videoList.Remove(currItem);
                    this.InitPlayListView(null);
                    break;
                }
            }
            this.player.Focus();
        }

        private void 清空列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.videoList = new List<VideoItem>();
            this.InitPlayListView(null);
            closePlayer();
            CloseTwoPlay();
            this.SwitchLoop(false);
            this.speedLbl.Text = "常速";
            this.player.Focus();
        }

        private void closePlayer() {
            this.player.Close();
            CloseTwoPlay();
            dmProgressBar.DM_Value = 0;
            Btnplay.DM_Key = DMSkin.Controls.DMLabelKey.播放;
            this.player.Focus();
        }

        private void playListGrid_rightItemClick(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e= (MouseEventArgs)e;
            if (mouse_e.Button == MouseButtons.Right)
            {
                Item clickedItem = (Item)sender;
                foreach (var item in this.videoList)
                {
                    if (item.Name == clickedItem.Text)
                    {
                        Console.WriteLine(clickedItem.Text);
                        this.currItem = item;
                        if(clickedItem.OnLine == true)
                        {
                        this.currItem.IsPlaying = true;
                    }
                        break;
                    }
                }

                
                var x = this.PointToClient(Control.MousePosition).X;
                var y = this.PointToClient(Control.MousePosition).Y - 40;
                this.删除当前项ToolStripMenuItem.Enabled = true;
                this.metroContextMenu2.Show(player, new Point(x, y));
            }
            
        }

        private void speedLbl_MouseEnter(object sender, EventArgs e)
        {
            //this.speedPanel.Parent = this;
            //this.speedPanelTimer.Stop();
            //this.speedPanel.BringToFront();
            //this.speedPanel.Show();
            //speedBar.Value = 45;
        }

        public System.Windows.Forms.Timer speedPanelTimer = new System.Windows.Forms.Timer();
        private void speedPanel_MouseLeave(object sender, EventArgs e)
        {
            //this.speedPanel.Hide();
            //设置一个定时器， 如果在这个时间后没有取消定时的话， 那么hide()
            Console.WriteLine("leave");
            this.speedPanelTimer.Tick += new EventHandler(HideSpeedPanel);
            this.speedPanelTimer.Interval =100;
            this.speedPanelTimer.Start();
        }
        private void HideSpeedPanel(Object sender, EventArgs e)
        {
            //this.speedPanel.Hide();
            //this.speedPanelTimer.Stop();
        }

        private void speedPanel_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void speedBar_MouseEnter(object sender, EventArgs e)
        {
            this.speedPanelTimer.Stop();
        }

        private void speedPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void speedLbl_Click(object sender, EventArgs e)
        {
            if (speed01.Visible)
            {
                speed01.Hide();
                speed02.Hide();
                speed03.Hide();
            }else
            {
                speed01.Show();
                speed02.Show();
                speed03.Show();
            }
        }

        private void speedBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsMouseDown)
            {
                int num = 100;
                if (num <= 40)
                {
                    this.player.SetConfig(0x68, "25");
                    if (this.twoPlay)
                    {
                        Thread _td = new Thread(new ThreadStart(() => {
                            DeterMineCall(() => { this.vicePlayer.SetConfig(0x68, "25"); });
                        }));
                        _td.Start();
                        
                    }
                    this.speedLbl.Text = "0.25倍";
                }
                else if (num > 40 && num <= 60)
                {
                    this.player.SetConfig(0x68, "100");
                    if (this.twoPlay)
                    {
                        Thread _td = new Thread(new ThreadStart(() => {
                            DeterMineCall(() => { this.vicePlayer.SetConfig(0x68, "100"); });
                        }));
                        _td.Start();
                       
                    }
                    this.speedLbl.Text = "常速";
                }
                else if(num >60 && num <= 75)
                {
                    this.player.SetConfig(0x68, "150");
                    if (this.twoPlay)
                    {
                        Thread _td = new Thread(new ThreadStart(() => {
                            DeterMineCall(() => { this.vicePlayer.SetConfig(0x68, "150"); });
                        }));
                        _td.Start();
                       
                    }
                    this.speedLbl.Text = "1.5倍";
                }
                Console.WriteLine(num);
                Console.WriteLine("播放速度调节: " + this.player.GetConfig(0x68));
            }
        }

        private void speedBar_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsMouseDown = false;
            this.player.Focus();

        }

        private void speedBar_MouseDown(object sender, MouseEventArgs e)
        {
            //if (this.speedBar.Cursor == Cursors.Hand)
            //{
            //    this.IsMouseDown = true;
            //}
        }

        System.Windows.Forms.Timer mirrorTimer = new System.Windows.Forms.Timer();
        
        private void mirrorBtn_Click(object sender, EventArgs e)
        {
            this.mirrorPanel.Visible = true;
            mirrorTimer.Enabled = false;
            mirrorTimer.Tick += new EventHandler(mirrorTick);
            mirrorTimer.Interval = 200;
            //Console.WriteLine("??");
         
        }
        private void mirrorTick(object sender, EventArgs e)
        {
            mirrorPanel.Visible = false;
            mirrorTimer.Enabled= false;
        }

        private void 截图altsToolStripMenuItem_Click(object sender, EventArgs e)
        {
                if (this.player.GetConfig(701) == "1")
                {
                    this.player.SetConfig(707, "2");
                string dir = Settings.Default.picDir;
                    string date = DateTime.Now.ToString("HHMMddhhmmssfff");
                    string path = dir + "\\截图" + date + ".jpg";
                    Console.WriteLine(path);
                    this.player.SetConfig(702, path);
                     this.player.SetConfig(602, "1");
                     this.player.SetConfig(621, "1");
                     this.player.SetConfig(612, "截图成功");
                     ClearTip.Clear(player, 1000);
                }
        }

        private void 连续截图altwToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (snapForm == null || snapForm.IsDisposed)
            {
                snapForm = new Snapshot(this.player);
            }
            snapForm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1"); //使用线形插值叠图
            this.player.SetConfig(612, "提示成功");
        }

        private void PlayerForm_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void PlayerForm_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private int LoopStart; //A点的position
        private int LoopEnd;  //B点的position
        private bool isLoop = false;
        private void SwitchLoop(bool b)
        {
            if (b)
            {
                this.isLoop = true;
            }
            else
            {
                if (this.isLoop)
                {
                    this.player.SetConfig(602, "1");
                    this.player.SetConfig(621, "1");
                    this.player.SetConfig(612, "取消AB循环");
                    ClearTip.Clear(player, 1000);
                }
                this.isLoop = false;
                this.ALbl.Visible = false;
                this.bLbl.Visible = false;
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        private void BackTick(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 设置A点ctrl1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var BarX = this.dmProgressBar.Location.X;
            var BarY = this.dmProgressBar.Location.Y;

            var BarWidth = this.dmProgressBar.Size.Width;
            var currValue = this.dmProgressBar.DM_Value; //当前进度
            Console.WriteLine(BarWidth);
            var left = new Point(BarX + 7, BarY - 5);  //起始坐标
            var right = new Point(BarX + BarWidth - 18, BarY - 5);  //终止坐标

            this.ALbl.Visible = true;
            var offsetW = left.X + (BarWidth - 19) * currValue / 100.0;
            this.ALbl.Location = new Point((int)offsetW, left.Y);
            if(offsetW < (BarWidth - 19) / 2) //根据位置是指anchor
            {
                this.ALbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            }
            else
            {
                this.ALbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            }
            this.LoopStart = this.player.GetPosition();

            //判断一下B点的横坐标小于A， 那么B = stop的坐标
            if (this.bLbl.Location.X <= offsetW || this.bLbl.Visible == false)
            {
                this.bLbl.Visible = true;
                this.bLbl.Location = new Point(right.X, right.Y - 1);
                this.LoopEnd = this.player.GetDuration();
                this.bLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            }


            //设置视频播放的起点和终点分别为A,B
            this.SwitchLoop(true);

            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1");
            this.player.SetConfig(612, "设置A点");
            ClearTip.Clear(player, 1000);

        }

        private void 设置B点ctrl2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var BarX = this.dmProgressBar.Location.X;
            var BarY = this.dmProgressBar.Location.Y;
            var BarWidth = this.dmProgressBar.Size.Width;
            var currValue = this.dmProgressBar.DM_Value;

            var start = new Point(BarX + 7, BarY - 5);
            var stop = new Point(BarX + BarWidth - 18, BarY - 6);

            this.bLbl.Visible = true;
            var offsetW = start.X + (BarWidth - 19) * currValue / 100.0;
            if (offsetW < (BarWidth - 19) / 2) //根据位置是指anchor
            {
                this.bLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            }
            else
            {
                this.bLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            }
            this.bLbl.Location = new Point((int)offsetW, start.Y);
            this.LoopEnd = this.player.GetPosition();
            this.manualOperation = false;
            if (this.ALbl.Location.X >= offsetW || this.ALbl.Visible == false)
            {
                this.ALbl.Visible = true;
                this.ALbl.Location = new Point(start.X, stop.Y + 1);
                this.ALbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
                this.LoopStart = 0;
            }
            this.SwitchLoop(true);
            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1");
            this.player.SetConfig(612, "设置B点");
            ClearTip.Clear(player, 1000);

        }

        private void 取消循环ctrlcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SwitchLoop(false);
        }

        private void dmProgressBar_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("paint");
        }

        private void dmProgressBar_SizeChanged(object sender, EventArgs e)
        {
            Console.WriteLine("size");
            //A,b亮点重绘
            var BarX = this.dmProgressBar.Location.X;
            var BarY = this.dmProgressBar.Location.Y;
            var BarWidth = this.dmProgressBar.Size.Width;
            var start = new Point(BarX + 7, BarY - 5);

            //重绘A点
            var offsetW = start.X + (BarWidth - 19) * 1.0 * this.LoopStart / this.player.GetDuration();
            this.ALbl.Location = new Point((int)offsetW, start.Y);

            //重绘B点
            offsetW = start.X + (BarWidth - 19) * 1.0 * this.LoopEnd / this.player.GetDuration();
            this.bLbl.Location = new Point((int)offsetW, start.Y - 1);


        }

        private void 音量ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.volume = ((this.volume + 10) > 100) ? 100 : (this.volume + 10);
            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1");
            this.player.SetConfig(612, "音量 (" + this.volume + "%)");
            ClearTip.Clear(player, 1000);
            UpdateVol();
        }

        private void 音量ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.volume = ((this.volume - 10) < 0) ? 0 : (this.volume - 10);
            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1");
            this.player.SetConfig(612, "音量 (" + this.volume + "%)");
            ClearTip.Clear(player, 1000);
            UpdateVol();
        }

        private void 快退5秒ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.timer.Stop();
            this.player.SetVolume(0);
            int num = 0;
            int num2 = this.player.GetPosition() - 500;
            if (this.player.GetPosition() != 0)
            {
                var pos = (num2 > num) ? num2 : num;
                this.player.SetPosition(pos);
                if (this.twoPlay)
                {
                    Thread _td = new Thread(new ThreadStart(() => {
                        DeterMineCall(() => { this.vicePlayer.SetPosition(pos); });
                    }));
                    _td.Start();
                    
                }
                var value = (int)((pos * 1.0 / this.duration) * 100);
                this.dmProgressBar.DM_Value = value;

                this.player.SetConfig(602, "1");
                this.player.SetConfig(621, "1");
                this.player.SetConfig(612, "快退5秒");
                ClearTip.Clear(player, 1000);
                if (this.player.GetPosition() > this.LoopEnd && this.bLbl.Visible == true)
                {
                    this.manualOperation = true;
                }
                else if (this.player.GetPosition() < this.LoopStart && this.bLbl.Visible == true)
                {
                    this.manualOperation = true;
                }
                else
                {
                    this.manualOperation = false;
                }

            }
            this.timer.Start();
            this.player.Focus();
        }

        private void 快进5秒ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.timer.Stop();
            this.player.SetVolume(0);
            int num2 = this.player.GetPosition() + 500;
            if (this.player.GetPosition() != 0)
            {
                var pos = (num2 < this.player.GetDuration()) ? num2 : this.player.GetDuration();
                this.player.SetPosition(pos);
                if (this.twoPlay)
                {
                    Thread _td = new Thread(new ThreadStart(() => {
                        DeterMineCall(() => { this.vicePlayer.SetPosition(pos); });
                    }));
                    _td.Start();
                    
                }
                Console.WriteLine("pos:" + pos);
                Console.WriteLine("dur:" + this.duration);

                var value = (int)((pos * 1.0 / this.duration) * 100);
                Console.WriteLine("value:" + value);
                this.dmProgressBar.DM_Value = value;

                this.player.SetConfig(602, "1");
                this.player.SetConfig(621, "1");
                this.player.SetConfig(612, "快进5秒");
                ClearTip.Clear(player, 1000);
                if (this.player.GetPosition() > this.LoopEnd && this.bLbl.Visible == true)
                {
                    this.manualOperation = true;
                }
                else if (this.player.GetPosition() < this.LoopStart && this.bLbl.Visible == true)
                {
                    this.manualOperation = true;
                }
                else
                {
                    this.manualOperation = false;
                }

            }

            this.timer.Start();
            this.player.Focus();

        }

        private void 常速ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //还原常速
           
            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1");
            this.player.SetConfig(612, "播放速度 (正常)");
            this.speedLbl.Text = "常速";
            ClearTip.Clear(player, 1000);
            this.player.SetConfig(104, "100");
            if (this.twoPlay)
            {
                
                Thread _td = new Thread(new ThreadStart(() => {
                    DeterMineCall(() => { this.vicePlayer.SetConfig(104, "100"); });
                }));
                _td.Start();

            }

        }

        private void 增加01ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //加速 ctrl+q
            int speed = Convert.ToInt32(this.player.GetConfig(104));
           

            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1");
            var per = ((speed + 10) / 100.0);
            Console.WriteLine(per);
            this.player.SetConfig(612, "播放速度 (" + (per == 1.0 ? "正常" : per + "倍") + ")");
            this.speedLbl.Text = (per == 1.0 ? "常速" : per + "倍速");
            ClearTip.Clear(player, 1000);
            if(per> 1.5)
            {
            }
            this.player.SetConfig(104, (speed + 10) + "");
            if (this.twoPlay)
            {
                Thread _td = new Thread(new ThreadStart(() => {
                    DeterMineCall(() => { this.vicePlayer.SetConfig(104, (speed + 10) + ""); });
                }));
                _td.Start();
               
            }
            

        }

        private void 减少01ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //减速 ctrl+s
            int speed = Convert.ToInt32(this.player.GetConfig(104));
           

            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1");
            var per = ((speed - 10) / 100.0);
            if (per == 0.0) per = 0.1;
            this.player.SetConfig(612, "播放速度 (" + (per == 1.0 ? "正常" : per + "倍") + ")");
            this.speedLbl.Text = (per == 1.0 ? "常速" : per + "倍速");
            ClearTip.Clear(player, 1000);
            if(per < 0.7)
            {
            }
            this.player.SetConfig(104, (speed - 10) + "");
            if (this.twoPlay)
            {
                Thread _td = new Thread(new ThreadStart(() => {
                    DeterMineCall(() => { this.vicePlayer.SetConfig(104, (speed - 10) + ""); });
                }));
                _td.Start();

              
            }

        }

        private void 倍ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //0.1
            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1");
            this.player.SetConfig(612, "播放速度 (0.1倍速)");
            this.speedLbl.Text = "0.1倍速";
            ClearTip.Clear(player, 1000);
            this.player.SetConfig(104, "10");
            if (this.twoPlay)
            {
                Thread _td = new Thread(new ThreadStart(() => {
                    DeterMineCall(() => { this.vicePlayer.SetConfig(104, "10"); });
                }));
                _td.Start();
               
            }
            if (speed01.Visible)
            {
                speed01.Hide();
                speed02.Hide();
                speed03.Hide();
            }


        }

        private void 倍ToolStripMenuItem02_Click(object sender, EventArgs e)
        {
            //0.2
            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1");
            this.player.SetConfig(612, "播放速度 (0.2倍速)");
            this.speedLbl.Text = "0.2倍速";
            ClearTip.Clear(player, 1000);
            this.player.SetConfig(104, "20");
            if (this.twoPlay)
            {
                Thread _td = new Thread(new ThreadStart(() => {
                    DeterMineCall(() => { this.vicePlayer.SetConfig(104, "20"); });
                }));
                _td.Start();
            }
            if (speed01.Visible)
            {
                speed01.Hide();
                speed02.Hide();
                speed03.Hide();
            }

        }

        private void 倍ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1");
            this.player.SetConfig(612, "播放速度 (0.5倍速)");
            this.speedLbl.Text = "0.5倍速";
            ClearTip.Clear(player, 1000);
            this.player.SetConfig(104, "50");
            if (this.twoPlay)
            {
                Thread _td = new Thread(new ThreadStart(() => {
                    DeterMineCall(() => { this.vicePlayer.SetConfig(104, "50"); });
                }));
                _td.Start();
            }
            if (speed01.Visible)
            {
                speed01.Hide();
                speed02.Hide();
                speed03.Hide();
            }
        }

        private void 倍ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1");
            this.player.SetConfig(612, "播放速度 (1.5倍速)");
            this.speedLbl.Text = "1.5倍速";
            ClearTip.Clear(player, 1000);
            this.player.SetConfig(104, "150");
            if (this.twoPlay)
            {
                Thread _td = new Thread(new ThreadStart(() => {
                    DeterMineCall(() => { this.vicePlayer.SetConfig(104, "150"); });
                }));
                _td.Start();
            }

        }

        private void 倍ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1");
            this.player.SetConfig(612, "播放速度 (2倍速)");
            this.speedLbl.Text = "2倍速";
            ClearTip.Clear(player, 1000);
            this.player.SetConfig(104, "200");
            if (this.twoPlay)
            {
                Thread _td = new Thread(new ThreadStart(() => {
                    DeterMineCall(() => { this.vicePlayer.SetConfig(104, "200"); });
                }));
                _td.Start();
            }
        }

        private void 倍ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1");
            this.player.SetConfig(612, "播放速度 (3倍速)");
            this.speedLbl.Text = "3倍速";
            ClearTip.Clear(player, 1000);
            this.player.SetConfig(104, "300");
            if (this.twoPlay)
            {
                Thread _td = new Thread(new ThreadStart(() => {
                    DeterMineCall(() => { this.vicePlayer.SetConfig(104, "300"); });
                }));
                _td.Start();
            }

        }

       
        private System.Windows.Forms.Timer twoPlayTimer = new System.Windows.Forms.Timer();
        private void button1_Click_2(object sender, EventArgs e)
        {
            Console.WriteLine(this.position);
            // hehhehe
            VideoItem item = null;
            foreach(var i in videoList)
            {
                if (i.IsPlaying)
                {
                    item = i;
                    twoPlay = false;
                    this.vicePanel.Width = (int)(this.playerPanel.Width * 0.5);
                    this.player.Pause();
                    this.vicePlayer.SetVolume(0);
                    //this.axPlayer1.SetConfig(102, this.position +"");
                    twoPlayTimer.Tick += new EventHandler(player2_tick);
                    twoPlayTimer.Interval = 10;
                    twoPlayTimer.Enabled = true;
                    this.vicePlayer.Open(i.Url);
                    this.vicePlayer.Pause();
                    this.player.Focus();
                    break;
                }
            }
        }

        private void player2_tick(Object sender, EventArgs e)
        {
            Console.WriteLine("are you ok?");
            Constant.PLAY_STATE state = (Constant.PLAY_STATE)this.vicePlayer.GetState();
            if(state == Constant.PLAY_STATE.PS_PLAY && !this.twoPlay)
            {
                this.vicePlayer.SetConfig(0x12e, "1");
                this.player.SetPosition((int)this.position);
                this.vicePlayer.SetPosition((int)this.position);
                Thread _td = new Thread(new ThreadStart(() => {
                    DeterMineCall(() => { this.player.Play(); Console.WriteLine("playing"); });
                }));
                _td.Start();

                this.twoPlay = true;
                this.twoPlayTimer.Enabled = false;
                this.player.Focus();
                Console.WriteLine("ok");
            }
        }
        public void updatetxt()
        {

        }

        public void SetPlay()
        {
            this.vicePlayer.Play();
        }

        private void playerPanel_Resize(object sender, EventArgs e)
        {
            if (this.twoPlay)
            {
                this.vicePanel.Width = (int)(this.playerPanel.Width * 0.5);
            }
        }


        private void CloseTwoPlay()
        {
            this.twoPlay = false;
            this.vicePlayer.Close();
            this.vicePanel.Width = 0;
            this.player.Width = this.masterPanel.Width;
            this.player.SetConfig(0x12e, "0");

            this.mBtn2.ForeColor = Color.MediumSeaGreen;
            this.mBtn1.ForeColor = Color.DarkGray;
            this.mBtn3.ForeColor = Color.DarkGray;
        }

        private void mirrorPanel_MouseLeave(object sender, EventArgs e)
        {
            mirrorTimer.Enabled = true;
        }

        private void mBtn1_MouseEnter(object sender, EventArgs e)
        {
            mirrorTimer.Stop();
        }

        private void mBtn1_Click(object sender, EventArgs e)
        {
            this.mBtn1.ForeColor = Color.MediumSeaGreen;
            this.mBtn2.ForeColor = Color.DarkGray;
            this.mBtn3.ForeColor = Color.DarkGray;
            //分镜

            this.player.SetConfig(0x12e, "0");
            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1");
            this.player.SetConfig(612, "视频状态 (分镜)");
            ClearTip.Clear(player, 1200);

            button1_Click_2(sender, e);
        }

        private void mBtn2_Click(object sender, EventArgs e)
        {
            this.mBtn2.ForeColor = Color.MediumSeaGreen;
            this.mBtn1.ForeColor = Color.DarkGray;
            this.mBtn3.ForeColor = Color.DarkGray;

            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1");
            this.player.SetConfig(612, "视频状态 (正常)");
            ClearTip.Clear(player, 1200);
            if (twoPlay)
            {
                this.CloseTwoPlay();
            }
            this.player.SetConfig(0x12e, "0");
        }

        private void mBtn3_Click(object sender, EventArgs e)
        {
            this.mBtn3.ForeColor = Color.MediumSeaGreen;
            this.mBtn1.ForeColor = Color.DarkGray;
            this.mBtn2.ForeColor = Color.DarkGray;

            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1");
            this.player.SetConfig(612, "视频状态 (镜面翻转)");
            if (twoPlay)
            {
                this.CloseTwoPlay();
            }
            this.player.SetConfig(0x12e, "1");
            ClearTip.Clear(player, 1200);

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            this.player.SetConfig(707, "4");
            this.player.SetConfig(703, "320");
            this.player.SetConfig(704, "240");
            this.player.SetConfig(709, "length=2000;cutinterval=200;playinterval=100");
            this.player.SetConfig(702,@"D:\test.gif");
            var isWorking = this.player.GetConfig(711);
            Console.WriteLine("是否截图:"+isWorking);
            Console.WriteLine("百分比" + this.player.GetConfig(712));
        }

        private void player_OnEvent(object sender, AxAPlayer3Lib._IPlayerEvents_OnEventEvent e)
        {
            Console.WriteLine(e);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var isWorking = this.player.GetConfig(711);
            Console.WriteLine("是否截图:" + isWorking);
            Console.WriteLine("百分比" + this.player.GetConfig(712));
        }

        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DeterMineCall(MethodInvoker method)
        {
            if (InvokeRequired)
                Invoke(method);
            else
                method();
        }
       
   


        private void PlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.volume = this.volume;
            Settings.Default.Save();
            if (this.timer.Enabled)
            {
                this.timer.Enabled = false;
            }

        }
    }
}
