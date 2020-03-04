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

            if (lista.Count == 0)
            {
                logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, $"Arquivo nao encontrado na {TabelasEnum.ControleArquivo.ObterTexto()}");
                ExplodeFalha();
            }

            if (!Validar((lista.All(x => x.ObterPorColuna("ST_STATUS").Valor == "S")),
                descricaoErroSeHouver.Length > 0 ? false : true,
                "O Campo ST_STATUS dos registros é igual a 'S'"))
                falha = true;

            if (falha && descricaoErroSeHouver.Length == 0)
            {
                logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, "NAO ERAM ESPERADAS FALHAS NO TESTE");
                ExplodeFalha();
            }
            else if (!falha && descricaoErroSeHouver.Length > 0)
            {
                logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, $"AS FALHAS ESPERADAS NAO FORAM ENCONTRADAS : {descricaoErroSeHouver.ToList().ObterListaConcatenada(",")}");
                ExplodeFalha();
            }

            foreach (var descricao in descricaoErroSeHouver)
                if (!Validar(lista.Any(x => x.ObterPorColuna("DS_ERRO").Valor.ToUpper() == descricao.ToUpper()), true, $"Buscando Erro - {descricao} - em {TabelasEnum.ControleArquivo.ObterTexto()}:"))
                    ExplodeFalha();


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
                logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, $"NAO ERAM ESPERADOS REGISTRO NA TABELA STAGE DE {tabela.ObterTexto()}" +
                    $"{Environment.NewLine} LINHAS ENCONTRADAS : { linhas })");
                ExplodeFalha();
            }
            else if (deveHaverRegistro && lista.Count == 0)//DEVERIAM HAVER REGISTROS, MAS NAO FORAM ENCONTRADOS
            {
                logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, $"NAO FORAM ENCONTRADOS REGISTROS NA TABELA {tabela.ObterTexto()}");
                ExplodeFalha();
            }
            else if (deveHaverRegistro)// VALIDA REGISTRO ENCONTRADO CONTEM CODIGO ESPERADO
            {
                var linha = lista.First();
                //foreach (var linha in lista)
                //{
                if (linha.ObterPorColuna("CD_STATUS_PROCESSAMENTO").Valor != codigoEsperado.ToString())
                {
                    logger.EscreverBloco($"O CODIGO DA LINHA ENCONTRADA NA TABELA {tabela.ObterTexto()} NAO CORRESPONDE AO ESPERADO {Environment.NewLine}" +
                        $"ESPERADO : {codigoEsperado.ToString()} , OBTIDO : {linha.ObterPorColuna("CD_STATUS_PROCESSAMENTO")}");
                    ExplodeFalha();
                }
                else
                {
                    logger.Escrever($"Codigo Esperado na tabela {tabela.ObterTexto()} encontrado com sucesso : {codigoEsperado.ToString()}");
                }
                //}
            }
            logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{tabela.ObterTexto()}");

        }

        private void MontarConsultaParaStage(TabelasEnum tabela, Consulta consulta)
        {
            if (valoresAlteradosBody.Alteracoes.Count == 0)
                throw new Exception("NENHUMA LINHA ALTERADA OU SELECIONADA.");


            AdicionaConsultaDoBody(FabricaConsulta.MontarConsultaParaStage(tabela, nomeArquivo, valoresAlteradosBody, consulta));
            consulta.AdicionarOrderBy(" ORDER BY DT_MUDANCA DESC ");
        }

        public void ValidarStages<T>(bool deveEncontrarRegistro ,int codigoEsperado = 0) where T : LinhaTabela, new()
        {
            ValidarStages<T>(tipoArquivoTeste.ObterTabelaEnum(), deveEncontrarRegistro, codigoEsperado);
        }
        public void ValidarStages<T>(int codigoEsperado) where T : LinhaTabela, new()
        {
            ValidarStages<T>(tipoArquivoTeste.ObterTabelaEnum(), true, codigoEsperado);
        }
        public void ValidarStages<T>(CodigoStage codigo) where T : LinhaTabela, new()
        {
            ValidarStages<T>((int)codigo);
        }


        protected override IList<string> ObterProceduresASeremExecutadas()
        {
            var lista = new List<string>();
            lista.Add("PRC_0093_IMP");
            lista.Add("PRC_0094_IMP");
            lista.Add("PRC_0101_IMP");
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
