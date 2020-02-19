using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Stages;

namespace Acelera.Testes.TestesTipoArquivo
{
    public class TesteSinistro : TesteBase
    {
        public override LinhaTabela LinhaDeValidacao => new SinistroStage();
    }
}
