using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rubik.Database.Controls
{
    public partial class DatabaseTreeList : UserControl
    {
        #region Variables

        private Objects.Database _dataSource;        

        #endregion
        public DatabaseTreeList()
        {
            InitializeComponent();
        }

        public Objects.Database DataSource
        {
            get { return _dataSource; }
            set
            {
                if(value != null && value != _dataSource)
                {
                    _dataSource = value;
                }
            }
        }
        public Objects.Database LastState
        {
            get { return GetLastState(); }
        }

        #region LastState
        private Objects.Database GetLastState()
        {
            Objects.Database db = new Objects.Database();
            TreeNode tableNode = treeView1.Nodes[0].Nodes["Tables"];

            foreach(TreeNode item in tableNode.Nodes)
            {
                if(item.Checked)
                {
                    
                }
            }
            return  new Objects.Database();
        }
        #endregion
        #region Build Tree
        public void BuildTreeList()
        {
            treeView1.BeginUpdate();

            BuildRootNode();
            BuildTablesNode();
            BuildFunctionsNode();
            BuildPackageNode();
            BuildProceduresNode();
            BuildSequencesNode();
            BuildTriggerNode();
            BuildViewsNode();

            treeView1.EndUpdate();
        }
        private void BuildRootNode()
        {
            treeView1.Nodes.Clear();
            TreeNode rootNode = new TreeNode();
            rootNode.Text = DataSource.Name + "-" + DataSource.DatabaseVersion;
            
            TreeNode child = new TreeNode();
            child.Name = "Tables";
            child.Text = "Tables";
            child.Checked = true;

            rootNode.Nodes.Add(child);

            child = new TreeNode();
            child.Name = "Views";
            child.Text = "Views";
            child.Checked = true;

            rootNode.Nodes.Add(child);

            child = new TreeNode();
            child.Name = "Procedures";
            child.Text = "Procedures";
            child.Checked = true;

            rootNode.Nodes.Add(child);

            child = new TreeNode();
            child.Name = "Functions";
            child.Text = "Functions";
            child.Checked = true;

            rootNode.Nodes.Add(child);

            child = new TreeNode();
            child.Name = "Sequences";
            child.Text = "Sequences";
            child.Checked = true;

            rootNode.Nodes.Add(child);

            child = new TreeNode();
            child.Name = "Trigers";
            child.Text = "Trigers";
            child.Checked = true;

            rootNode.Nodes.Add(child);

            child = new TreeNode();
            child.Name = "Package";
            child.Text = "Package";
            child.Checked = true;

            rootNode.Nodes.Add(child);

            treeView1.Nodes.Add(rootNode);
        }
        private void BuildTablesNode()
        {
            TreeNode node = treeView1.Nodes[0].Nodes["Tables"];
            
            foreach(var item in DataSource.Tables)
            {
                TreeNode child = new TreeNode(item.Name);
                child.Checked = true;
                child.Tag = item;
                node.Nodes.Add(child);

                if (item.KeyColumns.Count > 0)
                {
                    TreeNode keyItem = new TreeNode("Keys");
                    keyItem.Checked = true;
                    child.Nodes.Add(keyItem);

                    foreach (var key in item.KeyColumns)
                    {
                        TreeNode keyNode = new TreeNode(key.Name);
                        keyNode.Checked = true;
                        keyNode.Tag = key;
                        keyItem.Nodes.Add(keyNode);
                    }
                }

                foreach (var col in item.Columns)
                {
                    TreeNode colNode = new TreeNode(col.Name);
                    colNode.Checked = true;
                    colNode.Tag = col;
                    child.Nodes.Add(colNode);
                }
            }
        }
        private void BuildViewsNode()
        {
            TreeNode node = treeView1.Nodes[0].Nodes["Views"];

            foreach (var item in DataSource.Views)
            {
                TreeNode child = new TreeNode(item.Name);
                child.Checked = true;
                child.Tag = item;
                node.Nodes.Add(child);
            }
        }
        private void BuildFunctionsNode()
        {
            TreeNode node = treeView1.Nodes[0].Nodes.Find("Functions", true).FirstOrDefault();

            foreach (var item in DataSource.Functions)
            {
                TreeNode child = new TreeNode(item.Name);
                child.Checked = true;
                child.Tag = item;
                node.Nodes.Add(child);
            }
        }
        private void BuildSequencesNode()
        {
            TreeNode node = treeView1.Nodes[0].Nodes.Find("Sequences", true).FirstOrDefault();

            foreach (var item in DataSource.Sequences)
            {
                TreeNode child = new TreeNode(item.Name);
                child.Checked = true;
                child.Tag = item;
                node.Nodes.Add(child);
            }
        }
        private void BuildTriggerNode()
        {
            TreeNode node = treeView1.Nodes[0].Nodes.Find("Trigers", true).FirstOrDefault();

            foreach (var item in DataSource.Trigers)
            {
                TreeNode child = new TreeNode(item.Name);
                child.Checked = true;
                child.Tag = item;
                node.Nodes.Add(child);
            }
        }
        private void BuildPackageNode()
        {
            TreeNode node = treeView1.Nodes[0].Nodes["Package"];

            foreach (var item in DataSource.Packages)
            {
                TreeNode child = new TreeNode(item.Name);
                child.Checked = true;
                child.Tag = item;
                node.Nodes.Add(child);
            }
        }
        private void BuildProceduresNode()
        {
            TreeNode node = treeView1.Nodes[0].Nodes["Procedures"];

            foreach (var item in DataSource.Procedures)
            {
                TreeNode child = new TreeNode(item.Name);
                child.Checked = true;
                child.Tag = item;
                node.Nodes.Add(child);
            }
        }

        private void UnCheckAall(TreeNode node)
        {
            node.Checked = false;
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = false;

                if(child.Nodes.Count > 0)
                    UnCheckAall(child);
            }
        }
        private void CheckAall(TreeNode node)
        {
            node.Checked = true;
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = true;

                if (child.Nodes.Count > 0)
                    UnCheckAall(child);
            }
        }
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
            {
                if (e.Node != null)
                {
                    treeView1.BeginUpdate();

                    TreeNode node = e.Node;
                    if (node.Checked)
                    {
                        CheckAall(node);
                    }
                    else
                    {                        
                        UnCheckAall(node);
                    }
                    treeView1.EndUpdate();
                }
            }
        }
        #endregion
    }
}
