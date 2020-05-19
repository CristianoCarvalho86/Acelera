using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC185_Layout942_SGS : TestesFG02
    {

        /// <summary>
        ///Informar DT_REGISTRO = D-1 da DT_AVISO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3693_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3693", "FG02 - PROC185 -Informar DT_REGISTRO = D-1 da DT_AVISO");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_REGISTRO", SomarData(ObterValor(0,"DT_AVISO"), -1));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "185");
            ValidarTeste();
        }

        /// <summary>
        ///Informar DT_REGISTRO = DT_AVISO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3694_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3694", "FG02 - PROC185 - Informar DT_REGISTRO = DT_AVISO");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_REGISTRO", ObterValor(0, "DT_AVISO"));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "185");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        }

        /// <summary>
        ///Informar DT_REGISTRO = D+1 da DT_AVISO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3695_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3695", "FG02 - PROC185 - Informar DT_REGISTRO = D+1 da DT_AVISO");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_REGISTRO", SomarData(ObterValor(0,"DT_AVISO"), 1));
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "185");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        }
    }
}
