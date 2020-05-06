using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC34
{
    [TestClass]
    public class PROC34_Layout94_SOFTBOX : TestesFG05
    {

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem nenhum campo cadastral preenchido (cnpj, endereço, cidade, uf ou cep).
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4310()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4310", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem CNPJ preenchido. Os demais campos devem estar preenchidos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4311()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4311", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem Endereço preenchido. Os demais campos devem estar preenchidos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4312()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4312", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem Cidade preenchido. Os demais campos devem estar preenchidos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4313()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4313", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem UF preenchido. Os demais campos devem estar preenchidos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4314()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4314", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem CEP preenchido. Os demais campos devem estar preenchidos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4315()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4315", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem nenhum campo cadastral preenchido (cnpj, endereço, cidade, uf ou cep).
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4316()
        {
            IniciarTeste(TipoArquivo.Comissao, "4316", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem CNPJ preenchido. Os demais campos devem estar preenchidos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4317()
        {
            IniciarTeste(TipoArquivo.Comissao, "4317", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem Endereço preenchido. Os demais campos devem estar preenchidos]
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4318()
        {
            IniciarTeste(TipoArquivo.Comissao, "4318", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem Cidade preenchido. Os demais campos devem estar preenchidos]
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4319()
        {
            IniciarTeste(TipoArquivo.Comissao, "4319", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem UF preenchido. Os demais campos devem estar preenchidos]
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4320()
        {
            IniciarTeste(TipoArquivo.Comissao, "4320", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem CEP preenchido. Os demais campos devem estar preenchidos]
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4321()
        {
            IniciarTeste(TipoArquivo.Comissao, "4321", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem nenhum campo cadastral preenchido (cnpj, endereço, cidade, uf ou cep).
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4322()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4322", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem CNPJ preenchido. Os demais campos devem estar preenchidos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4323()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4323", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem Endereço preenchido. Os demais campos devem estar preenchidos]
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4324()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4324", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem Cidade preenchido. Os demais campos devem estar preenchidos]
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4325()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4325", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem UF preenchido. Os demais campos devem estar preenchidos]
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4326()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4326", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem CEP preenchido. Os demais campos devem estar preenchidos]
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4327()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4327", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "34", 1);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 com todos os campos cadastrais preenchido (cnpj, endereço, cidade, uf ou cep).
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4328()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4328", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", dados.ObterCDSeguradoraDoTipoParceiro("SE"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 com todos os campos cadastrais preenchido (cnpj, endereço, cidade, uf ou cep).
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4329()
        {
            IniciarTeste(TipoArquivo.Comissao, "4329", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", dados.ObterCDSeguradoraDoTipoParceiro("SE"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 com todos os campos cadastrais preenchido (cnpj, endereço, cidade, uf ou cep).
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4330()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4330", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_SEGURADORA", dados.ObterCDSeguradoraDoTipoParceiro("SE"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

    }
}
