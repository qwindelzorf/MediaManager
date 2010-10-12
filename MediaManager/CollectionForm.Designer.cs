namespace MediaManager
{
    partial class CollectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Books");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Games");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Music");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Video");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewItems = new System.Windows.Forms.TreeView();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAddVideo = new System.Windows.Forms.Button();
            this.btnAddMusic = new System.Windows.Forms.Button();
            this.btnAddGame = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.objectListViewItems = new BrightIdeasSoftware.ObjectListView();
            this.colTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSubtitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colPubDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colGenre = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSeries = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colSeriesNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.listContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageItems = new System.Windows.Forms.TabPage();
            this.tabPageProperties = new System.Windows.Forms.TabPage();
            this.lblModified = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCreated = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewItems)).BeginInit();
            this.listContextMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageItems.SuspendLayout();
            this.tabPageProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewItems);
            this.splitContainer1.Panel1MinSize = 125;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnDel);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddVideo);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddMusic);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddGame);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddBook);
            this.splitContainer1.Panel2.Controls.Add(this.objectListViewItems);
            this.splitContainer1.Size = new System.Drawing.Size(570, 230);
            this.splitContainer1.SplitterDistance = 125;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeViewItems
            // 
            this.treeViewItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewItems.Location = new System.Drawing.Point(0, 0);
            this.treeViewItems.Name = "treeViewItems";
            treeNode1.Name = "books";
            treeNode1.Text = "Books";
            treeNode2.Name = "games";
            treeNode2.Text = "Games";
            treeNode3.Name = "music";
            treeNode3.Text = "Music";
            treeNode4.Name = "video";
            treeNode4.Text = "Video";
            this.treeViewItems.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.treeViewItems.Size = new System.Drawing.Size(125, 230);
            this.treeViewItems.TabIndex = 0;
            this.treeViewItems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(361, 200);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAddVideo
            // 
            this.btnAddVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddVideo.Location = new System.Drawing.Point(246, 200);
            this.btnAddVideo.Name = "btnAddVideo";
            this.btnAddVideo.Size = new System.Drawing.Size(75, 23);
            this.btnAddVideo.TabIndex = 1;
            this.btnAddVideo.Text = "Add Video";
            this.btnAddVideo.UseVisualStyleBackColor = true;
            this.btnAddVideo.Click += new System.EventHandler(this.btnAddVideo_Click);
            // 
            // btnAddMusic
            // 
            this.btnAddMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddMusic.Location = new System.Drawing.Point(165, 200);
            this.btnAddMusic.Name = "btnAddMusic";
            this.btnAddMusic.Size = new System.Drawing.Size(75, 23);
            this.btnAddMusic.TabIndex = 1;
            this.btnAddMusic.Text = "Add Music";
            this.btnAddMusic.UseVisualStyleBackColor = true;
            this.btnAddMusic.Click += new System.EventHandler(this.btnAddMusic_Click);
            // 
            // btnAddGame
            // 
            this.btnAddGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddGame.Location = new System.Drawing.Point(84, 200);
            this.btnAddGame.Name = "btnAddGame";
            this.btnAddGame.Size = new System.Drawing.Size(75, 23);
            this.btnAddGame.TabIndex = 1;
            this.btnAddGame.Text = "Add Game";
            this.btnAddGame.UseVisualStyleBackColor = true;
            this.btnAddGame.Click += new System.EventHandler(this.btnAddGame_Click);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddBook.Location = new System.Drawing.Point(3, 200);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(75, 23);
            this.btnAddBook.TabIndex = 1;
            this.btnAddBook.Text = "Add Book";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // objectListViewItems
            // 
            this.objectListViewItems.AllColumns.Add(this.colTitle);
            this.objectListViewItems.AllColumns.Add(this.colSubtitle);
            this.objectListViewItems.AllColumns.Add(this.colPubDate);
            this.objectListViewItems.AllColumns.Add(this.colGenre);
            this.objectListViewItems.AllColumns.Add(this.colSeries);
            this.objectListViewItems.AllColumns.Add(this.colSeriesNumber);
            this.objectListViewItems.AllowColumnReorder = true;
            this.objectListViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListViewItems.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.objectListViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTitle,
            this.colSubtitle,
            this.colPubDate,
            this.colGenre,
            this.colSeries,
            this.colSeriesNumber});
            this.objectListViewItems.ContextMenuStrip = this.listContextMenu;
            this.objectListViewItems.EmptyListMsg = "There are no items in this view.";
            this.objectListViewItems.FullRowSelect = true;
            this.objectListViewItems.GridLines = true;
            this.objectListViewItems.HasCollapsibleGroups = false;
            this.objectListViewItems.Location = new System.Drawing.Point(0, 0);
            this.objectListViewItems.Name = "objectListViewItems";
            this.objectListViewItems.Size = new System.Drawing.Size(441, 194);
            this.objectListViewItems.TabIndex = 0;
            this.objectListViewItems.TintSortColumn = true;
            this.objectListViewItems.UseCompatibleStateImageBehavior = false;
            this.objectListViewItems.View = System.Windows.Forms.View.Details;
            // 
            // colTitle
            // 
            this.colTitle.AspectName = "Title";
            this.colTitle.Text = "Title";
            this.colTitle.Width = 100;
            // 
            // colSubtitle
            // 
            this.colSubtitle.AspectName = "Subtitle";
            this.colSubtitle.Text = "Subtitle";
            this.colSubtitle.Width = 100;
            // 
            // colPubDate
            // 
            this.colPubDate.AspectName = "PublicationDate";
            this.colPubDate.Text = "Publication Date";
            this.colPubDate.Width = 100;
            // 
            // colGenre
            // 
            this.colGenre.AspectName = "Genre";
            this.colGenre.Text = "Genre (s)";
            this.colGenre.Width = 100;
            // 
            // colSeries
            // 
            this.colSeries.AspectName = "Series";
            this.colSeries.Text = "Series";
            // 
            // colSeriesNumber
            // 
            this.colSeriesNumber.AspectName = "SeriesNumber";
            this.colSeriesNumber.Text = "Series Number";
            // 
            // listContextMenu
            // 
            this.listContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem,
            this.loanToolStripMenuItem});
            this.listContextMenu.Name = "listContextMenu";
            this.listContextMenu.Size = new System.Drawing.Size(153, 98);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookToolStripMenuItem,
            this.gameToolStripMenuItem,
            this.musicToolStripMenuItem,
            this.videoToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // bookToolStripMenuItem
            // 
            this.bookToolStripMenuItem.Name = "bookToolStripMenuItem";
            this.bookToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.bookToolStripMenuItem.Text = "&Book";
            this.bookToolStripMenuItem.Click += new System.EventHandler(this.bookToolStripMenuItem_Click);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.gameToolStripMenuItem.Text = "&Game";
            this.gameToolStripMenuItem.Click += new System.EventHandler(this.gameToolStripMenuItem_Click);
            // 
            // musicToolStripMenuItem
            // 
            this.musicToolStripMenuItem.Name = "musicToolStripMenuItem";
            this.musicToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.musicToolStripMenuItem.Text = "&Music";
            this.musicToolStripMenuItem.Click += new System.EventHandler(this.musicToolStripMenuItem_Click);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.videoToolStripMenuItem.Text = "&Video";
            this.videoToolStripMenuItem.Click += new System.EventHandler(this.videoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // loanToolStripMenuItem
            // 
            this.loanToolStripMenuItem.Enabled = false;
            this.loanToolStripMenuItem.Name = "loanToolStripMenuItem";
            this.loanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loanToolStripMenuItem.Text = "&Loan";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageItems);
            this.tabControl1.Controls.Add(this.tabPageProperties);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 262);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageItems
            // 
            this.tabPageItems.Controls.Add(this.splitContainer1);
            this.tabPageItems.Location = new System.Drawing.Point(4, 22);
            this.tabPageItems.Name = "tabPageItems";
            this.tabPageItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItems.Size = new System.Drawing.Size(576, 236);
            this.tabPageItems.TabIndex = 0;
            this.tabPageItems.Text = "Items";
            this.tabPageItems.UseVisualStyleBackColor = true;
            // 
            // tabPageProperties
            // 
            this.tabPageProperties.Controls.Add(this.lblModified);
            this.tabPageProperties.Controls.Add(this.label5);
            this.tabPageProperties.Controls.Add(this.lblCreated);
            this.tabPageProperties.Controls.Add(this.label3);
            this.tabPageProperties.Controls.Add(this.txtComments);
            this.tabPageProperties.Controls.Add(this.label2);
            this.tabPageProperties.Controls.Add(this.label1);
            this.tabPageProperties.Controls.Add(this.txtTitle);
            this.tabPageProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageProperties.Name = "tabPageProperties";
            this.tabPageProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProperties.Size = new System.Drawing.Size(576, 236);
            this.tabPageProperties.TabIndex = 1;
            this.tabPageProperties.Text = "Collection Properties";
            this.tabPageProperties.UseVisualStyleBackColor = true;
            // 
            // lblModified
            // 
            this.lblModified.AutoSize = true;
            this.lblModified.Location = new System.Drawing.Point(298, 44);
            this.lblModified.Name = "lblModified";
            this.lblModified.Size = new System.Drawing.Size(114, 13);
            this.lblModified.TabIndex = 7;
            this.lblModified.Text = "00/00/0000 00:00 AM";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Last Modified:";
            // 
            // lblCreated
            // 
            this.lblCreated.AutoSize = true;
            this.lblCreated.Location = new System.Drawing.Point(64, 44);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(114, 13);
            this.lblCreated.TabIndex = 5;
            this.lblCreated.Text = "00/00/0000 00:00 AM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Created: ";
            // 
            // txtComments
            // 
            this.txtComments.AcceptsReturn = true;
            this.txtComments.AcceptsTab = true;
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Location = new System.Drawing.Point(11, 86);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComments.Size = new System.Drawing.Size(557, 123);
            this.txtComments.TabIndex = 3;
            this.txtComments.TextChanged += new System.EventHandler(this.txtComments_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Collection Comments";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Collection Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(88, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(480, 20);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // CollectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "CollectionForm";
            this.Text = "New Collection";
            this.Load += new System.EventHandler(this.CollectionForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewItems)).EndInit();
            this.listContextMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageItems.ResumeLayout(false);
            this.tabPageProperties.ResumeLayout(false);
            this.tabPageProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewItems;
        private BrightIdeasSoftware.ObjectListView objectListViewItems;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageItems;
        private System.Windows.Forms.TabPage tabPageProperties;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblModified;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Label label3;
        private BrightIdeasSoftware.OLVColumn colTitle;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnDel;
        private BrightIdeasSoftware.OLVColumn colSubtitle;
        private BrightIdeasSoftware.OLVColumn colPubDate;
        private BrightIdeasSoftware.OLVColumn colGenre;
        private BrightIdeasSoftware.OLVColumn colSeries;
        private BrightIdeasSoftware.OLVColumn colSeriesNumber;
        private System.Windows.Forms.Button btnAddVideo;
        private System.Windows.Forms.Button btnAddMusic;
        private System.Windows.Forms.Button btnAddGame;
        private System.Windows.Forms.ContextMenuStrip listContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loanToolStripMenuItem;
    }
}