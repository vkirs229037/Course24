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
    public partial class ReachabilitySetup : Form
    {
        public int chosen_vertex;
        List<Vertex> vertices;
        public ReachabilitySetup(List<Vertex> vertices)
        {
            InitializeComponent();
            this.vertices = vertices;
            vertexComboBox.DataSource = vertices;
            vertexComboBox.SelectedItem = vertices[0];
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (vertexComboBox.SelectedItem is not null)
            {
                chosen_vertex = ((Vertex)vertexComboBox.SelectedItem).id;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
