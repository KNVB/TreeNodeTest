using System;
using System.Windows.Forms;
using AdminServerObject;
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
            this.Text = Properties.Resources.Software_Name;
            AdminServer adminServer = new AdminServer();
            UIObjFactory uiObjFactory = new UIObjFactory();

            AdminServerNode adminServerNode = uiObjFactory.getAdminServerNode(adminServer);
            adminServerNode.Text = "Admin. Server";
            RootNode rootNode = uiObjFactory.getRootNode();
            rootNode.Text = this.Text;
            rootNode.Name = rootNode.Text;

            rootNode.Nodes.Add(adminServerNode);
            treeView1.Nodes.Add(rootNode);
            rootNode.ExpandAll();
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
                case NodeType.AdminServerAdministrationNode:
                    ((AdminServerAdministrationNode)node).handleSelectEvent(listView1);
                    break;
                case NodeType.AdminUserAdministrationNode:
                    MessageBox.Show("Popup Connect Admin. User dialog.");
                    break;
                case NodeType.FTPServerListNode:
                     ((FTPServerListNode)node).handleSelectEvent(listView1);
                     break;
                case NodeType.RootNode:
                    ((RootNode)node).handleSelectEvent(listView1,  new SortedDictionary<string, AdminServer>());
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

        private void listView1_Click(object sender, EventArgs e)
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
                default:
                    splitContainer1.SelectNextControl((Control)splitContainer1, true, true, true, true);
                    Node relatedNode = listItem.relatedNode;
                    if (relatedNode != null)
                    {
                        relatedNode.Expand();
                        treeView1.SelectedNode = null;
                        treeView1.SelectedNode = relatedNode;
                    }
                    break;
            }
        }
    }
}
