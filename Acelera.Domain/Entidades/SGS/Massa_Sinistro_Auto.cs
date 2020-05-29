using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Entidades.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.SGS
{
    public class Massa_Sinistro_Parcela_Auto : Massa_Sinistro_Parcela
    {
        public override IList<string> CamposWhere
        {
            get
            {
                var t = new StageParcAuto();
                var camposDaStage = t.CamposDaTabela();
                return CamposDaTabela().Where(x => camposDaStage.Contains(x)).ToList();
            }
        }

    }
}
