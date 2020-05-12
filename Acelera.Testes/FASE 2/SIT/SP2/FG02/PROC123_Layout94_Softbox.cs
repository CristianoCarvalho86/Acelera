using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC123_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar DT_EMISSAO=D+365 da data atual
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4123_DT_EMISSAO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4123", "FG02 - PROC123 -Informar DT_EMISSAO=D+365 da data atual");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3212-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_EMISSAO", SomarData(dados.ObterDataDoBanco(),365));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200210.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "123");
            ValidarTeste();
        }
        /// <summary>
        /// Informar DT_EMISSAO=D-365 da data atual
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4121_Sem_Critica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4121", "FG02 - PROC123 -Informar DT_EMISSAO=D-365 da data atual");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3212-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_EMISSAO", SomarData(dados.ObterDataDoBanco(), -7));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200319.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTabelaDeRetorno(true, "123");
            ValidarTeste();
        }

        /// <summary>
        /// Informar DT_EMISSAO igual a data atual
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4122_Sem_Critica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4122", "FG02 - PROC123 -Informar DT_EMISSAO = data atual");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_EMISSAO", dados.ObterDataDoBanco());

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTabelaDeRetorno(true, "123");
            ValidarTeste();
        }

    }
}
