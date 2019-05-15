using AdminServerObject;
using Newtonsoft.Json.Linq;

namespace TreeNodeTest
{
    internal class AddFtpServerItem:ListItem
    {
        internal AdminServer adminServer;
        internal AddFtpServerItem(JToken token) :base(token)
        {

        }
    }
}