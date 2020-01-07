using Crownwood.DotNetMagic.Controls;
using Devart.Data.Oracle;
using ICSharpCode.TextEditor.Document;
using NLog;
using NLog.Targets;
using Rubik.DataTools.Fluent;
using Rubik.DataTools.Interface;
using Rubik.DataTools.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Rubik.DataTools.Controls
{
    public partial class DatabaseViewer : Form
    {
        Color _defaultNodeColor;
        Color _selectedNodeColor = Color.LightBlue;
        Wizard _configWizard;
        Logger logger;
        DatabaseFactory _db;
        Dispatcher dispatcherUI = Dispatcher.CurrentDispatcher;

        private string _connectionString = "";

        public DatabaseViewer(DatabaseFactory db)
        {
            this._db = db;
            InitializeComponent();

        }

        public DatabaseViewer()
        {
            InitializeComponent();
            _configWizard = new Wizard();
        }

        private void DatabaseViewer_Load(object sender, EventArgs e)
        {
            InitializeLog();

            //HighlightingManager.Manager.AddSyntaxModeFileProvider(new SyntaxModeProvider());
            //textEditorControl1.SetHighlighting("SQL");
            //textEditorControl1.IsReadOnly = true;
            this.Activate();
            this.SetTopLevel(true);

            if (_db != null)
                FillSchema();
        }

        private void InitializeLog()
        {
            try
            {
                logger = NLog.LogManager.GetCurrentClassLogger();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task<bool> CreateSchema()
        {
            DatabaseParameters param = null;
            if (string.IsNullOrEmpty(_connectionString))
            {
                if (_configWizard.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    param = _configWizard.Parameters;
                    if (param == null)
                        return false;
                }
                else
                {
                    return false;
                }
            }

            treeView1.Enabled = false;
            _db = DatabaseFactory
                .Init(param.ConnectionString)
                .ExcludeDefaultSchema()
                .UseDatabaseFilter(new DatabaseFilter());

            _db.IsSchemaFile = false;

            foreach (var user in param.SelectedUsers)
            {
                _db.AddSchema(user);
            }

            if (param.DropObjects)
                _db.IncludeDropStatement();

            if (param.CreateUser)
                _db.CreateUserScript();

            if (param.SeparateSchemas)
                _db.SeparateScriptFilePerSchema();

            if (param.AutoChangeSchema)
                _db.UseSchemaChangeScript();

            _db.OnSchemaProcess += _db_OnSchemaProcess;

            bool result = await _db.BuildAsync();

            FillSchema();
            treeView1.Enabled = true;
            statusBar.Text = "";
            tsCompare.Enabled = true;
            tsDatabaseInfo.Enabled = true;
            tsSaveSchema.Enabled = true;
            tsCreateScript.Enabled = true;

            return result;
        }

        private void FillSchema()
        {
            if (_db == null)
            {
                logger.Error("Database Schema Null !!");
            }

            treeView1.Nodes.Clear();
            treeView1.SuspendLayout();
            TreeNode rootNode = new TreeNode(_db.Name + " " + _db.DatabaseVersion);
            rootNode.ImageIndex = 0;
            rootNode.Checked = _db.IsSelected;
            treeView1.Nodes.Add(rootNode);
            foreach (var user in _db.Users)
            {
                var newChild = new TreeNode()
                {
                    Text = user.Name
                };
                newChild.Tag = user;
                rootNode.Nodes.Add(newChild);
                rootNode.Checked = user.IsSelected;
                FillNode(user.SchemaObjects.ToList(), newChild);
            }

            treeView1.Nodes[0].Expand();
            treeView1.ResumeLayout();

            tsSaveScript.Enabled = true;
            tsSaveSchema.Enabled = true;
        }

        private void FillNode(List<IDatabaseObject> dbObjects, TreeNode rootNode)
        {
            foreach (var dbObject in dbObjects)
            {
                var typeNode = rootNode.Nodes[dbObject.ObjectType.ToString()];

                if (typeNode == null)
                {
                    typeNode = new TreeNode(dbObject.ObjectType.ToString())
                    {
                        Checked = dbObject.IsSelected,
                        Name = dbObject.ObjectType.ToString()
                    };
                    rootNode.Nodes.Add(typeNode);
                }

                var itemNode = new TreeNode(dbObject.Name)
                {
                    Name = dbObject.Name,
                    Checked = dbObject.IsSelected,
                    Tag = dbObject
                };

                if (dbObject.ObjectType == Enums.ObjectTypeEnum.TABLE)
                {
                    Table table = dbObject as Table;

                    if ((dbObject as Table).IncludeTableData)
                    {
                        itemNode.ImageIndex = 4;
                        //typeNode.ImageIndex = 4;
                    }
                    else
                    {
                        itemNode.ImageIndex = 1;
                    }
                    typeNode.ImageIndex = 1;
                }
                else if (dbObject.ObjectType == Enums.ObjectTypeEnum.Column)
                {
                    typeNode.ImageIndex = 9;
                    itemNode.ImageIndex = 9;
                }
                else if (dbObject.ObjectType == Enums.ObjectTypeEnum.INDEX)
                {
                    typeNode.ImageIndex = 5;
                    itemNode.ImageIndex = 5;
                }
                else if (dbObject.ObjectType == Enums.ObjectTypeEnum.FUNCTION)
                {
                    typeNode.ImageIndex = 11;
                    itemNode.ImageIndex = 11;
                }

                typeNode.Nodes.Add(itemNode);

                if (dbObject.ObjectType == Enums.ObjectTypeEnum.TABLE)
                {
                    FillNode(((Table)dbObject).Columns.ToList<IDatabaseObject>(), itemNode);
                }
                else if (dbObject.ObjectType == Enums.ObjectTypeEnum.INDEX)
                {
                    TreeNode indexColNode = itemNode.Nodes.Add("Columns");
                    TreeNode indexTabNode = itemNode.Nodes.Add("Table");
                    FillNode(((Index)dbObject).Columns.ToList(), indexColNode);
                    FillNode(new List<string>() { ((Index)dbObject).Table }, indexTabNode);
                }
            }


        }

        private void FillNode(List<string> items, TreeNode itemNode)
        {
            foreach (var item in items)
            {
                itemNode.Nodes.Add(item);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            var dbRoot = e.Node.Tag as DatabaseObject;
            if (dbRoot != null)
                dbRoot.IsSelected = e.Node.Checked;

            foreach (var item in e.Node.Nodes)
            {
                TreeNode node = item as TreeNode;
                node.Checked = e.Node.Checked;
                var dbObject = node.Tag as DatabaseObject;

                if (dbObject != null)
                {
                    if (dbObject.ObjectType == Enums.ObjectTypeEnum.Schema)
                    {

                    }
                    dbObject.IsSelected = e.Node.Checked;
                }

            }
        }

        private async void tsCreateSchema_Click(object sender, EventArgs e)
        {
            CreateSchema();
        }

        private void tsLoadSchema_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _db = DatabaseFactory.DeSerialize(of.FileName);

                _db.Name = "( Dosyadan )";
                _db.DatabaseVersion = "[Dosyadan]- " + _db.DatabaseVersion;
                tsSaveSchema.Enabled = false;
                FillSchema();

                tsCompare.Enabled = false;
                tsDatabaseInfo.Enabled = false;
            }
        }

        private void tsCompare_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DatabaseFactory factory = DatabaseFactory.DeSerialize(of.FileName);
                CompareResultControl result = new CompareResultControl();
                result.SourceDatabase = _db;
                result.DestinationDatabase = factory;
                result.Dock = DockStyle.Fill;

                var tab = new Crownwood.DotNetMagic.Controls.TabPage();
                tab.Controls.Add(result);
                tab.Title = "Karşılaştır";

                tabControl1.TabPages.Add(tab);
                result.Compare();
            }
        }

        private void tsSaveSchema_Click(object sender, EventArgs e)
        {
            SaveFileDialog of = new SaveFileDialog();
            of.DefaultExt = ".dbs";
            of.Filter = "Database Şema (.dbs) |";
            if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _db.SerializeDatabase(of.FileName);
            }
        }

        private void tsCreateScript_Click(object sender, EventArgs e)
        {
            //if (_db != null)
            //{
            //    splitContainer2.Panel1Collapsed = true;
            //    textEditorControl1.Text = _db.ToSql();
            //    textEditorControl1.Refresh();
            //}
        }

        private void tsSaveScript_Click(object sender, EventArgs e)
        {
            SaveFileDialog of = new SaveFileDialog();
            of.DefaultExt = ".sql";
            of.Filter = "Sql Dosyası (.sql) |";
            if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fs = File.Create(of.FileName);
                TextWriter writer = new StreamWriter(fs, Encoding.UTF8);
                writer.Write(_db.ToSql());
                fs.Flush();
                fs.Close();
            }
        }

        private void Comparedatabase(DatabaseFactory db)
        {
            _db = DatabaseComparer.CompareDatabase(_db, db);
            FillSchema();

        }

        private void FindAndPaintNode(IDatabaseObject dbObject)
        {
            if (dbObject.GetType() == typeof(Table))
            {
                foreach (var item in ((Table)dbObject).Columns)
                {
                    FindAndPaintNode(item);
                }
            }
            else
            {
                var treeNodes = treeView1.Nodes.Find(dbObject.Name, true);
                if (treeNodes.Count() > 0)
                {
                    var treeNode = treeNodes[0];
                    PaintNode(treeNode);
                }
            }
        }

        private void PaintNode(TreeNode node)
        {
            node.BackColor = Color.RosyBrown;

            if (node.Parent != null)
                PaintNode(node.Parent);
        }

        private void tsExit_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (treeView1.SelectedNode.Tag != null && treeView1.SelectedNode.Tag is IDatabaseObject)
                {
                    var dbItem = treeView1.SelectedNode.Tag as Table;
                    if (dbItem != null)
                    {
                        contextMenuStrip1.Show(treeView1, new Point(e.X, e.Y));

                        //if (dbItem.IncludeTableData)
                        // {

                        //     cmsExclude.Visible = true;
                        //     cmsInclude.Visible = false;
                        //     contextMenuStrip1.Show(treeView1, new Point(e.X, e.Y));
                        // }
                        // else
                        // {
                        //     cmsExclude.Visible = false;
                        //     cmsInclude.Visible = true;
                        //     contextMenuStrip1.Show(treeView1, new Point(e.X, e.Y));
                        // }
                    }
                }
            }
        }

        private void tabloVerisinideDışaAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedNode = treeView1.SelectedNode;
            var table = selectedNode.Tag as Table;

            if (table != null)
            {
                var clobCols = from p in table.Columns
                               where p.DataType == Enums.DataTypeEnums.CLOB ||
                               p.DataType == Enums.DataTypeEnums.BLOB || p.DataType == Enums.DataTypeEnums.RAW
                               select p;

                if (clobCols.Count() > 0)
                {
                    MessageBox.Show("CLOB , BLOB , RAW alan bulunduran tabloların datası aktarılamaz !");
                    return;
                }
                else
                {
                    selectedNode.ImageIndex = 4;
                    table.IncludeTableData = true;
                }
            }
        }

        private void cmsExclude_Click(object sender, EventArgs e)
        {
            var selectedNode = treeView1.SelectedNode;
            var table = selectedNode.Tag as Table;

            if (table != null)
            {
                selectedNode.ImageIndex = 1;
                table.IncludeTableData = false;
            }
        }

        private void tsDatabaseInfo_Click(object sender, EventArgs e)
        {
            OracleSettings settings = new OracleSettings();
            settings.ShowDialog();

        }

        #region Events

        void _db_OnSchemaProcess(IDatabase database, Schema schema, IDatabaseObject obj)
        {
            dispatcherUI.BeginInvoke(new Action(() =>
            {
                statusBar.Text = schema.Name + "." + obj.Name + " Oluşturuldu";
            }));
        }

        #endregion

        private void tabloBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dbItem = treeView1.SelectedNode.Tag as Table;
            if (dbItem != null)
            {
                TableInformation tableinfo = new TableInformation();
                tableinfo.Dock = DockStyle.Fill;
                tableinfo.SelectedTable = dbItem;
                var tab = new Crownwood.DotNetMagic.Controls.TabPage();
                tab.Controls.Add(tableinfo);
                tab.Title = "Tablo Bilgileri";

                tabControlDetail.TabPages.Add(tab);

                tableinfo.Build();
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag is IDatabaseObject)
            {
                DatabaseObject baseObject = e.Node.Tag as DatabaseObject;

                var oldTab = tabControlDetail.TabPages[baseObject.Name];
                if (oldTab != null)
                {
                    tabControlDetail.SelectedTab = oldTab;
                    oldTab.Focus();
                }
                else
                {
                    if (baseObject.ObjectType == Enums.ObjectTypeEnum.TABLE)
                    {
                        var table = ((Table)e.Node.Tag);

                        TableInformation tableinfo = new TableInformation();
                        tableinfo.Dock = DockStyle.Fill;
                        tableinfo.SelectedTable = table;
                        var tab = new Crownwood.DotNetMagic.Controls.TabPage();
                        tab.Title = table.Name;
                        tab.Controls.Add(tableinfo);

                        tabControlDetail.TabPages.Add(tab);
                        tabControlDetail.SelectedTab = tab;

                        tableinfo.Build();
                    }
                    else if (baseObject.ObjectType != Enums.ObjectTypeEnum.INDEX 
                        && baseObject.ObjectType != Enums.ObjectTypeEnum.Key
                        && baseObject.ObjectType != Enums.ObjectTypeEnum.Database
                        && baseObject.ObjectType != Enums.ObjectTypeEnum.Column
                        && baseObject.ObjectType != Enums.ObjectTypeEnum.Schema
                        )
                    {
                        var dbObject = ((DatabaseObject)e.Node.Tag);

                        ScriptControl scriptControl = new ScriptControl();
                        scriptControl.DbObject = dbObject;
                        scriptControl.Dock = DockStyle.Fill;
                        var tab = new Crownwood.DotNetMagic.Controls.TabPage();
                        
                        tab.Title = dbObject.Name;
                        tab.Controls.Add(scriptControl);

                        tabControlDetail.TabPages.Add(tab);
                        tabControlDetail.SelectedTab = tab;
                        scriptControl.Build();
                    }
                }
            }
        }

        private void tabControlDetail_ClosePressed(object sender, EventArgs e)
        {
            tabControlDetail.TabPages.Remove(tabControlDetail.SelectedTab);
        }
    }
}

