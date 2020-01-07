using Devart.Data.Oracle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rubik.DataTools.Controls
{
    public partial class OracleSettings : Form
    {
        internal class EnvironmentItem
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }


        public OracleSettings()
        {
            InitializeComponent();
            this.Load += OracleSettings_Load;
        }

        void OracleSettings_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ReadOnly = true;
            ListHomes();
        }

        private void ListHomes()
        {
            treeView1.Nodes.Clear();
            var rootNode = treeView1.Nodes.Add("Oracle Homes");
            foreach (OracleHome home in OracleConnection.Homes)
            {
                var node = rootNode.Nodes.Add(home.Name);
                node.Tag = home.Name;

                if (OracleConnection.Homes.DefaultHome.Name == home.Name)
                {
                    node.BackColor = Color.LightBlue;
                    node.Text = "( Varsayılan ) - " + node.Text;
                }
            }

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Parent != null)
            {
                List<EnvironmentItem> environments = new List<EnvironmentItem>();

                OracleHome home=  OracleConnection.Homes[e.Node.Tag.ToString()];
                OracleGlobalization globalization =  home.GetClientInfo();

                environments.Add(new EnvironmentItem() { Name = "Name", Value = home.Name });
                environments.Add(new EnvironmentItem() { Name = "NlsLang", Value = home.NlsLang });
                environments.Add(new EnvironmentItem() { Name = "Path", Value = home.Path });
                try
                {
                    environments.Add(new EnvironmentItem() { Name = "ClientVersion", Value = home.ClientVersion });
                }
                catch
                {

                }

                environments.Add(new EnvironmentItem() { Name = "ClientCharacterSet", Value = globalization.ClientCharacterSet });
                environments.Add(new EnvironmentItem() { Name = "Currency", Value = globalization.Currency });
                environments.Add(new EnvironmentItem() { Name = "DateFormat", Value = globalization.DateFormat });
                environments.Add(new EnvironmentItem() { Name = "DateLanguage", Value = globalization.DateLanguage });
                environments.Add(new EnvironmentItem() { Name = "DualCurrency", Value = globalization.DualCurrency });
                environments.Add(new EnvironmentItem() { Name = "ISOCurrency", Value = globalization.ISOCurrency });
                environments.Add(new EnvironmentItem() { Name = "Language", Value = globalization.Language });
                environments.Add(new EnvironmentItem() { Name = "NCharConversionException", Value = globalization.NCharConversionException.ToString() });
                environments.Add(new EnvironmentItem() { Name = "NumericCharacters", Value = globalization.NumericCharacters });
                environments.Add(new EnvironmentItem() { Name = "Territory", Value = globalization.Territory });
                environments.Add(new EnvironmentItem() { Name = "TimeStampFormat", Value = globalization.TimeStampFormat });
                environments.Add(new EnvironmentItem() { Name = "TimeStampTZFormat", Value = globalization.TimeStampTZFormat });
                environments.Add(new EnvironmentItem() { Name = "TimeZone", Value = globalization.TimeZone });



                dataGridView1.DataSource = null;
                dataGridView1.DataSource = environments;
                dataGridView1.AutoResizeColumns();
                dataGridView1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
