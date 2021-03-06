﻿using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP6.FG13.PROC50
{
    [TestClass]
    public class PROC50_Layout94_TIM: TestesFG13
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9697()
        {
            IniciarTesteFG07("9697", "", OperadoraEnum.TIM);

            //ENVIA A PRIMEIRA PARCELA PARA A ODS
            SalvaExecutaEValidaTrinca(true);

            //ENVIAR BAIXA DA PARCELA
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);
            AjustarArquivoDeBaixaParaParcela(trinca.ArquivoParcEmissao, arquivo, 0, "18");
            AlterarLinha(0, "DT_OCORRENCIA", SomarData(trinca.ArquivoParcEmissao[0]["DT_OCORRENCIA"], 10));
            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9698()
        {
            IniciarTesteFG07("9698", "", OperadoraEnum.TIM);

            SalvaExecutaEValidaTrincaFG02(true);

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            AjustarArquivoDeBaixaParaParcela(trinca.ArquivoParcEmissao, arquivo, 1, "18");//Arquivo Parc TIM, primeira parcela linha 1

            EnviarParaOds(arquivo);

            LimparValidacao();

            AlterarLinha(0, "DT_OCORRENCIA", SomarData(arquivo[0]["DT_OCORRENCIA"], 20));

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9699()
        {
            IniciarTesteFG07("9699", "", OperadoraEnum.TIM);

            emissaoRegras.AdicionarNovaCoberturaNaEmissao(trinca.ArquivoParcEmissao, dados, 1,
                dados.ObterCoberturaDiferenteDe(trinca.ArquivoParcEmissao[1]["CD_COBERTURA"], trinca.ArquivoParcEmissao.Header[0]["CD_TPA"], true));

            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao.ObterLinha(2), trinca.ArquivoComissao.ObterLinha(1));//Arquivo Parc TIM, primeira parcela linha 1

            SalvaExecutaEValidaTrinca(true);

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            AjustarArquivoDeBaixaParaParcela(trinca.ArquivoParcEmissao, arquivo, 0, "18");
            AjustarArquivoDeBaixaParaParcela(trinca.ArquivoParcEmissao, arquivo, 1, "18");

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

            LimparValidacao();

            AlterarLinha(0, "DT_OCORRENCIA", SomarData(arquivo[0]["DT_OCORRENCIA"], 20));

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9709()
        {
            IniciarTesteFG07("9709", "", OperadoraEnum.TIM);

            //ENVIA A PRIMEIRA PARCELA PARA A ODS
            SalvaExecutaEValidaTrinca(true);

            //ENVIAR BAIXA DA PARCELA
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);
            AjustarArquivoDeBaixaParaParcela(trinca.ArquivoParcEmissao, arquivo, 0, "18");
            AlterarLinha(0, "DT_OCORRENCIA", SomarData(trinca.ArquivoParcEmissao[0]["DT_OCORRENCIA"], 10));
            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9700()
        {
            IniciarTesteFG07("9700", "", OperadoraEnum.TIM);

            //ENVIA A PRIMEIRA PARCELA PARA A ODS
            SalvaExecutaEValidaTrinca(true);

            //ENVIAR BAIXA DA PARCELA
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);
            AjustarArquivoDeBaixaParaParcela(trinca.ArquivoParcEmissao, arquivo, 1, "18");//Arquivo Parc TIM, primeira parcela linha 1
            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9701()
        {
            IniciarTesteFG07("9701", "", OperadoraEnum.TIM);

            emissaoRegras.AdicionarNovaCoberturaNaEmissao(trinca.ArquivoParcEmissao, dados, 1,
            dados.ObterCoberturaDiferenteDe(trinca.ArquivoParcEmissao[1]["CD_COBERTURA"], trinca.ArquivoParcEmissao.Header[0]["CD_TPA"], true));

            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao.ObterLinha(2), trinca.ArquivoComissao.ObterLinha(1));//Arquivo Parc TIM, primeira parcela linha 1

            //ENVIA A PRIMEIRA PARCELA PARA A ODS
            SalvaExecutaEValidaTrinca(true);

            //ENVIAR BAIXA DA PARCELA
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);
            AjustarArquivoDeBaixaParaParcela(trinca.ArquivoParcEmissao, arquivo, 1, "18");//Arquivo Parc TIM, primeira parcela linha 1
            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);
        }

    }
}
