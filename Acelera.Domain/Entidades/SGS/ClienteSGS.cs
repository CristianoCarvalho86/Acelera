using Acelera.Domain.Entidades.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.SGS
{
    public class ClienteSGS : EntidadeDeTabela<ClienteSGS>
    {
        public string TIP_PESS { get; set; }
        public string DTA_NASC { get; set; }
        public string COD_PESS { get; set; }
        public string NOM_PESS { get; set; }
        public string NRO_CPF { get; set; }
        public string NRO_RG { get; set; }
        public override string nomeTabela => "CLI_PESSOA";

        public override IList<string> CamposWhere => throw new NotImplementedException();
    }
}
