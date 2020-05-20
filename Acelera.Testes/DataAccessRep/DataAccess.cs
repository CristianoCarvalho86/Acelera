using Acelera.Data;
using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Logger;
using Acelera.Testes.Adapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.DataAccessRep
{
    public static class DataAccess
    {
        public static IList<T> ChamarConsultaAoBanco<T>(ConjuntoConsultas consulta, IMyLogger logger) where T : ILinhaTabela, new()
        {
            var tabela = new Tabela<T>();
            try
            {
                logger.InicioOperacao(OperacaoEnum.ConsultaBanco, tabela.ObterNomeTabela());

                var c = tabela.ObterQuery(consulta,Parametros.instanciaDB).Replace("/*R*/","");
                logger.Escrever("Consulta Realizada :" + c);
                var resultado = DBHelperHana.Instance.GetData(c);

                logger.LogRetornoQuery(resultado,c);

                tabela.ObterRetornoQuery(resultado);

                logger.SucessoDaOperacao(OperacaoEnum.ConsultaBanco, tabela.ObterNomeTabela());

            }
            catch (Exception ex)
            {
                logger.Erro(ex);
                throw ex;
            }
            return tabela.Linhas;
        }

        public static string ConsultaUnica(string sql, string parametroBuscado, IDBHelper dBHelper , IMyLogger logger)
        {
            string resultado;
            try
            {
                if (logger == null)
                    return ConsultaUnica(sql,dBHelper);

                logger.InicioOperacao(OperacaoEnum.ConsultaBanco, parametroBuscado);

                logger.Escrever("Consulta Realizada :" + sql);
                resultado = dBHelper.ObterResultadoUnico(sql);


                if (string.IsNullOrEmpty(resultado))
                    throw new Exception("Resultado nao encontrado");

                logger.Escrever($"Parametro Buscado encontrado: {resultado}");
                
                logger.SucessoDaOperacao(OperacaoEnum.ConsultaBanco, parametroBuscado);

            }
            catch (Exception ex)
            {
                logger.Erro(ex);
                throw ex;
            }
            return resultado;
        }

        public static string ConsultaUnica(string sql, IDBHelper dBHelper, bool validaResultadoUnico = true)
        {
            string resultado;
            try
            {
                resultado = dBHelper.ObterResultadoUnico(sql, validaResultadoUnico);
                if (string.IsNullOrEmpty(resultado) && validaResultadoUnico)
                    throw new Exception("Resultado nao encontrado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public static DataTable Consulta(string sql, string parametroBuscado, DBEnum dbEnum, IMyLogger logger)
        {
            IDBHelper helper = ObterBanco(dbEnum);
            DataTable tabela;
            try
            {
                logger.InicioOperacao(OperacaoEnum.ConsultaBanco, parametroBuscado);
                logger.Escrever("Consulta Realizada :" + sql);

                tabela = helper.GetData(sql);

                if (tabela.Rows.Count == 0)
                    throw new Exception("NENHUMA LINHA ENCONTRADA");

                logger.LogRetornoQuery(tabela, sql);

                logger.SucessoDaOperacao(OperacaoEnum.ConsultaBanco, parametroBuscado);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tabela;
        }

        [Obsolete]
        public static IList<T> ChamarConsultaAoBancoViaCMD<T>(ConjuntoConsultas consultas, IMyLogger logger) where T : LinhaTabela, new()
        {
            var tabela = new Tabela<T>();
            try
            {
                logger.InicioOperacao(OperacaoEnum.ConsultaBanco,tabela.ObterNomeTabela());
                var integracao = new IntegracaoCMD();
                integracao.AbrirCMD();

                integracao.ExecutarQuery(tabela.ObterQueryParaCMD(consultas));
                var resultado = integracao.ObterTextoCMD();
                tabela.ObterRetornoQueryCMD(resultado);

                logger.LogRetornoCMD(resultado);
                logger.SucessoDaOperacao(OperacaoEnum.ConsultaBanco, tabela.ObterNomeTabela());

                integracao.FecharCMD();

            }
            catch (Exception ex)
            {
                logger.Erro(ex);
            }
            return tabela.Linhas;
        }

        private static IDBHelper ObterBanco(DBEnum dbEnum)
        {
            if (dbEnum == DBEnum.Hana)
                return DBHelperHana.Instance;
            else if (dbEnum == DBEnum.SqlServer)
                return DBHelperSQLServer.Instance;
            throw new Exception("BANCO NAO PARAMETRIZADO");
        }

    }
}
