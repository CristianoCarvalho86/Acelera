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
    public class ValidadorStagesFG02 : ValidadorStagesFG01
    {
        public ValidadorStagesFG02(TabelasEnum tabelaEnum, string nomeArquivo, IMyLogger logger, AlteracoesArquivo valoresAlteradosBody, AlteracoesArquivo valoresAlteradosHeader, AlteracoesArquivo valoresAlteradosFooter)
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
                    var alteracoesPorLinha = valoresAlteradosBody.AlteracoesPorLinha(linha);
                    foreach(var alteracao in alteracoesPorLinha)
                    {
                        var consulta = consultaBase.Where(x => x.Key == alteracao.PosicaoDaLinha).First().Value;
                        AdicionaConsulta(consulta, alteracao, true);
                        consultas.AdicionarConsulta(consulta);
                    }
                }
            }
            else
            {
                consultas.AdicionarConsulta(consultaBase.First().Value);
            }

            consultas.AdicionarOrderBy(" ORDER BY DT_MUDANCA DESC ");

            return consultas;
        }

        public bool ValidarTabelaFG02(bool deveHaverRegistro, int codigoEsperado = 0, bool aoMenosUmComCodigoEsperado = false)
        {
            AoMenosUmComCodigoEsperado = aoMenosUmComCodigoEsperado;
            var linhas = new List<ILinhaTabela>();
            return base.ValidarTabelaFG00(deveHaverRegistro, out linhas, codigoEsperado);
        }

        public override bool ValidaStatusProcessamento(IList<ILinhaTabela> linhas, int codigoEsperado)
        {
            return base.ValidaStatusProcessamento(linhas, codigoEsperado);
        }

    }
}
