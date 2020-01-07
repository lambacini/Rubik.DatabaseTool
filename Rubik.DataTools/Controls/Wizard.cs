using Devart.Data.Oracle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rubik.DataTools.Controls
{
    public partial class Wizard : Form
    {
        public DatabaseParameters Parameters = new DatabaseParameters();

        public Wizard()
        {
            InitializeComponent();
            this.Load += Wizard_Load;
        }

        void Wizard_Load(object sender, EventArgs e)
        {
            wizardControl1.NextButton.Enabled = false;
            cmbTns.Items.AddRange(OracleConnection.GetServerList());
        }

        private void wizardControl1_CancelClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ayarlar tamamlanmadı ! Çıkmak istediğinize eminmisiniz ? ", "Sor",
                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            }
        }

        private void wizardControl1_FinishClick(object sender, EventArgs e)
        {
            Parameters.SelectedUsers.AddRange(userCheckList.CheckedItems.Cast<string>());
            Parameters.AutoChangeSchema = chkAddAlterUser.Checked;
            Parameters.SeparateSchemas = chkSeperateSchemas.Checked;
            Parameters.CreateUser = chkCreateUser.Checked;
            Parameters.DropObjects = chkDropObject.Checked;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void wizardControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void wizardControl1_WizardPageEnter(Crownwood.DotNetMagic.Controls.WizardPage wp, Crownwood.DotNetMagic.Controls.WizardControl wc)
        {
            if (wp.Name == pageDbConnection.Name)
            {
                wizardControl1.NextButton.Visible = true;
                wizardControl1.NextButton.Enabled = false;
            }
            else if (wp.Name == pageParameters.Name)
            {
                if (userCheckList.Items.Count == 0)
                {
                    LoadDbUsers();
                }

                wizardControl1.NextButton.Visible = false;
                wizardControl1.FinishButton.Visible = true;
                wizardControl1.FinishButton.Enabled = false;
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                string cnnStr = String.Format("User Id={0};Password={1};Data Source={2}", txtUsername.Text, txtPassword.Text, cmbTns.Text);
                //string cnnStr = String.Format("User Id={0};Password={1};Data Source={2}", "FONETPACS","8079521","FONET");
                Parameters.ConnectionString = cnnStr;

                OracleConnection cnn = new OracleConnection(Parameters.ConnectionString);
                cnn.Open();
                wizardControl1.NextButton.Enabled = true;
                lblSonuc.Text = "Bağlantı Başarılı";
            }
            catch (Exception ex)
            {
                lblSonuc.Text = ex.Message;
            }
        }

        private void LoadDbUsers()
        {
            try
            {
                OracleConnection cnn = new OracleConnection(Parameters.ConnectionString);
                cnn.Open();


                string sqlString = "SELECT U.USERNAME FROM DBA_USERS U WHERE 1=1 \n";
                if(!chkAllUsers.Checked)
                {
                    sqlString += "AND U.ACCOUNT_STATUS = 'OPEN'\n";
                }

                if(!chkSystemGroup.Checked)
                {
                    sqlString += "AND U.initial_rsrc_consumer_group <> 'SYS_GROUP'";
                }

                OracleCommand cmd = new OracleCommand(sqlString, cnn);
                var reader = cmd.ExecuteReader();
                userCheckList.Items.Clear();
                while(reader.Read())
                {
                    userCheckList.Items.Add(reader.GetString(0), false);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Kullanıcılar yüklenirken hata oluştu ?");
            }
        }

        private void chkSystemGroup_CheckedChanged(object sender, EventArgs e)
        {
            LoadDbUsers();
        }

        private void chkOnlyActive_CheckedChanged(object sender, EventArgs e)
        {
            LoadDbUsers();
        }

        private void userCheckList_SelectedValueChanged(object sender, EventArgs e)
        {
            if(userCheckList.CheckedItems.Count == 0)
            {
                wizardControl1.FinishButton.Enabled = false;
            }
            else
            {
                wizardControl1.FinishButton.Enabled = true;
            }
        }
    }
}
