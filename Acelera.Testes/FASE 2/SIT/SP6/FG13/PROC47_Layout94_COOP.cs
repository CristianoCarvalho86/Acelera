using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP6.FG13.PROC47
{
    [TestClass]
    public class PROC47_Layout94_COOP : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9419()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9419", "SAP-9318:FG05 - PROC 47 - C/C - PARCELA - ID_TRANSACAO já processado - Capa");
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);


            AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            SalvarArquivo(arquivo);

            CriarNovaLinhaParaEmissao(arquivo);
            RemoverLinha(0);
            AjustarQtdLinFooter();

            SalvarArquivo();

            CriarNovaLinhaParaEmissao(arquivo);
            AlterarLinha(1, "NR_SEQ_EMISSAO", arquivo[0]["NR_SEQ_EMISSAO"]);
            RemoverLinha(0);
            AjustarQtdLinFooter();

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "47", 1);
        }

    }
}
