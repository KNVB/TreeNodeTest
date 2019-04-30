using System;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;
using UIObject;
using System.Collections.Generic;

namespace TreeNodeTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            this.Text = Properties.Resources.Software_Name;
            AdminServer adminServer = new AdminServer();
           
            UIConfig uiConfig = new UIConfig(adminServer);
            AdminServerNode adminServerNode = uiConfig.getAdminServerNode();
            adminServerNode.Text = "ff";
            RootNode rootNode = uiConfig.getRootNode();
            rootNode.Text = this.Text;
            rootNode.Name = rootNode.Text;
            rootNode.Nodes.Add(adminServerNode);
            
            treeView1.Nodes.Add(rootNode);
            treeView1.SelectedNode = rootNode;
            rootNode.Expand();
      
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeView1_Click((Node)e.Node);
        }

        private void treeView1_Click(Node node)
        {
            switch (node.nodeType)
            {
                case NodeType.AdminServerNode:
                    ((AdminServerNode)node).handleSelectEvent(listView1);
                    break;
                case NodeType.FTPServerListNode:
                    ((FTPServerListNode)node).handleSelectEvent(listView1);
                    break;
                case NodeType.RootNode:
                    ((RootNode)node).handleSelectEvent(treeView1, listView1, imageList1, new SortedDictionary<string, AdminServer>());
                    break;
            }
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeView1.SelectedNode == e.Node)
            {
                treeView1_Click((Node)e.Node);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem listItem = (ListItem)listView1.SelectedItems[0];
            switch (listItem.ListItemType)
            {
                case ListItemType.AddAdminServerItem:
                    MessageBox.Show("Popup Connect Admin. Server dialog.");
                    break;
                case ListItemType.AddFTPServerItem:
                    MessageBox.Show("Popup Add FTP Server dialog.");
                    break;
            }
        }
    }
}
