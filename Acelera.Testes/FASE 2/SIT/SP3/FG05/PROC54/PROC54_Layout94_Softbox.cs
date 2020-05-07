using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC54
{
    [TestClass]
    public class PROC54_Layout94_SOFTBOX : TestesFG05
    {
        /// <summary>
        /// Informar CD_CORRETOR com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "CO". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem nenhum campo cadastral preenchido (cnpj, endereço, cidade, uf ou cep).
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4400()
        {
            IniciarTeste(TipoArquivo.Comissao, "4400", "FG05 - PROC54");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CORRETOR", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "54", 1);

        }

        /// <summary>
        /// Informar CD_CORRETOR com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "CO". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem CNPJ preenchido. Os demais campos devem estar preenchidos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4401()
        {
            IniciarTeste(TipoArquivo.Comissao, "4401", "FG05 - PROC54");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CORRETOR", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "54", 1);

        }

        /// <summary>
        /// Informar CD_CORRETOR com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "CO". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem Endereço preenchido. Os demais campos devem estar preenchidos]
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4402()
        {
            IniciarTeste(TipoArquivo.Comissao, "4402", "FG05 - PROC54");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CORRETOR", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "54", 1);

        }

        /// <summary>
        /// Informar CD_CORRETOR com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "CO". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem Cidade preenchido. Os demais campos devem estar preenchidos]
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4403()
        {
            IniciarTeste(TipoArquivo.Comissao, "4403", "FG05 - PROC54");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CORRETOR", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "54", 1);

        }

        /// <summary>
        /// Informar CD_CORRETOR com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "CO". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem UF preenchido. Os demais campos devem estar preenchidos]
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4404()
        {
            IniciarTeste(TipoArquivo.Comissao, "4404", "FG05 - PROC54");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CORRETOR", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "54", 1);

        }

        /// <summary>
        /// Informar CD_CORRETOR com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "CO". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem CEP preenchido. Os demais campos devem estar preenchidos]
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4405()
        {
            IniciarTeste(TipoArquivo.Comissao, "4405", "FG05 - PROC54");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CORRETOR", "");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "54", 1);

        }

        /// <summary>
        /// Informar CD_CORRETOR com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "CO". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 com todos os campos cadastrais preenchido (cnpj, endereço, cidade, uf ou cep).
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4406()
        {
            IniciarTeste(TipoArquivo.Comissao, "4406", "FG05 - PROC54");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_CORRETOR", dados.ObterCDSeguradoraDoTipoParceiro("CO"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

    }
}
