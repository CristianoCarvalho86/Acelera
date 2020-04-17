using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1184_Layout94_Softbox : TestesFG02
    {
        /// <summary>
        /// Informar VL_ADIC_FRACIONADO superior ao valor máximo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3949_CD_OCORRENCIA_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3949", "FG02 - PROC1184 - Informar VL_ADIC_FRACIONADO superior ao valor máximo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-2751-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura();
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "VL_ADIC_FRACIONADO", SomarValores(cobertura.ValorAdicionalMaior, "1"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1184");
            ValidarTeste();
        }

        /// <summary>
        /// Informar VL_ADIC_FRACIONADO inferior ao valor mínimo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3950_CD_OCORRENCIA_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3950", "FG02 - PROC1184 - Informar VL_ADIC_FRACIONADO inferior ao valor mínimo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3162-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura();
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "VL_ADIC_FRACIONADO", SomarValores(cobertura.ValorAdicionalMenor, "-1"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1184");
            ValidarTeste();
        }

        /// <summary>
        /// Informar VL_ADIC_FRACIONADO compreendido entre o valor mínimo e máximo do desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3951_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3951", "FG02 - PROC1184 - Informar VL_ADIC_FRACIONADO compreendido entre o valor mínimo e máximo do desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3179-20200317.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura();
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "VL_ADIC_FRACIONADO", SomarValores(cobertura.ValorAdicionalMaior, "-1"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }


        /// <summary>
        /// Informar VL_ADIC_FRACIONADO igual ao valor mínimo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "???", "FG02 - PROC1184 - Informar VL_ADIC_FRACIONADO igual ao valor mínimo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012 ");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3196-20200318.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura();
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "VL_ADIC_FRACIONADO", cobertura.ValorAdicionalMenor);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Informar VL_ADIC_FRACIONADO igual ao valor máximo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "???", "FG02 - PROC1184 - Informar VL_ADIC_FRACIONADO igual ao valor máximo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012 ");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3212-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura();
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "VL_ADIC_FRACIONADO", cobertura.ValorAdicionalMaior);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
