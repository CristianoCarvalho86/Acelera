using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC44
{
    [TestClass]
    public class PROC44_Layout94_VIVO : TestesFG05
    {

        /// <summary>
        /// Enviar 1º arquivo para ODS com apólice com código de cancelamento e ID_TRANSACAO_CANC preenchido no formato correto. Arquivo deve ser gravado na tabela ODS 
        /// Enviar 2º arquivo pela esteira, com a mesma apólice, mesmo ID_TRANSACAO_CANC e CD_TIPO_EMISSAO=10 
        /// O cd_tipo_emissao dos dois arquivos deve ser diferente, porém ambos devem ser de cancelamento.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4359()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4359", "FG05 - PROC44 - ");
            

            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.VIVO);

            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");
            var seqEMS = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"),"1");
            var seqEMS1 = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "2");

            EnviarParaOds(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods2 ,1 , OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO",seqEMS);
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000002");


            EnviarParaOds(arquivoods2);

            //Enviar parc com msmo id cancelamento mas tipo emissao diferente
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "9");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS1);
            AlterarLinha(0, "NR_ENDOSSO", "12340000003");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "44", 1);
        }

        /// <summary>
        /// Enviar 1º arquivo para ODS com apólice com código de cancelamento e ID_TRANSACAO_CANC preenchido no formato correto. Arquivo deve ser gravado na tabela ODS 
        /// Enviar 2º arquivo pela esteira, com a mesma apólice, mesmo ID_TRANSACAO_CANC e CD_TIPO_EMISSAO=10 
        /// O cd_tipo_emissao dos dois arquivos deve ser diferente, porém ambos devem ser de cancelamento.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4360()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4360", "FG05 - PROC44 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.VIVO);

            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");
            var seqEMS = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "1");
            var seqEMS1 = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "2");

            EnviarParaOds(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "9");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS);
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000002");


            EnviarParaOds(arquivoods2);

            //Enviar parc com msmo id cancelamento mas tipo emissao diferente
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS1);
            AlterarLinha(0, "NR_ENDOSSO", "12340000003");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "44", 1);
        }

        /// <summary>
        /// Enviar 1º arquivo para ODS com apólice com código de cancelamento e ID_TRANSACAO_CANC preenchido no formato correto. Arquivo deve ser gravado na tabela ODS 
        /// Enviar 2º arquivo pela esteira, com a mesma apólice, mesmo ID_TRANSACAO_CANC e CD_TIPO_EMISSAO=10 
        /// O cd_tipo_emissao dos dois arquivos deve ser diferente, porém ambos devem ser de cancelamento.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4361()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4361", "FG05 - PROC44 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.VIVO);

            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");
            var seqEMS = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "1");
            var seqEMS1 = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "2");

            EnviarParaOds(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS);
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000002");


            EnviarParaOds(arquivoods2);

            //Enviar parc com msmo id cancelamento mas tipo emissao diferente
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "12");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "03");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS1);
            AlterarLinha(0, "NR_ENDOSSO", "12340000003");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "44", 1);
        }

        /// <summary>
        /// Enviar 1º arquivo para ODS com apólice com código de cancelamento e ID_TRANSACAO_CANC preenchido no formato correto. Arquivo deve ser gravado na tabela ODS 
        /// Enviar 2º arquivo pela esteira, com a mesma apólice, mesmo ID_TRANSACAO_CANC e CD_TIPO_EMISSAO=10 
        /// O cd_tipo_emissao dos dois arquivos deve ser diferente, porém ambos devem ser de cancelamento.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4362()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4362", "FG05 - PROC44 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.VIVO);

            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");
            var seqEMS = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "1");
            var seqEMS1 = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "2");

            EnviarParaOds(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "21");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS);
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000002");


            EnviarParaOds(arquivoods2);

            //Enviar parc com msmo id cancelamento mas tipo emissao diferente
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "13");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS1);
            AlterarLinha(0, "NR_ENDOSSO", "12340000003");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "44", 1);
        }

        /// <summary>
        /// Enviar 1º arquivo para ODS com apólice com código de cancelamento e ID_TRANSACAO_CANC preenchido no formato correto. Arquivo deve ser gravado na tabela ODS 
        /// Enviar 2º arquivo pela esteira, com a mesma apólice, mesmo ID_TRANSACAO_CANC e CD_TIPO_EMISSAO=10 
        /// O cd_tipo_emissao dos dois arquivos deve ser diferente, porém ambos devem ser de cancelamento.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4363()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4363", "FG05 - PROC44 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.VIVO);

            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");
            var seqEMS = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "1");
            var seqEMS1 = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "2");

            EnviarParaOds(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "9");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS);
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000002");


            EnviarParaOds(arquivoods2);

            //Enviar parc com msmo id cancelamento mas tipo emissao diferente
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "21");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS1);
            AlterarLinha(0, "NR_ENDOSSO", "12340000003");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "44", 1);
        }

        /// <summary>
        /// Enviar 1º arquivo para STG com apólice com código de cancelamento e ID_TRANSACAO_CANC preenchido no formato correto. 
        /// Arquivo deve ser gravado na tabela STG Enviar 2º arquivo pela esteira, com a mesma apólice, ID_TRANSACAO_CANC em outro formato e CD_TIPO_EMISSAO=10 (ex.: refereindo-se a outro endosso do mesmo contrato) 
        /// O cd_tipo_emissao dos dois arquivos deve ser diferente, porém ambos devem ser de cancelamento.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4369()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4384", "FG05 - PROC44 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.VIVO);

            var idCanc = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO"), "1");
            var seqEMS = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "1");
            var seqEMS1 = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "2");

            EnviarParaOds(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS);
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000002");


            EnviarParaOds(arquivoods2);

            //Enviar parc com msmo id cancelamento mas tipo emissao diferente
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "9");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS1);
            AlterarLinha(0, "NR_ENDOSSO", "12340000003");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        /// <summary>
        /// Enviar 1º arquivo para STG com apólice com código de cancelamento e ID_TRANSACAO_CANC preenchido no formato correto. 
        /// Arquivo deve ser gravado na tabela STG Enviar 2º arquivo pela esteira, com a mesma apólice, ID_TRANSACAO_CANC em outro formato e CD_TIPO_EMISSAO=10 (ex.: refereindo-se a outro endosso do mesmo contrato) 
        /// O cd_tipo_emissao dos dois arquivos deve ser diferente, porém ambos devem ser de cancelamento.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4370()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4385", "FG05 - PROC44 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.VIVO);

            var idCanc = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO"), "1");
            var seqEMS = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "1");
            var seqEMS1 = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "2");

            EnviarParaOds(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "11");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS);
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000002");


            EnviarParaOds(arquivoods2);

            //Enviar parc com msmo id cancelamento mas tipo emissao diferente
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS1);
            AlterarLinha(0, "NR_ENDOSSO", "12340000003");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        /// <summary>
        /// Enviar 1º arquivo para STG com apólice com código de cancelamento e ID_TRANSACAO_CANC preenchido no formato correto. 
        /// Arquivo deve ser gravado na tabela STG Enviar 2º arquivo pela esteira, com a mesma apólice, ID_TRANSACAO_CANC em outro formato e CD_TIPO_EMISSAO=10 (ex.: refereindo-se a outro endosso do mesmo contrato) 
        /// O cd_tipo_emissao dos dois arquivos deve ser diferente, porém ambos devem ser de cancelamento.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4371()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4385", "FG05 - PROC44 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.VIVO);

            var idCanc = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO"), "1");
            var seqEMS = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "1");
            var seqEMS1 = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "2");

            EnviarParaOds(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS);
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000002");


            EnviarParaOds(arquivoods2);

            //Enviar parc com msmo id cancelamento mas tipo emissao diferente
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "12");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "03");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS1);
            AlterarLinha(0, "NR_ENDOSSO", "12340000003");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        /// <summary>
        /// Enviar 1º arquivo para STG com apólice com código de cancelamento e ID_TRANSACAO_CANC preenchido no formato correto. 
        /// Arquivo deve ser gravado na tabela STG Enviar 2º arquivo pela esteira, com a mesma apólice, ID_TRANSACAO_CANC em outro formato e CD_TIPO_EMISSAO=10 (ex.: refereindo-se a outro endosso do mesmo contrato) 
        /// O cd_tipo_emissao dos dois arquivos deve ser diferente, porém ambos devem ser de cancelamento.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4372()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4372", "FG05 - PROC44 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.VIVO);

            var idCanc = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO"), "1");
            var seqEMS = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "1");
            var seqEMS1 = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "2");

            EnviarParaOds(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "09");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS);
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000002");


            EnviarParaOds(arquivoods2);

            //Enviar parc com msmo id cancelamento mas tipo emissao diferente
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "13");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS1);
            AlterarLinha(0, "NR_ENDOSSO", "12340000003");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        /// <summary>
        /// Enviar 1º arquivo para STG com apólice com código de cancelamento e ID_TRANSACAO_CANC preenchido no formato correto. 
        /// Arquivo deve ser gravado na tabela STG Enviar 2º arquivo pela esteira, com a mesma apólice, ID_TRANSACAO_CANC em outro formato e CD_TIPO_EMISSAO=10 (ex.: refereindo-se a outro endosso do mesmo contrato) 
        /// O cd_tipo_emissao dos dois arquivos deve ser diferente, porém ambos devem ser de cancelamento.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4373()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4373", "FG05 - PROC44 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.VIVO);

            var idCanc = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO"), "1");
            var seqEMS = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "1");
            var seqEMS1 = SomarValores(arquivoods1.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "2");

            EnviarParaOds(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "13");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS);
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000002");


            EnviarParaOds(arquivoods2);

            //Enviar parc com msmo id cancelamento mas tipo emissao diferente
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "21");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS1);
            AlterarLinha(0, "NR_ENDOSSO", "12340000003");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }
    }
}
