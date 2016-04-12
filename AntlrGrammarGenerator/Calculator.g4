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
 /*
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
	*/
expr
 : MINUS expr                           # ChangeSign
 | NOT expr                             # Not
 | expr POW<assoc=right> expr           # Power
 | expr op=(MULT | DIV | MOD) expr      # MultOrDivOrModExpr
 | expr op=(PLUS | MINUS) expr          # PlusOrMinusExpr
 | expr op=(LE | GE | LT | GT) expr		# RelationalExpr
 | expr op=(EQ | NE) expr               # EqualityExpr
 | expr AND expr                        # AndExpr
 | expr OR expr                         # OrExpr
 | atom                                 # ToAtomExpr
 ;

atom 
	: funcName OBRACE expr CBRACE	# Function
	| OBRACE expr CBRACE			# Braces
	| num							# Number
	| bool							# Boolean
	| const							# Constant
	| var							# Variable
	| str							# String
	;

 
funcName
	: var
	;

var 
: ID
	//: LETTER (LETTER | DIGIT | UNDERSCORE)*
	;

const 
	: PI	# ContantePi
	; 
	
num 
: NUMBER
	//: DIGIT+ (DOT DIGIT+)?
	;

str
: STRING
	//: QUOTE (LETTER | DIGIT | UNDERSCORE | SPACE)* QUOTE
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
OBRACE		: '(';
CBRACE		: ')';
//DOT			: '.';
QUOTE		: '"';
//SPACE		: ' ';
//UNDERSCORE	: '_';
//LETTER		: [a-zA-Z];
//DIGIT		: [0-9];


ID
	: [a-zA-Z] [a-zA-Z_0-9]*
	;

NUMBER
	: [0-9]+ ('.' [0-9]+)?
	;

STRING
	: QUOTE (~["\r\n] | '""')* QUOTE
	;

WS : (' ' | '\r' | '\n') -> channel(HIDDEN);