namespace MathParser.Tests
{
    using System.Collections.Generic;
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
        public void Should_compute_simple_formula_When_Visit(string formula, double expected)
        {
            var tree = ParseTree(formula);
            var visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestCase("1 / 2 * 3", 1.5)]
        [TestCase("3 / 3 / 2", 0.5)]
        [TestCase("2 ^ 2 ^ 3", 0.5)]
        [TestCase("40 + 10 - (2*40) + (100/40) + 0.2", -27.3)]
        public void Should_manage_priority_When_Visit(string formula, double expected)
        {
            var tree = ParseTree(formula);
            var visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestCase("2 * -3", -6)]
        public void Should_manage_unary_minus_When_Visit(string formula, double expected)
        {
            var tree = ParseTree(formula);
            var visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestCase("PI + 3", 6.14159)]
        public void Should_manage_constant_When_Visit(string formula, double expected)
        {
            var tree = ParseTree(formula);
            var visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestCase("ABS(3)", 3)]
        [TestCase("ABS(-3)", 3)]
        public void Should_manage_functions_When_Visit(string formula, double expected)
        {
            var tree = ParseTree(formula);

            var visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [Test]
        public void Should_throw_calculator_exception_When_Visit_With_unknown_function()
        {
            const string Formula = "func(1)";
            var tree = ParseTree(Formula);
            var variableToValue = new Dictionary<string, double>();
            var visitor = new CalculatorVisitor(variableToValue);

            Assert.Throws<CalculatorException>(() => visitor.Visit(tree), "Cannot find function 'func'");
        }

        [Test]
        public void Should_manage_one_variable_When_Visit()
        {
            const string Formula = "x + 1";
            const double X = 3;
            const double Expected = X + 1;

            var tree = ParseTree(Formula);
            var variableToValue = new Dictionary<string, double>() { { "x", X } };
            var visitor = new CalculatorVisitor(variableToValue);

            var actual = visitor.Visit(tree);

            Assert.AreEqual(Expected, actual, 0.001);
        }

        [Test]
        public void Should_throw_calculator_exception_When_Visit_With_unknown_variable()
        {
            const string Formula = "x + 1";
            var tree = ParseTree(Formula);
            var variableToValue = new Dictionary<string, double>();
            var visitor = new CalculatorVisitor(variableToValue);

            Assert.Throws<CalculatorException>(() => visitor.Visit(tree), "Cannot find variable 'x'");
        }

        [Test]
        public void Should_manage_multiple_appearance_for_same_variable_When_Visit()
        {
            const string Formula = "x^2 + x + 1";
            const double X = 3;
            const double Expected = X*X + X + 1;

            var tree = ParseTree(Formula);
            var variableToValue = new Dictionary<string, double>() { { "x", X } };
            var visitor = new CalculatorVisitor(variableToValue);

            var actual = visitor.Visit(tree);

            Assert.AreEqual(Expected, actual, 0.001);
        }

        [Test]
        public void Should_manage_multiple_variables_When_Visit()
        {
            const string Formula = "x^2 + y^2";
            const double X = 3, Y = 4;
            const double Expected = X * X + Y * Y;

            var tree = ParseTree(Formula);
            var variableToValue = new Dictionary<string, double>() { { "x", X }, { "y", Y } };
            var visitor = new CalculatorVisitor(variableToValue);

            var actual = visitor.Visit(tree);

            Assert.AreEqual(Expected, actual, 0.001);
        }

        private static IParseTree ParseTree(string formula)
        {
            var input = new AntlrInputStream(formula);
            var lexer = new CalculatorLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new CalculatorParser(tokens);

            IParseTree tree = parser.expr();
            
            Trace.WriteLine(tree.ToStringTree(parser));
            Trace.WriteLine(parser.plusOrMinusExpr().ToStringTree(parser));

            return tree;
        }
    }
}