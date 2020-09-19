using Acelera.Domain;
using Acelera.Domain.DataAccess;
using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.RegrasNegocio
{
    public class DadosParametrosData
    {
        protected IMyLogger logger { get; private set; }
        public DadosParametrosData(IMyLogger logger)
        {
            this.logger = logger;
        }

        protected string ObterNaoExistenteNaTabela(string campo, string tabela, int valorMaximo)
        {
            var retorno = "";
            while (string.IsNullOrEmpty(retorno))
            {
                var random = new Random(DateTime.Now.Millisecond);
                var sql = $"SELECT ('{random.Next(0, valorMaximo)}') AS A FROM DUMMY"
                          + $" EXCEPT " 
                          + $" SELECT {campo} FROM {Parametros.instanciaDB}.{tabela} ";
                retorno = DataAccess.ConsultaUnica(sql,false);
            }
            return retorno;
        }

        protected string ObterRetornoPadrao(string campo, string tabela, bool existente, string clausula = "", bool convertToInt = false)
        {
            string select = string.Empty;
            if (existente)
            {
                clausula = clausula == string.Empty ? "" : " WHERE " + clausula;
                select = $"select top 1 {campo} from {Parametros.instanciaDB}.{tabela} {clausula}";
            }
            else
            {
                clausula = clausula == string.Empty ? "" : " AND " + clausula;
                var busca = convertToInt ? $"TO_INT({campo})" : campo;
                select = $"select (MAX({busca}) + 1) as {campo} from {Parametros.instanciaDB}.{tabela} where length(ltrim({campo},'+-.0123456789')) = 0 {clausula}";
            }
            return DataAccess.ConsultaUnica(select, campo, logger);
        }

        protected string ObterRetornoParaDiferente(string campoBusca, string campoComparacao, string valor, string tabela)
        {
            return ObterRetorno(campoBusca,campoComparacao,valor,tabela, false);
        }

        protected string ObterRetorno(string campoBusca, string campoComparacao, string valor, string tabela, bool igual, string clausula = "")
        {
            clausula = clausula == "" ? "" : " AND " + clausula; 
            var operador = igual ? "=" : "<>";
            var texto = igual ? "IGUAL A " : " DIFERENTE DE ";
            var select = $"select top 1 {campoBusca} from {Parametros.instanciaDB}.{tabela} where {campoComparacao} {operador} '{valor}' {clausula}";


            return DataAccess.ConsultaUnica(select, campoComparacao + texto + valor, logger);
        }

        public string ObterCDMoeda(bool existente)
        {
           return ObterRetornoPadrao("CD_MOEDA", "TAB_PRM_MOEDA_7030", existente);
        }

        private string ObterRetornoNotIn(string campoBusca, string campoComparacao, string valor, string tabela,string clausula = "", string clausulaDoNotIn = "")
        {
            clausula = clausula == "" ? "" : " AND " + clausula;
            clausulaDoNotIn = clausulaDoNotIn == "" ? "" : " AND " + clausulaDoNotIn;
            var select = $"select top 1 {campoBusca} from {Parametros.instanciaDB}.{tabela} WHERE {campoBusca} NOT IN" +
                $" (select {campoBusca} from {Parametros.instanciaDB}.{tabela} WHERE {campoComparacao} = '{valor}' {clausulaDoNotIn} ) {clausula}";


            return DataAccess.ConsultaUnica(select, $"{campoBusca} nao Ligada ao {campoComparacao} de valor: {valor} ", logger);
        }

        /// <summary>
        /// Nao esquecer de loggar 
        /// </summary>
        /// <returns></returns>
        public string ObterCDContratoDaStage(bool existente)
        {
            throw new Exception();
        }


        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterCDFormaPagamento(bool valido)
        {
            //TAB_PRM_FORMA_PAGTO_7015
            return ObterRetornoPadrao("CD_FORMA_PAGTO", "TAB_PRM_FORMA_PAGTO_7015", valido);
        }

        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterRamo(bool existente)
        {
            return ObterRetornoPadrao("CD_RAMO", "TAB_PRM_RAMO_7002", existente);
        }

        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterProduto(bool existente)
        {
            return ObterRetornoPadrao("CD_PRODUTO", "TAB_PRM_PRODUTO_7003", existente);
        }

        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterCDCobertura(bool existente)
        {
            return ObterRetornoPadrao("CD_COBERTURA", "TAB_PRM_COBERTURA_7007", existente);
        }

        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterCDBancoSeg(bool existente)
        {
            return ObterRetornoPadrao("CD_BANCO", "TAB_PRM_BANCO_7033", existente); 
        }

        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterOperacao(string produto, bool existente)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// select now() from dummy
        /// </summary>
        /// <returns></returns>
        public string ObterDataDoBanco()
        {
            return Convert.ToDateTime(DataAccess.ConsultaUnica("select now() from dummy", "DATA DO BANCO", logger)).ToString("yyyyMMdd");
        }



        /// <summary>
        /// CD_SEGURADORA
        /// </summary>
        /// <returns></returns>
        public string ObterParceiroNegocio(string valorCdTipoParceiroNegocio, bool igual)
        {
            return ObterRetorno("CD_EXTERNO", "CD_TIPO_PARCEIRO_NEGOCIO", valorCdTipoParceiroNegocio, "TAB_ODS_PARCEIRO_NEGOCIO_2000", igual);
        }

        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterCDFranquia(bool existente)
        {
            if(existente)
            return ObterRetornoPadrao("CD_FRANQUIA", "TAB_PRM_FRANQUIA_7010", existente);
            return "13";
        }

        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterCDOcorrencia(bool existente)
        {
            return ObterRetornoPadrao("CD_OCORRENCIA", "TAB_PRM_TIPO_OCORRENCIA_7035", existente);
        }



        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterSucursal(bool existente)
        {
            if(existente)
            return ObterParceiroNegocio("SU", true);
            return "03";
        }

        public string ObterMovimentoCobranca(bool existente)
        {
            return ObterRetornoPadrao("CD_MOVTO_COBRANCA", "TAB_PRM_MOVTO_COBRANCA_7025", existente);
        }
        
        public string ObterTipoMovimento(bool existente)
        {
            return ObterRetornoPadrao("CD_TIPO_MOVIMENTO", "TAB_PRM_TIPO_MOVIMENTO_7024", existente);
        }

        public string ObterCDTipoEmissao(string acao, bool ComCritica)
        {
            //CD_TIPO_MOVIMENTO É IGUAL A TIPO EMISSAO
            string select = string.Empty;
            var operador = ComCritica ? " = " : " <> ";
                select = $"select top 1 CD_TIPO_MOVIMENTO from {Parametros.instanciaDB}.TAB_PRM_TIPO_MOVIMENTO_7024 where TP_ACAO {operador} '{acao}'";


            return DataAccess.ConsultaUnica(select, "CD_TIPO_MOVIMENTO", logger);
        }

        public string ObterCdTipoEmissao(TipoArquivo tipoArquivo, bool existente)
        {
            List<string> lista = new List<string>();
            if (tipoArquivo == TipoArquivo.ParcEmissao)
            {
                lista.Add("18");
                lista.Add("20");
            }
            else if(tipoArquivo == TipoArquivo.ParcEmissaoAuto)
            {
                lista.Add("5");
                lista.Add("6");
                lista.Add("8");
                lista.Add("9");
                lista.Add("12");
                lista.Add("13");
                lista.Add("19");
                lista.Add("21");
            }
            else { throw new Exception("ESSE TIPO ARQUIVO NAO CONTEM CDTIPOEMISSAO"); }
            lista.Add("1");
            lista.Add("7");
            lista.Add("10");
            lista.Add("11");

            if (existente)
                return lista[new Random(DateTime.Now.Millisecond).Next(0, lista.Count - 1)];
            else
                return (lista.Select(x => int.Parse(x)).Max() + 1).ToString();
        }
        
        public string ObterRamoDiferente(string ramo)
        {
            return ObterRetornoParaDiferente("CD_RAMO", "CD_RAMO", ramo, "TAB_PRM_RAMO_7002");
        }

        public string ObterProdutoDiferente(string produto)
        {
            return ObterRetornoParaDiferente("CD_PRODUTO", "CD_PRODUTO", produto, "TAB_PRM_PRODUTO_7003");
        }

        public string ObterCoberturaNaoRelacionadaAProduto(string cd_produto)
        {
            return ObterRetornoNotIn("CD_COBERTURA", "CD_PRODUTO", cd_produto, "TAB_PRM_COBERTURA_7007");
        }

        public string ObterProdutoNaoRelacionadoACobertura(string cd_cobertura)
        {
            return ObterRetornoNotIn("CD_PRODUTO", "CD_COBERTURA", cd_cobertura, "TAB_PRM_COBERTURA_7007");
        }

        public string ObterRamoNaoRelacionadoACobertura(string cd_cobertura)
        {
            var select = $"SELECT TOP 1 R.CD_RAMO FROM {Parametros.instanciaDB}.TAB_PRM_RAMO_7002 R "+
            $"WHERE R.CD_RAMO NOT IN( "+
            $"select P.CD_RAMO from {Parametros.instanciaDB}.TAB_PRM_COBERTURA_7007 C " +
            $"INNER JOIN {Parametros.instanciaDB}.TAB_PRM_PRODUTO_7003 P ON C.CD_PRODUTO = P.CD_PRODUTO " +
            $"WHERE C.CD_COBERTURA = '{cd_cobertura}')";
            return DataAccess.ConsultaUnica(select);
        }

        public string ObterRamoRelacionadoACoberturaDiferenteDe(string cd_cobertura, string cdRamo, out string cdProduto)
        {
            var select = $"SELECT TOP 1 C.CD_RAMO_COBERTURA, P.CD_PRODUTO FROM {Parametros.instanciaDB}.TAB_PRM_PRODUTO_7003 P " +
            $" INNER JOIN {Parametros.instanciaDB}.TAB_PRM_COBERTURA_7007 C ON C.CD_PRODUTO = P.CD_PRODUTO " +
            $" WHERE C.CD_COBERTURA = '{cd_cobertura}' AND C.CD_RAMO_COBERTURA <> '{cdRamo}' ";
            var table = DataAccess.Consulta(select,$"RAMO DIFERENTE DE {cdRamo} E ASSOCIADO A COBERTURA : {cd_cobertura}",logger);
            cdProduto = table.Rows[0]["CD_PRODUTO"].ToString();
            return table.Rows[0]["CD_RAMO_COBERTURA"].ToString();
            
        }

        public string ObterCDTipoMovimentoParaAtuacao(string atuacao, bool relacionado)
        {
            if(relacionado)
                return ObterRetorno("CD_TIPO_MOVIMENTO", "CD_ATUACAO", atuacao, "TAB_PRM_TIPO_MOVIMENTO_7024", true);
            return ObterRetornoNotIn("CD_TIPO_MOVIMENTO", "CD_ATUACAO", atuacao, "TAB_PRM_TIPO_MOVIMENTO_7024");
        }

        public string ObterCDSusepDoCorretor(string cdCorretor)
        {
                return ObterRetorno("CD_SUSEP", "CD_EXTERNO", cdCorretor, "TAB_ODS_PARCEIRO_NEGOCIO_2000", true, " CD_TIPO_PARCEIRO_NEGOCIO = 'CO' ");
        }

        public string ObterCPFDoCorretor(string cdCorretor)
        {
            return ObterRetorno("NR_CNPJ_CPF_RNE", "CD_EXTERNO", cdCorretor, "TAB_ODS_PARCEIRO_NEGOCIO_2000", true, " CD_TIPO_PARCEIRO_NEGOCIO = 'CO' ");
        }

        public string ObterCdCorretorParaTipoRemuneracao(string cdTpa ,string cdTipoRemuneracao, bool relacionado, string[] diferenteDeCdCorretor = null)
        {
            var pnOperacaoDoTpa = ObterCdParceiroNegocioParaTPA(cdTpa);

            var clausula = diferenteDeCdCorretor == null ? $""  
                : diferenteDeCdCorretor.Select(x => $" C.CD_PN_CORRETOR <> '{x}'").ToList().ObterListaConcatenada(" AND ") + " AND ";

            var controle = relacionado ? "top 1" : "";
            var sql = $"select {controle} PN.CD_EXTERNO from {Parametros.instanciaDB}.TAB_PRM_REMUNERACAO_7013 C " +
                      $" INNER JOIN {Parametros.instanciaDB}.TAB_ODS_PARCEIRO_NEGOCIO_2000 PN ON C.CD_PN_CORRETOR = PN.CD_PARCEIRO_NEGOCIO " +
                      $" where {clausula} C.CD_TIPO_REMUNERACAO = '{cdTipoRemuneracao}'  AND C.CD_PN_OPERACAO = '{pnOperacaoDoTpa}' AND PN.CD_TIPO_PARCEIRO_NEGOCIO = 'CO' ";


            if (!relacionado)
                sql = $" select top 1 PN.CD_EXTERNO " +
                $" from {Parametros.instanciaDB}.TAB_PRM_REMUNERACAO_7013 C " +
                $" INNER JOIN {Parametros.instanciaDB}.TAB_ODS_PARCEIRO_NEGOCIO_2000 PN ON C.CD_PN_CORRETOR = PN.CD_PARCEIRO_NEGOCIO " +
                $" WHERE {clausula} PN.CD_EXTERNO NOT IN({sql})" +
                $" AND C.CD_PN_OPERACAO = '{pnOperacaoDoTpa}' AND C.CD_TIPO_REMUNERACAO <> '{cdTipoRemuneracao}' AND PN.CD_TIPO_PARCEIRO_NEGOCIO = 'CO' ";

            var operador = relacionado ? "=" : "<>";
            return DataAccess.ConsultaUnica(sql,$"CD_TIPO_REMUNERACAO {operador} '{cdTipoRemuneracao}'",logger);
        }

        public string ObterTipoRemuneracaoDoCorretor(string cdCorretor, string cdCobertura, string cdProduto)
        {
            var sql = $"select TOP 1 C.CD_TIPO_REMUNERACAO from {Parametros.instanciaDB}.TAB_PRM_REMUNERACAO_7013 C " +
                      $" INNER JOIN {Parametros.instanciaDB}.TAB_ODS_PARCEIRO_NEGOCIO_2000 PN ON C.CD_PN_CORRETOR = PN.CD_PARCEIRO_NEGOCIO " +
                      $" where PN.CD_EXTERNO = '{cdCorretor}' AND PN.CD_TIPO_PARCEIRO_NEGOCIO = 'CO' AND C.CD_COBERTURA = '{cdCobertura}' AND C.CD_PRODUTO = '{cdProduto}'";

            return DataAccess.ConsultaUnica(sql, $"CD_TIPO_REMUNERACAO DO CORRETOR = {cdCorretor}", logger);
        }

        public string ObterCdCorretorParaTipoRemuneracaoECobertura(string cdTpa, string cdTipoRemuneracao, string cdCobertura)
        {
            var pnOperacaoDoTpa = ObterCdParceiroNegocioParaTPA(cdTpa);

            var sql = $"select top 1 PN.CD_EXTERNO from {Parametros.instanciaDB}.TAB_PRM_REMUNERACAO_7013 C " +
                      $" INNER JOIN {Parametros.instanciaDB}.TAB_ODS_PARCEIRO_NEGOCIO_2000 PN ON C.CD_PN_CORRETOR = PN.CD_PARCEIRO_NEGOCIO " +
                      $" where C.CD_TIPO_REMUNERACAO = '{cdTipoRemuneracao}'  AND C.CD_PN_OPERACAO = '{pnOperacaoDoTpa}' AND C.CD_COBERTURA = '{cdCobertura}'" +
                      $" AND PN.CD_TIPO_PARCEIRO_NEGOCIO = 'CO' ";

            return DataAccess.ConsultaUnica(sql, $"CD_TIPO_REMUNERACAO = '{cdTipoRemuneracao}' E CD_COBERTURA = '{cdCobertura}'", logger);
        }

        public string ObterCdParceiroNegocioParaTPA(string cdTpa)
        {
            return ObterRetorno("CD_PARCEIRO_NEGOCIO", "CD_EXTERNO", cdTpa, "TAB_ODS_PARCEIRO_NEGOCIO_2000", true, "CD_TIPO_PARCEIRO_NEGOCIO = 'OP'");
        }

        public string ObterCdParceiroNegocioParaTipoParceiro(string cdExterno, string cdTipoParceiroNegocio)
        {
            return ObterRetorno("CD_PARCEIRO_NEGOCIO", "CD_EXTERNO", cdExterno, "TAB_ODS_PARCEIRO_NEGOCIO_2000", true, $"CD_TIPO_PARCEIRO_NEGOCIO = '{cdTipoParceiroNegocio}'");
        }

        public string ObterCdClienteParceiro(bool existente, string cdTpa = "", string[] diferenteDesses = null)
        {
            var clausula = "CD_TIPO_PARCEIRO_NEGOCIO = 'CL'";
            clausula = string.IsNullOrEmpty(cdTpa) ? clausula : clausula + $" AND CD_OPERACAO = '{cdTpa}'";
            if (diferenteDesses != null)
            {
                foreach (var cdCliente in diferenteDesses)
                    clausula += $" AND CD_EXTERNO <> '{cdCliente}'";
            }
            return ObterRetornoPadrao("CD_EXTERNO", "TAB_ODS_PARCEIRO_NEGOCIO_2000", existente, clausula, true);
        }

        public string ObterCdProdutoParaTPA(string cdTpa, bool relacionado)
        {
            var cdPnOperacao = ObterCdParceiroNegocioParaTPA(cdTpa);

            if (relacionado)
                return ObterRetorno("CD_PRODUTO", "CD_PN_OPERACAO", cdPnOperacao, "TAB_PRM_PRD_COBERTURA_7009", true);
            return ObterRetornoNotIn("CD_PRODUTO", "CD_PN_OPERACAO", cdPnOperacao, "TAB_PRM_PRD_COBERTURA_7009");
        }

        public string ObterIdCoberturaParaTPA(string cdTpa, bool relacionado)
        {
            var cdPnOperacao = ObterCdParceiroNegocioParaTPA(cdTpa);
            if (relacionado)
                return ObterRetorno("ID_COBERTURA", "CD_PN_OPERACAO", cdPnOperacao, "TAB_PRM_PRD_COBERTURA_7009", true);
            return ObterRetornoNotIn("ID_COBERTURA", "CD_PN_OPERACAO", cdPnOperacao, "TAB_PRM_PRD_COBERTURA_7009");
        }

        public string ObterIdCoberturaParaCodigo(string cdCobertura)
        {
                return ObterRetorno("ID_COBERTURA", "CD_COBERTURA", cdCobertura, "TAB_PRM_PRD_COBERTURA_7009", true);
        }

        public string ObterIdCoberturaParaCodigosCoberturaEProduto(string cdCobertura, string cdProduto)
        {
            return ObterRetorno("ID_COBERTURA", "CD_COBERTURA", cdCobertura, "TAB_PRM_COBERTURA_7007", true, $"CD_PRODUTO = '{cdProduto}'");
        }

        public Cobertura ObterCoberturaPeloId(string idCobertura , bool simples = false)
        {
            if (int.TryParse(idCobertura, out int id))
                return ObterCobertura("",id,simples);
            else
                throw new Exception("ID de cobertura invalido.");
        }

        public Cobertura ObterCoberturaSimples(string cdTpa)
        {
            return ObterCobertura(cdTpa, 0, true);
        }

        public Cobertura ObterCobertura(string cdTpa = "" ,int idCobertura = 0, bool simples = false)
        {
            var select = QueryCobertura(idCobertura, cdTpa, "", simples);

            var tabela = DataAccess.Consulta(select, "COBERTURA", logger);
            var linha = tabela.Rows[new Random(DateTime.Now.Millisecond).Next(0, tabela.Rows.Count - 1)];
            
            return Cobertura.CarregarCobertura(linha);
        }

        public Cobertura ObterCoberturaPeloCodigo(string cdCobertura, bool simples = false)
        {
            var select = QueryCobertura(0,"", cdCobertura, simples);

            var tabela = DataAccess.Consulta(select, "COBERTURA", logger);
            var linha = tabela.Rows[new Random(DateTime.Now.Millisecond).Next(0, tabela.Rows.Count - 1)];

            return Cobertura.CarregarCobertura(linha);
        }

        public string ObterCDSeguradoraDoTipoParceiro(string cdTipoParceiroNegocio)
        {
             return ObterRetorno("CD_EXTERNO", "CD_TIPO_PARCEIRO_NEGOCIO", cdTipoParceiroNegocio, "TAB_ODS_PARCEIRO_NEGOCIO_2000",true);
        }

        public string ObterParceiroNegocioNaoExistente()
        {
            return ObterNaoExistenteNaTabela("CD_EXTERNO", "TAB_ODS_PARCEIRO_NEGOCIO_2000", 99999);
        }

        public Cobertura ObterCoberturaDiferenteDe(string cdCobertura, string cdTpa = "", bool simples = false, string cdRamo = "")
        {
            var select = QueryCobertura(0, cdTpa,"", simples,cdRamo) + $" AND C.CD_COBERTURA <> '{cdCobertura}'";

            var tabela = DataAccess.Consulta(select, "COBERTURA", logger);
            var linha = tabela.Rows[new Random(DateTime.Now.Millisecond).Next(0, tabela.Rows.Count - 1)];

            return Cobertura.CarregarCobertura(linha);
        }

        private string QueryCobertura(int idCobertura = 0, string cdTpa ="", string cdCobertura = "", bool simples = false, string cdRamo = "")
        {
            var sql = $"SELECT TOP 1 C.ID_COBERTURA, C.CD_COBERTURA, C.CD_RAMO_COBERTURA, P.CD_RAMO, P.CD_PRODUTO ";
            if (!simples)
                sql += $", PP.VL_DESCONTO_MAIOR ,PP.VL_DESCONTO_MENOR, PP.VL_JUROS_MAIOR, PP.VL_JUROS_MENOR, PP.VL_ADIC_FRAC_MAIOR, PP.VL_ADIC_FRAC_MENOR," +
                    $" PP.VL_PREMIO_LQ_MENOR , PP.VL_PREMIO_LQ_MAIOR, PP.VL_PREMIO_BR_MENOR, PP.VL_PREMIO_BR_MAIOR, PP.VL_PERC_ALIQUOTA_IOF," +
                    $" PP.VL_PERC_TAXA_SEGURO , PP.VL_PERC_DISTRIBUICAO, PP.TP_APLICACAO_PREMIO_BR, PP.VL_IOF_MAIOR, PP.VL_IOF_MENOR, PP.TP_APLICACAO_IOF, PP.TP_APLICACAO_PREMIO_LQ, " +
                    $" PRDC.ID_PRD_COBERTURA, PRDC.CD_PN_SUCURSAL ";

            sql += $" FROM {Parametros.instanciaDB}.TAB_PRM_COBERTURA_7007 C " +
               $" INNER JOIN {Parametros.instanciaDB}.TAB_PRM_PRODUTO_7003 P ON C.CD_PRODUTO = P.CD_PRODUTO " +
                $" INNER JOIN {Parametros.instanciaDB}.TAB_PRM_PRD_COBERTURA_7009 PRDC ON C.ID_COBERTURA = PRDC.ID_COBERTURA ";

            if (!simples)
                sql += $" INNER JOIN {Parametros.instanciaDB}.TAB_PRM_PERCENT_PREMIO_7012 PP ON PRDC.ID_PRD_COBERTURA = PP.ID_PRD_COBERTURA ";

            var where = "";
            if (idCobertura != 0)
                where += $" WHERE C.ID_COBERTURA = {idCobertura}";
            else if (!string.IsNullOrEmpty(cdCobertura))
                where += (string.IsNullOrEmpty(where) ? " WHERE " : " AND ") + $"C.CD_COBERTURA = '{cdCobertura}'" ;
            else if (!string.IsNullOrEmpty(cdTpa))
                where += (string.IsNullOrEmpty(where) ? " WHERE " : " AND ") + $"PRDC.CD_PN_OPERACAO = '{ObterCdParceiroNegocioParaTPA(cdTpa)}'";
            if(!string.IsNullOrEmpty(cdRamo))
                where += (string.IsNullOrEmpty(where) ? " WHERE " : " AND ") + $"P.CD_RAMO = '{cdRamo}'";
            return sql + where;
        }

        public string ObterCdPNCorretor(string cdCorretor)
        {
            return ObterRetornoPadrao("CD_PARCEIRO_NEGOCIO", "TAB_ODS_PARCEIRO_NEGOCIO_2000", true, $"CD_TIPO_PARCEIRO_NEGOCIO = 'CO' AND CD_EXTERNO = '{cdCorretor}'", true);
        }

        public string ObterCdCorretor(string cdPnCorretor)
        {
            return ObterRetornoPadrao("CD_EXTERNO", "TAB_ODS_PARCEIRO_NEGOCIO_2000", true, $"CD_TIPO_PARCEIRO_NEGOCIO = 'CO' AND CD_PARCEIRO_NEGOCIO = '{cdPnCorretor}'", true);
        }

        public string[] ObterAtributosDoLayout(TipoArquivo tipo, string layout)
        {
            var sql = $"select DISTINCT(NM_ATRIBUTO_LAYOUT) from {Parametros.instanciaDB}.TAB_PRM_LAYOUT_7016 where NM_TIPO_ARQUIVO = '{tipo.ObterPrefixoOperadoraNoArquivo()}' AND CD_VERSAO_ARQUIVO = '{layout}' AND TP_REGISTRO = 3 AND ID_PRIMARY_KEY = '1'";
            var linhas = DataAccess.Consulta(sql, "NM_ATRIBUTO_LAYOUT", logger);
            var lista = new List<string>();
            foreach (DataRow row in linhas.Rows)
                lista.Add(row[0].ToString().ToUpper());
            if (linhas.Rows.Count == 0)
                throw new Exception("NENHUM LAYOUT ENCONTRADO");

            return lista.ToArray();
        }

        public string ObterParceiroNegocioComEndereco(string tipoParceiro, bool enderecoCompleto)
        {
            var sql = $" select TOP 1 CD_EXTERNO from {Parametros.instanciaDB}.TAB_ODS_PARCEIRO_NEGOCIO_2000 PN INNER JOIN " +
             $" {Parametros.instanciaDB}.TAB_ODS_ENDERECO_2001 E ON PN.CD_PARCEIRO_NEGOCIO = E.CD_PARCEIRO_NEGOCIO" +
             $" WHERE PN.CD_TIPO_PARCEIRO_NEGOCIO = '{tipoParceiro}'";
            if (enderecoCompleto)
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
            // invalida = sem CD_Classe_cobertura , dt_inicio_vigencia, dt_fim_vigencia
            var clausula = " CD_CLASSE_COBERTURA IS NULL OR DT_INICIO_VIGENCIA IS NULL OR DT_FIM_VIGENCIA IS NULL ";
            return DataAccess.ConsultaUnica($"SELECT TOP 1 CD_COBERTURA FROM {Parametros.instanciaDB}.TAB_PRM_COBERTURA_7007 where {clausula}");
        }

        public string ObterFlComissaoCalculada(string cdTpa)
        {
            var clausula = $"CD_EXTERNO = '{cdTpa}' and CD_TIPO_PARCEIRO_NEGOCIO = 'OP' ";
            return DataAccess.ConsultaUnica($"SELECT FL_COMISSAO_CALCULADA FROM {Parametros.instanciaDB}.TAB_ODS_PARCEIRO_NEGOCIO_2000 where {clausula}", logger);
        }

        public DataTable ObterValorRemuneracaoParaFG04(string cdTpa, string cdSucursal, string cdCobertura, string cdProduto, string tpRemuneracao, string flRemuInformada, string cdTipoRemuneracao)
        {
            var sucursal = ObterCdParceiroNegocioParaTipoParceiro(cdSucursal, "SU");
            var tpa = ObterCdParceiroNegocioParaTPA(cdTpa);
            var clausula = $"CD_PN_OPERACAO = '{tpa}' AND CD_PN_SUCURSAL = '{sucursal}' AND CD_COBERTURA = '{cdCobertura}' AND CD_PRODUTO = '{cdProduto}'" +
                $" AND TP_REMUNERACAO = '{tpRemuneracao}' AND FL_REMU_INFORMADA = '{flRemuInformada}'" +
                $" AND CD_PN_CORRETOR IS NOT NULL " +
                $" AND VL_REMUMERACAO IS NOT NULL ";
            if (!string.IsNullOrEmpty(cdTipoRemuneracao))
                clausula += $" AND CD_TIPO_REMUNERACAO = '{cdTipoRemuneracao}' ";
            return DataAccess.Consulta($"SELECT VL_REMUMERACAO, TP_REMUNERACAO, CD_PN_CORRETOR, CD_TIPO_REMUNERACAO FROM {Parametros.instanciaDB}.TAB_PRM_REMUNERACAO_7013 WHERE {clausula}",
                "BUSCANDO PARAMETRIZAÇÃO NA 7013", DBEnum.Hana, logger, false);
        }

        public ILinhaTabela ObterLinhaStageComissaoReferenteALinhaParcela(ILinhaTabela linhaStageParc)
        {
            return DataAccess.ChamarConsultaAoBanco<LinhaComissaoStage>($"SELECT * FROM {Parametros.instanciaDB}.{TabelasEnum.Comissao.ObterTexto()} WHERE " +
                    $"CD_CORRETOR = '{linhaStageParc.ObterPorColuna("CD_CORRETOR").ValorFormatado}' AND " +
                    $"CD_CONTRATO = '{linhaStageParc.ObterPorColuna("CD_CONTRATO").ValorFormatado}' AND " +
                    $"NR_SEQUENCIAL_EMISSAO = '{linhaStageParc.ObterPorColuna("NR_SEQUENCIAL_EMISSAO").ValorFormatado}' AND " +
                    $"CD_COBERTURA = '{linhaStageParc.ObterPorColuna("CD_COBERTURA").ValorFormatado}' AND " +
                    $"NR_PARCELA = '{linhaStageParc.ObterPorColuna("NR_PARCELA").ValorFormatado}'", logger).Single();
        }

        public ILinhaTabela ObterLinhaStageParcelaReferenteALinhaComissao(ILinhaTabela linhaStageComissao, bool ehAuto = false)
        {
            var tabela = ehAuto ? TabelasEnum.ParcEmissaoAuto : TabelasEnum.ParcEmissao;

            var sql = $"SELECT * FROM {Parametros.instanciaDB}.{tabela.ObterTexto()} WHERE " +
                    $"CD_CONTRATO = '{linhaStageComissao.ObterPorColuna("CD_CONTRATO").ValorFormatado}' AND " +
                    $"NR_SEQUENCIAL_EMISSAO = '{linhaStageComissao.ObterPorColuna("NR_SEQUENCIAL_EMISSAO").ValorFormatado}' AND " +
                    $"CD_COBERTURA = '{linhaStageComissao.ObterPorColuna("CD_COBERTURA").ValorFormatado}' AND " +
                    $"NR_PARCELA = '{linhaStageComissao.ObterPorColuna("NR_PARCELA").ValorFormatado}'";

            if (tabela == TabelasEnum.ParcEmissao)
                return DataAccess.ChamarConsultaAoBanco<LinhaParcEmissaoStage>(sql, logger)?.Single();
            else
                return DataAccess.ChamarConsultaAoBanco<LinhaParcEmissaoAutoStage>(sql, logger)?.Single();
        }

    }
}
