﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC4_Layout94_TIM : TestesFG00
    {
        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1227_SINISTRO_QT_LIN_CarEsp()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1227", "FG00 - PROC4 - No Trailler do arquivo SINISTRO no campo QT_LIN informar valor com um ou mais caracter especial");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0005-20180918.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "**", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.TIM.SINISTRO-EV-/*R*/-20180918.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Erro no numero verificador no footer.");
            ValidarTabelaDeRetorno("4");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1226_LANCTO_COMISSAO_QT_LIN_CarEsp()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "1226", "FG00 - PROC4 - No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor com um ou mais caracter especial");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-0073-20190531.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "(&", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.LCTCMS-EV-/*R*/-20190531.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Erro no numero verificador no footer.");
            ValidarTabelaDeRetorno("4");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1225_OCR_COBRANCA_QT_LIN_CarEsp()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1225", "FG00 - PROC4 - No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor com um ou mais caracter especial");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.COBRANCA-EV-9997-20191227.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "$$", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.TIM.COBRANCA-EV-/*R*/-20191227.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Erro no numero verificador no footer.");
            ValidarTabelaDeRetorno("4");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1224_EMS_COMISSAO_QT_LIN_CarEsp()
        {
            IniciarTeste(TipoArquivo.Comissao, "1224", "FG00 - PROC4 - No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor com um ou mais caracter especial");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.EMSCMS-EV-0003-20200113.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "#!", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.TIM.EMSCMS-EV-/*R*/-20200113.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Erro no numero verificador no footer.");
            ValidarTabelaDeRetorno("4");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1223_PARC_EMISSAO_QT_LIN_CarEsp()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "1223", "FG00 - PROC4 - No Trailler do arquivo PARC_EMISSAO no campo QT_LIN informar valor com um ou mais caracter especial");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "9+", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.TIM.PARCEMS-EV-/*R*/-20200212.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Erro no numero verificador no footer.");
            ValidarTabelaDeRetorno("4");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1222_CLIENTE_QT_LIN_CarEsp()
        {
            IniciarTeste(TipoArquivo.Cliente, "1222", "FG00 - PROC4 - No Trailler do arquivo CLIENTE no campo QT_LIN informar valor com um ou mais caracter especial");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "-5", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.TIM.CLIENTE-EV-/*R*/-20200212.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Erro no numero verificador no footer.");
            ValidarTabelaDeRetorno("4");
            ValidarStages(false);
            ValidarTeste();
        }


        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1311_SINISTRO_QT_LIN()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1311", "No Trailler do arquivo SINISTRO no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0001-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.TIM.SINISTRO-EV-/*R*/-20200214.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages(true, 110);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1310_LANCTO_COMISSAO_QT_LIN()
        {
            //------------------------------------------------SEM MASSA------------------------------------------------------------------
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1306_CLIENTE_QT_LIN()
        {
            IniciarTeste(TipoArquivo.Cliente, "1306", "No Trailler do arquivo CLIENTE no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0002-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.TIM.CLIENTE-EV-/*R*/-20200213.TXT");

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
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1309_OCR_COBRANCA_QT_LIN()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1309", "No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.COBRANCA-EV-9995-20191229.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.TIM.COBRANCA-EV-/*R*/-20191229.TXT");

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
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1308_EMS_COMISSAO_QT_LIN()
        {
            IniciarTeste(TipoArquivo.Comissao, "1308", "No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.EMSCMS-EV-0003-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.TIM.EMSCMS-EV-/*R*/-20200213.TXT");

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
        /// No Trailler do arquivo PARC_EMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1307_PARC_EMISSAO_QT_LIN()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "1307", "No Trailler do arquivo PARC_EMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0003-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.TIM.PARCEMSAUTO-EV-/*R*/-20200213.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages(true, 110);
            ValidarTeste();
        }

    }
}
