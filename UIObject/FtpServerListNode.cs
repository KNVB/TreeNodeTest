using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace UIObject
{
    public class FTPServerListNode : Node
    {
        public ListItem addFTPServerItem = new ListItem();
        private FTPServerNode ftpServerNode;
        //private SortedDictionary<string, FtpServerInfo> ftpServerList;
        public FTPServerListNode(string json, AdminServer adminServer) : base(json, adminServer)
        {
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(json);
            dynamic a = obj["addFTPServerItem"];
            nodeType = NodeType.FTPServerListNode;
            this.Text = obj.Text;
            this.Name = obj.Name;
            addFTPServerItem.ListItemType = ListItemType.AddFTPServerItem;
            addFTPServerItem.Text = a.Text;
            addFTPServerItem.Name = a.Name;
            addFTPServerItem.ImageIndex = a.ImageIndex;
            string temp = Convert.ToString(obj["ftpServerNode"]);
            ftpServerNode = new FTPServerNode(temp, adminServer);
            this.Nodes.Add(ftpServerNode);
        }
        public void handleSelectEvent(ListView listView)
        {
            ColumnHeader header;
            //FtpServerInfo ftpServerInfo;
            ListItem listItem;
            listView.Items.Clear();
            listView.Columns.Clear();
            foreach (string headerString in this.colunmNameList)
            {
                // MessageBox.Show(headerString);
                header = new ColumnHeader();
                header.Text = headerString;
                listView.Columns.Add(header);
            }
            this.addFTPServerItem.parentNode = this;
            listView.Items.Add(this.addFTPServerItem);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}