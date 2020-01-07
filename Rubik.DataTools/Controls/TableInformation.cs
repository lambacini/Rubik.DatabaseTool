using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rubik.DataTools.Objects;
using ICSharpCode.TextEditor.Document;

namespace Rubik.DataTools.Controls
{
    public partial class TableInformation : UserControl
    {
        public Table SelectedTable { get; set; } = new Table();
        public TableInformation()
        {
            InitializeComponent();

            HighlightingManager.Manager.AddSyntaxModeFileProvider(new SyntaxModeProvider());
            textEditorScript.SetHighlighting("SQL");
            textEditorScript.IsReadOnly = true;
        }

        
        public void Build()
        {
            var temp = this.SelectedTable.Name;
            txtTableName.Text = this.SelectedTable.Name;
            txtTableOwner.Text = this.SelectedTable.Owner.Name;
            txtTableSpace.Text = this.SelectedTable.TableSpace;

            this._bindColumns();
            this._bindIndexes();
            this._bindKeys();
            this._bindScript();
        }

        private void _bindColumns()
        {
            datagridColumns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datagridColumns.AutoGenerateColumns = false;
            datagridColumns.SuspendLayout();
            datagridColumns.DataSource = null;

            List<Column> dbObjects = new List<Column>();
            foreach (var item in SelectedTable.Columns)
            {
                dbObjects.Add((Column)item);
            }

            datagridColumns.DataSource = dbObjects;
            datagridColumns.Refresh();
            datagridColumns.ResumeLayout();
            
        }

        private void _bindIndexes()
        {
            if (SelectedTable.Indexes == null)
            {
                return;
            }

            datagridIndex.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datagridIndex.AutoGenerateColumns = false;

            datagridIndex.SuspendLayout();
            datagridIndex.DataSource = null;

            List<Index> dbObjects = new List<Index>();
            foreach (var item in SelectedTable.Indexes)
            {
                dbObjects.Add((Index)item);
            }

            datagridIndex.DataSource = dbObjects;
            datagridIndex.Refresh();
            datagridIndex.ResumeLayout();
        }

        private void _bindKeys()
        {
            if (SelectedTable.Keys == null)
            {
                return;
            }


            dataGridView3.SuspendLayout();
            dataGridView3.DataSource = null;
            dataGridView3.AutoGenerateColumns = true;

            List<Key> dbObjects = new List<Key>();
            foreach (var item in SelectedTable.Keys)
            {
                dbObjects.Add((Key)item);
            }

            dataGridView3.DataSource = dbObjects;
            dataGridView3.Refresh();
            dataGridView3.ResumeLayout();
        }

        private void _bindScript()
        {
            StringBuilder builder = new StringBuilder();
            
          
            builder.AppendLine(SelectedTable.GetAlterColumnsSql(false, true));

            textEditorScript.SuspendLayout();
            textEditorScript.Text = builder.ToString();
            textEditorScript.ResumeLayout();
        }

        private void tabTableinfo_SelectionChanged(Crownwood.DotNetMagic.Controls.TabControl sender, Crownwood.DotNetMagic.Controls.TabPage oldPage, Crownwood.DotNetMagic.Controls.TabPage newPage)
        {

        }
    }
}
