using AdminServerObject;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIObject
{
    public class FtpUserListNode : Node
    {
        string serverId;
        public FtpUserListNode(JToken token, AdminServer adminServer, string serverId) : base(token, adminServer)
        {
            nodeType = NodeType.FTPUserListNode;
            this.serverId = serverId;
        }
    }
}
