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
            if (!Validar(lista.Count, ObterProceduresASeremExecutadas().Count * vezesExecutado, "Quantidade de Procedures executadas"))
                falha = true;
            if (!falha && !Validar((lista.All(x => x.ObterPorColuna("CD_STATUS").Valor == "S")), true, "Todos os CD_STATUS sao igual a 'S'"))
                falha = true;

            var proceduresEsperadas = ObterProceduresASeremExecutadas();
            var procedureNaoEncontrada = proceduresEsperadas.Where(x => !lista.Any(z => z.ObterPorColuna("CD_PROCEDURE").Valor.Contains(x))); //lista.Where(x => proceduresEsperadas.Any(z => x.ObterPorColuna("CD_PROCEDURE").Valor.Contains(z)) == false);
            if (!Validar(procedureNaoEncontrada.Count() > 0, false, $"Existem PROCEDURES NAO ENCONTRADAS : {procedureNaoEncontrada.ToList().ObterListaConcatenada(" ,")}"))
                falha = true;

            if (Sucesso && falha || !Sucesso && !falha)
            {
                ExplodeFalha();
            }
            logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, "Tabela:LogProcessamento");
        }

        public void ValidarTabelaDeRetorno(params string[] codigosDeErroEsperados)
        {
            AjustarEntradaErros(ref codigosDeErroEsperados);

            var consulta = MontarConsultaParaTabelaDeRetorno(tipoArquivoTeste.ObterTabelaEnum());

            var lista = ChamarConsultaAoBanco<LinhaTabelaRetorno>(consulta);

            logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");

            var txtErrosEsperados = codigosDeErroEsperados.Length == 0 ? "NENHUM" : codigosDeErroEsperados.ToList().ObterListaConcatenada(", ");
            var txtErrosEncontrados = lista.Select(x => x.ObterPorColuna("CD_MENSAGEM").Valor).ToList().ObterListaConcatenada(", ");
            logger.Escrever($"Erros esperados na tabela de retorno: {txtErrosEsperados}");
            logger.Escrever($"Erros encontrados na tabela de retorno: {txtErrosEncontrados}");

            if(codigosDeErroEsperados.Length == 0 && lista.Count > 0 || codigosDeErroEsperados.Length > 0 && codigosDeErroEsperados.Length == 0)
            {
                logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, "ERROS ESPERADOS NÃO FORAM OS ERROS OBTIDOS.");
                ExplodeFalha();
            }

            foreach (var linhaEncontrada in lista)
            {
                if (!codigosDeErroEsperados.Contains(linhaEncontrada.ObterPorColuna("CD_MENSAGEM").Valor.ToUpper()))
                {
                    logger.EscreverBloco("VALIDAÇÃO ESPERADA NA TABELA DE RETORNO NAO ENCONTRADA."
                       + $"{Environment.NewLine} MENSAGENS ESPERADAS : {txtErrosEsperados}"
                       + $"{Environment.NewLine} MENSAGENS OBTIDAS : {txtErrosEncontrados}");

                    ExplodeFalha();
                }
            }
            logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");

        }
        private Consulta MontarConsultaParaTabelaDeRetorno(TabelasEnum tabela)
        {
            if (valoresAlteradosBody.Alteracoes.Count == 0)
                throw new Exception("NENHUMA LINHA ALTERADA OU SELECIONADA.");

            var consulta = FabricaConsulta.MontarConsultaParaTabelaDeRetorno(tabela, nomeArquivo, valoresAlteradosBody);
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

        protected void ExplodeFalha()
        {
            sucessoDoTeste = false;
            logger.TesteComFalha();
            Assert.Fail();
        }

        protected bool Validar(bool obtido, bool esperado, string tituloValidacao)
        {
            logger.EscreveValidacao(obtido.ToString(), esperado.ToString(), tituloValidacao);

            if (esperado == obtido)
                return true;
            return false;
        }

        protected bool Validar(int obtido, int esperado, string tituloValidacao)
        {
            logger.EscreveValidacao(obtido.ToString(), esperado.ToString(), tituloValidacao);

            if (esperado == obtido)
                return true;
            return false;
        }
    }
}
