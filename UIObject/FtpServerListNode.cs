using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using AdminServerObject;
using System.Windows.Forms;

namespace UIObject
{
    public class FTPServerListNode : Node
    {
        // public FTPServerNode ftpServerNodeTemplate { get; set; }
        public ListItem addFTPServerItem;
        public FTPServerListNode(JToken token, AdminServer adminServer) : base(token, adminServer)
        {
            nodeType = NodeType.FTPServerListNode;
            this.addFTPServerItem = new ListItem(token["addFTPServerItem"]);
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