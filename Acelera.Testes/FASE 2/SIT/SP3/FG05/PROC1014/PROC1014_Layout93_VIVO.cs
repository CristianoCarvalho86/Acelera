using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC1012
{
    [TestClass]
    public class PROC1014_Layout93_VIVO : TestesFG05
    {
        /// <summary>
        /// vl_premio_liquido inferior ao parametrizado para o (percentualmente) na tabela 7012
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4666()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4666", "FG05 - PROC1014");

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var cobertura = dados.ObterCoberturaPeloCodigo(ObterValorFormatado(0, "CD_COBERTURA"));
            var valorTotalLiq = ObterValorPremioTotalLiquido(decimal.Parse(ObterValorFormatado(0, "VL_IS")), cobertura);
            
            if (cobertura.TP_APLICACAO_PREMIO_LQ == "PC")
                valorTotalLiq = valorTotalLiq - (valorTotalLiq * cobertura.ValorPremioLiquidoMenorDecimal) - 0.05M;
            else
                valorTotalLiq = valorTotalLiq - cobertura.ValorPremioLiquidoMenorDecimal - 0.05M;

            AlterarLinha(0, "VL_PREMIO_LIQUIDO", valorTotalLiq.ValorFormatado());

            //Salvar e executar
            SalvarArquivo();
            
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }
    }
}
