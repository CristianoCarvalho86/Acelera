using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC241
{
    [TestClass]
    public class PROC241_Layout94_COOP : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9425()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9425", "SAP-9318:FG05 - PROC 241 - C/C - PARCELA - ID_TRANSACAO já processado - Capa");
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);
            CriarNovoContrato(0);

            AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "241", 1);
        }
    }
}
