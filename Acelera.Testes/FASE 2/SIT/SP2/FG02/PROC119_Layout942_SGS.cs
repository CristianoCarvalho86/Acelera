using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC119_Layout942_SGS : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO =7 e não informar CD_FORMA_PAGTO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2968_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2968", "FG02 - PROC119 - Informar CD_TIPO_MOVIMENTO =7 e não informar CD_FORMA_PAGTO");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_FORMA_PAGTO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "119");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO =146 e não informar CD_FORMA_PAGTO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2969_CD_FORMA_PAGTO()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2969", "FG02 - PROC88 - Informar CD_TIPO_MOVIMENTO =146 e não informar CD_FORMA_PAGTO");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_FORMA_PAGTO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "119");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO =7, e informar CD_FORMA_PAGTO=B
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2970_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2970", "Informar CD_TIPO_MOVIMENTO =7, e informar CD_FORMA_PAGTO=C");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_FORMA_PAGTO", "R");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO =146, e informar CD_FORMA_PAGTO=N
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2971_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2971", "Informar CD_TIPO_MOVIMENTO =146, e informar CD_FORMA_PAGTO=N");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_FORMA_PAGTO", "M");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
