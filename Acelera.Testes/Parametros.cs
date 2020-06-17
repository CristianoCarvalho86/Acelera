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
            set { _instanciaDB = value;}
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

    }
}
