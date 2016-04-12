grammar Evaluator;
 
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
	;

const 
	: PI	# ContantePi
	; 
	
num 
	: NUMBER
	;

str
	: STRING
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
TRUE  : 'true' | 'True' | 'TRUE';
FALSE : 'false' | 'False' | 'FALSE';

/** Basis */
OBRACE		: '(';
CBRACE		: ')';

ID
	: [a-zA-Z] [a-zA-Z_0-9]*
	;

NUMBER
	: [0-9]+ ('.' [0-9]+)?
	;

STRING
	: '"' (~["\r\n] | '""')* '"'
	;

WS : (' ' | '\r' | '\n') -> channel(HIDDEN);