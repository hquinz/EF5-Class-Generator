namespace EFClassGenerator
{
    partial class Form1
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
            this.lblHost = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.clbTables = new System.Windows.Forms.CheckedListBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtNamespaceClasses = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNamespaceConfig = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxHosts = new System.Windows.Forms.ComboBox();
            this.btnServerListRefresh = new System.Windows.Forms.Button();
            this.cbWindowsAuthentication = new System.Windows.Forms.CheckBox();
            this.butCheckConnection = new System.Windows.Forms.Button();
            this.comboBoxModels = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tbTargetPath = new System.Windows.Forms.TextBox();
            this.lblTargetPath = new System.Windows.Forms.Label();
            this.bOpenFileDialog = new System.Windows.Forms.Button();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(17, 20);
            this.lblHost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(36, 16);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "Host";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(598, 17);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(235, 22);
            this.txtUsername.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(522, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(598, 44);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(235, 22);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Database";
            // 
            // clbTables
            // 
            this.clbTables.FormattingEnabled = true;
            this.clbTables.Location = new System.Drawing.Point(17, 102);
            this.clbTables.Margin = new System.Windows.Forms.Padding(4);
            this.clbTables.Name = "clbTables";
            this.clbTables.Size = new System.Drawing.Size(825, 480);
            this.clbTables.TabIndex = 7;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(398, 71);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Get Tables";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(525, 641);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(100, 28);
            this.btnGenerate.TabIndex = 13;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnGenerate_MouseUp);
            // 
            // txtNamespaceClasses
            // 
            this.txtNamespaceClasses.Location = new System.Drawing.Point(160, 619);
            this.txtNamespaceClasses.Margin = new System.Windows.Forms.Padding(4);
            this.txtNamespaceClasses.Name = "txtNamespaceClasses";
            this.txtNamespaceClasses.Size = new System.Drawing.Size(303, 22);
            this.txtNamespaceClasses.TabIndex = 11;
            this.txtNamespaceClasses.Text = "Namespace.Mapping";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 622);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Namespace Mapping";
            // 
            // txtNamespaceConfig
            // 
            this.txtNamespaceConfig.Location = new System.Drawing.Point(160, 650);
            this.txtNamespaceConfig.Margin = new System.Windows.Forms.Padding(4);
            this.txtNamespaceConfig.Name = "txtNamespaceConfig";
            this.txtNamespaceConfig.Size = new System.Drawing.Size(303, 22);
            this.txtNamespaceConfig.TabIndex = 10;
            this.txtNamespaceConfig.Text = "Namespace.Config";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 653);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Namespace Config";
            // 
            // comboBoxHosts
            // 
            this.comboBoxHosts.FormattingEnabled = true;
            this.comboBoxHosts.Location = new System.Drawing.Point(88, 16);
            this.comboBoxHosts.Name = "comboBoxHosts";
            this.comboBoxHosts.Size = new System.Drawing.Size(303, 24);
            this.comboBoxHosts.TabIndex = 1;
            // 
            // btnServerListRefresh
            // 
            this.btnServerListRefresh.Location = new System.Drawing.Point(398, 17);
            this.btnServerListRefresh.Name = "btnServerListRefresh";
            this.btnServerListRefresh.Size = new System.Drawing.Size(100, 23);
            this.btnServerListRefresh.TabIndex = 2;
            this.btnServerListRefresh.Text = "Refresh";
            this.btnServerListRefresh.UseVisualStyleBackColor = true;
            this.btnServerListRefresh.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnServerListRefresh_MouseUp);
            // 
            // cbWindowsAuthentication
            // 
            this.cbWindowsAuthentication.AutoSize = true;
            this.cbWindowsAuthentication.Location = new System.Drawing.Point(88, 42);
            this.cbWindowsAuthentication.Name = "cbWindowsAuthentication";
            this.cbWindowsAuthentication.Size = new System.Drawing.Size(167, 20);
            this.cbWindowsAuthentication.TabIndex = 5;
            this.cbWindowsAuthentication.Text = "Windows authentication";
            this.cbWindowsAuthentication.UseVisualStyleBackColor = true;
            this.cbWindowsAuthentication.CheckedChanged += new System.EventHandler(this.cbWindowsAuthentication_CheckedChanged);
            // 
            // butCheckConnection
            // 
            this.butCheckConnection.Location = new System.Drawing.Point(266, 41);
            this.butCheckConnection.Name = "butCheckConnection";
            this.butCheckConnection.Size = new System.Drawing.Size(125, 23);
            this.butCheckConnection.TabIndex = 7;
            this.butCheckConnection.Text = "Check Connection";
            this.butCheckConnection.UseVisualStyleBackColor = true;
            this.butCheckConnection.MouseUp += new System.Windows.Forms.MouseEventHandler(this.butCheckConnection_MouseUp);
            // 
            // comboBoxModels
            // 
            this.comboBoxModels.FormattingEnabled = true;
            this.comboBoxModels.ItemHeight = 16;
            this.comboBoxModels.Location = new System.Drawing.Point(88, 68);
            this.comboBoxModels.Name = "comboBoxModels";
            this.comboBoxModels.Size = new System.Drawing.Size(303, 24);
            this.comboBoxModels.TabIndex = 5;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // tbTargetPath
            // 
            this.tbTargetPath.Location = new System.Drawing.Point(160, 589);
            this.tbTargetPath.Name = "tbTargetPath";
            this.tbTargetPath.Size = new System.Drawing.Size(642, 22);
            this.tbTargetPath.TabIndex = 9;
            // 
            // lblTargetPath
            // 
            this.lblTargetPath.AutoSize = true;
            this.lblTargetPath.Location = new System.Drawing.Point(14, 592);
            this.lblTargetPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTargetPath.Name = "lblTargetPath";
            this.lblTargetPath.Size = new System.Drawing.Size(93, 16);
            this.lblTargetPath.TabIndex = 15;
            this.lblTargetPath.Text = "Create Files in";
            // 
            // bOpenFileDialog
            // 
            this.bOpenFileDialog.Location = new System.Drawing.Point(805, 588);
            this.bOpenFileDialog.Name = "bOpenFileDialog";
            this.bOpenFileDialog.Size = new System.Drawing.Size(28, 23);
            this.bOpenFileDialog.TabIndex = 10;
            this.bOpenFileDialog.Text = "...";
            this.bOpenFileDialog.UseVisualStyleBackColor = true;
            this.bOpenFileDialog.Click += new System.EventHandler(this.bOpenFileDialog_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMain});
            this.statusStripMain.Location = new System.Drawing.Point(0, 701);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(855, 22);
            this.statusStripMain.TabIndex = 18;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelMain
            // 
            this.toolStripStatusLabelMain.Name = "toolStripStatusLabelMain";
            this.toolStripStatusLabelMain.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabelMain.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 723);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.bOpenFileDialog);
            this.Controls.Add(this.tbTargetPath);
            this.Controls.Add(this.comboBoxModels);
            this.Controls.Add(this.butCheckConnection);
            this.Controls.Add(this.cbWindowsAuthentication);
            this.Controls.Add(this.btnServerListRefresh);
            this.Controls.Add(this.comboBoxHosts);
            this.Controls.Add(this.txtNamespaceConfig);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNamespaceClasses);
            this.Controls.Add(this.lblTargetPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.clbTables);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblHost);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Class Generator - EF 5";
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox clbTables;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtNamespaceClasses;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNamespaceConfig;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxHosts;
        private System.Windows.Forms.Button btnServerListRefresh;
        private System.Windows.Forms.CheckBox cbWindowsAuthentication;
        private System.Windows.Forms.Button butCheckConnection;
        private System.Windows.Forms.ComboBox comboBoxModels;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox tbTargetPath;
        private System.Windows.Forms.Label lblTargetPath;
        private System.Windows.Forms.Button bOpenFileDialog;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMain;
    }
}

