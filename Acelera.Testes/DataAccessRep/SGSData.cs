using Acelera.Domain.Entidades.SGS;
using Acelera.Domain.Enums;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.DataAccessRep
{
    public class SGSData
    {
        protected IMyLogger logger { get; private set; }
        public SGSData(IMyLogger logger)
        {
            this.logger = logger;
        }

        public string ObterCdContratoDisponivel()
        {
            throw new NotImplementedException();
        }

        public bool ValidarCdTpaNaParametroGlobal(string cdTpa)
        {
            var sql = $"SELECT DS_VALOR FROM {Parametros.instanciaDB}.TAB_PRM_PARAMETRO_GLOBAL_7023 WHERE NM_CAMPO = 'OPERACAO_SGS' AND DS_VALOR = '{cdTpa}'";
            var table = DataAccess.Consulta(sql, "OBTER OPERACAO_SGS PARA O CD_TPA", DBEnum.Hana, logger);
            return table.Rows.Count == 0 ? false : true;
        }

        public bool ValidarRegistroNaoExisteNaODSParcela(string cdPnOperacao, string cdContrato, string nrSeqEmissao)
        {
            var sql = $"Select '1' FROM {Parametros.instanciaDB}.TAB_ODS_PARCELA_2003 WHERE CD_PN_OPERACAO = '{cdPnOperacao}' and CD_CONTRATO = '{cdContrato}' and NR_SEQ_EMISSAO = '{nrSeqEmissao}'";
            var table = DataAccess.Consulta(sql, "VALIDAR QUE REGISTRO NAO EXISTE NA STAGE", DBEnum.Hana, logger);
            return table.Rows.Count == 0 ? true : false;
        }

        public bool ValidaTabelasTemporariasSGS()
        {
            throw new NotImplementedException();
        }

        public ClienteSGS CarregarClienteSGS()
        {
            var sql = $" SELECT TIP_PESS, DTA_NASC FROM CLI_PESSOA WHERE ? ";
            throw new NotImplementedException();
        }

        
        public bool ValidarStageCliente(ClienteSGS cliente)
        {
            //FALTA COMPLETAR O WHERE DESSA QUERY
            var sql = $"SELECT EN_PAIS, TP_PESSOA, DT_NASCIMENTO FROM TAB_STG_CLIENTE_1000 WHERE EN_PAIS = '{cliente.NM_PAIS}', TP_PESSOA = '{cliente.TIP_PESS}'";
            throw new NotImplementedException();
        }

        public bool ValidarStageParcela()
        {
            var sql = $"SELECT EN_PAIS, TP_PESSOA, DT_NASCIMENTO FROM TAB_STG_CLIENTE_1000 WHERE ";
            throw new NotImplementedException();
        }

    }
}
