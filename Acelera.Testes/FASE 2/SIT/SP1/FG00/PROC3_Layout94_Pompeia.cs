﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC3_Layout94_Pompeia : TestesFG00
    {
        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1366_CLIENTE_QT_LIN_Diferente()
        {
            IniciarTeste(TipoArquivo.Cliente, "1366", "FG00 - PROC3 - No Trailler do arquivo CLIENTE no campo QT_LIN informar valor diferente da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1975-20200228.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "10", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.CLIENTE-EV-/*R*/-20200228.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Linhas do arquivo diferente do numero verificador no footer.");
            ValidarTabelaDeRetorno("3");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1367_PARC_EMISSAO_QT_LIN_Diferente()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "1367", "FG00 - PROC3 - No Trailler do arquivo PARC_EMISSAO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "10", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200211.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Linhas do arquivo diferente do numero verificador no footer.");
            ValidarTabelaDeRetorno("3");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1368_EMS_COMISSAO_QT_LIN_Diferente()
        {
            IniciarTeste(TipoArquivo.Comissao, "1368", "FG00 - PROC3 - No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.EMSCMS-EV-1977-20200228.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "10", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.EMSCMS-EV-/*R*/-20200228.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Linhas do arquivo diferente do numero verificador no footer.");
            ValidarTabelaDeRetorno("3");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1369_OCR_COBRANCA_QT_LIN_Diferente()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1369", "FG00 - PROC3 - No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor diferente da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1695-20191128.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "10", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.COBRANCA-EV-/*R*/-20191128.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Linhas do arquivo diferente do numero verificador no footer.");
            ValidarTabelaDeRetorno("3");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1370_LANCTO_COMISSAO_QT_LIN_Diferente()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "1370", "FG00 - PROC3 - No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9623-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "10", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.LCTCMS-EV-/*R*/-20190311.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Linhas do arquivo diferente do numero verificador no footer.");
            ValidarTabelaDeRetorno("3");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1371_SINISTRO_QT_LIN_Diferente()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1371", "FG00 - PROC3 - No Trailler do arquivo SINISTRO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191128.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "10", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191128.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Linhas do arquivo diferente do numero verificador no footer.");
            ValidarTabelaDeRetorno("3");
            ValidarStages(false);
            ValidarTeste();
        }


        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1456_CLIENTE_QT_LIN()
        {
            IniciarTeste(TipoArquivo.Cliente, "1456", "No Trailler do arquivo CLIENTE no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages(true, 110);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1457_PARC_EMISSAO_QT_LIN()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "1457", "No Trailler do arquivo PARC_EMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200211.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages(true, 110);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1458_EMS_COMISSAO_QT_LIN()
        {
            IniciarTeste(TipoArquivo.Comissao, "1458", "No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.EMSCMS-EV-1926-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.EMSCMS-EV-/*R*/-20200210.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages(true, 110);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1459_OCR_COBRANCA_QT_LIN()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1459", "No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1695-20191128.txt"));

            //ALTERAR O VALOR SELECIONADO


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.COBRANCA-EV-/*R*/-20191128.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages(true, 110);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1460_LANCTO_COMISSAO_QT_LIN()
        {
            //------------------------------------------------SEM MASSA------------------------------------------------------------------

        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1461_SINISTRO_QT_LIN()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1461", "No Trailler do arquivo SINISTRO no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200211.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages(true, 110);
            ValidarTeste();
        }

    }
}
