using Acelera.Domain.Entidades.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.SGS
{
    public class PaisSGS: EntidadeDeTabela<PaisSGS>
    {
        public string NM_PAIS { get; set; }

        public override string nomeTabela => "TB_SGS_PAIS_0080";

    }
}
