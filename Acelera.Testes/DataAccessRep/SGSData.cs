using Acelera.Domain.Entidades.SGS;
using Acelera.Domain.Enums;
using Acelera.Domain.Layouts;
using Acelera.Logger;
using Acelera.Utils;
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

        public bool ValidarCdContratoDisponivel()
        {
            var ControleArq
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

        public bool ValidaTabelasTemporariasSGS(string cdItem, string cdContrato, string nrSeqEmissao, string cdCliente,
            out MassaCliente_Sinistro massaClienteSGSEcontrado, out Massa_Sinistro_Parcela massaSinistroEncontrado)
        {
            massaClienteSGSEcontrado = null;
            massaSinistroEncontrado = null;

            logger.AbrirBloco("VERIFICAR REGISTROS NAS TABELAS TEMPORARIAS DO SGS.");

            var sql = $"{Massa_Sinistro_Parcela.ObterTextoSelect()} FROM {Massa_Sinistro_Parcela.NomeTabela} WHERE CD_ITEM = '{cdItem}' and CD_CONTRATO = '{cdContrato}' and NR_SEQUENCIAL_EMISSAO = '{nrSeqEmissao}'";
            var massaSinistroParcela = Massa_Sinistro_Parcela.CarregarEntidade(DataAccess.Consulta(sql, $"CARREGAR REGISTRO GRAVADO NA {Massa_Sinistro_Parcela.NomeTabela}", DBEnum.SqlServer, logger));

            sql = $"{MassaCliente_Sinistro.ObterTextoSelect()} FROM {MassaCliente_Sinistro.NomeTabela} WHERE CD_CLIENTE = '{cdCliente}'";
            var massaCliente = MassaCliente_Sinistro.CarregarEntidade(DataAccess.Consulta(sql, $"CARREGAR REGISTRO GRAVADO NA {MassaCliente_Sinistro.NomeTabela}", DBEnum.SqlServer, logger));

            if(!Assertions.ValidarRegistroUnicoNaLista(massaSinistroParcela, logger, Massa_Sinistro_Parcela.NomeTabela) ||
            !Assertions.ValidarRegistroUnicoNaLista(massaCliente, logger, MassaCliente_Sinistro.NomeTabela))
                return false;

            massaSinistroEncontrado = massaSinistroParcela.First();
            massaClienteSGSEcontrado = massaCliente.First();

            return true;

        }

        public ClienteSGS CarregarClienteSGS()
        {
            var sql = $" {ClienteSGS.ObterTextoSelect()} FROM {ClienteSGS.NomeTabela} WHERE ? ";
            return ClienteSGS.CarregarEntidade(DataAccess.Consulta(sql,"OBTER CLIENTES DA SGS", DBEnum.SqlServer, logger)).First();
        }

        public EnderecoSGS CarregarEnderecoSGS()
        {
            var sql = $" {EnderecoSGS.ObterTextoSelect()} FROM {EnderecoSGS.NomeTabela} WHERE ? ";
            return EnderecoSGS.CarregarEntidade(DataAccess.Consulta(sql, "OBTER ENDERECO DA SGS", DBEnum.SqlServer, logger)).First();
        }

        public PaisSGS CarregarPaisSGS()
        {
            var sql = $" {PaisSGS.ObterTextoSelect()} FROM {PaisSGS.NomeTabela} WHERE ? ";
            return PaisSGS.CarregarEntidade(DataAccess.Consulta(sql, "OBTER PAIS DA SGS", DBEnum.SqlServer, logger)).First();
        }


        public void ValidarStageCliente(MassaCliente_Sinistro massaCliente)
        {
            //FALTA COMPLETAR O WHERE DESSA QUERY
            var sql = $"SELECT '1' FROM TAB_STG_CLIENTE_1000 WHERE {massaCliente.ObterTextoWhere()} ";
            DataAccess.ConsultaUnica(sql);
        }

        public bool ValidarStageParcela(Massa_Sinistro_Parcela massaSinistro)
        {
            var sql = $"SELECT '1' FROM TAB_STG_PARCELA_1001 WHERE {massaSinistro.ObterTextoWhere()}";
            var resultado = DataAccess.ConsultaUnica(sql,false);
            return resultado == null ? 
        }

        public void ValidarStageParcelaAuto()
        {
            var sql = $"SELECT EN_PAIS, TP_PESSOA, DT_NASCIMENTO FROM TAB_STG_CLIENTE_1000 WHERE ";
            DataAccess.ConsultaUnica(sql);
        }

    }
}
