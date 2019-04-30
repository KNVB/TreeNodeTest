﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIObject
{
    public class AdminUserAdministrationNode : Node
    {
        public AdminUserAdministrationNode(string json, AdminServer adminServer) : base(json, adminServer)
        {
            dynamic obj = JsonConvert.DeserializeObject<dynamic>(json);
            this.nodeType = NodeType.AdminUserAdministrationNode;
            this.Text = obj.Text;
            this.Name = obj.Name;
        }        
    }
}
