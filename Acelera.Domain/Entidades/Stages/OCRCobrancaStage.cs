using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acelera.Domain.Enums;

namespace Acelera.Domain.Entidades.Stages
{
    public class OCRCobrancaStage : LinhaTabela
    {
        public override TabelasEnum TabelaReferente => TabelasEnum.OCRCobranca;

        protected override void CarregarCampos()
        {
            throw new NotImplementedException();
        }
    }
}
