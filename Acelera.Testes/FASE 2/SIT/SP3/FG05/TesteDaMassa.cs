using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05
{
    [TestClass]
    public class TesteDaMassa : TestesFG05
    {
        [TestMethod]
        public void Teste()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "9999", "teste de criação de massa");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.EMSCMS-EV-5281-20200320.TXT"));
            SelecionarLinhaParaValidacao(0);
            SalvarArquivo();
            ValidarFGsAnteriores();
            ValidarTeste();
        }

    }
}
