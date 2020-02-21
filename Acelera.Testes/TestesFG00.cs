using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
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
        public void ValidarLogProcessamento(bool devePassar)
        {
            var consulta = new Consulta();
            consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);
            var lista = ChamarConsultaAoBanco<LinhaLogProcessamento>(consulta);

            var falha = false;
            if (!Validar(10, lista.Count, "Quantidade de Procedures executadas"))
                falha = true;
            if (!Validar((lista.Any(x => x.ObterPorColuna("CD_STATUS").Valor == "N")).ToString(), false, "Todos os CD_STATUS sao igual a 'S'"))
                falha = true;

            var proceduresEsperadas = ObterProceduresASeremExecutadas();
            var procedureNaoEncontrada = lista.Where(x => proceduresEsperadas.Any(z => z == x.ObterPorColuna("CD_PROCEDURE").Valor) == false);
            if (!Validar(procedureNaoEncontrada.Count() == 0, true, $"PROCEDURES {procedureNaoEncontrada.Select(x => x.ObterPorColuna("CD_PROCEDURE").Valor).ToList().ObterListaConcatenada(" ,")} NAO ENCONTRADAS"))
                falha = true;

            if (devePassar && falha || !devePassar && !falha)
            {
                logger.TesteComFalha();
                Assert.Fail();
            }
        }

        public void ValidarControleArquivo(string[] descricaoErroSeHouver)
        {
            var consulta = new Consulta();
            consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);
            var lista = ChamarConsultaAoBanco<LinhaControleArquivo>(consulta);

            var falha = false;
            if (!Validar("10", lista.Count.ToString(), "Quantidade de Procedures executadas"))
                falha = true;
            if (!Validar((lista.Any(x => x.ObterPorColuna("ST_STATUS").Valor == "E")).ToString(), "false", "Todos os CD_STATUS sao igual a 'S'"))
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

        public void ValidarStages(TabelasEnum tabela)
        {
            var consulta = new Consulta();
            if (tabela == TabelasEnum.Cliente)
                consulta.AdicionarConsulta("CD_CLIENTE")

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
