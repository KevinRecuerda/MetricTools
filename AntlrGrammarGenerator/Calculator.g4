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
	: orExpr	# ToOrExpr
	;

orExpr
	: orExpr OR andExpr	# Or
	| andExpr			# ToAndExpr
	;

andExpr
	: andExpr AND equalityExpr	# And
	| equalityExpr				# ToEqualityExpr
	;

equalityExpr
	: equalityExpr EQ relationalExpr # Equal
	| equalityExpr NE relationalExpr # NotEqual
	| relationalExpr				 # ToRelationalExpr
	;

relationalExpr
	: relationalExpr GT plusOrMinusExpr # Greater
	| relationalExpr GE plusOrMinusExpr # GreaterOrEqual
	| relationalExpr LT plusOrMinusExpr # Lower
	| relationalExpr LE plusOrMinusExpr # LowerOrEqual
	| plusOrMinusExpr					# ToPlusOrMinusExpr
	;

plusOrMinusExpr 
	: plusOrMinusExpr PLUS multOrDivOrModExpr	# Plus
	| plusOrMinusExpr MINUS multOrDivOrModExpr	# Minus
	| multOrDivOrModExpr						# ToMultOrDivOrModExpr
	;

multOrDivOrModExpr
	: multOrDivOrModExpr MULT powExpr	# Multiplication
	| multOrDivOrModExpr DIV powExpr	# Division
	| multOrDivOrModExpr MOD powExpr	# Modulo
	| powExpr							# ToPowExpr
	;

powExpr
	: unaryExpr POW powExpr # Power
	| unaryExpr				# ToUnaryExpr
	;

unaryExpr
	: MINUS unaryExpr	# ChangeSign
	| NOT unaryExpr		# Not
	| atom				# ToAtom
	;

atom 
	: funcName LPAR plusOrMinusExpr RPAR	# Function
	| LPAR expr RPAR						# Braces
	| const									# Constant
	| num									# Number
	| str									# String
	| bool									# Boolean
	| var									# Variable
	;
 
funcName
	: var
	;

var 
	: LETTER (LETTER | DIGIT | UNDERSCORE)*
	;

const 
	: PI	# ContantePi
	; 
	
num 
	: DIGIT+ (DOT DIGIT+)?
	;

str
	: QUOTE (LETTER | DIGIT | UNDERSCORE | SPACE)* QUOTE
	;

bool
	: TRUE
	| FALSE
	;


/*
 * Lexer Rules
 */

/** Constants */
PI : 'pi' | 'PI' | 'Pi';

/** Operators */
PLUS  : '+';
MINUS : '-';
MULT  : '*';
DIV   : '/';
POW   : '^';
MOD   : '%';

/** Conditional Operators */
AND : '&&';
OR  : '||';

/** Equality Operators */
EQ : '='  | '==';
NE : '<>' | '!=';

/** Unary Operators */
NOT  : '!';

/** Relational Operators */
GT : '>';
GE : '>=';
LT : '<';
LE : '<=';

/** Booleans */
TRUE  : 'true';
FALSE : 'false';

/** Basis */
LPAR		: '(';
RPAR		: ')';
DOT			: '.';
QUOTE		: ';';
SPACE		: ' ';
UNDERSCORE	: '_';
LETTER		: [a-zA-Z];
DIGIT		: [0-9];

WS : (' ' | '\r' | '\n') -> channel(HIDDEN);