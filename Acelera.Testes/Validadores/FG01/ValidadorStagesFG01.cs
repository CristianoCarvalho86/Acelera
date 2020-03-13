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
        public ValidadorStagesFG01(TabelasEnum tabelaEnum, string nomeArquivo, MyLogger logger, AlteracoesArquivo valoresAlteradosBody, AlteracoesArquivo valoresAlteradosHeader, AlteracoesArquivo valoresAlteradosFooter)
        : base(tabelaEnum, nomeArquivo, logger, valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter)
        {

        }

        public override Consulta MontarConsulta(TabelasEnum tabela)
        {
            return base.MontarConsulta(tabela);
        }

        public bool ValidarTabelaFG01(bool deveHaverRegistro, int codigoEsperado = 0)
        {
            var linhas = new List<ILinhaTabela>();
            return base.ValidarTabelaFG00(deveHaverRegistro, out linhas, codigoEsperado);
        }

        public override bool ValidaStatusProcessamento(IList<ILinhaTabela> linhas, int codigoEsperado)
        {
            var sucesso = false;
            foreach (var linha in linhas)
            {
                if (linha.ObterPorColuna("CD_STATUS_PROCESSAMENTO").Valor != codigoEsperado.ToString())
                {
                    sucesso = false;
                    logger.EscreverBloco($"O CODIGO DA LINHA ENCONTRADA NA TABELA {tabelaEnum.ObterTexto()} NAO CORRESPONDE AO ESPERADO {Environment.NewLine}" +
                        $"ESPERADO : {codigoEsperado.ToString()} , OBTIDO : {linha.ObterPorColuna("CD_STATUS_PROCESSAMENTO")}");
                    return false;
                }
                else
                {
                    logger.Escrever($"Codigo Esperado na tabela {tabelaEnum.ObterTexto()} encontrado com sucesso : {codigoEsperado.ToString()}");
                }
            }
            return true;
        }

    }
}
