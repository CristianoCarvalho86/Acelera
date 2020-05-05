using Acelera.Domain.Entidades;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.DataAccessRep
{
    public class TabelaParametrosDataSP3 : TabelaParametrosData
    {
        private IMyLogger logger;
        public TabelaParametrosDataSP3(IMyLogger logger):base(logger)
        {

        }

        public string ObterCdClienteParceiro(bool existente)
        {
             return  ObterRetornoPadrao("CD_EXTERNO", "TAB_ODS_PARCEIRO_NEGOCIO_2000", existente , "CD_TIPO_PARCEIRO_NEGOCIO = 'CL'", true);
        }

        public IList<string> ObterAtributosDoLayout(TipoArquivo tipo, string layout)
        {
            var sql = $"select DISTINCT(NM_ATRIBUTO_LAYOUT) from TAB_PRM_LAYOUT_7016 where NM_TIPO_ARQUIVO = '{tipo.ObterTexto()}' AND CD_VERSAO_ARQUIVO = '{layout}' AND TP_REGISTRO = 3 AND ID_PRIMARY_KEY = '1'";
            return new List<string>();
        }

        public string ObterParceiroNegocioComEndereco(string tipoParceiro ,bool enderecoCompleto)
        {
            var sql = $" select TOP 1 CD_EXTERNO from {Parametros.instanciaDB}.TAB_ODS_PARCEIRO_NEGOCIO_2000 PN INNER JOIN " +
             $" {Parametros.instanciaDB}.TAB_ODS_ENDERECO_2001 E ON PN.CD_PARCEIRO_NEGOCIO = E.CD_PARCEIRO_NEGOCIO" +
             $" WHERE PN.CD_TIPO_PARCEIRO_NEGOCIO = '{tipoParceiro}'";
            if(enderecoCompleto)
                sql += $" PN.NR_CNPJ_CPF_RNE IS NOT NULL AND" +
                 $" E.EN_ENDERECO IS NOT NULL AND" +
                 $" E.EN_CIDADE IS NOT NULL AND" +
                 $" E.EN_UF IS NOT NULL AND" +
                 $" E.EN_CEP IS NOT NULL";
            else
                sql += $" PN.NR_CNPJ_CPF_RNE IS NULL OR" +
                 $" E.EN_ENDERECO IS  NULL OR" +
                 $" E.EN_CIDADE IS  NULL OR" +
                 $" E.EN_UF IS NULL OR" +
                 $" E.EN_CEP IS NULL ";

            return DataAccess.ConsultaUnica(sql);
        }

        public string ObterCoberturaValida(bool valida)
        {
            var clausula = "CAMPOS OBRIGATORIOS";
            return DataAccess.ConsultaUnica($"SELECT TOP 1 FROM {Parametros.instanciaDB}.TAB_PRM_COBERTURA_7007 where {clausula}");
        }

        //public string ObterIdTransacaoCanc(bool existente)
        //{
        //    var clausula = "SELECT ID_TRANSACAO_CANC"
        //}

    }
}
