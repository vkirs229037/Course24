using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLang;
using Microsoft.Msagl;
using Microsoft.Msagl.GraphViewerGdi;

namespace GraphApp
{
    using Drawing = Microsoft.Msagl.Drawing;
    internal static class Create
    {
        public static GViewer Viewer(Graph graph)
        {
            GViewer viewer = new();
            Drawing.Graph msagl_graph = new("Graph");
            foreach (Vertex v1 in graph.Vertices)
            {
                foreach (Vertex v2 in graph.Vertices)
                {
                    int weight_1_2 = graph[v1.id, v2.id];
                    int weight_2_1 = graph[v2.id, v1.id];
                    if (weight_1_2 != 0 && weight_1_2 == weight_2_1)
                    {
                        if (v2.id > v1.id) continue;
                        var edge = msagl_graph.AddEdge(v1.name, weight_1_2.ToString(), v2.name);
                        edge.Attr.ArrowheadAtTarget = Drawing.ArrowStyle.None;
                    }
                    else if (weight_1_2 != 0)
                    {
                        var edge = msagl_graph.AddEdge(v1.name, weight_1_2.ToString(), v2.name);
                        edge.Attr.ArrowheadAtTarget = Drawing.ArrowStyle.Normal;
                    }
                    Drawing.Node n1 = msagl_graph.FindNode(v1.name);
                    Drawing.Node n2 = msagl_graph.FindNode(v2.name);
                    if (n1 is not null) { 
                        n1.Attr.Shape = Drawing.Shape.Circle;
                    }
                    if (n2 is not null) { 
                        n2.Attr.Shape = Drawing.Shape.Circle;
                    }
                }
            }
            viewer.Graph = msagl_graph;
            return viewer;
        } 
    }
}
