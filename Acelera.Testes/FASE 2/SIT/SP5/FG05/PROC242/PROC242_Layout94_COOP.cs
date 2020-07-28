using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC242
{
    [TestClass]
    public class PROC242_Layout94_COOP : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9419()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9419", "SAP-9318:FG05 - PROC 242 - C/C - PARCELA - ID_TRANSACAO já processado - Capa");
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            CriarNovaLinhaParaEmissao(arquivo);

            EnviarParaOds(arquivo);

            CriarNovaLinhaParaEmissao(arquivo);
            RemoverLinha(0);
            RemoverLinha(1);
            AjustarQtdLinFooter();
            AlterarLinha(0, "NR_SEQ_EMISSAO", "1");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "242", 1);
        }
    }
}
