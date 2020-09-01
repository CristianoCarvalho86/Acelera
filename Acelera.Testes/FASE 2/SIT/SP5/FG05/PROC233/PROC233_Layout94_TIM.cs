using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC233
{
    [TestClass]
    public class PROC233_Layout94_TIM : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9360()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9360", "SAP-9360:FG05 - PROC 233 - C/C - PARCELA - Contrato com registro rejeitado - Mesmo arquivo");
            //Envia parc normal
            AlterarCobertura(false);

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-9999-20200831.txt"));
            RemoverLinha(0);
            RemoverLinha(0);

            CriarNovoContrato(0, arquivo, "", true);

            var arquivoParcela = arquivo.Clone();

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.TIM, arquivoParcela);

            AlterarLinha(1, "CD_RAMO", "00");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "233", 1);
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9361()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9361", "SAP-9361:FG05 - PROC 233 - C/C - PARCELA - Contrato com registro rejeitado - Arquivos diferentes");
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            SalvarArquivo();

            AdicionarNovaCoberturaNaEmissao(arquivo, dados, 0);
            AlterarLinha(1, "CD_RAMO", "00");
            RemoverLinha(0);
            AjustarQtdLinFooter();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "233", 1);
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9362()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9362", "SAP-9362:FG05 - PROC 233 - C/C - COMISSAO - Contrato com registro rejeitado - Mesmo arquivo");
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            var arquivoParc = arquivo.Clone();

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);
            IgualarCamposQueExistirem(arquivoParc,arquivo);

            AdicionarNovaCoberturaNaEmissao(arquivo, dados, 0);
            AlterarLinha(1, "CD_RAMO", "00");
            RemoverLinha(0);
            AjustarQtdLinFooter();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "233", 1);
        }
    }
}
