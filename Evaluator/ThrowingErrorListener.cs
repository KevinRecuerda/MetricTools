namespace Evaluator
{
    using System.Collections.Generic;

    using Antlr4.Runtime;

    public class ThrowingErrorListener : BaseErrorListener
    {
        public List<string> Errors { get; private set; }

        public ThrowingErrorListener()
        {
            this.Errors = new List<string>();
        }

        public override void SyntaxError(
            IRecognizer recognizer,
            IToken offendingSymbol,
            int line,
            int charPositionInLine,
            string msg,
            RecognitionException e)
        {
            this.Errors.Add(string.Format("line {0}:{1} {2}", line, charPositionInLine, msg));
        }
    }
}