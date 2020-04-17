﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1091_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar VL_LMI maior que VL_IS (0.01)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3909_VL_LMI_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3909", "FG02 - PROC1091 - Informar VL_LMI maior que VL_IS (0.01)");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3158-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_LMI", SomarValor(0, "VL_IS", 0.01M));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1091");
            ValidarTeste();
        }

        /// <summary>
        /// Informar VL_LMI menor que VL_IS (0.01)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3910_VL_LMI_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3910", "FG02 - PROC1091 - Informar VL_LMI menor que VL_IS (0.01)");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3158-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_LMI", SomarValor(0, "VL_IS", -0.01M));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1091");
            ValidarTeste();
        }

        /// <summary>
        /// Informar VL_LMI igual ao VL_IS
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3911_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3911", "FG02 - PROC1091 - Informar VL_LMI igual ao VL_IS");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3240-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_LMI", ObterValor(0, "VL_IS"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
