using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acelera.Domain.Enums;

namespace Acelera.Domain.Entidades.TabelaRetorno
{
    public class TabelaRetorno : LinhaTabela
    {
        public override TiposArquivosEnum TipoArquivo => TiposArquivosEnum.NaoSeAplica;

        protected override void CarregarCampos()
        {
            AddCampo();
        }
    }
}
