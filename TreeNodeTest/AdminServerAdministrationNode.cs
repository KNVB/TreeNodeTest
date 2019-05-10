using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace TreeNodeTest
{
    internal class AdminServerAdministrationNode : Node
    {
        public AdminUserAdministrationNode adminUserAdministrationNode;
        internal AdminServerAdministrationNode(JToken token) : base(token)
        {
            adminUserAdministrationNode = new AdminUserAdministrationNode(token["adminUserAdministrationNode"]);
            MessageBox.Show(Convert.ToString(adminServer == null), "AdminServerAdministrationNode");
            adminUserAdministrationNode.adminServer = adminServer;
            this.Nodes.Clear();
            this.Nodes.Add(adminUserAdministrationNode);
        }
        internal override void doSelect(UIManager uiManager)
        {
            List<ListItem> itemList = new List<ListItem>();
            ListItem adminUserAdministrationListItem = new ListItem();
            adminUserAdministrationListItem.ImageIndex = adminUserAdministrationNode.SelectedImageIndex;
            adminUserAdministrationListItem.Text = adminUserAdministrationNode.Text;
            adminUserAdministrationListItem.Name = adminUserAdministrationNode.Name;
            adminUserAdministrationListItem.SubItems.Add(adminUserAdministrationNode.description);
            adminUserAdministrationListItem.relatedNode = adminUserAdministrationNode;
            itemList.Add(adminUserAdministrationListItem);
            uiManager.updateListView(this.colunmNameList, itemList);
        }
    }
}
