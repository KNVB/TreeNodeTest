using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TreeNodeTest
{
    internal class Node:TreeNode
    {
        internal List<string> colunmNameList { get; set; }
        internal string description { get; set; }
        internal AdminServer adminServer=null;
        internal UIManager uiManager=null;
        internal virtual void doSelect()
        {

        }
        internal Node(AdminServer adminServer, UIManager uiManager)
        {
            this.adminServer = adminServer;
            this.uiManager = uiManager;
        }
        internal void init (JToken token)
        {
            dynamic obj = (dynamic)token;
            this.SelectedImageIndex = obj.SelectedImageIndex;
            this.ImageIndex = obj.ImageIndex;
            this.description = obj.description;
            this.Text = obj.Text;
            this.Name = obj.Name;

            if (obj.colunmNameList != null)
                this.colunmNameList = obj.colunmNameList.ToObject<List<string>>();
            this.ContextMenuStrip = new ContextMenuStrip();
        }
    }
}
