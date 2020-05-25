using Acelera.Domain.Entidades.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.SGS
{
    public class PartCoSeguroSGS: EntidadeDeTabela<PartCoSeguroSGS>
    {
       public string COD_ITEM { get; set; }

        public override string nomeTabela => "EMS_PARTCOSSEGURO";
    }
}
