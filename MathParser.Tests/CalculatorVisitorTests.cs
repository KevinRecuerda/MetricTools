namespace MathParser.Tests
{
    using System.Diagnostics;

    using Antlr4.Runtime;
    using Antlr4.Runtime.Tree;

    using NUnit.Framework;

    [TestFixture]
    public class CalculatorVisitorTests
    {
        [TestCase("1", 1)]
        [TestCase("-1", -1)]
        [TestCase("2+3", 5)]
        [TestCase("2-3", -1)]
        [TestCase("2*3", 6)]
        [TestCase("2/3", 0.6667)]
        [TestCase("2^3", 8)]
        [TestCase("5%2", 1)]
        public void Should_compute_simple_formula_When_Parse(string formula, double expected)
        {
            AntlrInputStream input = new AntlrInputStream(formula);
            CalculatorLexer lexer = new CalculatorLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CalculatorParser parser = new CalculatorParser(tokens);
            IParseTree tree = parser.expr();
            Trace.WriteLine(tree.ToStringTree(parser));

            CalculatorVisitor visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestCase("1 / 2 * 3", 1.5)]
        [TestCase("3 / 3 / 2", 0.5)]
        public void Should_manage_priority_When_Parse(string formula, double expected)
        {
            AntlrInputStream input = new AntlrInputStream(formula);
            CalculatorLexer lexer = new CalculatorLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CalculatorParser parser = new CalculatorParser(tokens);
            IParseTree tree = parser.expr();
            Trace.WriteLine(tree.ToStringTree(parser));

            CalculatorVisitor visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestCase("2 * -3", -6)]
        public void Should_manage_unary_minus_When_Parse(string formula, double expected)
        {
            AntlrInputStream input = new AntlrInputStream(formula);
            CalculatorLexer lexer = new CalculatorLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CalculatorParser parser = new CalculatorParser(tokens);
            IParseTree tree = parser.expr();
            Trace.WriteLine(tree.ToStringTree(parser));

            CalculatorVisitor visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestCase("PI + 3", 6.14159)]
        public void Should_manage_constant_When_Parse(string formula, double expected)
        {
            AntlrInputStream input = new AntlrInputStream(formula);
            CalculatorLexer lexer = new CalculatorLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CalculatorParser parser = new CalculatorParser(tokens);
            IParseTree tree = parser.expr();
            Trace.WriteLine(tree.ToStringTree(parser));

            CalculatorVisitor visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestCase("ABS(3)", 3)]
        [TestCase("ABS(-3)", 3)]
        public void Should_manage_functions_When_Parse(string formula, double expected)
        {
            AntlrInputStream input = new AntlrInputStream(formula);
            CalculatorLexer lexer = new CalculatorLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CalculatorParser parser = new CalculatorParser(tokens);
            IParseTree tree = parser.expr();
            Trace.WriteLine(tree.ToStringTree(parser));

            CalculatorVisitor visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.AreEqual(expected, actual, 0.001);
        }
    }
}