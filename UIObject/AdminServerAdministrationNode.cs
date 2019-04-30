using Newtonsoft.Json;
using System;

namespace UIObject
{
    internal class AdminServerAdministrationNode:Node
    {
        AdminUserAdministrationNode adminUserAdministrationNode;
        public AdminServerAdministrationNode(string json,AdminServer adminServer) : base(json,adminServer)
        {
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(json);
            string temp = Convert.ToString(obj["adminUserAdministrationNode"]);
            nodeType = NodeType.AdminServerAdministrationNode;
            adminUserAdministrationNode=new AdminUserAdministrationNode(temp, adminServer);
            this.Nodes.Add(adminUserAdministrationNode);
            this.Text = obj.Text;
            this.Name = obj.Name;

        }

    }
}