using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace UIObject
{
    public class FtpServerListNode : Node
    {
        private FtpServerNode ftpServerNode;
        public ListItem addFTPServerItem;
        public FtpServerListNode(JToken token, AdminServer adminServer) : base(token, adminServer)
        {
            nodeType = NodeType.FTPServerListNode;
            
            this.addFTPServerItem = new ListItem(token["addFTPServerItem"]);
            ftpServerNode = new FtpServerNode(token["ftpServerNode"],adminServer,"serverDesc1","serverId1");
            this.Nodes.Add(ftpServerNode);
            ftpServerNode = new FtpServerNode(token["ftpServerNode"], adminServer, "serverDesc2", "serverId2");
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