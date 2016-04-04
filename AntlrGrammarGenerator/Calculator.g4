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
 
expr : expr (TIMES | DIV) expr   # MulDiv
     | expr (PLUS | MINUS) expr   # AddSub
     | atom                  # atom
     | '(' expr ')'         # parens
     ;

atom 
	: number
	| variable
	| func LPAREN expr RPAREN #Func
	| LPAREN expr RPAREN
	;
 
func
	: ABS
	;

relop
	: EQ
	| NE
	| GT
	| GE
	| LT
	| LE
	;
	
number : MINUS? DIGIT+ (POINT DIGIT+)?

variable : MINUS? LETTER (LETTER | DIGIT | UNDERSCORE)*;

/*
 * Lexer Rules
 */

/** Functions */
ABS : 'abs' | 'ABS' | 'Abs';

/** Operators */
PLUS : '+';
MINUS : '-';
TIMES : '*';
DIV : '/';
POW : '^';
MODULO : '%'

/** Relation Operators */
EQ : '=';
NE : '<>';
GT : '>';
GE : '>='
LT : '<';
LE : '<=';

/** Basis */
LPAREN : '(';
RPAREN : ')';
DOT : '.';
UNDERSCORE : '_';
LETTER : [a-zA-Z];
DIGIT : [0-9];

WS : (' ' | '\r' | '\n') -> channel(HIDDEN);