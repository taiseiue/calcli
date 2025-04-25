using sly.parser;
using sly.parser.generator;

namespace calcli;
class Program
{
    static void Main(string[] args)
    {
        string expression = Console.ReadLine();

        var Parser = GetParser();
        var r = Parser.Parse(expression);

        if (!r.IsError)
        {
            Console.WriteLine($"result of <{expression}>  is {(int)r.Result}");
        }
        else
        {
            if (r.Errors != null && r.Errors.Any())
            {
                r.Errors.ForEach(error => Console.WriteLine(error.ErrorMessage));
            }
        }
    }
    public static Parser<ExpressionToken, int> GetParser()
    {
        var parserInstance = new ExpressionParser();
        var builder = new ParserBuilder<ExpressionToken, int>();
        var Parser = builder.BuildParser(parserInstance, ParserType.LL_RECURSIVE_DESCENT, "expression").Result;

        return Parser;
    }
}
