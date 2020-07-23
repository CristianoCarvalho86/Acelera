using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PRO55_Layout94_PITZI : TestesFG02
    {

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9020()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "Corretor com código SUSEP nulo");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCDSeguradoraDoTipoParceiro("SE"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("163");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9021()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "Corretor com código SUSEP invalido");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCDSeguradoraDoTipoParceiro("SE"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("163");
            ValidarTeste();
        }



        /// <summary>
        /// Importar arquivo com ID_TRANSACAO_CANC correto
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9022_PARC_EMISSAO_ID_TRANSACAO_CANC()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "Corretor com código SUSEP invalido");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCDSeguradoraDoTipoParceiro("CO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }

    }
}
