using System;
using System.Windows.Forms;
using AdminServerObject;


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
            uiManager = new UIManager(this);
            uiManager.initMainForm();
        }
        
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Node n = ((Node)e.Node);
            uiManager.handleNodeSelectEvent(n);
        }       
     
        private void listView1_Click(object sender, EventArgs e)
        {
            ListItem listItem = (ListItem)listView1.SelectedItems[0];
            uiManager.handleListViewClickEvent(listItem);
        }
    }
}
