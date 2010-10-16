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
using LumenWorks.Framework.IO.Csv;


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

        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length == 2)
            {
                FileInfo doc = new FileInfo(args[1]);
                if (doc.Exists && doc.Extension == ("." + Properties.Settings.Default.fileExtension))
                    loadCollection(doc.FullName);
                else
                    MessageBox.Show("Could not open file.\n" + args[1], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
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
        }

        #region File Menu
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

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Prompt the user for the file to import
            string extension = "csv";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = extension;
            ofd.CheckFileExists = true;
            ofd.AddExtension = true;
            ofd.AutoUpgradeEnabled = true;
            ofd.Multiselect = false;
            ofd.Title = "Select Default Collection...";
            ofd.Filter = string.Concat("Media Collections (*." + extension + ")|*." + extension + "|All files (*.*)|*.*");
            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (!File.Exists(ofd.FileName))
            {
                MessageBox.Show("Could not find file specified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Parse the CSV, creating a collection from it
            int line = 1;
            try
            {
                CollectionInfo info = new CollectionInfo();
                using (CsvReader csv = new CsvReader(new StreamReader(ofd.FileName), true))
                {
                    int fieldCount = csv.FieldCount;
                    string[] headers = csv.GetFieldHeaders();

                    while (csv.ReadNextRecord())
                    {
                        Book b = new Book();
                        b.Series = csv[0];
                        b.Title = csv[1];
                        b.SeriesNumber = uint.Parse(csv[2]);
                        b.Author = csv[3];
                        b.Genre = new List<string>(csv[4].Replace(" ", string.Empty).Split(','));
                        // csv[5] is page count
                        b.FirstPublicationDate = new DateTime(int.Parse(csv[6]), 1, 1);
                        b.PublicationDate = new DateTime(int.Parse(csv[7]), 1, 1);
                        // csv[8] is comments

                        info.Item.Add(b);
                        line++;
                    }
                }

                info.Item.Comments = "Imported from " + ofd.SafeFileName + " on " + DateTime.Now.ToShortDateString() + ".";
                info.Item.Title = ofd.SafeFileName.Substring(0, ofd.SafeFileName.LastIndexOf("."));
                collections.Add(info);
                newCollectionWindow(info.Item);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not parse the file \"" + ofd.FileName + "\".\n" 
                    + "Error at line " + line + ": \n" + ex.Message
                    , "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        #endregion

        #region Window Menu
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

        #region Edit Menu
        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreferencesForm prefs = new PreferencesForm();
            prefs.ShowDialog(this);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((CollectionForm)ActiveMdiChild).SelectItems();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the selected records
            CollectionForm activeChild = (CollectionForm)ActiveMdiChild;
            List<Media> records = activeChild.getSelectedItems();

            // Put the data into the clipboard
            toClipboard(records);

            // Since this is a cut, remove the selected records
            activeChild.collection.RemoveRange(records);
            activeChild.RefreshFilteredItems();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Put the data into the clipboard
            toClipboard(((CollectionForm)ActiveMdiChild).getSelectedItems());
        }

        private void toClipboard(List<Media> records)
        {
            // Convert the records to XML
            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(records.GetType());
            serializer.Serialize(new StringWriter(sb), records);

            // Put the XML into the clipboard
            Clipboard.SetData(DataFormats.Text, sb.ToString());
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Put the records in the clipboard into the active MDI child
            CollectionForm activeChild = (CollectionForm)ActiveMdiChild;
            activeChild.collection.AddRange(fromClipboard());
            activeChild.RefreshFilteredItems();
        }

        private List<Media> fromClipboard()
        {
            // Create a list for the data that _should_ be in the clipboard
            List<Media> records = new List<Media>();

            // See if the clipboard actually contains any text
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                // Convert the XML in the clipboard to a list of Media
                string xml = (string)Clipboard.GetData(DataFormats.Text);
                XmlSerializer serializer = new XmlSerializer(records.GetType());
                try
                {
                    records = new List<Media>((List<Media>)serializer.Deserialize(new StringReader(xml)));
                }
                catch (Exception)
                {
                    // If something went wrong, just use a blank list
                    records = new List<Media>();
                }
            }

            // Return any retreived records
            return records;
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem_Click(sender, e);
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(sender, e);
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem_Click(sender, e);
        }
        #endregion

    }
}
