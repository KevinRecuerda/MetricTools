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
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="EvaluatorParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.3")]
[System.CLSCompliant(false)]
public interface IEvaluatorListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by the <c>ContantePi</c>
	/// labeled alternative in <see cref="EvaluatorParser.const"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterContantePi([NotNull] EvaluatorParser.ContantePiContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>ContantePi</c>
	/// labeled alternative in <see cref="EvaluatorParser.const"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitContantePi([NotNull] EvaluatorParser.ContantePiContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Variable</c>
	/// labeled alternative in <see cref="EvaluatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVariable([NotNull] EvaluatorParser.VariableContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Variable</c>
	/// labeled alternative in <see cref="EvaluatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVariable([NotNull] EvaluatorParser.VariableContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="EvaluatorParser.funcName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFuncName([NotNull] EvaluatorParser.FuncNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EvaluatorParser.funcName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFuncName([NotNull] EvaluatorParser.FuncNameContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="EvaluatorParser.var"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVar([NotNull] EvaluatorParser.VarContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EvaluatorParser.var"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVar([NotNull] EvaluatorParser.VarContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Number</c>
	/// labeled alternative in <see cref="EvaluatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumber([NotNull] EvaluatorParser.NumberContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Number</c>
	/// labeled alternative in <see cref="EvaluatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumber([NotNull] EvaluatorParser.NumberContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Power</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPower([NotNull] EvaluatorParser.PowerContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Power</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPower([NotNull] EvaluatorParser.PowerContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Function</c>
	/// labeled alternative in <see cref="EvaluatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunction([NotNull] EvaluatorParser.FunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Function</c>
	/// labeled alternative in <see cref="EvaluatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunction([NotNull] EvaluatorParser.FunctionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Boolean</c>
	/// labeled alternative in <see cref="EvaluatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoolean([NotNull] EvaluatorParser.BooleanContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Boolean</c>
	/// labeled alternative in <see cref="EvaluatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoolean([NotNull] EvaluatorParser.BooleanContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>PlusOrMinusExpr</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPlusOrMinusExpr([NotNull] EvaluatorParser.PlusOrMinusExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>PlusOrMinusExpr</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPlusOrMinusExpr([NotNull] EvaluatorParser.PlusOrMinusExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Constant</c>
	/// labeled alternative in <see cref="EvaluatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstant([NotNull] EvaluatorParser.ConstantContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Constant</c>
	/// labeled alternative in <see cref="EvaluatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstant([NotNull] EvaluatorParser.ConstantContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Not</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNot([NotNull] EvaluatorParser.NotContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Not</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNot([NotNull] EvaluatorParser.NotContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>ToAtomExpr</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterToAtomExpr([NotNull] EvaluatorParser.ToAtomExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>ToAtomExpr</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitToAtomExpr([NotNull] EvaluatorParser.ToAtomExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>ChangeSign</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterChangeSign([NotNull] EvaluatorParser.ChangeSignContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>ChangeSign</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitChangeSign([NotNull] EvaluatorParser.ChangeSignContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="EvaluatorParser.num"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNum([NotNull] EvaluatorParser.NumContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EvaluatorParser.num"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNum([NotNull] EvaluatorParser.NumContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="EvaluatorParser.str"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStr([NotNull] EvaluatorParser.StrContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EvaluatorParser.str"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStr([NotNull] EvaluatorParser.StrContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>OrExpr</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOrExpr([NotNull] EvaluatorParser.OrExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>OrExpr</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOrExpr([NotNull] EvaluatorParser.OrExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>AndExpr</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAndExpr([NotNull] EvaluatorParser.AndExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>AndExpr</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAndExpr([NotNull] EvaluatorParser.AndExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>String</c>
	/// labeled alternative in <see cref="EvaluatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterString([NotNull] EvaluatorParser.StringContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>String</c>
	/// labeled alternative in <see cref="EvaluatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitString([NotNull] EvaluatorParser.StringContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>MultOrDivOrModExpr</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMultOrDivOrModExpr([NotNull] EvaluatorParser.MultOrDivOrModExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>MultOrDivOrModExpr</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMultOrDivOrModExpr([NotNull] EvaluatorParser.MultOrDivOrModExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Braces</c>
	/// labeled alternative in <see cref="EvaluatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBraces([NotNull] EvaluatorParser.BracesContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Braces</c>
	/// labeled alternative in <see cref="EvaluatorParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBraces([NotNull] EvaluatorParser.BracesContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="EvaluatorParser.bool"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBool([NotNull] EvaluatorParser.BoolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="EvaluatorParser.bool"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBool([NotNull] EvaluatorParser.BoolContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>EqualityExpr</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEqualityExpr([NotNull] EvaluatorParser.EqualityExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>EqualityExpr</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEqualityExpr([NotNull] EvaluatorParser.EqualityExprContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>RelationalExpr</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRelationalExpr([NotNull] EvaluatorParser.RelationalExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>RelationalExpr</c>
	/// labeled alternative in <see cref="EvaluatorParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRelationalExpr([NotNull] EvaluatorParser.RelationalExprContext context);
}
} // namespace Evaluator.AutoGeneratedByGrammar
