using Acelera.Domain.Entidades;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.DataAccessRep
{
    public class TabelaParametrosData
    {
        protected IMyLogger logger { get; private set; }
        public TabelaParametrosData(IMyLogger logger)
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

        public string ObterCDTipoMovimentoParaAtuacao(string atuacao, bool relacionado)
        {
            if(relacionado)
                return ObterRetorno("CD_TIPO_MOVIMENTO", "CD_ATUACAO", atuacao, "TAB_PRM_TIPO_MOVIMENTO_7024", true);
            return ObterRetornoNotIn("CD_TIPO_MOVIMENTO", "CD_ATUACAO", atuacao, "TAB_PRM_TIPO_MOVIMENTO_7024");
        }

        public string ObterCdCorretorParaTipoRemuneracao(string cdTpa ,string cdTipoRemuneracao, bool relacionado, string[] diferenteDeCdCorretor = null)
        {
            var clausula = diferenteDeCdCorretor == null ? $" CD_PN_TPA = '{cdTpa}'" 
                : diferenteDeCdCorretor.Select(x => $" CD_PN_CORRETOR <> '{x}'").ToList().ObterListaConcatenada(" AND ") + $" AND CD_PN_TPA = '{cdTpa}'";
            if (relacionado)
                return ObterRetorno("CD_PN_CORRETOR", "CD_TIPO_REMUNERACAO", cdTipoRemuneracao, "TAB_PRM_REMUNERACAO_7013", true, clausula);
            return ObterRetornoNotIn("CD_PN_CORRETOR", "CD_TIPO_REMUNERACAO", cdTipoRemuneracao, "TAB_PRM_REMUNERACAO_7013", clausula);
        }

        public string ObterCdParceiroNegocioParaTPA(string cdTpa)
        {
            return ObterRetorno("CD_PARCEIRO_NEGOCIO", "CD_EXTERNO", cdTpa, "TAB_ODS_PARCEIRO_NEGOCIO_2000", true, "CD_TIPO_PARCEIRO_NEGOCIO = 'OP'");
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

        public Cobertura ObterCoberturaDiferenteDe(string cdCobertura)
        {
            var select = QueryCobertura() + $" WHERE C.CD_COBERTURA <> '{cdCobertura}'";

            var tabela = DataAccess.Consulta(select, "COBERTURA", logger);
            var linha = tabela.Rows[new Random(DateTime.Now.Millisecond).Next(0, tabela.Rows.Count - 1)];

            return Cobertura.CarregarCobertura(linha);
        }

        private string QueryCobertura(int idCobertura = 0, string cdTpa ="", string cdCobertura = "", bool simples = false)
        {
            var sql = $"SELECT TOP 1 C.ID_COBERTURA, C.CD_COBERTURA, C.CD_RAMO_COBERTURA, P.CD_RAMO, P.CD_PRODUTO ";
            if (!simples)
                sql += $", PP.VL_DESCONTO_MAIOR ,PP.VL_DESCONTO_MENOR, PP.VL_JUROS_MAIOR, PP.VL_JUROS_MENOR, PP.VL_ADIC_FRAC_MAIOR, PP.VL_ADIC_FRAC_MENOR," +
                    $" PP.VL_PREMIO_LQ_MENOR , PP.VL_PREMIO_LQ_MAIOR, PP.VL_PREMIO_BR_MENOR, PP.VL_PREMIO_BR_MAIOR, PP.VL_PERC_ALIQUOTA_IOF," +
                    $" PP.VL_PERC_TAXA_SEGURO , PP.VL_PERC_DISTRIBUICAO, PP.TP_APLICACAO_PREMIO_BR, PP.VL_IOF_MAIOR, PP.VL_IOF_MENOR, PP.TP_APLICACAO_IOF, PP.TP_APLICACAO_PREMIO_LQ ";

            sql += $" FROM {Parametros.instanciaDB}.TAB_PRM_COBERTURA_7007 C " +
               $" INNER JOIN {Parametros.instanciaDB}.TAB_PRM_PRODUTO_7003 P ON C.CD_PRODUTO = P.CD_PRODUTO " +
                $" INNER JOIN {Parametros.instanciaDB}.TAB_PRM_PRD_COBERTURA_7009 PRDC ON C.ID_COBERTURA = PRDC.ID_COBERTURA ";


            if (!simples)
                sql += $" INNER JOIN {Parametros.instanciaDB}.TAB_PRM_PERCENT_PREMIO_7012 PP ON PRDC.ID_PRD_COBERTURA = PP.ID_PRD_COBERTURA ";

            if (idCobertura != 0)
                sql += $" WHERE C.ID_COBERTURA = {idCobertura}";
            else if (!string.IsNullOrEmpty(cdCobertura))
                sql += $" WHERE C.CD_COBERTURA = {cdCobertura}";
            else if (!string.IsNullOrEmpty(cdTpa))
                sql += $" WHERE PRDC.CD_PN_TPA = '{cdTpa}'";
            return sql;
        }

    }
}
