﻿namespace Evaluator.Tests
{
    using System.Collections.Generic;

    using Antlr4.Runtime;
    using Antlr4.Runtime.Tree;

    using Evaluator.AutoGeneratedByGrammar;

    using NFluent;

    using NUnit.Framework;

    [TestFixture]
    public class EvaluatorListenerTests
    {
        [Test]
        public void Should_have_no_variable_When_WalkListener()
        {
            var evaluatorListener = this.CreateTreeAndWalkListener("2 + 3");

            Assert.IsEmpty(evaluatorListener.Variables);
        }

        [Test]
        public void Should_have_one_variable_When_WalkListener()
        {
            var evaluatorListener = this.CreateTreeAndWalkListener("2 * x + 3");

            Check.That(evaluatorListener.Variables).ContainsExactly(new List<string>() { "x" });
        }

        [Test]
        public void Should_have_several_variables_When_WalkListener()
        {
            var evaluatorListener = this.CreateTreeAndWalkListener(@"2 * x + 3 * y + 2 ^ power + IsOk * 5 + (Car = ""Any"") * 3");

            Check.That(evaluatorListener.Variables).ContainsExactly(new List<string>() { "x", "y", "power", "IsOk", "Car" });
        }

        private EvaluatorListener CreateTreeAndWalkListener(string expression)
        {
            var input = new AntlrInputStream(expression);
            var lexer = new EvaluatorLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new EvaluatorParser(tokens);
            IParseTree tree = parser.expr();

            var evaluatorListener = new EvaluatorListener();
            var walker = new ParseTreeWalker();
            walker.Walk(evaluatorListener, tree);

            return evaluatorListener;
        }
    }
}