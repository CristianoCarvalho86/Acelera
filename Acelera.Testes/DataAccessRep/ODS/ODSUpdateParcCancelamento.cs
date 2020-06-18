using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.DataAccessRep.ODS
{
    public static class ODSUpdateParcCancelamento
    {
        public static string UpdateText()
        {
            return $"update a "+
            " set a.DT_CANCELAMENTO = b.dt_emissao, " +
            " a.CD_PARCELA_CANCELAMENTO = b.cd_parcela, " +
            " a.CD_STATUS_PARCELA = 'CA' " +
            $" from {Parametros.instanciaDB}.tab_ods_parcela_2003 a " +
            " inner " +
            $" join (select id_transacao_canc, dt_emissao, cd_parcela from {Parametros.instanciaDB}.tab_ods_parcela_2003 " +
            " where id_transacao_canc is not null) b on " +
            " a.id_transacao = b.id_transacao_canc;" +
            " update a" +
            " set a.DT_CANCELAMENTO = b.dt_emissao," +
            " a.CD_PARCELA_CANCELAMENTO = b.cd_parcela," +
            " a.CD_STATUS_COMISSAO = 'CA'" +
            $" from {Parametros.instanciaDB}.TAB_ODS_COMISSAO_2006 a" +
            " inner" +
            " join (select A.CD_PARCELA,id_transacao_canc, dt_emissao" +
            $" from {Parametros.instanciaDB}.tab_ods_COMISSAO_2006 A" +
            $" INNER JOIN {Parametros.instanciaDB}.TAB_ODS_PARCELA_2003 B" +
            " ON A.CD_PARCELA = B.CD_PARCELA" +
            " WHERE id_transacao_canc IS NOT NULL) b on" +
            " a.CD_PARCELA = b.CD_PARCELA; ";
        }

        public static void Update(IMyLogger logger)
        {
            var sql = UpdateText();

            DataAccess.ExecutarComando(sql, DBEnum.Hana, logger);
        }
    }
}
