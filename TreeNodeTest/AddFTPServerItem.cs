﻿using AdminServerObject;
using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;
namespace TreeNodeTest
{
    internal class AddFtpServerItem : ListItem
    {
        internal AdminServer adminServer;
        internal AddFtpServerItem(JToken token) : base(token)
        {

        }
        internal override void doClick(UIManager uiManager)
        {
            
        }
    }
}