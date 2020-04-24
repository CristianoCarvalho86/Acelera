using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1039_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Infomar SEXO=1
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3809_DT_FIM_VIGENCIA_inv()
        {
            IniciarTeste(TipoArquivo.Cliente, "3809", "FG02 - PROC1039 - Infomar SEXO=1");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.CLIENTE-EV-3209-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "SEXO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1039");
            ValidarTeste();

        }

        /// <summary>
        /// Infomar SEXO=k
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3810_DT_FIM_VIGENCIA_inv()
        {
            IniciarTeste(TipoArquivo.Cliente, "3810", "FG02 - PROC1039 - Infomar SEXO=k");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.CLIENTE-EV-3225-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "SEXO", "k");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1039");
            ValidarTeste();

        }

        /// <summary>
        /// Infomar SEXO=F
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3811_Cliente_semcritica()
        {
            IniciarTeste(TipoArquivo.Cliente, "3811", "FG02 - PROC1039 - Infomar SEXO=kInfomar SEXO=F");

            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.CLIENTE-EV-3241-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "SEXO", "F");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Infomar SEXO=M
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3812_Cliente_semcritica()
        {
            IniciarTeste(TipoArquivo.Cliente, "3812", "FG02 - PROC1039 - Infomar SEXO=kInfomar SEXO=M");

            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.CLIENTE-EV-3257-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "SEXO", "M");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

    }
}
