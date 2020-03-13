using Acelera.Domain.Entidades;
using Acelera.Domain.Enums;
using Acelera.Domain.Layouts;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Acelera.Testes
{
    public abstract class TesteItens
    {
        protected string nomeArquivo;
        protected MyLogger logger;
        protected Arquivo arquivo;
        protected AlteracoesArquivo valoresAlteradosBody;
        protected AlteracoesArquivo valoresAlteradosHeader;
        protected AlteracoesArquivo valoresAlteradosFooter;

        public TesteItens()
        {
            valoresAlteradosBody = new AlteracoesArquivo();
            valoresAlteradosHeader = new AlteracoesArquivo();
            valoresAlteradosFooter = new AlteracoesArquivo();
        }

        protected string pastaOrigem
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
        protected string pastaDestino
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

        protected string pastaLog
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
        
        protected string pastaLogArquivo
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

        protected ModoExecucaoEnum ModoExecucao
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
