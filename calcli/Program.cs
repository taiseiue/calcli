using sly.parser;
using sly.parser.generator;
using sly.parser.generator.visitor;
using System.Web;

namespace calcli;

class Program
{
    static void Main(string[] args)
    {
        Console.Write(">>");
        string expression = Console.ReadLine();

        var Parser = GetParser();
        var r = Parser.Parse(expression);

        if (!r.IsError)
        {
            var graphviz = new GraphVizEBNFSyntaxTreeVisitor<ExpressionToken, int>();
            var root = graphviz.VisitTree(r.SyntaxTree);
            var graph = graphviz.Graph.Compile();
            Console.WriteLine();
            Console.WriteLine("Syntax Tree(Graphviz):");
            Console.WriteLine($"https://dreampuf.github.io/GraphvizOnline/?engine=dot#{HttpUtility.UrlEncode(graph).Replace("+", "%20")}");
            Console.WriteLine();
            Console.WriteLine("Result:");
            Console.WriteLine($"{expression} = {(int)r.Result}");
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
