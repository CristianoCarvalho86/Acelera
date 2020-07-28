using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG01
{
    [TestClass]
    public class PROC192_Layout96_COOP : TestesFG01
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8906()
        {
            IniciarTeste(TipoArquivo.Cliente, "", "SAP-8906:FG01 - PROC 192 - C/C - CLIENTE - Informar endereço com em branco");

            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            AlterarLinha(0, "EN_ENDERECO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("192");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8907()
        {
            IniciarTeste(TipoArquivo.Cliente, "", "SAP-8907:FG01 - PROC 192 - C/C - CLIENTE - Informar endereço com um caracter");

            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            AlterarLinha(0, "EN_ENDERECO", "A");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("192");
            ValidarTeste();
        }
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8908()
        {
            IniciarTeste(TipoArquivo.Cliente, "", "SAP-8908:FG01 - PROC 192 - C/C - CLIENTE - Informar endereço com dois caracteres");

            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "EN_ENDERECO", "AA");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("192");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_8909()
        {
            IniciarTeste(TipoArquivo.Cliente, "", " SAP-8909:FG01 - PROC 192 - S/C - CLIENTE - Informar endereço com três caracterws");

            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            AlterarLinha(0, "EN_ENDERECO", "AAA");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_8910()
        {
            IniciarTeste(TipoArquivo.Cliente, "", " SAP-8909:FG01 - PROC 192 - S/C - CLIENTE - Informar endereço com três caracterws");

            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            AlterarLinha(0, "EN_ENDERECO", "AAAA");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }
    }
}
