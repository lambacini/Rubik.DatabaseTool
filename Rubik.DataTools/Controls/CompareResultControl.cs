using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rubik.DataTools.Fluent;
using Rubik.DataTools.Interface;
using Rubik.DataTools.Objects;

namespace Rubik.DataTools.Controls
{
    public partial class CompareResultControl : UserControl
    {
        public DatabaseFactory SourceDatabase { get; set; }
        public DatabaseFactory DestinationDatabase { get; set; }

        private DatabaseFactory _differenceSchema;
        private DatabaseFactory _differenceDatabase;

        public CompareResultControl()
        {
            InitializeComponent();

            scriptControl.SetHighlighting("SQL");
            scriptControl.IsReadOnly = true;
        }

        public void Compare()
        {
            _differenceSchema = DatabaseComparer.CompareDatabase(SourceDatabase, DestinationDatabase);
            _differenceDatabase = DatabaseComparer.CompareDatabase(DestinationDatabase, SourceDatabase);

            FillSchema(treeSchema, SourceDatabase);
            FillSchema(treeSchema_diff2, _differenceSchema);
            FillSchema(treeSchema_diff1, _differenceDatabase);
        }

        private void FillSchema(TreeView treeView,DatabaseFactory db)
        {
            treeView.Nodes.Clear();
            treeView.SuspendLayout();


            TreeNode rootNode = new TreeNode(db.Name + " " + db.DatabaseVersion);
            rootNode.ImageIndex = 0;
            rootNode.Checked = db.IsSelected;
            treeView.Nodes.Add(rootNode);
            foreach (var user in db.Users)
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

            treeView.ResumeLayout();
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
            }
        }

        private void treeSchema_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag is IDatabaseObject)
            {
                if (((IDatabaseObject)e.Node.Tag).ObjectType == Enums.ObjectTypeEnum.TABLE)
                {
                    var table = ((Table)e.Node.Tag);
                    
                    List<Column> dbObjects = new List<Column>();
                    foreach (var item in table.Columns)
                    {
                        dbObjects.Add((Column)item);
                    }

                    scriptControl.Text = table.GetAlterColumnsSql(false, true);

                }
                else
                {
                    var dbObject = ((DatabaseObject)e.Node.Tag);
                    
                    StringBuilder builder = new StringBuilder();

               
                    builder.AppendLine(dbObject.GetSqlString());
                    scriptControl.SuspendLayout();
                    scriptControl.Text = builder.ToString();
                    scriptControl.ResumeLayout();

                }

                scriptControl.Refresh();
            }
        }

    }
}
