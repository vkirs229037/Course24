using System;

namespace GraphLang;

public struct Node(string name, string label)
{
    public string name = name;
    public string label = label;
}
