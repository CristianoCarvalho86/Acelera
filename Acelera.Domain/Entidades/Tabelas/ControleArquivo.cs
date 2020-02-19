using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acelera.Domain.Enums;

namespace Acelera.Domain.Entidades.Tabelas
{
    public class ControleArquivo : LinhaTabela
    {
        public override TabelasEnum TabelaReferente => throw new NotImplementedException();

        protected override void CarregarCampos()
        {
            AddCampo("CD_ARQUIVO");
            AddCampo("NM_ARQUIVO_TPA");
            AddCampo("ST_STATUS");
            AddCampo("DS_ERRO");
            AddCampo("FL_ARQUIVO_RETORNO");
            AddCampo("QT_REGISTRO");
            AddCampo("QT_REGISTRO_CARGA");
            AddCampo("TP_ARQUIVO");
            AddCampo("CD_VERSAO_ARQUIVO");
            AddCampo("NM_TPA");
            AddCampo("CD_OPERACAO");
            AddCampo("DT_INCLUSAO");
            AddCampo("NM_USUARIO");
            
        }
    }
}
