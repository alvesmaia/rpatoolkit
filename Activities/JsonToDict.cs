using System.Collections.Generic;
using System.Activities;
using System.ComponentModel;
using Newtonsoft.Json;

namespace RPAToolkit.Activities
{
    [DisplayName("JSON to Dictionary")]
    [Description("Convert a JSON as string into a dictionary<string, object>")]
    public class JsonToDict : CodeActivity
    {
        [DisplayName("JSON")]
        [Description("Enter the JSON content as string")]
        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> Json { get; set; }

        [Description("Result")]
        [Category("Output")]
        [RequiredArgument]
        public OutArgument<Dictionary<string, object>> Dictionary { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var json = Json.Get(context);

            Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            Dictionary.Set(context, result);
        }
    }
}