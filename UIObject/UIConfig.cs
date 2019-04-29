using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
namespace UIObject
{
    public class UIConfig
    {
        UIConfigParameter uIConfigParameter = null;
        public UIConfig()
        {
            using (StreamReader streamReader = new StreamReader("UIConfigParameter.json"))
            {
                string json = streamReader.ReadToEnd();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                uIConfigParameter = jss.Deserialize<UIConfigParameter>(json);
            }
        }
        public AdminServerNode getAdminServerNode()
        {
            return uIConfigParameter.adminServerNode;
            //return (AdminServerNode)uIConfigParameter.adminServerNode.Clone();
        }
        public RootNode getRootNode()
        {
            return uIConfigParameter.rootNode;
            // return (RootNode)uIConfigParameter.rootNode.Clone();
        }
        public AdminServerAdministrationNode getAdminServerAdministrationNode()
        {
            return uIConfigParameter.adminServerAdministrationNode;
        }
        public AdminUserAdministrationNode getAdminUserAdministrationNode()
        {
            return uIConfigParameter.adminUserAdministrationNode;
        }
        public FtpServerListNode getFtpServerListNode()
        {
            return uIConfigParameter.ftpServerListNode;
        }
        public FtpServerNode getFtpServerNode()
        {
            return uIConfigParameter.ftpServerNode;
        }
        public FtpUserGroupsListNode getFtpUserGroupsListNode()
        {
            return uIConfigParameter.ftpUserGroupsListNode;
        }
        public FtpUsersListNode getFtpUsersListNode()
        {
            return uIConfigParameter.ftpUsersListNode;
        }
    }
}
