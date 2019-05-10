using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AdminServerObject;
using Newtonsoft.Json.Linq;

namespace TreeNodeTest
{
    public class UIObjFactory
    {
        Dictionary<string, dynamic> values = null;
        JObject objectList;
        UIManager uiManager;
        internal UIObjFactory(UIManager uiManager)
        {
            this.uiManager= uiManager;
            using (StreamReader streamReader = new StreamReader("UIConfigParameter.json"))
            {
                string json = streamReader.ReadToEnd();
                objectList = JObject.Parse(json);
            }
        }
        internal AdminServerNode getAdminServerNode(AdminServer adminServer)
        {
            AdminServerNode adminServerNode=new AdminServerNode(getObj("adminServerNode"),adminServer,uiManager);
            return adminServerNode;
        }
        internal RootNode getRootNode()
        {
            RootNode rootNode = new RootNode(getObj("RootNode"),uiManager);
            return rootNode;
        }
        public JToken getObj(string key)
        {
            return objectList[key];
        }
    }
}
