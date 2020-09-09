using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP6.FG13.PROC221
{
    [TestClass]
    public class PROC221_Layout94_LASA: TestesFG13
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9730()
        {
            IniciarTesteFG07("9730", "", OperadoraEnum.LASA);

            SalvaExecutaEValidaTrinca(false);

            CriarCancelamentoDaTrincaFG13(OperadoraEnum.LASA, "10", false);

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AjustarArquivoDeBaixaParaParcela(triplice.ArquivoParcEmissao, arquivo, 0, "18");

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9731()
        {
            IniciarTesteFG07("9731", "", OperadoraEnum.LASA);

            SalvaExecutaEValidaTrinca(true);

            CriarCancelamentoDaTrincaFG13(OperadoraEnum.LASA, "10", false);

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AjustarArquivoDeBaixaParaParcela(triplice.ArquivoParcEmissao, arquivo, 0, "18");

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9732()
        {
            IniciarTesteFG07("9732", "", OperadoraEnum.LASA);

            //ENVIA A PRIMEIRA PARCELA PARA A ODS
            SalvaExecutaEValidaTrinca(true);

            //ENVIA A SEGUNDA PARCELA PARA A ODS
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            triplice.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[1]);
            triplice.ArquivoParcEmissao.RemoverLinhaComAjuste(0);
            triplice.ArquivoComissao.RemoverLinhaComAjuste(0);

            SalvaExecutaEValidaTrinca(true);

            //ENVIAR CANCELAMENTO PARA A ODS
            CriarCancelamentoDaTrincaFG13(OperadoraEnum.LASA, "10", true);

            //ENVIAR BAIXA DA PARCELA
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);
            AjustarArquivoDeBaixaParaParcela(triplice.ArquivoParcEmissao, arquivo, 0, "18");

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9733()
        {
            IniciarTesteFG07("9733", "", OperadoraEnum.LASA);

            //ENVIA A PRIMEIRA PARCELA PARA A ODS
            SalvaExecutaEValidaTrinca(true);

            //ENVIA A SEGUNDA PARCELA PARA A STG
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            triplice.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[1]);
            triplice.ArquivoParcEmissao.RemoverLinhaComAjuste(0);
            triplice.ArquivoComissao.RemoverLinhaComAjuste(0);

            SalvaExecutaEValidaTrinca(false);

            //ENVIAR CANCELAMENTO PARA A ODS
            CriarCancelamentoDaTrincaFG13(OperadoraEnum.LASA, "10", true);

            //ENVIAR BAIXA DA PARCELA
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);
            AjustarArquivoDeBaixaParaParcela(triplice.ArquivoParcEmissao, arquivo, 0, "18");

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9734()
        {
            IniciarTesteFG07("9734", "", OperadoraEnum.LASA);

            //ENVIA A PRIMEIRA PARCELA PARA A ODS
            SalvaExecutaEValidaTrinca(true);

            //ENVIAR BAIXA DA PARCELA
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);
            AjustarArquivoDeBaixaParaParcela(triplice.ArquivoParcEmissao, arquivo, 0, "18");

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

    }
}
