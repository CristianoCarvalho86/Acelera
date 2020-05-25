using Acelera.Testes.DataAccessRep;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG03
{
    [TestClass]
    public class Testes : TestesFG03
    {
        [TestMethod]
        public void Teste1()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Sinistro, "1111", "inicial");
            var a = new SGSData(logger);
            a.ValidaTabelasTemporariasSGS()
        }

    }
}
