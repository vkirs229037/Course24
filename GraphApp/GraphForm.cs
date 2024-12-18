using GraphAlgs;
using GraphLang;
using Microsoft.Msagl.GraphViewerGdi;

namespace GraphApp
{
    using Drawing = Microsoft.Msagl.Drawing;
    public partial class GraphForm : Form
    {
        Compiler compiler;
        Graph graph;
        GViewer viewer;
        int[,] reachability_matrix;

        public GraphForm()
        {
            InitializeComponent();
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;
            string filename = openFileDialog.FileName;
            compiler = new(filename);
            graph = compiler.Compile();
            viewer = Create.Viewer(graph);
            SuspendLayout();
            viewer.Dock = DockStyle.Fill;
            Controls.Add(viewer);
            ResumeLayout();

            reachability_matrix = GraphAlgorithm.ReachabilityMatrix(graph);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new();
            about.ShowDialog();
        }

        private void reachableBtn_Click(object sender, EventArgs e)
        {
            answerLabel.Text = "";
            foreach (Vertex v in graph.Vertices)
            {
                viewer.Graph.FindNode(v.name).Attr.FillColor = Drawing.Color.White;
            }
            viewer.Refresh();

            ReachabilitySetup setup = new(graph.Vertices);
            if (setup.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            int chosen = setup.chosen_vertex;
            List<int> connections = [];

            for (int i = 0; i < graph.Vertices.Count; i++)
            {
                if (reachability_matrix[chosen, i] == 0)
                {
                    continue;
                }
                connections.Add(i);
            }

            foreach (int i in connections)
            {
                viewer.Graph.FindNode(graph.Vertices[i].name).Attr.FillColor = Drawing.Color.Red;
            }
            viewer.Graph.FindNode(graph.Vertices[chosen].name).Attr.FillColor = Drawing.Color.Blue;
            viewer.Refresh();
        }

        private void dijkstraBtn_Click(object sender, EventArgs e)
        {
            answerLabel.Text = "";
            foreach (Vertex v in graph.Vertices)
            {
                viewer.Graph.FindNode(v.name).Attr.FillColor = Drawing.Color.White;
            }
            viewer.Refresh();

            DijkstraSetup setup = new(graph.Vertices);
            if (setup.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            int s = setup.s;
            int t = setup.t;

            if (reachability_matrix[s, t] == 0)
            {
                MessageBox.Show("Между вершинами нет путя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            (int d, List<int> path) = GraphAlgorithm.Dijkstra(graph, s, t);

            answerLabel.Text = $"Кратчайший путь: {d}";
            foreach (int i in path[1..^1])
            {
                viewer.Graph.FindNode(graph.Vertices[i].name).Attr.FillColor = Drawing.Color.Red;
            }
            viewer.Graph.FindNode(graph.Vertices[s].name).Attr.FillColor = Drawing.Color.Green;
            viewer.Graph.FindNode(graph.Vertices[t].name).Attr.FillColor = Drawing.Color.Blue;
            viewer.Refresh();
        }
    }
}
