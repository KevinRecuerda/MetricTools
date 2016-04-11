namespace MathParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Antlr4.Runtime;
    using Antlr4.Runtime.Tree;

    public class Expression
    {
        private readonly CalculatorParser parser;
        private readonly IParseTree tree;

        public Expression(string expression)
        {
            this.OriginalExpression = expression;

            this.parser = this.CreateParser(expression);
            var errorListener = this.CreateErrorListener(this.parser);

            this.tree = this.Parse(this.parser, errorListener);

            this.Variables = this.ExtractVariables(this.tree);
        }

        public string OriginalExpression { get; set; }

        public List<string> Variables { get; set; }

        public T Evaluate<T>(Dictionary<string, object> parameters = null)
        {
            var visitor = new CalculatorVisitor(parameters);

            var actual = visitor.Visit(this.tree);

            if (typeof(T) == typeof(double) || typeof(T) == typeof(bool))
            {
                return (T)actual.value;
            }

            throw new NotSupportedException(string.Format("Can't evaluate for result of type '{0}' !", typeof(T)));
        }

        public string ToStringTree()
        {
            return this.tree.ToStringTree(this.parser);
        }

        private CalculatorParser CreateParser(string expression)
        {
            var input = new AntlrInputStream(expression);
            var lexer = new CalculatorLexer(input);
            var tokens = new CommonTokenStream(lexer);
            return new CalculatorParser(tokens);
        }

        private ThrowingErrorListener CreateErrorListener(CalculatorParser calculatorParser)
        {
            var throwingErrorListener = new ThrowingErrorListener();
            calculatorParser.AddErrorListener(throwingErrorListener);
            return throwingErrorListener;
        }

        private IParseTree Parse(CalculatorParser calculatorParser, ThrowingErrorListener throwingErrorListener)
        {
            IParseTree parseTree = calculatorParser.expr();

            if (throwingErrorListener.Errors.Any())
                throw new ParsingException(string.Join(Environment.NewLine, throwingErrorListener.Errors));

            return parseTree;
        }

        private List<string> ExtractVariables(IParseTree parseTree)
        {
            var calculatorListener = new CalculatorListener();
            var walker = new ParseTreeWalker();
            
            walker.Walk(calculatorListener, parseTree);

            return calculatorListener.Variables;
        }
    }
}