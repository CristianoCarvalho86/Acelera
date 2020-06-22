using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Acelera.Logger;
using Acelera.Testes.DataAccessRep;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG04
{
    [TestClass]
    public class Clientesods : TestesFG04
    {
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4830()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "", "");

            CarregarTriplice(OperadoraEnum.LASA);

            ExecutarEValidarTriplice(FGs.FG00, CodigoStage.AprovadoNAFG00, CodigoStage.AprovadoNAFG00, null);
           

        }

    }
}
