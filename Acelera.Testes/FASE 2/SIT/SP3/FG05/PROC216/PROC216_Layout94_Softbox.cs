﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC216
{
    [TestClass]
    public class PROC216_Layout94_SOFTBOX : TestesFG05
    {

        /// <summary>
        /// Em 1 arquivo PARC, informar valor
        /// total do prêmio total da cobertura. Este arquivo deve estar na ODS. 
        /// Em outro arquivo COMISSAO, após o PARC estar na STAGE, 
        /// informar apenas uma linha com este contrato e cobertura, 
        /// sendo o VL_COMISSAO superior ao VL_PREMIO_TOTAL do arquivo PARC
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4587()
        {
            IniciarTeste(TipoArquivo.Comissao, "4587", "FG05 - PROC216");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), "111130"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "50");
            AlterarLinha(0, "VL_IOF", "50");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));

            EnviarParaOds(arquivo, true);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_CORRETOR" };
            IgualarCampos(arquivoods, arquivo, campos);
            AlterarLinha(0, "VL_COMISSAO", "110");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");

            //Salvar e executar
            SalvarArquivo(true);
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "216", 1);
        }

        /// <summary>
        /// Em 1 arquivo PARC, informar valor total do prêmio total da cobertura. Este arquivo deve estar na ODS. 
        /// Em outro arquivo COMISSAO, após o PARC estar na STAGE, informar duas linha com este contrato e cobertura (Comissao e Pro Labore)
        /// sendo o VL_COMISSAO somado superior ao VL_PREMIO_TOTAL do arquivo PARC
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4588()
        {
            IniciarTeste(TipoArquivo.Comissao, "4588", "FG05 - PROC216");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), "111132"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "50");
            AlterarLinha(0, "VL_IOF", "50");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));

            EnviarParaOds(arquivo, true);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 2, OperadoraEnum.SOFTBOX);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_CORRETOR" };
            IgualarCampos(arquivoods, arquivo, campos, true);
            AlterarLinha(0, "VL_COMISSAO", "60");
            AlterarLinha(1, "VL_COMISSAO", "60");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(1, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "216", 1);
        }

        /// <summary>
        /// Em 1 arquivo PARC, informar valor total do prêmio total da cobertura. Este arquivo deve estar na ODS. 
        /// Em outro arquivo COMISSAO, após o PARC estar na STAGE, informar duas linha com este contrato e cobertura (Comissao e Pro Labore)
        /// sendo o VL_COMISSAO somado superior ao VL_PREMIO_TOTAL do arquivo PARC
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4589()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4587", "FG05 - PROC216");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), "111132"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "50");
            AlterarLinha(0, "VL_IOF", "50");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));

            EnviarParaOds(arquivo, true);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 3, OperadoraEnum.SOFTBOX);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_CORRETOR" };
            IgualarCampos(arquivoods, arquivo, campos, true);
            AlterarLinha(0, "VL_COMISSAO", "60");
            AlterarLinha(1, "VL_COMISSAO", "60");
            AlterarLinha(2, "VL_COMISSAO", "60");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(1, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(2, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));
            AlterarLinha(2, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 2));

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "216", 1);
        }

        /// <summary>
        /// Em 1 arquivo PARC, informar valor total do prêmio total da cobertura. Este arquivo deve estar na ODS. 
        /// Em outro arquivo COMISSAO, após o PARC estar na STAGE, informar apenas uma linha com este contrato e cobertura, sendo o VL_COMISSAO inferior ao VL_PREMIO_TOTAL do arquivo PARC
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4593()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4593", "FG05 - PROC216");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "50");
            AlterarLinha(0, "VL_IOF", "50");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));

            EnviarParaOds(arquivo, true);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_CORRETOR" };
            IgualarCampos(arquivoods, arquivo, campos, true);
            AlterarLinha(0, "VL_COMISSAO", "40");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "216");
        }

        /// <summary>
        /// Em 1 arquivo PARC, informar valor total do prêmio total da cobertura. Este arquivo deve estar na ODS. 
        /// Em outro arquivo COMISSAO, após o PARC estar na STAGE, informar apenas uma linha com este contrato e cobertura, sendo o VL_COMISSAO inferior ao VL_PREMIO_TOTAL do arquivo PARC
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4594()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4594", "FG05 - PROC216");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "50");
            AlterarLinha(0, "VL_IOF", "50");
            AlterarLinha(0, "CD_CORRETOR", "7150145");

            EnviarParaOds(arquivo, true);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 2, OperadoraEnum.SOFTBOX);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM" };
            IgualarCampos(arquivoods, arquivo, campos, true);
            AlterarLinha(0, "VL_COMISSAO", "20");
            AlterarLinha(1, "VL_COMISSAO", "20");
            AlterarLinha(0, "CD_CORRETOR", "7150145");
            AlterarLinha(1, "CD_CORRETOR", "7139687");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(1, "CD_TIPO_COMISSAO", "C");
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "216");
        }

        /// <summary>
        /// Em 1 arquivo PARC, informar valor total do prêmio total da cobertura. Este arquivo deve estar na ODS. 
        /// Em outro arquivo COMISSAO, após o PARC estar na STAGE, informar apenas uma linha com este contrato e cobertura, sendo o VL_COMISSAO inferior ao VL_PREMIO_TOTAL do arquivo PARC
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1111()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "1111", "FG05 - PROC219");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 2, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CLIENTE", "00952146");
            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));

            AlterarLinha(1, "CD_CLIENTE", "00952570");
            AlterarLinha(1, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(1, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(1, "CD_CONTRATO", ObterValorFormatado(0, "CD_CONTRATO"));

            SalvarArquivo(false);
        }

    }
}
