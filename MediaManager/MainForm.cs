using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Collections;

namespace MediaManager
{
    public partial class MainForm : Form
    {
        private class CollectionInfo
        {
            public string Path;
            public Collection Item;
            public DateTime? SaveDate;
            public bool Unsaved
            {
                get { if (SaveDate == null || Item.ModifiedDate > SaveDate) return false; else return true; }
            }
            public string Title
            {
                get { return Item.Title; }
                set { Item.Title = value; }
            }

            public CollectionInfo()
                : this(new Collection())
            {
            }

            public CollectionInfo(Collection item)
            {
                Item = item;
                SaveDate = null;
            }
        }

        private List<CollectionInfo> collections;

        public MainForm()
        {
            InitializeComponent();
            collections = new List<CollectionInfo>();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreferencesForm prefs = new PreferencesForm();
            prefs.ShowDialog(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Autoload any collection specified by the user
            if (!string.IsNullOrEmpty(Properties.Settings.Default.defaultCollection))
            {
                if (File.Exists(Properties.Settings.Default.defaultCollection))
                {
                    loadCollection(Properties.Settings.Default.defaultCollection);
                }
                else
                {
                    MessageBox.Show("The default collection could not be loaded.  Please verify your preferences.", "Autoload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool loadCollection(string path)
        {
            if (!File.Exists(path))
                return false;

            CollectionInfo info = new CollectionInfo();
            info.Path = path;

            //Load collection from file
            try
            {
                TextReader reader = new StreamReader(path);
                info.Item = Collection.Deserialize(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading collection from file: \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            collections.Add(info);
            newCollectionWindow(info.Item);

            return true;
        }

        private void newCollectionWindow(Collection collection)
        {
            CollectionForm cf = new CollectionForm(collection);
            cf.MdiParent = this;
            if (MdiChildren.Length == 1) cf.WindowState = FormWindowState.Maximized;
            cf.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CollectionInfo info = new CollectionInfo();
            collections.Add(info);
            newCollectionWindow(info.Item);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string extension = Properties.Settings.Default.fileExtension;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = extension;
            ofd.CheckFileExists = true;
            ofd.AddExtension = true;
            ofd.AutoUpgradeEnabled = true;
            ofd.Multiselect = false;
            ofd.Title = "Select Default Collection...";
            ofd.Filter = string.Concat("Media Collections (*." + extension + ")|*." + extension + "|All files (*.*)|*.*");
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                loadCollection(ofd.FileName);
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get index of active collection
            int activeIndex = getActiveCollectionIndex();
            saveCollection(activeIndex, collections[activeIndex].Path);
        }

        private int getActiveCollectionIndex()
        {
            //Get the index of the active collection window
            CollectionForm cf = (CollectionForm)ActiveMdiChild;
            for (int i = 0; i < collections.Count; i++)
                if (collections[i].Item == cf.collection) return i;
            throw new IndexOutOfRangeException("Failed to look up index of MDI child form.");
        }

        private bool saveCollection(int index, string path)
        {
            if(index < 0 || index >= collections.Count)
                return false;

            // If no file path was specified, ask the user for one
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                string extension = Properties.Settings.Default.fileExtension;

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.AddExtension = true;
                sfd.DefaultExt = extension;
                sfd.Filter = string.Concat("Media Collections (*." + extension + ")|*." + extension + "|All files (*.*)|*.*");
                sfd.AutoUpgradeEnabled = true;
                sfd.OverwritePrompt = true;
                sfd.Title = "Save Collection...";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    path = sfd.FileName;
                }
            }

            collections[index].Path = path;

            //Save collection to file
            try
            {
                TextWriter writer = new StreamWriter(path);
                writer.Write(Collection.Serialize(collections[index].Item));
                writer.Close();
                collections[index].SaveDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failure writing collection to file: \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get index of active collection
            int activeIndex = getActiveCollectionIndex();
            saveCollection(activeIndex, string.Empty);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnumerable unsavedCollections = collections.Select(n => n.Unsaved);
            // Prompt the user to save any unsaved collections
            foreach (CollectionInfo info in unsavedCollections)
            {
                MessageBox.Show("Collection \"" + info.Title + "\" has unsaved data.  Save now?", "Unsaved Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }

            this.Close();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        #region Window Layout
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
        #endregion

    }
}
