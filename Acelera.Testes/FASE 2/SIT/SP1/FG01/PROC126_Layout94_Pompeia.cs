using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC126_Layout94_Pompeia : TestesFG01
    {

        /// <summary>
        ///  No Body do arquivo CLIENTE no campo EN_UF informar valor o código CC
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2434_CLIENTE_EN_UF_CC()
        {
            IniciarTeste(TipoArquivo.Cliente, "2434", "FG01 - PROC126 - No Body do arquivo CLIENTE no campo EN_UF informar valor o código CC");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1933-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "EN_UF", "CC");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.CLIENTE-EV-/*R*/-20200213.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("126");
            ValidarTeste();
        }

        /// <summary>
        ///  No Body do arquivo PARC_EMISSAO no campo CD_UF_RISCO informar valor o código PP
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2435_PARC_EMISSAO_EN_UF_RISCO_PP()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2435", "FG01 - PROC126 - No Body do arquivo PARC_EMISSAO no campo CD_UF_RISCO informar valor o código PP");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1934-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_UF_RISCO", "PP");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.PARCEMS-EV-/*R*/-20200213.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("126");
            ValidarTeste();
        }

        /// <summary>
        ///  No Body do arquivo SINISTRO no campo EN_UF_BENEFICIARIO informar código SS
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2436_SINISTRO_EN_UF_BENEFICIARIO_SS()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2436", "FG01 - PROC126 - No Body do arquivo SINISTRO no campo EN_UF_BENEFICIARIO informar código SS");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "EN_UF_BENEFICIARIO", "SS");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.SINISTRO-EV-/*R*/-20200211.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

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
        public void SAP_2588_CLIENTE()
        {
        }

        /// <summary>
        ///  Importar arquivo com UF válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2589_PARC_EMISSAO()
        {
        }

        /// <summary>
        ///  Importar arquivo com UF válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2590_PSINISTRO()
        {
        }
    }
}
