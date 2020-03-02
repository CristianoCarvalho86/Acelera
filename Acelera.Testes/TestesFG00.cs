using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Entidades.TabelaRetorno;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public abstract class TestesFG00 : TesteFG
    {


        public void ValidarControleArquivo(params string[] descricaoErroSeHouver)
        {
            AjustarEntradaErros(ref descricaoErroSeHouver);
            var consulta = new Consulta();
            consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);
            var lista = ChamarConsultaAoBanco<LinhaControleArquivo>(consulta);

            logger.InicioOperacao(OperacaoEnum.ValidarResultado, "Tabela:ControleArquivo");

            var falha = false;

            if (!Validar((lista.Any(x => x.ObterPorColuna("ST_STATUS").Valor == "E")), false, "Todos os ST_STATUS sao igual a 'S'"))
                falha = true;

            if (falha && descricaoErroSeHouver.Length == 0 || !falha && descricaoErroSeHouver.Length > 0)
                ExplodeFalha(logger);

            if (falha)
            {
                foreach (var descricao in descricaoErroSeHouver)
                    if (!Validar(lista.Any(x => x.ObterPorColuna("DS_ERRO").Valor.ToUpper() == descricao.ToUpper()),true,"Descricao de erro em CONTROLE ARQUIVO esperada foi encontrada:"))
                        ExplodeFalha(logger);
            }

            logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, "Tabela:ControleArquivo");
        }

        public void ValidarStages<T>(TabelasEnum tabela, bool deveHaverRegistro, int codigoEsperado = 0) where T : LinhaTabela, new()
        {
            //TODO : INCLUIR POSSIBILIDADE DE CONSULTA PARA VARIAS ALTERAÇÕES NUM ARQUIVO (CLAUSULA 'OR'), PODE SER QUE CODIGO ESPERADO TENHA QUE VIRAR UM ARRAY
            var consulta = new Consulta();
            MontarConsultaParaStage(tabela, consulta);
            var lista = ChamarConsultaAoBanco<T>(consulta);

            logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{tabela.ObterTexto()}");

            logger.Escrever($"Deve encontrar registros na tabela {tabela.ObterTexto()} : {deveHaverRegistro}");
            logger.Escrever($"Foram encontrados {lista.Count} registros.");

            if (!deveHaverRegistro && lista.Count > 0)// NAO DEVERIA ENCONTRAR REGISTROS MAS FORAM ENCONTRADOS
            {
                var linhas = string.Empty;
                foreach (var l in lista)
                    linhas += "LINHA : " + l.ToString() + Environment.NewLine;
                logger.EscreverBloco($"NAO ERAM ESPERADOS REGISTRO NA TABELA STAGE DE {tabela.ObterTexto()}" +
                    $"{Environment.NewLine} LINHAS ENCONTRADAS : { linhas })");
                ExplodeFalha(logger);
            }
            if (deveHaverRegistro)// VALIDA REGISTRO ENCONTRADO CONTEM CODIGO ESPERADO
            {
                foreach (var linha in lista)
                {
                    if (linha.ObterPorColuna("CD_STATUS_PROCESSAMENTO").Valor != codigoEsperado.ToString())
                    {
                        logger.EscreverBloco($"O CODIGO DA LINHA ENCONTRADA NA TABELA {tabela.ObterTexto()} NAO CORRESPONDE AO ESPERADO {Environment.NewLine}" +
                            $"ESPERADO : {codigoEsperado.ToString()} , OBTIDO : {linha.ObterPorColuna("CD_STATUS_PROCESSAMENTO")}");
                        ExplodeFalha(logger);
                    }
                    else
                    {
                        logger.Escrever($"Codigo Esperado na tabela {tabela.ObterTexto()} encontrado com sucesso : {codigoEsperado.ToString()}");
                    }
                }
            }
            logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{tabela.ObterTexto()}");

        }

        private void MontarConsultaParaStage(TabelasEnum tabela, Consulta consulta)
        {
            if (valoresAlteradosBody.Alteracoes.Count == 0)
                throw new Exception("NENHUMA LINHA ALTERADA OU SELECIONADA.");


            AdicionaConsultaDoBody(FabricaConsulta.MontarConsultaParaStage(tabela, valoresAlteradosBody, consulta));
        }


        protected override IList<string> ObterProceduresASeremExecutadas()
        {
            var lista = new List<string>();
            lista.Add("PRC_0093_IMP");
            lista.Add("PRC_0094_IMP");
            lista.Add("PRC_0101_IMP");
            lista.Add("PRC_0002_IMP");
            lista.Add("PRC_0091_IMP");
            lista.Add("PRC_0400_IMP");
            lista.Add("PRC_0003_IMP");
            lista.Add("PRC_0004_IMP");
            lista.Add("PRC_0100_IMP");
            lista.Add("PRC_0095_IMP");
            lista.Add("PRC_0401_IMP");
            return lista;
        }
    }
}
