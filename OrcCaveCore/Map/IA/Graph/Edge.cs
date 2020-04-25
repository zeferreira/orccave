using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA
{
    public class Edge
    {
        public Edge()
        {
            this.Weight = 0.0;
        }

        public Edge(double weight)
        {
            this.Weight = weight;
        }

        public double Weight;

        public Node PreviousNodePath;
        public Node NextNodePath;
    }
}
