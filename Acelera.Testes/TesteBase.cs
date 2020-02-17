using Acelera.Domain.Enums;
using Acelera.Logger;
using Acelera.Testes.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    [TestClass]
    public abstract class TesteBase
    {

        IntegracaoCMD integracao;
        private string pastaOrigem
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
        private string pastaDestino
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

        private string comandoExecutar
        {
            get
            {
                return $"hdbsql -n {serverHana} -u {usuarioHana} -p {senhaHana} -e \"select host from m_database\"";
            }
        }

        private string comandoSelect
        {
            get
            {
                return $"hdbsql -n {serverHana} -u {usuarioHana} -p {senhaHana} -e \"select host from m_database\"";
            }
        }

        private string usuarioHana
        {
            get
            {
                var usuario = ConfigurationManager.AppSettings.Get("UsuarioHana");
                if (string.IsNullOrEmpty(usuario))
                    throw new Exception("Usuario Hana nao definido");
                return usuario;
            }
        }

        private string senhaHana
        {
            get
            {
                var senha = ConfigurationManager.AppSettings.Get("SenhaHana");
                if (string.IsNullOrEmpty(senha))
                    throw new Exception("Senha Hana nao definida");
                return senha;
            }
        }

        private string serverHana
        {
            get
            {
                var server = ConfigurationManager.AppSettings.Get("ServerHana");
                if (string.IsNullOrEmpty(server))
                    throw new Exception("Endereco do Servidor Hana nao definido");
                return server;
            }
        }

        protected string ObterArquivoOrigem(string nomeArquivo)
        {
            return pastaOrigem + nomeArquivo;
        }

        protected string ObterArquivoDestino(string nomeArquivo)
        {
            return pastaDestino + nomeArquivo;
        }

        protected void ChamarExecucao(MyLogger logger)
        {
            logger.InicioOperacao(OperacaoEnum.Processar);
            try
            {
                integracao = new IntegracaoCMD();
                integracao.AbrirCMD();
                integracao.ChamarAplicativo();
                logger.SucessoDaOperacao(OperacaoEnum.Processar);
            }
            catch (Exception ex)
            {
                logger.Erro(ex);
                throw;
            }
        }

        protected string ObterRetornoUltimoMetodo()
        {
            return "";
        }
    }
}
