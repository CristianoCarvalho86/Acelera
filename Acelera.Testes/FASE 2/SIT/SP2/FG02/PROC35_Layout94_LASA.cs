using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC35_Layout94_LASA : TestesFG02
    {

        /// <summary>
        ///  Informar campo negativo VL_CUSTO_APOLICE VL_PREMIO_TOTAL VL_TAXA_MOEDA VL_LMI VL_IS VL_PERCENTUAL_COSSEGURO VL_PREMIO_CEDIDO VL_COMISSAO_CEDIDO VL_FRANQUIA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2820_PARC_EMISSAO_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2820", "FG02 - PROC35 - Informar campo negativo");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3256-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "VL_CUSTO_APOLICE", "-1.00");
            AlterarLinha(2, "VL_PREMIO_TOTAL", "-100.00");
            AlterarLinha(2, "VL_TAXA_MOEDA", "-100.10");
            AlterarLinha(2, "VL_LMI", "-100.10");
            AlterarLinha(2, "VL_IS", "-100.10");
            AlterarLinha(2, "VL_PERCENTUAL_COSSEGURO", "-10.1");
            AlterarLinha(2, "VL_PREMIO_CEDIDO", "-100.10");
            AlterarLinha(2, "VL_COMISSAO_CEDIDO", "-100.10");
            AlterarLinha(2, "VL_FRANQUIA", "-100.10");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200322.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(9,"35");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo NR_SEQUENCIAL_EMISSAO, NR_PARCELA negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2822_COMISSAO_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.Comissao, "2822", "FG02 - PROC35 - Informar campo VL_BASE_CALCULO, PC_COMISSAO negativo");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.EMSCMS-EV-3160-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "VL_BASE_CALCULO", "-200");
            AlterarLinha(1, "PC_COMISSAO", "-25");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC35");

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
        ///  Informar campo VL_PREMIO_PAGO VL_MULTA VL_IOF_RETIDO negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2823_COBRANCA_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2823", "FG02 - PROC35 - Informar campo VL_ADC_FRC, VL_ADC_FRC_DVI, VL_MULTA_DEVIDO negativo");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.COBRANCA-EV-2786-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_ADC_FRC", "-208.54");
            AlterarLinha(0, "VL_ADC_FRC_DVI", "-105");
            AlterarLinha(0, "VL_MULTA_DEVIDO", "-200.10");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.COBRANCA-EV-/*R*/-20200214.txt");

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
        public void SAP_2824_SINISTRO_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2824", "FG02 - PROC35 - Informar campo CD_MOVIMENTO VL_MOVIMENTO VL_TAXA_PAGTO EN_CEP_BENEFICIARIO CD_BANCO_SEG NR_AGENCIA_SEG negativo");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3301-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_MOVIMENTO", "-105");
            AlterarLinha(0, "VL_TAXA_PAGTO", "-10");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.txt");

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
        ///  Informar campo  NR_PARCELA CD_EXTRATO_COMISSAO CD_LANCAMENTO VL_COMISSAO_PAGO CD_TIPO_LANCAMENTO negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2825_LANCTO_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "2825", "FG02 - PROC35 - Informar campo  NR_PARCELA CD_EXTRATO_COMISSAO CD_LANCAMENTO VL_COMISSAO_PAGO CD_TIPO_LANCAMENTO negativo");
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9624-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_COMISSAO_PAGO", "-100");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC35");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(5, "35");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo positivo VL_CUSTO_APOLICE VL_PREMIO_TOTAL VL_TAXA_MOEDA VL_LMI VL_IS VL_PERCENTUAL_COSSEGURO VL_PREMIO_CEDIDO VL_COMISSAO_CEDIDO VL_FRANQUIA
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2826_PARC_EMISSAO_NUMEROS_POSITIVOS()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2826", "FG02 - PROC35 - Informar campo negativo");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3256-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "VL_CUSTO_APOLICE", "1.00");
            AlterarLinha(2, "VL_PREMIO_TOTAL", "100.00");
            AlterarLinha(2, "VL_TAXA_MOEDA", "100.10");
            AlterarLinha(2, "VL_LMI", "100.10");
            AlterarLinha(2, "VL_IS", "100.10");
            AlterarLinha(2, "VL_PERCENTUAL_COSSEGURO", "10.1");
            AlterarLinha(2, "VL_PREMIO_CEDIDO", "100.10");
            AlterarLinha(2, "VL_COMISSAO_CEDIDO", "100.10");
            AlterarLinha(2, "VL_FRANQUIA", "100.10");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200322.txt");

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
        ///  Informar campo NR_SEQUENCIAL_EMISSAO, NR_PARCELA positivo
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2828_COMISSAO_NUMEROS_POSITIVOS()
        {
            IniciarTeste(TipoArquivo.Comissao, "2828", "FG02 - PROC35 - Informar campo VL_BASE_CALCULO, PC_COMISSAO positivo");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.EMSCMS-EV-3160-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "VL_BASE_CALCULO", "200");
            AlterarLinha(1, "PC_COMISSAO", "25");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.EMSCMS-EV-/*R*/-20200316.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTabelaDeRetorno(true,"35");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo VL_PREMIO_PAGO VL_MULTA VL_IOF_RETIDO POSITIVOS
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2829_COBRANCA_NUMEROS_POSITIVOS()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2823", "FG02 - PROC35 - Informar campo VL_ADC_FRC, VL_ADC_FRC_DVI, VL_MULTA_DEVIDO POSITIVOS");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.COBRANCA-EV-2786-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_ADC_FRC", "208.54");
            AlterarLinha(0, "VL_ADC_FRC_DVI", "105");
            AlterarLinha(0, "VL_MULTA_DEVIDO", "200.10");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.COBRANCA-EV-/*R*/-20200214.txt");

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
        ///  Informar campo CD_MOVIMENTO VL_MOVIMENTO VL_TAXA_PAGTO EN_CEP_BENEFICIARIO CD_BANCO_SEG NR_AGENCIA_SEG negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2830_SINISTRO_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2830", "FG02 - PROC35 - Informar campo CD_MOVIMENTO VL_MOVIMENTO VL_TAXA_PAGTO EN_CEP_BENEFICIARIO CD_BANCO_SEG NR_AGENCIA_SEG POSITIVOS");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3301-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_MOVIMENTO", "105");
            AlterarLinha(0, "VL_TAXA_PAGTO", "10");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.txt");

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

        /// <summary>
        ///  Informar campo  NR_PARCELA CD_EXTRATO_COMISSAO CD_LANCAMENTO VL_COMISSAO_PAGO CD_TIPO_LANCAMENTO negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2831_LANCTO_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "2831", "FG02 - PROC35 - Informar campo  NR_PARCELA CD_EXTRATO_COMISSAO CD_LANCAMENTO VL_COMISSAO_PAGO CD_TIPO_LANCAMENTO POSITIVO");
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9624-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_COMISSAO_PAGO", "100");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.LCTCMS-EV-/*R*/-20190311.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }

    }
}
