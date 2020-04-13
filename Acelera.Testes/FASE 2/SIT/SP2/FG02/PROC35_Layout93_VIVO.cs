using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC35_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        ///  Informar campo negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2802_PARC_EMISSAO_AUTO_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2802", "FG02 - PROC35 - Informar campo negativo");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "NR_APOLICE", "-12345");
            AlterarLinha(2, "NR_PARCELA", "-2");
            AlterarLinha(2, "CD_CLIENTE", "-200");
            AlterarLinha(2, "VL_JUROS", "-20");
            AlterarLinha(2, "VL_DESCONTO", "-20");
            AlterarLinha(2, "VL_PREMIO_LIQUIDO", "-20");
            AlterarLinha(2, "VL_IOF", "-20");
            AlterarLinha(2, "VL_ADIC_FRACIONADO", "-20");
            AlterarLinha(2, "VL_CUSTO_APOLICE", "-20");
            AlterarLinha(2, "VL_PREMIO_TOTAL", "-20");
            AlterarLinha(2, "VL_TAXA_MOEDA", "-20");
            AlterarLinha(2, "VL_LMI", "-20");
            AlterarLinha(2, "VL_IS", "-20");
            AlterarLinha(2, "VL_PERCENTUAL_COSSEGURO", "-20");
            AlterarLinha(2, "VL_PREMIO_CEDIDO", "-20");
            AlterarLinha(2, "VL_COMISSAO_CEDIDO", "-20");
            AlterarLinha(2, "VL_FRANQUIA", "-20");
            AlterarLinha(2, "CD_PRODUTO", "-20");
            AlterarLinha(2, "ID_TRANSACAO", "-20");
            AlterarLinha(2, "ID_TRANSACAO_CANC", "-20");
            AlterarLinha(2, "CD_PLANO", "-20");
            AlterarLinha(2, "CD_UF_RISCO", "-2");
            AlterarLinha(2, "CD_MODALIDADE", "-20");
            AlterarLinha(2, "CD_MODELO", "-20");
            AlterarLinha(2, "ANO_MODELO", "-20");
            AlterarLinha(2, "VL_PERC_FATOR", "-20");
            AlterarLinha(2, "VL_PERC_BONUS", "-20");
            AlterarLinha(2, "CD_CLASSE_BONUS", "-20");
            AlterarLinha(2, "DT_NASC_CONDUTOR", "-2009101");
            AlterarLinha(2, "TEMPO_HAB", "-1");
            AlterarLinha(2, "CD_UTILIZACAO", "-1");
            AlterarLinha(2, "CEP_UTILIZACAO", "-2052015");
            AlterarLinha(2, "CEP_PERNOITE", "-2052015");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(33,"35");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo CD_CLIENTE negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2803_CLIENTE_CDCLIENTE_NEGATIVO()
        {
            IniciarTeste(TipoArquivo.Cliente, "2803", "FG02 - PROC35 - Informar campo CD_CLIENTE negativo");
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_CLIENTE", "-200");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.CLIENTE-EV-/*R*/-20200207.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1,"35");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo NR_SEQUENCIAL_EMISSAO, NR_PARCELA negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2804_COMISSAO_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.Comissao, "2803", "FG02 - PROC35 - Informar campo NR_SEQUENCIAL_EMISSAO, NR_PARCELA negativo");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "NR_SEQUENCIAL_EMISSAO", "-200");
            AlterarLinha(2, "NR_PARCELA", "-2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.EMSCMS-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(2,"35");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo CD_OCORRENCIA, NR_PARCELA, VL_DESCONTO negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2805_COBRANCA_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.Comissao, "2805", "FG02 - PROC35 - Informar campo NR_PARCELA, CD_OCORRENCIA, VL_DESCONTO negativo");
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_OCORRENCIA", "-20");
            AlterarLinha(2, "NR_PARCELA", "-2");
            AlterarLinha(2, "VL_DESCONTO", "-200.10");
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.EMSCMS-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(3, "35");
            ValidarTeste();
        }

    }
}
