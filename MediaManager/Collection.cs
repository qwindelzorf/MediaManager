using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace MediaManager
{
    /// <summary>
    /// A collection of <see cref="Media"/> items
    /// </summary>
    public class Collection : IEnumerable<Media>
    {
        /// <summary>
        /// Collection Title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value; 
                _modifiedDate = DateTime.Now; 
                if (OnModified != null) OnModified(this, _modifiedDate);
            }
        }
        private string _title;

        /// <summary>
        /// Collection Comments
        /// </summary>
        public string Comments
        {
            get { return _comments; }
            set 
            {
                _comments = value; 
                _modifiedDate = DateTime.Now;
                if (OnModified != null) OnModified(this, _modifiedDate);
            }
        }
        private string _comments;

        /// <summary>
        /// The date and time at which the Collection was created
        /// </summary>
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set {}
        }
        private DateTime _creationDate;

        /// <summary>
        /// The date and time at which the Collection was last modified
        /// </summary>
        public DateTime ModifiedDate
        {
            get { return _modifiedDate; }
            set {}
        }
        private DateTime _modifiedDate;

        public delegate void ModifiedEventHandler(object sender, DateTime time);
        /// <summary>
        /// Modification Event notifier.  Triggered every time the collection is modified in any way.
        /// </summary>
        public event ModifiedEventHandler OnModified;

        /// <summary>
        /// An array allowing access to the <see cref="Media"/> items in the <see cref="Colleciton"/>
        /// </summary>
        /// <remarks>Throws <see cref="IndexOutOfRangeException"/> if an invalid index is specified</remarks>
        public Media this[int i]
        {
            get 
            { 
                if ((i >= 0) && (i < _items.Count)) 
                { 
                    return _items[i]; 
                } 
                else 
                {
                    throw new IndexOutOfRangeException(string.Concat("Index specified (", i, ") does not exist in the collection"));
                } 
            }
            set 
            {
                if ((i >= 0) && (i < _items.Count))
                {
                    _items[i] = value;
                    _modifiedDate = DateTime.Now;
                    if (OnModified != null) OnModified(this, _modifiedDate);
                }
                else
                {
                    throw new IndexOutOfRangeException(string.Concat("Index specified (", i, ") does not exist in the collection"));
                }
            }
        }
        private List<Media> _items;


        public Collection()
        {
            _creationDate = DateTime.Now;
            Title = string.Empty;
            Comments = string.Empty;

            _items = new List<Media>();
        }

        /// <summary>
        /// Add a <see cref="Media"/> item to the <see cref="Collection"/>
        /// </summary>
        /// <param name="item">The <see cref="Media"/> item to be added</param>
        /// <returns>The index of the item just added</returns>
        public int Add(Media item)
        {
            _items.Add(item);
            _modifiedDate = DateTime.Now;
            if (OnModified != null) OnModified(this, _modifiedDate);
            return _items.Count - 1;
        }

        /// <summary>
        /// Remive a <see cref="Media"/> item from the <see cref="Colleciton"/>
        /// </summary>
        /// <param name="item">The <see cref="Media"/> item to be removed</param>
        /// <returns>True if the item was in the <see cref="Collection"/> and has been removed.  False otherwise.</returns>
        public bool Remove(Media item)
        {
            if (_items.Contains(item))
            {
                _items.Remove(item);
                if (OnModified != null) OnModified(this, _modifiedDate);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Remove the <see cref="Media"/> item at the specified index from the <see cref="Collection"/>
        /// </summary>
        /// <param name="index">The index of the <see cref="Media"/> item to be removed</param>
        /// <returns>True if the item was in the <see cref="Collection"/> and has been removed.  False otherwise.</returns>
        public bool Remove(int index)
        {
            if ((index > 0) && (index < _items.Count))
            {
                _items.RemoveAt(index);
                if (OnModified != null) OnModified(this, _modifiedDate);
                return true;
            }
            else return false;
        }

        public IEnumerator<Media> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        static public string Serialize(Collection collection)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Collection));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, collection);
            return writer.ToString();
        }

        static public Collection Deserialize(TextReader xmlStream)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Collection));
            return (Collection)deserializer.Deserialize(xmlStream);
        }

        internal void RemoveRange(List<Media> records)
        {
            foreach (Media item in records) Remove(item);
        }

        internal void AddRange(List<Media> records)
        {
            foreach (Media item in records) Add(item);
        }
    }
}
