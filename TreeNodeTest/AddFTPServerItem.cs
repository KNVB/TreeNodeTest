using AdminServerObject;
using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;
namespace TreeNodeTest
{
    internal class AddFTPServerItem : ListItem
    {
        internal AdminServer adminServer;
        internal AddFTPServerItem(JToken token) : base(token)
        {

        }
        internal override void doClick(UIManager uiManager)
        {
            MessageBox.Show(Convert.ToString(adminServer == null));
        }
    }
}
