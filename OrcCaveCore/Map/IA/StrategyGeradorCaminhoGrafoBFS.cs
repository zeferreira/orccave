using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA
{
    public class StrategyGeradorCaminhoGrafoBFS : IStrategyGeradorCaminhoGrafo
    {
        Queue<Node> fila;

        public StrategyGeradorCaminhoGrafoBFS()
        {
            fila = new Queue<Node>();
        }

        public Node ProcurarCaminhoSolucao(Node root, Node destiny)
        {
            Node atual = null;
            
            fila.Enqueue(root);
            
            //    enquanto a fila não estiver vazia
            //        retire um vértice v da fila
            //            para cada vizinho w de v
            //                se w não está numerado
            //                então numere w
            //                    ponha w na fila

            while (fila.Count > 0)
            {
                atual = fila.Dequeue();
                if (atual.identificador == destiny.identificador)
                    return atual;
                else
                {
                    atual.visitado = true;
                    foreach (Node item in atual.vizinhos)
                    {
                        if(item.visitado == false)
                        {
                            item.PreviousNodePath = atual;
                            fila.Enqueue(item);
                        }
                    }
                }
            }

            return null;
        }

        public List<Edge> ProcurarCaminhoSolucaoAresta(Node root, Node destiny)
        {
            throw new NotImplementedException();
        }
    }
}
