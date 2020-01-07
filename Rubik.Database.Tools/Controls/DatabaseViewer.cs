using Crownwood.DotNetMagic.Controls;
using NLog;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rubik.Database.Controls
{
    public partial class DatabaseViewer : Form
    {
        Logger logger;
        private Objects.Database _database;

        public DatabaseViewer(Objects.Database db)
        {
            this._database = db;
            InitializeComponent();
        }
        public DatabaseViewer()
        {
            InitializeComponent();

        }

        private void DatabaseViewer_Load(object sender, EventArgs e)
        {
            InitializeLog();
            this.Activate();
            this.SetTopLevel(true);

            if (_database != null)
                FillSchema();
        }

        private void InitializeLog()
        {
            try
            {
                logger = NLog.LogManager.GetCurrentClassLogger();
                NLog.Targets.RichTextBoxTarget target = new NLog.Targets.RichTextBoxTarget();

                target.Layout = "${date:format=HH\\:MM\\:ss} ${logger} ${message}";
                target.FormName = "DatabaseViewer";
                target.ControlName = "logText";
                target.UseDefaultRowColoringRules = true;

                NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(target, LogLevel.Trace);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillSchema()
        {
            if (_database == null)
            {
                logger.Error("Database Schema Null !!");
            }

            Node rootNode = new Node(_database.Name + " " + _database.DatabaseVersion);
            rootNode.Nodes.Add(new Node()
            {
                Text = _database.OwnerUser
            });
        }

        private void FillNode(Database.Objects.Database db,Node rootNode)
        {

        }
    }
}
