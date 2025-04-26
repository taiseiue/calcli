using sly.lexer;

public enum ExpressionToken
{

    [Lexeme("[0-9]+")]
    INT,

    [Lexeme("\\+")]
    PLUS,

    [Lexeme("\\-")]
    MINUS,

    [Lexeme("\\*")]
    TIMES,

    [Lexeme("\\*")]
    DIVIDE,

    [Lexeme("\\(")]
    LPAREN,

    [Lexeme("\\)")]
    RPAREN,

    [Lexeme("[ \\t]+", isSkippable: true)]
    WS

}
