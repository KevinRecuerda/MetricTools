namespace Evaluator.Tests
{
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    public class ExpressionTests
    {
        [Test]
        public void Should_throw_exception_When_Parse_bad_formula()
        {
            var actual = Assert.Throws<ParsingException>(() => new Expression("2 + 3)"));

            Assert.IsTrue(actual.Message.StartsWith("line 1:5"));
        }

        [Test]
        public void Should_return_correct_double_When_Evaluate()
        {
            const string Formula = @"x*y^2 + isOk * 100 + !isOk * 50 + (car = ""any"") * 1000 + (car != ""no"") * 500";
            var expression = new Expression(Formula);

            var parameters = new Dictionary<string, object>()
                {
                    {"x", 3},
                    {"y", 5},
                    {"isOk", true},
                    {"car", "any"},
                };
            var actual = expression.Evaluate<double>(parameters);

            Assert.AreEqual(75 + 100 + 1000 + 500, actual);
        }

        [Test]
        public void Should_return_correct_bool_When_Evaluate()
        {
            const string Formula = @"x < y && isOk || car = ""any""";
            var expression = new Expression(Formula);

            var parameters = new Dictionary<string, object>()
                {
                    {"x", 3},
                    {"y", 5},
                    {"isOk", true},
                    {"car", "any"},
                };
            var actual = expression.Evaluate<bool>(parameters);

            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Should_return_different_values_When_Evaluate_With_different_parameters()
        {
            var expression = new Expression("x ^2 + y");

            var parameters = new Dictionary<string, object> { { "x", 3 }, { "y", -0.5 } };
            var actual = expression.Evaluate<double>(parameters);
            Assert.AreEqual(8.5, actual);

            parameters["x"] = 5;
            actual = expression.Evaluate<double>(parameters);
            Assert.AreEqual(24.5, actual);
        }
    }
}