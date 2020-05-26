using Acelera.Domain.Entidades.SGS;
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
            MassaCliente_Sinistro massaCliente = null;
            Massa_Sinistro_Parcela massaParcela = null;
            var resultado = a.ValidaTabelasTemporariasSGS("327", "313101654880", "1", "00696865", out massaCliente, out massaParcela);
            a.ValidarCdContratoDisponivel("313101654880");
            a.Executar();
            a.ValidarStageCliente(massaCliente);
            a.ValidarStageParcela(massaParcela);
        }

    }
}
