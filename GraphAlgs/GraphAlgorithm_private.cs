using System.Dynamic;
using System.Reflection.Metadata;
using GraphLang;

namespace GraphAlgs;

public static partial class GraphAlgorithm {
    // Вычисление всех вершин, соединенных с заданной
    // Предполагается, что в set содержится один элемент: v
    static HashSet<int> connections(Graph g, int v, int size) {
        HashSet<int> set = [v];
        HashSet<int> prev_set = [];
        while (!prev_set.SetEquals(set)) {
            prev_set = set;
            HashSet<int> temp_set = [];
            foreach (int xi in set) {
                for (int i = 0; i < size; i++) {
                    if (g[xi, i] != 0) temp_set.Add(i);
                }
            }
            set = set.Union(temp_set).ToHashSet();
        }
        return set;
    }

    static List<int> row(Graph g, int row_i) {
        List<int> row = [];
        int n = g.Vertices.Count;
        for (int i = 0; i < n; i++) {
            int gi = g[row_i, i];
            row.Add(gi);
        }
        return row;
    }

    static List<int> col(Graph g, int col_i) {
        List<int> col = [];
        int n = g.Vertices.Count;
        for (int i = 0; i < n; i++) {
            int gi = g[i, col_i];
            col.Add(gi);
        }
        return col;
    }
}