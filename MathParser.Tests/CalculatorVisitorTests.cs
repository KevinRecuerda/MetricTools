﻿namespace MathParser.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    using Antlr4.Runtime;
    using Antlr4.Runtime.Tree;

    using NUnit.Framework;

    [TestFixture]
    public class CalculatorVisitorTests
    {
        [TestCase("1", 1)]
        [TestCase("1.5", 1.5)]
        [TestCase("true", true)]
        [TestCase("false", false)]
        [TestCase(@"""OK""", @"OK")]
        public void Should_recognize_atom_When_Visit(string expression, object expected)
        {
            var tree = ParseTree(expression);
            var visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.AreEqual(expected, actual.value);
        }

        [TestCase("1", 1)]
        [TestCase("-1", -1)]
        [TestCase("2+3", 5)]
        [TestCase("2-3", -1)]
        [TestCase("2*3", 6)]
        [TestCase("2/3", 0.6667)]
        [TestCase("2^3", 8)]
        [TestCase("5%2", 1)]
        public void Should_compute_simple_expression_When_Visit(string expression, double expected)
        {
            var tree = ParseTree(expression);
            var visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.IsTrue(actual.IsDouble());
            Assert.AreEqual(expected, (double)actual.value, 0.001);
        }

        [TestCase("1 / 2 * 3", 1.5)]
        [TestCase("3 / 3 / 2", 0.5)]
        [TestCase("2 ^ 2 ^ 3", 64)]
        [TestCase("40 + 10 - (2*40) + (100/40) + 0.2", -27.3)]
        public void Should_manage_priority_When_Visit(string expression, double expected)
        {
            var tree = ParseTree(expression);
            var visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.IsTrue(actual.IsDouble());
            Assert.AreEqual(expected, (double)actual.value, 0.001);
        }

        [TestCase("2 * -3", -6)]
        public void Should_manage_unary_minus_When_Visit(string expression, double expected)
        {
            var tree = ParseTree(expression);
            var visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.IsTrue(actual.IsDouble());
            Assert.AreEqual(expected, (double)actual.value, 0.001);
        }

        [TestCase("!true", false)]
        [TestCase("!false", true)]
        public void Should_manage_not_When_Visit(string expression, bool expected)
        {
            var tree = ParseTree(expression);
            var visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.IsTrue(actual.IsBool());
            Assert.AreEqual(expected, (bool)actual.value);
        }

        [TestCase("PI + 3", 6.14159)]
        public void Should_manage_constant_When_Visit(string expression, double expected)
        {
            var tree = ParseTree(expression);
            var visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.IsTrue(actual.IsDouble());
            Assert.AreEqual(expected, (double)actual.value, 0.001);
        }

        [TestCase("ABS(3)", 3)]
        [TestCase("ABS(-3)", 3)]
        public void Should_manage_functions_When_Visit(string expression, double expected)
        {
            var tree = ParseTree(expression);

            var visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.IsTrue(actual.IsDouble());
            Assert.AreEqual(expected, (double)actual.value, 0.001);
        }

        [Test]
        public void Should_throw_calculator_exception_When_Visit_With_unknown_function()
        {
            const string expression = "func(1)";
            var tree = ParseTree(expression);
            var variableToValue = new Dictionary<string, object>();
            var visitor = new CalculatorVisitor(variableToValue);

            Assert.Throws<EvaluationException>(() => visitor.Visit(tree), "Cannot find function 'func'");
        }

        [Test]
        public void Should_manage_one_variable_When_Visit()
        {
            const string expression = "x + 1";
            const double X = 3;
            const double Expected = X + 1;

            var tree = ParseTree(expression);
            var variableToValue = new Dictionary<string, object>() { { "x", X } };
            var visitor = new CalculatorVisitor(variableToValue);

            var actual = visitor.Visit(tree);

            Assert.IsTrue(actual.IsDouble());
            Assert.AreEqual(Expected, (double)actual.value, 0.001);
        }

        [Test]
        public void Should_throw_calculator_exception_When_Visit_With_unknown_variable()
        {
            const string expression = "x + 1";
            var tree = ParseTree(expression);
            var variableToValue = new Dictionary<string, object>();
            var visitor = new CalculatorVisitor(variableToValue);

            Assert.Throws<EvaluationException>(() => visitor.Visit(tree), "Cannot find variable 'x'");
        }

        [Test]
        public void Should_manage_multiple_appearance_for_same_variable_When_Visit()
        {
            const string expression = "x^2 + x + 1";
            const double X = 3;
            const double Expected = X*X + X + 1;

            var tree = ParseTree(expression);
            var variableToValue = new Dictionary<string, object>() { { "x", X } };
            var visitor = new CalculatorVisitor(variableToValue);

            var actual = visitor.Visit(tree);

            Assert.IsTrue(actual.IsDouble());
            Assert.AreEqual(Expected, (double)actual.value, 0.001);
        }

        [Test]
        public void Should_manage_multiple_variables_When_Visit()
        {
            const string expression = "x^2 + y^2";
            const double X = 3, Y = 4;
            const double Expected = X * X + Y * Y;

            var tree = ParseTree(expression);
            var variableToValue = new Dictionary<string, object>() { { "x", X }, { "y", Y } };
            var visitor = new CalculatorVisitor(variableToValue);

            var actual = visitor.Visit(tree);

            Assert.IsTrue(actual.IsDouble());
            Assert.AreEqual(Expected, (double)actual.value, 0.001);
        }
        
        [TestCase("2.5 < 3", true)]
        [TestCase("2.5 <= 3", true)]
        [TestCase("2.5 > 3", false)]
        [TestCase("2.5 >= 3", false)]
        public void Should_manage_relational_operators_When_Visit_With_double(string expression, bool expected)
        {
            var tree = ParseTree(expression);
            var visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.IsTrue(actual.IsBool());
            Assert.AreEqual(expected, (bool)actual.value);
        }

        [TestCase("2.5 = 3", false)]
        [TestCase("2.5 != 3", true)]
        [TestCase("true = false", false)]
        [TestCase("true = true", true)]
        [TestCase(@"""OK"" = ""OK""", true)]
        [TestCase(@"""OK"" = ""OK  """, false)]
        public void Should_manage_equality_operators_When_Visit(string expression, bool expected)
        {
            var tree = ParseTree(expression);
            var visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.IsTrue(actual.IsBool());
            Assert.AreEqual(expected, (bool)actual.value);
        }

        [TestCase("true  && true",  true)]
        [TestCase("true  && false", false)]
        [TestCase("false && true",  false)]
        [TestCase("false && false", false)]
        [TestCase("true  || true",  true)]
        [TestCase("true  || false", true)]
        [TestCase("false || true",  true)]
        [TestCase("false || false", false)]
        [TestCase("2.5 > 3 || 2.5 <= 2.5", true)]
        [TestCase("2.5 > 3 || 2.5 < 2.5", false)]
        public void Should_manage_logical_operators_When_Visit(string expression, bool expected)
        {
            var tree = ParseTree(expression);
            var visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.IsTrue(actual.IsBool());
            Assert.AreEqual(expected, (bool)actual.value);
        }

        [Test]
        public void Should_should_when_when()
        {
            // TODO : Manage Regex
            // TODO : op : =~ et !=~
            Regex regex = new Regex(@".*Future Option.*");
            Match match = regex.Match("Equity Fture Option");
            if (match.Success)
            {
                Trace.WriteLine(match.Value);
            }
        }

        private static IParseTree ParseTree(string expression)
        {
            var input = new AntlrInputStream(expression);
            var lexer = new CalculatorLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new CalculatorParser(tokens);

            IParseTree tree = parser.expr();

            Trace.WriteLine(tree.ToStringTree(parser));

            return tree;
        }
    }
}