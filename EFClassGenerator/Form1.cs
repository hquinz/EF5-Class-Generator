using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassGenerator;
using ClassGenerator.Data;
using EFClassGenerator.Data;
using EFClassGenerator.Helpers;
using EFClassGenerator.Tools;


/*
 * Code First Relationships Fluent API
    http://msdn.microsoft.com/en-us/data/hh134698.aspx
 * 
 * Creating a More Complex Data Model for an ASP.NET MVC Application
    http://www.asp.net/mvc/tutorials/getting-started-with-ef-using-mvc/creating-a-more-complex-data-model-for-an-asp-net-mvc-application
 * 
 * Associations in EF Code First: Part 1 to 5
    http://weblogs.asp.net/manavi/archive/2011/05/01/associations-in-ef-4-1-code-first-part-5-one-to-one-foreign-key-associations.aspx
 * 
 */



namespace EFClassGenerator
{
    public partial class Form1 : Form
    {
        #region Private Properties

        private readonly MsSqlServerList _msSqlServerList = null;
        private readonly DbWorker _dbWorker;
        private readonly DbInterpreter _dbInterpreter;
        private readonly QueryGenerator _queryGenerator = new QueryGenerator();

        #endregion Private Properties


        #region Init

        public Form1()
        {
            InitializeComponent();
            SetState(@"Searching for SQL - server...") ;
            _msSqlServerList = new MsSqlServerList();
            var dbConnect = new DbConnect();
            //var bindingSourceServer = new BindingSource {DataSource = _msSqlServerList.Server};
            //comboBoxHosts.DataSource = bindingSourceServer;
            comboBoxHosts.DataSource = _msSqlServerList.Server;
            _dbWorker = new DbWorker(dbConnect, _queryGenerator);
            _dbInterpreter = new DbInterpreter(dbConnect, _queryGenerator);
            tbTargetPath.Text = FileManager.GetAppPath + "\\classes";
            SetState("Ready");

        }

        #endregion Init



        #region Button Events

        private void btnServerListRefresh_MouseUp(object sender, MouseEventArgs e)
        {
            SetState(@"Searching for SQL - server ...");
            _msSqlServerList.RefreshServerList();
            RefreshCombobox(comboBoxHosts, _msSqlServerList.Server);
            SetState(@"Ready");
        }

        private void butCheckConnection_MouseUp(object sender, MouseEventArgs e)
        {
            SetState(@"Testing Connection ...");
            SetConnectionData(false);
            RefreshCombobox(comboBoxModels, _dbWorker.CheckConnectionAndGetModels(SetState));
            
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            SetState(@"Connecting to server...");
            SetConnectionData(true);
            var tables = _dbWorker.CheckConnectionAndGetTables(SetState);
            SetTableContent(tables);

        }
        private void btnGenerate_MouseUp(object sender, MouseEventArgs e)
        {
            _dbInterpreter.FilePath = tbTargetPath.Text;
            _dbInterpreter.GenerateClassFiles(clbTables.CheckedItems.Cast<DataRowView>(), SetState);
            MessageBox.Show(@"Done");

        }

        private void bOpenFileDialog_Click(object sender, EventArgs e)
        {
            tbTargetPath.Text = GetPath();
        }

        #endregion Button Events

        #region Other Controll Events

        private void cbWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.Enabled = !cbWindowsAuthentication.Checked;
            txtPassword.Enabled = !cbWindowsAuthentication.Checked;
        }


        #endregion 

        #region Private Methods


        private void SetConnectionData(bool setCatalog)
        {
            _dbWorker.Server = GetTextFromComboBox(comboBoxHosts);
            _dbWorker.User = txtUsername.Text;
            _dbWorker.Password = txtPassword.Text;
            _dbWorker.UseWindowsAuthentication = cbWindowsAuthentication.Checked;
            _dbWorker.Catalog = setCatalog ? GetTextFromComboBox(comboBoxModels) : null;
            
        }

        private string GetTextFromComboBox(ComboBox combobox)
        {
            return string.IsNullOrEmpty(combobox.Text) ? combobox.SelectedValue?.ToString() : combobox.Text;
        }

        private void SetState(string state)
        {
            toolStripStatusLabelMain.Text = state;
            this.Refresh();

        }

        private void RefreshCombobox(ComboBox comboBox, List<string> items)
        {
            comboBox.DataSource = null;
            comboBox.DataSource = items;
            comboBox.SelectedIndex = comboBox.Items.Count -1;

        }

        private void SetTableContent(DataTable dt)
        {
            if (dt == null) return;
            clbTables.DataSource = dt;
            clbTables.DisplayMember = "name";
            clbTables.ValueMember = "object_id";
        }

        private string GetPath()
        {
            var result = folderBrowserDialog.ShowDialog();
            return folderBrowserDialog.SelectedPath;
        }


 

        #endregion Private Methods



    }


}
