using myplayer.helpers;
using myplayer.model;
using myplayer.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace myplayer
{
    public partial class PlayerForm : Form
    {
        public System.Windows.Forms.Timer timer;
        public System.Windows.Forms.Timer backTimer;
        private List<VideoItem> videoList = new List<VideoItem>();
        private VideoItem currItem = null;
        private long duration = 0;
        private long position = 0;


        public PlayerForm()
        {
            InitializeComponent();
            this.timer = new System.Windows.Forms.Timer();
            this.timer.Tick += new EventHandler(this.time_Tick);
            this.timer.Interval = 50;
            this.timer.Enabled = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.player.SetCustomLogo(-1);
        }

        //计时器 控制进度条和一些状态
        private void time_Tick(Object sender,EventArgs e)
        {
            Constant.PLAY_STATE state = (Constant.PLAY_STATE)this.player.GetState();
            switch (state)
            {
                case Constant.PLAY_STATE.PS_PLAY:
                case Constant.PLAY_STATE.PS_PAUSED:  //暂停播放状态
                    this.position = this.player.GetPosition();
                    this.duration = this.player.GetDuration();
                    this.processBar.Value = Convert.ToInt32((double)((this.processBar.Maximum * this.position) / ((double)this.duration)));
                    this.timeLbl.Text = PlayHelper.GetTime(this.position) + "/" + PlayHelper.GetTime(this.duration);
                    //this.player.SetVolume(80);
                    //this.dmProgressBar1.DM_Value = this.volume;
                    break;
            }
            if ((state == Constant.PLAY_STATE.PS_READY) && (this.position > 0))
            {
                this.stopBtn_Click(sender, e);
            }

        }

        // 加载视频并播放该视频
        private void openBtn_Click(object sender, EventArgs e)
        {
            VideoItem item = PlayOp.OpenFile();
            if (item == null) return;
            videoList.Add(item);

            this.player.Open(item.Url);
            currItem = item;
            this.playBtn.Text = "暂停";

        }

        // 暂停/播放视频
        private void playBtn_Click(object sender, EventArgs e)
        {

            Constant.PLAY_STATE state = (Constant.PLAY_STATE)this.player.GetState();
            if (state == Constant.PLAY_STATE.PS_PLAY)
            {
                this.player.Pause();
                this.playBtn.Text = "播放";
            }
            else if (state == Constant.PLAY_STATE.PS_PAUSED){
                this.player.Play();
                this.playBtn.Text = "暂停";
            }
        }

        // 停止视频
        private void stopBtn_Click(object sender, EventArgs e)
        {
            this.player.Close();
            this.playBtn.Text = "播放";
        }

        #region 进度条点击事件
        private void processBar_Scroll(object sender, EventArgs e)
        {
            this.timer.Stop();
            if (this.position <= 0)
            {
                this.processBar.Value = 0;
            }
        }

        private void processBar_MouseUp(object sender, MouseEventArgs e)
        {
            switch (((Constant.PLAY_STATE)this.player.GetState()))
            {
                case Constant.PLAY_STATE.PS_PLAY:
                case Constant.PLAY_STATE.PS_PAUSED:
                    if (!(this.timer.Enabled || (this.player.GetPosition() == 0)))
                    {
                        double num = this.processBar.Value;
                        double num2 = (num / ((double)this.processBar.Maximum)) * this.duration;
                        this.player.SetPosition(Convert.ToInt32(num2));
                        this.timeLbl.Text = PlayHelper.GetTime(this.player.GetPosition()) + "/" + PlayHelper.GetTime(this.player.GetDuration());
                        this.timer.Start();
                    }
                    this.processBar.Focus();
                    break;
            }
        }

        #endregion

        //水平反转（镜面）
        private void mirrorBtn_Click(object sender, EventArgs e)
        {
            if (this.player.GetConfig(302) == "1")
            {
                this.player.SetConfig(302, "0");
            }
            else
            {
                this.player.SetConfig(302, "1");
            }
        }


        //播放速度控制 (播放速度很慢的话考虑把声音关闭）
        private void speedBar_Scroll(object sender, EventArgs e)
        {
            int num = this.speedBar.Value * 10;
            this.player.SetConfig(104, num + "");
        }

        private void speedBar_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void speedBar_MouseUp(object sender, MouseEventArgs e)
        {

        }

        //旋转
        private void rotateR90_Click(object sender, EventArgs e)
        {
            int rotate = Convert.ToInt32(this.player.GetConfig(304)) + 90;
            this.player.SetConfig(304, rotate+"");
        }

        private void rotateL90_Click(object sender, EventArgs e)
        {
            int rotate = Convert.ToInt32(this.player.GetConfig(304)) + 270;
            this.player.SetConfig(304, rotate + "");
        }

        private void rotate180_Click(object sender, EventArgs e)
        {
            int rotate = Convert.ToInt32(this.player.GetConfig(304)) + 180;
            this.player.SetConfig(304, rotate + "");
        }

        private void rotateNormal_Click(object sender, EventArgs e)
        {
            this.player.SetConfig(304, "0");
        }

        //截图

        private void snapshot_Click(object sender, EventArgs e)
        {
            if(this.player.GetConfig(701) == "1")
            {
                this.player.SetConfig(707, "2");
                string dir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string date = DateTime.Now.ToString("hhMMddhhmmss");
                string path = dir + "\\截图"+date+".jpg";
                Console.WriteLine(path);
                this.player.SetConfig(702,path);

            }
        }

        public delegate void ListenerHandler();
        public event ListenerHandler Listener = null;
        private void gifShot_Click(object sender, EventArgs e)
        {
            if (this.player.GetConfig(701) == "1")
            {
                this.player.SetConfig(707, "4");
                this.player.SetConfig(703, "320");
                this.player.SetConfig(704, "240");
                this.player.SetConfig(709, "length=2000;cutinterval=200;playinterval=100");
                string dir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string date = DateTime.Now.ToString("hhMMddhhmmss");
                string path = dir + "\\截图" + date + ".gif";
                Console.WriteLine(path);
                this.player.SetConfig(702,@"c:\teset.gif");
            }
        }
        private void noteMe()
        {

        }

        private void gifShotEnd_Click(object sender, EventArgs e)
        {
            Console.WriteLine(this.player.GetConfig(711));
            Console.WriteLine(this.player.GetConfig(712));
        }

        private void videoCut_Click(object sender, EventArgs e)
        {
            Console.WriteLine(this.player.GetConfig(801));
           
        }



        //视频裁剪 


        //局部播放
    }
}
