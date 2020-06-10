using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC1015
{
    [TestClass]
    public class PROC1015_Layout94_POMPEIA : TestesFG05
    {
        /// <summary>
        /// vl_premio_liquido inferior ao parametrizado para o (percentualmente) na tabela 7012
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4675()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4675", "FG05 - PROC1015");

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            //Alterar arquivo
            var cobertura = dados.ObterCoberturaSimples(ObterValorHeader("CD_TPA"));
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "CD_RAMO", cobertura.CdRamo);
            AlterarLinha(0, "CD_PRODUTO", cobertura.CdProduto);
            AlterarLinha(0, "VL_PREMIO_TOTAL", ObterValorFormatado(0, "VL_PREMIO_TOTAL") + 6);
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", ObterValorFormatado(0, "VL_PREMIO_LIQUIDO") + 3);
            AlterarLinha(0, "VL_IOF", ObterValorFormatado(0, "VL_IOF") + 3);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }
    }
    }

