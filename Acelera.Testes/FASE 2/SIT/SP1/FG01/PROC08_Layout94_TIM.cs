using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC08_Layout94_TIM : TestesFG01
    {

        /// <summary>
        ///No Body do arquivo CLIENTE nos campos abaixo informado o código 1234567 respeitando a tamanho do campos: EN_CEP
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2342_CLIENTE_CEPInv()
        {
            IniciarTeste(TipoArquivo.Cliente, "2342", "FG01 - PROC8 - No Body do arquivo CLIENTE nos campos abaixo informado o código 1234567 respeitando a tamanho do campos: EN_CEP");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "EN_CEP", "1234567");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.CLIENTE-EV-/*R*/-20200214.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("8");
            ValidarTeste();
        }

        /// <summary>
        ///No Body do arquivo SINISTRO nos campos abaixo informado o código 1234567 respeitando a tamanho do campos: EN_CEP_BENEFICIARIO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2344_SINISTRO_CEPInv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2344", "FG01 - PROC8 - No Body do arquivo SINISTRO nos campos abaixo informado o código 1234567 respeitando a tamanho do campos: EN_CEP_BENEFICIARIO");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0001-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "EN_CEP_BENEFICIARIO", "1234567");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.SINISTRO-EV-/*R*/-20200214.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("8");
            ValidarTeste();
        }

        /// <summary>
        /// Importar arquivo com CEP em formato válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2535_CLIENTE_CEP()
        {
        }

        /// <summary>
        /// Importar arquivo com CEP em formato válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2536_PARC_EMISSAO_CEP()
        {
        }

        /// <summary>
        /// Importar arquivo com CEP em formato válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2537_SINISTRO_CEP()
        {
        }

    }
}
