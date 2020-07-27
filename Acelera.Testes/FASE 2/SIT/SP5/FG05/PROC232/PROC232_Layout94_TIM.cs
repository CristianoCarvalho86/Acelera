using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC232
{
    [TestClass]
    public class PROC232_Layout94_TIM : TestesFG05
    {
        [TestMethod]
        public void SAP_9319()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9319", "FG05 - PROC232 - ");
            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.TIM);

            AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);

            EnviarParaOds(arquivoods1);

            arquivo = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.TIM);

            //CriarComissao();

            AlterarLinha(0, "VL_COMISSAO", "100");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "231", 1);
        }
    }
}
