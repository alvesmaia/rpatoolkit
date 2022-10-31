using System.Activities;
using System.Collections.Generic;


namespace RPAToolkit.Activities
{
    public sealed class BuildDictionary : CodeActivity<Dictionary<string, object>>
    {
        private Dictionary<string, InArgument<object>> values;

        public BuildDictionary()
        {
        }

        public BuildDictionary(InArgument<Dictionary<string, object>> dictionary) => this.Dictionary = dictionary;

        public InArgument<Dictionary<string, object>> Dictionary { get; set; }

        public Dictionary<string, InArgument<object>> Values
        {
            get
            {
                if (this.values == null)
                    this.values = (Dictionary<string, InArgument<object>>) new Dictionary<string, InArgument<object>>();
                return this.values;
            }
        }

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            metadata.AddRuntimeArgument<Dictionary<string, object>>(this.Dictionary, "Dictionary", false);
            if (this.values == null)
                return;
            int num = 1;
            foreach (KeyValuePair<string, InArgument<object>> keyValuePair in (IEnumerable<KeyValuePair<string, InArgument<object>>>)this.values)
            {
                string argumentName = "Value-" + (object)num++;
                metadata.AddRuntimeArgument<object>(keyValuePair.Value, argumentName, false);
            }
        }

        protected override Dictionary<string, object> Execute(CodeActivityContext context)
        {
            Dictionary<string, object> dictionary1 = this.Dictionary.Get((ActivityContext)context);
            Dictionary<string, object> dictionary2;
            if (dictionary1 == null)
            {
                dictionary2 = (Dictionary<string, object>) new Dictionary<string, object>();
            }
            else
            {
                dictionary2 = (Dictionary<string, object>) new Dictionary<string, object>(dictionary1);
            }
            if (this.values != null)
            {
                foreach (KeyValuePair<string, InArgument<object>> keyValuePair in (IEnumerable<KeyValuePair<string, InArgument<object>>>)this.values)
                {
                    if (!dictionary2.ContainsKey(keyValuePair.Key))
                    {
                        dictionary2.Add(keyValuePair.Key, keyValuePair.Value.Get((ActivityContext)context));
                    }
                }
            }
            return dictionary2;
        }
    }
}
