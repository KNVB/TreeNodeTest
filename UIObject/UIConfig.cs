using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace UIObject
{
    public class UIConfig
    {
        Dictionary<string, dynamic> values = null;
        AdminServer adminServer;
        public UIConfig(AdminServer adminServer)
        {
            this.adminServer= adminServer;
            using (StreamReader streamReader = new StreamReader("UIConfigParameter.json"))
            {
                string json = streamReader.ReadToEnd();
                values=JsonConvert.DeserializeObject<Dictionary<string,dynamic>>(json);
            }
        }
        public AdminServerNode getAdminServerNode()
        {
            string json = Convert.ToString(values["adminServerNode"]);
            AdminServerNode adminServerNode=new AdminServerNode(json,this.adminServer);
            return adminServerNode;
        }
        public RootNode getRootNode()
        {
            string json = Convert.ToString(values["RootNode"]);
            RootNode rootNode = new RootNode(json ,this.adminServer);
            return rootNode;
        }
        public dynamic getObj(string key)
        {
            return values[key];
        }
    }
}
