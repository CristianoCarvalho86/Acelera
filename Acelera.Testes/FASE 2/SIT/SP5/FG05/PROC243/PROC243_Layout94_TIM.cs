using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC243
{
    [TestClass]
    public class PROC243_Layout96_TIM : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9463()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9463", "SAP-9318:FG05 - PROC 243 - C/C - PARCELA - ID_TRANSACAO já processado - Capa");
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);
            contratoRegras.CriarNovoContrato(0,arquivo);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            CriarNovaLinhaParaEmissao(arquivo);

            EnviarParaOdsAlterandoCliente(arquivo);

            CriarNovaLinhaParaEmissao(arquivo,1);
            AlterarLinha(2, "NR_ENDOSSO", arquivo[1]["NR_ENDOSSO"]);
            RemoverLinha(0);
            RemoverLinha(0);
            AjustarQtdLinFooter();

            SalvarArquivo();

            SelecionarLinhaParaValidacao(0);
            ValidarFGsAnteriores();
            //ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "243", 1);
        }
    }
}
