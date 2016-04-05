namespace MathParser
{
    using System;

    using Antlr4.Runtime;

    public class CalculatorVisitor : CalculatorBaseVisitor<double>
    {
        private readonly FunctionVisitor functionVisitor;

        public CalculatorVisitor()
        {
            this.functionVisitor = new FunctionVisitor();
        }

        public override double VisitPlus(CalculatorParser.PlusContext context)
        {
            return this.VisitBinaryOpHelper(context, (left, right) => left + right);
        }

        public override double VisitMinus(CalculatorParser.MinusContext context)
        {
            return this.VisitBinaryOpHelper(context, (left, right) => left - right);
        }

        public override double VisitMultiplication(CalculatorParser.MultiplicationContext context)
        {
            return this.VisitBinaryOpHelper(context, (left, right) => left * right);
        }

        public override double VisitDivision(CalculatorParser.DivisionContext context)
        {
            return this.VisitBinaryOpHelper(context, (left, right) => left / right);
        }

        public override double VisitModulo(CalculatorParser.ModuloContext context)
        {
            return this.VisitBinaryOpHelper(context, (left, right) => left % right);
        }

        public override double VisitPower(CalculatorParser.PowerContext context)
        {
            return this.VisitBinaryOpHelper(context, Math.Pow);
        }

        public override double VisitChangeSign(CalculatorParser.ChangeSignContext context)
        {
            return -1 * this.Visit(context.unaryMinus());
        }

        public override double VisitFunction(CalculatorParser.FunctionContext context)
        {
            var function = this.functionVisitor.Visit(context.funcName());
            var parameter = this.Visit(context.expr());

            return function(parameter);
        }

        public override double VisitBraces(CalculatorParser.BracesContext context)
        {
            return this.Visit(context.expr());
        }

        public override double VisitNumber(CalculatorParser.NumberContext context)
        {
            return Convert.ToDouble(context.num().GetText());
        }

        public override double VisitVariable(CalculatorParser.VariableContext context)
        {
            // TODO : KR : manage this
            return base.VisitVariable(context);
        }

        #region Functions
        private class FunctionVisitor : CalculatorBaseVisitor<Func<double, double>>
        {
            public override Func<double, double> VisitFuncAbs(CalculatorParser.FuncAbsContext context)
            {
                return Math.Abs;
            }
        }
        #endregion

        #region Constants
        public override double VisitContantePi(CalculatorParser.ContantePiContext context)
        {
            return Math.PI;
        }
        #endregion


        #region Helper
        private double VisitBinaryOpHelper(ParserRuleContext context, Func<double, double, double> apply)
        {
            var left = this.WalkLeft(context);
            var right = this.WalkRight(context);

            return apply(left, right);
        }

        private double WalkLeft(ParserRuleContext context)
        {
            return this.Visit(context.GetRuleContext<ParserRuleContext>(0));
        }

        private double WalkRight(ParserRuleContext context)
        {
            return this.Visit(context.GetRuleContext<ParserRuleContext>(1));
        }
        #endregion
    }
}