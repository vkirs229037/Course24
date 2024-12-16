namespace GraphLang;

public class Lexer(string content)
{
    readonly string content = content;
    int cursor = 0;
    bool is_reading_label = false;
    List<Token> tokens = [];

    public List<Token> Tokens {
        get { return tokens; }
        set { }
    }

    char? peek(int forward = 0) {
        return cursor + forward < content.Length ? content[cursor + forward] : null;
    }

    char? consume() {
        char? result = cursor < content.Length ? content[cursor] : null;
        cursor += 1;
        return result;
    }

    string take_id() {
        string result = "";
        while (char.IsLetterOrDigit(content[cursor])) {
            result += consume();
        }
        cursor--;
        return result;
    }

    string take_string() {
        string result = "";
        while (peek() != '"') {
            result += consume();
        }
        cursor--;
        return result;
    }

    Token set_reading() {
        is_reading_label = !is_reading_label;
        return new(TokenType.Quote, "\"");
    }

    Token get_token() {
        Token token;
        char c = content[cursor];

        if (is_reading_label) {
            if (c == '"') {
                token = set_reading();
            } else {
                token = new(TokenType.String, take_string());
            }
        } else {
            token = c switch {
                _ when char.IsLetterOrDigit(c) => parse_id(),
                '#' => parse_numlit(),
                ';' => new(TokenType.Semicolon, ";"),
                '-' => new(TokenType.Dash, "-"),
                ')' => new(TokenType.RParen, ")"),
                '(' => new(TokenType.LParen, "("),
                ']' => new(TokenType.RBracket, "]"),
                '[' => new(TokenType.LBracket, "["),
                '}' => new(TokenType.RBrace, "}"),
                '{' => new(TokenType.LBrace, "{"),
                '>' => new(TokenType.Arrow, ">"),
                '"' => set_reading(),
                _ => new(TokenType.Error, "Ошибка: неизвестный символ " + c),
            };
        }
        
        cursor++;
        return token;
    }

    Token parse_id() {
        string id_text = take_id();
        return id_text switch
        {
            "label" => new(TokenType.Label, id_text),
            "weight" => new(TokenType.Weight, id_text),
            "bintree" => new(TokenType.Command, id_text),
            _ => new(TokenType.Id, id_text),
        };
    }

    Token parse_numlit() {
        cursor++;
        string result = "";
        while (is_numeric(content[cursor])) {
            result += consume();
        }
        cursor--;
        return new(TokenType.Numlit, result);
    }

    bool is_numeric(char c) => char.IsDigit(c) || c == '-';

    // TODO ERROR HANDLING
    public List<Token> Lex() { 
        while (peek() is not null) {
            if (char.IsWhiteSpace(content[cursor])) {
                consume();
            } else {
                Token token = get_token();
                tokens.Add(token);
            }
        }
        tokens.Add(new(TokenType.Eof, ""));
        return tokens; 
    }
}