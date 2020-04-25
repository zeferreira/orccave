using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA
{
    public class StrategyGeradorCaminhoGuloso : IStrategyGeradorCaminhoGrafo
    {
        Node response;

        public StrategyGeradorCaminhoGuloso()
        {
            Node response = null;
        }

        public Node ProcurarCaminhoSolucao(Node root, Node destiny)
        {
            this.response = null;
            var visited = new HashSet<int>();
            VisitNodeDFS(root, destiny, visited);
            return response;
        }

        private void VisitNodeDFS(Node actual, Node destiny, HashSet<int> visited)
        {
            if(destiny != null)
            {
                if (actual.identificador == destiny.identificador)
                {
                    response = actual;
                    actual.visitado = true;
                }
                else
                {
                    List<Edge> sortedList = actual.edgeNeighbors.OrderBy(o => o.Weight).ToList();
                    var sortedNoVisited = sortedList.Where(a => !visited.Contains(a.NextNodePath.identificador));

                    foreach (Edge neighbour in sortedNoVisited)
                    {
                        if (neighbour.NextNodePath.visitado == false)
                        {
                            neighbour.NextNodePath.PreviousNodePath = actual;
                            VisitNodeDFS(neighbour.NextNodePath, destiny, visited);
                        }
                    }
                }
            }
            visited.Add(actual.identificador);

        }

        
        public List<Edge> ProcurarCaminhoSolucaoAresta(Node root, Node destiny)
        {
            throw new NotImplementedException();
        }
    }
}
