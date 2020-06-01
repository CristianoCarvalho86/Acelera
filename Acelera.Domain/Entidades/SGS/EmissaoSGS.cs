using Acelera.Domain.Entidades.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.SGS
{
    public class EmissaoSGS : EntidadeDeTabela<EmissaoSGS>
    {
        public string TIP_DOCTO_SEG { get; set; }
        public string TIP_EMIS { get; set; }
        public string COD_EMIS { get; set; }
        public string COD_MOEDA { get; set; }
        public string DAT_REFR { get; set; }
        public string NUM_PROPOSTA { get; set; }
        public string DATA_PROPOSTA { get; set; }
        public string DATA_APOLICE { get; set; }
        public string DAT_INI_SEGR { get; set; }
        public string DAT_FIM_SEGR { get; set; }
        public string NUM_APOLICE_CSA { get; set; }
        public string NUM_APOLICE { get; set; }
        public string NUM_ENDOSSO { get; set; }
        public string STS_EMIS { get; set; }
        public string COD_PROD { get; set; }

        public override string nomeTabela => "EMS_EMISSAO";

    }
}
