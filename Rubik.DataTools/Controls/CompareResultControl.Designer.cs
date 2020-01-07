namespace Rubik.DataTools.Controls
{
    partial class CompareResultControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareResultControl));
            this.panelDefault = new System.Windows.Forms.Panel();
            this.treeSchema = new System.Windows.Forms.TreeView();
            this.titleBar1 = new Crownwood.DotNetMagic.Controls.TitleBar();
            this.pnlSchema_diff1 = new System.Windows.Forms.Panel();
            this.treeSchema_diff1 = new System.Windows.Forms.TreeView();
            this.titleBar2 = new Crownwood.DotNetMagic.Controls.TitleBar();
            this.pnlSchema_diff2 = new System.Windows.Forms.Panel();
            this.treeSchema_diff2 = new System.Windows.Forms.TreeView();
            this.titleBar3 = new Crownwood.DotNetMagic.Controls.TitleBar();
            this.pnlScript = new System.Windows.Forms.Panel();
            this.scriptControl = new ICSharpCode.TextEditor.TextEditorControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.işlemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kopyalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titleBar4 = new Crownwood.DotNetMagic.Controls.TitleBar();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelDefault.SuspendLayout();
            this.pnlSchema_diff1.SuspendLayout();
            this.pnlSchema_diff2.SuspendLayout();
            this.pnlScript.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDefault
            // 
            this.panelDefault.Controls.Add(this.treeSchema);
            this.panelDefault.Controls.Add(this.titleBar1);
            this.panelDefault.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelDefault.Location = new System.Drawing.Point(0, 0);
            this.panelDefault.Name = "panelDefault";
            this.panelDefault.Size = new System.Drawing.Size(200, 595);
            this.panelDefault.TabIndex = 0;
            // 
            // treeSchema
            // 
            this.treeSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeSchema.ImageIndex = 0;
            this.treeSchema.ImageList = this.ımageList1;
            this.treeSchema.Location = new System.Drawing.Point(0, 23);
            this.treeSchema.Name = "treeSchema";
            this.treeSchema.SelectedImageIndex = 17;
            this.treeSchema.Size = new System.Drawing.Size(200, 572);
            this.treeSchema.TabIndex = 5;
            this.treeSchema.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeSchema_AfterSelect);
            // 
            // titleBar1
            // 
            this.titleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar1.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
            this.titleBar1.Location = new System.Drawing.Point(0, 0);
            this.titleBar1.MouseOverColor = System.Drawing.Color.Empty;
            this.titleBar1.Name = "titleBar1";
            this.titleBar1.Size = new System.Drawing.Size(200, 23);
            this.titleBar1.TabIndex = 2;
            this.titleBar1.Text = "Mevcut Şema";
            // 
            // pnlSchema_diff1
            // 
            this.pnlSchema_diff1.Controls.Add(this.treeSchema_diff1);
            this.pnlSchema_diff1.Controls.Add(this.titleBar2);
            this.pnlSchema_diff1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSchema_diff1.Location = new System.Drawing.Point(200, 0);
            this.pnlSchema_diff1.Name = "pnlSchema_diff1";
            this.pnlSchema_diff1.Size = new System.Drawing.Size(200, 595);
            this.pnlSchema_diff1.TabIndex = 1;
            // 
            // treeSchema_diff1
            // 
            this.treeSchema_diff1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeSchema_diff1.ImageIndex = 0;
            this.treeSchema_diff1.ImageList = this.ımageList1;
            this.treeSchema_diff1.Location = new System.Drawing.Point(0, 23);
            this.treeSchema_diff1.Name = "treeSchema_diff1";
            this.treeSchema_diff1.SelectedImageIndex = 17;
            this.treeSchema_diff1.Size = new System.Drawing.Size(200, 572);
            this.treeSchema_diff1.TabIndex = 4;
            this.treeSchema_diff1.Tag = "DiffSchema";
            this.treeSchema_diff1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeSchema_AfterSelect);
            // 
            // titleBar2
            // 
            this.titleBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar2.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
            this.titleBar2.Location = new System.Drawing.Point(0, 0);
            this.titleBar2.MouseOverColor = System.Drawing.Color.Empty;
            this.titleBar2.Name = "titleBar2";
            this.titleBar2.Size = new System.Drawing.Size(200, 23);
            this.titleBar2.TabIndex = 2;
            this.titleBar2.Text = "Eksikler";
            // 
            // pnlSchema_diff2
            // 
            this.pnlSchema_diff2.Controls.Add(this.treeSchema_diff2);
            this.pnlSchema_diff2.Controls.Add(this.titleBar3);
            this.pnlSchema_diff2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSchema_diff2.Location = new System.Drawing.Point(400, 0);
            this.pnlSchema_diff2.Name = "pnlSchema_diff2";
            this.pnlSchema_diff2.Size = new System.Drawing.Size(200, 595);
            this.pnlSchema_diff2.TabIndex = 2;
            // 
            // treeSchema_diff2
            // 
            this.treeSchema_diff2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeSchema_diff2.ImageIndex = 0;
            this.treeSchema_diff2.ImageList = this.ımageList1;
            this.treeSchema_diff2.Location = new System.Drawing.Point(0, 23);
            this.treeSchema_diff2.Name = "treeSchema_diff2";
            this.treeSchema_diff2.SelectedImageIndex = 17;
            this.treeSchema_diff2.Size = new System.Drawing.Size(200, 572);
            this.treeSchema_diff2.TabIndex = 3;
            this.treeSchema_diff2.Tag = "DiffDatabase";
            // 
            // titleBar3
            // 
            this.titleBar3.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar3.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
            this.titleBar3.Location = new System.Drawing.Point(0, 0);
            this.titleBar3.MouseOverColor = System.Drawing.Color.Empty;
            this.titleBar3.Name = "titleBar3";
            this.titleBar3.Size = new System.Drawing.Size(200, 23);
            this.titleBar3.TabIndex = 2;
            this.titleBar3.Text = "Fazlalıklar";
            // 
            // pnlScript
            // 
            this.pnlScript.Controls.Add(this.scriptControl);
            this.pnlScript.Controls.Add(this.menuStrip1);
            this.pnlScript.Controls.Add(this.titleBar4);
            this.pnlScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScript.Location = new System.Drawing.Point(600, 0);
            this.pnlScript.Name = "pnlScript";
            this.pnlScript.Size = new System.Drawing.Size(484, 595);
            this.pnlScript.TabIndex = 3;
            // 
            // scriptControl
            // 
            this.scriptControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptControl.IsReadOnly = false;
            this.scriptControl.Location = new System.Drawing.Point(0, 47);
            this.scriptControl.Name = "scriptControl";
            this.scriptControl.Size = new System.Drawing.Size(484, 548);
            this.scriptControl.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.işlemlerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 23);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // işlemlerToolStripMenuItem
            // 
            this.işlemlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kopyalaToolStripMenuItem});
            this.işlemlerToolStripMenuItem.Name = "işlemlerToolStripMenuItem";
            this.işlemlerToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.işlemlerToolStripMenuItem.Text = "İşlemler";
            // 
            // kopyalaToolStripMenuItem
            // 
            this.kopyalaToolStripMenuItem.Name = "kopyalaToolStripMenuItem";
            this.kopyalaToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.kopyalaToolStripMenuItem.Text = "Kopyala";
            // 
            // titleBar4
            // 
            this.titleBar4.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar4.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
            this.titleBar4.Location = new System.Drawing.Point(0, 0);
            this.titleBar4.MouseOverColor = System.Drawing.Color.Empty;
            this.titleBar4.Name = "titleBar4";
            this.titleBar4.Size = new System.Drawing.Size(484, 23);
            this.titleBar4.TabIndex = 2;
            this.titleBar4.Text = "Scripot";
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
            // CompareResultControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlScript);
            this.Controls.Add(this.pnlSchema_diff2);
            this.Controls.Add(this.pnlSchema_diff1);
            this.Controls.Add(this.panelDefault);
            this.Name = "CompareResultControl";
            this.Size = new System.Drawing.Size(1084, 595);
            this.panelDefault.ResumeLayout(false);
            this.pnlSchema_diff1.ResumeLayout(false);
            this.pnlSchema_diff2.ResumeLayout(false);
            this.pnlScript.ResumeLayout(false);
            this.pnlScript.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDefault;
        private Crownwood.DotNetMagic.Controls.TitleBar titleBar1;
        private System.Windows.Forms.Panel pnlSchema_diff1;
        private Crownwood.DotNetMagic.Controls.TitleBar titleBar2;
        private System.Windows.Forms.Panel pnlSchema_diff2;
        private Crownwood.DotNetMagic.Controls.TitleBar titleBar3;
        private System.Windows.Forms.Panel pnlScript;
        private Crownwood.DotNetMagic.Controls.TitleBar titleBar4;
        private ICSharpCode.TextEditor.TextEditorControl scriptControl;
        private System.Windows.Forms.TreeView treeSchema;
        private System.Windows.Forms.TreeView treeSchema_diff1;
        private System.Windows.Forms.TreeView treeSchema_diff2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem işlemlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kopyalaToolStripMenuItem;
        private System.Windows.Forms.ImageList ımageList1;

    }
}
