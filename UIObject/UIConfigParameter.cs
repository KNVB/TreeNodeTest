using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIObject
{
    public class UIConfigParameter
    {
        public RootNode rootNode { get; set; } = null;
        public AdminServerNode adminServerNode { get; set; } = null;
        public AdminServerAdministrationNode adminServerAdministrationNode { get; set; } = null;
        public AdminUserAdministrationNode adminUserAdministrationNode { get; set; } = null;
        public FtpServerListNode ftpServerListNode { get; set; } = null;
        public FtpServerNode ftpServerNode { get; set; } = null;
        public FtpUserGroupsListNode ftpUserGroupsListNode { get; set; } = null;
        public FtpUsersListNode ftpUsersListNode { get; set; } = null;
    }
}
