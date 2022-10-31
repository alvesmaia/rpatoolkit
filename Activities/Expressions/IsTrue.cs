using System.Activities;
using System.ComponentModel;

namespace RPAToolkit.Activities.Expressions
{
    [Description("Returns the result of a boolean expression")]
    public class IsTrue : CodeActivity<bool>
    {
        [Category("Input")]
        [RequiredArgument]
        
        public InArgument<bool> Condition { get; set; }

        protected override bool Execute(CodeActivityContext context) => this.Condition.Get((ActivityContext)context);
    }
}
