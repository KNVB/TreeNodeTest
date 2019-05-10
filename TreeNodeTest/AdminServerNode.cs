using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System;

namespace TreeNodeTest
{
    internal class AdminServerNode : Node
    {
        internal FtpServerListNode ftpServerListNode;
        internal AdminServerAdministrationNode adminServerAdministrationNode;
        internal SortedDictionary<string, dynamic> toolStripItemList;
        internal AdminServerNode(JToken token) : base(token)
        {
            MessageBox.Show(Convert.ToString(adminServer == null), "adminServerNode");
            toolStripItemList = token["ToolStripItemList"].ToObject<SortedDictionary<string, dynamic>>();
            adminServerAdministrationNode = new AdminServerAdministrationNode(token["adminServerAdministrationNode"]);
            ftpServerListNode = new FtpServerListNode(token["ftpServerListNode"]);
            adminServerAdministrationNode.adminServer = this.adminServer;
            ftpServerListNode.adminServer = this.adminServer;
            this.Nodes.Clear();
            this.Nodes.Add(adminServerAdministrationNode);
            this.Nodes.Add(ftpServerListNode);
        }
        internal override void doSelect(UIManager uiManager)
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
    }
}
