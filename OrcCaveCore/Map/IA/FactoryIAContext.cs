using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA
{
    public class FactoryIAContext
    {
        
        public static IAContext GetIAContext()
        {
            EnumTypeIAContext tipo = EnumTypeIAContext.Greedy;

            switch (tipo)
            {
                case EnumTypeIAContext.BFS:
                    return new IAContext(new StrategyGeradorCaminhoGrafoBFS());
                    
                case EnumTypeIAContext.DFS:
                    return new IAContext(new StrategyGeradorCaminhoGrafoDFS());

                case EnumTypeIAContext.Greedy:
                    return new IAContext(new StrategyGeradorCaminhoGuloso());
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
