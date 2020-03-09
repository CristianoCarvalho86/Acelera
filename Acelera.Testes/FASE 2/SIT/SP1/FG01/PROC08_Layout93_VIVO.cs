using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC08_Layout93_VIVO : TestesFG01
    {

        /// <summary>
        ///No Body do arquivo CLIENTE nos campos abaixo informado o código 1234567 respeitando a tamanho do campos: EN_CEP
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2257_CLIENTE_CEPInv()
        {
            IniciarTeste(TipoArquivo.Cliente, "2257", "FG01 - PROC8 - No Body do arquivo CLIENTE nos campos abaixo informado o código 1234567 respeitando a tamanho do campos: EN_CEP");
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1867-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "EN_CEP", "1234567");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.VIVO.CLIENTE-EV-/*R*/-20200212.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaClienteStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("8");
        }
    

        /// <summary>
        ///No Body do arquivo PARC_EMISSAO_AUTO nos campos abaixo informado o código 1234567 respeitando a tamanho do campos: CEP_UTILIZACAO CEP_PERNOITE
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2258_PARC_EMISSAO_AUTO_CEPInv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2258", "FG01 - PROC8 - No Body do arquivo PARC_EMISSAO nos campos abaixo informado o código 1234567 respeitando a tamanho do campos: CEP_UTILIZACAO CEP_PERNOITE");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CEP_UTILIZACAO", "1234567");
            AlterarHeader("CEP_PERNOITE", "1234567");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaParcEmissaoAutoStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("8");
        }

        /// <summary>
        /// Importar arquivo com CEP em formato válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2532_CLIENTE_CEP()
        {
        }

        /// <summary>
        /// Importar arquivo com CEP em formato válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2533_PARC_EMISSAO_AUTO_CEP()
        {
        }

    }
}
