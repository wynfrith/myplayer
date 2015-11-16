using myplayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace myplayer
{
    public partial class SettingForm : DMSkin.Main
    {
        public SettingForm()
        {
            InitializeComponent();
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

        private void SettingForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Settings.Default.picDir;

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = dialog.SelectedPath;
                Settings.Default.picDir = dialog.SelectedPath;
            }
        }
    }
}
