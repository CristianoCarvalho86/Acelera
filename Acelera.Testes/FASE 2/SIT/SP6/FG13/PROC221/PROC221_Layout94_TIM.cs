﻿using Acelera.Domain.Enums;
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
    public class PROC221_Layout94_TIM: TestesFG13
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9740()
        {
            IniciarTesteFG07("9740", "", OperadoraEnum.TIM);

            SalvaExecutaEValidaTrinca(false);

            CriarCancelamentoDaTrincaFG13(OperadoraEnum.TIM, "10", false);

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            AjustarArquivoDeBaixaParaParcela(trinca.ArquivoParcEmissao, arquivo, 1, "18");

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9741()
        {
            IniciarTesteFG07("9741", "", OperadoraEnum.TIM);

            SalvaExecutaEValidaTrinca(true);

            CriarCancelamentoDaTrincaFG13(OperadoraEnum.TIM, "10", false);

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            AjustarArquivoDeBaixaParaParcela(trinca.ArquivoParcEmissao, arquivo, 0, "18");

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9742()
        {
            IniciarTesteFG07("9742", "", OperadoraEnum.TIM);

            //ENVIA A PRIMEIRA PARCELA PARA A ODS
            SalvaExecutaEValidaTrinca(true);

            //ENVIA A SEGUNDA PARCELA PARA A ODS
            CriarNovaLinhaParaEmissao(trinca.ArquivoParcEmissao, 0);
            trinca.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao[1], trinca.ArquivoComissao[1]);
            trinca.ArquivoParcEmissao.RemoverLinhaComAjuste(0);
            trinca.ArquivoComissao.RemoverLinhaComAjuste(0);

            SalvaExecutaEValidaTrinca(true);

            //ENVIAR CANCELAMENTO PARA A ODS
            CriarCancelamentoDaTrincaFG13(OperadoraEnum.TIM, "10", true);

            //ENVIAR BAIXA DA PARCELA
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);
            AjustarArquivoDeBaixaParaParcela(trinca.ArquivoParcEmissao, arquivo, 0, "18");

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9743()
        {
            IniciarTesteFG07("9743", "", OperadoraEnum.TIM);

            //ENVIA A PRIMEIRA PARCELA PARA A ODS
            SalvaExecutaEValidaTrinca(true);

            //ENVIA A SEGUNDA PARCELA PARA A STG
            CriarNovaLinhaParaEmissao(trinca.ArquivoParcEmissao, 0);
            trinca.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao[1], trinca.ArquivoComissao[1]);
            trinca.ArquivoParcEmissao.RemoverLinhaComAjuste(0);
            trinca.ArquivoComissao.RemoverLinhaComAjuste(0);

            SalvaExecutaEValidaTrinca(false);

            //ENVIAR CANCELAMENTO PARA A ODS
            CriarCancelamentoDaTrincaFG13(OperadoraEnum.TIM, "10", true);

            //ENVIAR BAIXA DA PARCELA
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);
            AjustarArquivoDeBaixaParaParcela(trinca.ArquivoParcEmissao, arquivo, 0, "18");

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9744()
        {
            IniciarTesteFG07("9744", "", OperadoraEnum.TIM);

            //ENVIA A PRIMEIRA PARCELA PARA A ODS
            SalvaExecutaEValidaTrinca(true);

            //ENVIAR BAIXA DA PARCELA
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);
            AjustarArquivoDeBaixaParaParcela(trinca.ArquivoParcEmissao, arquivo, 0, "18");

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

    }
}
