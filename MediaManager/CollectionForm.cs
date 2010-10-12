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

            treeViewItems.Nodes.Clear();

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
                treeViewItems.Nodes.Add(rootNode);
            }

            collection.OnModified += new Collection.ModifiedEventHandler(collection_OnModified);
        }

        void collection_OnModified(object sender, DateTime time)
        {
            this.Text = collection.Title;
            txtComments.Text = collection.Comments;
            lblCreated.Text = collection.CreationDate.ToShortDateString() + " " + collection.CreationDate.ToShortTimeString();
            lblModified.Text = collection.ModifiedDate.ToShortDateString() + " " + collection.ModifiedDate.ToShortTimeString();

            showFilteredItems();
        }

        private void CollectionForm_Load(object sender, EventArgs e)
        {
            this.Text = string.IsNullOrEmpty(collection.Title) ? "New Collection" : collection.Title;
            objectListViewItems.SetObjects(collection);
            treeViewItems.SelectedNode = treeViewItems.Nodes[treeViewItems.Nodes.Count - 1].Nodes[0];
        }

        Type filterType;
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Remove all existing columns
            objectListViewItems.Columns.Clear();

            filterType = (Type)e.Node.Tag;

            // Rebuild the column list to reflect the selected type
            foreach(string field in columnMap[filterType.Name])
            {
                BrightIdeasSoftware.OLVColumn col = new BrightIdeasSoftware.OLVColumn();
                col.Text = field;
                col.MinimumWidth = 100;
                col.AspectName = field;
                col.IsEditable = true;
                col.Name = field + "Column";
                col.Tag = filterType;
                objectListViewItems.Columns.Add(col);
                if (field == e.Node.Text) objectListViewItems.PrimarySortColumn = col;
            }

            showFilteredItems();
        }

        private void showFilteredItems()
        {
            // Only display items of the selected type
            if (filterType == typeof(Media)) objectListViewItems.SetObjects(collection);
            else objectListViewItems.SetObjects(collection.Where(n => n.GetType() == filterType));
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            collection.Title = txtTitle.Text;
        }

        private void txtComments_TextChanged(object sender, EventArgs e)
        {
            collection.Comments = txtComments.Text;
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            bookToolStripMenuItem_Click(sender, e);
        }

        private void btnAddGame_Click(object sender, EventArgs e)
        {
            gameToolStripMenuItem_Click(sender, e);
        }

        private void btnAddMusic_Click(object sender, EventArgs e)
        {
            musicToolStripMenuItem_Click(sender, e);
        }

        private void btnAddVideo_Click(object sender, EventArgs e)
        {
            videoToolStripMenuItem_Click(sender, e);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            deleteToolStripMenuItem_Click(sender, e);
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Media m = new Book();
            m.Title = "<New Book>";
            collection.Add(m);
            showFilteredItems();
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Media m = new Game();
            m.Title = "<New Game>";
            collection.Add(m);
            showFilteredItems();
        }

        private void musicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Media m = new Music();
            m.Title = "<New Music>";
            collection.Add(m);
            showFilteredItems();
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Media m = new Video();
            m.Title = "<New Video>";
            collection.Add(m);
            showFilteredItems();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Delete the active row from the collection
            Media m = (Media)objectListViewItems.SelectedObject;
            collection.Remove(m);
            showFilteredItems();
        }
    }
}