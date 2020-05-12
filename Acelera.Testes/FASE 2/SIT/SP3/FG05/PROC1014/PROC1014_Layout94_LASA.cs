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
    public class PROC1014_Layout94_LASA : TestesFG05
    {
        /// <summary>
        /// vl_premio_liquido inferior ao parametrizado para o (percentualmente) na tabela 7012
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4663()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4663", "FG05 - PROC1014");

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var cobertura = dados.ObterCobertura() ;
            var valorTotal = ObterValorPremioTotalLiquido(decimal.Parse(ObterValor(0, "VL_IS")), cobertura);
            
            if (cobertura.TP_APLICACAO_PREMIO_LQ == "PC")
                valorTotal = valorTotal - (valorTotal * cobertura.ValorPremioLiquidoMenorDecimal) - 0.05M;
            else
                valorTotal = valorTotal - cobertura.ValorPremioLiquidoMenorDecimal - 0.05M;


            AlterarLinha(0, "VL_PREMIO_LIQUIDO", valorTotal.ValorFormatado()) ;

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "1014", 1);
        }
    }
}
