using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA
{
    public class StrategyGeradorCaminhoGrafoDFS : IStrategyGeradorCaminhoGrafo
    {
        Node response;

        public StrategyGeradorCaminhoGrafoDFS()
        {
            Node response = null;
        }

        public Node ProcurarCaminhoSolucao(Node root, Node destiny)
        {
            var visited = new HashSet<int>();
            VisitNodeDFS(root, destiny, visited);
            return response;
        }

        public List<Edge> ProcurarCaminhoSolucaoAresta(Node root, Node destiny)
        {
            throw new NotImplementedException();
        }

        private void VisitNodeDFS(Node actual, Node destiny, HashSet<int> visited)
        {
            visited.Add(actual.identificador);
            if(destiny != null)
            {
                if (actual.identificador == destiny.identificador)
                    response = actual;
            }

            foreach (Node neighbour in actual.vizinhos.Where(a => !visited.Contains(a.identificador)))
            {
                if(neighbour.visitado == false)
                {
                    neighbour.PreviousNodePath = actual;
                    VisitNodeDFS(neighbour, destiny,visited);
                }
                    
            }
        }
    }
}
