using Acelera.Testes.DataAccessRep;
using Acelera.Testes.FASE_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public class TestesFG05 : TestesFG02
    {
        protected TabelaParametrosDataSP3 dados { get; set; }

        [TestMethod]
        public void Teste()
        {
           var a = dados.ObterCdClienteParceiro(false);
        }
    }
}
