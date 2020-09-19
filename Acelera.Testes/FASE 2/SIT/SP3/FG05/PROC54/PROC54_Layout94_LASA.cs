using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC54
{
    [TestClass]
    public class PROC54_Layout94_LASA : TestesFG05
    {
        /// <summary>
        /// Informar CD_CORRETOR com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "CO". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem nenhum campo cadastral preenchido (cnpj, endereço, cidade, uf ou cep).
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4393()
        {
            IniciarTeste(TipoArquivo.Comissao, "4393", "FG05 - PROC54");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "54", 1);

        }

        /// <summary>
        /// Informar CD_CORRETOR com um CD_EXTERNO cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 como "CO". 
        /// Este CD_PARCEIRO_NEGOCIO deve estar parametrizado na TAB_ODS_ENDERECO_2001 sem CNPJ preenchido. Os demais campos devem estar preenchidos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4394()
        {
            IniciarTeste(TipoArquivo.Comissao, "4394", "FG05 - PROC54");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

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
        public void SAP_4395()
        {
            IniciarTeste(TipoArquivo.Comissao, "4395", "FG05 - PROC54");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

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
        public void SAP_4396()
        {
            IniciarTeste(TipoArquivo.Comissao, "4396", "FG05 - PROC54");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

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
        public void SAP_4397()
        {
            IniciarTeste(TipoArquivo.Comissao, "4397", "FG05 - PROC54");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

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
        public void SAP_4398()
        {
            IniciarTeste(TipoArquivo.Comissao, "4398", "FG05 - PROC54");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

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
        public void SAP_4399()
        {
            IniciarTeste(TipoArquivo.Comissao, "4399", "FG05 - PROC54");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            AlterarLinha(0, "CD_CORRETOR", "7239711");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }

    }
}
