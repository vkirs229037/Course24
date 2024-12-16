using System;
using System.Collections.Immutable;
using System.Dynamic;
using System.Globalization;

namespace GraphLang;

public struct Vertex(string name, string label, int id)
{
    public string name = name;
    public string label = label;
    public int id = id;

    public static implicit operator Node(Vertex v) => new(v.name, v.label);
    public override string ToString()
    {
        if (string.IsNullOrEmpty(label)) {
            return $"[ID {id}] {name}";
        }
        return $"[ID {id}] {name}: {label}";
    }
}

public class Graph
{
    static private int LAST_ID = -1;
    static private int LastId 
    {
        get { LAST_ID++; return LAST_ID; }
        set { }
    }
    private int[,] incidence_matrix;
    private List<Vertex> vertices;

    public List<Vertex> Vertices {
        get { return vertices; }
        set { }
    }

    public int this[int i, int j] {
        get => incidence_matrix[i, j];
    }

    public Graph(List<Node> nodes, Dictionary<Node, List<Node>> node_connections, Dictionary<Tuple<Node, Node>, int> weights) {
        int n = nodes.Count;
        incidence_matrix = new int[n, n];
        var nodes_sorted = nodes;
        nodes_sorted.Sort((x, y) => x.name.CompareTo(y.name));
        vertices = nodes_sorted.Select(n => new Vertex(n.name, n.label, LastId)).ToList();
        foreach (Vertex v1 in vertices) {
            foreach (Vertex v2 in vertices) {
                if (node_connections.ContainsKey(v1) && node_connections[v1].Contains(v2)) {
                    Tuple<Node, Node> node_tup = new(v1, v2);
                    int w = weights.GetValueOrDefault(node_tup, 1);
                    incidence_matrix[v1.id, v2.id] = w;
                }
                else {
                    incidence_matrix[v1.id, v2.id] = 0;
                }
            }
        }
    }

    public void Print() {
        foreach (Vertex v in vertices) {
            Console.WriteLine(v);
        }
        int width = vertices.Max(v => v.name.Length);
        string format = $"{{0, {width}}} ";
        Console.Write(format, " ");
        foreach (Vertex v in vertices) {
            Console.Write(format, v.name);
        }
        Console.Write("\n");
        for (int i = 0; i < incidence_matrix.GetLength(0); i++) {
            Console.Write(format, vertices[i].name);
            for (int j = 0; j < incidence_matrix.GetLength(0); j++) {
                Console.Write(format, incidence_matrix[i, j]);
            } 
            Console.Write("\n");
        }
    }
}
