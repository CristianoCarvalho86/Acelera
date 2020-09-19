using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC216
{
    [TestClass]
    public class PROC216_Layout94_POMPEIA : TestesFG05
    {

        /// <summary>
        /// Em 1 arquivo PARC, informar valor
        /// total do prêmio total da cobertura. Este arquivo deve estar na ODS. 
        /// Em outro arquivo COMISSAO, após o PARC estar na STAGE, 
        /// informar apenas uma linha com este contrato e cobertura, 
        /// sendo o VL_COMISSAO superior ao VL_PREMIO_TOTAL do arquivo PARC
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4597()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4597", "FG05 - PROC216");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1 , OperadoraEnum.POMPEIA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), "111125"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "50");
            AlterarLinha(0, "VL_IOF", "50");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_CORRETOR" };
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos);
            AlterarLinha(0, "VL_COMISSAO", "110");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "216", 1);
        }

        /// <summary>
        /// Em 1 arquivo PARC, informar valor total do prêmio total da cobertura. Este arquivo deve estar na ODS. 
        /// Em outro arquivo COMISSAO, após o PARC estar na STAGE, informar duas linha com este contrato e cobertura (Comissao e Pro Labore)
        /// sendo o VL_COMISSAO somado superior ao VL_PREMIO_TOTAL do arquivo PARC
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4598()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4598", "FG05 - PROC216");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), "111124"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "50");
            AlterarLinha(0, "VL_IOF", "50");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));

            EnviarParaOdsAlterandoCliente(arquivo,true);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 2, OperadoraEnum.POMPEIA);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_CORRETOR"};
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos, true);
            AlterarLinha(0, "VL_COMISSAO", "60");
            AlterarLinha(1, "VL_COMISSAO", "60");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(1, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));

            //Salvar e executar
            SalvarArquivo(true);
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "216", 1);
        }

        /// <summary>
        /// Em 1 arquivo PARC, informar valor total do prêmio total da cobertura. Este arquivo deve estar na ODS. 
        /// Em outro arquivo COMISSAO, após o PARC estar na STAGE, informar duas linha com este contrato e cobertura (Comissao e Pro Labore)
        /// sendo o VL_COMISSAO somado superior ao VL_PREMIO_TOTAL do arquivo PARC
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4599()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4599", "FG05 - PROC216");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), "111126"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "50");
            AlterarLinha(0, "VL_IOF", "50");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));

            EnviarParaOdsAlterandoCliente(arquivo, true);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 3, OperadoraEnum.POMPEIA);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_CORRETOR" };
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos, true);
            AlterarLinha(0, "VL_COMISSAO", "60");
            AlterarLinha(1, "VL_COMISSAO", "60");
            AlterarLinha(2, "VL_COMISSAO", "60");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(1, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(2, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));
            AlterarLinha(2, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 2));

            //Salvar e executar
            SalvarArquivo(true);
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "216", 1);
        }

        /// <summary>
        /// Em 1 arquivo PARC, informar valor total do prêmio total da cobertura. Este arquivo deve estar na ODS. 
        /// Em outro arquivo COMISSAO, após o PARC estar na STAGE, informar apenas uma linha com este contrato e cobertura, sendo o VL_COMISSAO inferior ao VL_PREMIO_TOTAL do arquivo PARC
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4603()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4603", "FG05 - PROC216");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "50");
            AlterarLinha(0, "VL_IOF", "50");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));

            SalvarArquivo();
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_CORRETOR" };
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos, true);
            AlterarLinha(0, "VL_COMISSAO", "60");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "216");
        }

        /// <summary>
        /// Em 1 arquivo PARC, informar valor total do prêmio total da cobertura. Este arquivo deve estar na ODS. 
        /// Em outro arquivo COMISSAO, após o PARC estar na STAGE, informar apenas uma linha com este contrato e cobertura, sendo o VL_COMISSAO inferior ao VL_PREMIO_TOTAL do arquivo PARC
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4604()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4604", "FG05 - PROC216");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            AlterarLinha(0, "CD_CONTRATO", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));

            AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "50");
            AlterarLinha(0, "VL_IOF", "50");
            AlterarLinha(0, "CD_CORRETOR", "7150166");

            EnviarParaOdsAlterandoCliente(arquivo, true);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 2, OperadoraEnum.POMPEIA);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_CORRETOR" };
            ArquivoUtils.IgualarCampos(arquivoods, arquivo, campos, true);
            AlterarLinha(0, "VL_COMISSAO", "20");
            AlterarLinha(1, "VL_COMISSAO", "20");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(1, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "216");
        }

    }
}
