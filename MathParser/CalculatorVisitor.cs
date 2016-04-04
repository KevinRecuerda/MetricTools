using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    public class CalculatorVisitor : CalculatorBaseVisitor<int>
    {
        public override int VisitInt(CalculatorParser.IntContext context)
        {
            return int.Parse(context.INT().GetText());
        }

        public override int VisitAddSub(CalculatorParser.AddSubContext context)
        {
            int left = Visit(context.expr(0));
            int right = Visit(context.expr(1));
            if (context.op.Type == CalculatorParser.ADD)
            {
                return left + right;
            }
            else
            {
                return left - right;
            }
        }

        public override int VisitMulDiv(CalculatorParser.MulDivContext context)
        {
            int left = Visit(context.expr(0));
            int right = Visit(context.expr(1));
            if (context.op.Type == CalculatorParser.MUL)
            {
                return left * right;
            }
            else
            {
                return left / right;
            }
        }

        public override int VisitParens(CalculatorParser.ParensContext context)
        {
            return Visit(context.expr());
        }
    }
}
