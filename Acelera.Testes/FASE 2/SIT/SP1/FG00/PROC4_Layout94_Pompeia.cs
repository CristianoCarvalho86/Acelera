﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC4_Layout94_Pompeia : TestesFG00
    {
        /// <summary>
        /// Não informar o registro do Trailler no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1377_SINISTRO_SemTrailler()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1377", "FG00 - PROC4 - Não informar o registro do Trailler no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191127.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverFooter();

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191127.TXT");

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
        /// Não informar o registro do Trailler no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1376_LANCTO_COMISSAO_SemTrailler()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "1376", "FG00 - PROC4 - Não informar o registro do Trailler no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9999-20190531.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverFooter();

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
        /// Não informar o registro do Trailler no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1375_OCR_COBRANCA_SemTrailler()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1375", "FG00 - PROC4 - Não informar o registro do Trailler no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1695-20191128.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverFooter();

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.COBRANCA-EV-/*R*/-20191128.TXT");

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
        /// Não informar o registro do Trailler no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1374_COMISSAO_SemTrailler()
        {
            IniciarTeste(TipoArquivo.Comissao, "1374", "FG00 - PROC4 - Não informar o registro do Trailler no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.EMSCMS-EV-1974-20200227.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverFooter();

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.EMSCMS-EV-/*R*/-20200227.TXT");

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
        /// Não informar o registro do Trailler no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1373_PARC_EMISSAO_SemTrailler()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "1373", "FG00 - PROC4 - Não informar o registro do Trailler no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverFooter();

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200211.TXT");

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
        /// Não informar o registro do Trailler no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1372_CLIENTE_SemTrailler()
        {
            IniciarTeste(TipoArquivo.Cliente, "1372", "FG00 - PROC4 - Não informar o registro do Trailler no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1978-20200229.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverFooter();

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.CLIENTE-EV-/*R*/-20200229.TXT");

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
        public void SAP_1467_SINISTRO_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1466_LANCTO_COMISSAO_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1462_CLIENTE_QT_LIN()
        {
            IniciarTeste(TipoArquivo.Cliente, "1462", "No Trailler do arquivo CLIENTE no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

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
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1465_OCR_COBRANCA_QT_LIN()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1465", "No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

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
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1464_EMS_COMISSAO_QT_LIN()
        {
            IniciarTeste(TipoArquivo.Comissao, "1464", "No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

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
        /// No Trailler do arquivo PARC_EMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1463_PARC_EMISSAO_QT_LIN()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "1463", "No Trailler do arquivo PARC_EMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

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

    }
}
