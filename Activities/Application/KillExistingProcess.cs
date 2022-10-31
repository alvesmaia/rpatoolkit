using System.Linq;
using System.Activities;
using System.ComponentModel;
using System.Diagnostics;

namespace RPAToolkit.Activities.Application
{
    public class KillExistingProcess : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<string[]> Processes { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string[] processes = Processes.Get(context);
            var myPID = Process.GetCurrentProcess().SessionId;

            foreach (var process in processes)
            {
                if (Process.GetProcessesByName(process).Count() > 0)
                {
                    var currentProcess = Process.GetProcessesByName(process);
                    currentProcess.Where(p => p.SessionId == myPID).ToArray();

                    foreach (var p in currentProcess)
                    {
                        p.Kill();
                    }

                }
            }


        }
    }
}