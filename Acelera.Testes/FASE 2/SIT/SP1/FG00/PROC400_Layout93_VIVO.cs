﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC400_Layout93_VIVO : TestesFG00
    {
        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo NOMEARQ informar o nome CLIENTE respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1117_LANCTO_COMISSAO_NOMEARQ_CLIENTE()
        {
            //------------------------------------------------SEM MASSA------------------------------------------------------------------
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo NOMEARQ informar o nome PARCEMSAUTO respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1116_OCR_COBRANCA_NOMEARQ_PARCEMSAUTO()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1116", "FG00 - PROC400 - No Header do arquivo OCR_COBRANCA no campo NOMEARQ informar o nome PARCEMSAUTO");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1870-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NOMEARQ", "PARCEMSAUTO");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.COBRANCA-EV-/*R*/-20200212.TXT");

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
        /// No Header do arquivo PARC_EMISSAO_AUTO no campo NOMEARQ informar o nome COBRANCA respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1114_PARC_EMISSAO_AUTO_NOMEARQ_COBRANCA()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "1114", "FG00 - PROC400 - No Header do arquivo PARC_EMISSAO_AUTO no campo NOMEARQ informar o nome COBRANCA");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NOMEARQ", "COBRANCA");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Nome do arquivo diferente do header");
            ValidarTabelaDeRetorno("400");
            ValidarStages( false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo NOMEARQ informar o nome LCTCMS respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1113_CLIENTE_NOMEARQ_LCTCMS()
        {
            IniciarTeste(TipoArquivo.Cliente, "1113", "FG00 - PROC400 - No Header do arquivo CLIENTE no campo NOMEARQ informar o nome LCTCMS");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NOMEARQ", "LCTCMS");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT");

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
        /// No Header do arquivo COMISSAO no campo NOMEARQ informar o nome SINISTRO respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1115_COMISSAO_NOMEARQ_LCTCMS()
        {
            IniciarTeste(TipoArquivo.Comissao, "1115", "FG00 - PROC400 - No Header do arquivo COMISSAO no campo NOMEARQ informar o nome LCTCMS");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1821-20200201.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NOMEARQ", "SINISTRO");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.EMSCMS-EV-/*R*/-20200201.TXT");

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
        /// No Header do arquivo CLIENTE no campo NOMEARQ informar o código CLIENTE Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1179_CLIENTE_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo NOMEARQ informar o código PARCEMS Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1180_PARC_EMISSAO_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo NOMEARQ informar o código EMSCMS Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1181_EMS_COMISSAO_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo NOMEARQ informar o código COBRANCA Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1182_OCR_COBRANCA_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo NOMEARQ informar o código LCTCMS Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1183_LANCTO_COMISSAO_NOMEARQ()
        {
        }

    }
}
