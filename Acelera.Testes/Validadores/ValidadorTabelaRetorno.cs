using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.TabelaRetorno;
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
    public class ValidadorTabelaRetorno : ValidadorTabela
    {
        public ValidadorTabelaRetorno(TabelasEnum tabelaEnum, string nomeArquivo, IMyLogger logger, AlteracoesArquivo valoresAlteradosBody, AlteracoesArquivo valoresAlteradosHeader, AlteracoesArquivo valoresAlteradosFooter) 
            : base(tabelaEnum, nomeArquivo, logger, valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter)
        {
        }

        public override ConjuntoConsultas MontarConsulta(TabelasEnum tabela)
        {
            var consultaBase = FabricaConsulta.MontarConsultaParaTabelaDeRetorno(tabela, nomeArquivo, valoresAlteradosBody);
            var consultas = new ConjuntoConsultas();

            if (valoresAlteradosBody != null && valoresAlteradosBody.ExisteAlteracaoValida())
            {
                var linhasAlteradas = consultaBase.Select(x => x.Key).Distinct().ToList();
                foreach (var linha in linhasAlteradas)
                {
                    var consulta = consultaBase.Where(x => x.Key == linha).First().Value;
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

        public bool ValidarTabela(TabelasEnum tabela, bool naoDeveEncontrar, bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados)
        {
            AjustarEntradaErros(ref codigosDeErroEsperados);

            var consulta = MontarConsulta(tabelaEnum);

            List<ILinhaTabela> linhasEncontradas;
            linhasEncontradas = DataAccess.ChamarConsultaAoBanco<LinhaTabelaRetorno>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();

            var qtd = ObterQtdRegistrosDuplicadosHeaderAndFooter();
            if (qtd == 0)
                qtd = 1;

            if (codigosDeErroEsperados.Length == 0)
                qtd = 0;

            if (linhasEncontradas.Count < qtd && !naoDeveEncontrar)
            {
                logger.EscreverBloco($"ERAM ESPERADOS :{qtd}, FORAM ENCONTRADOS: {linhasEncontradas.Count} registros");
                return false;
            }

            var linhasEncontradasDoTipoEsperado = linhasEncontradas.Where(x => codigosDeErroEsperados.Contains(x.ObterPorColuna("CD_MENSAGEM").ValorFormatado)).ToList();

            if (validaQuantidadeErros && (linhasEncontradasDoTipoEsperado.Count != codigosDeErroEsperados.Length))
            {
                logger.EscreverBloco($"ERAM ESPERADOS :{codigosDeErroEsperados.Length} NA {tabela.ObterTexto()} MAS FORAM ENCONTRADAS :{linhasEncontradasDoTipoEsperado.Count}");
                return false;
            }
            else if (validaQuantidadeErros && linhasEncontradasDoTipoEsperado.Count == codigosDeErroEsperados.Length)
            {
                logger.EscreverBloco($"ERAM ESPERADOS :{codigosDeErroEsperados.Length} NA {tabela.ObterTexto()} , FORAM ENCONTRADAS :{linhasEncontradasDoTipoEsperado.Count} - OK");
            }

            if (naoDeveEncontrar)
                return ValidarCodigosDeErroNaoForamEncontrados(TabelasEnum.TabelaRetorno, linhasEncontradas, "CD_MENSAGEM", codigosDeErroEsperados);

            return ValidarCodigosDeErro(TabelasEnum.TabelaRetorno, linhasEncontradas, "CD_MENSAGEM", codigosDeErroEsperados);
        }

    }
}
