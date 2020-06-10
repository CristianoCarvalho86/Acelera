using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC227
{
    [TestClass]
    public class PROC227_Layout94_SOFTBOX : TestesFG05
    {

        /// <summary>
        /// Enviar primeiro arquivo PARC para a ODS com DT_INICIO_VIGENCIA e DT_FIM VIGENCIA. 
        /// Após registro gravado, enviar outro arquivo SINISTRO cuja DT_OCORRENCIA seja inferior a DT_INICIO_VIGENCIA da apólice (do 1o arquivo)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4631()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4631", "FG05 - PROC227 - ");

            arquivo = new Arquivo_Layout_9_4_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            var cdCliente = ObterValor(0, "CD_CLIENTE");
            AlterarLinha(0, "DT_NASCIMENTO", "");

            EnviarParaOds(arquivo, true, "PROC227_4631");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CLIENTE", cdCliente);
            AlterarLinha(0, "CD_SUCURSAL", "71");
            AlterarLinha(0, "VL_LMI", ObterValor(0, "VL_IS"));
            AlterarLinha(0, "DT_INICIO_VIGENCIA", ObterValor(0, "DT_EMISSAO"));


            SalvarArquivo(false, "PROC227_4631");

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "227", 1);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4633()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4633", "FG05 - PROC227 - ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

    }
}
