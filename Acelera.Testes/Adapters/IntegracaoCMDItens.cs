using Acelera.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.Adapters
{
    public abstract class IntegracaoCMDItens
    {
        protected string comandoExecutar
        {
            get
            {
                return $"hdbsql -n {serverHana} -u {usuarioHana} -p {senhaHana} -e \"EXEC 'START TASK FGR_XXXXXX'\"";
            }
        }

        private string comandoSelect
        {
            get
            {
                return $"hdbsql -n {serverHana} -u {usuarioHana} -p {senhaHana} -e \"[ALTERAR]\"";
            }
        }

        protected string usuarioHana
        {
            get
            {
                var usuario = ConfigurationManager.AppSettings.Get("UsuarioHana");
                if (string.IsNullOrEmpty(usuario))
                    throw new Exception("Usuario Hana nao definido");
                return usuario;
            }
        }

        protected string senhaHana
        {
            get
            {
                var senha = ConfigurationManager.AppSettings.Get("SenhaHana");
                if (string.IsNullOrEmpty(senha))
                    throw new Exception("Senha Hana nao definida");
                return senha;
            }
        }

        protected string serverHana
        {
            get
            {
                var server = ConfigurationManager.AppSettings.Get("ServerHana");
                if (string.IsNullOrEmpty(server))
                    throw new Exception("Endereco do Servidor Hana nao definido");
                return server;
            }
        }
        
        protected string EnderecoHDB
        {
            get
            {
                var hdb = ConfigurationManager.AppSettings.Get("EnderecoHDB");
                if (string.IsNullOrEmpty(hdb))
                    throw new Exception("Endereco do HDB Client nao definido");
                return hdb;
            }
        }

        protected string ObterComandoSelect(string queryValidacao)
        {
            return comandoSelect.Replace("[ALTERAR]", queryValidacao);
        }
    }
}
