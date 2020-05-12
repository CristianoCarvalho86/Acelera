using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC267_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar DT_NASCIMENTO de forma que o cliente tenha 17 anos (data atual - 17 anos)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3783_CANC_Inv()
        {
            IniciarTeste(TipoArquivo.Cliente, "3783", "FG02 - PROC267 - Informar DT_NASCIMENTO de forma que o cliente tenha 17 anos (data atual - 17 anos)");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.CLIENTE-EV-3227-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_NASCIMENTO", "20030416");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.CLIENTE-EV-/*R*/-20200320.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "267");
            ValidarTeste();

        }


        /// <summary>
        /// Informar DT_NASCIMENTO de forma que o cliente tenha exatamente igual a 18 anos (data atual - 18 anos)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3784_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.Cliente, "3784", "FG02 - PROC267 - Informar DT_NASCIMENTO de forma que o cliente tenha exatamente igual a 18 anos (data atual - 18 anos)");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.CLIENTE-EV-3211-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_NASCIMENTO", "20020416");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.CLIENTE-EV-/*R*/-20200319.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "267");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }

        /// <summary>
        /// Informar DT_NASCIMENTO de forma que o cliente tenha exatamente igual a 18 anos (data atual - 19 anos)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3785_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.Cliente, "3785", "FG02 - PROC267 - Informar DT_NASCIMENTO de forma que o cliente tenha exatamente igual a 18 anos (data atual - 19 anos)");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.CLIENTE-EV-2750-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_NASCIMENTO", "20010416");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.CLIENTE-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "267");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }

    }
}
