using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace UIObject
{
    public class FTPServerNode:Node
    {
        private FTPUserListNode ftpUsersListNode=null;
        private FTPUserGroupsListNode ftpUserGroupsListNode=null;
        public FTPServerNode(JToken token, AdminServer adminServer, string serverDesc,string serverId) : base(token, adminServer)
        {
            nodeType = NodeType.FTPServerNode;
            ftpUsersListNode = new FTPUserListNode(token["ftpUsersListNode"]);
            ftpUserGroupsListNode =new FTPUserGroupsListNode(token["ftpUserGroupsListNode"]);
            this.Text = serverDesc;
            this.Name = serverId;
            this.Nodes.Add(ftpUsersListNode);
            this.Nodes.Add(ftpUserGroupsListNode);
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
            listItem.relatedNode = ftpUsersListNode;
            listItem.SubItems.Add(ftpUsersListNode.description);
            listItem.ImageIndex = ftpUsersListNode.ImageIndex;
            listView.Items.Add(listItem);

            listItem = new ListItem();
            listItem.Text = ftpUserGroupsListNode.Text;
            listItem.Name = listItem.Text;
            listItem.relatedNode = ftpUserGroupsListNode;
            listItem.SubItems.Add(ftpUserGroupsListNode.description);
            listItem.ImageIndex = ftpUserGroupsListNode.ImageIndex;
            listView.Items.Add(listItem);

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
     }
  }
