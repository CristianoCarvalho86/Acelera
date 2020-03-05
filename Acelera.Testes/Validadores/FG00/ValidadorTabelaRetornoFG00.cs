using Acelera.Domain.Entidades;
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
            var consulta = FabricaConsulta.MontarConsultaParaTabelaDeRetorno(tabela, nomeArquivo, valoresAlteradosBody);
            return consulta;
        }

        public bool ValidarTabela(int qtdRegistrosEsperados = 1, params string[] codigosDeErroEsperados)
        {
            AjustarEntradaErros(ref codigosDeErroEsperados);

            var consulta = MontarConsulta(tabelaEnum);

            List<ILinhaTabela> linhas;
            linhas = DataAccess.ChamarConsultaAoBanco<LinhaTabelaRetorno>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();
            if (linhas.Count != qtdRegistrosEsperados)
            {
                logger.EscreverBloco($"ERAM ESPERADOS :{qtdRegistrosEsperados}, FORAM ENCONTRADOS: {linhas.Count} ERROS");
                return false;
            }

            return ValidarCodigosDeErro(linhas, "CD_MENSAGEM", codigosDeErroEsperados);
        }
    }
}
