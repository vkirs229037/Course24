using System.Data;
using System.Runtime.Versioning;
using GraphLang;

namespace GraphAlgs;

public static partial class GraphAlgorithm
{
    // Алгоритм Дейкстры для нахождения кратчайшего пути между 
    // двумя вершинами. Предполагается, что все веса в графе неотрицательные.
    public static (int, List<int>) Dijkstra(Graph G, int s, int t) {
        // Инициализация 
        Dictionary<int, int> l_temp = new();
        Dictionary<int, int> l_const = new() 
        {
            [s] = 0
        };
        foreach (Vertex v in G.Vertices) {
            if (v.id != s) {
                l_temp[v.id] = int.MaxValue;
            }
        }
        int p = s;
        int n = G.Vertices.Count;
        // Поиск кратчайшего пути
        while (p != t) {
            List<int> Gp = row(G, p);
            foreach (int xi in l_temp.Keys) {
                int c = Gp[xi];
                if (c == 0) continue;
                l_temp[xi] = int.Min(l_temp[xi], l_const[p] + c);
            }
            KeyValuePair<int, int> min_l = l_temp.MinBy(kvp => kvp.Value);
            int xi_star = min_l.Key;
            l_const[xi_star] = min_l.Value;
            l_temp.Remove(xi_star);
            p = xi_star;
        }
        int d = l_const[p];
        // Вычисление путя
        List<int> path = [p];
        while (p != s) {
            int xi = p;
            // Можно убрать, просто напрямую из матрицы получить c
            List<int> Gp = col(G, xi);
            foreach (int xi_prime in l_const.Keys) {
                if (xi_prime == p) break;
                int c = Gp[xi_prime];
                if (l_const[xi_prime] + c == l_const[xi]) {
                    p = xi_prime;
                    path.Add(xi_prime);
                    break;
                }
            }
        }
        path.Reverse();

        return (d, path);
    }

    // Матрица достижимостей для графа.
    // Ее нахождение, вообще говоря, имеет смысл только
    // для орграфа; для неориентированного связного графа 
    // матрица будет состоять из одних единиц.
    public static int[,] ReachabilityMatrix(Graph g) {
        int size = g.Vertices.Count;
        int[,] result = new int[size, size];
        foreach (Vertex v in g.Vertices) {
            HashSet<int> conns = connections(g, v.id, size);
            for (int i = 0; i < size; i++) {
                result[v.id, i] = conns.Contains(i) ? 1 : 0;
            }
        }
        return result;
    }
}
