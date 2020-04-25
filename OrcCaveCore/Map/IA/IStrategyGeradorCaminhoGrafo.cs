using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA
{
    public interface IStrategyGeradorCaminhoGrafo
    {
        Node ProcurarCaminhoSolucao(Node root, Node destiny);

        List<Edge> ProcurarCaminhoSolucaoAresta(Node root, Node destiny);
    }
}
