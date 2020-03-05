using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.Validadores
{
    public abstract class ValidadorTabela
    {
        protected TabelasEnum tabelaEnum;
        protected MyLogger logger;
        protected string nomeArquivo;
        protected AlteracoesArquivo valoresAlteradosBody;
        protected AlteracoesArquivo valoresAlteradosHeader;
        protected AlteracoesArquivo valoresAlteradosFooter;
        public ValidadorTabela(TabelasEnum tabelasEnum, string nomeArquivo, MyLogger logger, AlteracoesArquivo valoresAlteradosBody, AlteracoesArquivo valoresAlteradosHeader, AlteracoesArquivo valoresAlteradosFooter)
        {
            this.tabelaEnum = tabelasEnum;
            this.nomeArquivo = nomeArquivo;
            this.logger = logger;
            this.valoresAlteradosBody = valoresAlteradosBody;
            this.valoresAlteradosHeader = valoresAlteradosHeader;
            this.valoresAlteradosFooter = valoresAlteradosFooter;
        }
        protected void AjustarEntradaErros(ref string[] erros)
        {
            if (erros.Length == 1 && erros.Contains(string.Empty))
                erros = new string[] { };

        }

        protected void AdicionaConsulta(Consulta consulta, AlteracoesArquivo valoresAlterados)
        {
            if(valoresAlterados != null)
            foreach (var c in valoresAlterados.Alteracoes)
                foreach (var item in c.CamposAlterados)
                    consulta.AdicionarConsulta(item.Coluna, item.Valor);
        }

        protected bool ValidarCodigosDeErro(IList<ILinhaTabela> lista, string colunaMsg,params string[] codigosDeErroEsperados)
        {
            var txtErrosEsperados = codigosDeErroEsperados.Length == 0 ? "NENHUM" : codigosDeErroEsperados.ToList().ObterListaConcatenada(", ");
            var txtErrosEncontrados = lista.Select(x => x.ObterPorColuna(colunaMsg).Valor).ToList().ObterListaConcatenada(", ");
            logger.Escrever($"Erros esperados na {tabelaEnum.ObterTexto()}: {txtErrosEsperados}");
            logger.Escrever($"Erros encontrados na tabela de {tabelaEnum.ObterTexto()}: {txtErrosEncontrados}");

            if (codigosDeErroEsperados.Length == 0 && lista.Count > 0 || codigosDeErroEsperados.Length > 0 && lista.Count == 0)
            {
                logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, "ERROS ESPERADOS NÃO FORAM OS ERROS OBTIDOS.");
                return false;
            }

            foreach (var linhaEncontrada in lista)
            {
                if (!codigosDeErroEsperados.Contains(linhaEncontrada.ObterPorColuna(colunaMsg).Valor.ToUpper()))
                {
                    logger.EscreverBloco($"VALIDAÇÃO ESPERADA NA {tabelaEnum.ObterTexto()} NAO ENCONTRADA."
                       + $"{Environment.NewLine} MENSAGENS ESPERADAS : {txtErrosEsperados}"
                       + $"{Environment.NewLine} MENSAGENS OBTIDAS : {txtErrosEncontrados}");

                    return false;
                }
            }
            return true;

        }

        public abstract Consulta MontarConsulta(TabelasEnum tabela);

    }
}
