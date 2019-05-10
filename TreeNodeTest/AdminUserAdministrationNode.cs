using AdminServerObject;
using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;
namespace TreeNodeTest
{
    internal class AdminUserAdministrationNode : Node
    {
        internal AdminUserAdministrationNode(JToken token) : base(token)
        {
        }
        internal override void doSelect(UIManager uiManager)
        {
            MessageBox.Show(Convert.ToString(adminServer == null));
        }
    }
}