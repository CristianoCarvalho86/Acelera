using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC212
{
    [TestClass]
    public class PROC212_Layout94_LASA : TestesFG05
    {

        /// <summary>
        /// Enviar 1º arquivo para ODS com apólice com código de cancelamento e ID_TRANSACAO_CANC preenchido no formato correto. Arquivo deve ser gravado na tabela ODS 
        /// Enviar 2º arquivo pela esteira, com a mesma apólice, mesmo ID_TRANSACAO_CANC e CD_TIPO_EMISSAO=10 
        /// O cd_tipo_emissao dos dois arquivos deve ser diferente, porém ambos devem ser de cancelamento.
        /// </summary>
        [TestMethod]
        [TestCategory("Comm Critica")]
        public void SAP_()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3801", "FG05 - PROC212 - ");

            var arquivoods = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods ,1 , OperadoraEnum.LASA);

            arquivoods.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods.AlterarLinha(0, "NR_SEQ_EMISSAO", "1");

            EnviarParaOds(arquivoods);

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_SEQ_EMISSAO"});
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "212", 1);


        }

    }
}
