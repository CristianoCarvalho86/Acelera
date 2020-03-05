using Acelera.Domain.Entidades;
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
        public ValidadorStagesFG01(TabelasEnum tabelaEnum, string nomeArquivo, MyLogger logger, AlteracoesArquivo valoresAlteradosBody, AlteracoesArquivo valoresAlteradosHeader, AlteracoesArquivo valoresAlteradosFooter)
        : base(tabelaEnum, nomeArquivo, logger, valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter)
        {

        }

        public bool ValidarTabelaFG01(bool deveHaverRegistro, int codigoEsperado = 0)
        {
            var linhas = new List<ILinhaTabela>();
            if (!ValidarTabelaFG00(deveHaverRegistro, out linhas, codigoEsperado))
                return false;

            var qtdRegistrosEsperados = ObterQtdRegistrosEsperados();
            if (linhas.Count != qtdRegistrosEsperados)
            {
                logger.EscreverBloco($"Eram esperados {qtdRegistrosEsperados} registros na tabela : {tabelaEnum.ObterTexto()}" +
                    $" {Environment.NewLine} Foram encontrados: {linhas.Count}");
                return false;
            }
            return true;

        }

        private int ObterQtdRegistrosEsperados()
        {
            if (valoresAlteradosBody != null && valoresAlteradosBody.Alteracoes.Count > 0)
                return valoresAlteradosBody.Alteracoes.First().RepeticoesLinha - 1;
            return 1;
        }

    }
}
