using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
namespace TreeNodeTest
{
    internal class RootNode : Node
    {
        private AdminServerManager adminServerManager;
        internal AddAdminServerItem addAdminServerItem;
        internal RootNode(AdminServer adminServer, UIManager uiManager) : base(adminServer, uiManager)
        {
            
        }
        internal override void doSelect()
        {
            List<ListItem> itemList = new List<ListItem>();

            foreach (string key in this.adminServerManager.adminServerList.Keys)
            {
                ListItem listItem = new ListItem();
                listItem.relatedNode = (Node)Nodes.Find(key, true)[0];
                listItem.Text = key;
                listItem.Name = listItem.Text;
                listItem.ImageIndex = listItem.relatedNode.ImageIndex;
                itemList.Add(listItem);
            }
            itemList.Add(this.addAdminServerItem);
            uiManager.updateListView(this.colunmNameList, itemList);
        }
        internal void init(JToken token)
        {
            base.init(token);
        }

        internal void setAdminServerManager(AdminServerManager adminServerManager)
        {
            this.adminServerManager = adminServerManager;
            addAdminServerItem.setAdminServerManager(adminServerManager);
        }
    }
}