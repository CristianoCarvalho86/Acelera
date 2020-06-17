using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC22
{
    [TestClass]
    public class PROC22_Layout93_VIVO : TestesFG05
    {
        /// <summary>
        /// Gerar um arquivo anteriormente que popule a tabela ODS que não possua nenhum item a ser criticado. 
        /// Em outro arquivo, enviar as mesmas informações do arquivo anterior nos campos da tabela TAB_PRM_LAYOUT_7016 para o NM_TIPO_ARQUIVO= SINISTRO, CD_VERSAO_ARQUIVO=9.3, TP_REGISTRO=3 e ID_PRIMARY_KEY=1.
        /// Todos os campos exibidos nessa consulta na coluna NM_ATRIBUTO_LAYOUT devem ser iguais aos do primeiro arquivo.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4161()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4161", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);
            
            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissaoAuto, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "22", 1);
        }

        /// <summary>
        /// Gerar um arquivo anteriormente que popule a tabela ODS que não possua nenhum item a ser criticado. 
        /// Em outro arquivo, enviar as mesmas informações do arquivo anterior nos campos da tabela TAB_PRM_LAYOUT_7016 para o NM_TIPO_ARQUIVO= SINISTRO, CD_VERSAO_ARQUIVO=9.3, TP_REGISTRO=3 e ID_PRIMARY_KEY=1.
        /// Todos os campos exibidos nessa consulta na coluna NM_ATRIBUTO_LAYOUT devem ser iguais aos do primeiro arquivo.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4162()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Cliente, "4162", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            EnviarParaOds(arquivo,false);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Cliente, "9.3");
            IgualarCampos(arquivoods, arquivo, campos);

            //Salvar e executar
            SalvarArquivo(true);
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "22", 1);
        }

        /// <summary>
        /// Gerar um arquivo anteriormente que popule a tabela ODS que não possua nenhum item a ser criticado. 
        /// Em outro arquivo, enviar as mesmas informações do arquivo anterior nos campos da tabela TAB_PRM_LAYOUT_7016 para o NM_TIPO_ARQUIVO= SINISTRO, CD_VERSAO_ARQUIVO=9.3, TP_REGISTRO=3 e ID_PRIMARY_KEY=1.
        /// Todos os campos exibidos nessa consulta na coluna NM_ATRIBUTO_LAYOUT devem ser iguais aos do primeiro arquivo.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4163()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4166", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.3");
            IgualarCampos(arquivoods, arquivo, campos);

            //Salvar e executar
            SalvarArquivo(true, "PROC22_4193");
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "22", 1);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4168()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4168", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissaoAuto, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            IgualarCampos(arquivoods, arquivo, campos2);

            AlterarLinha(0, "CD_INTERNO_RESSEGURADOR", "-2");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4174()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4174", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissaoAuto, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            IgualarCampos(arquivoods, arquivo, campos2);

            AlterarLinha(0, "CD_SUSEP_CONTRATO", "-2");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4173()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4173", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissaoAuto, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            IgualarCampos(arquivoods, arquivo, campos2);

            AlterarLinha(0, "CD_SISTEMA", "COM");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4167()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4167", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissaoAuto, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            IgualarCampos(arquivoods, arquivo, campos2);

            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "C", true));

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4166()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4166", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissaoAuto, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            IgualarCampos(arquivoods, arquivo, campos2);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4165()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4165", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissaoAuto, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            IgualarCampos(arquivoods, arquivo, campos2);

            AlterarLinha(0, "CD_COBERTURA", "01733");

            AlterarCobertura(false);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4176()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4176", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            var seq = SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1);

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissaoAuto, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            IgualarCampos(arquivoods, arquivo, campos2);

            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seq);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4175()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4175", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            var parc = SomarValor(0, "NR_PARCELA", 1);

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            IgualarCampos(arquivoods, arquivo, campos2);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissaoAuto, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(0, "NR_ENDOSSO", "12345");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "NR_PARCELA", parc);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4170()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4170", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "03");

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissaoAuto, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            IgualarCampos(arquivoods, arquivo, campos2);

            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4169()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4169", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissaoAuto, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO" };
            IgualarCampos(arquivoods, arquivo, campos2);

            AlterarLinha(0, "CD_ITEM", "1234");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4187()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4187", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));

            var seq = SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1);

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO"};
            IgualarCampos(arquivoods, arquivo, campos2);

            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", seq);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4186()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4186", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            var parc = SomarValor(0, "NR_PARCELA", 1);

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO" };
            IgualarCampos(arquivoods, arquivo, campos2);

            AlterarLinha(0, "NR_PARCELA", parc);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4181()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4181", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            AlterarLinha(0, "CD_INTERNO_RESSEGURADOR", "-2");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4185()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4185", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "C", true));
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO" };
            IgualarCampos(arquivoods, arquivo, campos2);

            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "C", true));
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4183()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4183", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO"};
            IgualarCampos(arquivoods, arquivo, campos2);

            AlterarLinha(0, "CD_COBERTURA", "01733");

            AlterarCobertura(false);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4182()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4182", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            var campos2 = new string[] { "CD_CONTRATO"};
            IgualarCampos(arquivoods, arquivo, campos2);

            AlterarLinha(0, "CD_ITEM", "1234");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4179()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4179", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4177()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Cliente, "4177", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Cliente, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            AlterarLinha(0, "CD_CLIENTE", "12345");

            //Salvar e executar
            SalvarArquivo(false);
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }
    }
}
