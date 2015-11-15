using myplayer.helpers;
using myplayer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace myplayer.service
{
    public class PlayOp
    {
        //打开一个文件
        public static VideoItem OpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "媒体文件|*.mp4;*.avi;*.rm;*.rmvb;*.flv;*.mkv;*.wmv;|所有文件|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                VideoItem newVideo = new VideoItem(dialog.SafeFileName, dialog.FileName);
                if (PlayHelper.isRightExt(newVideo)) return newVideo;
            }
            return null;
        }
    }
}
