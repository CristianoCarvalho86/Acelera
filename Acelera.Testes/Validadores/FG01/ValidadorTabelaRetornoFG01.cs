using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.TabelaRetorno;
using Acelera.Domain.Enums;
using Acelera.Logger;
using Acelera.Testes.Validadores.FG00;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.Validadores.FG01
{
    public class ValidadorTabelaRetornoFG01 : ValidadorTabelaRetornoFG00
    {
        public ValidadorTabelaRetornoFG01(TabelasEnum tabelaEnum, string nomeArquivo, MyLogger logger, AlteracoesArquivo valoresAlteradosBody, AlteracoesArquivo valoresAlteradosHeader, AlteracoesArquivo valoresAlteradosFooter) 
            : base(tabelaEnum, nomeArquivo, logger, valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter)
        {
        }

        public override Consulta MontarConsulta(TabelasEnum tabela)
        {
            var consulta = FabricaConsulta.MontarConsultaParaTabelaDeRetornoFG01(tabela, nomeArquivo, valoresAlteradosBody);
            return consulta;
        }

        public bool ValidarTabela(params string[] codigosDeErroEsperados)
        {
            AjustarEntradaErros(ref codigosDeErroEsperados);

            var consulta = MontarConsulta(tabelaEnum);

            List<ILinhaTabela> linhas;
            linhas = DataAccess.ChamarConsultaAoBanco<LinhaTabelaRetorno>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();

            var qtd = ObterQtdRegistrosDuplicadosDoBody();
            if (qtd == 0)
                qtd = 1;

            if (linhas.Count < qtd)
            {
                logger.EscreverBloco($"ERAM ESPERADOS :{qtd}, FORAM ENCONTRADOS: {linhas.Count} ERROS");
                return false;
            }


            return ValidarCodigosDeErro(TabelasEnum.TabelaRetorno, linhas, "CD_MENSAGEM", codigosDeErroEsperados);
        }
    }
}
