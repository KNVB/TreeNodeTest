using System.IO;
using Newtonsoft.Json.Linq;

namespace TreeNodeTest
{
    internal class UIObjFactory
    {
        JObject messageTextList;
        JObject labelList;
        JObject objectList;
        string json;
        internal UIObjFactory()
        {
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
        internal string getMessageText(string key)
        {
            return (string)messageTextList[key];
        }
        internal string getLabel(string key)
        {
            return (string)labelList[key];
        }
        internal JToken getObj(string key)
        {
            return objectList[key];
        }
    }
}
