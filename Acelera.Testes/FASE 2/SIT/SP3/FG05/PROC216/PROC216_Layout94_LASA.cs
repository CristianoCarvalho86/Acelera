using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC216
{
    [TestClass]
    public class PROC216_Layout94_LASA : TestesFG05
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
        public void SAP_4577()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4577", "FG05 - PROC216");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo ,1 , OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "50");
            AlterarLinha(0, "VL_IOF", "50");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "R", true));
            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");

            EnviarParaOds(arquivo, true);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_CORRETOR" };
            IgualarCampos(arquivoods, arquivo, campos);
            AlterarLinha(0, "VL_COMISSAO", "110");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");

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
        public void SAP_4578()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4577", "FG05 - PROC216");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(ObterValorFormatado(0, "CD_CONTRATO"), "111131"));
            AlterarLinha(0, "NR_APOLICE", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "NR_PROPOSTA", ObterValorFormatado(0, "CD_CONTRATO"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "50");
            AlterarLinha(0, "VL_IOF", "50");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));


            EnviarParaOds(arquivo, true);
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 2, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_CORRETOR" };
            IgualarCampos(arquivoods, arquivo, campos, true);
            AlterarLinha(0, "VL_COMISSAO", "60");
            AlterarLinha(1, "VL_COMISSAO", "60");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(1, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "216", 2);
        }

        /// <summary>
        /// Em 1 arquivo PARC, informar valor total do prêmio total da cobertura. Este arquivo deve estar na ODS. 
        /// Em outro arquivo COMISSAO, após o PARC estar na STAGE, informar duas linha com este contrato e cobertura (Comissao e Pro Labore)
        /// sendo o VL_COMISSAO somado superior ao VL_PREMIO_TOTAL do arquivo PARC
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4579()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4579", "FG05 - PROC216");

            //Carregar arquivo ods
            var arquivoods = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.LASA);

            arquivoods.AlterarLinha(0, "VL_PREMIO_TOTAL", "100");

            EnviarParaOds(arquivoods);

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 3, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", };
            IgualarCampos(arquivoods, arquivo, campos, true);
            AlterarLinha(0, "VL_COMISSAO", "60");
            AlterarLinha(1, "VL_COMISSAO", "60");
            AlterarLinha(3, "VL_COMISSAO", "60");

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
        public void SAP_4583()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4583", "FG05 - PROC216");

            //Carregar arquivo ods
            var arquivoods = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.LASA);

            arquivoods.AlterarLinha(0, "VL_PREMIO_TOTAL", "100");

            EnviarParaOds(arquivoods);

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", };
            IgualarCampos(arquivoods, arquivo, campos, true);
            AlterarLinha(0, "VL_COMISSAO", "60");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        /// <summary>
        /// Em 1 arquivo PARC, informar valor total do prêmio total da cobertura. Este arquivo deve estar na ODS. 
        /// Em outro arquivo COMISSAO, após o PARC estar na STAGE, informar apenas uma linha com este contrato e cobertura, sendo o VL_COMISSAO inferior ao VL_PREMIO_TOTAL do arquivo PARC
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4584()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4584", "FG05 - PROC216");

            //Carregar arquivo ods
            var arquivoods = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.LASA);

            arquivoods.AlterarLinha(0, "VL_PREMIO_TOTAL", "100");

            EnviarParaOds(arquivoods);

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 2, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", };
            IgualarCampos(arquivoods, arquivo, campos, true);
            AlterarLinha(0, "VL_COMISSAO", "30");
            AlterarLinha(0, "VL_COMISSAO", "40");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

    }
}
