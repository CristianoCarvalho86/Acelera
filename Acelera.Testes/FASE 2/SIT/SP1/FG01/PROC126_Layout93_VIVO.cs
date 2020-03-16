using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC126_Layout93_VIVO : TestesFG01
    {

        /// <summary>
        ///  No Body do arquivo CLIENTE no campo EN_UF informar código CC
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2275_CLIENTE_EN_UF_CC()
        {
            IniciarTeste(TipoArquivo.Cliente, "2275", "FG01 - PROC126 - No Body do arquivo CLIENTE no campo EN_UF informar código CC");
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "EN_UF", "CC");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo(ObterArquivoDestino("C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT"));

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
        ///  No Body do arquivo PARC_EMISSAO_AUTO no campo CD_UF_RISCO informar código PP	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2276_PARC_EMISSAO_AUTO_EN_UF_RISCO_PP()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2276", "FG01 - PROC126 - No Body do arquivo PARC_EMISSAO_AUTO no campo CD_UF_RISCO informar código PP");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_UF_RISCO", "PP");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo(ObterArquivoDestino("C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("126");
            ValidarTeste();
        }

        /// <summary>
        ///  No Body do arquivo CLIENTE no campo EN_UF não informar valor, ou seja, campos em branco, respeitando a tamanho do campos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2278_CLIENTE_SemEN_UF()
        {
            IniciarTeste(TipoArquivo.Cliente, "2278", "FG01 - PROC126 - No Body do arquivo CLIENTE no campo EN_UF não informar valor");
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "EN_UF", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo(ObterArquivoDestino("C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT"));

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
        ///  No Body do arquivo PARC_EMISSAO_AUTO não informar valor, ou seja, campos em branco, respeitando a tamanho do campos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2279_PARC_EMISSAO_AUTO_SemEN_UF()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2279", "FG01 - PROC126 - No Body do arquivo PARC_EMISSAO_AUTO não informar valor");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_UF_RISCO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo(ObterArquivoDestino("C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());

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
        public void SAP_2582_CLIENTE()
        {
        }

        /// <summary>
        ///  Importar arquivo com UF válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2583_PARC_EMISSAO_AUTO()
        {
        }

    }
}
