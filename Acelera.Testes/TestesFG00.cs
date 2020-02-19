using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public abstract class TestesFG00 : TesteBase
    {
        public void ValidarLogProcessamento(string nomeArquivo, bool devePassar, MyLogger logger)
        {
            var consulta = new Consulta();
            consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);
            var lista = ChamarValidacao<LinhaLogProcessamento>(consulta, logger);

            var falha = false;
            if (!Validar("10", lista.Count.ToString(), "Quantidade de Procedures executadas", logger))
                falha = true;
            if (!Validar((lista.Any(x => x.ObterPorColuna("CD_STATUS").Valor == "N")).ToString(), "false", "Todos os CD_STATUS sao igual a 'S'", logger))
                falha = true;

            if (devePassar && falha || !devePassar && !falha)
            {
                logger.TesteComFalha();
                Assert.Fail();
            }
        }

        public void ValidarControleArquivo(string nomeArquivo, string[] descricaoErroSeHouver, MyLogger logger)
        {
            var consulta = new Consulta();
            consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);
            var lista = ChamarValidacao<LinhaControleArquivo>(consulta, logger);

            var falha = false;
            if (!Validar("10", lista.Count.ToString(), "Quantidade de Procedures executadas", logger))
                falha = true;
            if (!Validar((lista.Any(x => x.ObterPorColuna("ST_STATUS").Valor == "E")).ToString(), "false", "Todos os CD_STATUS sao igual a 'S'", logger))
                falha = true;

            if (string.IsNullOrEmpty(descricaoErroSeHouver) && falha || !string.IsNullOrEmpty(descricaoErroSeHouver) && !falha)
            {
                logger.TesteComFalha();
                Assert.Fail();
            }
        }
    }
}
