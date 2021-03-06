﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC92_Layout94_TIM : TestesFG00
    {

        /// <summary>
        ///  No Header do arquivo CLIENTE no campo VERSAO informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2354_CLIENTE_SemVERSAO()
        {
            IniciarTeste(TipoArquivo.Cliente, "2354", "FG00 - PROC92 - No Header do arquivo CLIENTE no campo VERSAO informar valor");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader( "VERSAO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.CLIENTE-EV-/*R*/-20200213.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout informada nï¿½o existente");
            ValidarTabelaDeRetorno("92");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///  No Header do arquivo PARC_EMISSAO no campo VERSAO não informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2355_PARC_EMISSAO_SemVERSAO()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2355", "FG00 - PROC92 - No Header do arquivo PARC_EMISSAO no campo VERSAO não informar valor");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0001-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader( "VERSAO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.PARCEMS-EV-/*R*/-20200214.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout informada nï¿½o existente");
            ValidarTabelaDeRetorno("92");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///  No Header do arquivo EMS_COMISSAO no campo VERSAO informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2356_EMS_COMISSAO_SemVERSAO()
        {
            IniciarTeste(TipoArquivo.Comissao, "2356", " FG00 - PROC92 - No Header do arquivo EMS_COMISSAO no campo VERSAO informar valor");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.EMSCMS-EV-0003-20200113.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "");
            RemoverLinhasExcetoAsPrimeiras(100);
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.EMSCMS-EV-/*R*/-20200213.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout informada nï¿½o existente");
            ValidarTabelaDeRetorno("92");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///  No Header do arquivo OCR_COBRANCA no campo VERSAO informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2357_OCR_COBRANCA_SemVERSAO()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2357", "FG00 - PROC92 - No Header do arquivo OCR_COBRANCA no campo VERSAO informar valor");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.COBRANCA-EV-9995-20191229.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "");
            RemoverLinhasExcetoAsPrimeiras(100);
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.COBRANCA-EV-/*R*/-20191229.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout informada nï¿½o existente");
            ValidarTabelaDeRetorno("92");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///  No Header do arquivo LANCTO_COMISSAO no campo VERSAO informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2357_LANCTO_COMISSAO_SemVERSAO()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "2357", " FG00 - PROC92 - No Header do arquivo LANCTO_COMISSAO no campo VERSAO informar valor");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-0073-20190531.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.LASA.LCTCMS-EV-/*R*/-20190531.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout informada nï¿½o existente");
            ValidarTabelaDeRetorno("92");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///  No Header do arquivo SINISTRO no campo VERSAO informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2358_SINISTRO_SemVERSAO()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2358", "FG00 - PROC92 - No Header do arquivo SINISTRO no campo VERSAO informar valor");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.SINISTRO-EV-/*R*/-20200213.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout informada nï¿½o existente");
            ValidarTabelaDeRetorno("92");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2569_CLIENTE()
        {
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2570_PARC_EMISSAO()
        {
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2571_EMS_COMISSAO()
        {
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2572_OCR_COBRANCA()
        {
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2573_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2574_SINISTRO()
        {
        }

        
    }
}
