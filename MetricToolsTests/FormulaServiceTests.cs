using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MetricTools.Service;
using NUnit.Framework;

namespace MetricToolsTests
{
    [TestFixture]
    public class FormulaServiceTests
    {
        private FormulaService formulaService;

        [SetUp]
        public void SetUp()
        {
            this.formulaService = new FormulaService();
        }

        [TestCase("x")]
        [TestCase("(x)")]
        [TestCase("x+1")]
        [TestCase("1-x")]
        [TestCase("2*x")]
        [TestCase("x/2")]
        [TestCase("x%2")]
        [TestCase("x^2")]
        [TestCase("(x+1)")]
        [TestCase("(x+1)*2")]
        [TestCase("3*x+2")]
        [TestCase("x+1.5")]
        [TestCase("x+1,5")]
        public void Should_return_correct_variable_When_GetVariables_For_a_simple_formula(string formula)
        {
            var actual = this.formulaService.GetVariables(formula);

            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("x", actual.First());
        }

        [Test]
        public void Should_return_only_once_variable_When_GetVariables_With_multiple_variable_occurence()
        {
            var actual = this.formulaService.GetVariables("x+x");

            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("x", actual.First());
        }

        [Test]
        public void Should_return_variable_without_space_When_GetVariables_With_space()
        {
            Regex re = new Regex(@"([[\+\-\*\/\(\)\%\^\ \&]([\<\>\!]?=?))]");
            List<string> tokenList = re.Split("x <= 2 && x < 4").Select(t => t.Trim()).Where(t => t != "").ToList();

            var actual = this.formulaService.GetVariables("x + 1");

            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("x", actual.First());
        }

        [TestCase("1+2", 3)]
        [TestCase("2*3", 6)]
        [TestCase("4/2", 2)]
        [TestCase("4-2", 2)]
        [TestCase("3%2", 1)]
        [TestCase("4^2", 16)]
        public void Should_return_correct_result_When_Evaluate_For_a_formula_without_variable(string formula, double expected)
        {
            var actual = this.formulaService.Evaluate(formula);

            Assert.AreEqual(expected, actual);

            // make lexer
            // then parser

            // OPERATOR BINARY : +,-,*,/,%,^
            // NUMBER : [0-9]+[.0-9]?
            // VAR : [a-zA-Z_]

            // TokenFactory : Tokenize(string value)
        }
    }
}