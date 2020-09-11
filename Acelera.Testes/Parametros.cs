using Acelera.Domain.Entidades;
using Acelera.Domain.Enums;
using Acelera.Domain.Layouts;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Acelera.Testes
{
    public static class Parametros
    {

        public static string pastaOrigem
        {
            get
            {
                var origem = ConfigurationManager.AppSettings.Get("PastaOrigem");
                if (string.IsNullOrEmpty(origem))
                    throw new Exception("Pasta de Origem nao definida");
                if (!origem.EndsWith("\\"))
                    origem += "\\";
                return origem;
            }
        }
        public static string pastaDestino
        {
            get
            {
                var origem = ConfigurationManager.AppSettings.Get("PastaDestino");
                if (string.IsNullOrEmpty(origem))
                    throw new Exception("Pasta de Destino nao definida");
                if (!origem.EndsWith("\\"))
                    origem += "\\";
                return origem;
            }
        }

        public static bool logStackTrace
        {
            get
            {
                var temp = ConfigurationManager.AppSettings.Get("LogStackTrace");
                if (string.IsNullOrEmpty(temp))
                    throw new Exception("LogStackTrace nao definido");

                return Convert.ToBoolean(temp);
            }
        }

        public static bool ExecutaPelaBat
        {
            get
            {
                var temp = ConfigurationManager.AppSettings.Get("ExecutaPelaBat");
                if (string.IsNullOrEmpty(temp))
                    throw new Exception("ExecutaPelaBat nao definido");

                return Convert.ToBoolean(temp);
            }
        }


        public static bool ValidaLogProcessamento
        {
            get
            {
                var temp = ConfigurationManager.AppSettings.Get("ValidaLogProcessamento");
                if (string.IsNullOrEmpty(temp))
                    throw new Exception("ValidaLogProcessamento nao definido");

                return Convert.ToBoolean(temp);
            }
        }

        public static bool logDataBaseResults
        {
            get
            {
                var temp = ConfigurationManager.AppSettings.Get("LogDataBaseResults");
                if (string.IsNullOrEmpty(temp))
                    throw new Exception("LogDataBaseResults nao definido");

                return Convert.ToBoolean(temp);
            }
        }

        public static string pastaDestinoXml
        {
            get
            {
                var destino = ConfigurationManager.AppSettings.Get("PastaDestinoXml");
                if (string.IsNullOrEmpty(destino))
                    throw new Exception("Pasta de Destino nao definida");
                if (!destino.EndsWith("\\"))
                    destino += "\\";
                return destino;
            }
        }

        public static string pastaLog
        {
            get
            {
                var logger = ConfigurationManager.AppSettings.Get("PastaLogger");
                if (string.IsNullOrEmpty(logger))
                    throw new Exception("Pasta de Log nao definida");
                if (!logger.EndsWith("\\"))
                    logger += "\\";
                return logger;
            }
        }

        public static string pastaLogArquivo
        {
            get
            {
                var logger = ConfigurationManager.AppSettings.Get("PastaLoggerArquivos");
                if (string.IsNullOrEmpty(logger))
                    throw new Exception("Pasta de Log dos arquivos nao definida");
                if (!logger.EndsWith("\\"))
                    logger += "\\";
                return logger;
            }
        }

        public static string pastaLogCopia
        {
            get
            {
                var logger = ConfigurationManager.AppSettings.Get("PastaLoggerCopia");
                if (string.IsNullOrEmpty(logger))
                    return null;
                if (!logger.EndsWith("\\"))
                    logger += "\\";
                return logger;
            }
        }

        public static string pastaLogArquivoCopia
        {
            get
            {
                var logger = ConfigurationManager.AppSettings.Get("PastaLoggerArquivosCopia");
                if (string.IsNullOrEmpty(logger))
                    return null;
                if (!logger.EndsWith("\\"))
                    logger += "\\";
                return logger;
            }
        }

        public static string dataArquivoParametro
        {
            get
            {
                var dataArquivo = ConfigurationManager.AppSettings.Get("DataArquivo");
                if (string.IsNullOrEmpty(dataArquivo))
                    return null;
                return dataArquivo;
            }
        }
        public static string OperacaoTeste
        {
            get
            {
                var operacao = ConfigurationManager.AppSettings.Get("OperacaoTeste");
                if (string.IsNullOrEmpty(operacao))
                    throw new Exception("OperacaoTeste Atributo OperacaoTeste nao informado.");
                return operacao;
            }
        }

        private static string _instanciaDB;
        public static string instanciaDB
        {
            get
            {
                if (string.IsNullOrEmpty(_instanciaDB))
                {
                    _instanciaDB = ConfigurationManager.AppSettings.Get("InstanciaDB");
                    if (string.IsNullOrEmpty(_instanciaDB))
                        return "HDIQAS_1";
                }
                return _instanciaDB;
            }
            set { _instanciaDB = value; }
        }

        private static string _connectionStringHana;
        public static string connectionStringHana
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionStringHana))
                {
                    _connectionStringHana = ConfigurationManager.AppSettings.Get("ConnectionString");
                    if (string.IsNullOrEmpty(_connectionStringHana))
                        throw new Exception("CONNECTION STRINGO DO HANA NAO ENCONTRADA");
                }
                return _connectionStringHana;
            }
            set { _connectionStringHana = value; }
        }

        private static string _connectionStringOIM;
        public static string connectionStringOIM
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionStringOIM))
                {
                    _connectionStringOIM = ConfigurationManager.AppSettings.Get("ConnectionStringOIM");
                    if (string.IsNullOrEmpty(_connectionStringOIM))
                        throw new Exception("CONNECTION STRINGO DO OIM NAO ENCONTRADA");
                }
                return _connectionStringOIM;
            }
            set { _connectionStringOIM = value; }
        }
        private static string _connectionStringSGS;
        public static string connectionStringSGS
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionStringSGS))
                {
                    _connectionStringSGS = ConfigurationManager.AppSettings.Get("ConnectionStringSGS");
                    if (string.IsNullOrEmpty(_connectionStringSGS))
                        throw new Exception("CONNECTION STRING DO SGS NAO ENCONTRADA");
                }
                return _connectionStringSGS;
            }
            set { _connectionStringSGS = value; }
        }



        public static ModoExecucaoEnum ModoExecucao
        {
            get
            {
                var modo = ConfigurationManager.AppSettings.Get("ModoExecucao");
                if (string.IsNullOrEmpty(modo) || modo == ((int)ModoExecucaoEnum.Completo).ToString())
                    return ModoExecucaoEnum.Completo;
                if (modo == ((int)ModoExecucaoEnum.ApenasCriacao).ToString())
                    return ModoExecucaoEnum.ApenasCriacao;
                if (modo == ((int)ModoExecucaoEnum.ApenasValidacao).ToString())
                    return ModoExecucaoEnum.ApenasValidacao;
                return ModoExecucaoEnum.Completo;
            }
        }

        public static string PastaBatDia
        {
            get
            {
                var batDia = ConfigurationManager.AppSettings.Get("PastaBatDia");
                if (string.IsNullOrEmpty(batDia))
                    throw new Exception("Pasta Bat Dia nao definida");
                if (!batDia.EndsWith("\\"))
                    batDia += "\\";
                return batDia;
            }
        }

        public static string PastaBatNoite
        {
            get
            {
                var batNoite = ConfigurationManager.AppSettings.Get("PastaBatNoite");
                if (string.IsNullOrEmpty(batNoite))
                    throw new Exception("Pasta Bat Noite nao definida");
                if (!batNoite.EndsWith("\\"))
                    batNoite += "\\";
                return batNoite;
            }
        }
    }
}
