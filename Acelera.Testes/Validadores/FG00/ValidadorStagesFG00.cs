using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;

namespace Acelera.Testes.Validadores.FG00
{
    public class ValidadorStagesFG00 : ValidadorTabela
    {
        public ValidadorStagesFG00(TabelasEnum tabelaEnum, string nomeArquivo, MyLogger logger, AlteracoesArquivo valoresAlteradosBody, AlteracoesArquivo valoresAlteradosHeader, AlteracoesArquivo valoresAlteradosFooter)
            : base(tabelaEnum, nomeArquivo, logger, valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter)
        {
        }

        public bool ValidarTabelaFG00(bool deveHaverRegistro, out List<ILinhaTabela> linhas, int codigoEsperado = 0)
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
                return ValidaStatusProcessamento(linhas.First(), codigoEsperado);
            }

            return true;
        }

        public override Consulta MontarConsulta(TabelasEnum tabela)
        {
            var consulta = FabricaConsulta.MontarConsultaParaStage(tabela, nomeArquivo, valoresAlteradosBody);
            AdicionaConsulta(consulta,valoresAlteradosHeader);
            AdicionaConsulta(consulta,valoresAlteradosFooter);
            consulta.AdicionarOrderBy(" ORDER BY DT_MUDANCA DESC ");

            return consulta;
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

        public virtual bool ValidaStatusProcessamento(ILinhaTabela linha, int codigoEsperado)
        {
            if (linha.ObterPorColuna("CD_STATUS_PROCESSAMENTO").Valor != codigoEsperado.ToString())
            {
                logger.EscreverBloco($"O CODIGO DA LINHA ENCONTRADA NA TABELA {tabelaEnum.ObterTexto()} NAO CORRESPONDE AO ESPERADO {Environment.NewLine}" +
                    $"ESPERADO : {codigoEsperado.ToString()} , OBTIDO : {linha.ObterPorColuna("CD_STATUS_PROCESSAMENTO")}");
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
