namespace Rubik.DataTools.Controls
{
    partial class ScriptControl
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
            this.textEditorControl1 = new ICSharpCode.TextEditor.TextEditorControl();
            this.titleBar3 = new Crownwood.DotNetMagic.Controls.TitleBar();
            this.SuspendLayout();
            // 
            // textEditorControl1
            // 
            this.textEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControl1.IsReadOnly = false;
            this.textEditorControl1.Location = new System.Drawing.Point(0, 23);
            this.textEditorControl1.Name = "textEditorControl1";
            this.textEditorControl1.Size = new System.Drawing.Size(658, 439);
            this.textEditorControl1.TabIndex = 5;
            // 
            // titleBar3
            // 
            this.titleBar3.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar3.GradientColoring = Crownwood.DotNetMagic.Controls.GradientColoring.LightBackToDarkBack;
            this.titleBar3.Location = new System.Drawing.Point(0, 0);
            this.titleBar3.MouseOverColor = System.Drawing.Color.Empty;
            this.titleBar3.Name = "titleBar3";
            this.titleBar3.Size = new System.Drawing.Size(658, 23);
            this.titleBar3.TabIndex = 4;
            this.titleBar3.Text = "Sql Script";
            // 
            // ScriptControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textEditorControl1);
            this.Controls.Add(this.titleBar3);
            this.Name = "ScriptControl";
            this.Size = new System.Drawing.Size(658, 462);
            this.ResumeLayout(false);

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl textEditorControl1;
        private Crownwood.DotNetMagic.Controls.TitleBar titleBar3;
    }
}
