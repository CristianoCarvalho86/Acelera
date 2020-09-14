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
        public static string UpdateParcOdsText()
        {
            return $"update a" +
                    $" set a.DT_CANCELAMENTO = b.dt_emissao,a.CD_PARCELA_CANCELAMENTO = b.cd_parcela,a.CD_STATUS_PARCELA = 'CA'" +
                    $" from {Parametros.instanciaDB}.tab_ods_parcela_2003 a" +
                    $" inner " +
                    $" join {Parametros.instanciaDB}.TAB_ODS_COBERTURA_2005 c " +
                    $" on a.cd_parcela = c.cd_parcela" +
                    $" inner " +
                    $" join (select id_transacao_canc, dt_emissao, a1.cd_parcela from {Parametros.instanciaDB}.tab_ods_parcela_2003 a1 " +
                    $" inner join {Parametros.instanciaDB}.TAB_ODS_COBERTURA_2005 b1" +
                    $" on a1.cd_parcela = b1.cd_parcela" +
                    $" where id_transacao_canc is not null) b" +
                    $" on c.id_transacao = b.id_transacao_canc" +
                    $" and cd_status_parcela = 'EM'" +
                    $" and dt_cancelamento is null " +
                    $" and cd_parcela_cancelamento is null;";
        }

        public static string UpdateCmsOdsText()
        {                                                                                                                          
            return "update a "+
            $" set a.DT_CANCELAMENTO = b.dt_cancelamento, a.CD_PARCELA_CANCELAMENTO = b.cd_parcela, a.CD_STATUS_COMISSAO = 'CA'"+
            $" from {Parametros.instanciaDB}.TAB_ODS_COMISSAO_2006 a "+
            $" inner "+
            $" join (select b.CD_PARCELA, b.dt_cancelamento"+
            $" from {Parametros.instanciaDB}.tab_ods_COMISSAO_2006 A "+
            $" INNER JOIN {Parametros.instanciaDB}.TAB_ODS_PARCELA_2003 b"+
            $" ON A.CD_PARCELA = b.CD_PARCELA"+
            $" and b.cd_status_parcela = 'CA'"+
            $") b"+
            $" on a.CD_PARCELA = b.CD_PARCELA"+
            $" and cd_status_comissao = 'EM' ";                                                                                                
        }

        public static void Update(IMyLogger logger)
        {
            var sql = UpdateParcOdsText();

            DataAccess.ExecutarComando(sql, DBEnum.Hana, logger);

            sql = UpdateCmsOdsText();

            DataAccess.ExecutarComando(sql, DBEnum.Hana, logger);
        }
    }
}
