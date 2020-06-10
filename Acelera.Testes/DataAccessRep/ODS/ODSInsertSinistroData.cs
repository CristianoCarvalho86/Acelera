using Acelera.Domain.Entidades.SGS;
using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.DataAccessRep.ODS
{
    public class ODSInsertSinistroData
    {
        public static void Insert(string nomeArquivo, IMyLogger logger)
        {
            var sql = $"INSERT INTO {Parametros.instanciaDB}.TAB_ODS_SINISTRO_2007 " +
            " SELECT " +
            $" {Parametros.instanciaDB}.SEQ_ODS_SINISTRO_2007.NEXTVAL AS CD_AVISO_SINISTRO, " +
            " CD_PARCELA, " +
            " CD_PN_SEGURADORA, " +
            " CD_PN_TPA, " +
            " CD_PN_OPERACAO, " +
            " CD_AVISO, " +
            " CD_SINISTRO, " +
            " CD_CAUSA , " +
            " ID_COBERTURA, " +
            " DT_AVISO, " +
            " DT_OCORRENCIA, " +
            " DT_REGISTRO, " +
            " CD_GRUPO_RAMO, " +
            " A.NM_ARQUIVO_TPA, " +
            " CD_SEQ_ORIGEM, " +
            " 'N' AS FL_MIGRADO, " +
            " NOW() AS DT_INCLUSAO, " +
            " 'POC_SAC_20200520' AS NM_USUARIO, " +
            " 'I' AS TP_MUDANCA, " +
            " NOW() AS DT_MUDANCA " +
            $" FROM {Parametros.instanciaDB}.TAB_STG_SINISTRO_1006 A " +
            $" INNER JOIN {Parametros.instanciaDB}.TAB_ODS_PARCELA_2003 B " +
            " ON A.CD_CONTRATO = B.CD_CONTRATO " +
            " AND A.NR_SEQUENCIAL_EMISSAO = B.NR_SEQ_EMISSAO " +
            $" INNER JOIN {Parametros.instanciaDB}.TAB_PRM_COBERTURA_7007 COB " +
            "     ON A.CD_COBERTURA = COB.CD_COBERTURA " +
            "     AND A.CD_PRODUTO = COB.CD_PRODUTO " +
            "     AND A.CD_RAMO = COB.CD_RAMO_COBERTURA " +
            $" INNER JOIN {Parametros.instanciaDB}.TAB_PRM_RAMO_7002 RM " +
            " ON COB.CD_RAMO_COBERTURA = RM.CD_RAMO " +
            $" WHERE A.NM_ARQUIVO_TPA = '{nomeArquivo}' ";
            DataAccess.ExecutarComando(sql, DBEnum.Hana, logger);
        }
    }
}
