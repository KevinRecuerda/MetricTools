//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.3
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from D:\GitHub-Perso\MetricTools\Evaluator.Grammar\Evaluator.g4 by ANTLR 4.3

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

namespace Evaluator.AutoGeneratedByGrammar {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.3")]
[System.CLSCompliant(false)]
public partial class EvaluatorLexer : Lexer {
	public const int
		PI=1, PLUS=2, MINUS=3, MULT=4, DIV=5, POW=6, MOD=7, AND=8, OR=9, EQ=10, 
		NE=11, NOT=12, GT=13, GE=14, LT=15, LE=16, TRUE=17, FALSE=18, OBRACE=19, 
		CBRACE=20, ID=21, NUMBER=22, STRING=23, WS=24;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] tokenNames = {
		"'\\u0000'", "'\\u0001'", "'\\u0002'", "'\\u0003'", "'\\u0004'", "'\\u0005'", 
		"'\\u0006'", "'\\u0007'", "'\b'", "'\t'", "'\n'", "'\\u000B'", "'\f'", 
		"'\r'", "'\\u000E'", "'\\u000F'", "'\\u0010'", "'\\u0011'", "'\\u0012'", 
		"'\\u0013'", "'\\u0014'", "'\\u0015'", "'\\u0016'", "'\\u0017'", "'\\u0018'"
	};
	public static readonly string[] ruleNames = {
		"PI", "PLUS", "MINUS", "MULT", "DIV", "POW", "MOD", "AND", "OR", "EQ", 
		"NE", "NOT", "GT", "GE", "LT", "LE", "TRUE", "FALSE", "OBRACE", "CBRACE", 
		"ID", "NUMBER", "STRING", "WS"
	};


	    protected const int EOF = Eof;
	    protected const int HIDDEN = Hidden;


	public EvaluatorLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	public override string GrammarFileName { get { return "Evaluator.g4"; } }

	public override string[] TokenNames { get { return tokenNames; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2\x1A\xAA\b\x1\x4"+
		"\x2\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b"+
		"\x4\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4"+
		"\x10\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14\x4\x15"+
		"\t\x15\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x4\x19\t\x19\x3\x2\x3\x2"+
		"\x3\x2\x3\x2\x3\x2\x3\x2\x5\x2:\n\x2\x3\x3\x3\x3\x3\x4\x3\x4\x3\x5\x3"+
		"\x5\x3\x6\x3\x6\x3\a\x3\a\x3\b\x3\b\x3\t\x3\t\x3\t\x3\n\x3\n\x3\n\x3\v"+
		"\x3\v\x3\v\x5\vQ\n\v\x3\f\x3\f\x3\f\x3\f\x5\fW\n\f\x3\r\x3\r\x3\xE\x3"+
		"\xE\x3\xF\x3\xF\x3\xF\x3\x10\x3\x10\x3\x11\x3\x11\x3\x11\x3\x12\x3\x12"+
		"\x3\x12\x3\x12\x3\x12\x3\x12\x3\x12\x3\x12\x3\x12\x3\x12\x3\x12\x3\x12"+
		"\x5\x12q\n\x12\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13"+
		"\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x5\x13\x82\n\x13\x3"+
		"\x14\x3\x14\x3\x15\x3\x15\x3\x16\x3\x16\a\x16\x8A\n\x16\f\x16\xE\x16\x8D"+
		"\v\x16\x3\x17\x6\x17\x90\n\x17\r\x17\xE\x17\x91\x3\x17\x3\x17\x6\x17\x96"+
		"\n\x17\r\x17\xE\x17\x97\x5\x17\x9A\n\x17\x3\x18\x3\x18\x3\x18\x3\x18\a"+
		"\x18\xA0\n\x18\f\x18\xE\x18\xA3\v\x18\x3\x18\x3\x18\x3\x19\x3\x19\x3\x19"+
		"\x3\x19\x2\x2\x2\x1A\x3\x2\x3\x5\x2\x4\a\x2\x5\t\x2\x6\v\x2\a\r\x2\b\xF"+
		"\x2\t\x11\x2\n\x13\x2\v\x15\x2\f\x17\x2\r\x19\x2\xE\x1B\x2\xF\x1D\x2\x10"+
		"\x1F\x2\x11!\x2\x12#\x2\x13%\x2\x14\'\x2\x15)\x2\x16+\x2\x17-\x2\x18/"+
		"\x2\x19\x31\x2\x1A\x3\x2\a\x4\x2\x43\\\x63|\x6\x2\x32;\x43\\\x61\x61\x63"+
		"|\x3\x2\x32;\x5\x2\f\f\xF\xF$$\x5\x2\f\f\xF\xF\"\"\xB7\x2\x3\x3\x2\x2"+
		"\x2\x2\x5\x3\x2\x2\x2\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2\x2\v\x3\x2\x2"+
		"\x2\x2\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2\x2\x13\x3\x2"+
		"\x2\x2\x2\x15\x3\x2\x2\x2\x2\x17\x3\x2\x2\x2\x2\x19\x3\x2\x2\x2\x2\x1B"+
		"\x3\x2\x2\x2\x2\x1D\x3\x2\x2\x2\x2\x1F\x3\x2\x2\x2\x2!\x3\x2\x2\x2\x2"+
		"#\x3\x2\x2\x2\x2%\x3\x2\x2\x2\x2\'\x3\x2\x2\x2\x2)\x3\x2\x2\x2\x2+\x3"+
		"\x2\x2\x2\x2-\x3\x2\x2\x2\x2/\x3\x2\x2\x2\x2\x31\x3\x2\x2\x2\x3\x39\x3"+
		"\x2\x2\x2\x5;\x3\x2\x2\x2\a=\x3\x2\x2\x2\t?\x3\x2\x2\x2\v\x41\x3\x2\x2"+
		"\x2\r\x43\x3\x2\x2\x2\xF\x45\x3\x2\x2\x2\x11G\x3\x2\x2\x2\x13J\x3\x2\x2"+
		"\x2\x15P\x3\x2\x2\x2\x17V\x3\x2\x2\x2\x19X\x3\x2\x2\x2\x1BZ\x3\x2\x2\x2"+
		"\x1D\\\x3\x2\x2\x2\x1F_\x3\x2\x2\x2!\x61\x3\x2\x2\x2#p\x3\x2\x2\x2%\x81"+
		"\x3\x2\x2\x2\'\x83\x3\x2\x2\x2)\x85\x3\x2\x2\x2+\x87\x3\x2\x2\x2-\x8F"+
		"\x3\x2\x2\x2/\x9B\x3\x2\x2\x2\x31\xA6\x3\x2\x2\x2\x33\x34\ar\x2\x2\x34"+
		":\ak\x2\x2\x35\x36\aR\x2\x2\x36:\aK\x2\x2\x37\x38\aR\x2\x2\x38:\ak\x2"+
		"\x2\x39\x33\x3\x2\x2\x2\x39\x35\x3\x2\x2\x2\x39\x37\x3\x2\x2\x2:\x4\x3"+
		"\x2\x2\x2;<\a-\x2\x2<\x6\x3\x2\x2\x2=>\a/\x2\x2>\b\x3\x2\x2\x2?@\a,\x2"+
		"\x2@\n\x3\x2\x2\x2\x41\x42\a\x31\x2\x2\x42\f\x3\x2\x2\x2\x43\x44\a`\x2"+
		"\x2\x44\xE\x3\x2\x2\x2\x45\x46\a\'\x2\x2\x46\x10\x3\x2\x2\x2GH\a(\x2\x2"+
		"HI\a(\x2\x2I\x12\x3\x2\x2\x2JK\a~\x2\x2KL\a~\x2\x2L\x14\x3\x2\x2\x2MQ"+
		"\a?\x2\x2NO\a?\x2\x2OQ\a?\x2\x2PM\x3\x2\x2\x2PN\x3\x2\x2\x2Q\x16\x3\x2"+
		"\x2\x2RS\a>\x2\x2SW\a@\x2\x2TU\a#\x2\x2UW\a?\x2\x2VR\x3\x2\x2\x2VT\x3"+
		"\x2\x2\x2W\x18\x3\x2\x2\x2XY\a#\x2\x2Y\x1A\x3\x2\x2\x2Z[\a@\x2\x2[\x1C"+
		"\x3\x2\x2\x2\\]\a@\x2\x2]^\a?\x2\x2^\x1E\x3\x2\x2\x2_`\a>\x2\x2` \x3\x2"+
		"\x2\x2\x61\x62\a>\x2\x2\x62\x63\a?\x2\x2\x63\"\x3\x2\x2\x2\x64\x65\av"+
		"\x2\x2\x65\x66\at\x2\x2\x66g\aw\x2\x2gq\ag\x2\x2hi\aV\x2\x2ij\at\x2\x2"+
		"jk\aw\x2\x2kq\ag\x2\x2lm\aV\x2\x2mn\aT\x2\x2no\aW\x2\x2oq\aG\x2\x2p\x64"+
		"\x3\x2\x2\x2ph\x3\x2\x2\x2pl\x3\x2\x2\x2q$\x3\x2\x2\x2rs\ah\x2\x2st\a"+
		"\x63\x2\x2tu\an\x2\x2uv\au\x2\x2v\x82\ag\x2\x2wx\aH\x2\x2xy\a\x63\x2\x2"+
		"yz\an\x2\x2z{\au\x2\x2{\x82\ag\x2\x2|}\aH\x2\x2}~\a\x43\x2\x2~\x7F\aN"+
		"\x2\x2\x7F\x80\aU\x2\x2\x80\x82\aG\x2\x2\x81r\x3\x2\x2\x2\x81w\x3\x2\x2"+
		"\x2\x81|\x3\x2\x2\x2\x82&\x3\x2\x2\x2\x83\x84\a*\x2\x2\x84(\x3\x2\x2\x2"+
		"\x85\x86\a+\x2\x2\x86*\x3\x2\x2\x2\x87\x8B\t\x2\x2\x2\x88\x8A\t\x3\x2"+
		"\x2\x89\x88\x3\x2\x2\x2\x8A\x8D\x3\x2\x2\x2\x8B\x89\x3\x2\x2\x2\x8B\x8C"+
		"\x3\x2\x2\x2\x8C,\x3\x2\x2\x2\x8D\x8B\x3\x2\x2\x2\x8E\x90\t\x4\x2\x2\x8F"+
		"\x8E\x3\x2\x2\x2\x90\x91\x3\x2\x2\x2\x91\x8F\x3\x2\x2\x2\x91\x92\x3\x2"+
		"\x2\x2\x92\x99\x3\x2\x2\x2\x93\x95\a\x30\x2\x2\x94\x96\t\x4\x2\x2\x95"+
		"\x94\x3\x2\x2\x2\x96\x97\x3\x2\x2\x2\x97\x95\x3\x2\x2\x2\x97\x98\x3\x2"+
		"\x2\x2\x98\x9A\x3\x2\x2\x2\x99\x93\x3\x2\x2\x2\x99\x9A\x3\x2\x2\x2\x9A"+
		".\x3\x2\x2\x2\x9B\xA1\a$\x2\x2\x9C\xA0\n\x5\x2\x2\x9D\x9E\a$\x2\x2\x9E"+
		"\xA0\a$\x2\x2\x9F\x9C\x3\x2\x2\x2\x9F\x9D\x3\x2\x2\x2\xA0\xA3\x3\x2\x2"+
		"\x2\xA1\x9F\x3\x2\x2\x2\xA1\xA2\x3\x2\x2\x2\xA2\xA4\x3\x2\x2\x2\xA3\xA1"+
		"\x3\x2\x2\x2\xA4\xA5\a$\x2\x2\xA5\x30\x3\x2\x2\x2\xA6\xA7\t\x6\x2\x2\xA7"+
		"\xA8\x3\x2\x2\x2\xA8\xA9\b\x19\x2\x2\xA9\x32\x3\x2\x2\x2\xE\x2\x39PVp"+
		"\x81\x8B\x91\x97\x99\x9F\xA1\x3\x2\x3\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace Evaluator.AutoGeneratedByGrammar