﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using AdminServerObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TreeNodeTest
{
    internal class UIObjFactory
    {
        JObject messageTextList;
        JObject labelList;
        JObject objectList;
        string json;
        UIManager uiManager;
        internal UIObjFactory(UIManager uiManager)
        {
            this.uiManager = uiManager;
            using (StreamReader streamReader = new StreamReader(@"json\MessageText.json"))
            {
                json = streamReader.ReadToEnd();
                messageTextList = JObject.Parse(json);
            }
            using (StreamReader streamReader = new StreamReader(@"json\Label.json"))
            {
                json = streamReader.ReadToEnd();
                labelList = JObject.Parse(json);
            }
            using (StreamReader streamReader = new StreamReader(@"json\UIObject.json"))
            {
                json = streamReader.ReadToEnd();
                objectList = JObject.Parse(json);
            }
        }
        internal AdminServerNode getAdminServerNode(AdminServer adminServer)
        {
            AdminServerNode adminServerNode=new AdminServerNode(getObj("adminServerNode"),adminServer,uiManager);
            return adminServerNode;
        }
        internal string getMessageText(string key)
        {
            return (string)messageTextList[key];
        }
        internal string getLabel(string key)
        {
            return (string)labelList[key];
        }
        internal RootNode getRootNode()
        {
            RootNode rootNode = new RootNode(getObj("RootNode"), uiManager);
            return rootNode;
        }
        internal JToken getObj(string key)
        {
            return objectList[key];
        }
    }
}
