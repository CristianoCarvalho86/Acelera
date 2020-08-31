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
        private const string linhaTim =     "03   -171 01 5908   79793920010   20 4-1-1   -1EMS     797100205830572   3119     01589                   1 4962804  120200531     7971002058305722018120120200610201812012020061020200710     797100205830572     797100200000001         79710000030           143362150            0.00            0.0020200531           15.08            1.11            0.00            0.00           16.19      1.000000006         1199.00         1199.000.000            0.00            0.00                      0.00     71717          797100205830572797100000307119                                             RJ                                                                                                         ";
        private const string linhaAgregue = "03   -171 01 5908   71793920010   20 7-1-1   -1EMI     717100500002137    2 1     01589                   1    1605  120190215     7171005000021372019021520190220201902152019021520200215     717100500002137                             71710000001           122336855            0.00            0.0020190215           25.91            1.91            0.00            0.00           27.82      1.000000006         1599.00         1599.000.000            0.00            0.00                      0.00     71722           71710050000213771710000001711                                             SP                                                                                                         ";
        private const string linhaPITZI =   "03-1   7101 5908 71   71399481020   7 -11 -1   EMS717100801052937     2     101589     1                     5807201  20200709717100801052937     2020070920200709        2020070920210708717100801052937                         71710000001         0080000001                      0.00            0.0020200709           36.86            2.72            0.00            0.00           39.58              106         2199.00         2199.00 0.00            0.00            0.004                   439.8071729     71710080105293771710000001711                                                   6    SP                                                                                                         ";
        private const string linhaTimCapa = "03   -177 03 5908   79793920010   18 4-1-1   -1EMS     797700210058838    1 0     01612                   1  215958  120200213     7977002100588382020021320200213202002132020021320220213     797700210058838                                       0                   0            0.00            0.0020200220            0.00            0.00            0.00            0.00            0.00      1.000000006            0.00          150.000.000            0.00            0.00                      0.00     77504                     7977002100588380770                                             RJ                                                                                                         ";

        public static LinhaArquivo CarregaLinhaEmissaoTIM(LinhaArquivo linhaCapa, int indexDaNovaLinha)
        {
            var linha = linhaCapa.Clone();
            linha.Index = indexDaNovaLinha;
            linha.CarregaTexto(linhaTim);
            return linha;
        }

        public static LinhaArquivo CarregaLinhaCapaTIM(LinhaArquivo linhaReferencia)
        {
            var linha = linhaReferencia.Clone();
            linha.Index = linhaReferencia.Index + 1;
            linha.CarregaTexto(linhaTimCapa);
            return linha;
        }

        public static LinhaArquivo CarregaLinhaEmissaoAGREGUE(LinhaArquivo linhaCapa, int indexDaNovaLinha)
        {
            var linha = linhaCapa.Clone();
            linha.Index = indexDaNovaLinha;
            linha.CarregaTexto(linhaAgregue);
            return linha;
        }

        public static LinhaArquivo CarregaLinhaEmissaoPITZI(LinhaArquivo linhaCapa, int indexDaNovaLinha)
        {
            var linha = linhaCapa.Clone();
            linha.Index = indexDaNovaLinha;
            linha.CarregaTexto(linhaPITZI);
            return linha;
        }
    }
}
