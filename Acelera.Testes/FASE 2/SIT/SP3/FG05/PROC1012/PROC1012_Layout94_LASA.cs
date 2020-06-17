using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC1012
{
    [TestClass]
    public class PROC1012_Layout94_LASA : TestesFG05
    {
        /// <summary>
        /// VL_PREMIO_TOTAL inferior ao parametrizado para o CD_COBERTURA (percentualmente) na tabela 7012
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4655()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4655", "FG05 - PROC1012");

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var cobertura = dados.ObterCoberturaPeloCodigo(ObterValorFormatado(0, "CD_COBERTURA")) ;
            decimal valorTotal = 0;
            valorTotal = ObterValorPremioTotalBruto(ObterValorFormatado(0, "VL_IS").ObterValorDecimal(), cobertura);

            if (cobertura.TP_APLICACAO_PREMIO_BR == "PC")
                valorTotal = valorTotal - (valorTotal * cobertura.ValorPremioBrutoMenorDecimal) - 0.05M;
            else
                valorTotal = valorTotal - cobertura.ValorPremioBrutoMenorDecimal - 0.05M;

            AlterarLinha(0, "VL_PREMIO_TOTAL", valorTotal.ValorFormatado());
            AlterarLinha(0, "CD_SUCURSAL", dados.ObterParceiroNegocio("SU", true));
            AlterarLinha(0, "VL_LMI", ObterValor(0, "VL_IS"));

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "1012", 1);
        }

        /// <summary>
        /// VL_PREMIO_TOTAL inferior ao parametrizado para o CD_COBERTURA (percentualmente) na tabela 7012
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4656()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4656", "FG05 - PROC1012");

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var cobertura = dados.ObterCoberturaPeloCodigo(ObterValorFormatado(0, "CD_COBERTURA"));
            decimal valorTotal = 0;
            valorTotal = ObterValorPremioTotalBruto(ObterValorFormatado(0, "VL_IS").ObterValorDecimal(), cobertura);

            if (cobertura.TP_APLICACAO_PREMIO_BR == "PC")
                valorTotal = valorTotal - (valorTotal * cobertura.ValorPremioBrutoMenorDecimal) + 0.05M;
            else
                valorTotal = valorTotal - cobertura.ValorPremioBrutoMenorDecimal + 0.05M;

            AlterarLinha(0, "VL_PREMIO_TOTAL", valorTotal.ValorFormatado());
            AlterarLinha(0, "CD_SUCURSAL", dados.ObterParceiroNegocio("SU", true));
            AlterarLinha(0, "VL_LMI", ObterValor(0, "VL_IS"));

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "1012", 1);
        }

        /// <summary>
        /// VL_PREMIO_TOTAL inferior ao parametrizado para o CD_COBERTURA (percentualmente) na tabela 7012
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4657()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4657", "FG05 - PROC1012");

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var cobertura = dados.ObterCoberturaPeloCodigo(ObterValorFormatado(0, "CD_COBERTURA"));
            decimal valorTotal = 0;
            valorTotal = ObterValorPremioTotalBruto(ObterValorFormatado(0, "VL_IS").ObterValorDecimal(), cobertura);

            //if (cobertura.TP_APLICACAO_PREMIO_BR == "PC")
            //    valorTotal = valorTotal - (valorTotal * cobertura.ValorPremioBrutoMenorDecimal);
            //else
            //    valorTotal = valorTotal - cobertura.ValorPremioBrutoMenorDecimal;

            //AlterarLinha(0, "VL_PREMIO_TOTAL", valorTotal.ValorFormatado());

            AlterarLinha(0, "VL_PREMIO_TOTAL", "30");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "1.50");
            AlterarLinha(0, "CD_SUCURSAL", dados.ObterParceiroNegocio("SU", true));
            AlterarLinha(0, "VL_LMI", ObterValor(0, "VL_IS"));

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }
    }
}
