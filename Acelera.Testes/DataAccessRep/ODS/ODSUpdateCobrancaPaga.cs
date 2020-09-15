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
    public static class ODSUpdateCobrancaPaga
    {
        public static string UpdateText(string nomeArquivo)
        {
            return $"update  a " +
            $" set cd_status_parcela = 'PG'," +
            $" dt_pagamento = dt_ocorrencia," +
            $" VL_PREMIO_PAGO = B.VL_PREMIO_PAGO, " +
            $" VL_DESCONTO_PAGO = B.VL_DESCONTO_PAGO, " +
            $" VL_MULTA_PAGO = B.VL_MULTA_PAGO, " +
            $" VL_ADIC_FRACIONAMENTO_PAGO = B.VL_ADIC_FRACIONAMENTO_PAGO" +
            $" from {Parametros.instanciaDB}.tab_ods_parcela_2003 a " +
            $" inner join (select bp.id_registro, " +
            $" op.cd_parcela, " +
            $" bp.dt_ocorrencia, " +
            $" bp.VL_PREMIO_PAGO, " +
            $" bp.VL_DESCONTO AS VL_DESCONTO_PAGO, " +
            $" bp.VL_MULTA AS VL_MULTA_PAGO," +
            $" bp.VL_ADC_FRC AS VL_ADIC_FRACIONAMENTO_PAGO" +
            $" from {Parametros.instanciaDB}.tab_stg_baixa_parcela_1004 bp" +
            $" inner join {Parametros.instanciaDB}.tab_ods_parcela_2003 op" +
            $" on bp.cd_contrato = op.cd_contrato and" +
            $" bp.nr_sequencial_emissao = op.nr_seq_emissao" +
            $" and bp.nr_parcela = op.nr_parcela" +
            $" AND cd_status_parcela<> 'CA'" +
            $" WHERE bp.NM_ARQUIVO_TPA IN('{nomeArquivo}')) b " +
            $" on a.cd_parcela = b.cd_parcela ";
        }

        public static void Update(string nomeArquivo, IMyLogger logger)
        {
            var sql = UpdateText(nomeArquivo);

            DataAccess.ExecutarComando(sql, DBEnum.Hana, logger);
        }

        public static bool ValidaApolicePaga(string cdContrato, IMyLogger logger)
        {
            return DataAccess.ExisteRegistro($"SELECT '1' FROM {Parametros.instanciaDB}.{TabelasEnum.OdsParcela.ObterTexto()} where NR_APOLICE = '{cdContrato}'" +
                $" AND cd_status_parcela = 'PG' AND DT_PAGAMENTO IS NOT NULL ", logger);
        }
    }
}
