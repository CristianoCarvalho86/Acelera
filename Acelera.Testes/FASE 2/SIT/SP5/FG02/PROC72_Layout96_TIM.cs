using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC72_Layout96_TIM: TestesFG02
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9014()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-9014:FG02 - 72 - C/C - TIM - SINISTRO - CD_TIPO_MOVIMENTO = 2 e informar DT_PAGAMENTO");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(0, "DT_PAGAMENTO", dados.ObterDataDoBanco());

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("72");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9015()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-9015:FG02 - 72 - C/C - TIM - SINISTRO - CD_TIPO_MOVIMENTO = 30 e informar DT_PAGAMENTO");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "30");
            AlterarLinha(0, "DT_PAGAMENTO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("72");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9016()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-9016:FG02 - 72 - S/C - TIM - SINISTRO - CD_TIPO_MOVIMENTO = 2 e não informar DT_PAGAMENTO");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(0, "DT_PAGAMENTO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9017()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-9017:FG02 - 72 - S/C - TIM - SINISTRO - CD_TIPO_MOVIMENTO = 30 e não informar DT_PAGAMENTO");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "30");


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9018()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-9018:FG02 - 72 - S/C - SOFTBOX - SINISTRO - CD_TIPO_MOVIMENTO = 30 e informar DT_PAGAMENTO");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "DT_PAGAMENTO", dados.ObterDataDoBanco());

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }


    }
}
