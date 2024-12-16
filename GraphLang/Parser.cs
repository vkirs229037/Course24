using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Security.Principal;
using System.Transactions;
using Microsoft.VisualBasic;

namespace GraphLang;

public class Parser(List<Token> tokens)
{
    readonly List<Token> tokens = tokens;
    Dictionary<string, string> labels = [];
    Dictionary<Node, List<Node>> graph = [];
    List<Node> nodes = [];
    Dictionary<Tuple<Token, Token>, int> weights_tok = [];
    Dictionary<Tuple<Node, Node>, int> weights = [];
    Stack<List<Token>> node_stack = [];
    Stack<Token> op_stack = [];
    int cursor = 0;

    public List<Node> Nodes {
        get { return nodes; }
        set { }
    }

    public Dictionary<Node, List<Node>> Graph {
        get { return graph; }
        set { }
    }

    public Dictionary<Tuple<Node, Node>, int> Weights {
        get { return weights; }
        set { }
    }

    List<List<Token>> into_stmts() {
        List<List<Token>> result = [];
        List<Token> stmt = [];
        foreach (Token token in tokens) {
            if (token.type is not TokenType.Semicolon) {
                stmt.Add(token);
            } else {
                result.Add(stmt);
                stmt = [];
            }
        }
        return result;
    }

    void parse_stmt(List<Token> stmt) {
        bool in_list = false;
        List<Token> temp_list = [];

        while (cursor < stmt.Count) {
            Token token = stmt[cursor];
            if (in_list) {
                switch (token.type) {
                    case TokenType.RBracket:
                        in_list = false;
                        node_stack.Push(temp_list);
                        temp_list = [];
                        cursor++;
                        break;
                    case TokenType.Label | TokenType.Command | TokenType.Weight:
                        throw new Exception("Команды не могут быть в списке");
                    case TokenType.Id:
                        temp_list.Add(token);
                        cursor++;
                        break;
                    default:
                        throw new Exception("Ошибка при парсинге");
                }
            } else {
                switch (token.type) {
                    case TokenType.Id:
                        node_stack.Push([token]);
                        cursor++;
                        break;
                    case TokenType.Dash or TokenType.Arrow:
                        op_stack.Push(token);
                        cursor++;
                        break;
                    case TokenType.Label:
                        parse_label(stmt);
                        break;
                    case TokenType.Command:
                        parse_command(stmt);
                        break;
                    case TokenType.LBracket:
                        in_list = true;
                        cursor++;
                        break;
                    case TokenType.Weight:
                        parse_weight(stmt);
                        break;
                    default:
                        throw new Exception("Ошибка при парсинге");
                }
            }
        }

        cursor = 0;
    }

    void parse_label(List<Token> stmt) {
        cursor++;
        Token tok;
        try { tok = stmt[cursor]; }
        catch { throw new Exception("Неожиданный конец файла при чтении текста для вершины"); }

        if (tok.type != TokenType.Id) { throw new Exception("Текст может быть задан только для вершины"); }
        string id = tok.value;

        cursor += 2;
        
        try { tok = stmt[cursor]; }
        catch { throw new Exception("Неожиданный конец файла при чтении текста для вершины"); }
        
        if (tok.type != TokenType.String) { throw new Exception("Текст вершины не является строкой (заключенной в кавычки)"); }
        string label = tok.value;

        labels[id] = label;
        
        cursor += 3;
    }

    void parse_command(List<Token> stmt) {
        string command = stmt[cursor].value;
        switch (command) {
            case "bintree":
                parse_bintree(stmt);
                break;
            default:
                Utils.TODO("Команда {command} не реализована");
                break;
        }
    }

    void parse_weight(List<Token> stmt) {
        cursor++;
        Token tok1;
        try { tok1 = stmt[cursor]; }
        catch { throw new Exception("Неожиданный конец файла при чтении вершины"); }

        if (tok1.type != TokenType.Id) { throw new Exception("Вес может быть задан только для пар вершин"); }

        cursor++;
        
        Token tok2;
        try { tok2 = stmt[cursor]; }
        catch { throw new Exception("Неожиданный конец файла при чтении вершины"); }

        if (tok2.type != TokenType.Id) { throw new Exception("Вес может быть задан только для пар вершин"); }
        
        cursor++;

        Token w;
        try { w = stmt[cursor]; }
        catch { throw new Exception("Неожиданный конец файла при чтении веса"); }

        if (w.type != TokenType.Numlit) { throw new Exception("Значение веса должно быть десятичным числом (начинаться с #)"); }

        int w_value;
        try {
            w_value = Convert.ToInt32(w.value);
        }
        catch {
            throw new Exception("Значение веса не являлось верным десятичным числом");
        }

        Tuple<Token, Token> tok_pair = new(tok1, tok2);
        weights_tok[tok_pair] = w_value;

        cursor += 2;
    }

    void parse_bintree(List<Token> stmt) {
        cursor++;
        Token arg = stmt[cursor];
        switch (arg.type) {
            case TokenType.Id:
                node_stack.Push([arg]);
                cursor += 2;
                break;
            case TokenType.LBracket:
                cursor++;
                List<Token> arg_list = [];
                while (true) {
                    Token current = stmt[cursor];
                    if (current.type == TokenType.RBracket) {
                        cursor++;
                        break;
                    }
                    if (current.type != TokenType.Id) {
                        throw new Exception("В списке может быть только идентификатор вершины");
                    }
                    arg_list.Add(current);
                    cursor++;
                }
                bintree(arg_list);
                break;
        }
    }

    void bintree(List<Token> vertices) {
        int N = vertices.Count;
        int head = 0;
        int depth = 0;

        while (head < N) {
            Token root = vertices[head];
            // int arg_shift = (head + 1) % (int)Math.Pow(2, depth);
            int left_offset = /*arg_shift +*/ depth + (int)Math.Pow(2, depth);
            if (head + left_offset >= N) {
                break;
            } else {
                Token left = vertices[head + left_offset];
                node_stack.Push([root]);
                node_stack.Push([left]);
                op_stack.Push(new Token(TokenType.Dash, "-"));
            }
            int right_offset = /*arg_shift +*/ depth + 1 + (int)Math.Pow(2, depth);
            if (head + right_offset >= N) {
                break;
            } else {
                Token right = vertices[head + right_offset];
                node_stack.Push([root]);
                node_stack.Push([right]);
                op_stack.Push(new Token(TokenType.Dash, "-"));
            }
            depth += head switch {
                _ when head + 1 < (int)Math.Pow(2, depth) => 0,
                _ => 1,
            };
            head += 1;
        }
    }

    void interpret() {
        while (!(op_stack.Count == 0)) {
            Token op = op_stack.Pop();
            List<Token> a = node_stack.Pop();
            List<Token> b = node_stack.Pop();

            foreach (Token tok1 in a) {
                if (!labels.TryGetValue(tok1.value, out string? label1)) 
                    label1 = "";
                foreach (Token tok2 in b) {
                    if (!labels.TryGetValue(tok2.value, out string? label2))
                        label2 = "";
                    Node n1 = new(tok1.value, label1);
                    Node n2 = new(tok2.value, label2);
                    if (!graph.TryGetValue(n2, out List<Node>? n2_value)) {
                        n2_value = ([]);
                        graph[n2] = n2_value;
                    }
                    n2_value.Add(n1);
                    if (op.type == TokenType.Dash) {
                        if (!graph.TryGetValue(n1, out List<Node>? n1_value)) {
                            n1_value = ([]);
                            graph[n1] = n1_value;
                        }
                        n1_value.Add(n2);
                    }
                    // Другой случай - токен является оператором "стрелка".
                    // Тогда нет связи n1 -> n2
                    if (!nodes.Contains(n1)) nodes.Add(n1);
                    if (!nodes.Contains(n2)) nodes.Add(n2);
                }
            }
        }

        while (!(node_stack.Count == 0)) {
            List<Token> a = node_stack.Pop();
            foreach (Token tok in a) {
                if (!labels.TryGetValue(tok.value, out string? label)) 
                    label = "";
                Node n = new(tok.value, label);
                if (!graph.ContainsKey(n)) {
                    graph[n] = [];
                }
            }
        }

        foreach (var tok_weight_pair in weights_tok) {
            Tuple<Token, Token> tok_pair_tup = tok_weight_pair.Key;
            Tuple<string, string> tok_pair = new(tok_pair_tup.Item1.value, tok_pair_tup.Item2.value);
            int weight = tok_weight_pair.Value;
            List<string> node_names = nodes.Select(n => n.name).ToList();
            int idx1 = node_names.FindIndex(n => n == tok_pair.Item1);
            int idx2 = node_names.FindIndex(n => n == tok_pair.Item2);
            if (idx1 >= 0 && idx2 >= 0) {
                Node n1 = nodes[idx1];
                Node n2 = nodes[idx2];
                Tuple<Node, Node> node_tup = new(n1, n2);
                weights[node_tup] = weight;
            }
        }
    }

    public void Parse() {
        List<List<Token>> stmts = into_stmts();
        foreach (List<Token> stmt in stmts) {
            parse_stmt(stmt);
        }
        interpret();
    }
}
