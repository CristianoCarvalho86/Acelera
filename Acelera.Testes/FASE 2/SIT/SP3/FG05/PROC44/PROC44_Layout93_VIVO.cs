using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC44
{
    [TestClass]
    public class PROC44_Layout93_VIVO : TestesFG05
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
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            var seqEMS = SomarValores(arquivo.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"),"1");
            var seqEMS1 = SomarValores(arquivo.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "2");
            var dtEmissao = ObterLinha(0).ObterCampoDoArquivo("DT_EMISSAO").ValorFormatado;

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods1 = arquivo.Clone();

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1 , OperadoraEnum.VIVO);

            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");
            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO",seqEMS);
            AlterarLinha(0, "NR_ENDOSSO", "12340000002");
            AlterarLinha(0, "DT_EMISSAO", SomarData(dtEmissao, 5));

            EnviarParaOdsAlterandoCliente(arquivo);

            //Enviar parc com msmo id cancelamento mas tipo emissao diferente
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS1);
            AlterarLinha(0, "NR_ENDOSSO", "12340000003");
            AlterarLinha(0, "DT_EMISSAO", SomarData(dtEmissao, 7));

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
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            var seqEMS = SomarValores(arquivo.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "1");
            var seqEMS1 = SomarValores(arquivo.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "2");
            var dtEmissao = ObterLinha(0).ObterCampoDoArquivo("DT_EMISSAO").ValorFormatado;

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods1 = arquivo.Clone();

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");
            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS);
            AlterarLinha(0, "NR_ENDOSSO", "12340000002");
            AlterarLinha(0, "DT_EMISSAO", SomarData(dtEmissao, 5));

            EnviarParaOdsAlterandoCliente(arquivo);

            //Enviar parc com msmo id cancelamento mas tipo emissao diferente
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "6");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS1);
            AlterarLinha(0, "NR_ENDOSSO", "12340000003");
            AlterarLinha(0, "DT_EMISSAO", SomarData(dtEmissao, 7));

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
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            var seqEMS = SomarValores(arquivo.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "1");
            var seqEMS1 = SomarValores(arquivo.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "2");
            var dtEmissao = ObterLinha(0).ObterCampoDoArquivo("DT_EMISSAO").ValorFormatado;

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods1 = arquivo.Clone();

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");
            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS);
            AlterarLinha(0, "NR_ENDOSSO", "12340000002");
            AlterarLinha(0, "DT_EMISSAO", SomarData(dtEmissao, 5));

            EnviarParaOdsAlterandoCliente(arquivo);

            //Enviar parc com msmo id cancelamento mas tipo emissao diferente
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "7");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS1);
            AlterarLinha(0, "NR_ENDOSSO", "12340000003");
            AlterarLinha(0, "DT_EMISSAO", SomarData(dtEmissao, 7));

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
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            var seqEMS = SomarValores(arquivo.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "1");
            var seqEMS1 = SomarValores(arquivo.ObterValorFormatadoSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO"), "2");
            var dtEmissao = ObterLinha(0).ObterCampoDoArquivo("DT_EMISSAO").ValorFormatado;

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods1 = arquivo.Clone();

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");
            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS);
            AlterarLinha(0, "NR_ENDOSSO", "12340000002");
            AlterarLinha(0, "DT_EMISSAO", SomarData(dtEmissao, 5));

            EnviarParaOdsAlterandoCliente(arquivo);

            //Enviar parc com msmo id cancelamento mas tipo emissao diferente
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCampos(arquivoods1, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            AlterarLinha(0, "CD_TIPO_EMISSAO", "8");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seqEMS1);
            AlterarLinha(0, "NR_ENDOSSO", "12340000003");
            AlterarLinha(0, "DT_EMISSAO", SomarData(dtEmissao, 7));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "44", 1);
        }

       
    }
}
