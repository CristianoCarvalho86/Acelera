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
    public class PROC1012_Layout93_VIVO : TestesFG05
    {
        /// <summary>
        /// VL_PREMIO_TOTAL inferior ao parametrizado para o CD_COBERTURA (percentualmente) na tabela 7012
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4658()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4658", "FG05 - PROC1012");

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var cobertura = dados.ObterCoberturaPeloCodigo(ObterValorFormatado(0, "CD_COBERTURA")) ;
            decimal valorTotal = 0;
            valorTotal = ObterValorPremioTotalBruto(decimal.Parse(ObterValorFormatado(0, "VL_IS")), cobertura);

            if (cobertura.TP_APLICACAO_PREMIO_BR == "PC")
                valorTotal = valorTotal - (valorTotal * cobertura.ValorPremioBrutoMenorDecimal) - 0.05M;
            else
                valorTotal = valorTotal - cobertura.ValorPremioBrutoMenorDecimal - 0.05M;

            AlterarLinha(0, "VL_PREMIO_TOTAL", valorTotal.ToString()) ;

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "1012", 1);
        }

    }
}
