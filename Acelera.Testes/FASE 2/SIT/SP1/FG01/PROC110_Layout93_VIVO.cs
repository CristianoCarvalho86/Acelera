using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC110_Layout93_VIVO : TestesFG01
    {

        /// <summary>
        /// No arquivo CLIENTE repetir 3x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2204_CLIENTE_3xBody()
        {
            IniciarTeste(TipoArquivo.Cliente, "2204", "FG01 - PROC110 - No arquivo CLIENTE repetir 3x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03");
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "NR_CNPJ_CPF", "05168329721");
            ReplicarLinha(0, 3);
            AumentarLinhasNoFooter(3);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01,true);
            ValidarTabelaDeRetorno("110");
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo CLIENTE repetir 3x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2204_1_CLIENTE_3xBody()
        {
            IniciarTeste(TipoArquivo.Cliente, "2204", "FG01 - PROC110 - No arquivo CLIENTE repetir 3x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03");
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "NR_CNPJ_CPF", "111111111");
            ReplicarLinha(0, 3);
            AumentarLinhasNoFooter(3);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01, true);
            ValidarTabelaDeRetorno("110");
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo PARC_EMISSAO_AUTO repetir 3x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2205_PARC_EMISSAO_AUTO_3xBody()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2205", "FG01 - PROC110 - No arquivo PARC_EMISSAO_AUTO repetir 3x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 3);
            AumentarLinhasNoFooter(3);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01,true);
            ValidarTabelaDeRetorno("110");
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo EMS_COMISSAO repetir 3x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2206_EMS_COMISSAO_3xBody()
        {
            IniciarTeste(TipoArquivo.Comissao, "2206", "FG01 - PROC110 - No arquivo EMS_COMISSAO repetir 3x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 3);
            AumentarLinhasNoFooter(3);
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.EMSCMS-EV-/*R*/-20200211.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01,true);
            ValidarTabelaDeRetorno("110");
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo OCR_COBRANCA repetir 3x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2207_OCR_COBRANCA_3xBody()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2207", "FG01 - PROC110 - No arquivo OCR_COBRANCA repetir 3x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03");
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1866-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 3);
            AumentarLinhasNoFooter(3);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.COBRANCA-EV-/*R*/-20200211.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01,true);
            ValidarTabelaDeRetorno("110");
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo LANCTO_COMISSAO repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2208_LANCTO_COMISSAO_1xBody()
        {
            //-------------------------------------------SEM MASSA--------------------------------------------------
        }

        /// <summary>
        /// Importar arquivo s/ registro duplicado
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2437_CLIENTE()
        {
        }

        /// <summary>
        /// Importar arquivo s/ registro duplicado
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2438_PARC_EMISSAO_AUTO()
        {
        }

        /// <summary>
        /// Importar arquivo s/ registro duplicado
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2439_EMS_COMISSAO()
        {
        }

        /// <summary>
        /// Importar arquivo s/ registro duplicado
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2440_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Importar arquivo s/ registro duplicado
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2441_LANCTO_COMISSAO()
        {
        }

    }
}
