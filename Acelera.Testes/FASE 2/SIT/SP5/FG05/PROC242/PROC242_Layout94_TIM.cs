using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
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
    public class PROC242_Layout94_TIM : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9401()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9401", "SAP-9401:FG05 - PROC 242 - TIM - PARCELA - NR_SEQ_EMISSAO já processado - Parcela 2");
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);
            CriarNovoContrato(0);
            AlterarHeader("VERSAO", "9.6");

            AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            CriarNovaLinhaParaEmissao(arquivo);

            EnviarParaOdsAlterandoCliente(arquivo);

            CriarNovaLinhaParaEmissao(arquivo, 1);
            AlterarLinha(2, "NR_SEQUENCIAL_EMISSAO", "2");
            RemoverLinha(0);
            RemoverLinha(0);
            AjustarQtdLinFooter();

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "243", 1);
        }
    }
}
