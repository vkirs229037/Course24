using System;

namespace GraphLang;

public class Compiler
{
    string content;

    public Compiler(string filename) {
        content = File.ReadAllText(filename);
    }

    public Graph Compile() {
        Lexer lexer = new(content);
        lexer.Lex();
        Parser parser = new(lexer.Tokens);
        parser.Parse();
        Graph graph = new(parser.Nodes, parser.Graph, parser.Weights);
        return graph;
    }
}
