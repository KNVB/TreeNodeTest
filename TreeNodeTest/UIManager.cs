using AdminServerObject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TreeNodeTest
{
    internal class UIManager
    {
        private AdminServerManager adminServerManager;
        private ListView listView;
        private ImageList imageList;
        private RootNode rootNode;
        private SplitContainer splitContainer;
        private TreeView treeView;
        private UIObjFactory uiObjFactory = null;
        internal UIManager(TreeView treeView, ListView listView, SplitContainer splitContainer, ImageList imageList, AdminServerManager adminServerManager)
        {
            this.adminServerManager = adminServerManager;
            this.treeView=treeView;
            this.listView=listView;
            this.imageList= imageList;
            this.splitContainer= splitContainer;
            uiObjFactory = new UIObjFactory(this);
            rootNode = uiObjFactory.getRootNode();
        }
        internal RootNode getRootNode()
        {
            return rootNode;
        }
        internal void refreshFtpServerListNode(FtpServerListNode ftpServerListNode)
        {
            ftpServerListNode.Nodes.Clear();
            foreach (FtpServerInfo fI in ftpServerListNode.ftpServerList.Values)
            {
                FtpServerNode ftpServerNode = new FtpServerNode(ftpServerListNode.token["ftpServerNode"], ftpServerListNode.adminServer,this, fI.description, fI.serverId);
                foreach (string key in ftpServerNode.toolStripItemList.Keys)
                {
                    ToolStripMenuItem tSI = ftpServerNode.toolStripItemList[key].ToObject<ToolStripMenuItem>();
                    tSI.Click += (sender, e) => MessageBox.Show(fI.serverId);
                    ftpServerNode.ContextMenuStrip.Items.Add(tSI);
                }
                ftpServerNode.ContextMenuStrip.ImageList = imageList;
                ftpServerListNode.Nodes.Add(ftpServerNode);
            }
        }
        internal void refreshRootNode()
        {
            splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
            rootNode.Nodes.Clear();
            foreach (string key in adminServerManager.adminServerList.Keys)
            {
                AdminServer adminServer = adminServerManager.adminServerList[key];
                AdminServerNode adminServerNode = uiObjFactory.getAdminServerNode(adminServer);
                adminServerNode.Text = key;
                adminServerNode.Name = key;
                foreach(string id in adminServerNode.toolStripItemList.Keys)
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
        }
        internal void selectNode(Node n)
        {
            treeView.SelectedNode = n;
        }
        internal void updateListView(List<string> colunmNameList, List<ListItem> ItemList)
        {
            splitContainer.SelectNextControl((Control)splitContainer, true, true, true, true);
            this.listView.Items.Clear();
            this.listView.Columns.Clear();
            foreach (string headerString in colunmNameList)
            {
                ColumnHeader header;
                header = new ColumnHeader();
                header.Text = headerString;
                listView.Columns.Add(header);
            }
            foreach (ListItem item in ItemList)
                listView.Items.Add(item);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
