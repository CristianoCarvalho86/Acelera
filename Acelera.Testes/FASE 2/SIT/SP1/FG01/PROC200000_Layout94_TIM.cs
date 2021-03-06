﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC200000_Layout94_TIM : TestesFG01
    {
        /// <summary>
        /// PARC_EMISSAO - Não Informar versão do layout
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2364_PARC_EMISSAO_PlanoB()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2364", "FG01 - PROC200000 - PARC_EMISSAO - Testar Plano B para PARC_EMISSAO");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0002-20200610.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_CONTRATO", ObterContratoPlanoB());
            RemoverLinhasExcetoAsPrimeiras(1);
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.PARCEMS-EV-/*R*/-20200610.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.PlanoB);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }

        /// <summary>
        /// EMS_COMISSAO - Não Informar versão do layout
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2365_EMS_COMISSAO_PlanoB()
        {
            IniciarTeste(TipoArquivo.Comissao, "2365", "FG01 - PROC200000 - EMS_COMISSAO - Testar PlanoB");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.EMSCMS-EV-0003-20200109.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_CONTRATO", ObterContratoPlanoB());
            RemoverTodasAsLinhasMenosUma(0);
            AlterarFooter("QT_LIN", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.EMSCMS-EV-/*R*/-20200109.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.PlanoB);
            ValidarTeste();
        }

        /// <summary>
        /// OCR_COBRANCA - Não Informar versão do layout
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2366_OCR_COBRANCA_SemVersao_layout()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2366", "FG01 - PROC200000 - OCR_COBRANCA - Testar Plano B");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1818-20200131.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_CONTRATO", ObterContratoPlanoB());
            RemoverTodasAsLinhasMenosUma(0);
            AlterarFooter("QT_LIN", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.COBRANCA-EV-/*R*/-20200131.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.PlanoB);
            ValidarTeste();
        }

        /// <summary>
        /// LANCTO_COMISSAO - Não Informar versão do layout
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2367_LANCTO_COMISSAO_SemVersao_layout()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "2367", "FG01 - PROC200000 - LANCTO_COMISSAO - Não Informar versão do layout");
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-0073-20190531.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_CONTRATO", ObterContratoPlanoB());
            RemoverTodasAsLinhasMenosUma(0);
            AlterarFooter("QT_LIN", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.LASA.LCTCMS-EV-/*R*/-20190531.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.PlanoB);
            ValidarTeste();

        }

        /// <summary>
        /// SINISTRO - Não Informar versão do layout
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2368_SINISTRO_SemVersao_layout()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2368", "FG01 - PROC200000 - SINISTRO - Não Informar versão do layout");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_CONTRATO", ObterContratoPlanoB());

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.SINISTRO-EV-/*R*/-20200212.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.PlanoB);
            ValidarTeste();
        }

    }
}
