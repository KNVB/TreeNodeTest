using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TreeNodeTest
{
    internal class FtpServerListNode : Node
    {
        public AddFTPServerItem addFTPServerItem;
        internal FtpServerListNode(JToken token) : base(token)
        {
            this.addFTPServerItem = new AddFTPServerItem(token["addFTPServerItem"]);
        }
        internal override void doSelect(UIManager uiManager)
        {
            List<ListItem> itemList = new List<ListItem>();
            this.addFTPServerItem.adminServer = this.adminServer;
            itemList.Add(this.addFTPServerItem);
            uiManager.updateListView(this.colunmNameList, itemList);
        }
    }
}