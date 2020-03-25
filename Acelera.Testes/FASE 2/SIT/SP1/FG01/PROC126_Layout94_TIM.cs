using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC126_Layout94_TIM : TestesFG01
    {

        /// <summary>
        ///  No Body do arquivo CLIENTE no campo EN_UF informar valor o código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2360_CLIENTE_EN_UF_01()
        {
            IniciarTeste(TipoArquivo.Cliente, "2360", "FG01 - PROC126 - No Body do arquivo CLIENTE no campo EN_UF informar valor o código 01");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0002-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "EN_UF", "01");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.CLIENTE-EV-/*R*/-20200213.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("126");
            ValidarTeste();
        }

        /// <summary>
        ///  No Body do arquivo PARC_EMISSAO no campo CD_UF_RISCO informar valor o código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2361_PARC_EMISSAO_EN_UF_RISCO_01()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2361", " FG01 - PROC126 - No Body do arquivo PARC_EMISSAO no campo CD_UF_RISCO informar valor o código 01");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0002-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_UF_RISCO", "01");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.PARCEMS-EV-/*R*/-20200214.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("126");
            ValidarTeste();
        }

        /// <summary>
        ///  No Body do arquivo SINISTRO no campo EN_UF_BENEFICIARIO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2362_SINISTRO_EN_UF_BENEFICIARIO_01()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2362", "FG01 - PROC126 - No Body do arquivo SINISTRO no campo EN_UF_BENEFICIARIO informar código 01");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0002-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "EN_UF_BENEFICIARIO", "01");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.SINISTRO-EV-/*R*/-20200212.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("126");
            ValidarTeste();
        }
        
        /// <summary>
        ///  Importar arquivo com UF válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2585_CLIENTE()
        {
        }

        /// <summary>
        ///  Importar arquivo com UF válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2586_PARC_EMISSAO()
        {
        }

        /// <summary>
        ///  Importar arquivo com UF válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2587_SINISTRO()
        {
        }
    }
}
