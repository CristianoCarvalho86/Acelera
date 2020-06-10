using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC213_Layout93_VIVO : TestesFG01
    {

        /// <summary>
        /// Informar Cd_VEICUCLO no formato NNNNNNN
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4679()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4679", "FG05 - PROC213");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            AlterarLinha(0, "CD_MODELO", "1234567");

            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("213");
            ValidarTeste();

        }

        /// <summary>
        /// Informar Cd_VEICUCLO no formato NNNNNNN
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4680()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4680", "FG05 - PROC213");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            AlterarLinha(0, "CD_MODELO", "11223-34");

            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("213");
            ValidarTeste();

        }

        /// <summary>
        /// Informar Cd_VEICUCLO no formato NNNNNNN
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4681()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4681", "FG05 - PROC213");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            AlterarLinha(0, "CD_MODELO", "14325-6");

            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("213");
            ValidarTeste();

        }


        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4282()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4682", "FG05 - PROC213");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            AlterarLinha(0, "CD_MODELO", "001001-4");

            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());

            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetorno("");
            ValidarTeste();

        }
    }
}
