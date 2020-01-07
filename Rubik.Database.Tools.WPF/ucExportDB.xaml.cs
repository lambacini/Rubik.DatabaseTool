using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Windows.Threading;
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Rubik.Database.Tools.WPF
{
    public partial class UcExportDb : UserControl
    {
        #region Variables

        public Objects.Database DatabaseSchema;
        private Objects.Database _schemaDb;
        private string _sql = "";
        private TreeViewItem _rootNodeItem = new TreeViewItem();

        #endregion
        #region Const
        public UcExportDb()
        {
            InitializeComponent();
            this.Loaded += UcExportDbLoaded;
        }
        #endregion
        #region Form Events
        private void UcExportDbLoaded(object sender, RoutedEventArgs e)
        {
            if (DatabaseSchema == null)
            {
                DatabaseSchema = new Objects.Database
                                     {
                                         ConnectionString = "User Id=FONETPACS;Password=1;Server=10.63.10.78;Direct=True;Sid=FONET;Persist Security Info=True" 
                                     };

                DatabaseSchema.OnObjectCreated += (s) =>
                                                      {
                                                          label1.Content = s;
                                                      };

                DatabaseSchema.InitializeDatabase();
                DatabaseSchema.DatabaseToSchema();
            }

            PopulateRootNodes();
            PopulateTables();
            PopulateViews();
            PopulateProcedure();
            PopulateSeqeucens();
            
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Rubik.Database.Tools.Export export = new Export(
                new DatabaseParameter()
                {
                    CreateTable = true,
                    DropTable = false,
                    ExportColumns = true,
                    ExportData = false,
                    ExportIndexes = true,
                    ExportKeys = true,
                    AutoSave = true,
                    ConnectionString = "User Id=FONETPACS;Password=1;Server=127.0.0.1;Direct=True;Sid=FONET;Persist Security Info=True",
                });
            export.Execute();
            SaveFileDialog sv = new SaveFileDialog();
            if (sv.ShowDialog().Value)
            {
                string filePath = sv.FileName;
                _sql = DatabaseSchema.GetFileHeader();
                DumpSqlString(_rootNodeItem);
                SaveFile(filePath);
            }
        }
        private void ButtonClick1(object sender, RoutedEventArgs e)
        {
            string filePath = "";
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Rubik Database Schemas (*.rds)|*.rds";
            if (sv.ShowDialog().Value == true)
            {
                filePath = sv.FileName;
                _schemaDb = new Objects.Database();
                DumpSchemas(_rootNodeItem);

                Stream sr = File.Open(filePath, FileMode.OpenOrCreate);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(sr,_schemaDb);
                sr.Close();
            }

            
        }
        #endregion
        #region Private Methods

        private void PopulateRootNodes()
        {
            tree1.Items.Clear();

            TreeViewItem dbNode = new TreeViewItem();
            dbNode.Header = DatabaseSchema.Name + " " + DatabaseSchema.ConnectionType;
            tree1.Items.Add(dbNode);
            _rootNodeItem = dbNode;

            TreeViewItem tableNode = new TreeViewItem();
            tableNode.Tag = "TABLE";
            CheckBox tableHeader = new CheckBox();
            tableHeader.IsChecked = true;
            tableHeader.Content = "Tables";
            tableNode.Header = tableHeader;
            tableHeader.Checked += (s, ex) => CheckUnCheckChild(tableNode, ex);
            tableHeader.Unchecked += (s, ex) => CheckUnCheckChild(tableNode, ex);
            _rootNodeItem.Items.Add(tableNode);

            TreeViewItem funcNode = new TreeViewItem();
            funcNode.Tag = "FUNCTION";
            CheckBox funcHeader = new CheckBox();
            funcHeader.IsChecked = true;
            funcHeader.Content = "Functions";
            funcHeader.Checked += (s, ex) => CheckUnCheckChild(funcNode, ex);
            funcHeader.Unchecked += (s, ex) => CheckUnCheckChild(funcNode, ex);
            funcNode.Header = funcHeader;

            _rootNodeItem.Items.Add(funcNode);

            TreeViewItem sqeNode = new TreeViewItem();
            sqeNode.Tag = "SQE";
            CheckBox sqeHeader = new CheckBox();
            sqeHeader.Content = "Sequences";
            sqeHeader.IsChecked = true;
            sqeHeader.Checked += (s, ex) => CheckUnCheckChild(sqeNode, ex);
            sqeHeader.Unchecked += (s, ex) => CheckUnCheckChild(sqeNode, ex);
            sqeNode.Header = sqeHeader;

            _rootNodeItem.Items.Add(sqeNode);

            TreeViewItem trigersNode = new TreeViewItem();
            trigersNode.Tag = "TRIGER";
            CheckBox trigersHeader = new CheckBox();
            trigersHeader.Content = "Trigers";
            trigersNode.Header = trigersHeader;
            trigersHeader.IsChecked = true;
            trigersHeader.Checked += (s, ex) => CheckUnCheckChild(trigersNode, ex);
            trigersHeader.Unchecked += (s, ex) => CheckUnCheckChild(trigersNode, ex);

            _rootNodeItem.Items.Add(trigersNode);

            TreeViewItem viewNode = new TreeViewItem();
            viewNode.Tag = "VIEW";
            CheckBox viewHeader = new CheckBox();
            viewHeader.IsChecked = true;
            viewHeader.Content = "Views";
            viewHeader.Checked += (s, ex) => CheckUnCheckChild(viewNode, ex);
            viewHeader.Unchecked += (s, ex) => CheckUnCheckChild(viewNode, ex);

            viewNode.Header = viewHeader;

            _rootNodeItem.Items.Add(viewNode);

            TreeViewItem packageNode = new TreeViewItem();
            packageNode.Tag = "PACKAGE";
            CheckBox packageHeader = new CheckBox();
            packageHeader.Content = "Package";
            packageHeader.IsChecked = true;
            packageHeader.Checked += (s, ex) => CheckUnCheckChild(packageNode, ex);
            packageHeader.Unchecked += (s, ex) => CheckUnCheckChild(packageNode, ex);
            packageNode.Header = packageHeader;

            _rootNodeItem.Items.Add(packageNode);


            TreeViewItem procedureNode = new TreeViewItem();
            procedureNode.Tag = "PROCEDURE";
            CheckBox procedureHeader = new CheckBox();
            procedureHeader.Content = "Procedures";
            procedureHeader.IsChecked = true;
            procedureHeader.Checked += (s, ex) => CheckUnCheckChild(procedureNode, ex);
            procedureHeader.Unchecked += (s, ex) => CheckUnCheckChild(procedureNode, ex);
            procedureNode.Header = procedureHeader;

            _rootNodeItem.Items.Add(procedureNode);
        }
        private void PopulateTables()
        {
            TreeViewItem tableTree = GetTreeViewItem("TABLE");
            if (tableTree == null)
                return;


            foreach (Objects.Table item in DatabaseSchema.Tables)
            {
                TreeViewItem table = new TreeViewItem {Tag = item};
                CheckBox chk = new CheckBox { Content = item.Name, IsChecked = !item.IsColumnsOnly };
                chk.Checked += (s, ex) => CheckUnCheckChild(table, ex);
                chk.Unchecked += (s, ex) => CheckUnCheckChild(table, ex);
                table.Header = chk;

                tableTree.Items.Add(table);

                TreeViewItem keysItems = new TreeViewItem {Header = "Keys"};
                table.Items.Add(keysItems);

                foreach (Objects.TableColumn col in item.Columns)
                {
                    TreeViewItem colItem = new TreeViewItem {Tag = col};
                    CheckBox chkCol = new CheckBox {Content = col.Name, IsChecked = true};
                    colItem.Header = chkCol;
                    chkCol.Checked += (s, ex) => CheckUnCheckChild(colItem, ex);
                    chkCol.Unchecked += (s, ex) => CheckUnCheckChild(colItem, ex);

                    table.Items.Add(colItem);
                }

                foreach (Objects.Keys key in item.KeyColumns)
                {
                    TreeViewItem keyItem = new TreeViewItem {Tag = key, Header = key.Name};
                    keysItems.Items.Add(keyItem);
                }
            }
        }
        private void PopulateViews()
        {
            TreeViewItem tableTree = GetTreeViewItem("VIEW");
            if (tableTree == null)
                return;

            foreach (Objects.View item in DatabaseSchema.Views)
            {
                TreeViewItem view = new TreeViewItem { Tag = item };
                CheckBox chk = new CheckBox { Content = item.Name};
                chk.Checked += (s, ex) => CheckUnCheckChild(view, ex);
                chk.Unchecked += (s, ex) => CheckUnCheckChild(view, ex);
                chk.IsChecked = true;
                view.Header = chk;

                tableTree.Items.Add(view);
            }
        }
        private void PopulateProcedure()
        {
            TreeViewItem tableTree = GetTreeViewItem("FUNCTION");
            if (tableTree == null)
                return;

            foreach (Objects.Function item in DatabaseSchema.Functions)
            {
                TreeViewItem view = new TreeViewItem { Tag = item };
                CheckBox chk = new CheckBox { Content = item.Name };
                chk.Checked += (s, ex) => CheckUnCheckChild(view, ex);
                chk.Unchecked += (s, ex) => CheckUnCheckChild(view, ex);
                chk.IsChecked = true;
                view.Header = chk;

                tableTree.Items.Add(view);
            }

            TreeViewItem tableTree2 = GetTreeViewItem("TRIGER");
            if (tableTree2 == null)
                return;

            foreach (Objects.Triger item in DatabaseSchema.Trigers)
            {
                TreeViewItem view = new TreeViewItem { Tag = item };
                CheckBox chk = new CheckBox { Content = item.Name };
                chk.Checked += (s, ex) => CheckUnCheckChild(view, ex);
                chk.Unchecked += (s, ex) => CheckUnCheckChild(view, ex);
                chk.IsChecked = true;
                view.Header = chk;

                tableTree2.Items.Add(view);
            }

            TreeViewItem procedureTree = GetTreeViewItem("PROCEDURE");
            if (procedureTree == null)
                return;

            foreach (Objects.Procedure item in DatabaseSchema.Procedures)
            {
                TreeViewItem view = new TreeViewItem { Tag = item };
                CheckBox chk = new CheckBox { Content = item.Name };
                chk.Checked += (s, ex) => CheckUnCheckChild(view, ex);
                chk.Unchecked += (s, ex) => CheckUnCheckChild(view, ex);
                chk.IsChecked = true;
                view.Header = chk;

                procedureTree.Items.Add(view);
            }

            TreeViewItem Packagetree = GetTreeViewItem("PACKAGE");
            if (Packagetree == null)
                return;

            foreach (Objects.Package item in DatabaseSchema.Packages)
            {
                TreeViewItem view = new TreeViewItem { Tag = item };
                CheckBox chk = new CheckBox { Content = item.Name };
                chk.Checked += (s, ex) => CheckUnCheckChild(view, ex);
                chk.Unchecked += (s, ex) => CheckUnCheckChild(view, ex);
                chk.IsChecked = true;
                view.Header = chk;

                Packagetree.Items.Add(view);
            }
        }
        private void PopulateSeqeucens()
        {
            TreeViewItem tableTree = GetTreeViewItem("SQE");
            if (tableTree == null)
                return;

            foreach (Objects.Sequence item in DatabaseSchema.Sequences)
            {
                TreeViewItem view = new TreeViewItem { Tag = item };
                CheckBox chk = new CheckBox { Content = item.Name };
                chk.Checked += (s, ex) => CheckUnCheckChild(view, ex);
                chk.Unchecked += (s, ex) => CheckUnCheckChild(view, ex);
                chk.IsChecked = true;
                view.Header = chk;

                tableTree.Items.Add(view);
            }
        }
        private void PopulateTrigers()
        {
            TreeViewItem tableTree = GetTreeViewItem("TRIGER");
            if (tableTree == null)
                return;

            foreach (Objects.Triger item in DatabaseSchema.Trigers)
            {
                TreeViewItem view = new TreeViewItem { Tag = item };
                CheckBox chk = new CheckBox { Content = item.Name };
                chk.Checked += (s, ex) => CheckUnCheckChild(view, ex);
                chk.Unchecked += (s, ex) => CheckUnCheckChild(view, ex);
                chk.IsChecked = true;
                view.Header = chk;

                tableTree.Items.Add(view);
            }
        }
        private void CheckUnCheckChild(TreeViewItem item, RoutedEventArgs e)
        {
            foreach (TreeViewItem child in item.Items)
            {
                if (child.Header.GetType().ToString() == "System.Windows.Controls.CheckBox")
                {
                    CheckBox chk = (CheckBox)child.Header;
                    chk.IsChecked = ((CheckBox)e.Source).IsChecked;
                }
            }
        }
        private void DumpSqlString(TreeViewItem rootNode)
        {
            foreach (TreeViewItem item in rootNode.Items)
            {
                if (item.Tag != null && item.Tag.GetType() == typeof(Objects.Table))
                {
                    if (item.Header != null && item.Header.GetType() == typeof(System.Windows.Controls.CheckBox))
                    {
                        CheckBox chk = (CheckBox)item.Header;
                        if (chk.IsChecked != null && chk.IsChecked.Value)
                        {
                            _sql += ((Objects.Table)item.Tag).GetAlterColumnsSql(false, true);
                        }
                        else
                        {
                            DumpSqlString(item);
                        }
                    }
                }
                else if (item.Tag != null && item.Tag.GetType() == typeof(Objects.TableColumn))
                {
                    CheckBox chk = (CheckBox)item.Header;
                    if (chk.IsChecked.Value)
                    {
                        _sql += ((Objects.TableColumn)item.Tag).GetAlterSql();
                    }
                }
                else if (item.Tag != null && item.Tag.GetType() == typeof(Objects.View))
                {
                    CheckBox chk = (CheckBox)item.Header;
                    if (chk.IsChecked.Value)
                    {
                        _sql += ((Objects.View) item.Tag).GetCreateSql();
                    }
                }
                else if (item.Tag != null && item.Tag.GetType() == typeof(Objects.Sequence))
                {
                    CheckBox chk = (CheckBox)item.Header;
                    if (chk.IsChecked.Value)
                    {
                        _sql += ((Objects.Sequence)item.Tag).GetCreateSql();
                    }
                }
                else if (item.Tag != null && item.Tag.GetType() == typeof(Objects.Triger))
                {
                    CheckBox chk = (CheckBox)item.Header;
                    if (chk.IsChecked.Value)
                    {
                        _sql += ((Objects.Triger)item.Tag).GetCreateSql();
                    }
                }
                else if (item.Tag != null && item.Tag.GetType() == typeof(Objects.Function))
                {
                    CheckBox chk = (CheckBox)item.Header;
                    if (chk.IsChecked.Value)
                    {
                        _sql += ((Objects.Function)item.Tag).GetCreateSql();
                    }
                }
                else
                {
                    DumpSqlString(item);
                }
            }
        }
        private void DumpSchemas(TreeViewItem rootNode)
        {
            foreach (TreeViewItem item in rootNode.Items)
            {
                CheckBox chk;
                if ((item.Tag != null) && (item.Tag.GetType() == typeof(Objects.Table)))
                {
                    if ((item.Header != null) && (item.Header.GetType() == typeof(CheckBox)))
                    {
                        chk = (CheckBox)item.Header;
                        if (chk.IsChecked.Value)
                        {
                            this._schemaDb.Tables.Add((Objects.Table)item.Tag);
                        }
                        else
                        {
                            this.DumpSchemas(item);
                        }
                    }
                }
                else if ((item.Tag != null) && (item.Tag.GetType() == typeof(Objects.TableColumn)))
                {
                    chk = (CheckBox)item.Header;
                    if (chk.IsChecked.Value)
                    {
                        Objects.TableColumn col = (Objects.TableColumn)item.Tag;
                        var result = this._schemaDb.Tables.Where(p => p.Name == col.Owner.Name).FirstOrDefault();
                        if (result != null)
                        {
                            result.Columns.Add(col);
                        }
                        else
                        {
                            Objects.Table tbl = new Objects.Table
                            {
                                Name = col.Owner.Name,
                                Tablespace = col.Owner.Tablespace,
                                KeyColumns = col.Owner.KeyColumns,
                                IsColumnsOnly = true
                            };
                            this._schemaDb.Tables.Add(tbl);
                        }
                    }
                }
                else if((item.Tag != null) && (item.Tag.GetType() == typeof(Objects.View)))
                {
                    if ((item.Header != null) && (item.Header.GetType() == typeof(CheckBox)))
                    {
                        chk = (CheckBox)item.Header;
                        if (chk.IsChecked.Value)
                        {
                            this._schemaDb.Views.Add((Objects.View)item.Tag);
                        }
                    }
                }
                else
                {
                    this.DumpSchemas(item);
                }
            }
        }
        private void SaveFile(string filePath)
        {
            this._sql = this._sql.TrimStart();
            FileStream fs = File.Create(filePath);
            var sw = new StreamWriter(fs);
            sw.Write(this._sql);
            sw.Close();
            fs.Close();
        }
        private TreeViewItem GetTreeViewItem(string tag)
        {
            TreeViewItem treeItem = null;

            foreach (var item in _rootNodeItem.Items)
            {
                TreeViewItem temp = (TreeViewItem)item;
                if (temp.Tag.ToString() == tag)
                {
                    treeItem = temp;
                }
            }

            return treeItem;
        }

        #endregion
    }
}
