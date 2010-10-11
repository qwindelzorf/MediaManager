using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaManager
{
    public class Book : Media
    {

        public string Author;
        public uint? Edition;
        public DateTime? FirstPublicationDate;

        public Book()
        {
            Author = string.Empty;
            Edition = null;
            FirstPublicationDate = null;
        }
    }
}
