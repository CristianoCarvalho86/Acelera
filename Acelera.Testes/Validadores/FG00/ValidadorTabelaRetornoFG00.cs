﻿using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.TabelaRetorno;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.Validadores.FG00
{
    public class ValidadorTabelaRetornoFG00 : ValidadorTabela
    {
        public ValidadorTabelaRetornoFG00(TabelasEnum tabelaEnum, string nomeArquivo, MyLogger logger, AlteracoesArquivo valoresAlteradosBody, AlteracoesArquivo valoresAlteradosHeader, AlteracoesArquivo valoresAlteradosFooter) 
            :base(tabelaEnum, nomeArquivo,logger,valoresAlteradosBody,valoresAlteradosHeader,valoresAlteradosFooter)
        {
        }

        public override Consulta MontarConsulta(TabelasEnum tabela)
        {
            var consulta = FabricaConsulta.MontarConsultaParaTabelaDeRetorno(tabela, nomeArquivo, valoresAlteradosBody, ExisteAlteracaoHeaderOuFooter(), ExistemLinhasNoArquivo());
            return consulta;
        }

        public override void TratarConsulta(Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public bool ValidarTabela(bool validaQuantidadeErros = false,params string[] codigosDeErroEsperados)
        {
            AjustarEntradaErros(ref codigosDeErroEsperados);

            var consulta = MontarConsulta(tabelaEnum);

            List<ILinhaTabela> linhas;
            linhas = DataAccess.ChamarConsultaAoBanco<LinhaTabelaRetorno>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();

            var qtd = ObterQtdRegistrosDuplicadosHeaderAndFooter();
            if (qtd == 0)
                qtd = 1;

            if (codigosDeErroEsperados.Length == 0)
                qtd = 0;

            if (linhas.Count < qtd)
            {
                logger.EscreverBloco($"ERAM ESPERADOS :{qtd}, FORAM ENCONTRADOS: {linhas.Count} registros");
                return false;
            }

            if(validaQuantidadeErros && linhas.Count != codigosDeErroEsperados.Length)
            {
                logger.EscreverBloco($"ERAM ESPERADOS :{codigosDeErroEsperados.Length} NA {TabelasEnum.ControleArquivo.ObterTexto()} MAS FORAM ENCONTRADAS :{linhas.Count}");
            }


            return ValidarCodigosDeErro(TabelasEnum.TabelaRetorno,linhas, "CD_MENSAGEM", codigosDeErroEsperados);
        }
    }
}