using System;
using System.Collections.Generic;
using System.ComponentModel;
using UIObject;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            UIConfig uiConfig = new UIConfig();
            RootNode rootNode = uiConfig.getRootNode();
            rootNode.Text = this.Text;
            rootNode.Name = rootNode.Text;
            AdminServerNode adminServerNode = uiConfig.getAdminServerNode();
            adminServerNode.Text = "ff";
            rootNode.Nodes.Add(adminServerNode);
            adminServerNode = uiConfig.getAdminServerNode();
            adminServerNode.Text = "ff";
            rootNode.Nodes.Add(adminServerNode);
            treeView1.Nodes.Add(rootNode);
           
        }
    }
}
