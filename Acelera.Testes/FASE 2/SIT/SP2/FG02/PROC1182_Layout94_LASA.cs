using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1182_Layout94_LASA : TestesFG02
    {
        /// <summary>
        /// Informar VL_DESCONTO superior ao valor máximo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3934_CD_OCORRENCIA_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3934", "FG02 - PROC1182 - Informar VL_DESCONTO superior ao valor máximo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3224-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura();
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "VL_DESCONTO", SomarValores(cobertura.ValorDescontoMaior, "1"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1182");
            ValidarTeste();
        }

        /// <summary>
        /// Informar VL_DESCONTO inferior ao valor mínimo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3935_CD_OCORRENCIA_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3935", "FG02 - PROC1182 - Informar VL_DESCONTO inferior ao valor mínimo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3208-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura();
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "VL_DESCONTO", SomarValores(cobertura.ValorDescontoMenor, "-1"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1182");
            ValidarTeste();
        }

        /// <summary>
        /// Informar VL_DESCONTO compreendido entre o valor mínimo e máximo do desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3936_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3936", "FG02 - PROC1182 - Informar VL_DESCONTO compreendido entre o valor mínimo e máximo do desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3158-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura();
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "VL_DESCONTO", SomarValores(cobertura.ValorDescontoMaior, "-1"));

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
        /// Informar VL_DESCONTO igual ao valor mínimo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "???", "FG02 - PROC1182 - Informar VL_DESCONTO igual ao valor mínimo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012 ");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3175-20200317.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura();
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "VL_DESCONTO", cobertura.ValorDescontoMenor);

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
        /// Informar VL_DESCONTO igual ao valor máximo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "???", "FG02 - PROC1182 - Informar VL_DESCONTO igual ao valor máximo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012 ");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3192-20200318.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura();
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "VL_DESCONTO", cobertura.ValorDescontoMaior);

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
