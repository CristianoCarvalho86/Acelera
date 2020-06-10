using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Utils
{
    public class ControleCDContratoFG03
    {
        private static ControleCDContratoFG03 instancia;
        private string enderecoArquivo;
        private ControleCDContratoFG03()
        {
            enderecoArquivo = ConfigurationManager.AppSettings["PastaControleCdContrato"];
            if (!File.Exists(enderecoArquivo))
                throw new Exception("Controle Arquivo nao encontrado.");
        }

        public static ControleCDContratoFG03 Instancia
        {
            get
            {
                try
                {
                    if (instancia == null)
                    {
                        instancia = new ControleCDContratoFG03();
                    }
                    return instancia;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao obter Instancia de Controle CD Contrato");
                }
            }
        }

        public IList<string> ObterContratosUtilizados()
        {
            return File.ReadAllText(enderecoArquivo).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public bool ValidaContrato(string cdContrato)
        {
            var valoresAtuais = ObterContratosUtilizados();
            if (valoresAtuais.Contains(cdContrato))
                return false;

            AtualizaArquivo(cdContrato);

            return true;
        }

        public void AtualizaArquivo(string cdContrato)
        {
            StreamWriter writer = null;
            try
            {
                writer = File.AppendText(enderecoArquivo);
                writer.WriteLine(cdContrato);
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO AO ATUALIZAR VALOR NO CONTROLE ARQUIVO CD CONTRATO. : " + ex.ToString());
            }
            finally
            {
                writer.Close();
            }

        }

    }
}
