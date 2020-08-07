using Acelera.Domain.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Utils
{
    public static class ParametrosLinhaEmissao
    {
        private const string linhaTim = "03   -171 01 5908   79793920010   20 4-1-1   -1EMS     797100205830572   3119     01589                   1 4962804  120200531     7971002058305722018120120200610201812012020061020200710     797100205830572     797100200000001         79710000030           143362150            0.00            0.0020200531           15.08            1.11            0.00            0.00           16.19      1.000000006         1199.00         1199.000.000            0.00            0.00                      0.00     71717          797100205830572797100000307119                                             RJ                                                                                                         ";
        public static LinhaArquivo CarregaLinhaEmissaoTIM(LinhaArquivo linhaCapa, int indexDaNovaLinha)
        {
            var linha = linhaCapa.Clone();
            linha.Index = indexDaNovaLinha;
            linha.CarregaTexto(linhaTim);
            return linha;
        }
    }
}
