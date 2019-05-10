using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TreeNodeTest
{
    internal class FtpServerNode:Node
    {
        internal SortedDictionary<string, dynamic> toolStripItemList;
        internal FtpServerNode(JToken token, AdminServer adminServer, UIManager uiManager, string serverDesc,string serverId) : base(token, adminServer, uiManager)
        {
            toolStripItemList = token["ToolStripItemList"].ToObject<SortedDictionary<string, dynamic>>();
            this.Text = serverDesc;
            this.Name = serverId;
        }
        internal override void doSelect()
        {

        }
    }
  }
