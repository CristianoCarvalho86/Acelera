using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC41_Layout94_Pompeia : TestesFG01
    {

        /// <summary>
        /// No Body do arquivo CLIENTE no campo NR_CNPJ_CPF informar CPF com 10 dígitos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2422_CLIENTE_NR_CNPJ_CPF_10Dig()
        {
            IniciarTeste(TipoArquivo.Cliente, "2422", "FG01 - PROC41 - No Body do arquivo CLIENTE no campo NR_CNPJ_CPF informar CPF com 10 dígitos");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1930-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "NR_CNPJ_CPF", "123456789009");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.POMPEIA.CLIENTE-EV-/*R*/-20200212.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("41");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo CLIENTE no campo NR_CNPJ_CPF informar CNPJ com15 dígitos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2423_CLIENTE_NR_CNPJ_CPF_15Dig()
        {
            IniciarTeste(TipoArquivo.Cliente, "2423", "FG01 - PROC41 - No Body do arquivo CLIENTE no campo NR_CNPJ_CPF informar CNPJ com 15 dígitos");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1930-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "NR_CNPJ_CPF", "123456789123456");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.POMPEIA.CLIENTE-EV-/*R*/-20200212.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("41");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO não informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos: NR_CNPJ_CPF (Será criiticado também plea PROC 5)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2424_PARC_EMISSAO_SemNR_CNPJ_CPF()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2424", "FG01 - PROC41 - No Body do arquivo PARC_EMISSAO não informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos: NR_CNPJ_CPF");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "NR_CNPJ_CPF", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.POMPEIA.PARCEMS-EV-/*R*/-20200212.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("41");
            ValidarTeste();
        }


        /// <summary>
        ///  Importar arquivo com CPF valido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2550_CLIENTE()
        {
        }

    }
}
