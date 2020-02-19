using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acelera.Domain.Enums;

namespace Acelera.Domain.Entidades.Stages
{
    public class ClienteStage : LinhaTabela
    {
        public override TabelasEnum TabelaReferente => TabelasEnum.Cliente;

        protected override void CarregarCampos()
        {
            AddCampo("cd_registro");
            AddCampo("nm_arquivo_tpa");
            AddCampo("nm_tpa");
            AddCampo("cd_operacao");
            AddCampo("cd_versao_arquivo");
        }
    }
}
