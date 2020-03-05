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

        public override Consulta MontarConsulta(TabelasEnum tabela)
        {
            var consulta = FabricaConsulta.MontarConsultaParaStage(tabela, nomeArquivo, valoresAlteradosBody);
            AdicionaConsulta(consulta,valoresAlteradosHeader);
            AdicionaConsulta(consulta,valoresAlteradosFooter);
            consulta.AdicionarOrderBy(" ORDER BY DT_MUDANCA DESC ");

            return consulta;
        }


        public bool ValidarTabela(bool deveHaverRegistro, out IList<ILinhaTabela> linhas, int codigoEsperado = 0)
        {

            linhas = ObterLinhas(MontarConsulta(tabelaEnum));

            logger.Escrever($"Deve encontrar registros na tabela {tabelaEnum.ObterTexto()} : {deveHaverRegistro}");
            logger.Escrever($"Foram encontrados {linhas.Count} registros.");

            if (!deveHaverRegistro && linhas.Count > 0)// NAO DEVERIA ENCONTRAR REGISTROS MAS FORAM ENCONTRADOS
            {
                var linhasTexto = string.Empty;
                foreach (var l in linhasTexto)
                    linhasTexto += "LINHA : " + l.ToString() + Environment.NewLine;
                logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, $"NAO ERAM ESPERADOS REGISTRO NA TABELA STAGE DE {tabelaEnum.ObterTexto()}" +
                    $"{Environment.NewLine} LINHAS ENCONTRADAS : { linhas })");
                return false;
            }
            else if (deveHaverRegistro && linhas.Count == 0)//DEVERIAM HAVER REGISTROS, MAS NAO FORAM ENCONTRADOS
            {
                logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, $"NAO FORAM ENCONTRADOS REGISTROS NA TABELA {tabelaEnum.ObterTexto()}");
                return false;
            }
            else if (deveHaverRegistro)// VALIDA REGISTRO ENCONTRADO CONTEM CODIGO ESPERADO
            {
                var linha = linhas.First();
                //foreach (var linha in lista)
                //{
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
            }
            return true;
        }

        private IList<ILinhaTabela> ObterLinhas(Consulta consulta)
        {
            var linhas = new List<ILinhaTabela>();
            if (tabelaEnum == TabelasEnum.Cliente)
                linhas = DataAccess.ChamarConsultaAoBanco<LinhaClienteStage>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();
            else if (tabelaEnum == TabelasEnum.Comissao)
                linhas = DataAccess.ChamarConsultaAoBanco<LinhaComissaoStage>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();
            else if (tabelaEnum == TabelasEnum.LanctoComissao)
                linhas = DataAccess.ChamarConsultaAoBanco<LinhaLanctoComissaoStage>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();
            else if (tabelaEnum == TabelasEnum.OCRCobranca)
                linhas = DataAccess.ChamarConsultaAoBanco<LinhaOCRCobrancaStage>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();
            else if (tabelaEnum == TabelasEnum.ParcEmissao)
                linhas = DataAccess.ChamarConsultaAoBanco<LinhaParcEmissaoStage>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();
            else if (tabelaEnum == TabelasEnum.ParcEmissaoAuto)
                linhas = DataAccess.ChamarConsultaAoBanco<LinhaParcEmissaoAutoStage>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();
            else if (tabelaEnum == TabelasEnum.Sinistro)
                linhas = DataAccess.ChamarConsultaAoBanco<LinhaSinistroStage>(consulta, logger).Select(x => (ILinhaTabela)x).ToList();
            else
                throw new Exception("TIPO DE TABELA DE CONSULTA NAO ENCONTRADO.");

            return linhas;

        }


    }
}
