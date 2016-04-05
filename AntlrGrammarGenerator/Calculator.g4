grammar Calculator;
 
@parser::members
{
    protected const int EOF = Eof;
}
 
@lexer::members
{
    protected const int EOF = Eof;
    protected const int HIDDEN = Hidden;
}
 
/*
 * Parser Rules
 */

expr 
	: plusOrMinus	# ToPlusOrMinus
	;

plusOrMinus 
	: plusOrMinus PLUS multOrDivOrMod	# Plus
	| plusOrMinus MINUS multOrDivOrMod	# Minus
	| multOrDivOrMod					# ToMultOrDivOrMod
	;

multOrDivOrMod
	: multOrDivOrMod MULT pow	# Multiplication
	| multOrDivOrMod DIV pow	# Division
	| multOrDivOrMod MOD pow	# Modulo
	| pow						# ToPow
	;

pow
	: unaryMinus POW pow # Power
	| unaryMinus		 # ToUnaryMinus
	;

unaryMinus
	: MINUS unaryMinus	# ChangeSign
	| atom				# ToAtom
	;

atom 
	: num						# Number
	| var						# Variable
	| const						# Constant
	| funcName LPAR expr RPAR	# Function
	| LPAR expr RPAR			# Braces
	;
 
funcName
	: ABS	# FuncAbs
	;

const 
	: PI	# ContantePi
	; 

relop
	: EQ
	| NE
	| GT
	| GE
	| LT
	| LE
	;
	
num 
	: DIGIT+ (DOT DIGIT+)?
	;

var 
	: LETTER (LETTER | DIGIT | UNDERSCORE)*
	;

/*
 * Lexer Rules
 */

/** Functions */
ABS : 'abs' | 'ABS' | 'Abs';

/** Constants */
PI : 'pi' | 'PI' | 'Pi';

/** Operators */
PLUS  : '+';
MINUS : '-';
MULT  : '*';
DIV   : '/';
POW   : '^';
MOD   : '%';

/** Relation Operators */
EQ : '=';
NE : '<>';
GT : '>';
GE : '>=';
LT : '<';
LE : '<=';

/** Basis */
LPAR		: '(';
RPAR		: ')';
DOT			: '.';
UNDERSCORE	: '_';
LETTER		: [a-zA-Z];
DIGIT		: [0-9];

WS : (' ' | '\r' | '\n') -> channel(HIDDEN);