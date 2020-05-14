using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using Acelera.Testes.Validadores.FG00;
using Acelera.Testes.Validadores.FG01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.Validadores.FG02
{
    public class ValidadorStages : ValidadorTabela
    {
        protected bool AoMenosUmComCodigoEsperado = false;
        public ValidadorStages(TabelasEnum tabelaEnum, string nomeArquivo, IMyLogger logger, AlteracoesArquivo valoresAlteradosBody, AlteracoesArquivo valoresAlteradosHeader, AlteracoesArquivo valoresAlteradosFooter)
        : base(tabelaEnum, nomeArquivo, logger, valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter)
        {

        }

        public override ConjuntoConsultas MontarConsulta(TabelasEnum tabela)
        {
            var consultaBase = FabricaConsulta.MontarConsultaParaStage(tabela, nomeArquivo, valoresAlteradosBody, false, ExistemLinhasNoArquivo());

            var consultas = new ConjuntoConsultas();

            var alteracaoHeader = valoresAlteradosHeader?.Alteracoes?.FirstOrDefault()?.CamposAlterados.Where(x => x.ColunaArquivo == "CD_TPA").FirstOrDefault();
            if (alteracaoHeader != null)
                AdicionaConsulta(consultaBase.First().Value, valoresAlteradosHeader,true);//NAO HAVERA ALTERAÇÕES NO HEADER E NAS LINHAS SIMULTANEAMENTE

            if (valoresAlteradosBody != null && valoresAlteradosBody.ExisteAlteracaoValida())
            {
                var linhasAlteradas = valoresAlteradosBody.LinhasAlteradas();
                foreach(var linha in linhasAlteradas)
                {
                    var alteracoesPorLinha = valoresAlteradosBody.AlteracoesPorLinha(linha).Where(x => x.CamposAlterados.Count > 0).First();
                    var consulta = consultaBase.Where(x => x.Key == alteracoesPorLinha.PosicaoDaLinha).First().Value;
                    AdicionaConsulta(consulta, alteracoesPorLinha, true);
                    consultas.AdicionarConsulta(consulta);
                }
            }
            else
            {
                consultas.AdicionarConsulta(consultaBase.First().Value);
            }

            consultas.AdicionarOrderBy(" ORDER BY DT_MUDANCA DESC ");

            return consultas;
        }

        public override void TratarConsulta(Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public bool ValidarTabela(bool deveHaverRegistro, int codigoEsperado = 0, bool aoMenosUmComCodigoEsperado = false)
        {
            AoMenosUmComCodigoEsperado = aoMenosUmComCodigoEsperado;
            var linhas = new List<ILinhaTabela>();
            return ValidarTabela(deveHaverRegistro, out linhas, codigoEsperado);
        }

        public bool ValidarTabela(bool deveHaverRegistro, out List<ILinhaTabela> linhas, int codigoEsperado = 0)
        {
            linhas = ObterLinhasParaStage(MontarConsulta(tabelaEnum)).ToList();

            logger.Escrever($"Deve encontrar registros na tabela {tabelaEnum.ObterTexto()} : {deveHaverRegistro}");
            logger.Escrever($"Foram encontrados {linhas.Count} registros.");

            if (!ValidaQuantidadeDeLinhas(deveHaverRegistro, linhas.Count))
            {
                return false;
            }
            else if (deveHaverRegistro)// VALIDA REGISTRO ENCONTRADO CONTEM CODIGO ESPERADO
            {
                return ValidaStatusProcessamento(linhas, codigoEsperado);
            }

            return true;
        }
        public virtual bool ValidaQuantidadeDeLinhas(bool deveHaverRegistros, int linhasEncontradas)
        {
            if (!deveHaverRegistros && linhasEncontradas > 0)// NAO DEVERIA ENCONTRAR REGISTROS MAS FORAM ENCONTRADOS
            {
                var linhasTexto = string.Empty;
                foreach (var l in linhasTexto)
                    linhasTexto += "LINHA : " + l.ToString() + Environment.NewLine;
                logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, $"NAO ERAM ESPERADOS REGISTRO NA TABELA STAGE DE {tabelaEnum.ObterTexto()}" +
                    $"{Environment.NewLine} LINHAS ENCONTRADAS : { linhasEncontradas })");
                return false;
            }
            else if (deveHaverRegistros && linhasEncontradas == 0)//DEVERIAM HAVER REGISTROS, MAS NAO FORAM ENCONTRADOS
            {
                logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, $"NAO FORAM ENCONTRADOS REGISTROS NA TABELA {tabelaEnum.ObterTexto()}");
                return false;
            }
            return true;
        }

        public virtual bool ValidaStatusProcessamento(IList<ILinhaTabela> linhas, int codigoEsperado)
        {
            if (AoMenosUmComCodigoEsperado)
                return ValidarAoMenosUmStatusCorreto(linhas, codigoEsperado);

            foreach (var linha in linhas)
            {
                if (linha.ObterPorColuna("CD_STATUS_PROCESSAMENTO").Valor != codigoEsperado.ToString())
                {
                    logger.EscreverBloco($"O CODIGO DA LINHA ENCONTRADA NA TABELA {tabelaEnum.ObterTexto()} NAO CORRESPONDE AO ESPERADO {Environment.NewLine}" +
                        $"ESPERADO : {codigoEsperado.ToString()} , OBTIDO : {linha.ObterPorColuna("CD_STATUS_PROCESSAMENTO").Valor}");
                    return false;
                }
                else
                {
                    logger.Escrever($"Codigo Esperado na tabela {tabelaEnum.ObterTexto()} encontrado com sucesso : {codigoEsperado.ToString()}");
                }
            }
            return true;
        }

        public bool ValidarAoMenosUmStatusCorreto(IList<ILinhaTabela> linhas, int codigoEsperado)
        {
            var linhasComProblema = linhas.Where(x => x.ObterPorColuna("CD_STATUS_PROCESSAMENTO").Valor != codigoEsperado.ToString());
            if (linhasComProblema.Any(x => x.ObterPorColuna("CD_STATUS_PROCESSAMENTO").Valor == codigoEsperado.ToString()))
                linhasComProblema = new List<ILinhaTabela>();

            if (linhasComProblema.Count() > 0)
            {
                logger.EscreverBloco($"O CODIGO DA LINHA ENCONTRADA NA TABELA {tabelaEnum.ObterTexto()} NAO CORRESPONDE AO ESPERADO {Environment.NewLine}" +
                    $"ESPERADO : {codigoEsperado.ToString()} , OBTIDO : {linhasComProblema.Select(x => x.ObterPorColuna("CD_STATUS_PROCESSAMENTO").Valor).ObterListaConcatenada(",")}");
                return false;
            }
            else
            {
                logger.Escrever($"Codigo Esperado na tabela {tabelaEnum.ObterTexto()} encontrado com sucesso : {codigoEsperado.ToString()}");
            }
            return true;
        }

    }
}
