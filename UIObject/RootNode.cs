using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UIObject
{
    public class RootNode: Node
    {
        internal ListItem addAdminServerItem = new ListItem();
        public RootNode(string json,AdminServer adminServer) :base(json,adminServer)
        {
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(json);
            dynamic a = obj["addAdminServerItem"];
            addAdminServerItem.ListItemType = ListItemType.AddAdminServerItem;
            addAdminServerItem.Text = a.Text;
            addAdminServerItem.Name = a.Name;
            addAdminServerItem.ImageIndex = a.ImageIndex;
            nodeType = NodeType.RootNode;
        }
        public void handleSelectEvent(TreeView treeView1, ListView listView, ImageList imageList1, SortedDictionary<string, AdminServer> adminServerList)
        {
            ColumnHeader header;
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

            foreach (string key in adminServerList.Keys)
            {
                listItem = new ListItem();
                //listItem.ListItemType = ListItemType.AdminServerItem;
                listItem.parentNode = this;
                listItem.Text = key;
                listItem.Name = listItem.Text;
                listItem.ImageIndex = 2;
                listView.Items.Add(listItem);
            }
            //rootNode.addAdminServerListItem.fullPath = rootNode.FullPath;
            listView.Items.Add(this.addAdminServerItem);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
