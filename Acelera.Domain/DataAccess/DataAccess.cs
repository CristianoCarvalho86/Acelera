using Acelera.Data;
using Acelera.Domain;
using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.DataAccess
{
    public static class DataAccess
    {
        public static IList<T> ChamarConsultaAoBanco<T>(ConjuntoConsultas consulta, IMyLogger logger) where T : ILinhaTabela, new()
        {
            var tabela = new Tabela<T>();
            try
            {
                logger.InicioOperacao(OperacaoEnum.ConsultaBanco, tabela.ObterNomeTabela());

                var c = tabela.ObterQuery(consulta, Parametros.instanciaDB).Replace("/*R*/", "");
                logger.Escrever("Consulta Realizada :" + c);
                var resultado = DBHelperHana.Instance.GetData(c);

                logger.LogRetornoQuery(resultado, c);

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

        public static IList<T> ChamarConsultaAoBanco<T>(string consulta, IMyLogger logger) where T : ILinhaTabela, new()
        {
            var tabela = new Tabela<T>();
            try
            {
                logger.InicioOperacao(OperacaoEnum.ConsultaBanco, tabela.ObterNomeTabela());

                var c = consulta;
                logger.Escrever("Consulta Realizada :" + c);
                var resultado = DBHelperHana.Instance.GetData(c);

                logger.LogRetornoQuery(resultado, c);

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

        public static string ConsultaUnica(string sql, string parametroBuscado, IMyLogger logger)
        {
            return ConsultaUnica(sql, parametroBuscado, DBEnum.Hana, logger);
        }

        public static string ConsultaUnica(string sql, IMyLogger logger, bool validaResultadoUnico = true)
        {
            return ConsultaUnica(sql, string.Empty, DBEnum.Hana, logger, validaResultadoUnico);
        }

        public static string ObterTotalLinhas(string tabela, IMyLogger logger, string clausula = null)
        {
            clausula = string.IsNullOrEmpty(clausula) ? string.Empty : $" WHERE {clausula}";
            return ConsultaUnica($"SELECT COUNT(*) AS TOTAL FROM {Parametros.instanciaDB}.{tabela} {clausula}",$"OBTER QUANTIDADE REGISTROS NA TABELA: {tabela}",logger);
        }

        public static bool ExisteRegistro(string sql, IMyLogger logger)
        {
            var table = Consulta(sql, "VALIDACAO SE EXISTE REGISTRO NO BANCO",DBEnum.Hana, logger, false);
            return table.Rows.Count != 0;
        }

        public static bool ExisteRegistro(string tabela, string campoBusca, string valorBusca, IMyLogger logger)
        {
            return ExisteRegistro($"SELECT '1' from {Parametros.instanciaDB}.{tabela} where {campoBusca} = '{valorBusca}' ", logger);
        }

        public static string ConsultaUnica(string sql, string parametroBuscado, DBEnum dbEnum , IMyLogger logger, bool validaResultadoUnico = true)
        {
            IDBHelper helper = ObterBanco(dbEnum);
            string resultado;
            try
            {
                if (logger == null)
                    return ConsultaUnica(sql,dbEnum);

                logger.InicioOperacao(OperacaoEnum.ConsultaBanco, parametroBuscado);

                logger.Escrever("Consulta Realizada :" + sql);
                resultado = helper.ObterResultadoUnico(sql, validaResultadoUnico);

                if (string.IsNullOrEmpty(resultado))
                {
                    logger.Escrever("NENHUM REGISTRO ENCONTRADO.");

                    if (validaResultadoUnico)
                        throw new Exception("Resultado nao encontrado");
                }
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

        public static string ConsultaUnica(string sql, bool validaResultadoUnico = true)
        {
            return ConsultaUnica(sql, DBEnum.Hana,validaResultadoUnico);
        }

        public static string ConsultaUnica(string sql, DBEnum dbEnum, bool validaResultadoUnico = true)
        {
            IDBHelper helper = ObterBanco(dbEnum);
            string resultado;
            try
            {
                resultado = helper.ObterResultadoUnico(sql, validaResultadoUnico);
                if (string.IsNullOrEmpty(resultado) && validaResultadoUnico)
                    throw new Exception("Resultado nao encontrado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        /// <summary>
        /// Default, using Hana
        /// </summary>
        /// <returns>Full filled DataTable</returns>
        public static DataTable Consulta(string sql, string parametroBuscado, IMyLogger logger)
        {
            return Consulta(sql, parametroBuscado,DBEnum.Hana, logger);
        }

        public static void ExecutarComando(string comando, DBEnum dbEnum, IMyLogger logger)
        {
            IDBHelper helper = ObterBanco(dbEnum);

            logger.AbrirBloco($"INICIANDO EXECUÇÃO DE : {comando}");
            var resultado = helper.Execute(comando);
            logger.Escrever($"RETORNO DO BANCO : '{resultado}'");
            logger.FecharBloco();
        }

        public static DataTable Consulta(string sql, string parametroBuscado, DBEnum dbEnum, IMyLogger logger, bool validaResultadoUnico = true)
        {
            IDBHelper helper = ObterBanco(dbEnum);
            DataTable tabela;
            try
            {
                logger.InicioOperacao(OperacaoEnum.ConsultaBanco, parametroBuscado);
                logger.Escrever("Consulta Realizada :" + sql);

                tabela = helper.GetData(sql);

                if (tabela.Rows.Count == 0)
                {
                    logger.Escrever("NENHUM REGISTRO ENCONTRADO.");

                    if (validaResultadoUnico)
                    {
                        logger.Erro("NENHUMA LINHA ENCONTRADA");
                        throw new Exception("NENHUMA LINHA ENCONTRADA");
                    }
                }

                logger.LogRetornoQuery(tabela, sql);

                logger.SucessoDaOperacao(OperacaoEnum.ConsultaBanco, parametroBuscado);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tabela;
        }

        //[Obsolete]
        //public static IList<T> ChamarConsultaAoBancoViaCMD<T>(ConjuntoConsultas consultas, IMyLogger logger) where T : LinhaTabela, new()
        //{
        //    var tabela = new Tabela<T>();
        //    try
        //    {
        //        logger.InicioOperacao(OperacaoEnum.ConsultaBanco, tabela.ObterNomeTabela());
        //        var integracao = new IntegracaoCMD();
        //        integracao.AbrirCMD();

        //        integracao.ExecutarQuery(tabela.ObterQueryParaCMD(consultas));
        //        var resultado = integracao.ObterTextoCMD();
        //        tabela.ObterRetornoQueryCMD(resultado);

        //        logger.LogRetornoCMD(resultado);
        //        logger.SucessoDaOperacao(OperacaoEnum.ConsultaBanco, tabela.ObterNomeTabela());

        //        integracao.FecharCMD();

        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Erro(ex);
        //    }
        //    return tabela.Linhas;
        //}

        private static IDBHelper ObterBanco(DBEnum dbEnum)
        {
            if (dbEnum == DBEnum.Hana)
                return DBHelperHana.Instance;
            else if (dbEnum == DBEnum.SqlServer)
            {
                DBHelperSQLServer.Instance.SetConnection(Parametros.connectionStringSGS);
                return DBHelperSQLServer.Instance;
            }
            else if (dbEnum == DBEnum.SqlServerOIM)
            {
                DBHelperSQLServer.Instance.SetConnection(Parametros.connectionStringOIM);
                return DBHelperSQLServer.Instance;
            }
            throw new Exception("BANCO NAO PARAMETRIZADO");
        }

        public static bool ChamarExecucaoHana(string taskName, IMyLogger logger)
        {
            IDBHelper helper = ObterBanco(DBEnum.Hana);

            if (Parametros.ModoExecucao != ModoExecucaoEnum.Completo)
                return true;
            try
            {
                var comando = "";
                if (taskName.Contains("FGR_01_") && !taskName.Contains("FGR_01_2") && !taskName.Contains("FGR_01_1"))//Temporario enquanto resolvem o problema da FG01 (Codigo vindo 150 onde nao devia)
                    comando = $"CALL {Parametros.instanciaDB}.{taskName}_SP()";
                else if (taskName.Contains("PRC_ENCADEA_FGR_08"))
                    comando = $"CALL {Parametros.instanciaDB}.PRC_ENCADEA_FGR_08(OUT_STATUS => ?)";
                else
                    comando = $"START TASK {Parametros.instanciaDB}.{taskName}";

                logger.AbrirBloco($"EXECUTANDO TAREFA : '{taskName}'");
                logger.Escrever($"EXECUTANDO COMANDO : {comando}");
                var retorno = helper.Execute(comando, out string erroEncontrado);

                logger.EscreverBloco($"RESULTADO DA TAREFA : '{retorno}'");

                if (retorno == 999)
                    logger.Escrever("HOUVE UM ERRO DESCARTADO NA EXECUÇÃO : " + erroEncontrado);
                logger.FecharBloco();
                return true;
            }
            catch (Exception ex)
            {
                logger.Erro(ex);
                throw ex;
            }

        }

    }
}
