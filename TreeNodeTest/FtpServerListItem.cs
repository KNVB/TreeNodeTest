using AdminServerObject;
using System.Windows.Forms;

namespace TreeNodeTest
{
    internal class FtpServerListItem:ListItem
    {
        internal override void doClick(UIManager uiManager)
        {
            uiManager.refreshFtpServerListNode((FtpServerListNode)relatedNode);
            uiManager.selectNode(relatedNode);
        }
    }
}
