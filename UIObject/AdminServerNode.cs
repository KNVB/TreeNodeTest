using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace UIObject
{
    public class AdminServerNode:Node
    {
        AdminServerAdministrationNode adminServerAdministrationNode;
        FTPServerListNode ftpServerListNode;
        public AdminServerNode(string json,AdminServer adminServer) : base(json,adminServer)
        {
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(json);
            string temp = Convert.ToString(obj["adminServerAdministrationNode"]);
            adminServerAdministrationNode = new AdminServerAdministrationNode(temp, adminServer);
            temp = Convert.ToString(obj["ftpServerListNode"]);
            ftpServerListNode=new FTPServerListNode(temp, adminServer);
            this.Nodes.Add(adminServerAdministrationNode);
            this.Nodes.Add(ftpServerListNode);
            nodeType = NodeType.AdminServerNode;
        }
        public void handleSelectEvent(ListView listView)
        {
            ColumnHeader header;
            ListItem listItem;
            listView.Items.Clear();
            listView.Columns.Clear();

            foreach (string headerString in colunmNameList)
            {
                // MessageBox.Show(headerString);
                header = new ColumnHeader();
                header.Text = headerString;
                listView.Columns.Add(header);
            }
           
            listItem = new ListItem();
            listItem.Text = adminServerAdministrationNode.Text;
            listItem.Name = listItem.Text;
            listItem.parentNode = this;
            listItem.SubItems.Add(adminServerAdministrationNode.description);
            listItem.ImageIndex = adminServerAdministrationNode.ImageIndex;
            listView.Items.Add(listItem);
           
            listItem = new ListItem();
            listItem.Text = ftpServerListNode.Text;
            listItem.Name = listItem.Text;
            listItem.parentNode = this;
            listItem.SubItems.Add(ftpServerListNode.description);
            listItem.ImageIndex = ftpServerListNode.ImageIndex;
            listView.Items.Add(listItem);
           

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
