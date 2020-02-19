using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acelera.Domain.Enums;

namespace Acelera.Domain.Entidades.Tabelas
{
    public class LogProcessamento : LinhaTabela
    {
        public override TabelasEnum TabelaReferente => throw new NotImplementedException();

        protected override void CarregarCampos()
        {
            throw new NotImplementedException();
        }
    }
}
