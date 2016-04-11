namespace MathParser
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using Antlr4.Runtime;

    public class CalculatorVisitor : CalculatorBaseVisitor<CalculatorValue>
    {
        private const double MinValue = 0.0000000001;

        private readonly Dictionary<string, Func<double, double>> functionsByName; 
        private readonly Dictionary<string, object> variableToValue;

        public CalculatorVisitor()
            : this(new Dictionary<string, object>())
        {
        }

        public CalculatorVisitor(Dictionary<string, object> variableToValue)
        {
            this.variableToValue = variableToValue;
            this.functionsByName = new Dictionary<string, Func<double, double>>()
                {
                    {"abs", Math.Abs}
                };
        }

        public override CalculatorValue VisitChangeSign(CalculatorParser.ChangeSignContext context)
        {
            return new CalculatorValue(-1 * this.GetDouble(this.Visit(context.expr())));
        }

        public override CalculatorValue VisitNot(CalculatorParser.NotContext context)
        {
            return new CalculatorValue(! this.GetBool(this.Visit(context.expr())));
        }

        public override CalculatorValue VisitPower(CalculatorParser.PowerContext context)
        {
            return new CalculatorValue(this.VisitBinaryOperation(context, CalculatorParser.POW));
        }

        public override CalculatorValue VisitMultOrDivOrModExpr(CalculatorParser.MultOrDivOrModExprContext context)
        {
            return new CalculatorValue(this.VisitBinaryOperation(context, context.op.Type));
        }

        public override CalculatorValue VisitPlusOrMinusExpr(CalculatorParser.PlusOrMinusExprContext context)
        {
            return new CalculatorValue(this.VisitBinaryOperation(context, context.op.Type));
        }

        private double VisitBinaryOperation(ParserRuleContext context, int op)
        {
            var left = this.GetDouble(this.WalkLeft(context));
            var right = this.GetDouble(this.WalkRight(context));

            switch (op)
            {
                case CalculatorParser.PLUS:
                    return left + right;
                case CalculatorParser.MINUS:
                    return left - right;
                case CalculatorParser.MULT:
                    return left * right;
                case CalculatorParser.DIV:
                    return left / right;
                case CalculatorParser.MOD:
                    return left % right;
                case CalculatorParser.POW:
                    return Math.Pow(left, right);
                default:
                    throw new EvaluationException("Invalid arithmetic operator !");
            }
        }

        public override CalculatorValue VisitRelationalExpr(CalculatorParser.RelationalExprContext context)
        {
            return new CalculatorValue(this.VisitRelationalExpr(context, context.op.Type));
        }

        private bool VisitRelationalExpr(ParserRuleContext context, int op)
        {
            var left = this.GetDouble(this.WalkLeft(context));
            var right = this.GetDouble(this.WalkRight(context));

            switch (op)
            {
                case CalculatorParser.GE:
                    return left >= right;
                case CalculatorParser.GT:
                    return left > right;
                case CalculatorParser.LE:
                    return left <= right;
                case CalculatorParser.LT:
                    return left < right;
                default:
                    throw new EvaluationException("Invalid relational operator !");
            }
        }

        public override CalculatorValue VisitEqualityExpr(CalculatorParser.EqualityExprContext context)
        {
            return new CalculatorValue(this.VisitEqualityExpr(context, context.op.Type));
        }

        private bool VisitEqualityExpr(ParserRuleContext context, int op)
        {
            var left = this.WalkLeft(context);
            var right = this.WalkRight(context);

            switch (op)
            {
                case CalculatorParser.EQ:
                    return left.IsDouble() && right.IsDouble()
                        ? Math.Abs((double)left.value - (double)right.value) < MinValue
                        : left.value.Equals(right.value);
                case CalculatorParser.NE:
                    return left.IsDouble() && right.IsDouble()
                        ? Math.Abs((double)left.value - (double)right.value) >= MinValue
                        : !left.value.Equals(right.value);
                default:
                    throw new EvaluationException("Invalid equality operator !");
            }
        }

        public override CalculatorValue VisitAndExpr(CalculatorParser.AndExprContext context)
        {
            var left = this.GetBool(this.WalkLeft(context));
            var right = this.GetBool(this.WalkRight(context));

            return new CalculatorValue(left && right);
        }

        public override CalculatorValue VisitOrExpr(CalculatorParser.OrExprContext context)
        {
            var left = this.GetBool(this.WalkLeft(context));
            var right = this.GetBool(this.WalkRight(context));

            return new CalculatorValue(left || right);
        }

        public override CalculatorValue VisitFunction(CalculatorParser.FunctionContext context)
        {
            var functionName = context.funcName().GetText();
            Func<double, double> function;
            if (!this.functionsByName.TryGetValue(functionName.ToLower(), out function))
            {
                throw new EvaluationException(string.Format("Cannot find function '{0}'", functionName));
            }

            var parameter = this.Visit(context.expr());
            double doubleValue;
            if (!parameter.TryGetDouble(out doubleValue))
            {
                throw new EvaluationException(string.Format("For function '{0}', parameter has to be a double", functionName));
            }

            return new CalculatorValue(function(doubleValue));
        }

        public override CalculatorValue VisitBraces(CalculatorParser.BracesContext context)
        {
            return this.Visit(context.expr());
        }

        public override CalculatorValue VisitNumber(CalculatorParser.NumberContext context)
        {
            return new CalculatorValue(Convert.ToDouble(context.num().GetText(), CultureInfo.InvariantCulture));
        }

        public override CalculatorValue VisitBoolean(CalculatorParser.BooleanContext context)
        {
            return new CalculatorValue(Convert.ToBoolean(context.@bool().GetText().ToLower()));
        }

        public override CalculatorValue VisitVariable(CalculatorParser.VariableContext context)
        {
            var variableName = context.var().GetText();
            object value;
            if (!this.variableToValue.TryGetValue(variableName, out value))
            {
                throw new EvaluationException(string.Format("Cannot find variable '{0}'", variableName));
            }

            if (value is int)
                value = Convert.ToDouble(value, CultureInfo.InvariantCulture);

            return new CalculatorValue(value);
        }

        public override CalculatorValue VisitString(CalculatorParser.StringContext context)
        {
            var str = context.str().GetText();

            // Remove quote
            str = str.Substring(1, str.Length - 2).Replace("\"\"", "\""); ;

            return new CalculatorValue(str);
        }

        #region Constants
        public override CalculatorValue VisitContantePi(CalculatorParser.ContantePiContext context)
        {
            return new CalculatorValue(Math.PI);
        }
        #endregion


        #region Helper
        private CalculatorValue WalkLeft(ParserRuleContext context)
        {
            return this.Visit(context.GetRuleContext<ParserRuleContext>(0));
        }

        private CalculatorValue WalkRight(ParserRuleContext context)
        {
            return this.Visit(context.GetRuleContext<ParserRuleContext>(1));
        }

        private double GetDouble(CalculatorValue calculatorValue)
        {
            double doubleValue;
            if (!calculatorValue.TryGetDouble(out doubleValue))
            {
                throw new EvaluationException("Double attended");
            }
            return doubleValue;
        }

        private bool GetBool(CalculatorValue calculatorValue)
        {
            bool boolValue;
            if (!calculatorValue.TryGetBool(out boolValue))
            {
                throw new EvaluationException("Bool attended");
            }
            return boolValue;
        }

        private string GetString(CalculatorValue calculatorValue)
        {
            string stringValue;
            if (!calculatorValue.TryGetString(out stringValue))
            {
                throw new EvaluationException("String attended");
            }
            return stringValue;
        }
        #endregion
    }
}