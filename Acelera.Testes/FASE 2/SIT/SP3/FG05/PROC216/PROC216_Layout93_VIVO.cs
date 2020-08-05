using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC216
{
    [TestClass]
    public class PROC216_Layout93_VIVO : TestesFG05
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
        public void SAP_4567()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4567", "FG05 - PROC216");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1 , OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "50");
            AlterarLinha(0, "VL_IOF", "50");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "C", true));

            EnviarParaOdsAlterandoCliente(arquivo, true);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_CORRETOR" };
            IgualarCampos(arquivoods, arquivo, campos);
            AlterarLinha(0, "VL_COMISSAO", "110");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");

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
        public void SAP_4568()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4568", "FG05 - PROC216");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "50");
            AlterarLinha(0, "VL_IOF", "50");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "C", true));

            EnviarParaOdsAlterandoCliente(arquivo, true);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 2, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_CORRETOR" };
            IgualarCampos(arquivoods, arquivo, campos, true);
            AlterarLinha(0, "VL_COMISSAO", "60");
            AlterarLinha(1, "VL_COMISSAO", "60");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));

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
        public void SAP_4569()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4569", "FG05 - PROC216");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "50");
            AlterarLinha(0, "VL_IOF", "50");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "C", true));

            EnviarParaOdsAlterandoCliente(arquivo, true);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 3, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_CORRETOR" };
            IgualarCampos(arquivoods, arquivo, campos, true);
            AlterarLinha(0, "VL_COMISSAO", "60");
            AlterarLinha(1, "VL_COMISSAO", "60");
            AlterarLinha(2, "VL_COMISSAO", "60");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");
            AlterarLinha(1, "CD_TIPO_COMISSAO", "C");
            AlterarLinha(2, "CD_TIPO_COMISSAO", "C");
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));
            AlterarLinha(2, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 2));

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "216", 1);
        }

        /// <summary>
        /// Em 1 arquivo PARC, informar valor total do prêmio total da cobertura. Este arquivo deve estar na ODS. 
        /// Em outro arquivo COMISSAO, após o PARC estar na STAGE, informar apenas uma linha com este contrato e cobertura, sendo o VL_COMISSAO inferior ao VL_PREMIO_TOTAL do arquivo PARC
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4573()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4573", "FG05 - PROC216");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "9");
            AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "50");
            AlterarLinha(0, "VL_IOF", "50");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "C", true));

            EnviarParaOdsAlterandoCliente(arquivo, true);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_CORRETOR" };
            IgualarCampos(arquivoods, arquivo, campos);
            AlterarLinha(0, "VL_COMISSAO", "40");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");

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
        public void SAP_4574()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4574", "FG05 - PROC216");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "9");
            AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "50");
            AlterarLinha(0, "VL_IOF", "50");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "C", true));

            EnviarParaOdsAlterandoCliente(arquivo, true);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 2, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_CORRETOR" };
            IgualarCampos(arquivoods, arquivo, campos, true);
            AlterarLinha(0, "VL_COMISSAO", "20");
            AlterarLinha(1, "VL_COMISSAO", "20");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");
            AlterarLinha(1, "CD_TIPO_COMISSAO", "C");
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNegocioComDependencia, "216");
        }

    }
}
