using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using AdminServerObject;
using System.Windows.Forms;

namespace UIObject
{
    public class FTPServerListNode : Node
    {
        private FTPServerNode ftpServerNode;
        public ListItem addFTPServerItem;
        public FTPServerListNode(JToken token, AdminServer adminServer) : base(token, adminServer)
        {
            nodeType = NodeType.FTPServerListNode;
            
            this.addFTPServerItem = new ListItem(token["addFTPServerItem"]);
            ftpServerNode = new FTPServerNode(token["ftpServerNode"],adminServer,"serverDesc1","serverId1");
            this.Nodes.Add(ftpServerNode);
            ftpServerNode = new FTPServerNode(token["ftpServerNode"], adminServer, "serverDesc2", "serverId2");
            this.Nodes.Add(ftpServerNode);
        }

        public void handleSelectEvent(ListView listView)
        {
            initListView(listView);
            this.addFTPServerItem.ListItemType = ListItemType.AddFTPServerItem;
            listView.Items.Add(this.addFTPServerItem);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}