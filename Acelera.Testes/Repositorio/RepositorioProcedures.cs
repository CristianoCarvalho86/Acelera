using Acelera.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.Repositorio
{
    public static class RepositorioProcedures
    {
        public static FGs[] FgsQueRodamProcedures => new FGs[] { FGs.FG00, FGs.FG01, FGs.FG01_2, FGs.FG02, FGs.FG05, FGs.FG09 };

        public static IList<string> ObterProcedures(FGs fg, TipoArquivo tipoArquivo)
        {
            switch(fg)
            {
                case FGs.FG00:
                    return ProceduresFG00();
                case FGs.FG01:
                    return ProceduresFG00()
                        .Concat(ProceduresFG01(tipoArquivo)).ToList();
                case FGs.FG01_2:
                    return ProceduresFG00().Concat(ProceduresFG01(tipoArquivo))
                        .Concat(ProceduresFG01_2()).ToList();
                case FGs.FG02:
                    return ProceduresFG00().Concat(ProceduresFG01(tipoArquivo)).Concat(ProceduresFG01_2())
                        .Concat(ProceduresFG02(tipoArquivo)).ToList();
                case FGs.FG05:
                    return ProceduresFG00().Concat(ProceduresFG01(tipoArquivo)).Concat(ProceduresFG01_2()).Concat(ProceduresFG02(tipoArquivo))
                        .Concat(ProceduresFG05(tipoArquivo)).ToList();
                case FGs.FG09:
                    return ProceduresFG00().Concat(ProceduresFG01(tipoArquivo)).Concat(ProceduresFG01_2()).Concat(ProceduresFG02(tipoArquivo))
                        .Concat(ProceduresFG09(tipoArquivo)).ToList();
                default:
                    throw new Exception("FG NAO PARAMETRIZADA PARA OBTER PROCEDURES");
            }
        }

        private static IList<string> ProceduresFG00()
        {
            var lista = new List<string>();
            lista.Add("PRC_0093_IMP");
            lista.Add("PRC_0094_IMP");
            lista.Add("PRC_0101_IMP");
            lista.Add("PRC_0101_IMP");
            lista.Add("PRC_0002_IMP");
            lista.Add("PRC_0091_IMP");
            lista.Add("PRC_0400_IMP");
            lista.Add("PRC_0003_IMP");
            lista.Add("PRC_0004_IMP");
            lista.Add("PRC_0100_IMP");
            lista.Add("PRC_0095_IMP");
            lista.Add("PRC_0092_IMP");
            lista.Add("PRC_0401_IMP");
            return lista;
        }

        private static IList<string> ProceduresFG01(TipoArquivo tipoArquivoTeste)
        {
            var lista = new List<string>();
            switch (tipoArquivoTeste)
            {
                case TipoArquivo.Cliente:
                    lista.Add("PRC_0008");
                    lista.Add("PRC_0041");
                    lista.Add("PRC_0126");
                    //lista.Add("PRC_0022"); PASSAR PRA 1_2
                    break;
                case TipoArquivo.ParcEmissao:
                    lista.Add("PRC_0014");
                    lista.Add("PRC_0015");
                    lista.Add("PRC_0126");
                    lista.Add("PRC_0010");
                    //lista.Add("PRC_200000");
                    //lista.Add("PRC_0022");
                    break;

                case TipoArquivo.ParcEmissaoAuto:
                    lista.Add("PRC_0008");
                    lista.Add("PRC_0014");
                    lista.Add("PRC_0015");
                    lista.Add("PRC_0126");
                    lista.Add("PRC_0213");
                    lista.Add("PRC_0010");
                    //lista.Add("PRC_200000");
                    //lista.Add("PRC_0022");
                    break;
                case TipoArquivo.Comissao:
                    //lista.Add("PRC_0022");
                    //lista.Add("PRC_200000");
                    break;
                case TipoArquivo.LanctoComissao:
                case TipoArquivo.OCRCobranca:
                    //lista.Add("PRC_200000");
                    break;
                case TipoArquivo.Sinistro:
                    lista.Add("PRC_0008");
                    lista.Add("PRC_0062");
                    lista.Add("PRC_0066");
                    lista.Add("PRC_0126");
                    //lista.Add("PRC_200000");
                    lista.Add("PRC_0074");
                    //lista.Add("PRC_0022");
                    break;
                default:
                    throw new Exception("TIPO ARQUIVO NAO ENCONTRADO.");

            }
            lista.Add("PRC_0110");
            lista.Add("PRC_0001");
            lista.Add("PRC_0005");
            lista.Add("PRC_0006");
            lista.Add("PRC_0007");

            return lista;
        }

        private static IList<string> ProceduresFG01_2()
        {
            var lista = new List<string>();
            lista.Add("PRC_0022");
            return lista;
        }

        private static IList<string> ProceduresFG02(TipoArquivo tipoArquivoTeste)
        {
            var lista = new List<string>();
            switch (tipoArquivoTeste)
            {
                case TipoArquivo.Cliente:
                    lista.Add("PRC_0035");
                    lista.Add("PRC_1039");
                    lista.Add("PRC_1040");
                    lista.Add("PRC_1041");
                    lista.Add("PRC_0267");

                    break;
                case TipoArquivo.ParcEmissao:
                    lista.Add("PRC_0011");
                    lista.Add("PRC_0013");
                    lista.Add("PRC_0016");
                    lista.Add("PRC_0018");
                    lista.Add("PRC_0019");
                    lista.Add("PRC_0020");
                    lista.Add("PRC_0033");
                    lista.Add("PRC_0035");
                    lista.Add("PRC_0023");
                    lista.Add("PRC_0024");
                    lista.Add("PRC_0025");
                    lista.Add("PRC_0026");
                    lista.Add("PRC_0028");
                    lista.Add("PRC_0032");
                    lista.Add("PRC_0034");
                    lista.Add("PRC_0107");
                    lista.Add("PRC_0120");
                    lista.Add("PRC_0122");
                    lista.Add("PRC_0123");
                    lista.Add("PRC_0127");
                    lista.Add("PRC_0155");
                    lista.Add("PRC_0162");
                    lista.Add("PRC_0191");
                    lista.Add("PRC_0215");
                    lista.Add("PRC_0223");
                    lista.Add("PRC_1002");
                    lista.Add("PRC_1003");
                    lista.Add("PRC_1024");
                    lista.Add("PRC_1046");
                    lista.Add("PRC_1048");
                    lista.Add("PRC_1056");
                    lista.Add("PRC_1065");
                    lista.Add("PRC_1067");
                    lista.Add("PRC_1083");
                    //lista.Add("PRC_1091");
                    lista.Add("PRC_1092");
                    lista.Add("PRC_1182");
                    lista.Add("PRC_1183");
                    lista.Add("PRC_1184");

                    break;

                case TipoArquivo.ParcEmissaoAuto:
                    lista.Add("PRC_0011");
                    lista.Add("PRC_0013");
                    lista.Add("PRC_0016");
                    lista.Add("PRC_0018");
                    lista.Add("PRC_0019");
                    lista.Add("PRC_0020");
                    lista.Add("PRC_0033");
                    lista.Add("PRC_0035");
                    lista.Add("PRC_0023");
                    lista.Add("PRC_0024");
                    lista.Add("PRC_0025");
                    lista.Add("PRC_0026");
                    lista.Add("PRC_0028");
                    lista.Add("PRC_0032");
                    lista.Add("PRC_0034");
                    lista.Add("PRC_0107");
                    lista.Add("PRC_0120");
                    lista.Add("PRC_0122");
                    lista.Add("PRC_0123");
                    lista.Add("PRC_0127");
                    lista.Add("PRC_0155");
                    lista.Add("PRC_0162");
                    lista.Add("PRC_0191");
                    lista.Add("PRC_0215");
                    lista.Add("PRC_0223");
                    lista.Add("PRC_1002");
                    lista.Add("PRC_1003");
                    lista.Add("PRC_1024");
                    lista.Add("PRC_1046");
                    lista.Add("PRC_1048");
                    lista.Add("PRC_1056");
                    lista.Add("PRC_1065");
                    lista.Add("PRC_1067");
                    lista.Add("PRC_1083");
                    //lista.Add("PRC_1091");
                    lista.Add("PRC_1092");
                    lista.Add("PRC_1182");
                    lista.Add("PRC_1183");
                    lista.Add("PRC_1184");
                    break;
                case TipoArquivo.Comissao:
                    lista.Add("PRC_0033");
                    lista.Add("PRC_0035");
                    lista.Add("PRC_0024");
                    lista.Add("PRC_0025");
                    lista.Add("PRC_0052");
                    lista.Add("PRC_0218");
                    lista.Add("PRC_1048");
                    lista.Add("PRC_0108");
                    lista.Add("PRC_0034");
                    //lista.Add("PRC_1049");
                    //lista.Add("PRC_1111");
                    break;

                case TipoArquivo.LanctoComissao:
                    lista.Add("PRC_0033");
                    lista.Add("PRC_0035");
                    lista.Add("PRC_0026");
                    lista.Add("PRC_0124");
                    lista.Add("PRC_1190");
                    //lista.Add("PRC_1191");
                    lista.Add("PRC_1193");
                    break;
                case TipoArquivo.OCRCobranca:
                    lista.Add("PRC_0033");
                    lista.Add("PRC_0035");
                    lista.Add("PRC_1167");
                    lista.Add("PRC_0124");
                    lista.Add("PRC_0034");

                    break;
                case TipoArquivo.Sinistro:
                    lista.Add("PRC_0033");
                    lista.Add("PRC_0035");
                    lista.Add("PRC_0023");
                    lista.Add("PRC_0024");
                    lista.Add("PRC_0025");
                    lista.Add("PRC_0026");
                    //lista.Add("PRC_0027");
                    //lista.Add("PRC_0070");
                    lista.Add("PRC_0080");
                    //lista.Add("PRC_0081");
                    //lista.Add("PRC_0082");
                    lista.Add("PRC_0085");
                    lista.Add("PRC_0086");
                    lista.Add("PRC_0087");
                    lista.Add("PRC_0088");
                    //lista.Add("PRC_0107");
                    lista.Add("PRC_0111");
                    lista.Add("PRC_0119");
                    lista.Add("PRC_0120");
                    //lista.Add("PRC_0128");
                    lista.Add("PRC_0130");
                    lista.Add("PRC_0131");
                    lista.Add("PRC_0132");
                    lista.Add("PRC_0164");
                    lista.Add("PRC_0176");
                    lista.Add("PRC_0177");
                    lista.Add("PRC_0178");
                    //lista.Add("PRC_0181");
                    lista.Add("PRC_0182");
                    lista.Add("PRC_0184");
                    lista.Add("PRC_0185");
                    lista.Add("PRC_1048");
                    //lista.Add("PRC_0129");
                    lista.Add("PRC_0267");

                    break;
                default:
                    throw new Exception("TIPO ARQUIVO NAO ENCONTRADO.");

            }

            return lista;
        }

        private static IList<string> ProceduresFG05(TipoArquivo tipoArquivoTeste)
        {
            var lista = new List<string>();
            switch (tipoArquivoTeste)
            {
                case TipoArquivo.Cliente:
                    //lista.Add("PRC_0022_NEG");
                    lista.Add("PRC_0097_INT");
                    lista.Add("PRC_0038_INT");
                    break;
                case TipoArquivo.ParcEmissao:
                    //lista.Add("PRC_0022_NEG");
                    lista.Add("PRC_0027_NEG");
                    lista.Add("PRC_0038_INT");
                    lista.Add("PRC_0044_NEG");
                    lista.Add("PRC_0097_INT");
                    lista.Add("PRC_0212_NEG");
                    lista.Add("PRC_1012_NEG");
                    lista.Add("PRC_1014_NEG");
                    lista.Add("PRC_1015_NEG");
                    break;

                case TipoArquivo.ParcEmissaoAuto:
                    //lista.Add("PRC_0022_NEG");
                    lista.Add("PRC_0027_NEG");
                    lista.Add("PRC_0038_INT");
                    lista.Add("PRC_0044_NEG");
                    lista.Add("PRC_0097_INT");
                    lista.Add("PRC_0212_NEG");
                    lista.Add("PRC_0227_NEG");
                    lista.Add("PRC_0228_NEG");
                    lista.Add("PRC_1012_NEG");
                    lista.Add("PRC_1014_NEG");
                    lista.Add("PRC_1015_NEG");
                    break;

                case TipoArquivo.Comissao:
                    //lista.Add("PRC_0022_NEG");
                    lista.Add("PRC_0038_INT");
                    lista.Add("PRC_0054_INT");
                    lista.Add("PRC_0097_INT");
                    //lista.Add("PRC_0108_NEG");
                    lista.Add("PRC_0216_NEG");
                    break;

                case TipoArquivo.LanctoComissao:
                    lista.Add("PRC_0097_INT");

                    break;
                case TipoArquivo.OCRCobranca:
                    lista.Add("PRC_0097_INT");
                    break;

                case TipoArquivo.Sinistro:
                    lista.Add("PRC_0027_NEG");
                    lista.Add("PRC_0038_INT");
                    lista.Add("PRC_0097_INT");
                    break;
                default:
                    throw new Exception("TIPO ARQUIVO NAO ENCONTRADO.");

            }

            return lista;
        }

        private static IList<string> ProceduresFG09(TipoArquivo tipoArquivoTeste)
        {
            var lista = new List<string>();
            switch (tipoArquivoTeste)
            {
                case TipoArquivo.Cliente:
                    break;
                case TipoArquivo.ParcEmissao:
                    //lista.Add("PRC_0042_");
                    lista.Add("PRC_0045_");
                    lista.Add("PRC_0190_");
                    lista.Add("PRC_0196_");
                    lista.Add("PRC_0197_");
                    //lista.Add("PRC_0199_");
                    lista.Add("PRC_0201_");
                    lista.Add("PRC_0206_");
                    lista.Add("PRC_0207_");
                    lista.Add("PRC_0208_");
                    lista.Add("PRC_0211_");
                    lista.Add("PRC_0222_");
                    lista.Add("PRC_0224_");
                    lista.Add("PRC_0229_");
                    break;

                case TipoArquivo.ParcEmissaoAuto:
                    //lista.Add("PRC_0042_");
                    lista.Add("PRC_0045_");
                    lista.Add("PRC_0190_");
                    //lista.Add("PRC_0199_");
                    lista.Add("PRC_0196_");
                    lista.Add("PRC_0197_");
                    lista.Add("PRC_0201_");
                    lista.Add("PRC_0206_");
                    lista.Add("PRC_0207_");
                    lista.Add("PRC_0208_");
                    lista.Add("PRC_0211_");
                    lista.Add("PRC_0222_");
                    lista.Add("PRC_0224_");
                    lista.Add("PRC_0229_");
                    break;

                case TipoArquivo.Comissao:
                    lista.Add("PRC_0199_");
                    lista.Add("PRC_0200_");
                    break;

                case TipoArquivo.LanctoComissao:
                    break;
                case TipoArquivo.OCRCobranca:
                    break;

                case TipoArquivo.Sinistro:
                    break;
                default:
                    throw new Exception("TIPO ARQUIVO NAO ENCONTRADO.");

            }

            return lista;
        }
    }
}
