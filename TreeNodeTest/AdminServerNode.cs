using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using AdminServerObject;

namespace TreeNodeTest
{
    internal class AdminServerNode : Node
    {
        internal AdminServerAdministrationNode adminServerAdministrationNode;
        internal FtpServerListNode ftpServerListNode;
        internal SortedDictionary<string, dynamic> toolStripItemList;
        public AdminServerNode(AdminServer adminServer, UIManager uiManager) : base(adminServer, uiManager)
        {
        }
        internal override void doSelect()
        {
            List<ListItem> itemList = new List<ListItem>();
            ListItem listItem = new ListItem();
            listItem.Text = adminServerAdministrationNode.Text;
            listItem.Name = listItem.Text;
            listItem.relatedNode = adminServerAdministrationNode;
            listItem.SubItems.Add(adminServerAdministrationNode.description);
            listItem.ImageIndex = adminServerAdministrationNode.ImageIndex;
            itemList.Add(listItem);
            
            listItem = new ListItem();
            listItem.Text = ftpServerListNode.Text;
            listItem.Name = listItem.Text;
            listItem.relatedNode = ftpServerListNode;
            listItem.SubItems.Add(ftpServerListNode.description);
            listItem.ImageIndex = ftpServerListNode.ImageIndex;
            itemList.Add(listItem);
           
            uiManager.updateListView(this.colunmNameList, itemList);
        }
        internal void init(JToken token,string adminServerId)
        {
            base.init(token);
            
            this.Text = adminServerId;
            this.Name = adminServerId;
            toolStripItemList = token["ToolStripItemList"].ToObject<SortedDictionary<string, dynamic>>();
            adminServerAdministrationNode = new AdminServerAdministrationNode(adminServer, uiManager);
            adminServerAdministrationNode.init(token["adminServerAdministrationNode"]);
            ftpServerListNode = new FtpServerListNode(adminServer, uiManager);
            ftpServerListNode.init(token["ftpServerListNode"]);
            this.Nodes.Clear();
            this.Nodes.Add(adminServerAdministrationNode);
            this.Nodes.Add(ftpServerListNode);
        }
    }
}
