﻿using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC1014
{
    [TestClass]
    public class PROC1014_Layout94_SOFTBOX : TestesFG05
    {
        /// <summary>
        /// vl_premio_liquido inferior ao parametrizado para o (percentualmente) na tabela 7012
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4668()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4668", "FG05 - PROC1014");

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-2751-20200211.txt"));

            //Alterar arquivo
            var cobertura = dados.ObterCoberturaPeloCodigo(ObterValorFormatado(0, "CD_COBERTURA"));
            decimal valorTotalLiq = 0;
            valorTotalLiq = ObterValorPremioTotalBruto(ObterValorFormatado(0, "VL_IS").ObterValorDecimal(), cobertura);

            if (cobertura.TP_APLICACAO_PREMIO_LQ == "PC")
                valorTotalLiq = valorTotalLiq - (valorTotalLiq * cobertura.ValorPremioLiquidoMenorDecimal) - 0.05M;
            else
                valorTotalLiq = valorTotalLiq - cobertura.ValorPremioLiquidoMenorDecimal - 0.05M;


            AlterarLinha(0, "VL_PREMIO_LIQUIDO", valorTotalLiq.ValorFormatado());
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF").ValorFormatado());
            AlterarLinha(0, "VL_LMI", ObterValor(0, "VL_IS"));

            //Salvar e executar
            SalvarArquivo("PROC1014");
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "1014", 1);
        }

        /// <summary>
        /// vl_premio_liquido inferior ao parametrizado para o (percentualmente) na tabela 7012
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4669()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4669", "FG05 - PROC1014");

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            //Alterar arquivo
            var cobertura = dados.ObterCoberturaPeloCodigo(ObterValorFormatado(0, "CD_COBERTURA"));
            decimal valorTotalLiq = 0;
            valorTotalLiq = ObterValorPremioTotalBruto(ObterValorFormatado(0, "VL_IS").ObterValorDecimal(), cobertura);

            if (cobertura.TP_APLICACAO_PREMIO_LQ == "PC")
                valorTotalLiq = valorTotalLiq - (valorTotalLiq * cobertura.ValorPremioLiquidoMenorDecimal) + 0.05M;
            else
                valorTotalLiq = valorTotalLiq - cobertura.ValorPremioLiquidoMenorDecimal + 0.05M;


            AlterarLinha(0, "VL_PREMIO_LIQUIDO", valorTotalLiq.ValorFormatado());
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF").ValorFormatado());
            AlterarLinha(0, "VL_LMI", ObterValor(0, "VL_IS"));

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "1014", 1);
        }

        /// <summary>
        /// vl_premio_liquido inferior ao parametrizado para o (percentualmente) na tabela 7012
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4670()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4670", "FG05 - PROC1014");

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            //Alterar arquivo
            var cobertura = dados.ObterCoberturaPeloCodigo(ObterValorFormatado(0, "CD_COBERTURA"));
            var valorTotalLiq = ObterValorPremioTotalLiquido(decimal.Parse(ObterValorFormatado(0, "VL_IS")), cobertura);

            if (cobertura.TP_APLICACAO_PREMIO_LQ == "PC")
                valorTotalLiq = valorTotalLiq - (valorTotalLiq * cobertura.ValorPremioLiquidoMenorDecimal);
            else
                valorTotalLiq = valorTotalLiq - cobertura.ValorPremioLiquidoMenorDecimal;


            AlterarLinha(0, "VL_PREMIO_LIQUIDO", valorTotalLiq.ValorFormatado());

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }
    }
}
