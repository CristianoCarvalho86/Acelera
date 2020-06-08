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
    public class PROC1015_Layout94_LASA : TestesFG05
    {
        /// <summary>
        /// vl_premio_liquido inferior ao parametrizado para o (percentualmente) na tabela 7012
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4671()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4671", "FG05 - PROC1015");

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var cobertura = dados.ObterCoberturaPeloCodigo(ObterValorFormatado(0, "CD_COBERTURA"));
            var valorIof = ObterValorPremioTotalBruto(ObterValorFormatado(0, "VL_IS").ObterValorDecimal(), cobertura);

            if (cobertura.TP_APLICACAO_IOF == "PC")
                valorIof = valorIof - (valorIof * cobertura.VL_IOF_MENOR_decimal) - 0.05M;
            else
                valorIof = valorIof - cobertura.VL_IOF_MENOR_decimal - 0.05M;

            AlterarLinha(0, "VL_IOF", valorIof.ValorFormatado()) ;
            AlterarLinha(0, "CD_SUCURSAL", "71");
            AlterarLinha(0, "VL_LMI", ObterValor(0, "VL_IS"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF").ValorFormatado());
            RemoverLinhasExcetoAsPrimeiras(1);

            //Salvar e executar
            SalvarArquivo("PROC1015");
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "1015", 1);
        }

        /// <summary>
        /// vl_premio_liquido inferior ao parametrizado para o (percentualmente) na tabela 7012
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4672()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4672", "FG05 - PROC1015");

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var cobertura = dados.ObterCoberturaPeloCodigo(ObterValorFormatado(0, "CD_COBERTURA"));
            var valorIof = ObterValorCalculadoIOF(decimal.Parse(ObterValor(0, "VL_IS")), cobertura);

            if (cobertura.TP_APLICACAO_IOF == "PC")
                valorIof = valorIof - (valorIof * cobertura.VL_IOF_MENOR_decimal) + 0.05M;
            else
                valorIof = valorIof - cobertura.VL_IOF_MENOR_decimal + 0.05M;

            AlterarLinha(0, "VL_IOF", valorIof.ValorFormatado());

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "1015", 1);
        }

        /// <summary>
        /// vl_premio_liquido inferior ao parametrizado para o (percentualmente) na tabela 7012
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4673()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4673", "FG05 - PROC1015");

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var cobertura = dados.ObterCoberturaPeloCodigo(ObterValorFormatado(0, "CD_COBERTURA"));
            var valorIof = ObterValorCalculadoIOF(decimal.Parse(ObterValor(0, "VL_IS")), cobertura);

            if (cobertura.TP_APLICACAO_IOF == "PC")
                valorIof = valorIof - (valorIof * cobertura.VL_IOF_MENOR_decimal);
            else
                valorIof = valorIof - cobertura.VL_IOF_MENOR_decimal;

            AlterarLinha(0, "VL_IOF", valorIof.ValorFormatado());

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }
    }
}
