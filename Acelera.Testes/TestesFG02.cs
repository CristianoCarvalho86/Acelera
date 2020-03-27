using Acelera.Testes.DataAccessRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2
{
    public class TestesFG02 : TestesFG01
    {
        public TabelaParametrosData dados;

        public TestesFG02():base()
        {
            dados = new TabelaParametrosData();
        }

        public override void ValidarFGsAnteriores()
        {
        }

    }
}
