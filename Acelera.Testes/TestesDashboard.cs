using Acelera.Domain.Entidades.ConjuntoArquivos;
using Acelera.Domain.Layouts;
using Acelera.Testes.FASE_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    [TestClass]
    public class TestesDashboard : TestesFG02
    {

        [TestMethod]
        public void Teste1()
        {
            TripliceLASA triplice = new TripliceLASA(1, Parametros.pastaOrigem, Parametros.pastaDestino);
            triplice.AlterarCliente(0, "CD_CLIENTE", "99991111");
            triplice.Salvar();
        }

        public override void FimDoTeste()
        {

        }

    }
}
