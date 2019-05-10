using Newtonsoft.Json.Linq;

namespace TreeNodeTest
{
    internal class FtpUserListNode
    {
        private JToken jToken;

        public FtpUserListNode(JToken jToken)
        {
            this.jToken = jToken;
        }
    }
}