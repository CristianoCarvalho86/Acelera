﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1167_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar CD_OCORRENCIA diferente de 18, 31 e 46 (ex:20)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3929_CD_OCORRENCIA_inv()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "3929", "FG02 - PROC1167 - Informar CD_OCORRENCIA diferente de 18, 31 e 46 (ex:20)");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.COBRANCA-EV-1600-20191108.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_OCORRENCIA", "20");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC1167");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1167");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_OCORRENCIA = 18
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3930_OCRCobranca_semcritica()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "3930", "FG02 - PROC1167 - Informar CD_OCORRENCIA = 18");

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.COBRANCA-EV-1600-20191108.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_OCORRENCIA", "18");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "1167");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_OCORRENCIA = 31
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3931_OCRCobranca_semcritica()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "3931", "FG02 - PROC1167 - Informar CD_OCORRENCIA = 31");

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.COBRANCA-EV-1600-20191108.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_OCORRENCIA", "31");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

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
        /// Informar CD_OCORRENCIA = 46
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3932_OCRCobranca_semcritica()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "3932", "FG02 - PROC1167 - Informar CD_OCORRENCIA = 46");

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.COBRANCA-EV-1600-20191108.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_OCORRENCIA", "46");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

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
