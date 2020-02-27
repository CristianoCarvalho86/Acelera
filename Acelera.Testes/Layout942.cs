using System;
using System.Configuration;
using System.Linq;
using Acelera.Data;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4_2;
using Acelera.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes
{
    [TestClass]
    public class Layout942 : TestesFG00
    {
        [TestMethod]
        public void Altera_NM_BENEFICIARIO_Valor_Incorreto()
        {
            IniciarTeste("NUMERO_DO_TESTE", "Altera_NM_BENEFICIARIO_Valor_Incorreto");
            //CARREGAR O ARQUIVO BASE
            var arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(arquivo, 50, "NM_BENEFICIARIO", "TESTANDO BLABLA");
            ReplicarLinha(arquivo, 50, 10);
            RemoverLinha(arquivo, 50);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.SGS.SINISTRO-EV-000001-20200209-ALTERADO.txt"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao("FG00");

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo(new string[] { "campo nao encontrado" , "outro erro"});
            //VALIDAR O LOG_PROCESSAMENTO_8000



        }
        
        [TestMethod]
        public void ABC()
        {
            DBHelper helper = DBHelper.Instance;
            var table = helper.GetData("select now() from dummy");

        }
        [Ignore]
        [TestMethod]
        public void Altera_EN_BENEFICIARIO_Valor_Incorreto()
        {
            //throw new Exception();


        }
    }
}
