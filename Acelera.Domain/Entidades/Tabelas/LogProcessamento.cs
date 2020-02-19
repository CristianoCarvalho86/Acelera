using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acelera.Domain.Enums;

namespace Acelera.Domain.Entidades.Tabelas
{
    public class LogProcessamento : LinhaTabela
    {
        public override TabelasEnum TabelaReferente => throw new NotImplementedException();

        protected override void CarregarCampos()
        {
            AddCampo("CD_PROCEDURE");
            AddCampo("CD_MENSAGEM");
            AddCampo("CD_ERRO_SQL");
            AddCampo("TX_MENSAGEM_ERRO_SQL");
            AddCampo("NM_ARQUIVO_TPA");
            AddCampo("CD_STATUS");
            AddCampo("CD_VERSAO_ARQUIVO");
            AddCampo("CD_PN_TPA");
            AddCampo("CD_PN_OPERACAO");
            AddCampo("DT_INCLUSAO");
            AddCampo("NM_USUARIO");
        }

        protected override string ObterClausulaConsulta()
        {
            throw new NotImplementedException();
        }
    }
}
