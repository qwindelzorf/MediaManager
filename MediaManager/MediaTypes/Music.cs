using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaManager
{
    public class Music : Media
    {
        public string Lable;
        public string Composer;
        public string Artist;

        public Music()
        {
            Lable = string.Empty;
            Composer = string.Empty;
            Artist = string.Empty;
        }
    }
}
