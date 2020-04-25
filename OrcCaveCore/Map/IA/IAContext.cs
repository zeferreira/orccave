using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA
{
    //bridge fro IA class
    public class IAContext
    {
        IStrategyGeradorCaminhoGrafo geradorSolucao;

        public IAContext(IStrategyGeradorCaminhoGrafo geradorSolucao)
        {
            this.geradorSolucao = geradorSolucao;
        }

        public Node ProcurarCaminhoSolucao(Node root, Node destiny)
        {
            return this.geradorSolucao.ProcurarCaminhoSolucao(root,destiny);
        }
    }
}
