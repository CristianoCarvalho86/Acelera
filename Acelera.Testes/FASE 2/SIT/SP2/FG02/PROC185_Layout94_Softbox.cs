using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC185_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        ///Informar DT_REGISTRO = D-365 da DT_AVISO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3702_DT_REGISTRO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3702", "FG02 - PROC185 -Informar DT_REGISTRO = D-365 da DT_AVISO");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3220-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_REGISTRO", SomarData("DT_AVISO", -365));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200319.txt");

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
        public void SAP_3703_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3703", "FG02 - PROC185 - Informar DT_REGISTRO = DT_AVISO");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3222-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", ObterValor(0, "DT_AVISO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200319.txt");

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
        ///Informar DT_REGISTRO = D+365 da DT_AVISO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3704_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3704", "FG02 - PROC185 - Informar DT_REGISTRO = D+365 da DT_AVISO");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3231-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_REGISTRO", SomarData("DT_AVISO", 365));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.txt");

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
