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
        /// Infomar CD_SEXO=1
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3809_DT_FIM_VIGENCIA_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3809", "FG02 - PROC1039 - Infomar CD_SEXO=1");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3158-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SEXO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200316.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1039");
            ValidarTeste();

        }

        /// <summary>
        /// Infomar CD_SEXO=k
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3810_DT_FIM_VIGENCIA_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3810", "FG02 - PROC1039 - Infomar CD_SEXO=k");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3304-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SEXO", "k");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200325.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1039");
            ValidarTeste();

        }

        /// <summary>
        /// Infomar CD_SEXO=F
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3811_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3811", "FG02 - PROC1039 - Infomar CD_SEXO=kInfomar CD_SEXO=F");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3175-20200317.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SEXO", "F");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200317.txt");

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
        /// Infomar CD_SEXO=M
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3812_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3812", "FG02 - PROC1039 - Infomar CD_SEXO=kInfomar CD_SEXO=M");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3288-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SEXO", "M");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200324.txt");

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
