using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1046_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar DT_INICIO_VIGENCIA=D+1 DT_EMISSAO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3843_NR_CNPJ_CPF_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3843", "FG02 - PROC1046 - Informar DT_INICIO_VIGENCIA=D+1 DT_EMISSAO");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3158-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_INICIO_VIGENCIA", SomarData(ObterValor(1,"DT_EMISSAO"), 1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC1046");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1046");
            ValidarTeste();

        }

        /// <summary>
        /// Informar DT_INICIO_VIGENCIA=D-1 DT_EMISSAO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3844_NR_CNPJ_CPF_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3844", "FG02 - PROC1046 - Informar DT_INICIO_VIGENCIA=D-1 DT_EMISSAO");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3175-20200317.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_INICIO_VIGENCIA", SomarData("DT_EMISSAO", -1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200317.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1046");
            ValidarTeste();

        }

        /// <summary>
        /// Informar DT_INICIO_VIGENCIA= DT_EMISSAO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3845_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3845", "FG02 - PROC1046 - Informar DT_INICIO_VIGENCIA= DT_EMISSAO");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3192-20200318.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_INICIO_VIGENCIA", ObterValor(1, "DT_EMISSAO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200318.txt");

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
