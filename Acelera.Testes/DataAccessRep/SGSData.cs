using Acelera.Domain.Entidades.SGS;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Utils;
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

        public bool ValidarCdContratoDisponivel(string cdContrato)
        {
            logger.AbrirBloco($"VALIDANDO SE O CD_CONTRATO '{cdContrato}' JÁ FOI USADO NOS NOSSOS TESTES.");
            var controle = ControleCDContratoFG03.Instancia;
            var retorno = controle.ValidaContrato(cdContrato);
            logger.Escrever($"CD_CONTRATO JÁ UTILIZADO : {!retorno}");
            logger.FecharBloco();
            return retorno;
        }

        public bool ValidarCdTpaNaParametroGlobal(string cdTpa)
        {
            logger.AbrirBloco($"VALIDAR SE OPERAÇÃO ESTÁ MARCADA COMO EXTRAÇÃO SGS. CD_TPA:'{cdTpa}'");
            var sql = $"SELECT DS_VALOR FROM {Parametros.instanciaDB}.TAB_PRM_PARAMETRO_GLOBAL_7023 WHERE NM_CAMPO = 'OPERACAO_SGS' AND DS_VALOR = '{cdTpa}'";
            var table = DataAccess.Consulta(sql, "OBTER OPERACAO_SGS PARA O CD_TPA", DBEnum.Hana, logger);
            if(table.Rows.Count == 0)
            {
                logger.Erro($"BUSCA NA TAB_PRM_PARAMETRO_GLOBAL_7023 NÃO ENCONTROU VALOR PARA ESTA OPERAÇÃO. CD_TPA:'{cdTpa}'");
                return false;
            }
            return true;
        }

        public bool ValidarRegistroNaoExisteNaODSParcela(string cdPnOperacao, string cdContrato, string nrSeqEmissao)
        {
            logger.AbrirBloco("VALIDANDO SE O REGISTRO NAO EXISTE NA ODS PARCELA.");
            var sql = $"Select '1' FROM {Parametros.instanciaDB}.TAB_ODS_PARCELA_2003 WHERE CD_PN_OPERACAO = '{cdPnOperacao}' and CD_CONTRATO = '{cdContrato}' and NR_SEQ_EMISSAO = '{nrSeqEmissao}'";
            var table = DataAccess.Consulta(sql, "VALIDAR QUE REGISTRO NAO EXISTE NA STAGE", DBEnum.Hana, logger);
            if (table.Rows.Count > 0)
            {
                logger.Erro($"REGISTRO EXISTENTE NA TABELA ODS PARCELA. CdPnOperacao:'{cdPnOperacao}'; CdContrato:'{cdContrato}'; NrSeqEmissao:'{nrSeqEmissao}' ");
                return false;
            }
            return true;
        }

        public bool ValidaTabelasTemporariasSGS(string cdItem, string cdContrato, string nrSeqEmissao, string cdCliente,
            out MassaCliente_Sinistro massaClienteSGSEcontrado, out Massa_Sinistro_Parcela massaSinistroEncontrado)
        {
            massaClienteSGSEcontrado = null;
            massaSinistroEncontrado = null;

            logger.AbrirBloco("VERIFICAR REGISTROS NAS TABELAS TEMPORARIAS DO SGS.");

            var sql = $"SELECT {Massa_Sinistro_Parcela.ObterTextoSelect()} FROM {Massa_Sinistro_Parcela.NomeTabela} WHERE CD_ITEM = '{cdItem}' and CD_CONTRATO = '{cdContrato}' and NR_SEQUENCIAL_EMISSAO = '{nrSeqEmissao}'";
            var massaSinistroParcela = Massa_Sinistro_Parcela.CarregarEntidade(DataAccess.Consulta(sql, $"CARREGAR REGISTRO GRAVADO NA {Massa_Sinistro_Parcela.NomeTabela}", DBEnum.SqlServer, logger));

            sql = $"SELECT {MassaCliente_Sinistro.ObterTextoSelect()} FROM {MassaCliente_Sinistro.NomeTabela} WHERE CD_CLIENTE = '{cdCliente}'";
            var massaCliente = MassaCliente_Sinistro.CarregarEntidade(DataAccess.Consulta(sql, $"CARREGAR REGISTRO GRAVADO NA {MassaCliente_Sinistro.NomeTabela}", DBEnum.SqlServer, logger));

            if(!Assertions.ValidarRegistroUnicoNaLista(massaSinistroParcela, logger, Massa_Sinistro_Parcela.NomeTabela) ||
            !Assertions.ValidarRegistroUnicoNaLista(massaCliente, logger, MassaCliente_Sinistro.NomeTabela))
                return false;

            massaSinistroEncontrado = massaSinistroParcela.First();
            massaClienteSGSEcontrado = massaCliente.First();

            return true;

        }

        public ClienteSGS CarregarClienteSGS(string cdCliente)
        {
            logger.AbrirBloco("CARREGAR CLIENTE DO BANCO SGS.");
            var sql = $"SELECT {ClienteSGS.ObterTextoSelect()} FROM {ClienteSGS.NomeTabela} WHERE CD_CLIENTE = '{cdCliente}' ";
            var clientes = ClienteSGS.CarregarEntidade(DataAccess.Consulta(sql,"OBTER CLIENTES DA SGS", DBEnum.SqlServer, logger));
            Assertions.ValidarRegistroUnicoNaLista(clientes, logger, "LISTA DE CLIENTES DA SGS", true);
            return clientes.First();
        }

        public IList<EnderecoSGS> CarregarEnderecoSGS(string cdCliente)
        {
            logger.AbrirBloco("CARREGAR CLIENTE DO BANCO SGS.");
            var sql = $"SELECT {EnderecoSGS.ObterTextoSelect()} FROM {EnderecoSGS.NomeTabela} WHERE COD_PESS = '{cdCliente}' ";
            var enderecos = EnderecoSGS.CarregarEntidade(DataAccess.Consulta(sql, $"OBTER ENDERECO DO CLIENTE '{cdCliente}' DA SGS.", DBEnum.SqlServer, logger));
            logger.Escrever($"ENDERECOS ENCONTRADOS para o CD_CLIENTE '{cdCliente}' : {enderecos.Count}");
            return enderecos;
        }

        public PaisSGS CarregarPaisSGS()
        {
            throw new NotImplementedException();
            var sql = $" {PaisSGS.ObterTextoSelect()} FROM {PaisSGS.NomeTabela} WHERE ? ";
            return PaisSGS.CarregarEntidade(DataAccess.Consulta(sql, "OBTER PAIS DA SGS", DBEnum.SqlServer, logger)).First();
        }


        public string ValidarStageCliente(MassaCliente_Sinistro massaCliente)
        {
            //FALTA COMPLETAR O WHERE DESSA QUERY
            var sql = $"SELECT CD_STATUS_PROCESSAMENTO FROM {Parametros.instanciaDB}.TAB_STG_CLIENTE_1000 WHERE {massaCliente.ObterTextoWhere()} ";
            var resultado = DataAccess.ConsultaUnica(sql, logger, false);
            if (resultado == null)
            {
                logger.Erro("REGISTRO NAO ENCONTRADO NA STAGE.");
                return string.Empty;
            }
            logger.Escrever($"CD_STATUS_PROCESSAMENTO ENCONTRADO NA STAGE : {resultado}");
            logger.FecharBloco();
            return resultado;
        }

        public string ValidarStageParcela(Massa_Sinistro_Parcela massaSinistro)
        {
            logger.AbrirBloco("VALIDAR TAB_STG_PARCELA_1001.");
            var sql = $"SELECT CD_STATUS_PROCESSAMENTO FROM {Parametros.instanciaDB}.TAB_STG_PARCELA_1001 WHERE {massaSinistro.ObterTextoWhere()}";
            var resultado = DataAccess.ConsultaUnica(sql,logger, false);
            if(resultado == null)
            {
                logger.Erro("REGISTRO NAO ENCONTRADO NA STAGE.");
                return string.Empty;
            }
            logger.Escrever($"CD_STATUS_PROCESSAMENTO ENCONTRADO NA STAGE : {resultado}");
            logger.FecharBloco();
            return resultado;
        }

        public string ValidarStageParcelaAuto(Massa_Sinistro_Parcela massaSinistro)
        {
            logger.AbrirBloco("VALIDAR TAB_STG_PARCELA_1001.");
            var sql = $"SELECT CD_STATUS_PROCESSAMENTO FROM {Parametros.instanciaDB}.TAB_ARQ_RETORNO_8002 WHERE {massaSinistro.ObterTextoWhere()}";
            var resultado = DataAccess.ConsultaUnica(sql, logger, false);
            if (resultado == null)
            {
                logger.Erro("REGISTRO NAO ENCONTRADO NA STAGE.");
                return string.Empty;
            }
            logger.Escrever($"CD_STATUS_PROCESSAMENTO ENCONTRADA NA STAGE : {resultado}");
            logger.FecharBloco();
            return resultado;
        }

        public void Executar()
        {
            logger.AbrirBloco("EXECUTAR PROC_MASP1602B00 NO SGS");
            var table = DataAccess.Consulta("EXEC PROC_MASP1602B00", "Executando proc_MASP1602B00", DBEnum.SqlServer, logger);
            logger.Escrever("RESULTADO DA EXECUÇÃO:" + Environment.NewLine);
            logger.Escrever(table.ObterTextoTabular());
            logger.FecharBloco();
        }

    }
}
