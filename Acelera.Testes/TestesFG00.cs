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

            if (falha && descricaoErroSeHouver.Length == 0 || !falha && descricaoErroSeHouver.Length > 0)
                ExplodeFalha(logger);

            if (falha)
            {
                foreach (var descricao in descricaoErroSeHouver)
                    if (!lista.Any(x => x.ObterPorColuna("DS_ERRO").Valor.ToUpper() == descricao.ToUpper()))
                        ExplodeFalha(logger);
            }
        }

        private IList<string> ObterProceduresASeremExecutadas()
        {
            var lista = new List<string>();
            lista.Add("PRC_0093_IMP");
            lista.Add("PRC_0094_IMP");
            lista.Add("PRC_0101_IMP");
            lista.Add("PRC_0002_IMP");
            lista.Add("PRC_0091_IMP");
            lista.Add("PRC_0400_IMP");
            lista.Add("PRC_0003_IMP");
            lista.Add("PRC_0004_IMP");
            lista.Add("PRC_0100_IMP");
            lista.Add("PRC_0095_IMP");
            return lista;
        }

        private void ExplodeFalha(MyLogger logger)
        {
            logger.TesteComFalha();
            Assert.Fail();
        }
    }
}
