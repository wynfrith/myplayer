﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myplayer.model
{
    public class VideoItem
    {
        private string ext;
        private string name;
        private string url;
        private bool isPlaying;

        public VideoItem(string name, string url)
        {
            this.name = name;
            this.url = url;
            this.ext = name.Substring(name.LastIndexOf("."));
            this.isPlaying = false;
        }

        public override bool Equals(object obj)
        {
            return (this.url == ((VideoItem)obj).url);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public string Ext
        {
            get
            {
                return ext;
            }

            set
            {
                ext = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public bool IsPlaying
        {
            get
            {
                return isPlaying;
            }

            set
            {
                isPlaying = value;
            }
        }
    }



}
