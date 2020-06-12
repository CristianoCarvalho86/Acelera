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
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=9. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4515_()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4515", "FG05 - PROC212 - ");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            
            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), "00002"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "9");
            AlterarLinha(0, "ID_TRANSACAO_CANC", SomarValor(0, "ID_TRANSACAO", 1));
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", "12345");

            SalvarArquivo();

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

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);


            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), "00002"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "9");
            AlterarLinha(0, "ID_TRANSACAO_CANC", SomarValor(0, "ID_TRANSACAO", 2));
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "3");
            AlterarLinha(0, "NR_ENDOSSO", "12345");

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

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), "00002"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(0, "ID_TRANSACAO_CANC", SomarValor(0, "ID_TRANSACAO", 3));
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "4");
            AlterarLinha(0, "NR_ENDOSSO", "12345");

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

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), "00003"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "12");
            AlterarLinha(0, "ID_TRANSACAO_CANC", SomarValor(0, "ID_TRANSACAO", 4));
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "5");
            AlterarLinha(0, "NR_ENDOSSO", "12345");

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

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), "00004"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "13");
            AlterarLinha(0, "ID_TRANSACAO_CANC", SomarValor(0, "ID_TRANSACAO", 5));
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "6");
            AlterarLinha(0, "NR_ENDOSSO", "12345");

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

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), "00005"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "21");
            AlterarLinha(0, "ID_TRANSACAO_CANC", SomarValor(0, "ID_TRANSACAO", 6));
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "7");
            AlterarLinha(0, "NR_ENDOSSO", "12345");

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

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            

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

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            

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

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            

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

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            

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

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);


        }

        /// <summary>
        /// Em um arquivo, enviar emissão da apolice com CD_TIPO_EMISSAO=20 e NR_SEQ_EMISSAO=1.Registro deve ser gravado na ODS. 
        /// Em outro arquivo, enviar emissão de cancelamento do mesmo contrato, informando CD_TIPO_EMISSAO=11. Manter NR_SEQ_EMISSAO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4532_()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4532", "FG05 - PROC212 - ");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

    }
}
