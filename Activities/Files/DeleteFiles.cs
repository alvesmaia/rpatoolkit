using System.Collections.Generic;
using System.Linq;
using System.Activities;
using System.ComponentModel;
using System.IO;

namespace RPAToolkit.Activities.Files
{
    public class DeleteFiles : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<string[]> Pattern { get; set; }

        [Category("Input")]
        public InArgument<string> RootPath { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var pattern = Pattern.Get(context);
            var rootpath = RootPath.Get(context);

            List<string> files = new List<string>();
            foreach (var search in pattern)
            {
                files.AddRange(Directory.GetFiles(rootpath, search, SearchOption.AllDirectories).ToList());
            }

            foreach (var item in files)
            {
                File.Delete(item);
            }


        }
    }
}