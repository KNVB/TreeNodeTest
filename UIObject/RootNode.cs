using System;
using System.Windows.Forms;

namespace UIObject
{
    public class RootNode:Node
    {
        public ListItem addAdminServerItem { get; set; }
        public RootNode()
        {
           // MessageBox.Show((addAdminServerItem==null).ToString());
        }
    }
}
