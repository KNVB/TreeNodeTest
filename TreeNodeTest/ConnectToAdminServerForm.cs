using AdminServerObject;
using System;
using System.Windows.Forms;

namespace TreeNodeTest
{
    public partial class ConnectToAdminServerForm : Form
    {
        private int adminPortNo = -1;
        private string adminServerName = "";
        private string adminUserName = "", adminUserPassword = "";
        private AdminServerManager adminServerManager;
        public ConnectToAdminServerForm(AdminServerManager adminServerManager)
        {
            InitializeComponent();
            this.adminServerManager = adminServerManager;
        }
        private void ConnectToServerForm_Load(object sender, EventArgs e)
        {
            //loginButton_Click(this, new EventArgs());
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            this.DialogResult = DialogResult.No;
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            adminServerManager.addAdminServer(this.serverName.Text, Convert.ToInt32(portNo.Value), "dsfds", "sfsd");
            Cursor.Current = Cursors.Default;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
