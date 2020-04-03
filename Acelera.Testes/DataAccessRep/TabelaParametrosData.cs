using Acelera.Domain.Entidades;
using Acelera.Domain.Enums;
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
        private IMyLogger logger;
        public TabelaParametrosData(IMyLogger logger)
        {
            this.logger = logger;
        }

        private string ObterRetornoPadrao(string campo, string tabela, bool existente)
        {
            string select = string.Empty;
            if (existente)
                select = $"select top 1 {campo} from {Parametros.instanciaDB}.{tabela}";
            else
                select = $"select (MAX({campo}) + 1) as {campo} from {Parametros.instanciaDB}.{tabela}";

            return DataAccess.ConsultaUnica(select, campo, logger);
        }

        private string ObterRetornoParaDiferente(string campoBusca, string campoComparacao, string valor, string tabela)
        {
            return ObterRetorno(campoBusca,campoComparacao,valor,tabela, false);
        }

        private string ObterRetorno(string campoBusca, string campoComparacao, string valor, string tabela, bool igual)
        {
            var operador = igual ? "=" : "<>";
            var texto = igual ? "IGUAL A " : " DIFERENTE DE ";
            var select = $"select top 1 {campoBusca} from {Parametros.instanciaDB}.{tabela} where {campoComparacao} {operador} '{valor}'";


            return DataAccess.ConsultaUnica(select, campoComparacao + texto + valor, logger);
        }

        public string ObterCDMoeda(bool existente)
        {
           return ObterRetornoPadrao("CD_MOEDA", "TAB_PRM_MOEDA_7030", existente);
        }

        private string ObterRetornoNotIn(string campoBusca, string campoComparacao, string valor, string tabela)
        {
            var select = $"select top 1 {campoBusca} from {Parametros.instanciaDB}.{tabela} WHERE {campoBusca} NOT IN" +
                $" (select {campoBusca} from {Parametros.instanciaDB}.{tabela} WHERE {campoComparacao} = '{valor}')";


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
        public string ObterCobertura(bool existente)
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
        /// SELECT NAS TABELAS DE PARAMETRO
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
            //TAB_PRM_FRANQUIA_7010
            return ObterRetornoPadrao("CD_FRANQUIA", "TAB_PRM_FRANQUIA_7010", existente);
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
        public string ObterJurosMaximo()
        {
            //Utiliza  ObterSucursal, cobertura, produto , ramo e operacao
            throw new NotImplementedException();
        }


        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterSucursal(bool existente)
        {
            throw new NotImplementedException();
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
            string select = string.Empty;
            var operador = ComCritica ? " = " : " <> ";
                select = $"select top 1 CD_TIPO_EMISSAO from {Parametros.instanciaDB}.TAB_PRM_TIPO_MOVIMENTO_7024 where TP_ACAO {operador} '{acao}'";


            return DataAccess.ConsultaUnica(select, "CD_TIPO_EMISSAO", logger);
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

        public string ObterTPA(string cdTipoEmissao, bool existente)
        {
            string select = string.Empty;
            var operador = existente ? " = " : " <> ";
            select = $"select top 1 CD_TPA_OPERACAO from {Parametros.instanciaDB}.TAB_PRM_TIPO_MOVIMENTO_7024 where CD_TIPO_EMISSAO {operador} '{cdTipoEmissao}'";


            return DataAccess.ConsultaUnica(select, "CD_TPA_OPERACAO", logger);
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

        public string ObterCDTipoMovimentoNaoRelacionadoAAtuacao(string atuacao)
        {
            return ObterRetornoNotIn("CD_TIPO_MOVIMENTO", "CD_ATUACAO", atuacao, "TAB_PRM_TIPO_MOVIMENTO_7024");
        }

        public Cobertura ObterCobertura()
        {
            var select = QueryCobertura();

            var tabela = DataAccess.Consulta(select, "COBERTURA", logger);
            var linha = tabela.Rows[new Random(DateTime.Now.Millisecond).Next(0, tabela.Rows.Count - 1)];
            
            return Cobertura.CarregarCobertura(linha);
        }

        public Cobertura ObterCoberturaDiferenteDe(string cdCobertura)
        {
            var select = QueryCobertura() + $" WHERE C.CD_COBERTURA <> '{cdCobertura}'";

            var tabela = DataAccess.Consulta(select, "COBERTURA", logger);
            var linha = tabela.Rows[new Random(DateTime.Now.Millisecond).Next(0, tabela.Rows.Count - 1)];

            return Cobertura.CarregarCobertura(linha);
        }

        private string QueryCobertura()
        {
            return $"SELECT C.ID_COBERTURA, C.CD_COBERTURA, C.CD_RAMO_COBERTURA, P.CD_RAMO, P.CD_PRODUTO, PP.VL_DESCONTO_MAIOR, " +
               $" PP.VL_DESCONTO_MENOR, PP.VL_JUROS_MAIOR, PP.VL_JUROS_MENOR, PP.VL_ADIC_FRAC_MAIOR, PP.VL_ADIC_FRAC_MENOR " +
               $" FROM {Parametros.instanciaDB}.TAB_PRM_COBERTURA_7007 C " +
               $" INNER JOIN {Parametros.instanciaDB}.TAB_PRM_PRODUTO_7003 P ON C.CD_PRODUTO = P.CD_PRODUTO " +
               $" INNER JOIN {Parametros.instanciaDB}.TAB_PRM_PRD_COBERTURA_7009 PRDC ON C.ID_COBERTURA = PRDC.ID_COBERTURA " +
               $" INNER JOIN {Parametros.instanciaDB}.TAB_PRM_PERCENT_PREMIO_7012 PP ON PRDC.ID_PRD_COBERTURA = PP.ID_PRD_COBERTURA ";
        }

    }
}
