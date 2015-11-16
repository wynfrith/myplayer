using myplayer.helpers;
using myplayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace myplayer
{
    public partial class Snapshot : DMSkin.Main
    {
        private AxAPlayer3Lib.AxPlayer player;
        private System.Windows.Forms.Timer timer;

        public Snapshot(AxAPlayer3Lib.AxPlayer player)
        {
            InitializeComponent();
            this.player = player;
        }

        SolidBrush sb = new SolidBrush(Color.LightCoral);
        protected override void OnPaint(PaintEventArgs e)
        {
            //设置高质量插值法
            e.Graphics.InterpolationMode = InterpolationMode.Bilinear;
            //设置高质量,低速度呈现平滑程度
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.FillRectangle(sb, -1, -1, Width + 30, 30);

        }

        private void Snapshot_Load(object sender, EventArgs e)
        {
            this.player.Pause();
            string dir = Settings.Default.picDir;
            this.dirBox.Text = dir;
            this.numBox.Value = 10;
            this.timesBox.Value = 100;
            this.timer = new System.Windows.Forms.Timer();
            this.timer.Enabled = false;
            this.timer.Interval = (int)this.timesBox.Value;
            this.timer.Tick += new EventHandler(Snap);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.player.Play();
            Close();
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.dirBox.Text = dialog.SelectedPath;
                Settings.Default.picDir = dialog.SelectedPath;
            }
        }

        private string dir;  //存储目录
        private int num;  //重复次数
        private int oldVol;
        private int oldPos;
       private void Snap(object sender, EventArgs e)
        {
            if (this.player.GetConfig(701) == "0")
            {
                this.player.SetConfig(602, "0");
                timer.Enabled = false;
                return;
            }
            this.player.SetConfig(602, "1");
            this.player.SetConfig(621, "1"); //使用线形插值叠图

            if (num -- <= 0)
            {
                timer.Enabled = false;
                //this.player.Pause();
                //this.player.SetVolume(this.oldVol);
                //this.player.SetPosition(this.oldPos);
                //this.startBtn.Text = "开始截图";
                //this.startBtn.Enabled = true;
                this.player.SetConfig(612, "截图完成");
                ClearTip.Clear(this.player,500);
                this.Close();
                return;
            }

            //截图
            this.player.SetConfig(612, "正在截图中..("+(this.numBox.Value -num)+")");

            this.player.SetConfig(707, "2");
            string path = this.dir + @"\"+(this.numBox.Value - num) +".jpg";
            Console.WriteLine(path);
            this.player.SetConfig(702, path);

        }
       
        private void startBtn_Click(object sender, EventArgs e)
        {
           

            if (this.player.GetConfig(701) == "1")
            {
                this.oldVol = this.player.GetVolume();
                this.oldPos = this.player.GetPosition();

                this.Hide();
                //this.player.SetVolume(0);
                this.player.Play();
                this.startBtn.Text = "截图中..";
                this.startBtn.Enabled = false;
                string date = DateTime.Now.ToString("HHMMddhhmmss");
                this.dir = this.dirBox.Text + @"\连续截图" + date;
                Directory.CreateDirectory(this.dir);

                this.num = (int)this.numBox.Value;
                var time = (int)this.timesBox.Value;
                timer.Interval = time;
                timer.Enabled = true;
            }
        }
    }
}
