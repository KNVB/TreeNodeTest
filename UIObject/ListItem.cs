using System.Windows.Forms;
namespace UIObject
{
    public class ListItem : ListViewItem
    {
        public Node parentNode { get; set; }
        public int ListItemType = -1;
    }
}
