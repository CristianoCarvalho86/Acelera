﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC06_Layout94_Pompeia : TestesFG01
    {
        /// <summary>
        /// No Body do arquivo CLIENTE no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_NASCIMENTO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2399_CLIENTE_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.Cliente, "2399", "FG01 - PROC6 - No Header do arquivo CLIENTE no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_NASCIMENTO");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1930-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_NASCIMENTO", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.CLIENTE-EV-/*R*/-20200212.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO nos campos abaixo informar data inválida (Ex. 32131234) DT_INICIO_VIGENCIA DT_FIM_VIGENCIA DT_VENCIMENTO DT_NASC_CONDUTOR
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2400_PARC_EMISSAO_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2400", "FG01 - PROC6 - No Body do arquivo PARC_EMISSAO nos campos abaixo informar data inválida (Ex. 32131234) DT_REFERENCIA DT_PROPOSTA DT_EMISSAO DT_EMISSAO_ORIGINAL");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0,"DT_REFERENCIA", "32131234");
            AlterarLinha(0,"DT_PROPOSTA", "32131234");
            AlterarLinha(0,"DT_EMISSAO", "32131234");
            AlterarLinha(0, "DT_EMISSAO_ORIGINAL", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.PARCEMS-EV-/*R*/-20200212.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA nos campos abaixo informar data inválida (Ex. 32131234) DT_OCORRENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2401_OCR_COBRANCA_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2401", "FG01 - PROC6 - No Body do arquivo OCR_COBRANCA nos campos abaixo informar data inválida (Ex. 32131234) DT_OCORRENCIA");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1695-20191128.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_OCORRENCIA", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.COBRANCA-EV-/*R*/-20191128.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo LANCTO_COMISSAO nos campos abaixo informar data inválida (Ex. 32131234) DT_PAGAMENTO DT_BAIXA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2402_LANCTO_COMISSAO_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "2402", "FG01 - PROC6 - No Body do arquivo LANCTO_COMISSAO nos campos abaixo informar data inválida (Ex. 32131234) DT_PAGAMENTO DT_BAIXA");
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9623-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_PAGAMENTO", "32131234");
            AlterarLinha(0, "DT_BAIXA", "32131234");
            RemoverLinhasExcetoAsPrimeiras(100);
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.LASA.LCTCMS-EV-/*R*/-20190311.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo SINISTRO nos campos abaixo informar data inválida (Ex. 32131234) DT_REGISTRO DT_NASC_BENEFICIARIO DT_PAGAMENTO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2403_SINISTRO_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2403", "FG01 - PROC6 - No Body do arquivo SINISTRO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_REGISTRO DT_NASC_BENEFICIARIO DT_PAGAMENTO");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0,"DT_REGISTRO", "32131234");
            AlterarLinha(0,"DT_NASC_BENEFICIARIO", "32131234");
            AlterarLinha(0, "DT_PAGAMENTO", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.SINISTRO-EV-/*R*/-20200127.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
            ValidarTeste();
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2506_CLIENTE()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2507_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2508_EMS_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2509_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2510_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2511_SINISTRO()
        {
        }

    }
}
