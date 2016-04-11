namespace MathParser
{
    using System.Collections.Generic;

    public class CalculatorListener : CalculatorBaseListener
    {
        public List<string> Variables { get; set; }

        public CalculatorListener()
        {
            this.Variables = new List<string>();
        }

        public override void EnterVariable(CalculatorParser.VariableContext context)
        {
            this.Variables.Add(context.GetText());
            base.EnterVariable(context);
        }
    }
}