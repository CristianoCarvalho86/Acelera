using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC22
{
    [TestClass]
    public class PROC22_Layout94_LASA : TestesFG05
    {
        /// <summary>
        /// Gerar um arquivo anteriormente que popule a tabela ODS que não possua nenhum item a ser criticado. 
        /// Em outro arquivo, enviar as mesmas informações do arquivo anterior nos campos da tabela TAB_PRM_LAYOUT_7016 para o NM_TIPO_ARQUIVO= SINISTRO, CD_VERSAO_ARQUIVO=9.4, TP_REGISTRO=3 e ID_PRIMARY_KEY=1.
        /// Todos os campos exibidos nessa consulta na coluna NM_ATRIBUTO_LAYOUT devem ser iguais aos do primeiro arquivo.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4191()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4191", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            var canc = SomarValor(0, "ID_TRANSACAO", 1);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissao, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos2);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "22", 1);
        }

        /// <summary>
        /// Gerar um arquivo anteriormente que popule a tabela ODS que não possua nenhum item a ser criticado. 
        /// Em outro arquivo, enviar as mesmas informações do arquivo anterior nos campos da tabela TAB_PRM_LAYOUT_7016 para o NM_TIPO_ARQUIVO= SINISTRO, CD_VERSAO_ARQUIVO=9.4, TP_REGISTRO=3 e ID_PRIMARY_KEY=1.
        /// Todos os campos exibidos nessa consulta na coluna NM_ATRIBUTO_LAYOUT devem ser iguais aos do primeiro arquivo.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4192()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Cliente, "4192", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Cliente, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "22", 1);
        }

        /// <summary>
        /// Gerar um arquivo anteriormente que popule a tabela ODS que não possua nenhum item a ser criticado. 
        /// Em outro arquivo, enviar as mesmas informações do arquivo anterior nos campos da tabela TAB_PRM_LAYOUT_7016 para o NM_TIPO_ARQUIVO= SINISTRO, CD_VERSAO_ARQUIVO=9.4, TP_REGISTRO=3 e ID_PRIMARY_KEY=1.
        /// Todos os campos exibidos nessa consulta na coluna NM_ATRIBUTO_LAYOUT devem ser iguais aos do primeiro arquivo.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4193()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4193", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "22", 1);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4200()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4200", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissao, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos2);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));
            AlterarLinha(0, "CD_CORRETOR", "7139687");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "22");
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4199()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4199", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissao, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos2);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));
            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "22");
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4198()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4198", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissao, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos2);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));
            AlterarLinha(0, "CD_COBERTURA", "01592");

            AlterarCobertura(false);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "22");
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4209()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4209", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            
            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));
            var seq = SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1);

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissao, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos2);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seq);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "22");
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4208()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4208", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            
            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));
            var parc = SomarValor(0, "NR_PARCELA", 1);

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissao, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos2);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));
            AlterarLinha(0, "NR_PARCELA", parc);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "22");
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4203()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4203", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissao, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos2);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "22");
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4202()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4202", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissao, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos2);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));
            AlterarLinha(0, "CD_ITEM", "1234");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "22");
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4220()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4220", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            var seq = SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1);

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seq);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4214()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4214", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));


            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            AlterarLinha(0, "CD_INTERNO_RESSEGURADOR", "-2");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4219()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4219", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            var parc = SomarValor(0, "NR_PARCELA", 1);

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            AlterarLinha(0, "NR_PARCELA", parc);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4213()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4213", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "C", true));
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4211()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4211", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            AlterarLinha(0, "CD_COBERTURA", "01592");
            AlterarLinha(0, "CD_RAMO", "71");


            AlterarCobertura(false);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4215()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4215", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            AlterarLinha(0, "CD_ITEM", "1234");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4212()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4212", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4210()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Cliente, "4210", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Cliente, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            AlterarLinha(0, "CD_CLIENTE", "98765");

            //Salvar e executar
            SalvarArquivo(false);
            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "22");
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4197()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4197", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissao, "9.4");
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos2);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));
            AlterarLinha(0, "CD_CLIENTE", "123456");

            //Salvar e executar
            SalvarArquivo(false);
            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "22");
        }

    }
}
