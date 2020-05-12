using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC35_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        ///  Informar campo negativo VL_DESCONTO VL_PREMIO_LIQUIDO VL_IOF VL_ADIC_FRACIONADO VL_CUSTO_APOLICE VL_PREMIO_TOTAL VL_TAXA_MOEDA VL_LMI VL_IS VL_PERCENTUAL_COSSEGURO VL_PREMIO_CEDIDO VL_COMISSAO_CEDIDO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2832_PARC_EMISSAO_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2832", "FG02 - PROC35 - Informar campo negativo");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3162-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_DESCONTO", "-123.00");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "-144.00");
            AlterarLinha(0, "VL_IOF", "-122.00");
            AlterarLinha(0, "VL_ADIC_FRACIONADO", "-1.04");
            AlterarLinha(0, "VL_CUSTO_APOLICE", "-1.22");
            AlterarLinha(0, "VL_PREMIO_TOTAL", "-1.33");
            AlterarLinha(0, "VL_TAXA_MOEDA", "-1.32");
            AlterarLinha(0, "VL_LMI", "-1.22");
            AlterarLinha(0, "VL_IS", "-111.04");
            AlterarLinha(0, "VL_PERCENTUAL_COSSEGURO", "-11.0");
            AlterarLinha(0, "VL_PREMIO_CEDIDO", "-1.00");
            AlterarLinha(0, "VL_COMISSAO_CEDIDO", "-1.00");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200316.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(12,"35");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo CD_CLIENTE negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2833_CLIENTE_CDCLIENTE_NEGATIVO()
        {
            IniciarTeste(TipoArquivo.Cliente, "2833", "FG02 - PROC35 - Informar campo CD_CLIENTE negativo");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.CLIENTE-EV-3324-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_CLIENTE", "-50");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.CLIENTE-EV-/*R*/-20200326.txt");

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
        public void SAP_2834_COMISSAO_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.Comissao, "2834", "FG02 - PROC35 - Informar campo PC_PARTICIPACAO negativo");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.EMSCMS-EV-3163-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "PC_PARTICIPACAO", "-25");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.EMSCMS-EV-/*R*/-20200316.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1,"35");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo VL_JUROS_COBRADO VL_JUROS_DEVIDO VL_DIF_PREMIO negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2835_COBRANCA_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2835", "FG02 - PROC35 - Informar campo VL_JUROS_COBRADO VL_JUROS_DEVIDO VL_DIF_PREMIO negativo");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.COBRANCA-EV-2077-20191218.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_JUROS_COBRADO", "-208.54");
            AlterarLinha(0, "VL_JUROS_DEVIDO", "-105");
            AlterarLinha(0, "VL_DIF_PREMIO", "-200.10");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC35");

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

        /// <summary>
        ///  Informar campo CD_MOVIMENTO VL_MOVIMENTO VL_TAXA_PAGTO EN_CEP_BENEFICIARIO CD_BANCO_SEG NR_AGENCIA_SEG negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2836_SINISTRO_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2836", "FG02 - PROC35 - Informar campo VL_TAXA_PAGTO EN_CEP_BENEFICIARIO CD_BANCO_SEG NR_AGENCIA_SEG NR_CONTA_SEG NR_SEQ_MOV negativo");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3238-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_TAXA_PAGTO", "-15");
            AlterarLinha(0, "EN_CEP_BENEFICIARIO", "-205205");
            AlterarLinha(0, "CD_BANCO_SEG", "-10");
            AlterarLinha(0, "NR_AGENCIA_SEG", "-15");
            AlterarLinha(0, "NR_CONTA_SEG", "-100");
            AlterarLinha(0, "NR_SEQ_MOV", "-10");
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200324.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(6, "35");
            ValidarTeste();
        }


        /// <summary>
        ///  Informar campo POSITIVO VL_DESCONTO VL_PREMIO_LIQUIDO VL_IOF VL_ADIC_FRACIONADO VL_CUSTO_APOLICE VL_PREMIO_TOTAL VL_TAXA_MOEDA VL_LMI VL_IS VL_PERCENTUAL_COSSEGURO VL_PREMIO_CEDIDO VL_COMISSAO_CEDIDO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2837_PARC_EMISSAO_NUMEROS_POSITIVOS()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2837", "FG02 - PROC35 - Informar campo POSITIVO");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3162-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_DESCONTO", "123.00");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "144.00");
            AlterarLinha(0, "VL_IOF", "122.00");
            AlterarLinha(0, "VL_ADIC_FRACIONADO", "1.04");
            AlterarLinha(0, "VL_CUSTO_APOLICE", "1.22");
            AlterarLinha(0, "VL_PREMIO_TOTAL", "1.33");
            AlterarLinha(0, "VL_TAXA_MOEDA", "1.32");
            AlterarLinha(0, "VL_LMI", "1.22");
            AlterarLinha(0, "VL_IS", "111.04");
            AlterarLinha(0, "VL_PERCENTUAL_COSSEGURO", "11.00");
            AlterarLinha(0, "VL_PREMIO_CEDIDO", "1.00");
            AlterarLinha(0, "VL_COMISSAO_CEDIDO", "1.00");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200316.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo CD_CLIENTE POSITIVO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2838_CLIENTE_CDCLIENTE_POSITIVO()
        {
            IniciarTeste(TipoArquivo.Cliente, "2838", "FG02 - PROC35 - Informar campo CD_CLIENTE positivo");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.CLIENTE-EV-3324-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_CLIENTE", "50");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.CLIENTE-EV-/*R*/-20200326.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo NR_SEQUENCIAL_EMISSAO, NR_PARCELA POSITIVO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2839_COMISSAO_NUMEROS_POSITIVOS()
        {
            IniciarTeste(TipoArquivo.Comissao, "2839", "FG02 - PROC35 - Informar campo PC_PARTICIPACAO POSITIVO");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.EMSCMS-EV-3163-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "PC_PARTICIPACAO", "25");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.EMSCMS-EV-/*R*/-20200316.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTabelaDeRetorno(true, "35");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo VL_JUROS_COBRADO VL_JUROS_DEVIDO VL_DIF_PREMIO positivo
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2840_COBRANCA_NUMEROS_POSITIVOS()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2840", "FG02 - PROC35 - Informar campo VL_JUROS_COBRADO VL_JUROS_DEVIDO VL_DIF_PREMIO negativo");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.COBRANCA-EV-2077-20191218.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_JUROS_COBRADO", "208.54");
            AlterarLinha(0, "VL_JUROS_DEVIDO", "105");
            AlterarLinha(0, "VL_DIF_PREMIO", "200.10");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.COBRANCA-EV-/*R*/-20191218.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo CD_MOVIMENTO VL_MOVIMENTO VL_TAXA_PAGTO EN_CEP_BENEFICIARIO CD_BANCO_SEG NR_AGENCIA_SEG positivo
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2841_SINISTRO_NUMEROS_POSITIVOS()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2841", "FG02 - PROC35 - Informar campo VL_TAXA_PAGTO EN_CEP_BENEFICIARIO CD_BANCO_SEG NR_AGENCIA_SEG NR_CONTA_SEG NR_SEQ_MOV positivo");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3238-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_TAXA_PAGTO", "15");
            AlterarLinha(0, "EN_CEP_BENEFICIARIO", "205205");
            AlterarLinha(0, "CD_BANCO_SEG", "10");
            AlterarLinha(0, "NR_AGENCIA_SEG", "15");
            AlterarLinha(0, "NR_CONTA_SEG", "100");
            AlterarLinha(0, "NR_SEQ_MOV", "10");
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200324.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }

    }
}
