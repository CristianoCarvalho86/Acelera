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

namespace Acelera.Testes.Validadores.FG00
{
    public class ValidadorTabelaRetornoFG00 : ValidadorTabela
    {
        public ValidadorTabelaRetornoFG00(TabelasEnum tabelaEnum, string nomeArquivo, IMyLogger logger, AlteracoesArquivo valoresAlteradosBody, AlteracoesArquivo valoresAlteradosHeader, AlteracoesArquivo valoresAlteradosFooter) 
            :base(tabelaEnum, nomeArquivo,logger,valoresAlteradosBody,valoresAlteradosHeader,valoresAlteradosFooter)
        {
        }

        public override ConjuntoConsultas MontarConsulta(TabelasEnum tabela)
        {
            var consulta = FabricaConsulta.MontarConsultaParaTabelaDeRetornoFG00(tabela, nomeArquivo, valoresAlteradosBody, ExisteAlteracaoHeaderOuFooter(), ExistemLinhasNoArquivo());
            return new ConjuntoConsultas(consulta);
        }

        public override void TratarConsulta(Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public bool ValidarTabela(TabelasEnum tabela ,bool naoDeveEncontrar, bool validaQuantidadeErros = false,params string[] codigosDeErroEsperados)
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

            if (linhasEncontradas.Count < qtd)
            {
                logger.EscreverBloco($"ERAM ESPERADOS :{qtd}, FORAM ENCONTRADOS: {linhasEncontradas.Count} registros");
                return false;
            }

            var linhasEncontradasDoTipoEsperado = linhasEncontradas.Where(x => codigosDeErroEsperados.Contains(x.ObterPorColuna("CD_MENSAGEM").ValorFormatado)).ToList();

            if(validaQuantidadeErros && (linhasEncontradasDoTipoEsperado.Count != codigosDeErroEsperados.Length))
            {
                logger.EscreverBloco($"ERAM ESPERADOS :{codigosDeErroEsperados.Length} NA {tabela.ObterTexto()} MAS FORAM ENCONTRADAS :{linhasEncontradasDoTipoEsperado.Count}");
                return false;
            }
            else if(validaQuantidadeErros && linhasEncontradasDoTipoEsperado.Count == codigosDeErroEsperados.Length)
            {
                logger.EscreverBloco($"ERAM ESPERADOS :{codigosDeErroEsperados.Length} NA {tabela.ObterTexto()} , FORAM ENCONTRADAS :{linhasEncontradasDoTipoEsperado.Count} - OK");
            }

            if (naoDeveEncontrar)
                return ValidarCodigosDeErroNaoForamEncontrados(TabelasEnum.TabelaRetorno, linhasEncontradas, "CD_MENSAGEM", codigosDeErroEsperados);

            return ValidarCodigosDeErro(TabelasEnum.TabelaRetorno,linhasEncontradas, "CD_MENSAGEM", codigosDeErroEsperados);
        }
    }
}
