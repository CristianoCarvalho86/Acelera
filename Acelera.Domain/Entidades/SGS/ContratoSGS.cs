using Acelera.Domain.Entidades.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.SGS
{
    public class ContratoSGS: EntidadeDeTabela<ContratoSGS>
    {
        public string COD_SUC { get; set; }
        public string COD_CORR { get; set; }
        public string COD_CTRT { get; set; }
        public string COD_PESS { get; set; }

        public override string nomeTabela => "EMS_CONTRATO";
    }
}
