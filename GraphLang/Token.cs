using System;

namespace GraphLang;

public enum TokenType {
    Id, // [A-z0-9]
    Label, // "label"
    Weight, // "weight"
    Command, // команда 
    Dash, // -
    Arrow, // >, для задания орграфов
    LBrace, // {
    RBrace, // }
    LParen, // (
    RParen, // )
    LBracket, // [
    RBracket, // ]
    Semicolon, // ;
    Quote, // "
    String, // строка (label)
    Numlit, // Число
    Eof, // конец файла
    Error // ошибка
}

public struct Token(TokenType type, string value)
{
    public TokenType type = type;
    public string value = value;
}
