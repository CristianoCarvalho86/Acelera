using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC110_Layout94_Pompeia : TestesFG01
    {

        /// <summary>
        /// No arquivo LANCTO_COMISSAO repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2373_LANCTO_COMISSAO_1xBody()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "2373", "FG01 - PROC110 - No arquivo LANCTO_COMISSAO repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-0073-20190531.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.LASA.LCTCMS-EV-/*R*/-20190531.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("110");
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo SINISTRO repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2374_SINISTRO_1xBody()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2374", "FG01 - PROC110 - No arquivo SINISTRO repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.SINISTRO-EV-/*R*/-20200117.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("110");
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo OCR_COBRANCA repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2372_OCR_COBRANCA_1xBody()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2372", "FG01 - PROC110 - No arquivo OCR_COBRANCA repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1694-20191128.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.COBRANCA-EV-/*R*/-20191128.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("110");
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo EMS_COMISSAO repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2371_EMS_COMISSAO_1xBody()
        {
            IniciarTeste(TipoArquivo.Comissao, "2371", "FG01 - PROC110 - No arquivo EMS_COMISSAO repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.EMSCMS-EV-1920-20200208.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.EMSCMS-EV-/*R*/-20200208.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("110");
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo PARC_EMISSAO repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2370_PARC_EMISSAO_1xBody()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2370", "FG01 - PROC110 - No arquivo PARC_EMISSAO repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.PARCEMS-EV-/*R*/-20200211.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("110");
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo CLIENTE repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2369_CLIENTE_1xBody()
        {
            IniciarTeste(TipoArquivo.Cliente, "2369", "FG01 - PROC110 - No arquivo CLIENTE repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1927-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.CLIENTE-EV-/*R*/-20200211.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("110");
            ValidarTeste();
        }

        /// <summary>
        /// Importar arquivo s/ registro duplicado
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2449_CLIENTE()
        {
        }

        /// <summary>
        /// Importar arquivo s/ registro duplicado
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2451_EMS_COMISSAO()
        {
        }

        /// <summary>
        /// Importar arquivo s/ registro duplicado
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2452_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Importar arquivo s/ registro duplicado
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2453_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// Importar arquivo s/ registro duplicado
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2454_SINISTRO()
        {
        }

        /// <summary>
        /// Importar arquivo s/ registro duplicado
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2450_PARC_EMISSAO()
        {
        }

    }
}
