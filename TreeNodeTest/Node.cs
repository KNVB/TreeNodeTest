using System;
using System.Collections.Generic;
using AdminServerObject;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace TreeNodeTest
{
    internal abstract class Node:TreeNode
    {
        internal List<string> colunmNameList { get; set; }
        internal string description { get; set; }
        internal AdminServer adminServer;
        internal Node(JToken token)
        {
            init(token);
        }
        internal virtual void doSelect(UIManager uiManager)
        {

        }        
        private void init(JToken token)
        {
            dynamic obj = (dynamic)token;
            this.SelectedImageIndex = obj.SelectedImageIndex;
            this.ImageIndex = obj.ImageIndex;
            this.description = obj.description;

            this.Text = obj.Text;
            this.Name = obj.Name;

            if (obj.colunmNameList != null)
                this.colunmNameList = obj.colunmNameList.ToObject<List<string>>();
            this.ContextMenuStrip = new ContextMenuStrip();
        }
        /*
        internal void initListView(ListView listView)
        {
            ColumnHeader header;
            listView.Items.Clear();
            listView.Columns.Clear();
            foreach (string headerString in this.colunmNameList)
            {
                // MessageBox.Show(headerString);
                header = new ColumnHeader();
                header.Text = headerString;
                listView.Columns.Add(header);
            }
        }
        */
    }
}
