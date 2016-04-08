namespace MathParser
{
    using System;
    using System.Collections.Generic;

    using Antlr4.Runtime;

    public class CalculatorVisitor : CalculatorBaseVisitor<double>
    {
        private readonly Dictionary<string, Func<double, double>> functionsByName; 
        private readonly Dictionary<string, double> variableToValue;

        public CalculatorVisitor()
            : this(new Dictionary<string, double>())
        {
        }

        public CalculatorVisitor(Dictionary<string, double> variableToValue)
        {
            this.variableToValue = variableToValue;
            this.functionsByName = new Dictionary<string, Func<double, double>>()
                {
                    {"abs", Math.Abs}
                };
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
            return -1 * this.Visit(context.unaryExpr());
        }

        public override double VisitFunction(CalculatorParser.FunctionContext context)
        {
            var functionName = context.funcName().GetText();
            Func<double, double> function;
            if (!this.functionsByName.TryGetValue(functionName.ToLower(), out function))
            {
                throw new CalculatorException(string.Format("Cannot find function '{0}'", functionName));
            }

            var parameter = this.Visit(context.plusOrMinusExpr());

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
            var variableName = context.var().GetText();
            double value;
            if (!this.variableToValue.TryGetValue(variableName, out value))
            {
                throw new CalculatorException(string.Format("Cannot find variable '{0}'", variableName));
            }
                
            return value;
        }

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