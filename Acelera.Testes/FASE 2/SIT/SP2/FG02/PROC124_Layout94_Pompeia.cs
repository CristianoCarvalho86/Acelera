﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC124_Layout94_Pompeia : TestesFG02
    {

        /// <summary>
        /// Informar DT_OCORRENCIA=D-7 da data atual
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3153_DT_OCORRENCIA_inv()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "3153", "FG02 - PROC124 -Informar DT_OCORRENCIA=D-7 da data atual");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1694-20191128.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_OCORRENCIA", SomarData(dados.ObterDataDoBanco(),-7));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.COBRANCA-EV-/*R*/-20191128.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "124");
            ValidarTeste();
        }

        /// <summary>
        ///Informar DT_OCORRENCIA igual a data atual
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3154_OCRCobranca_semcritica()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "3154", "FG02 - PROC124 - Informar DT_OCORRENCIA igual a data atual");

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1695-20191128.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_OCORRENCIA", dados.ObterDataDoBanco());

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.COBRANCA-EV-/*R*/-20191128.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        ///Informar DT_OCORRENCIA igual a D+7 da data atual
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3155_OCRCobranca_semcritica()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "3155", "FG02 - PROC124 - Informar DT_OCORRENCIA igual a D+7 da data atual");

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1766-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_OCORRENCIA", SomarData(dados.ObterDataDoBanco(), 7));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.COBRANCA-EV-/*R*/-20191220.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
