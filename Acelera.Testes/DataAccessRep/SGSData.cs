using Acelera.Domain.Entidades.SGS;
using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Utils;
using Acelera.Logger;
using Acelera.Utils;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void CarregarSinistroDoContrato(Arquivo arquivo, string cdContrato)
        {

        }

        public bool ValidarCdTpaNaParametroGlobal(string cdTpa, bool validaRegistroEncontrado)
        {
            logger.AbrirBloco($"VALIDAR SE OPERAÇÃO ESTÁ MARCADA COMO EXTRAÇÃO SGS. CD_TPA:'{cdTpa}'");
            var sql = $"SELECT DS_VALOR FROM {Parametros.instanciaDB}.TAB_PRM_PARAMETRO_GLOBAL_7023 WHERE NM_CAMPO = 'OPERACAO_SGS' AND DS_VALOR = '{int.Parse(cdTpa).ToString()}'";//Esse parse é para remover zeros a esquerda
            var table = DataAccess.Consulta(sql, "OBTER OPERACAO_SGS PARA O CD_TPA", DBEnum.Hana, logger,false);
            if(table.Rows.Count == 0 && validaRegistroEncontrado)
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
            var table = DataAccess.Consulta(sql, "VALIDAR QUE REGISTRO NAO EXISTE NA STAGE", DBEnum.Hana, logger,false);
            if (table.Rows.Count > 0)
            {
                logger.Erro($"REGISTRO EXISTENTE NA TABELA ODS PARCELA. CdPnOperacao:'{cdPnOperacao}'; CdContrato:'{cdContrato}'; NrSeqEmissao:'{nrSeqEmissao}' ");
                return false;
            }
            return true;
        }

        public void CarregaEntidadesDasTabelasTemporariasSGS(string cdContrato, string cdCliente,
            out IList<Massa_Cliente_Sinistro> massaClienteSGSEcontrado, out IList<Massa_Sinistro_Parcela> massaSinistroEncontrado)
        {
            massaClienteSGSEcontrado = null;
            massaSinistroEncontrado = null;

            var sql = $"SELECT {Massa_Sinistro_Parcela.ObterTextoSelect()} FROM {Massa_Sinistro_Parcela.NomeTabela} WHERE CD_CONTRATO = '{cdContrato}' ";
            var massaSinistroParcela = Massa_Sinistro_Parcela.CarregarEntidade(DataAccess.Consulta(sql, $"CARREGAR REGISTRO GRAVADO NA {Massa_Sinistro_Parcela.NomeTabela}", DBEnum.SqlServer, logger,false));

            sql = $"SELECT {Massa_Cliente_Sinistro.ObterTextoSelect()} FROM {Massa_Cliente_Sinistro.NomeTabela} WHERE CD_CLIENTE = '{cdCliente}'";
            var massaCliente = Massa_Cliente_Sinistro.CarregarEntidade(DataAccess.Consulta(sql, $"CARREGAR REGISTRO GRAVADO NA {Massa_Cliente_Sinistro.NomeTabela}", DBEnum.SqlServer, logger,false));

            massaSinistroEncontrado = massaSinistroParcela;
            massaClienteSGSEcontrado = massaCliente;

        }

        public void ValidarEntidadesDasTabelasTemporariasSGS(string cdContrato, string cdCliente, IList<Massa_Sinistro_Parcela> massaSinistroParcela)
        {
            logger.AbrirBloco("VALIDAR REGISTROS NAS TABELAS TEMPORARIAS DO SGS.");
            logger.Escrever($"CARREGANDO DADOS DO BANCO PARA O CONTRATO {cdContrato}");
            var sql = QueryMassaParcelaSGS.ObterTextoSelect() + $" WHERE CONTRATO.cod_ctrt = '{cdContrato}'";
            var registroParcelaEncontrado = QueryMassaParcelaSGS.CarregarEntidade(DataAccess.Consulta(sql, $"DADOS QUE PREENCHEM A {Massa_Sinistro_Parcela.NomeTabela}",logger));
            if (registroParcelaEncontrado.Count != massaSinistroParcela.Count)
                throw new Exception("Quantidade de registros encontrados diferentes dos registros na tabela temporaria.");


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


        public string ValidarStageCliente(Massa_Cliente_Sinistro massaCliente)
        {
            //FALTA COMPLETAR O WHERE DESSA QUERY
            var sql = $"SELECT CD_STATUS_PROCESSAMENTO, ID_REGISTRO FROM {Parametros.instanciaDB}.TAB_STG_CLIENTE_1000 WHERE " +
                $"{massaCliente.ObterTextoWhere(StageCliente.CamposDaTabela().Where(x => new string[]{ "DT_ARQUIVO","ID_REGISTRO", "CD_STATUS_PROCESSAMENTO"}.Contains(x) == false ).ToList())} ";
            var resultado = DataAccess.Consulta(sql, "REGISTRO NA STAGE COM OS PARAMETROS DA TEMPORARIA DO SGS", logger);
            if (resultado == null || resultado.Rows.Count == 0)
            {
                logger.Erro("REGISTRO NAO ENCONTRADO NA STAGE.");
                return string.Empty;
            }
            else if (resultado.Rows.Count > 1)
            {
                logger.Erro("MAIS DE UM REGISTRO ENCONTRADO NA STAGE.");
                return string.Empty;
            }
            massaCliente.CD_STATUS_PROCESSAMENTO = resultado.Rows[0]["CD_STATUS_PROCESSAMENTO"].ToString();
            massaCliente.ID_REGISTRO = resultado.Rows[0]["ID_REGISTRO"].ToString();
            logger.Escrever($"CD_STATUS_PROCESSAMENTO ENCONTRADO NA STAGE : {massaCliente.CD_STATUS_PROCESSAMENTO}");
            logger.FecharBloco();
            return massaCliente.CD_STATUS_PROCESSAMENTO;
        }

        public string[] ValidarStageClienteMultiplo(Massa_Cliente_Sinistro massaCliente)
        {
            //FALTA COMPLETAR O WHERE DESSA QUERY
            var sql = $"SELECT CD_STATUS_PROCESSAMENTO FROM {Parametros.instanciaDB}.TAB_STG_CLIENTE_1000 WHERE " +
                $"{massaCliente.ObterTextoWhere(StageCliente.CamposDaTabela().Where(x => new string[] { "DT_ARQUIVO", "ID_REGISTRO", "CD_STATUS_PROCESSAMENTO" }.Contains(x) == false).ToList())} ";
            var resultado = DataAccess.Consulta(sql," REGISTROS NA STAGE DE CLIENTE", DBEnum.Hana, logger, false);
            if (resultado.Rows.Count == 0)
            {
                logger.Erro("REGISTRO NAO ENCONTRADO NA STAGE.");
                return null;
            }
            else if (resultado.Rows.Count == 1)
            {
                logger.Erro("APENAS UM REGISTRO ENCONTRADO NA STAGE.");
                return null;
            }
            string[] array = new string[resultado.Rows.Count];
            for (int i = 0; i < resultado.Rows.Count; i++)
            {
                array[i] = resultado.Rows[i]["CD_STATUS_PROCESSAMENTO"].ToString();
            }
            logger.Escrever($"CD_STATUS_PROCESSAMENTO ENCONTRADO NA STAGE : {array.ObterListaConcatenada(" ,")}");
            logger.FecharBloco();
            return array;
        }

        public string[] ValidarStageParcelaAutoMultiplo(Massa_Sinistro_Parcela massaSinistro)
        {
            logger.AbrirBloco("VALIDAR TAB_STG_PARCELA_AUTO_1002.");
            var sql = $"SELECT CD_STATUS_PROCESSAMENTO FROM {Parametros.instanciaDB}.TAB_STG_PARCELA_AUTO_1002 WHERE " +
                $"{massaSinistro.ObterTextoWhere(StageParc.CamposDaTabela().Where(x => new string[] { "DT_ARQUIVO", "ID_REGISTRO", "CD_STATUS_PROCESSAMENTO" }.Contains(x) == false).ToList())} ";
            var resultado = DataAccess.Consulta(sql, " REGISTROS NA STAGE DE PARCELA AUTO", DBEnum.Hana, logger, false);
            if (resultado.Rows.Count == 0)
            {
                logger.Erro("REGISTRO NAO ENCONTRADO NA STAGE.");
                return null;
            }
            else if (resultado.Rows.Count == 1)
            {
                logger.Erro("APENAS UM REGISTRO ENCONTRADO NA STAGE.");
                return null;
            }
            string[] array = new string[resultado.Rows.Count];
            for (int i = 0; i < resultado.Rows.Count; i++)
            {
                array[i] = resultado.Rows[i]["CD_STATUS_PROCESSAMENTO"].ToString();
            }
            logger.Escrever($"CD_STATUS_PROCESSAMENTO ENCONTRADO NA STAGE : {array.ObterListaConcatenada(" ,")}");
            logger.FecharBloco();
            return array;
        }

        public string ValidarStageParcela(Massa_Sinistro_Parcela massaSinistro)
        {
            logger.AbrirBloco("VALIDAR TAB_STG_PARCELA_1001.");
            var sql = $"SELECT CD_STATUS_PROCESSAMENTO FROM {Parametros.instanciaDB}.TAB_STG_PARCELA_1001 WHERE " +
                $"{massaSinistro.ObterTextoWhere(StageParc.CamposDaTabela().Where(x => new string[] { "DT_ARQUIVO", "ID_REGISTRO", "CD_STATUS_PROCESSAMENTO" }.Contains(x) == false).ToList())} ";
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
            logger.AbrirBloco("VALIDAR TAB_STG_PARCELA_AUTO_1002.");
            var sql = $"SELECT CD_STATUS_PROCESSAMENTO, ID_REGISTRO FROM {Parametros.instanciaDB}.TAB_STG_PARCELA_AUTO_1002 WHERE " +
                $" {massaSinistro.ObterTextoWhere(StageParcAuto.CamposDaTabela().Where(x => new string[] { "DT_ARQUIVO", "ID_REGISTRO", "CD_STATUS_PROCESSAMENTO" }.Contains(x) == false).ToList())}";
            var resultado = DataAccess.Consulta(sql, "CONSULTA REGISTRO NA STAGE PARA TABELA TEMPORARIA SGS", logger);
            if (resultado == null || resultado.Rows.Count == 0)
            {
                logger.Erro("REGISTRO NAO ENCONTRADO NA STAGE.");
                return string.Empty;
            }
            else if (resultado.Rows.Count > 1)
            {
                logger.Erro("MAIS DE UM REGISTRO ENCONTRADO NA STAGE.");
                return string.Empty;
            }
            massaSinistro.CD_STATUS_PROCESSAMENTO = resultado.Rows[0]["CD_STATUS_PROCESSAMENTO"].ToString();
            massaSinistro.ID_REGISTRO = resultado.Rows[0]["ID_REGISTRO"].ToString();
            logger.Escrever($"CD_STATUS_PROCESSAMENTO ENCONTRADO NA STAGE : {massaSinistro.CD_STATUS_PROCESSAMENTO}");
            logger.FecharBloco();
            return massaSinistro.CD_STATUS_PROCESSAMENTO;
        }

        public void Executar()
        {
            logger.AbrirBloco("EXECUTAR PROC_MASP1602B00 NO SGS");
            var table = DataAccess.Consulta("EXEC PROC_MASP1602B00  @cd_ambiente = 'H'", "Executando proc_MASP1602B00", DBEnum.SqlServer, logger);
            logger.Escrever("RESULTADO DA EXECUÇÃO:" + Environment.NewLine);
            logger.Escrever(table.ObterTextoTabular());
            logger.FecharBloco();
        }

        public QueryContratoParaArquivo ObterCodigoContratoComUmaParcela()
        {
            logger.AbrirBloco("OBTENDO DADOS DE CONTRATO COM APENAS UMA PARCELA");
            var sql = "select top 1 PARCELA.cod_ctrt from ems_parcela PARCELA INNER JOIN ems_emissao EMISSAO ON PARCELA.cod_ctrt = EMISSAO.cod_ctrt " +
                       " where EMISSAO.cod_prod = '31501' or EMISSAO.cod_prod = '31522'  AND EMISSAO.num_apolice IS NOT NULL AND EMISSAO.num_endosso is not null " +
                       " group by PARCELA.cod_ctrt having count(cod_parc_prem) = 1  order by NEWID()";
            var codContrato = DataAccess.ConsultaUnica(sql,"BUSCANDO COD CONTRATO COM UMA PARCELA", DBEnum.SqlServer, logger);
            logger.Escrever($"CONTRATO SELECIONADO : {codContrato}");
            var resultado = DataAccess.Consulta($"{QueryContratoParaArquivo.ObterTextoSelect()} where CONTRATO.cod_ctrt = '{codContrato}'",
                $"CARREGANDO DADOS DO CONTRATO {codContrato}", DBEnum.SqlServer, logger);
            logger.FecharBloco();
            return QueryContratoParaArquivo.CarregarEntidade(resultado).First();
        }

        public QueryContratoParaArquivo ObterCodigoContratoComMultiplasParcelas()
        {
            logger.AbrirBloco("OBTENDO DADOS DE CONTRATO COM N PARCELAS");
            var sql = "select top 1 PARCELA.cod_ctrt from ems_parcela PARCELA INNER JOIN ems_emissao EMISSAO ON PARCELA.cod_ctrt = EMISSAO.cod_ctrt " +
                       " where EMISSAO.cod_prod = '31501' or EMISSAO.cod_prod = '31522'  AND EMISSAO.num_apolice IS NOT NULL AND EMISSAO.num_endosso is not null " +
                       " group by PARCELA.cod_ctrt having count(cod_parc_prem) > 1  order by NEWID()";
            var codContrato = DataAccess.ConsultaUnica(sql,"BUSCANDO COD CONTRATO COM MULTIPLAS PARCELAS", DBEnum.SqlServer, logger);
            logger.Escrever($"CONTRATO SELECIONADO : {codContrato}");
            var resultado = DataAccess.Consulta($"{QueryContratoParaArquivo.ObterTextoSelect().Replace("SELECT", "SELECT TOP 1 ")} where CONTRATO.cod_ctrt = '{codContrato}'",
                $"CARREGANDO DADOS DO CONTRATO {codContrato}", DBEnum.SqlServer, logger);
            logger.FecharBloco();
            return QueryContratoParaArquivo.CarregarEntidade(resultado).First();
        }

        public IList<QueryContratoParaArquivo> ObterContratosDoCliente(string cdCliente)
        {
            logger.AbrirBloco($"OBTENDO DADOS DE CONTRATO PARA COD_CLIENTE : {cdCliente}");
            var resultado = DataAccess.Consulta($"{QueryContratoParaArquivo.ObterTextoSelect()} where CONTRATO.cod_pess = '{cdCliente}'",
            $"CARREGANDO DADOS DO CONTRATO PARA O CLIENTE: {cdCliente}", DBEnum.SqlServer, logger);
            logger.FecharBloco();
            return QueryContratoParaArquivo.CarregarEntidade(resultado);
        }

        public QueryContratoParaArquivo ObterContratoCancelado()
        {
            //dividir em 2 queries
            logger.AbrirBloco($"OBTENDO DADOS DE CONTRATO CANCELADO");
            var codContrato = DataAccess.ConsultaUnica("SELECT TOP 1 cod_ctrt from ems_emissao where tip_emis = '10' or tip_emis = '11'  and (cod_prod = '31501' or cod_prod = '31522' ) " +
                " AND num_apolice IS NOT NULL AND num_endosso is not null order by NEWID() ", "OBTER CONTRATO CANCELADO", DBEnum.SqlServer, logger);
            var resultado = DataAccess.Consulta($"{QueryContratoParaArquivo.ObterTextoSelect().Replace("SELECT", "SELECT TOP 1 ")} where CONTRATO.cod_ctrt = '{codContrato}'",
            $"CARREGANDO DADOS DE CONTRATO CANCELADO", DBEnum.SqlServer, logger);
            logger.FecharBloco();
            return QueryContratoParaArquivo.CarregarEntidade(resultado).First();
        }

        public QueryContratoParaArquivo ObterContratoComCodMovimentacaoUm()
        {
            //dividir em 2 queries
            logger.AbrirBloco($"OBTENDO DADOS DE CONTRATO CANCELADO");
            var codContrato = DataAccess.ConsultaUnica("SELECT TOP 1 cod_ctrt from ems_emissao where tip_emis = '10' or tip_emis = '11'  and (cod_prod = '31501' or cod_prod = '31522' ) " +
                " AND num_apolice IS NOT NULL AND num_endosso is not null order by NEWID() ", "OBTER CONTRATO CANCELADO", DBEnum.SqlServer, logger);
            var resultado = DataAccess.Consulta($"{QueryContratoParaArquivo.ObterTextoSelect().Replace("SELECT", "SELECT TOP 1 ")} where CONTRATO.cod_ctrt = '{codContrato}'",
            $"CARREGANDO DADOS DE CONTRATO CANCELADO", DBEnum.SqlServer, logger);
            logger.FecharBloco();
            return QueryContratoParaArquivo.CarregarEntidade(resultado).First();
        }

        public QueryContratoParaArquivo ObterContratoValido()
        {
            //dividir em 2 queries
            logger.AbrirBloco($"OBTENDO DADOS DE CONTRATO CANCELADO");
            var codContrato = DataAccess.ConsultaUnica("SELECT TOP 1 cod_ctrt from ems_emissao where (cod_prod = '31501' or cod_prod = '31522' ) " +
                " AND num_apolice IS NOT NULL AND num_endosso is not null order by NEWID() ", "OBTER CONTRATO CANCELADO", DBEnum.SqlServer, logger);
            var resultado = DataAccess.Consulta($"{QueryContratoParaArquivo.ObterTextoSelect().Replace("SELECT", "SELECT TOP 1 ")} where CONTRATO.cod_ctrt = '{codContrato}'",
            $"CARREGANDO DADOS DE CONTRATO CANCELADO", DBEnum.SqlServer, logger);
            logger.FecharBloco();
            return QueryContratoParaArquivo.CarregarEntidade(resultado).First();
        }

        public QueryContratoParaArquivo ObterContratoPeloCodigo(string codContrato)
        {
            logger.AbrirBloco($"OBTENDO DADOS DE CONTRATO PARA O COD_CONTRATO : {codContrato}");
            var resultado = DataAccess.Consulta($"{QueryContratoParaArquivo.ObterTextoSelect()} where CONTRATO.cod_ctrt = '{codContrato}'",
            $"CARREGANDO DADOS DO CONTRATO PARA O COD_CONTRATO: {codContrato}", DBEnum.SqlServer, logger);
            logger.FecharBloco();
            return QueryContratoParaArquivo.CarregarEntidade(resultado).First();
        }

        public string ObterClienteComMultiplosContratos()
        {
            logger.AbrirBloco("OBTENDO CLIENTE COM MULTIPLOS CONTRATOS");

            var sql = "select top 1 CONTRATO.cod_pess from ems_contrato CONTRATO INNER JOIN ems_emissao EMISSAO ON CONTRATO.cod_ctrt = EMISSAO.cod_ctrt "+
                        " where EMISSAO.cod_prod = '31501' or EMISSAO.cod_prod = '31522' "+
                        " group by cod_pess having count(cod_pess) > 1 order by NEWID()";
            var codCliente = DataAccess.ConsultaUnica(sql,"BUSCANDO CLIENTE QUE CONSTA EM VARIOS CONTRATOS",DBEnum.SqlServer,logger);
            logger.Escrever($"CLIENTE SELECIONADO : {codCliente}");
            return codCliente;
        }

        public string ObterClienteComUnicoContrato()
        {
            logger.AbrirBloco("OBTENDO CLIENTE COM APENAS UM CONTRATO");
            var sql = "select top 1 CONTRATO.cod_pess from ems_contrato CONTRATO INNER JOIN ems_emissao EMISSAO ON CONTRATO.cod_ctrt = EMISSAO.cod_ctrt " +
            " where EMISSAO.cod_prod = '31501' or EMISSAO.cod_prod = '31522' " +
            " group by cod_pess having count(cod_pess) = 1 order by NEWID()";
            var codCliente = DataAccess.ConsultaUnica(sql,"BUSCANDO CLIENTE QUE CONSTA EM UM UNICO CONTRATO",DBEnum.SqlServer, logger);
            logger.Escrever($"CLIENTE SELECIONADO : {codCliente}");
            return codCliente;
        }


        public bool ValidaExistenciaCDContrato(string CdContrato)
        {
            logger.AbrirBloco($"VALIDANDO SE CD_CONTRATO '{CdContrato}' NAO EXISTE NO SGS.");
            var resultado = DataAccess.ConsultaUnica($"SELECT TOP 1 cod_ctrt from ems_contrato where cod_ctrt = '{CdContrato}'", DBEnum.SqlServer, false);
            return resultado != null ? true : false;
        }


    }
}
