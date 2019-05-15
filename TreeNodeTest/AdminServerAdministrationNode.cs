using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
namespace TreeNodeTest
{
    internal class AdminServerAdministrationNode : Node
    {
        internal AdminUserAdministrationNode adminUserAdministrationNode;
        internal AdminServerAdministrationNode(AdminServer adminServer, UIManager uiManager) : base(adminServer, uiManager)
        {
        }
        internal override void doSelect()
        {
            adminUserAdministrationNode.adminServer = adminServer;
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
        internal void init(JToken token)
        {
            base.init(token);
            adminUserAdministrationNode = new AdminUserAdministrationNode(adminServer, uiManager);
            adminUserAdministrationNode.init(token["adminUserAdministrationNode"]);
            this.Nodes.Clear();
            this.Nodes.Add(adminUserAdministrationNode);
        }
    }
}