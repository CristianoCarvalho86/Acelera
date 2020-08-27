using Acelera.Testes.FASE_2.SIT.SP4.FG07;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG08
{
    [TestClass]
    public class FG08_LASA : TestesFG08
    {
        private FG07_LASA testeFG07;
        public FG08_LASA()
        {
            testeFG07 = new FG07_LASA();
        }

        [TestMethod]
        public void SAP_9867()
        {
            numeroDoTeste = "9867";
            testeFG07.SAP_6162();
            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9865()
        {
            numeroDoTeste = "9865";
            testeFG07.SAP_6160();
            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9866()
        {
            numeroDoTeste = "9866";
            testeFG07.SAP_6161();
            ExecutarEValidarFG08(true);
        }
        [TestMethod]
        public void SAP_9864()
        {
            numeroDoTeste = "9864";
            testeFG07.SAP_6159();
            ExecutarEValidarFG08(true);
        }
        [TestMethod]
        public void SAP_9863()
        {
            numeroDoTeste = "9863";
            testeFG07.SAP_6158();
            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9862()
        {
            numeroDoTeste = "9862";
            testeFG07.SAP_6157();
            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9861()
        {
            numeroDoTeste = "9861";
            testeFG07.SAP_6156();
            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9860()
        {
            numeroDoTeste = "9860";
            testeFG07.SAP_6155();
            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9859()
        {
            numeroDoTeste = "9859";
            testeFG07.SAP_6154();
            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9858()
        {
            numeroDoTeste = "9858";
            //testeFG07.SAP_9762();     PERGUNTAR QUEM EH ESSE CARA
            ExecutarEValidarFG08(true);
        }
    }
}
