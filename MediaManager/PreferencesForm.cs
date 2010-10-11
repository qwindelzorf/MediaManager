using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaManager
{
    public partial class PreferencesForm : Form
    {
        public PreferencesForm()
        {
            InitializeComponent();
        }

        private void PreferencesForm_Load(object sender, EventArgs e)
        {
            chkAutoload.Checked = !string.IsNullOrEmpty(Properties.Settings.Default.defaultCollection);
            txtDefaultCollectionPath.Text = Properties.Settings.Default.defaultCollection;
        }

        private void chkAutoload_CheckedChanged(object sender, EventArgs e)
        {
            txtDefaultCollectionPath.Enabled = chkAutoload.Checked;
            btnBrowse.Enabled = chkAutoload.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.defaultCollection = txtDefaultCollectionPath.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string extension = Properties.Settings.Default.fileExtension;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = extension;
            ofd.CheckFileExists = true;
            ofd.AddExtension = true;
            ofd.AutoUpgradeEnabled = true;
            ofd.FileName = txtDefaultCollectionPath.Text;
            ofd.Multiselect = false;
            ofd.Title = "Select Default Collection...";
            ofd.Filter = string.Concat("Media Collections (*." + extension + ")|*." + extension + "|All files (*.*)|*.*");
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDefaultCollectionPath.Text = ofd.FileName;
            }
        }
    }
}
