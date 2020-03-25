using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using Acelera.Testes.DataAccessRep;
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

        protected void AdicionaConsulta(Consulta consulta, AlteracoesArquivo valoresAlterados, bool ehStage)
        {
            if (valoresAlterados != null)
                foreach (var c in valoresAlterados.Alteracoes)
                    foreach (var item in c.CamposAlterados)
                    {
                        var campo = item.Coluna;
                        if (ehStage && campo == "NR_APOLICE")
                            campo = "CD_CONTRATO";
                        consulta.AdicionarConsulta(campo, item.Valor);
                    }
        }

        protected bool ValidarCodigosDeErro(TabelasEnum tabelaDaValidacao ,IList<ILinhaTabela> lista, string colunaMsg,params string[] codigosDeErroEsperados)
        {
            var txtErrosEsperados = codigosDeErroEsperados.Length == 0 ? "NENHUM" : codigosDeErroEsperados.ToList().ObterListaConcatenada(", ");
            var txtErrosEncontrados = lista.Select(x => x.ObterPorColuna(colunaMsg).Valor).Distinct().ToList().ObterListaConcatenada(", ");
            logger.Escrever($"Erros esperados na {tabelaDaValidacao.ObterTexto()}: {txtErrosEsperados}");
            logger.Escrever($"Erros encontrados na tabela de {tabelaDaValidacao.ObterTexto()}: {txtErrosEncontrados}");

            if (codigosDeErroEsperados.Length == 0 && lista.Count > 0 || codigosDeErroEsperados.Length > 0 && lista.Count == 0)
            {
                logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, "ERROS ESPERADOS NÃO FORAM OS ERROS OBTIDOS.");
                return false;
            }

            foreach (var erro in codigosDeErroEsperados)
            {
                var encontrados = lista.Where(x => x.ObterPorColuna(colunaMsg).Valor.ToUpper() == erro.ToUpper());
                if (encontrados.Count() == 0)
                {
                    logger.EscreverBloco($"Mensagem de erro esperada não encontrada :'{erro}'");
                    return false;
                }
                if (encontrados.Count() > 1)
                {
                    logger.EscreverBloco($"Mensagem de erro esperada encontrada {encontrados.Count()} vezes :'{erro}'");
                }
            }

            var errosNaoEsperados = lista.Where(x => !codigosDeErroEsperados.Contains(x.ObterPorColuna(colunaMsg).Valor.ToUpper()));
            if (errosNaoEsperados.Count() > 0)
            {
                var listaDeErrosNaoEsperados = errosNaoEsperados.Select(x => x.ObterPorColuna(colunaMsg).Valor).Distinct();
                foreach (var erro in listaDeErrosNaoEsperados)
                {
                    logger.EscreverBloco($"Mensagem de erro NAO ESPERADA encontrada {errosNaoEsperados.Count(x => x.ObterPorColuna(colunaMsg).Valor.ToUpper() == erro)} vezes :'{erro}'");
                }
            }

            return true;

        }

        protected IList<ILinhaTabela> ObterLinhasParaStage(Consulta consulta)
        {
            var linhas = new List<ILinhaTabela>();
            if (tabelaEnum == TabelasEnum.Cliente)
                linhas = DataAccess.ChamarConsultaAoBanco<LinhaClienteStage>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();
            else if (tabelaEnum == TabelasEnum.Comissao)
                linhas = DataAccess.ChamarConsultaAoBanco<LinhaComissaoStage>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();
            else if (tabelaEnum == TabelasEnum.LanctoComissao)
                linhas = DataAccess.ChamarConsultaAoBanco<LinhaLanctoComissaoStage>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();
            else if (tabelaEnum == TabelasEnum.OCRCobranca)
                linhas = DataAccess.ChamarConsultaAoBanco<LinhaOCRCobrancaStage>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();
            else if (tabelaEnum == TabelasEnum.ParcEmissao)
                linhas = DataAccess.ChamarConsultaAoBanco<LinhaParcEmissaoStage>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();
            else if (tabelaEnum == TabelasEnum.ParcEmissaoAuto)
                linhas = DataAccess.ChamarConsultaAoBanco<LinhaParcEmissaoAutoStage>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();
            else if (tabelaEnum == TabelasEnum.Sinistro)
                linhas = DataAccess.ChamarConsultaAoBanco<LinhaSinistroStage>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();
            else
                throw new Exception("TIPO DE TABELA DE CONSULTA NAO ENCONTRADO.");

            return linhas;

        }

        protected int ObterQtdRegistrosDuplicadosDoBody()
        {
            if (valoresAlteradosBody != null && valoresAlteradosBody.Alteracoes.Count > 0 && valoresAlteradosBody.Alteracoes.First().RepeticoesLinha > 1)
                return valoresAlteradosBody.Alteracoes.First().RepeticoesLinha - 1;
            return 1;
        }

        protected int ObterQtdRegistrosDuplicadosHeaderAndFooter()
        {
            var qtd = 0;
            if (valoresAlteradosHeader != null && valoresAlteradosHeader.Alteracoes.Count > 0 && valoresAlteradosHeader.Alteracoes.First().RepeticoesLinha > 1)
                qtd += valoresAlteradosHeader.Alteracoes.First().RepeticoesLinha;
            if (valoresAlteradosFooter != null && valoresAlteradosFooter.Alteracoes.Count > 0 && valoresAlteradosFooter.Alteracoes.First().RepeticoesLinha > 1)
                qtd += valoresAlteradosFooter.Alteracoes.First().RepeticoesLinha;
            return qtd;
        }

        protected bool ExisteAlteracaoHeaderOuFooter()
        {
            if ((valoresAlteradosHeader != null && valoresAlteradosHeader.Alteracoes.Count > 0) ||
                (valoresAlteradosFooter != null && valoresAlteradosFooter.Alteracoes.Count > 0) ||
                (valoresAlteradosBody != null && valoresAlteradosBody.Alteracoes.Count > 0 &&
                (valoresAlteradosBody.Alteracoes.First().SemHeaderOuFooter || valoresAlteradosBody.Alteracoes.First().NomeArquivoAlterado)))
                return true;
            return false;
        }

        protected bool ExistemLinhasNoArquivo()
        {
            if (valoresAlteradosBody != null && valoresAlteradosBody.Alteracoes.Count > 0)
                return true;
            return false;
        }

        public abstract Consulta MontarConsulta(TabelasEnum tabela);

        public abstract void TratarConsulta(Consulta consulta);

    }
}
