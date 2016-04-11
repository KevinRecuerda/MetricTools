namespace MathParser.Tests
{
    using System.Collections.Generic;

    using Antlr4.Runtime;
    using Antlr4.Runtime.Tree;

    using NFluent;

    using NUnit.Framework;

    [TestFixture]
    public class CalculatorListenerTests
    {
        [Test]
        public void Should_have_no_variable_When_WalkListener()
        {
            var calculatorListener = this.CreateTreeAndWalkListener("2 + 3");

            Assert.IsEmpty(calculatorListener.Variables);
        }

        [Test]
        public void Should_have_one_variable_When_WalkListener()
        {
            var calculatorListener = this.CreateTreeAndWalkListener("2 * x + 3");

            Check.That(calculatorListener.Variables).ContainsExactly(new List<string>() { "x" });
        }

        [Test]
        public void Should_have_several_variables_When_WalkListener()
        {
            var calculatorListener = this.CreateTreeAndWalkListener(@"2 * x + 3 * y + 2 ^ power + IsOk * 5 + (Car = ""Any"") * 3");

            Check.That(calculatorListener.Variables).ContainsExactly(new List<string>() { "x", "y", "power", "IsOk", "Car" });
        }

        private CalculatorListener CreateTreeAndWalkListener(string expression)
        {
            var input = new AntlrInputStream(expression);
            var lexer = new CalculatorLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new CalculatorParser(tokens);
            IParseTree tree = parser.expr();

            var calculatorListener = new CalculatorListener();
            var walker = new ParseTreeWalker();
            walker.Walk(calculatorListener, tree);

            return calculatorListener;
        }
    }
}