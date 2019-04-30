using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIObject
{
    public class FTPServerNode:Node
    {
        public FTPUserListNode ftpUsersListNode ;
        public FTPUserGroupsListNode ftpUserGroupsListNode ;
        public FTPServerNode(string json, AdminServer adminServer) : base(json, adminServer)
        {
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(json);
            string temp = Convert.ToString(obj["ftpUserGroupsListNode"]);
            ftpUserGroupsListNode = new FTPUserGroupsListNode(temp, adminServer);
            temp = Convert.ToString(obj["ftpUsersListNode"]);
            ftpUsersListNode=new FTPUserListNode(temp, adminServer);
            this.Nodes.Add(ftpUsersListNode);
            this.Nodes.Add(ftpUserGroupsListNode);

            this.Text = "FTP Server";
            this.Name = this.Text;
            nodeType = NodeType.FTPServerNode;
        }        
        public void handleSelectEvent(ListView listView)
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
            listItem = new ListItem();
            listItem.Text = ftpUsersListNode.Text;
            listItem.Name = listItem.Text;
            listItem.parentNode = this;
            listItem.SubItems.Add(ftpUsersListNode.description);
            listItem.ImageIndex = ftpUsersListNode.ImageIndex;
            listView.Items.Add(listItem);

            listItem = new ListItem();
            listItem.Text = ftpUserGroupsListNode.Text;
            listItem.Name = listItem.Text;
            listItem.parentNode = this;
            listItem.SubItems.Add(ftpUserGroupsListNode.description);
            listItem.ImageIndex = ftpUserGroupsListNode.ImageIndex;
            listView.Items.Add(listItem);

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
     }
  }
