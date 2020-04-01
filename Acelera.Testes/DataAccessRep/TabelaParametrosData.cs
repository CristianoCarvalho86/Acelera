using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.DataAccessRep
{
    public class TabelaParametrosData
    {
        private MyLogger logger;
        public TabelaParametrosData(MyLogger logger)
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

        public string ObterCDMoeda(bool existente)
        {
           return ObterRetornoPadrao("CD_MOEDA", "TAB_PRM_MOEDA_7030", existente);
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
        /// SELECT NAS TABELAS PARA MONTAR UM CONJUNTO DE PRODUTO - RAMO - COEBRTURA NAO EXISTENTE
        /// </summary>
        /// <returns></returns>
        public string ObterCoberturaRamoProduto(bool existente)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterCDFormaPagamento(bool valido)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
        public string ObterDataDoBanco(bool existente)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterCDSeguradora(bool existente)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterCDFranquia(bool existente)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterCDOcorrencia(bool existente)
        {
            throw new NotImplementedException();
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

        public string ObterCDTipoEmissao(string acao, bool ComCritica)
        {
            string select = string.Empty;
            var operador = ComCritica ? " = " : " <> ";
                select = $"select top 1 CD_TIPO_EMISSAO from {Parametros.instanciaDB}.TAB_PRM_TIPO_MOVIMENTO_7024 where TP_ACAO {operador} '{acao}'";


            return DataAccess.ConsultaUnica(select, "CD_TIPO_EMISSAO", logger);
        }

    }
}
