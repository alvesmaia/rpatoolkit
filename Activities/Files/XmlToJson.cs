using System.Activities;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Xml;

namespace RPAToolkit.Activities.Files
{
    public class XmlToJson : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> XmlPath { get; set; }

        [Category("Input")]
        public InArgument<string> JsonPath { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var xmlPath = XmlPath.Get(context);
            var jsonPath = JsonPath.Get(context);

            XmlDocument doc = new XmlDocument();
            var xmlString = System.IO.File.ReadAllText(xmlPath);
            doc.LoadXml(xmlString);
            System.IO.File.WriteAllText(jsonPath, JsonConvert.SerializeXmlNode(doc));

        }
    }
}