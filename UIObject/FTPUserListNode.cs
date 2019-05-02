using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIObject
{
    public class FTPUserListNode : Node
    {
        public FTPUserListNode(JToken token) : base(token)
        {
            nodeType = NodeType.FTPUserListNode;
        }
    }
}
