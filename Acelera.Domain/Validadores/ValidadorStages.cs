﻿using Acelera.Contratos;
using Acelera.Domain;
using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Logger;
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
        public ValidadorStages(TabelasEnum tabelaEnum, string nomeArquivo, IMyLogger logger, IArquivo arquivo)
        : base(tabelaEnum, nomeArquivo, logger, arquivo)
        {

        }

        public override ConjuntoConsultas MontarConsulta(TabelasEnum tabela, IArquivo arquivo)
        {
            var consultas = new ConjuntoConsultas();
            try
            {
                var consultaBase = FabricaConsulta.MontarConsultaParaStage(tabela, nomeArquivo, arquivo.valoresAlteradosBody, false, ExistemLinhasNoArquivo());

                var alteracaoHeader = arquivo.valoresAlteradosHeader?.Alteracoes?.FirstOrDefault()?.CamposAlterados.Where(x => x.ColunaArquivo == "CD_TPA").FirstOrDefault();
                if (alteracaoHeader != null)
                    AdicionaConsulta(consultaBase.First().Value, arquivo.valoresAlteradosHeader, true);//NAO HAVERA ALTERAÇÕES NO HEADER E NAS LINHAS SIMULTANEAMENTE

                if (arquivo.valoresAlteradosBody != null && arquivo.valoresAlteradosBody.ExisteAlteracaoValidaParaOArquivo(nomeArquivo))
                {
                    var linhasAlteradas = arquivo.valoresAlteradosBody.LinhasAlteradasPorArquivo(nomeArquivo);
                    foreach (var linha in linhasAlteradas)
                    {
                        var alteracoesPorLinha = arquivo.valoresAlteradosBody.AlteracoesPorLinha(linha.Key, linha.Value).Where(x => x.CamposAlterados.Count > 0).FirstOrDefault();
                        if (alteracoesPorLinha == null)
                            continue;
                        var consulta = consultaBase.Where(x => x.Key == alteracoesPorLinha.PosicaoDaLinha).First().Value;
                        AdicionaConsulta(consulta, alteracoesPorLinha, true);
                        consultas.AdicionarConsulta(consulta);
                    }
                    if (linhasAlteradas.Count() == 0)
                        consultas.AdicionarConsulta(consultaBase.First().Value);
                }
                else
                    consultas.AdicionarConsulta(consultaBase.First().Value);

                consultas.AdicionarOrderBy(" ORDER BY DT_MUDANCA DESC ");
            }
            catch (Exception ex)
            {
                logger.Erro("VALIDACAO DA STAGE - " + ex.ToString());
                throw;
            }

            return consultas;
        }

        public override void TratarConsulta(Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public bool ValidarTabela(string[] Parametro, string[] Valores, string orderBy, int? codigoEsperado, out IList<ILinhaTabela> linhas, bool aoMenosUmComCodigoEsperado = false)
        {
            try
            {
                var campos = "";
                for (int i = 0; i < Parametro.Length; i++)
                {
                    campos += $"{Parametro[i]} = '{Valores[i]}' AND ";
                }
                campos = campos.Remove(campos.Length - 4);
                linhas = ObterLinhasParaStage($"select * FROM {Parametros.instanciaDB}.{tabelaEnum.ObterTexto()} WHERE {campos} ORDER BY {orderBy}").ToList();
                AoMenosUmComCodigoEsperado = aoMenosUmComCodigoEsperado;
                var deveHaverRegistro = codigoEsperado.HasValue ? true : false;
                logger.Escrever($"Deve encontrar registros na tabela {tabelaEnum.ObterTexto()} : {deveHaverRegistro}");
                logger.Escrever($"Foram encontrados {linhas.Count} registros.");

                if (!ValidaQuantidadeDeLinhas(deveHaverRegistro, linhas.Count))
                {
                    return false;
                }
                else if (deveHaverRegistro)// VALIDA REGISTRO ENCONTRADO CONTEM CODIGO ESPERADO
                {
                    return ValidaStatusProcessamento(linhas, codigoEsperado.Value);
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.Erro("ERRO EM ValidarTabela - ValidadorStage - ValidarTabela(string[] Parametro, string[] Valores, string orderBy, int? codigoEsperado, out IList<ILinhaTabela> linhas, bool aoMenosUmComCodigoEsperado = false)-" + ex.ToString());
                throw ex;
            }

        }

        public bool ValidarTabela(bool deveHaverRegistro, int codigoEsperado = 0, bool aoMenosUmComCodigoEsperado = false)
        {
            AoMenosUmComCodigoEsperado = aoMenosUmComCodigoEsperado;
            var linhas = new List<ILinhaTabela>();
            return ValidarTabela(deveHaverRegistro, out linhas, codigoEsperado);
        }

        public bool ValidarTabela(bool deveHaverRegistro, out List<ILinhaTabela> linhas, int codigoEsperado = 0, bool aoMenosUmComCodigoEsperado = false)
        {
            try
            {
                linhas = ObterLinhasParaStage(MontarConsulta(tabelaEnum,arquivo)).ToList();
                AoMenosUmComCodigoEsperado = aoMenosUmComCodigoEsperado;
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
            catch (Exception ex)
            {
                logger.Erro("ERRO EM ValidarTabela - ValidadorStage- ValidarTabela(bool deveHaverRegistro, out List<ILinhaTabela> linhas, int codigoEsperado = 0, bool aoMenosUmComCodigoEsperado = false)" + ex.ToString());
                throw ex;
            }
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
            var linhasComErroEsperado = linhas.Where(x => x.ObterPorColuna("CD_STATUS_PROCESSAMENTO").Valor == codigoEsperado.ToString());

            if (linhasComErroEsperado.Count() == 0)
            {
                logger.EscreverBloco($"O CODIGO DA LINHA ENCONTRADA NA TABELA {tabelaEnum.ObterTexto()} NAO CORRESPONDE AO ESPERADO {Environment.NewLine}" +
                    $"ESPERADO : {codigoEsperado.ToString()} , OBTIDO : {linhas.Select(x => x.ObterPorColuna("CD_STATUS_PROCESSAMENTO").Valor).ObterListaConcatenada(",")}");
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
