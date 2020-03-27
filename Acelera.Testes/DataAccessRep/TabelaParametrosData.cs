using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.DataAccessRep
{
    public class TabelaParametrosData
    {

        public string ObterCDMoeda(bool existente)
        {
            //SELECT NO BANCO, TABELA DE PARAMETRO, TRAZENDO OS CD_MOEDAS DISPONIVEIS
            return string.Empty;
        }

        /// <summary>
        /// Nao esquecer de loggar 
        /// </summary>
        /// <returns></returns>
        public string ObterCDContratoDaStage(bool existente)
        {
            return string.Empty;
        }

        /// <summary>
        /// SELECT NAS TABELAS PARA MONTAR UM CONJUNTO DE PRODUTO - RAMO - COEBRTURA NAO EXISTENTE
        /// </summary>
        /// <returns></returns>
        public string ObterCoberturaRamoProduto(bool existente)
        {
            return string.Empty;
        }


        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterCDFormaPagamento(bool valido)
        {
            return string.Empty;
        }

        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterRamo(bool existente)
        {
            return string.Empty;
        }

        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterProduto(bool existente)
        {
            return string.Empty;
        }

        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterCobertura(bool existente)
        {
            return string.Empty;
        }

        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterCDBancoSeg(bool existente)
        {
            return string.Empty;
        }

        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterOperacao(string produto, bool existente)
        {
            return string.Empty;
        }

        /// <summary>
        /// select now() from dummy
        /// </summary>
        /// <returns></returns>
        public string ObterDataDoBanco(bool existente)
        {
            return string.Empty;
        }



        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterCDSeguradora(bool existente)
        {
            return string.Empty;
        }

        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterCDFranquia(bool existente)
        {
            return string.Empty;
        }

        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterCDOcorrencia(bool existente)
        {
            return string.Empty;
        }


        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterJurosMaximo()
        {
            //Utiliza  ObterSucursal, cobertura, produto , ramo e operacao
            return string.Empty;
        }


        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterSucursal(bool existente)
        {
            return string.Empty;
        }

        /// <summary>
        /// SELECT NAS TABELAS DE PARAMETRO
        /// </summary>
        /// <returns></returns>
        public string ObterOperacao(bool existente)
        {
            return string.Empty;
        }

    }
}
