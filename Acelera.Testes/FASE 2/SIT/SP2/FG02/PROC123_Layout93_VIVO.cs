using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC123_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// Informar DT_EMISSAO=D+1 da data atual
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4114_DT_EMISSAO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4114", "FG02 - PROC123 -Informar DT_EMISSAO=D+1 da data atual");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_EMISSAO", SomarData(dados.ObterDataDoBanco(),1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "123");
            ValidarTeste();
        }
        /// <summary>
        /// Informar DT_EMISSAO=D-1 da data atual
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4112_Sem_Critica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4112", "FG02 - PROC123 -Informar DT_EMISSAO=D+1 da data atual");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_EMISSAO", SomarData(dados.ObterDataDoBanco(), -1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }

        /// <summary>
        /// Informar DT_EMISSAOc= da data atual
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4113_Sem_Critica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4112", "FG02 - PROC123 -Informar DT_EMISSAO=D+1 da data atual");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_EMISSAO", dados.ObterDataDoBanco());

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }

    }
}
