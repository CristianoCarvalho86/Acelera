using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using Acelera.Testes.Validadores.FG00;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.Validadores.FG01
{
    public class ValidadorStagesFG01 : ValidadorStagesFG00
    {
        protected bool AoMenosUmComCodigoEsperado = false;
        public ValidadorStagesFG01(TabelasEnum tabelaEnum, string nomeArquivo, MyLogger logger, AlteracoesArquivo valoresAlteradosBody, AlteracoesArquivo valoresAlteradosHeader, AlteracoesArquivo valoresAlteradosFooter)
        : base(tabelaEnum, nomeArquivo, logger, valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter)
        {

        }

        public override Consulta MontarConsulta(TabelasEnum tabela)
        {
            var consulta = FabricaConsulta.MontarConsultaParaStage(tabela, nomeArquivo, valoresAlteradosBody, false, ExistemLinhasNoArquivo());
            var alteracaoHeader = valoresAlteradosHeader?.Alteracoes?.FirstOrDefault()?.CamposAlterados.Where(x => x.ColunaArquivo == "CD_TPA").FirstOrDefault();
            if (alteracaoHeader != null)
                AdicionaConsulta(consulta, valoresAlteradosHeader,true);

            if (valoresAlteradosBody != null && valoresAlteradosBody.ExisteAlteracaoValida())
                AdicionaConsulta(consulta, valoresAlteradosBody,true);
            consulta.AdicionarOrderBy(" ORDER BY DT_MUDANCA DESC ");

            return consulta;
        }

        public bool ValidarTabelaFG01(bool deveHaverRegistro, int codigoEsperado = 0, bool aoMenosUmComCodigoEsperado = false)
        {
            AoMenosUmComCodigoEsperado = aoMenosUmComCodigoEsperado;
            var linhas = new List<ILinhaTabela>();
            return base.ValidarTabelaFG00(deveHaverRegistro, out linhas, codigoEsperado);
        }

        public override bool ValidaStatusProcessamento(IList<ILinhaTabela> linhas, int codigoEsperado)
        {
            var linhasComProblema = linhas.Where(x => x.ObterPorColuna("CD_STATUS_PROCESSAMENTO").Valor != codigoEsperado.ToString());
            if (AoMenosUmComCodigoEsperado)
            {
                if (linhasComProblema.Any(x => x.ObterPorColuna("CD_STATUS_PROCESSAMENTO").Valor == codigoEsperado.ToString()))
                    linhasComProblema = new List<ILinhaTabela>();
            }

            if (linhasComProblema.Count() > 0 && !AoMenosUmComCodigoEsperado)
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
