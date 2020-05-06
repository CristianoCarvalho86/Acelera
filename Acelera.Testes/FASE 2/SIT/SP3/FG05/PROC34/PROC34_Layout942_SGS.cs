using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC34
{
    [TestClass]
    public class PROC34_Layout94_SGS : TestesFG05
    {
        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem nenhum campo cadastral preenchido (cnpj, endereço, cidade, uf ou cep).
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4352()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4352", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_2();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SGS);

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
        public void SAP_4353()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4353", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_2();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SGS);

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
        public void SAP_4354()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4354", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_2();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SGS);

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
        public void SAP_4355()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4355", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_2();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SGS);

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
        public void SAP_4356()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4356", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_2();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SGS);

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
        public void SAP_4357()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4357", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_2();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SGS);

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
        public void SAP_4358()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4358", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_4_2();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SGS);

            AlterarLinha(0, "CD_SEGURADORA", dados.ObterCDSeguradoraDoTipoParceiro("SE"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

    }
}
