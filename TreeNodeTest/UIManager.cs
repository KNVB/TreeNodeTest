using AdminServerObject;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace TreeNodeTest
{
    internal class UIManager
    {
        private AdminServerManager adminServerManager;
        private Form1 mainForm;
        private ListView listView;
        private ImageList imageList;
        private RootNode rootNode;
        private SplitContainer splitContainer;
        private TreeView treeView;
        private UIObjFactory uiObjFactory = null;
        internal UIManager(Form1 mainForm)
        {
            adminServerManager = new AdminServerManager();
            uiObjFactory = new UIObjFactory();
            this.mainForm = mainForm;
            this.treeView = mainForm.treeView1;
            this.listView = mainForm.listView1;
            this.imageList = mainForm.imageList1;
            this.splitContainer = mainForm.splitContainer1;
        }

       

        internal void handleListViewClickEvent(ListItem listItem)
        {
            listItem.doClick(this);
            listItem.Selected = false;
        }
        internal void handleNodeSelectEvent(Node n)
        {
            n.doSelect();
        }
        internal void initMainForm()
        {
            rootNode = new RootNode(null, this);
            rootNode.init(uiObjFactory.getObj("RootNode"));
            rootNode.addAdminServerItem = new AddAdminServerItem(uiObjFactory.getObj("RootNode")["addAdminServerItem"]);
            rootNode.setAdminServerManager(adminServerManager);
            this.mainForm.Text=uiObjFactory.getLabel("AppName");
            rootNode.Text = this.mainForm.Text;
            treeView.BeginUpdate();
            treeView.Nodes.Add(rootNode);
            treeView.EndUpdate();
        }
        internal void refreshFtpServerListNode(AdminServer adminServer, FtpServerListNode ftpServerListNode)
        {
            SortedDictionary<string, FtpServerInfo> ftpServerList = adminServer.getFTPServerList();
            ftpServerListNode.Nodes.Clear();
            foreach (string serverId in ftpServerList.Keys)
            {
                FtpServerNode ftpServerNode = new FtpServerNode(adminServer, this,serverId);
                FtpServerInfo fI = ftpServerList[serverId];
                ftpServerNode.init(uiObjFactory.getObj("ftpServerNode"));
                foreach (string key in ftpServerNode.toolStripItemList.Keys)
                {
                    ToolStripMenuItem tSI = ftpServerNode.toolStripItemList[key].ToObject<ToolStripMenuItem>();
                    tSI.Click += (sender, e) => MessageBox.Show(serverId);
                    ftpServerNode.ContextMenuStrip.Items.Add(tSI);
                }
                ftpServerNode.ContextMenuStrip.ImageList = imageList;
                ftpServerNode.Text = fI.description;
                ftpServerNode.Name = serverId;
                ftpServerListNode.Nodes.Add(ftpServerNode);
            }
        }
        internal void refreshRootNode()
        {
            splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
            treeView.BeginUpdate();

            rootNode.Nodes.Clear();
            foreach (string key in adminServerManager.adminServerList.Keys)
            {
                AdminServer adminServer = adminServerManager.adminServerList[key];
                AdminServerNode adminServerNode = new AdminServerNode(adminServer, this);
                adminServerNode.init(uiObjFactory.getObj("adminServerNode"),key);
                foreach (string id in adminServerNode.toolStripItemList.Keys)
                {
                    ToolStripMenuItem tSI = adminServerNode.toolStripItemList[id].ToObject<ToolStripMenuItem>();
                    tSI.Click += (sender, e) => MessageBox.Show(adminServer.serverName + ":" + adminServer.portNo);
                    adminServerNode.ContextMenuStrip.Items.Add(tSI);
                }
                adminServerNode.ContextMenuStrip.ImageList = imageList;
                rootNode.Nodes.Add(adminServerNode);
                if (key == adminServerManager.lastServerKey)
                {
                    treeView.SelectedNode = adminServerNode;
                    adminServerNode.doSelect();
                    adminServerNode.Expand();
                }
            }
            treeView.EndUpdate();
        }
        internal void selectNode(Node relatedNode)
        {
            treeView.SelectedNode = relatedNode;
        }
        internal void updateListView(List<string> colunmNameList, List<ListItem> itemList)
        {
            splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
            if ((colunmNameList!=null)&&(colunmNameList.Count>0))
            {
                this.listView.Columns.Clear();
                foreach (string headerString in colunmNameList)
                {
                    ColumnHeader header;
                    header = new ColumnHeader();
                    header.Text = headerString;
                    listView.Columns.Add(header);
                }
            }
            if ((itemList != null) && (itemList.Count > 0))
            {
                this.listView.Items.Clear();
                foreach (ListItem item in itemList)
                    listView.Items.Add(item);
            }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}