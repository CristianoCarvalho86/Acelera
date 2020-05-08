using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC212
{
    [TestClass]
    public class PROC212_Layout93_VIVO : TestesFG05
    {

        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=10. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4515()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4515", "FG05 - PROC212 - ");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo ,1 , OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivo.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOds(arquivo, true, "PROC212");
            var arquivoods = arquivo.Clone();

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "9");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo(true, "PROC212");

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "212", 1);


        }

        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=11. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4516()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4516", "FG05 - PROC212 - ");

            var arquivoods = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.VIVO);

            arquivoods.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods.AlterarLinha(0, "NR_SEQ_EMISSAO", "1");
            arquivoods.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOds(arquivoods);

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "212", 1);


        }

        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=11. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4517()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4517", "FG05 - PROC212 - ");

            var arquivoods = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.VIVO);

            arquivoods.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods.AlterarLinha(0, "NR_SEQ_EMISSAO", "1");
            arquivoods.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOds(arquivoods);

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "212", 1);


        }

        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=11. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4518()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4518", "FG05 - PROC212 - ");

            var arquivoods = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.VIVO);

            arquivoods.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods.AlterarLinha(0, "NR_SEQ_EMISSAO", "1");
            arquivoods.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOds(arquivoods);

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "12");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "212", 1);


        }

        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=11. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4519()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4519", "FG05 - PROC212 - ");

            var arquivoods = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.VIVO);

            arquivoods.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods.AlterarLinha(0, "NR_SEQ_EMISSAO", "1");
            arquivoods.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOds(arquivoods);

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "13");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "212", 1);


        }

        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=11. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4520()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4520", "FG05 - PROC212 - ");

            var arquivoods = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.VIVO);

            arquivoods.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods.AlterarLinha(0, "NR_SEQ_EMISSAO", "1");
            arquivoods.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOds(arquivoods);

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "21");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "212", 1);


        }


        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=11. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4527()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4527", "FG05 - PROC212 - ");

            var arquivoods = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.VIVO);

            arquivoods.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods.AlterarLinha(0, "NR_SEQ_EMISSAO", "1");
            arquivoods.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOds(arquivoods);

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "9");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);


        }

        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=11. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4528()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4528", "FG05 - PROC212 - ");

            var arquivoods = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.VIVO);

            arquivoods.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods.AlterarLinha(0, "NR_SEQ_EMISSAO", "1");
            arquivoods.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOds(arquivoods);

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);


        }

        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=11. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4529()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4529", "FG05 - PROC212 - ");

            var arquivoods = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.VIVO);

            arquivoods.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods.AlterarLinha(0, "NR_SEQ_EMISSAO", "1");
            arquivoods.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOds(arquivoods);

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);


        }

        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=11. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4530()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4530", "FG05 - PROC212 - ");

            var arquivoods = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.VIVO);

            arquivoods.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods.AlterarLinha(0, "NR_SEQ_EMISSAO", "1");
            arquivoods.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOds(arquivoods);

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "12");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);


        }

        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=11. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4531()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4531", "FG05 - PROC212 - ");

            var arquivoods = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.VIVO);

            arquivoods.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods.AlterarLinha(0, "NR_SEQ_EMISSAO", "1");
            arquivoods.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOds(arquivoods);

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "13");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);


        }

        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=11. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4532()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4532", "FG05 - PROC212 - ");

            var arquivoods = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.VIVO);

            arquivoods.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods.AlterarLinha(0, "NR_SEQ_EMISSAO", "1");
            arquivoods.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOds(arquivoods);

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "21");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);


        }

    }
}
