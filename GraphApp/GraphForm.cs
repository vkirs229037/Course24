using GraphLang;
using Microsoft.Msagl.GraphViewerGdi;

namespace GraphApp
{
    public partial class GraphForm : Form
    {
        Compiler compiler;
        Graph graph;
        GViewer viewer;

        public GraphForm()
        {
            InitializeComponent();
        }

        private void GraphForm_Load(object sender, EventArgs e)
        {

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
    }
}
