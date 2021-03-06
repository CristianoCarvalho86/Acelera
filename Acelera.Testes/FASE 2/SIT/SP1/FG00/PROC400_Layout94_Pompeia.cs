﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC400_Layout94_Pompeia : TestesFG00
    {
        /// <summary>
        /// No Header do arquivo CLIENTE no campo NOMEARQ não informar valor, campo em branco, respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1444_CLIENTE_SemNOMEARQ()
        {
            IniciarTeste(TipoArquivo.Cliente, "1444", "FG00 - PROC400 - No Header do arquivo CLIENTE no campo NOMEARQ não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1981-20200302.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NOMEARQ", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.CLIENTE-EV-/*R*/-20200302.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Nome do arquivo diferente do header");
            ValidarTabelaDeRetorno("400");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo NOMEARQ não informar valor, campo em branco, respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1445_PARC_EMISSAO_SemNOMEARQ()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "1445", "FG00 - PROC400 - No Header do arquivo PARC_EMISSAO no campo NOMEARQ não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1973-20200227.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NOMEARQ", ""); 

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200227.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Nome do arquivo diferente do header");
            ValidarTabelaDeRetorno("400");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo NOMEARQ não informar valor, campo em branco, respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1446_EMS_COMISSAO_SemNOMEARQ()
        {
            IniciarTeste(TipoArquivo.Comissao, "1446", "FG00 - PROC400 - No Header do arquivo EMS_COMISSAO no campo NOMEARQ não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.EMSCMS-EV-1980-20200229.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NOMEARQ", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.EMSCMS-EV-/*R*/-20200229.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Nome do arquivo diferente do header");
            ValidarTabelaDeRetorno("400");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo NOMEARQ não informar valor, campo em branco, respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1447_OCR_COBRANCA_SemNOMEARQ()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1447", "FG00 - PROC400 - No Header do arquivo OCR_COBRANCA no campo NOMEARQ não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1695-20191128.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NOMEARQ", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.COBRANCA-EV-/*R*/-20191128.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Nome do arquivo diferente do header");
            ValidarTabelaDeRetorno("400");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo NOMEARQ não informar valor, campo em branco, respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1448_LANCTO_COMISSAO_SemNOMEARQ()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "1448", "FG00 - PROC400 - No Header do arquivo LANCTO_COMISSAO no campo NOMEARQ não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9623-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NOMEARQ", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.LCTCMS-EV-/*R*/-20190311.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Nome do arquivo diferente do header");
            ValidarTabelaDeRetorno("400");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo NOMEARQ não informar valor, campo em branco, respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1449_SINISTRO_SemNOMEARQ()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1449", "FG00 - PROC400 - No Header do arquivo SINISTRO no campo NOMEARQ não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191128.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NOMEARQ", "LCTCMS");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191128.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Nome do arquivo diferente do header");
            ValidarTabelaDeRetorno("400");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo NOMEARQ informar o código CLIENTE Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1510_CLIENTE_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo NOMEARQ informar o código PARCEMS Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1511_PARC_EMISSAO_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo NOMEARQ informar o código EMSCMS Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1512_EMS_COMISSAO_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo NOMEARQ informar o código COBRANCA Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1513_OCR_COBRANCA_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo NOMEARQ informar o código LCTCMS Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1514_LANCTO_COMISSAO_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo NOMEARQ informar o código SINISTRO Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1515_SINISTRO_NOMEARQ()
        {
        }

    }
}
