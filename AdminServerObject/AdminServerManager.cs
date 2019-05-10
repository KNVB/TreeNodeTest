using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminServerObject
{
    public class AdminServerManager
    {
        public SortedDictionary<string, AdminServer> adminServerList = new SortedDictionary<string, AdminServer>();
        public string lastServerKey = "";
        public void addAdminServer(string adminServerName, int adminPortNo, string adminUserName, string adminUserPassword)
        {
            AdminServer adminServer = new AdminServer();
            adminServer.serverName = adminServerName;
            adminServer.portNo = adminPortNo;
            adminServerList.Add(adminServerName + ":" + adminPortNo, adminServer);
            lastServerKey = adminServerName + ":" + adminPortNo;
        }
    }
}
