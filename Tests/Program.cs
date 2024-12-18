using GraphLang;
using GraphAlgs;

internal class Program
{
    private static void Main(string[] args)
    {
        Compiler compiler = new("D:\\Универ\\7 сем\\НИР\\Grapher\\Tests\\graph.txt");
        Graph graph = compiler.Compile();
        graph.Print();
        (int d, List<int> path) = GraphAlgorithm.Dijkstra(graph, 0, 5);
        Console.WriteLine("Путь между вершинами 1 и 6:");
        Console.WriteLine($"Длина {d}");
        foreach (int i in path)
        {
            Console.WriteLine(i);
        }
        int[,] r_matrix = GraphAlgorithm.ReachabilityMatrix(graph);
        Console.WriteLine("Матрица достижимости:");
        for (int i = 0; i < r_matrix.GetLength(0); i++)
        {
            for (int j = 0; j < r_matrix.GetLength(1); j++)
            {
                Console.Write($"{r_matrix[i, j]} ");
            }
            Console.Write("\n");
        }
    }
}