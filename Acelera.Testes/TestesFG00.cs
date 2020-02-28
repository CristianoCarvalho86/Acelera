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
    public abstract class TestesFG00 : TesteBase
    {
        public void ValidarLogProcessamento(bool Sucesso)
        {
            var consulta = new Consulta();
            consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);
            var lista = ChamarConsultaAoBanco<LinhaLogProcessamento>(consulta);

            logger.InicioOperacao(OperacaoEnum.ValidarResultado, "Tabela:LogProcessamento");

            var falha = false;
            if (!Validar(ObterProceduresASeremExecutadas().Count, lista.Count, "Quantidade de Procedures executadas"))
                falha = true;
            if (!Validar((lista.Any(x => x.ObterPorColuna("CD_STATUS").Valor == "E")).ToString(), false, "Todos os CD_STATUS sao igual a 'S'"))
                falha = true;

            var proceduresEsperadas = ObterProceduresASeremExecutadas();
            var procedureNaoEncontrada = lista.Where(x => proceduresEsperadas.Any(z => z == x.ObterPorColuna("CD_PROCEDURE").Valor) == false);
            if (!Validar(procedureNaoEncontrada.Count() == 0, true, $"PROCEDURES {procedureNaoEncontrada.Select(x => x.ObterPorColuna("CD_PROCEDURE").Valor).ToList().ObterListaConcatenada(" ,")} NAO ENCONTRADAS"))
                falha = true;

            if (Sucesso && falha || !Sucesso && !falha)
            {
                logger.TesteComFalha();
                Assert.Fail();
            }
            logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, "Tabela:LogProcessamento");
        }

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

        public void ValidarTabelaDeRetorno(params string[] errosEsperados)
        {
            AjustarEntradaErros(ref errosEsperados);
            var consulta = new Consulta();
            MontarConsultaParaTabelaDeRetorno(TabelasEnum.TabelaRetorno, consulta);
            var lista = ChamarConsultaAoBanco<LinhaTabelaRetorno>(consulta);
            logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
            logger.Escrever($"Erros esperados na tabela de retorno {errosEsperados.ToList().ObterListaConcatenada(", ")}");
            foreach (var linhaEncontrada in lista)
            {
                if(!errosEsperados.Contains(linhaEncontrada.ObterPorColuna("CD_MENSAGEM").Valor.ToUpper()))
                {
                    var mensagesObtidas = lista.Select(x => x.ObterPorColuna("CD_MENSAGEM").Valor).ToList().ObterListaConcatenada(", ");

                    logger.EscreverBloco("VALIDAÇÃO ESPERADA NA TABELA DE RETORNO NAO ENCONTRADA."
                       + $"{Environment.NewLine} MENSAGENS ESPERADAS : {errosEsperados.ToList().ObterListaConcatenada(", ")}"
                       + $"{Environment.NewLine} MENSAGENS OBTIDAS : {mensagesObtidas}");

                    ExplodeFalha(logger);
                }
            }
            logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");

        }

        private void MontarConsultaParaTabelaDeRetorno(TabelasEnum tabela, Consulta consulta)
        {
            if (valoresAlteradosBody.Alteracoes.Count == 0)
                throw new Exception("NENHUMA LINHA ALTERADA OU SELECIONADA.");

            if (tabela == TabelasEnum.Cliente)
            {
                consulta.AdicionarConsulta("CD_CLIENTE", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CLIENTE").Valor);
                consulta.AdicionarConsulta("TIPO_REGISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("TIPO_REGISTRO").Valor);
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CONTRATO").Valor);
                AdicionaConsultaDoBody(consulta);
            }
            else if (tabela == TabelasEnum.Sinistro)
            {
                consulta.AdicionarConsulta("TIPO_REGISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("TIPO_REGISTRO").Valor);
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CONTRATO").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("CD_SINISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_SINISTRO").Valor);
                AdicionaConsultaDoBody(consulta);
            }
            else
            {
                consulta.AdicionarConsulta("TIPO_REGISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("TIPO_REGISTRO").Valor);
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CONTRATO").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("NR_PARCELA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_PARCELA").Valor);
                AdicionaConsultaDoBody(consulta);
            }
        }

        private void MontarConsultaParaStage(TabelasEnum tabela, Consulta consulta)
        {
            if (valoresAlteradosBody.Alteracoes.Count == 0)
                throw new Exception("NENHUMA LINHA ALTERADA OU SELECIONADA.");

            if (tabela == TabelasEnum.Cliente)
            {
                consulta.AdicionarConsulta("CD_CLIENTE", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CLIENTE").Valor);
                AdicionaConsultaDoBody(consulta);
            }
            else if (tabela == TabelasEnum.ParcEmissao || tabela == TabelasEnum.ParcEmissaoAuto)
            {
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CONTRATO").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("NR_PARCELA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_PARCELA").Valor);
                consulta.AdicionarConsulta("CD_COBERTURA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_COBERTURA").Valor);
                AdicionaConsultaDoBody(consulta);
            }
            else if (tabela == TabelasEnum.Comissao)
            {
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CONTRATO").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("NR_PARCELA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_PARCELA").Valor);
                consulta.AdicionarConsulta("CD_COBERTURA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_COBERTURA").Valor);
                consulta.AdicionarConsulta("CD_TIPO_COMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_TIPO_COMISSAO").Valor);
                AdicionaConsultaDoBody(consulta);
            }
            else if (tabela == TabelasEnum.OCRCobranca)
            {
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CONTRATO").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("NR_PARCELA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_PARCELA").Valor);
                AdicionaConsultaDoBody(consulta);
            }
            else if (tabela == TabelasEnum.LanctoComissao)
            {
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CONTRATO").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("NR_PARCELA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_PARCELA").Valor);
                consulta.AdicionarConsulta("CD_TIPO_COMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_TIPO_COMISSAO").Valor);
                AdicionaConsultaDoBody(consulta);
            }
            else if (tabela == TabelasEnum.Sinistro)
            {
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CONTRATO").Valor);
                //consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("VL_MOVIMENTO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("VL_MOVIMENTO").Valor);
                consulta.AdicionarConsulta("NM_BENEFICIARIO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NM_BENEFICIARIO").Valor);
                consulta.AdicionarConsulta("CD_COBERTURA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_COBERTURA").Valor);
                consulta.AdicionarConsulta("CD_SINISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_SINISTRO").Valor);
                AdicionaConsultaDoBody(consulta);
            }
        }

        private void AdicionaConsultaDoBody(Consulta consulta)
        {
            foreach (var c in valoresAlteradosBody.Alteracoes)
                foreach (var item in c.CamposAlterados)
                    consulta.AdicionarConsulta(item.Coluna, item.Valor);
        }

        private IList<string> ObterProceduresASeremExecutadas()
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

        private void ExplodeFalha(MyLogger logger)
        {
            logger.TesteComFalha();
            Assert.Fail();
        }

        protected bool Validar(object esperado, object obtido, string tituloValidacao)
        {
            logger.EscreveValidacao(obtido.ToString(), esperado.ToString(), tituloValidacao);

            if (esperado == obtido)
                return true;
            return false;
        }

        private void AjustarEntradaErros(ref string[] erros)
        {
            if (erros.Length == 1 && erros.Contains(string.Empty))
                erros = new string[] { };

        }
    }
}
