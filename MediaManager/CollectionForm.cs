using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace MediaManager
{
    public partial class CollectionForm : Form
    {
        public Collection collection;
        string mediaFilter;
        string fieldFilter;
        Dictionary<string, List<string>> columnMap;

        public CollectionForm(Collection collection)
        {
            this.collection = collection;
            mediaFilter = "*";
            fieldFilter = "*";

            InitializeComponent();

            List<Type> mediaTypes = new List<Type>();
            mediaTypes.Add(typeof(Book));
            mediaTypes.Add(typeof(Game));
            mediaTypes.Add(typeof(Music));
            mediaTypes.Add(typeof(Video));
            mediaTypes.Add(typeof(Media));

            columnMap = new Dictionary<string, List<string>>();

            treeView.Nodes.Clear();

            // Populate the left-hand tree view
            foreach(Type mediaType in mediaTypes)
            {
                TreeNode rootNode = new TreeNode(mediaType.Name);
                rootNode.Tag = mediaType;
                columnMap.Add(mediaType.Name, new List<string>());
                foreach (FieldInfo fi in mediaType.GetFields())
                {
                    TreeNode fieldNode = new TreeNode(fi.Name);
                    fieldNode.Tag = mediaType;
                    rootNode.Nodes.Add(fieldNode);
                    columnMap[mediaType.Name].Add(fi.Name);
                }
                treeView.Nodes.Add(rootNode);
            }

            collection.OnModified += new Collection.ModifiedEventHandler(collection_OnModified);
        }

        void collection_OnModified(object sender, DateTime time)
        {
            this.Text = collection.Title;
            txtComments.Text = collection.Comments;
            lblCreated.Text = collection.CreationDate.ToShortDateString() + " " + collection.CreationDate.ToShortTimeString();
            lblModified.Text = collection.ModifiedDate.ToShortDateString() + " " + collection.ModifiedDate.ToShortTimeString();

            objectListView.SetObjects(collection);
        }

        private void CollectionForm_Load(object sender, EventArgs e)
        {
            this.Text = string.IsNullOrEmpty(collection.Title) ? "New Collection" : collection.Title;
            objectListView.SetObjects(collection);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            objectListView.Columns.Clear();

            Type filterType = (Type)e.Node.Tag;

            foreach(string field in columnMap[filterType.Name])
            {
                BrightIdeasSoftware.OLVColumn col = new BrightIdeasSoftware.OLVColumn(field, field);
                col.Text = field;
                col.Width = 100;
                col.AspectName = field;
                objectListView.Columns.Add(col);
            }

            objectListView.SetObjects(collection.Select(n=>n.GetType() == filterType));
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            collection.Title = txtTitle.Text;
        }

        private void txtComments_TextChanged(object sender, EventArgs e)
        {
            collection.Comments = txtComments.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            b.Title = "*";
            collection.Add(b);
        }
    }
}