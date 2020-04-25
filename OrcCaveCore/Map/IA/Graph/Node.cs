using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA
{
    public class Node
    {
        public Node()
        {
            this.vizinhos = new List<Node>();
            this.edgeNeighbors = new List<Edge>();
        }

        public List<Node> vizinhos;

        public List<Edge> edgeNeighbors;

        public int identificador;
        public bool visitado;

        public Node PreviousNodePath;
        public Node NextNodePath;

        public Edge PreviousEdgePath;
        public Edge NextEdgePath;
    }
}
