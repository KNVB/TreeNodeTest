using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace UIObject
{
    public class Node : TreeNode
    {
        internal AdminServer adminServer;
        public int nodeType;
        internal List<string> colunmNameList { get; set; }
        internal string description { get; set; }
        dynamic obj= null;
        public Node(string json,AdminServer adminServer)
        {
            this.adminServer = adminServer;
            obj = JsonConvert.DeserializeObject<dynamic>(json);
            this.SelectedImageIndex = obj.SelectedImageIndex;
            this.ImageIndex = obj.ImageIndex;
            this.description = obj.description;
            if  (obj.colunmNameList !=null)
                this.colunmNameList = obj.colunmNameList.ToObject<List<string>>();
        }
    }
}
