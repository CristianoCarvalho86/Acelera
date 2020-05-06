using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC44
{
    [TestClass]
    public class PROC44_Layout94_LASA : TestesFG05
    {

        /// <summary>
        /// Enviar 1º arquivo para ODS com apólice com código de cancelamento e ID_TRANSACAO_CANC preenchido no formato correto. Arquivo deve ser gravado na tabela ODS 
        /// Enviar 2º arquivo pela esteira, com a mesma apólice, mesmo ID_TRANSACAO_CANC e CD_TIPO_EMISSAO=10 
        /// O cd_tipo_emissao dos dois arquivos deve ser diferente, porém ambos devem ser de cancelamento.
        /// </summary>
        [TestMethod]
        [TestCategory("Comm Critica")]
        public void SAP_4374()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4374", "FG05 - PROC44 - ");
            

            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.LASA);

            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOds(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods2 ,1 , OperadoraEnum.LASA);

            
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "11");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);

            EnviarParaOds(arquivoods2);

            //Enviar parc com msmo id cancelamento mas tipo emissao diferente
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "44", 1);
        }

        /// <summary>
        /// Enviar 1º arquivo para ODS com apólice com código de cancelamento e ID_TRANSACAO_CANC preenchido no formato correto. Arquivo deve ser gravado na tabela ODS 
        /// Enviar 2º arquivo pela esteira, com a mesma apólice, mesmo ID_TRANSACAO_CANC e CD_TIPO_EMISSAO=10 
        /// O cd_tipo_emissao dos dois arquivos deve ser diferente, porém ambos devem ser de cancelamento.
        /// </summary>
        [TestMethod]
        [TestCategory("Comm Critica")]
        public void SAP_4375()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4375", "FG05 - PROC44 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.LASA);

            var idCanc = ObterValor(0, "ID_TRANSACAO");

            EnviarParaOds(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.LASA);


            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);

            EnviarParaOds(arquivoods2);

            //Enviar parc com msmo id cancelamento mas tipo emissao diferente
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "44", 1);
        }
    }
}
