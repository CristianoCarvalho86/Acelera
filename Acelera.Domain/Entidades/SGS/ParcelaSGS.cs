using Acelera.Domain.Entidades.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.SGS
{
    public class ParcelaSGS : EntidadeDeTabela<ParcelaSGS>
    {
        public override string nomeTabela => "EMS_PARCELA";
        public string COD_RAMO { get; set; }
        public string CD_PARC_PREM { get; set; }
        public string COD_COBT { get; set; }
        public string COD_ITEM { get; set; }
        public string VLR_IS { get; set; }
        public string VLR_FRAQ { get; set; }

    }
}
