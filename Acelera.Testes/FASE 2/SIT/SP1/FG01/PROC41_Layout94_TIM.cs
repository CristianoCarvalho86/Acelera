using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC41_Layout94_TIM : TestesFG01
    {

        /// <summary>
        /// No Body do arquivo CLIENTE no campo NR_CNPJ_CPF informar CPF com 8 dígitos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2348_CLIENTE_NR_CNPJ_CPF_8Dig()
        {
            IniciarTeste(TipoArquivo.Cliente, "2348", "FG01 - PROC41 - No Body do arquivo CLIENTE no campo NR_CNPJ_CPF informar CPF com 8 dígitos");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "NR_CNPJ_CPF", "1234567808");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.CLIENTE-EV-/*R*/-20200214.TXT");

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
        /// No Body do arquivo CLIENTE no campo NR_CNPJ_CPF informar CNPJ com dígito verificador inválido
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2349_CLIENTE_NR_CNPJ_CPF_DigInv()
        {
            IniciarTeste(TipoArquivo.Cliente, "2349", "FG01 - PROC41 - No Body do arquivo CLIENTE no campo NR_CNPJ_CPF informar CNPJ com dígito verificador inválido");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "NR_CNPJ_CPF", "12345678910");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.CLIENTE-EV-/*R*/-20200214.TXT");

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
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2350_PARC_EMISSAO_SemNR_CNPJ_CPF()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2350", "FG01 - PROC41 - No Body do arquivo PARC_EMISSAO não informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos: NR_CNPJ_CPF");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0002-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "NR_CNPJ_CPF", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.PARCEMS-EV-/*R*/-20200214.TXT");

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
        public void SAP_2549_CLIENTE()
        {
        }

    }
}
