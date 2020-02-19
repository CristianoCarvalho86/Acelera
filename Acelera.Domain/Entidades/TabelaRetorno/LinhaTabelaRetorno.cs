using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acelera.Domain.Enums;

namespace Acelera.Domain.Entidades.TabelaRetorno
{
    public class LinhaTabelaRetorno : LinhaTabela
    {
        public override TabelasEnum TabelaReferente => TabelasEnum.TabelaRetorno;

        protected override void CarregarCampos()
        {
            AddCampo("cd_registro");
            AddCampo("nm_arquivo_tpa");
            AddCampo("nm_tpa");
            AddCampo("cd_operacao");
            AddCampo("cd_versao_arquivo");
            AddCampo("cd_mensagem");
            AddCampo("ds_mensagem");
            AddCampo("dt_inclusao");
            AddCampo("tp_registro");
            AddCampo("cd_cliente");
            AddCampo("nr_apolice");
            AddCampo("nr_endosso");
            AddCampo("nr_parcela");
            AddCampo("nr_sequencial_emissao");
            AddCampo("cd_corretor");
            AddCampo("cd_sinistro");
            AddCampo("cd_movimento");
            AddCampo("tp_mensagem");
            AddCampo("nm_usuario");
            AddCampo("nm_campo_erro");
            AddCampo("dt_geracao_arquivo");
            AddCampo("cd_origem_msg");
            AddCampo("fl_status_envio");
            
        }
    }
}
