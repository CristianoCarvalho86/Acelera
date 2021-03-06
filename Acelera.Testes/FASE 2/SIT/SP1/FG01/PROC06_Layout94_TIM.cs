﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC06_Layout94_TIM : TestesFG01
    {        
        /// <summary>
        /// No Body do arquivo CLIENTE no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_NASCIMENTO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2325_CLIENTE_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.Cliente, "2325", "FG01 - PROC6 - No Header do arquivo CLIENTE no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_NASCIMENTO");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_NASCIMENTO", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.CLIENTE-EV-/*R*/-20200214.TXT");

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
        /// No Body do arquivo PARC_EMISSAO nos campos abaixo informar data inválida (Ex. 32131234) DT_REFERENCIA DT_PROPOSTA DT_EMISSAO DT_EMISSAO_ORIGINAL
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2326_PARC_EMISSAO_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2326", "FG01 - PROC6 - No Body do arquivo PARC_EMISSAO nos campos abaixo informar data inválida (Ex. 32131234) DT_REFERENCIA DT_PROPOSTA DT_EMISSAO DT_EMISSAO_ORIGINAL");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0002-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0,"DT_REFERENCIA", "32131234");
            AlterarLinha(0,"DT_PROPOSTA", "32131234");
            AlterarLinha(0,"DT_EMISSAO", "32131234");
            AlterarLinha(0,"DT_EMISSAO_ORIGINAL", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.PARCEMS-EV-/*R*/-20200214.TXT");

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
        public void SAP_2327_OCR_COBRANCA_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2327", "FG01 - PROC6 - No Body do arquivo OCR_COBRANCA nos campos abaixo informar data inválida (Ex. 32131234) DT_OCORRENCIA");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.COBRANCA-EV-9996-20191227.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_OCORRENCIA", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.COBRANCA-EV-/*R*/-20191227.TXT");

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
        public void SAP_2328_LANCTO_COMISSAO_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "2328", "FG01 - PROC6 - No Header do arquivo LANCTO_COMISSAO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ");
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
        /// No Body do arquivo SINISTRO nos campos abaixo informar data inválida (Ex. 32131234) DT_MOVIMENTO DT_AVISO DT_OCORRENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2329_SINISTRO_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2329", "FG01 - PROC6 - No Header do arquivo SINISTRO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_MOVIMENTO DT_AVISO DT_OCORRENCIA");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0001-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", "32131234");
            AlterarLinha(0, "DT_AVISO", "32131234");
            AlterarLinha(0, "DT_OCORRENCIA", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.SINISTRO-EV-/*R*/-20200214.TXT");

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
        public void SAP_2500_CLIENTE()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2501_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2502_EMS_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2503_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2504_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2505_SINISTRO()
        {
        }

    }
}
