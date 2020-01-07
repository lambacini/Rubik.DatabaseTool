namespace Rubik.Database.Controls
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
            this.tabControl1 = new Crownwood.DotNetMagic.Controls.TabControl();
            this.tabPage1 = new Crownwood.DotNetMagic.Controls.TabPage();
            this.tabPage2 = new Crownwood.DotNetMagic.Controls.TabPage();
            this.treeControl1 = new Crownwood.DotNetMagic.Controls.TreeControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonWithStyle1 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
            this.titleBar1 = new Crownwood.DotNetMagic.Controls.TitleBar();
            this.buttonWithStyle2 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
            this.buttonWithStyle3 = new Crownwood.DotNetMagic.Controls.ButtonWithStyle();
            this.tabControl2 = new Crownwood.DotNetMagic.Controls.TabControl();
            this.tabDbObjects = new Crownwood.DotNetMagic.Controls.TabPage();
            this.tabSqlScript = new Crownwood.DotNetMagic.Controls.TabPage();
            this.tabLog = new Crownwood.DotNetMagic.Controls.TabPage();
            this.logText = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabDbObjects.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.OfficeDockSides = false;
            this.tabControl1.PositionTop = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowDropSelect = false;
            this.tabControl1.Size = new System.Drawing.Size(780, 699);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.TabPages.AddRange(new Crownwood.DotNetMagic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabLog});
            this.tabControl1.TextTips = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.InactiveBackColor = System.Drawing.Color.Empty;
            this.tabPage1.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.tabPage1.InactiveTextColor = System.Drawing.Color.Empty;
            this.tabPage1.Location = new System.Drawing.Point(1, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.SelectBackColor = System.Drawing.Color.Empty;
            this.tabPage1.SelectTextBackColor = System.Drawing.Color.Empty;
            this.tabPage1.SelectTextColor = System.Drawing.Color.Empty;
            this.tabPage1.Size = new System.Drawing.Size(778, 674);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Title = "Kaşılaştır";
            this.tabPage1.ToolTip = "Compare";
            // 
            // tabPage2
            // 
            this.tabPage2.InactiveBackColor = System.Drawing.Color.Empty;
            this.tabPage2.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.tabPage2.InactiveTextColor = System.Drawing.Color.Empty;
            this.tabPage2.Location = new System.Drawing.Point(1, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.SelectBackColor = System.Drawing.Color.Empty;
            this.tabPage2.Selected = false;
            this.tabPage2.SelectTextBackColor = System.Drawing.Color.Empty;
            this.tabPage2.SelectTextColor = System.Drawing.Color.Empty;
            this.tabPage2.Size = new System.Drawing.Size(778, 674);
            this.tabPage2.TabIndex = 5;
            this.tabPage2.Title = "Dışa Aktar";
            this.tabPage2.ToolTip = "Page";
            // 
            // treeControl1
            // 
            this.treeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeControl1.FocusNode = null;
            this.treeControl1.HotBackColor = System.Drawing.Color.Empty;
            this.treeControl1.HotForeColor = System.Drawing.Color.Empty;
            this.treeControl1.Location = new System.Drawing.Point(0, 0);
            this.treeControl1.Name = "treeControl1";
            this.treeControl1.SelectedNode = null;
            this.treeControl1.SelectedNoFocusBackColor = System.Drawing.SystemColors.Control;
            this.treeControl1.Size = new System.Drawing.Size(776, 584);
            this.treeControl1.TabIndex = 2;
            this.treeControl1.Text = "treeControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonWithStyle3);
            this.panel1.Controls.Add(this.buttonWithStyle2);
            this.panel1.Controls.Add(this.titleBar1);
            this.panel1.Controls.Add(this.buttonWithStyle1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 65);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(778, 609);
            this.panel2.TabIndex = 4;
            // 
            // buttonWithStyle1
            // 
            this.buttonWithStyle1.Location = new System.Drawing.Point(11, 29);
            this.buttonWithStyle1.Name = "buttonWithStyle1";
            this.buttonWithStyle1.Size = new System.Drawing.Size(122, 23);
            this.buttonWithStyle1.TabIndex = 0;
            this.buttonWithStyle1.Text = "Şema Seç";
            // 
            // titleBar1
            // 
            this.titleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar1.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
            this.titleBar1.Location = new System.Drawing.Point(0, 0);
            this.titleBar1.MouseOverColor = System.Drawing.Color.Empty;
            this.titleBar1.Name = "titleBar1";
            this.titleBar1.Size = new System.Drawing.Size(778, 23);
            this.titleBar1.TabIndex = 1;
            this.titleBar1.Text = ".:: Veritabanı Karşılaştırma İşlemleri";
            // 
            // buttonWithStyle2
            // 
            this.buttonWithStyle2.Location = new System.Drawing.Point(139, 29);
            this.buttonWithStyle2.Name = "buttonWithStyle2";
            this.buttonWithStyle2.Size = new System.Drawing.Size(122, 23);
            this.buttonWithStyle2.TabIndex = 2;
            this.buttonWithStyle2.Text = "Başlat";
            // 
            // buttonWithStyle3
            // 
            this.buttonWithStyle3.Location = new System.Drawing.Point(267, 29);
            this.buttonWithStyle3.Name = "buttonWithStyle3";
            this.buttonWithStyle3.Size = new System.Drawing.Size(167, 23);
            this.buttonWithStyle3.TabIndex = 3;
            this.buttonWithStyle3.Text = "Script Dosyası Oluştur";
            // 
            // tabControl2
            // 
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.OfficeDockSides = false;
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.ShowDropSelect = false;
            this.tabControl2.Size = new System.Drawing.Size(778, 609);
            this.tabControl2.TabIndex = 3;
            this.tabControl2.TabPages.AddRange(new Crownwood.DotNetMagic.Controls.TabPage[] {
            this.tabDbObjects,
            this.tabSqlScript});
            this.tabControl2.TextTips = true;
            // 
            // tabDbObjects
            // 
            this.tabDbObjects.Controls.Add(this.treeControl1);
            this.tabDbObjects.InactiveBackColor = System.Drawing.Color.Empty;
            this.tabDbObjects.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.tabDbObjects.InactiveTextColor = System.Drawing.Color.Empty;
            this.tabDbObjects.Location = new System.Drawing.Point(1, 1);
            this.tabDbObjects.Name = "tabDbObjects";
            this.tabDbObjects.SelectBackColor = System.Drawing.Color.Empty;
            this.tabDbObjects.SelectTextBackColor = System.Drawing.Color.Empty;
            this.tabDbObjects.SelectTextColor = System.Drawing.Color.Empty;
            this.tabDbObjects.Size = new System.Drawing.Size(776, 584);
            this.tabDbObjects.TabIndex = 4;
            this.tabDbObjects.Title = "Veritabanı Nesneleri";
            this.tabDbObjects.ToolTip = "Page";
            // 
            // tabSqlScript
            // 
            this.tabSqlScript.Enabled = false;
            this.tabSqlScript.InactiveBackColor = System.Drawing.Color.Empty;
            this.tabSqlScript.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.tabSqlScript.InactiveTextColor = System.Drawing.Color.Empty;
            this.tabSqlScript.Location = new System.Drawing.Point(1, 1);
            this.tabSqlScript.Name = "tabSqlScript";
            this.tabSqlScript.SelectBackColor = System.Drawing.Color.Empty;
            this.tabSqlScript.Selected = false;
            this.tabSqlScript.SelectTextBackColor = System.Drawing.Color.Empty;
            this.tabSqlScript.SelectTextColor = System.Drawing.Color.Empty;
            this.tabSqlScript.Size = new System.Drawing.Size(776, 584);
            this.tabSqlScript.TabIndex = 5;
            this.tabSqlScript.Title = "Sql Script";
            this.tabSqlScript.ToolTip = "Page";
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.logText);
            this.tabLog.InactiveBackColor = System.Drawing.Color.Empty;
            this.tabLog.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.tabLog.InactiveTextColor = System.Drawing.Color.Empty;
            this.tabLog.Location = new System.Drawing.Point(1, 24);
            this.tabLog.Name = "tabLog";
            this.tabLog.SelectBackColor = System.Drawing.Color.Empty;
            this.tabLog.SelectTextBackColor = System.Drawing.Color.Empty;
            this.tabLog.SelectTextColor = System.Drawing.Color.Empty;
            this.tabLog.Size = new System.Drawing.Size(778, 674);
            this.tabLog.TabIndex = 6;
            this.tabLog.Title = "Log";
            this.tabLog.ToolTip = "Application Logs";
            // 
            // logText
            // 
            this.logText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logText.Location = new System.Drawing.Point(0, 0);
            this.logText.Name = "logText";
            this.logText.Size = new System.Drawing.Size(778, 674);
            this.logText.TabIndex = 0;
            this.logText.Text = "";
            // 
            // DatabaseViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 699);
            this.Controls.Add(this.tabControl1);
            this.Name = "DatabaseViewer";
            this.Text = ".:: Database Viewer ::.";
            this.Load += new System.EventHandler(this.DatabaseViewer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabDbObjects.ResumeLayout(false);
            this.tabLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Crownwood.DotNetMagic.Controls.TabControl tabControl1;
        private Crownwood.DotNetMagic.Controls.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private Crownwood.DotNetMagic.Controls.TabControl tabControl2;
        private Crownwood.DotNetMagic.Controls.TabPage tabDbObjects;
        private Crownwood.DotNetMagic.Controls.TreeControl treeControl1;
        private Crownwood.DotNetMagic.Controls.TabPage tabSqlScript;
        private System.Windows.Forms.Panel panel1;
        private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle3;
        private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle2;
        private Crownwood.DotNetMagic.Controls.TitleBar titleBar1;
        private Crownwood.DotNetMagic.Controls.ButtonWithStyle buttonWithStyle1;
        private Crownwood.DotNetMagic.Controls.TabPage tabPage2;
        private Crownwood.DotNetMagic.Controls.TabPage tabLog;
        private System.Windows.Forms.RichTextBox logText;
    }
}