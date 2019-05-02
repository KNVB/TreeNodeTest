using Newtonsoft.Json.Linq;

namespace UIObject
{
    public class FTPUserGroupsListNode:Node
    {
        public FTPUserGroupsListNode(JToken token) : base(token)
        {
            nodeType = NodeType.FTPUserGroupsListNode;
        }
    }
}
