using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace TreeNodeTest
{
    internal class AddAdminServerItem:ListItem
    {
        AdminServerManager adminServerManager;
        internal AddAdminServerItem(JToken token) : base(token)
        {
           
        }
        internal void setAdminServerManager(AdminServerManager adminServerManager)
        {
            this.adminServerManager = adminServerManager;
        }
        internal override void doClick(UIManager uiManager)
        {
            ConnectToAdminServerForm ctsf = new ConnectToAdminServerForm(adminServerManager);
            DialogResult dialogresult = ctsf.ShowDialog();
            if (dialogresult.Equals(DialogResult.OK))
            {
                uiManager.refreshRootNode();
            }
        }
    }
}
