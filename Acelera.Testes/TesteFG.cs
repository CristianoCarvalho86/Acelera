using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.TabelaRetorno;
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
    public abstract class TesteFG : TesteBase
    {
        protected abstract IList<string> ObterProceduresASeremExecutadas();

        public void ValidarLogProcessamento(bool Sucesso, int vezesExecutado = 1)
        {
            var consulta = new Consulta();
            consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);
            var lista = ChamarConsultaAoBanco<LinhaLogProcessamento>(consulta);

            logger.InicioOperacao(OperacaoEnum.ValidarResultado, "Tabela:LogProcessamento");

            var falha = false;
            if (!Validar(ObterProceduresASeremExecutadas().Count * vezesExecutado, lista.Count, "Quantidade de Procedures executadas"))
                falha = true;
            if (!Validar((lista.Any(x => x.ObterPorColuna("CD_STATUS").Valor == "E")).ToString(), false, "Todos os CD_STATUS sao igual a 'S'"))
                falha = true;

            var proceduresEsperadas = ObterProceduresASeremExecutadas();
            var procedureNaoEncontrada = lista.Where(x => proceduresEsperadas.Any(z => z == x.ObterPorColuna("CD_PROCEDURE").Valor) == false);
            if (!Validar(procedureNaoEncontrada.Count() == 0, true, $"PROCEDURES {procedureNaoEncontrada.Select(x => x.ObterPorColuna("CD_PROCEDURE").Valor).ToList().ObterListaConcatenada(" ,")} NAO ENCONTRADAS"))
                falha = true;

            if (Sucesso && falha || !Sucesso && !falha)
            {
                logger.TesteComFalha();
                Assert.Fail();
            }
            logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, "Tabela:LogProcessamento");
        }

        public void ValidarTabelaDeRetorno(params string[] errosEsperados)
        {
            AjustarEntradaErros(ref errosEsperados);

            var consulta = MontarConsultaParaTabelaDeRetorno(TabelasEnum.TabelaRetorno);

            var lista = ChamarConsultaAoBanco<LinhaTabelaRetorno>(consulta);
            logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
            logger.Escrever($"Erros esperados na tabela de retorno {errosEsperados.ToList().ObterListaConcatenada(", ")}");
            foreach (var linhaEncontrada in lista)
            {
                if (!errosEsperados.Contains(linhaEncontrada.ObterPorColuna("CD_MENSAGEM").Valor.ToUpper()))
                {
                    var mensagesObtidas = lista.Select(x => x.ObterPorColuna("CD_MENSAGEM").Valor).ToList().ObterListaConcatenada(", ");

                    logger.EscreverBloco("VALIDAÇÃO ESPERADA NA TABELA DE RETORNO NAO ENCONTRADA."
                       + $"{Environment.NewLine} MENSAGENS ESPERADAS : {errosEsperados.ToList().ObterListaConcatenada(", ")}"
                       + $"{Environment.NewLine} MENSAGENS OBTIDAS : {mensagesObtidas}");

                    ExplodeFalha(logger);
                }
            }
            logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");

        }
        private Consulta MontarConsultaParaTabelaDeRetorno(TabelasEnum tabela)
        {
            if (valoresAlteradosBody.Alteracoes.Count == 0)
                throw new Exception("NENHUMA LINHA ALTERADA OU SELECIONADA.");

            var consulta = FabricaConsulta.MontarConsultaParaTabelaDeRetorno(tabela, valoresAlteradosBody);
            AdicionaConsultaDoBody(consulta);
            return consulta;
        }

        protected void AjustarEntradaErros(ref string[] erros)
        {
            if (erros.Length == 1 && erros.Contains(string.Empty))
                erros = new string[] { };

        }

        protected void AdicionaConsultaDoBody(Consulta consulta)
        {
            foreach (var c in valoresAlteradosBody.Alteracoes)
                foreach (var item in c.CamposAlterados)
                    consulta.AdicionarConsulta(item.Coluna, item.Valor);
        }

        protected void ExplodeFalha(MyLogger logger)
        {
            sucessoDoTeste = false;
            logger.TesteComFalha();
            Assert.Fail();
        }

        protected bool Validar(object esperado, object obtido, string tituloValidacao)
        {
            logger.EscreveValidacao(obtido.ToString(), esperado.ToString(), tituloValidacao);

            if (esperado == obtido)
                return true;
            return false;
        }
    }
}
