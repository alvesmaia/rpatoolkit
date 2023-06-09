using System.Linq;
using System.Activities;
using System.ComponentModel;
using System.Diagnostics;
using System;

namespace RPAToolkit.Activities.Application
{
    public class KillExistingProcess : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<string[]> Processes { get; set; }

        [Category("Input")]
        [DisplayName("Continue on Error")]
        [Description("Specifies whether the activity should continue execution if an error occurs.")]
        public bool ContinueOnError { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            try
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
            catch (Exception ex)
            {
                if (!ContinueOnError)
                {
                    throw ex;
                }
                else
                {
                    // Log the error or handle it in a desired way
                }
            }
        }

    }
}