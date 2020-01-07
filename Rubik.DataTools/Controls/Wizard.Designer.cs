namespace Rubik.DataTools.Controls
{
    partial class Wizard
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
            this.components = new System.ComponentModel.Container();
            this.wizardControl1 = new Crownwood.DotNetMagic.Controls.WizardControl();
            this.pageDbConnection = new Crownwood.DotNetMagic.Controls.WizardPage();
            this.pnlDbConfiguration = new System.Windows.Forms.Panel();
            this.lblSonuc = new System.Windows.Forms.Label();
            this.cmbCnnType = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.cmbTns = new System.Windows.Forms.ComboBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pageParameters = new Crownwood.DotNetMagic.Controls.WizardPage();
            this.pnlCompareSettings = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAddAlterUser = new System.Windows.Forms.CheckBox();
            this.chkSeperateSchemas = new System.Windows.Forms.CheckBox();
            this.chkDropObject = new System.Windows.Forms.CheckBox();
            this.chkCreateUser = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSystemGroup = new System.Windows.Forms.CheckBox();
            this.chkAllUsers = new System.Windows.Forms.CheckBox();
            this.userCheckList = new System.Windows.Forms.CheckedListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlDbConfiguration.SuspendLayout();
            this.pnlCompareSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.ButtonBackText = "< Geri";
            this.wizardControl1.ButtonCancelText = "Vazgeç";
            this.wizardControl1.ButtonCloseText = "Kapat";
            this.wizardControl1.ButtonFinishText = "Bitir";
            this.wizardControl1.ButtonHelpText = "Yardım";
            this.wizardControl1.ButtonNextText = "İleri >";
            this.wizardControl1.ButtonUpdateText = "Güncelle";
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.wizardControl1.HeaderPanel.BackColor = System.Drawing.SystemColors.Window;
            this.wizardControl1.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.wizardControl1.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.HeaderPanel.Name = "_panelTop";
            this.wizardControl1.HeaderPanel.Size = new System.Drawing.Size(533, 72);
            this.wizardControl1.HeaderPanel.TabIndex = 1;
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Profile = Crownwood.DotNetMagic.Controls.Profiles.Install;
            this.wizardControl1.SelectedIndex = 0;
            this.wizardControl1.ShowCancelButton = Crownwood.DotNetMagic.Controls.Status.Yes;
            this.wizardControl1.ShowCloseButton = Crownwood.DotNetMagic.Controls.Status.No;
            this.wizardControl1.ShowNextButton = Crownwood.DotNetMagic.Controls.Status.Yes;
            this.wizardControl1.Size = new System.Drawing.Size(533, 386);
            this.wizardControl1.Style = Crownwood.DotNetMagic.Common.VisualStyle.Office2003;
            this.wizardControl1.TabIndex = 0;
            this.wizardControl1.Title = "Ayarlar & Seçenekler";
            // 
            // 
            // 
            this.wizardControl1.TrailerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.wizardControl1.TrailerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.wizardControl1.TrailerPanel.Location = new System.Drawing.Point(0, 338);
            this.wizardControl1.TrailerPanel.Name = "_panelBottom";
            this.wizardControl1.TrailerPanel.Size = new System.Drawing.Size(533, 48);
            this.wizardControl1.TrailerPanel.TabIndex = 2;
            this.wizardControl1.WizardPages.AddRange(new Crownwood.DotNetMagic.Controls.WizardPage[] {
            this.pageDbConnection,
            this.pageParameters});
            this.wizardControl1.WizardPageEnter += new Crownwood.DotNetMagic.Controls.WizardControl.WizardPageHandler(this.wizardControl1_WizardPageEnter);
            this.wizardControl1.CancelClick += new System.EventHandler(this.wizardControl1_CancelClick);
            this.wizardControl1.FinishClick += new System.EventHandler(this.wizardControl1_FinishClick);
            this.wizardControl1.TabIndexChanged += new System.EventHandler(this.wizardControl1_TabIndexChanged);
            // 
            // pageDbConnection
            // 
            this.pageDbConnection.CaptionTitle = "(Page Title)";
            this.pageDbConnection.Control = this.pnlDbConfiguration;
            this.pageDbConnection.FullPage = false;
            this.pageDbConnection.InactiveBackColor = System.Drawing.Color.Empty;
            this.pageDbConnection.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.pageDbConnection.InactiveTextColor = System.Drawing.Color.Empty;
            this.pageDbConnection.Location = new System.Drawing.Point(0, 0);
            this.pageDbConnection.Name = "pageDbConnection";
            this.pageDbConnection.SelectBackColor = System.Drawing.Color.Empty;
            this.pageDbConnection.SelectTextBackColor = System.Drawing.Color.Empty;
            this.pageDbConnection.SelectTextColor = System.Drawing.Color.Empty;
            this.pageDbConnection.Size = new System.Drawing.Size(679, 313);
            this.pageDbConnection.SubTitle = "Veritabanı Bağlantı Parametreleri";
            this.pageDbConnection.TabIndex = 4;
            this.pageDbConnection.ToolTip = "Page";
            // 
            // pnlDbConfiguration
            // 
            this.pnlDbConfiguration.Controls.Add(this.lblSonuc);
            this.pnlDbConfiguration.Controls.Add(this.cmbCnnType);
            this.pnlDbConfiguration.Controls.Add(this.txtPassword);
            this.pnlDbConfiguration.Controls.Add(this.label4);
            this.pnlDbConfiguration.Controls.Add(this.label3);
            this.pnlDbConfiguration.Controls.Add(this.label2);
            this.pnlDbConfiguration.Controls.Add(this.btnTestConnection);
            this.pnlDbConfiguration.Controls.Add(this.cmbTns);
            this.pnlDbConfiguration.Controls.Add(this.txtUsername);
            this.pnlDbConfiguration.Controls.Add(this.label1);
            this.pnlDbConfiguration.Location = new System.Drawing.Point(0, 0);
            this.pnlDbConfiguration.Name = "pnlDbConfiguration";
            this.pnlDbConfiguration.Size = new System.Drawing.Size(533, 266);
            this.pnlDbConfiguration.TabIndex = 0;
            // 
            // lblSonuc
            // 
            this.lblSonuc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSonuc.Location = new System.Drawing.Point(0, 219);
            this.lblSonuc.Name = "lblSonuc";
            this.lblSonuc.Size = new System.Drawing.Size(533, 47);
            this.lblSonuc.TabIndex = 9;
            // 
            // cmbCnnType
            // 
            this.cmbCnnType.Enabled = false;
            this.cmbCnnType.FormattingEnabled = true;
            this.cmbCnnType.Items.AddRange(new object[] {
            "Normal",
            "SysDba",
            "SysOper"});
            this.cmbCnnType.Location = new System.Drawing.Point(234, 136);
            this.cmbCnnType.Name = "cmbCnnType";
            this.cmbCnnType.Size = new System.Drawing.Size(151, 23);
            this.cmbCnnType.TabIndex = 8;
            this.cmbCnnType.Text = "Normal";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(234, 82);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(151, 23);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.Text = "8079521";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Bağlantı Türü : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "TNS : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Şifre : ";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(310, 165);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(75, 23);
            this.btnTestConnection.TabIndex = 3;
            this.btnTestConnection.Text = "Bağlan";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // cmbTns
            // 
            this.cmbTns.FormattingEnabled = true;
            this.cmbTns.Location = new System.Drawing.Point(234, 109);
            this.cmbTns.Name = "cmbTns";
            this.cmbTns.Size = new System.Drawing.Size(151, 23);
            this.cmbTns.TabIndex = 2;
            this.cmbTns.Text = "FONET";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(234, 56);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(151, 23);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "FONETPACS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Adı  : ";
            // 
            // pageParameters
            // 
            this.pageParameters.CaptionTitle = "(Page Title)";
            this.pageParameters.Control = this.pnlCompareSettings;
            this.pageParameters.FullPage = false;
            this.pageParameters.InactiveBackColor = System.Drawing.Color.Empty;
            this.pageParameters.InactiveTextBackColor = System.Drawing.Color.Empty;
            this.pageParameters.InactiveTextColor = System.Drawing.Color.Empty;
            this.pageParameters.Location = new System.Drawing.Point(0, 0);
            this.pageParameters.Name = "pageParameters";
            this.pageParameters.SelectBackColor = System.Drawing.Color.Empty;
            this.pageParameters.Selected = false;
            this.pageParameters.SelectTextBackColor = System.Drawing.Color.Empty;
            this.pageParameters.SelectTextColor = System.Drawing.Color.Empty;
            this.pageParameters.Size = new System.Drawing.Size(533, 259);
            this.pageParameters.SubTitle = "Karşılaştırma Parametreleri";
            this.pageParameters.TabIndex = 5;
            this.pageParameters.ToolTip = "Page";
            // 
            // pnlCompareSettings
            // 
            this.pnlCompareSettings.Controls.Add(this.groupBox2);
            this.pnlCompareSettings.Controls.Add(this.groupBox1);
            this.pnlCompareSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlCompareSettings.Name = "pnlCompareSettings";
            this.pnlCompareSettings.Size = new System.Drawing.Size(533, 266);
            this.pnlCompareSettings.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAddAlterUser);
            this.groupBox2.Controls.Add(this.chkSeperateSchemas);
            this.groupBox2.Controls.Add(this.chkDropObject);
            this.groupBox2.Controls.Add(this.chkCreateUser);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(254, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 266);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sql Script Parametreleri";
            // 
            // chkAddAlterUser
            // 
            this.chkAddAlterUser.AutoSize = true;
            this.chkAddAlterUser.Checked = true;
            this.chkAddAlterUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddAlterUser.Location = new System.Drawing.Point(23, 112);
            this.chkAddAlterUser.Name = "chkAddAlterUser";
            this.chkAddAlterUser.Size = new System.Drawing.Size(233, 19);
            this.chkAddAlterUser.TabIndex = 3;
            this.chkAddAlterUser.Text = "Şema kendi kullanıcısı için oluşturulsun";
            this.toolTip1.SetToolTip(this.chkAddAlterUser, "Sql Scriptin başına her kullanıcı için \"ALTER SESSION SET CURRENT_SCHEMA=USER\" ek" +
        "ler.");
            this.chkAddAlterUser.UseVisualStyleBackColor = true;
            // 
            // chkSeperateSchemas
            // 
            this.chkSeperateSchemas.AutoSize = true;
            this.chkSeperateSchemas.Checked = true;
            this.chkSeperateSchemas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSeperateSchemas.Location = new System.Drawing.Point(23, 87);
            this.chkSeperateSchemas.Name = "chkSeperateSchemas";
            this.chkSeperateSchemas.Size = new System.Drawing.Size(194, 19);
            this.chkSeperateSchemas.TabIndex = 2;
            this.chkSeperateSchemas.Text = "Her şema için ayrı dosya oluştur";
            this.chkSeperateSchemas.UseVisualStyleBackColor = true;
            // 
            // chkDropObject
            // 
            this.chkDropObject.AutoSize = true;
            this.chkDropObject.Location = new System.Drawing.Point(23, 62);
            this.chkDropObject.Name = "chkDropObject";
            this.chkDropObject.Size = new System.Drawing.Size(153, 19);
            this.chkDropObject.TabIndex = 1;
            this.chkDropObject.Text = "Önceki Nesneleri Dropla";
            this.chkDropObject.UseVisualStyleBackColor = true;
            // 
            // chkCreateUser
            // 
            this.chkCreateUser.AutoSize = true;
            this.chkCreateUser.Checked = true;
            this.chkCreateUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreateUser.Location = new System.Drawing.Point(23, 37);
            this.chkCreateUser.Name = "chkCreateUser";
            this.chkCreateUser.Size = new System.Drawing.Size(122, 19);
            this.chkCreateUser.TabIndex = 0;
            this.chkCreateUser.Text = "Kullanıcıyı Oluştur";
            this.chkCreateUser.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSystemGroup);
            this.groupBox1.Controls.Add(this.chkAllUsers);
            this.groupBox1.Controls.Add(this.userCheckList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 266);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kullanıcılar";
            // 
            // chkSystemGroup
            // 
            this.chkSystemGroup.AutoSize = true;
            this.chkSystemGroup.Location = new System.Drawing.Point(136, 22);
            this.chkSystemGroup.Name = "chkSystemGroup";
            this.chkSystemGroup.Size = new System.Drawing.Size(96, 19);
            this.chkSystemGroup.TabIndex = 2;
            this.chkSystemGroup.Text = "System Grup ";
            this.chkSystemGroup.UseVisualStyleBackColor = true;
            this.chkSystemGroup.CheckedChanged += new System.EventHandler(this.chkSystemGroup_CheckedChanged);
            // 
            // chkAllUsers
            // 
            this.chkAllUsers.AutoSize = true;
            this.chkAllUsers.Location = new System.Drawing.Point(6, 22);
            this.chkAllUsers.Name = "chkAllUsers";
            this.chkAllUsers.Size = new System.Drawing.Size(124, 19);
            this.chkAllUsers.TabIndex = 1;
            this.chkAllUsers.Text = "Tüm Kullanıcılkkar";
            this.chkAllUsers.UseVisualStyleBackColor = true;
            this.chkAllUsers.CheckedChanged += new System.EventHandler(this.chkOnlyActive_CheckedChanged);
            // 
            // userCheckList
            // 
            this.userCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userCheckList.FormattingEnabled = true;
            this.userCheckList.Location = new System.Drawing.Point(3, 54);
            this.userCheckList.Name = "userCheckList";
            this.userCheckList.Size = new System.Drawing.Size(245, 202);
            this.userCheckList.TabIndex = 0;
            this.userCheckList.SelectedValueChanged += new System.EventHandler(this.userCheckList_SelectedValueChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Bilgi !";
            // 
            // Wizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 386);
            this.Controls.Add(this.wizardControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Wizard";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ayarlar & Seçenekler";
            this.pnlDbConfiguration.ResumeLayout(false);
            this.pnlDbConfiguration.PerformLayout();
            this.pnlCompareSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Crownwood.DotNetMagic.Controls.WizardControl wizardControl1;
        private Crownwood.DotNetMagic.Controls.WizardPage pageDbConnection;
        private Crownwood.DotNetMagic.Controls.WizardPage pageParameters;
        private System.Windows.Forms.Panel pnlDbConfiguration;
        private System.Windows.Forms.ComboBox cmbCnnType;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.ComboBox cmbTns;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSonuc;
        private System.Windows.Forms.Panel pnlCompareSettings;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAddAlterUser;
        private System.Windows.Forms.CheckBox chkSeperateSchemas;
        private System.Windows.Forms.CheckBox chkDropObject;
        private System.Windows.Forms.CheckBox chkCreateUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox userCheckList;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkSystemGroup;
        private System.Windows.Forms.CheckBox chkAllUsers;
    }
}