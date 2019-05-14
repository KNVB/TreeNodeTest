using AdminServerObject;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TreeNodeTest
{
    internal class FtpServerListNode : Node
    {
        public AddFtpServerItem addFTPServerItem;
        internal JToken token;
        internal SortedDictionary<string, FtpServerInfo> ftpServerList=new SortedDictionary<string, FtpServerInfo>();
        internal FtpServerListNode(JToken token,AdminServer adminServer, UIManager uiManager) : base(token, adminServer,uiManager)
        {
            FtpServerInfo ftpServerInfo = new FtpServerInfo();
            ftpServerInfo.serverId = "QQKK";
            ftpServerInfo.description = "陳大文";
            ftpServerList.Add(ftpServerInfo.serverId, ftpServerInfo);

            ftpServerInfo = new FtpServerInfo();
            ftpServerInfo.serverId = "4466";
            ftpServerInfo.description = "張三_李四";
            ftpServerList.Add(ftpServerInfo.serverId, ftpServerInfo);

            this.addFTPServerItem = new AddFtpServerItem(token["addFTPServerItem"]);
            this.token= token;

        }
        internal override void doSelect()
        {
            List<ListItem> itemList = new List<ListItem>();
            this.addFTPServerItem.adminServer = this.adminServer;


            
            foreach(string serverId in ftpServerList.Keys)
            {
                ListItem ftpServerItem = new ListItem();
                FtpServerNode ftpServerNode = ((FtpServerNode)Nodes.Find(serverId, true)[0]);
                FtpServerInfo ftpServerInfo = ftpServerList[serverId];
                ftpServerItem.relatedNode = ftpServerNode;
                ftpServerItem.Text = ftpServerInfo.description;
                ftpServerItem.Name = ftpServerInfo.serverId;
                ftpServerItem.ImageIndex = ftpServerNode.ImageIndex;
                ftpServerItem.SubItems.Add("1");
                switch (ftpServerInfo.status)
                {
                    case FtpServerStatus.DISABLE:
                        ftpServerItem.SubItems.Add("Disabled");
                        break;
                    case FtpServerStatus.STARTED:
                        ftpServerItem.SubItems.Add("Started");
                        break;
                    case FtpServerStatus.STOPPED:
                        ftpServerItem.SubItems.Add("Stopped");
                        break;
                }
                itemList.Add(ftpServerItem);
            }
            itemList.Add(this.addFTPServerItem);
            uiManager.updateListView(this.colunmNameList, itemList);
        }
    }
}