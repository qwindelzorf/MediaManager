using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaManager
{
    public class Video : Media
    {
        public string Director;
        public string Studio;
        public string Format;

        public Video()
        {
            Director = string.Empty;
            Studio = string.Empty;
            Format = string.Empty;
        }
    }
}
