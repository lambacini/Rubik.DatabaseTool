namespace Rubik.DataTools.Controls
{
    partial class DatabaseViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseViewer));
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.veritabanıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCreateSchema = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLoadSchema = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSaveSchema = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCompare = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCreateScript = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSaveScript = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsDatabaseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkındaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkındaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabDb = new Crownwood.DotNetMagic.Controls.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControlDetail = new Crownwood.DotNetMagic.Controls.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.titleBar1 = new Crownwood.DotNetMagic.Controls.TitleBar();
            this.tabControl1 = new Crownwood.DotNetMagic.Controls.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsInclude = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsExclude = new System.Windows.Forms.ToolStripMenuItem();
            this.tabloBilgileriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabDb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "database.png");
            this.ımageList1.Images.SetKeyName(1, "table.png");
            this.ımageList1.Images.SetKeyName(2, "table_edit.png");
            this.ımageList1.Images.SetKeyName(3, "table_gear.png");
            this.ımageList1.Images.SetKeyName(4, "table_go.png");
            this.ımageList1.Images.SetKeyName(5, "table_key.png");
            this.ımageList1.Images.SetKeyName(6, "table_link.png");
            this.ımageList1.Images.SetKeyName(7, "table_refresh.png");
            this.ımageList1.Images.SetKeyName(8, "table_relationship.png");
            this.ımageList1.Images.SetKeyName(9, "table_row_delete.png");
            this.ımageList1.Images.SetKeyName(10, "key.png");
            this.ımageList1.Images.SetKeyName(11, "script.png");
            this.ımageList1.Images.SetKeyName(12, "disk.png");
            this.ımageList1.Images.SetKeyName(13, "exclamation.png");
            this.ımageList1.Images.SetKeyName(14, "connect.png");
            this.ımageList1.Images.SetKeyName(15, "database_refresh.png");
            this.ımageList1.Images.SetKeyName(16, "database_save.png");
            this.ımageList1.Images.SetKeyName(17, "bullet_blue.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.veritabanıToolStripMenuItem,
            this.hakkındaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1209, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // veritabanıToolStripMenuItem
            // 
            this.veritabanıToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCreateSchema,
            this.tsLoadSchema,
            this.tsSaveSchema,
            this.tsCompare,
            this.tsCreateScript,
            this.tsSaveScript,
            this.toolStripSeparator1,
            this.tsDatabaseInfo});
            this.veritabanıToolStripMenuItem.Name = "veritabanıToolStripMenuItem";
            this.veritabanıToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.veritabanıToolStripMenuItem.Text = "Veritabanı";
            // 
            // tsCreateSchema
            // 
            this.tsCreateSchema.Image = global::Rubik.DataTools.Properties.Resources.disconnect;
            this.tsCreateSchema.Name = "tsCreateSchema";
            this.tsCreateSchema.Size = new System.Drawing.Size(198, 22);
            this.tsCreateSchema.Text = "Şema Yükle (Database)";
            this.tsCreateSchema.Click += new System.EventHandler(this.tsCreateSchema_Click);
            // 
            // tsLoadSchema
            // 
            this.tsLoadSchema.Image = global::Rubik.DataTools.Properties.Resources.bin_empty;
            this.tsLoadSchema.Name = "tsLoadSchema";
            this.tsLoadSchema.Size = new System.Drawing.Size(198, 22);
            this.tsLoadSchema.Text = "Şema Yükle (Dosyadan)";
            this.tsLoadSchema.Click += new System.EventHandler(this.tsLoadSchema_Click);
            // 
            // tsSaveSchema
            // 
            this.tsSaveSchema.Enabled = false;
            this.tsSaveSchema.Image = global::Rubik.DataTools.Properties.Resources.disk;
            this.tsSaveSchema.Name = "tsSaveSchema";
            this.tsSaveSchema.Size = new System.Drawing.Size(198, 22);
            this.tsSaveSchema.Text = "Şemayı Kaydet";
            this.tsSaveSchema.Click += new System.EventHandler(this.tsSaveSchema_Click);
            // 
            // tsCompare
            // 
            this.tsCompare.Image = global::Rubik.DataTools.Properties.Resources.database_refresh;
            this.tsCompare.Name = "tsCompare";
            this.tsCompare.Size = new System.Drawing.Size(198, 22);
            this.tsCompare.Text = "Dosya İle Karşılaştır";
            this.tsCompare.Click += new System.EventHandler(this.tsCompare_Click);
            // 
            // tsCreateScript
            // 
            this.tsCreateScript.Enabled = false;
            this.tsCreateScript.Image = global::Rubik.DataTools.Properties.Resources.script;
            this.tsCreateScript.Name = "tsCreateScript";
            this.tsCreateScript.Size = new System.Drawing.Size(198, 22);
            this.tsCreateScript.Text = "Sql Script";
            this.tsCreateScript.Click += new System.EventHandler(this.tsCreateScript_Click);
            // 
            // tsSaveScript
            // 
            this.tsSaveScript.Enabled = false;
            this.tsSaveScript.Image = global::Rubik.DataTools.Properties.Resources.script_save;
            this.tsSaveScript.Name = "tsSaveScript";
            this.tsSaveScript.Size = new System.Drawing.Size(198, 22);
            this.tsSaveScript.Text = "Sql Scripti Kaydet";
            this.tsSaveScript.Click += new System.EventHandler(this.tsSaveScript_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // tsDatabaseInfo
            // 
            this.tsDatabaseInfo.Name = "tsDatabaseInfo";
            this.tsDatabaseInfo.Size = new System.Drawing.Size(198, 22);
            this.tsDatabaseInfo.Text = "Oracle Parameters";
            this.tsDatabaseInfo.Click += new System.EventHandler(this.tsDatabaseInfo_Click);
            // 
            // hakkındaToolStripMenuItem
            // 
            this.hakkındaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hakkındaToolStripMenuItem1});
            this.hakkındaToolStripMenuItem.Name = "hakkındaToolStripMenuItem";
            this.hakkındaToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.hakkındaToolStripMenuItem.Text = "Yardım";
            // 
            // hakkındaToolStripMenuItem1
            // 
            this.hakkındaToolStripMenuItem1.Name = "hakkındaToolStripMenuItem1";
            this.hakkındaToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.hakkındaToolStripMenuItem1.Text = "Hakkında";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 673);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1209, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusBar
            // 
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(0, 17);
            // 
            // tabDb
            // 
            this.tabDb.Controls.Add(this.splitContainer1);
            this.tabDb.Controls.Add(this.panel1);
            this.tabDb.InactiveBackColor = System.Drawing.Color.Empty;
            this.tabDb.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.tabDb.InactiveTextColor = System.Drawing.Color.Empty;
            this.tabDb.Location = new System.Drawing.Point(1, 24);
            this.tabDb.Name = "tabDb";
            this.tabDb.SelectBackColor = System.Drawing.Color.Empty;
            this.tabDb.SelectTextBackColor = System.Drawing.Color.Empty;
            this.tabDb.SelectTextColor = System.Drawing.Color.Empty;
            this.tabDb.Size = new System.Drawing.Size(1207, 646);
            this.tabDb.TabIndex = 4;
            this.tabDb.Title = "Database";
            this.tabDb.ToolTip = "Compare";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlDetail);
            this.splitContainer1.Size = new System.Drawing.Size(1207, 621);
            this.splitContainer1.SplitterDistance = 201;
            this.splitContainer1.TabIndex = 7;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.ımageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 17;
            this.treeView1.Size = new System.Drawing.Size(201, 621);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            // 
            // tabControlDetail
            // 
            this.tabControlDetail.AutoSize = true;
            this.tabControlDetail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tabControlDetail.BoldSelectedPage = true;
            this.tabControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDetail.Location = new System.Drawing.Point(0, 0);
            this.tabControlDetail.Name = "tabControlDetail";
            this.tabControlDetail.OfficeDockSides = false;
            this.tabControlDetail.PositionTop = true;
            this.tabControlDetail.ShowArrows = true;
            this.tabControlDetail.ShowClose = true;
            this.tabControlDetail.ShowDropSelect = false;
            this.tabControlDetail.Size = new System.Drawing.Size(1002, 621);
            this.tabControlDetail.TabIndex = 2;
            this.tabControlDetail.TextTips = true;
            this.tabControlDetail.ClosePressed += new System.EventHandler(this.tabControlDetail_ClosePressed);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.titleBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1207, 25);
            this.panel1.TabIndex = 3;
            // 
            // titleBar1
            // 
            this.titleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar1.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
            this.titleBar1.Location = new System.Drawing.Point(0, 0);
            this.titleBar1.MouseOverColor = System.Drawing.Color.Empty;
            this.titleBar1.Name = "titleBar1";
            this.titleBar1.Size = new System.Drawing.Size(1207, 23);
            this.titleBar1.TabIndex = 1;
            this.titleBar1.Text = ".:: Veritabanı Karşılaştırma İşlemleri";
            // 
            // tabControl1
            // 
            this.tabControl1.AutoSize = true;
            this.tabControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tabControl1.BoldSelectedPage = true;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.OfficeDockSides = false;
            this.tabControl1.PositionTop = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowArrows = true;
            this.tabControl1.ShowClose = true;
            this.tabControl1.ShowDropSelect = false;
            this.tabControl1.Size = new System.Drawing.Size(1209, 671);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.TabPages.AddRange(new Crownwood.DotNetMagic.Controls.TabPage[] {
            this.tabDb});
            this.tabControl1.TextTips = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsInclude,
            this.cmsExclude,
            this.tabloBilgileriToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(219, 70);
            // 
            // cmsInclude
            // 
            this.cmsInclude.Name = "cmsInclude";
            this.cmsInclude.Size = new System.Drawing.Size(218, 22);
            this.cmsInclude.Text = "Tablo verisini dışa aktar";
            this.cmsInclude.Visible = false;
            this.cmsInclude.Click += new System.EventHandler(this.tabloVerisinideDışaAktarToolStripMenuItem_Click);
            // 
            // cmsExclude
            // 
            this.cmsExclude.Name = "cmsExclude";
            this.cmsExclude.Size = new System.Drawing.Size(218, 22);
            this.cmsExclude.Text = "Tablo verisini dışa aktarma !";
            this.cmsExclude.Visible = false;
            this.cmsExclude.Click += new System.EventHandler(this.cmsExclude_Click);
            // 
            // tabloBilgileriToolStripMenuItem
            // 
            this.tabloBilgileriToolStripMenuItem.Name = "tabloBilgileriToolStripMenuItem";
            this.tabloBilgileriToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.tabloBilgileriToolStripMenuItem.Text = "Tablo Bilgileri";
            this.tabloBilgileriToolStripMenuItem.Click += new System.EventHandler(this.tabloBilgileriToolStripMenuItem_Click);
            // 
            // DatabaseViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 695);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DatabaseViewer";
            this.Text = "Rubik Database Compare & Migrate v0.1";
            this.Load += new System.EventHandler(this.DatabaseViewer_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabDb.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem veritabanıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsCreateSchema;
        private System.Windows.Forms.ToolStripMenuItem tsLoadSchema;
        private System.Windows.Forms.ToolStripMenuItem hakkındaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hakkındaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsCompare;
        private System.Windows.Forms.ToolStripMenuItem tsCreateScript;
        private System.Windows.Forms.ToolStripMenuItem tsSaveScript;
        private System.Windows.Forms.ToolStripMenuItem tsSaveSchema;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBar;
        private Crownwood.DotNetMagic.Controls.TabPage tabDb;
        private System.Windows.Forms.Panel panel1;
        private Crownwood.DotNetMagic.Controls.TitleBar titleBar1;
        private Crownwood.DotNetMagic.Controls.TabControl tabControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmsInclude;
        private System.Windows.Forms.ToolStripMenuItem cmsExclude;
        private System.Windows.Forms.ToolStripMenuItem tsDatabaseInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem tabloBilgileriToolStripMenuItem;
        private Crownwood.DotNetMagic.Controls.TabControl tabControlDetail;
    }
}