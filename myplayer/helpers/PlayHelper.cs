using myplayer.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace myplayer.helpers
{
    public class PlayHelper
    {
        public static bool isRightExt(VideoItem item)
        {
            string[] strArray = new string[] { ".avi", ".mp4", ".rm", ".mkv", ".wmv", ".rmvb", ".flv", ".mov", ".mpg", ".divx", ".xvid" };
            foreach (string str in strArray)
            {
                if (item.Ext.ToLower() == str)
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetTime(long ms)
        {
            int num = (int)ms / 0x3e8;
            string str = "00:00";
            if (num > 0)
            {
                int num2 = num / 60;
                int num3 = num % 60;
                str = ((num2 < 10) ? ("0" + num2.ToString()) : num2.ToString()) + ":" + ((num3 < 10) ? ("0" + num3.ToString()) : num3.ToString());
            }
            return str;
        }

        public static void LoopFolder(string pathName, Action<FileInfo> fileRule)
        {
            if (string.IsNullOrEmpty(pathName))
            {
                throw new ArgumentNullException(pathName);
            }
            try
            {
                DirectorySecurity security = new DirectorySecurity(pathName, AccessControlSections.Access);
                if (!security.AreAccessRulesProtected)
                {
                    DirectoryInfo info = new DirectoryInfo(pathName);
                    foreach (FileInfo info2 in info.GetFiles())
                    {
                        fileRule(info2);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
