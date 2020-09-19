using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC181
{
    [TestClass]
    public class PROC181_Layout94_LASA : TestesFG05
    {

        /// <summary>
        ///Primeiro, enviar arquivo PARC com emissão de apólice. 
        ///Segundo, enviar arquivo com cancelamento dessa apolice (cd_tipo_emissao=10), preenchendo os campos pertinentes a movimentação de cancelamento e aumentando o numero do endosso
        ///Terceiro, enviar arquivo SINISTRO com aviso de sinistro (cd_tipo_movimento=1), referindo-se ao arquivo de cancelamneto (atraves do NR ENDOSSO e NR SEQ EMISSAO)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4499()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4499", "FG05 - PROC181 - ");
            

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivo.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOdsAlterandoCliente(arquivo, true);
            var arquivoods1 = arquivo.Clone();


            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo ,1 , OperadoraEnum.LASA);

            ArquivoUtils.IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO","2");
            AlterarLinha(0, "NR_ENDOSSO", "12340000001");


            EnviarParaOdsAlterandoCliente(arquivo, true);
            var arquivoods2 = arquivo.Clone();

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            ArquivoUtils.IgualarCampos(arquivoods2, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE"});
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "NR_SEQ_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", "12340000001");

            SalvarArquivo(true,"PROC181");

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "181", 1);
        }

        /// <summary>
        ///Primeiro, enviar arquivo PARC com emissão de apólice. 
        ///Segundo, enviar arquivo com cancelamento dessa apolice (cd_tipo_emissao=10), preenchendo os campos pertinentes a movimentação de cancelamento e aumentando o numero do endosso
        ///Terceiro, enviar arquivo SINISTRO com aviso de sinistro (cd_tipo_movimento=1), referindo-se ao arquivo de cancelamneto (atraves do NR ENDOSSO e NR SEQ EMISSAO)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4500()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4500", "FG05 - PROC181 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.LASA);

            arquivoods1.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods1.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            arquivoods1.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOdsAlterandoCliente(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.LASA);

            ArquivoUtils.IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "11");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000001");


            EnviarParaOdsAlterandoCliente(arquivoods2);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            ArquivoUtils.IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE" });
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", "12340000001");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "181", 1);
        }

        /// <summary>
        ///Primeiro, enviar arquivo PARC com emissão de apólice. 
        ///Segundo, enviar arquivo com cancelamento dessa apolice (cd_tipo_emissao=10), preenchendo os campos pertinentes a movimentação de cancelamento e aumentando o numero do endosso
        ///Terceiro, enviar arquivo SINISTRO com aviso de sinistro (cd_tipo_movimento=1), referindo-se ao arquivo de cancelamneto (atraves do NR ENDOSSO e NR SEQ EMISSAO)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4501()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4501", "FG05 - PROC181 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.LASA);

            arquivoods1.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods1.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            arquivoods1.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOdsAlterandoCliente(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.LASA);

            ArquivoUtils.IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000001");


            EnviarParaOdsAlterandoCliente(arquivoods2);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            ArquivoUtils.IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE" });
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", "12340000001");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "181", 1);
        }

        /// <summary>
        ///Primeiro, enviar arquivo PARC com emissão de apólice. 
        ///Segundo, enviar arquivo com cancelamento dessa apolice (cd_tipo_emissao=10), preenchendo os campos pertinentes a movimentação de cancelamento e aumentando o numero do endosso
        ///Terceiro, enviar arquivo SINISTRO com aviso de sinistro (cd_tipo_movimento=1), referindo-se ao arquivo de cancelamneto (atraves do NR ENDOSSO e NR SEQ EMISSAO)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4502()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4502", "FG05 - PROC181 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.LASA);

            arquivoods1.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods1.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            arquivoods1.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOdsAlterandoCliente(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.LASA);

            ArquivoUtils.IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "11");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000001");


            EnviarParaOdsAlterandoCliente(arquivoods2);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            ArquivoUtils.IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE" });
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_ENDOSSO", "12340000001");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "181", 1);
        }

        /// <summary>
        ///Primeiro, enviar arquivo PARC com emissão de apólice. 
        ///Segundo, enviar arquivo com cancelamento dessa apolice (cd_tipo_emissao=10), preenchendo os campos pertinentes a movimentação de cancelamento e aumentando o numero do endosso
        ///Terceiro, enviar arquivo SINISTRO com aviso de sinistro (cd_tipo_movimento=1), referindo-se ao arquivo de cancelamneto (atraves do NR ENDOSSO e NR SEQ EMISSAO)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4503()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4503", "FG05 - PROC181 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.LASA);

            arquivoods1.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods1.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            arquivoods1.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOdsAlterandoCliente(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.LASA);

            ArquivoUtils.IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000001");


            EnviarParaOdsAlterandoCliente(arquivoods2);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            ArquivoUtils.IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE" });
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        /// <summary>
        ///Primeiro, enviar arquivo PARC com emissão de apólice. 
        ///Segundo, enviar arquivo com cancelamento dessa apolice (cd_tipo_emissao=10), preenchendo os campos pertinentes a movimentação de cancelamento e aumentando o numero do endosso
        ///Terceiro, enviar arquivo SINISTRO com aviso de sinistro (cd_tipo_movimento=1), referindo-se ao arquivo de cancelamneto (atraves do NR ENDOSSO e NR SEQ EMISSAO)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4504()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4504", "FG05 - PROC181 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.LASA);

            arquivoods1.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods1.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            arquivoods1.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOdsAlterandoCliente(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.LASA);

            ArquivoUtils.IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "11");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000001");


            EnviarParaOdsAlterandoCliente(arquivoods2);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            ArquivoUtils.IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE" });
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        /// <summary>
        ///Primeiro, enviar arquivo PARC com emissão de apólice. 
        ///Segundo, enviar arquivo com cancelamento dessa apolice (cd_tipo_emissao=10), preenchendo os campos pertinentes a movimentação de cancelamento e aumentando o numero do endosso
        ///Terceiro, enviar arquivo SINISTRO com aviso de sinistro (cd_tipo_movimento=1), referindo-se ao arquivo de cancelamneto (atraves do NR ENDOSSO e NR SEQ EMISSAO)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4505()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4505", "FG05 - PROC181 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.LASA);

            arquivoods1.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods1.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            arquivoods1.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOdsAlterandoCliente(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.LASA);

            ArquivoUtils.IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000001");


            EnviarParaOdsAlterandoCliente(arquivoods2);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            ArquivoUtils.IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE" });
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        /// <summary>
        ///Primeiro, enviar arquivo PARC com emissão de apólice. 
        ///Segundo, enviar arquivo com cancelamento dessa apolice (cd_tipo_emissao=10), preenchendo os campos pertinentes a movimentação de cancelamento e aumentando o numero do endosso
        ///Terceiro, enviar arquivo SINISTRO com aviso de sinistro (cd_tipo_movimento=1), referindo-se ao arquivo de cancelamneto (atraves do NR ENDOSSO e NR SEQ EMISSAO)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4506()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4506", "FG05 - PROC181 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.LASA);

            arquivoods1.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods1.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            arquivoods1.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOdsAlterandoCliente(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.LASA);

            ArquivoUtils.IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "11");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000001");


            EnviarParaOdsAlterandoCliente(arquivoods2);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            ArquivoUtils.IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE" });
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }
    }
}
