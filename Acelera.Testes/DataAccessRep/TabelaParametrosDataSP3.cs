using Acelera.Domain.Entidades;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.DataAccessRep
{
    public class TabelaParametrosDataSP3 : TabelaParametrosData
    {
        private IMyLogger logger;
        public TabelaParametrosDataSP3(IMyLogger logger):base(logger)
        {

        }

        public string ObterCdClienteParceiro(bool existente)
        {
             return  ObterRetornoPadrao("CD_EXTERNO", "CD_TIPO_PARCEIRO_NEGOCIO", existente , "CD_TIPO_PARCEIRO_NEGOCIO = 'OP'", true);
        }
    }
}
