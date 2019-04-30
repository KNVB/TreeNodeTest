using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIObject
{
    public class FTPUserGroupsListNode:Node
    {
        public FTPUserGroupsListNode(string json, AdminServer adminServer) : base(json, adminServer)
        {
            nodeType = NodeType.FTPUserGroupsListNode;
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(json);
            this.Text = obj.Text;
            this.Name = obj.Name;
        }
    }
}
