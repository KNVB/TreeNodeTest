using System;
using System.Windows.Forms;
using AdminServerObject;
using System.Collections.Generic;

namespace TreeNodeTest
{
    public partial class Form1 : Form
    {
        UIManager uiManager;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AdminServerManager asm = new AdminServerManager();
            uiManager = new UIManager(treeView1, listView1, splitContainer1, imageList1, asm);
            this.Text = Properties.Resources.Software_Name;
            RootNode rootNode = uiManager.getRootNode();
            rootNode.setAdminServerManager(asm);
            rootNode.Text = this.Text;
            treeView1.Nodes.Add(rootNode);
        }
        
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Node n = ((Node)e.Node);
            n.doSelect(uiManager);
        }       
     
        private void listView1_Click(object sender, EventArgs e)
        {
            ListItem listItem = (ListItem)listView1.SelectedItems[0];
            listItem.doClick(uiManager);
            listItem.Selected = false;
        }
    }
}
