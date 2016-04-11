namespace MathParser.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics;

    using NUnit.Framework;

    [TestFixture]
    public class MathParserServiceTests
    {
        private MathParserService mathParserService;

        [SetUp]
        public void SetUp()
        {
            this.mathParserService = new MathParserService();
        }

        [Test]
        public void Should_throw_exception_When_Parse_bad_formula()
        {
            var actual = Assert.Throws<ParsingException>(() => this.mathParserService.Parse("2 + 3)"));

            Assert.IsTrue(actual.Message.StartsWith("line 1:5"));
        }

        [Test]
        public void Should_return_correct_double_When_Evaluate()
        {
            var parameters = new Dictionary<string, object>()
                {
                    {"x", 3},
                    {"y", 5},
                    {"isOk", true},
                    {"car", "any"},
                };

            const string Formula = @"x*y^2 + isOk * 100 + !isOk * 50 + (car = ""any"") * 1000 + (car != ""no"") * 500";
            var expression = this.mathParserService.Parse(Formula);

            var actual = this.mathParserService.Evaluate<double>(expression, parameters);

            Assert.AreEqual(75 + 100 + 1000 + 500, actual);
        }

        [Test]
        public void Should_return_correct_bool_When_Evaluate()
        {
            var parameters = new Dictionary<string, object>()
                {
                    {"x", 3},
                    {"y", 5},
                    {"isOk", true},
                    {"car", "any"},
                };

            const string Formula = @"x < y && isOk || car = ""any""";
            var expression = this.mathParserService.Parse(Formula);

            var actual = this.mathParserService.Evaluate<bool>(expression, parameters);

            Assert.AreEqual(true, actual);
        }
        // TODO : same experssion, multiple dico
    }
}