using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MediaManager
{
    [Serializable]
    [XmlInclude(typeof(Book)), XmlInclude(typeof(Music)), XmlInclude(typeof(Game)), XmlInclude(typeof(Video))]
    public abstract class Media
    {
        public string Title;
        public string Subtitle;
        public DateTime? PublicationDate;
        public List<string> Genre;
        public string Series;
        public uint? SeriesNumber;

        public Media()
        {
            Title = string.Empty;
            Subtitle = string.Empty;
            PublicationDate = null;
            Genre = new List<string>();
            Series = string.Empty;
            SeriesNumber = null;
        }
    }
}
