namespace Rubik.DataTools.Controls
{
    partial class TableInformation
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
            this.tabTableinfo = new Crownwood.DotNetMagic.Controls.TabControl();
            this.tabGeneral = new Crownwood.DotNetMagic.Controls.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTableSpace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTableOwner = new System.Windows.Forms.TextBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabCols = new Crownwood.DotNetMagic.Controls.TabPage();
            this.datagridColumns = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nullable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Default = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tabIndexes = new Crownwood.DotNetMagic.Controls.TabPage();
            this.datagridIndex = new System.Windows.Forms.DataGridView();
            this.colIndxName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIndxColumns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIndxCompress = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIndxReverse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.tabKeys = new Crownwood.DotNetMagic.Controls.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.tabScripts = new Crownwood.DotNetMagic.Controls.TabPage();
            this.textEditorScript = new ICSharpCode.TextEditor.TextEditorControl();
            this.titleBar3 = new Crownwood.DotNetMagic.Controls.TitleBar();
            this.tabMaintance = new Crownwood.DotNetMagic.Controls.TabPage();
            this.tabTableinfo.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabCols.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridColumns)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabIndexes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridIndex)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabKeys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabScripts.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTableinfo
            // 
            this.tabTableinfo.AutoSize = true;
            this.tabTableinfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tabTableinfo.BoldSelectedPage = true;
            this.tabTableinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTableinfo.Location = new System.Drawing.Point(0, 0);
            this.tabTableinfo.Name = "tabTableinfo";
            this.tabTableinfo.OfficeDockSides = false;
            this.tabTableinfo.PositionTop = true;
            this.tabTableinfo.SelectedIndex = 0;
            this.tabTableinfo.ShowArrows = true;
            this.tabTableinfo.ShowClose = true;
            this.tabTableinfo.ShowDropSelect = false;
            this.tabTableinfo.Size = new System.Drawing.Size(847, 628);
            this.tabTableinfo.TabIndex = 1;
            this.tabTableinfo.TabPages.AddRange(new Crownwood.DotNetMagic.Controls.TabPage[] {
            this.tabGeneral,
            this.tabCols,
            this.tabIndexes,
            this.tabKeys,
            this.tabScripts,
            this.tabMaintance});
            this.tabTableinfo.TextTips = true;
            this.tabTableinfo.SelectionChanged += new Crownwood.DotNetMagic.Controls.SelectTabHandler(this.tabTableinfo_SelectionChanged);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.groupBox1);
            this.tabGeneral.InactiveBackColor = System.Drawing.Color.Empty;
            this.tabGeneral.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.tabGeneral.InactiveTextColor = System.Drawing.Color.Empty;
            this.tabGeneral.Location = new System.Drawing.Point(1, 24);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.SelectBackColor = System.Drawing.Color.Empty;
            this.tabGeneral.SelectTextBackColor = System.Drawing.Color.Empty;
            this.tabGeneral.SelectTextColor = System.Drawing.Color.Empty;
            this.tabGeneral.Size = new System.Drawing.Size(845, 603);
            this.tabGeneral.TabIndex = 1;
            this.tabGeneral.Title = "Genel Bilgiler";
            this.tabGeneral.ToolTip = "Page";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtTableSpace);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTableOwner);
            this.groupBox1.Controls.Add(this.txtTableName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(818, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Genel Bilgiler";
            // 
            // txtTableSpace
            // 
            this.txtTableSpace.Location = new System.Drawing.Point(346, 30);
            this.txtTableSpace.Name = "txtTableSpace";
            this.txtTableSpace.ReadOnly = true;
            this.txtTableSpace.Size = new System.Drawing.Size(147, 23);
            this.txtTableSpace.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tablespace : ";
            // 
            // txtTableOwner
            // 
            this.txtTableOwner.Location = new System.Drawing.Point(104, 59);
            this.txtTableOwner.Name = "txtTableOwner";
            this.txtTableOwner.ReadOnly = true;
            this.txtTableOwner.Size = new System.Drawing.Size(147, 23);
            this.txtTableOwner.TabIndex = 3;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(104, 30);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.ReadOnly = true;
            this.txtTableName.Size = new System.Drawing.Size(147, 23);
            this.txtTableName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Owner : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Table Name : ";
            // 
            // tabCols
            // 
            this.tabCols.Controls.Add(this.datagridColumns);
            this.tabCols.Controls.Add(this.panel1);
            this.tabCols.InactiveBackColor = System.Drawing.Color.Empty;
            this.tabCols.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.tabCols.InactiveTextColor = System.Drawing.Color.Empty;
            this.tabCols.Location = new System.Drawing.Point(1, 24);
            this.tabCols.Name = "tabCols";
            this.tabCols.SelectBackColor = System.Drawing.Color.Empty;
            this.tabCols.Selected = false;
            this.tabCols.SelectTextBackColor = System.Drawing.Color.Empty;
            this.tabCols.SelectTextColor = System.Drawing.Color.Empty;
            this.tabCols.Size = new System.Drawing.Size(845, 603);
            this.tabCols.TabIndex = 2;
            this.tabCols.Title = "Columns";
            this.tabCols.ToolTip = "Columns";
            // 
            // datagridColumns
            // 
            this.datagridColumns.AllowUserToAddRows = false;
            this.datagridColumns.AllowUserToDeleteRows = false;
            this.datagridColumns.AllowUserToOrderColumns = true;
            this.datagridColumns.AllowUserToResizeRows = false;
            this.datagridColumns.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.datagridColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.DataType,
            this.ValueLength,
            this.Nullable,
            this.Default,
            this.ColumnId});
            this.datagridColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridColumns.Location = new System.Drawing.Point(0, 0);
            this.datagridColumns.Name = "datagridColumns";
            this.datagridColumns.Size = new System.Drawing.Size(845, 568);
            this.datagridColumns.TabIndex = 1;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // DataType
            // 
            this.DataType.DataPropertyName = "DataType";
            this.DataType.HeaderText = "DataType";
            this.DataType.Name = "DataType";
            this.DataType.ReadOnly = true;
            // 
            // ValueLength
            // 
            this.ValueLength.DataPropertyName = "ValueLength";
            this.ValueLength.HeaderText = "ValueLength";
            this.ValueLength.Name = "ValueLength";
            this.ValueLength.ReadOnly = true;
            // 
            // Nullable
            // 
            this.Nullable.DataPropertyName = "Nullable";
            this.Nullable.FalseValue = "False";
            this.Nullable.HeaderText = "Nullable";
            this.Nullable.Name = "Nullable";
            this.Nullable.ReadOnly = true;
            this.Nullable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Nullable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Nullable.TrueValue = "True";
            // 
            // Default
            // 
            this.Default.DataPropertyName = "Default";
            this.Default.HeaderText = "Default";
            this.Default.Name = "Default";
            this.Default.ReadOnly = true;
            // 
            // ColumnId
            // 
            this.ColumnId.DataPropertyName = "ColumnId";
            this.ColumnId.HeaderText = "ColumnId";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 568);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 35);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(751, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Script";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabIndexes
            // 
            this.tabIndexes.Controls.Add(this.datagridIndex);
            this.tabIndexes.Controls.Add(this.panel2);
            this.tabIndexes.InactiveBackColor = System.Drawing.Color.Empty;
            this.tabIndexes.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.tabIndexes.InactiveTextColor = System.Drawing.Color.Empty;
            this.tabIndexes.Location = new System.Drawing.Point(1, 24);
            this.tabIndexes.Name = "tabIndexes";
            this.tabIndexes.SelectBackColor = System.Drawing.Color.Empty;
            this.tabIndexes.Selected = false;
            this.tabIndexes.SelectTextBackColor = System.Drawing.Color.Empty;
            this.tabIndexes.SelectTextColor = System.Drawing.Color.Empty;
            this.tabIndexes.Size = new System.Drawing.Size(845, 603);
            this.tabIndexes.TabIndex = 3;
            this.tabIndexes.Title = "Index";
            this.tabIndexes.ToolTip = "Index";
            // 
            // datagridIndex
            // 
            this.datagridIndex.AllowUserToAddRows = false;
            this.datagridIndex.AllowUserToDeleteRows = false;
            this.datagridIndex.AllowUserToOrderColumns = true;
            this.datagridIndex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridIndex.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndxName,
            this.colIndxColumns,
            this.colIndxCompress,
            this.colIndxReverse});
            this.datagridIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridIndex.Location = new System.Drawing.Point(0, 0);
            this.datagridIndex.Name = "datagridIndex";
            this.datagridIndex.ReadOnly = true;
            this.datagridIndex.Size = new System.Drawing.Size(845, 568);
            this.datagridIndex.TabIndex = 3;
            // 
            // colIndxName
            // 
            this.colIndxName.DataPropertyName = "Name";
            this.colIndxName.HeaderText = "Name";
            this.colIndxName.Name = "colIndxName";
            this.colIndxName.ReadOnly = true;
            // 
            // colIndxColumns
            // 
            this.colIndxColumns.DataPropertyName = "ColumnsString";
            this.colIndxColumns.HeaderText = "Columns";
            this.colIndxColumns.Name = "colIndxColumns";
            this.colIndxColumns.ReadOnly = true;
            // 
            // colIndxCompress
            // 
            this.colIndxCompress.DataPropertyName = "Compress";
            this.colIndxCompress.FalseValue = "False";
            this.colIndxCompress.HeaderText = "Compress";
            this.colIndxCompress.Name = "colIndxCompress";
            this.colIndxCompress.ReadOnly = true;
            this.colIndxCompress.TrueValue = "True";
            // 
            // colIndxReverse
            // 
            this.colIndxReverse.DataPropertyName = "Reverse";
            this.colIndxReverse.FalseValue = "False";
            this.colIndxReverse.HeaderText = "Reverse";
            this.colIndxReverse.Name = "colIndxReverse";
            this.colIndxReverse.ReadOnly = true;
            this.colIndxReverse.TrueValue = "True";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 568);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(845, 35);
            this.panel2.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(751, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Script";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tabKeys
            // 
            this.tabKeys.Controls.Add(this.dataGridView3);
            this.tabKeys.Controls.Add(this.panel3);
            this.tabKeys.InactiveBackColor = System.Drawing.Color.Empty;
            this.tabKeys.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.tabKeys.InactiveTextColor = System.Drawing.Color.Empty;
            this.tabKeys.Location = new System.Drawing.Point(1, 24);
            this.tabKeys.Name = "tabKeys";
            this.tabKeys.SelectBackColor = System.Drawing.Color.Empty;
            this.tabKeys.Selected = false;
            this.tabKeys.SelectTextBackColor = System.Drawing.Color.Empty;
            this.tabKeys.SelectTextColor = System.Drawing.Color.Empty;
            this.tabKeys.Size = new System.Drawing.Size(845, 603);
            this.tabKeys.TabIndex = 4;
            this.tabKeys.Title = "Keys";
            this.tabKeys.ToolTip = "Keys";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(845, 568);
            this.dataGridView3.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 568);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(845, 35);
            this.panel3.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(751, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Script";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // tabScripts
            // 
            this.tabScripts.Controls.Add(this.textEditorScript);
            this.tabScripts.Controls.Add(this.titleBar3);
            this.tabScripts.InactiveBackColor = System.Drawing.Color.Empty;
            this.tabScripts.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.tabScripts.InactiveTextColor = System.Drawing.Color.Empty;
            this.tabScripts.Location = new System.Drawing.Point(1, 24);
            this.tabScripts.Name = "tabScripts";
            this.tabScripts.SelectBackColor = System.Drawing.Color.Empty;
            this.tabScripts.Selected = false;
            this.tabScripts.SelectTextBackColor = System.Drawing.Color.Empty;
            this.tabScripts.SelectTextColor = System.Drawing.Color.Empty;
            this.tabScripts.Size = new System.Drawing.Size(845, 603);
            this.tabScripts.TabIndex = 6;
            this.tabScripts.Title = "Script";
            this.tabScripts.ToolTip = "Script";
            // 
            // textEditorScript
            // 
            this.textEditorScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorScript.IsReadOnly = false;
            this.textEditorScript.Location = new System.Drawing.Point(0, 23);
            this.textEditorScript.Name = "textEditorScript";
            this.textEditorScript.Size = new System.Drawing.Size(845, 580);
            this.textEditorScript.TabIndex = 7;
            // 
            // titleBar3
            // 
            this.titleBar3.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar3.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
            this.titleBar3.Location = new System.Drawing.Point(0, 0);
            this.titleBar3.MouseOverColor = System.Drawing.Color.Empty;
            this.titleBar3.Name = "titleBar3";
            this.titleBar3.Size = new System.Drawing.Size(845, 23);
            this.titleBar3.TabIndex = 6;
            this.titleBar3.Text = "Sql Script";
            // 
            // tabMaintance
            // 
            this.tabMaintance.InactiveBackColor = System.Drawing.Color.Empty;
            this.tabMaintance.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.tabMaintance.InactiveTextColor = System.Drawing.Color.Empty;
            this.tabMaintance.Location = new System.Drawing.Point(1, 24);
            this.tabMaintance.Name = "tabMaintance";
            this.tabMaintance.SelectBackColor = System.Drawing.Color.Empty;
            this.tabMaintance.Selected = false;
            this.tabMaintance.SelectTextBackColor = System.Drawing.Color.Empty;
            this.tabMaintance.SelectTextColor = System.Drawing.Color.Empty;
            this.tabMaintance.Size = new System.Drawing.Size(845, 603);
            this.tabMaintance.TabIndex = 5;
            this.tabMaintance.Title = "Maintance";
            this.tabMaintance.ToolTip = "Maintance";
            // 
            // TableInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabTableinfo);
            this.Size = new System.Drawing.Size(847, 628);
            this.tabTableinfo.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabCols.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridColumns)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabIndexes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridIndex)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabKeys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabScripts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Crownwood.DotNetMagic.Controls.TabControl tabTableinfo;
        private Crownwood.DotNetMagic.Controls.TabPage tabGeneral;
        private Crownwood.DotNetMagic.Controls.TabPage tabIndexes;
        private Crownwood.DotNetMagic.Controls.TabPage tabKeys;
        private Crownwood.DotNetMagic.Controls.TabPage tabCols;
        private Crownwood.DotNetMagic.Controls.TabPage tabMaintance;
        private System.Windows.Forms.DataGridView datagridColumns;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView datagridIndex;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTableSpace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTableOwner;
        private System.Windows.Forms.TextBox txtTableName;
        private Crownwood.DotNetMagic.Controls.TabPage tabScripts;
        private ICSharpCode.TextEditor.TextEditorControl textEditorScript;
        private Crownwood.DotNetMagic.Controls.TitleBar titleBar3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueLength;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Nullable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Default;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndxName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndxColumns;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIndxCompress;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIndxReverse;
    }
}
