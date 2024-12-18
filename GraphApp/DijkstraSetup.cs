using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphLang;

namespace GraphApp
{
    public partial class DijkstraSetup : Form
    {
        public int s;
        public int t;

        public DijkstraSetup(List<Vertex> vertices)
        {
            InitializeComponent();
            var vertices_copy = vertices.ToList();
            startComboBox.DataSource = vertices;
            endComboBox.DataSource = vertices_copy;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            object? s_vertex_obj = startComboBox.SelectedItem;
            object? t_vertex_obj = endComboBox.SelectedItem;

            if (s_vertex_obj is null || t_vertex_obj is null)
            {
                return;
            }

            s = ((Vertex)s_vertex_obj).id;
            t = ((Vertex)t_vertex_obj).id;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
