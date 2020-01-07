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
    public partial class ScriptControl : UserControl
    {
        public DatabaseObject DbObject { get; set; }
        public ScriptControl()
        {
            InitializeComponent();

            HighlightingManager.Manager.AddSyntaxModeFileProvider(new SyntaxModeProvider());
            textEditorControl1.SetHighlighting("SQL");
            textEditorControl1.IsReadOnly = true;
        }

        public void Build()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(DbObject.GetSqlString());

            textEditorControl1.SuspendLayout();
            textEditorControl1.Text = builder.ToString();
            textEditorControl1.ResumeLayout();
        }
    }
}
