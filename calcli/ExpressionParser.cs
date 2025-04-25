using sly.lexer;
using sly.parser.generator;

public class ExpressionParser
{
    [Production("expression: INT")]
    public int intExpr(Token<ExpressionToken> intToken)
    {
        return intToken.IntValue;
    }

    [Production("expression: term PLUS expression")]
    public int PlusExpression(int left, Token<ExpressionToken> operatorToken, int right)
    {
        return left + right;
    }
    [Production("expression: term MINUS expression")]
    public int MinusExpression(int left, Token<ExpressionToken> operatorToken, int right)
    {
        return left - right;
    }
    [Production("expression: term TIMES expression")]
    public int TimesExpression(int left, Token<ExpressionToken> operatorToken, int right)
    {
        return left * right;
    }
    [Production("expression: term DIVIDE expression")]
    public int DivideExpression(int left, Token<ExpressionToken> operatorToken, int right)
    {
        return left / right;
    }

    [Production("term: INT")]
    public int Expression(Token<ExpressionToken> intToken)
    {
        return intToken.IntValue;
    }
}