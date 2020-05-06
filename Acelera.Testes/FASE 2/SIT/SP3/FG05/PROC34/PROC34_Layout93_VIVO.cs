using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC34
{
    [TestClass]
    public class PROC34_Layout93_VIVO : TestesFG05
    {

        /// <summary>
        /// Informar CD_SEGURADORA com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "SE". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem nenhum campo cadastral preenchido (cnpj, endereço, cidade, uf ou cep).
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4275()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4275", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

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
        public void SAP_4276()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4276", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

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
        public void SAP_4277()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4277", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

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
        public void SAP_4278()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4278", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

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
        public void SAP_4279()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4279", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

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
        public void SAP_4280()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4280", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

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
        public void SAP_4281()
        {
            IniciarTeste(TipoArquivo.Comissao, "4281", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

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
        public void SAP_4282()
        {
            IniciarTeste(TipoArquivo.Comissao, "4282", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

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
        public void SAP_4283()
        {
            IniciarTeste(TipoArquivo.Comissao, "4283", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

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
        public void SAP_4284()
        {
            IniciarTeste(TipoArquivo.Comissao, "4284", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

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
        public void SAP_4285()
        {
            IniciarTeste(TipoArquivo.Comissao, "4285", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

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
        public void SAP_4286()
        {
            IniciarTeste(TipoArquivo.Comissao, "4286", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

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
        public void SAP_4287()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4287", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

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
        public void SAP_4288()
        {
            IniciarTeste(TipoArquivo.Comissao, "4288", "FG05 - PROC34");

            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_SEGURADORA", dados.ObterCDSeguradoraDoTipoParceiro("SE"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

    }
}
