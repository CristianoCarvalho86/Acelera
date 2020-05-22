using Acelera.Domain.Entidades.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.SGS
{
    public class EnderecoSGS : EntidadeDeTabela
    {
        public string DS_ENDER { get; set; }
        public string NR_ENDER { get; set; }
        public string DS_ENDER_COMPL { get; set; }
        public string NM_BAIRRO { get; set; }
        public string NM_CID { get; set; }
        public string CD_UF { get; set; }
        public string CD_CEP { get; set; }

        public override string NomeTabela => "CLI_ENDERECO";
    }
}
