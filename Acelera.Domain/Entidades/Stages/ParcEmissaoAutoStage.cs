using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acelera.Domain.Enums;

namespace Acelera.Domain.Entidades.Stages
{
    public class ParcEmissaoAutoStage : LinhaTabela
    {
        public override TiposArquivosEnum TipoArquivo => TiposArquivosEnum.ParcEmissaoAuto;

        protected override void CarregarCampos()
        {
            throw new NotImplementedException();
        }
    }
}
