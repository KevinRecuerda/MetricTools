using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using NUnit.Framework;

namespace MathParser.Tests
{
    public class Class1
    {
        [Test]
        public void Should()
        {
            const string Formula = "2*3";
            AntlrInputStream input = new AntlrInputStream(Formula);
            CalculatorLexer lexer = new CalculatorLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CalculatorParser parser = new CalculatorParser(tokens);
            IParseTree tree = parser.prog();
            Console.WriteLine(tree.ToStringTree(parser));

            CalculatorVisitor visitor = new CalculatorVisitor();

            var actual = visitor.Visit(tree);

            Assert.AreEqual(6, actual);
        }
    }
}
