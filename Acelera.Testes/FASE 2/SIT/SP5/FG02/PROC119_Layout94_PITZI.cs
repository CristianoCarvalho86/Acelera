using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC119_Layout94_PITZI : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO =7 e não informar CD_FORMA_PAGTO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2956_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2956", "FG02 - PROC119 - Informar CD_TIPO_MOVIMENTO =7 e não informar CD_FORMA_PAGTO");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.PITZI.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_FORMA_PAGTO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PITZI.SINISTRO-EV-/*R*/-20200211.txt");

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
        public void SAP_2957_CD_FORMA_PAGTO()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2957", "FG02 - PROC88 - Informar CD_TIPO_MOVIMENTO =146 e não informar CD_FORMA_PAGTO");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.PITZI.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_FORMA_PAGTO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PITZI.SINISTRO-EV-/*R*/-20200127.txt");

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
        public void SAP_2958_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2958", "Informar CD_TIPO_MOVIMENTO =7, e informar CD_FORMA_PAGTO=B");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.PITZI.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_FORMA_PAGTO", "B");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PITZI.SINISTRO-EV-/*R*/-20200117.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "119");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO =146, e informar CD_FORMA_PAGTO=N
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2959_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2959", "Informar CD_TIPO_MOVIMENTO =146, e informar CD_FORMA_PAGTO=N");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.PITZI.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PITZI.SINISTRO-EV-/*R*/-20191223.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "119");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
