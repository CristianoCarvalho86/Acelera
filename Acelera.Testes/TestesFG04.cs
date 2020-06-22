using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Testes.ConjuntoArquivos;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.Validadores.FG02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public class TestesFG04 : TestesFG02
    {
        protected ITriplice triplice;

        protected IList<ILinhaTabela> resultadoStageComissao;

        protected IList<ILinhaTabela> resultadoStageParcela;

        protected new TabelaParametrosDataSP3 dados;

        public TestesFG04()
        {

        }

        protected override void IniciarTeste(TipoArquivo tipo, string numeroDoTeste, string nomeDoTeste)
        {
            base.IniciarTeste(tipo, numeroDoTeste, nomeDoTeste);
            dados = new TabelaParametrosDataSP3(logger);
        }

        public void CarregarTriplice(OperadoraEnum operadora)
        {
            if (operadora == OperadoraEnum.LASA)
                triplice = new TripliceLASA(1, logger);
            else if (operadora == OperadoraEnum.SOFTBOX)
                triplice = new TripliceSoftbox(1, logger);
            else
                throw new Exception("OPERACAO NAO PERMITIDA NOS TESTES DA FG04.");
        }

        public void ValidarFlComissaoCalculada(string cdTpa, string valorEsperado)
        {
            logger.AbrirBloco("VALIDANDO FL_COMISSAO_CALCULADA.");
            var flComissaoCalculada = dados.ObterFlComissaoCalculada(cdTpa);
            logger.Escrever("FL_COMISSAO_CALCULADA encontrada = " + flComissaoCalculada);
            if (flComissaoCalculada == valorEsperado)
                logger.Escrever($"FL_COMISSAO_CALCULADA IGUAL AO VALOR ESPERADO ('{valorEsperado}')");
            else
            {
                logger.Erro($"FL_COMISSAO_CALCULADA IGUAL DIFERENTE DO VALOR ESPERADO ('{valorEsperado}')");
                ExplodeFalha();
            }
        }

        public void ValidarVlComissaoNaStage(string cdTpa, string cdSucursal, string cdCobertura, string cdProduto)
        {
            logger.AbrirBloco("INICIANDO VALIDAÇÃO DO VL_COMISSAO ENCONTRADO NA STAGE.");
            var dadosRemuneracao = dados.ObterValorRemuneracaoParaFG04(cdTpa, cdSucursal, cdCobertura, cdProduto);
            if (dadosRemuneracao.Rows.Count != 1)
            {
                logger.Erro("ERRO AO BUSCAR PARAMETRIZAÇÕES NA TABELA 7013");
                ExplodeFalha();
            }
            logger.Escrever("VL_REMUNERACAO ENCONTRADO NA TABELA 7013 : " + dadosRemuneracao.Rows[0]["VL_REMUNERACAO"].ToString());
            logger.Escrever("TP_REMUNERACAO ENCONTRADO NA TABELA 7013 : " + dadosRemuneracao.Rows[0]["TP_REMUNERACAO"].ToString());
            foreach (var linha in resultadoStageComissao)
            {
                if (dadosRemuneracao.Rows[0]["TP_REMUNERACAO"].ToString() == "1")
                {
                    logger.Escrever($"VL_COMISSAO ENCONTRADO NA STAGE : {linha.ObterPorColuna("VL_COMISSAO")};");
                    logger.Escrever("VL_COMISSAO DEVE SER : TAB_STG_PARCELA_1001.VL_PREMIO_LIQUIDO * (TAB_PRM_REMUNERACAO_7013.VL_REMUNERACAO)");
                    if (linha.ObterPorColuna("VL_COMISSAO").ValorDecimal !=
                       linha.ObterPorColuna("VL_PREMIO_LIQUIDO").ValorDecimal * decimal.Parse(dadosRemuneracao.Rows[0]["VL_REMUNERACAO"].ToString()))
                    {
                        logger.Erro("VL_COMISSAO INVALIDO.");
                        ExplodeFalha();
                    }
                    logger.Escrever("VALOR CORRETO.");
                }
                else if (dadosRemuneracao.Rows[0]["TP_REMUNERACAO"].ToString() == "2")
                {
                    logger.Escrever($"VL_COMISSAO ENCONTRADO NA STAGE : {linha.ObterPorColuna("VL_COMISSAO")};");
                    logger.Escrever("VL_COMISSAO DEVE SER : TAB_PRM_REMUNERACAO_7013.VL_REMUNERACAO");
                    if (linha.ObterPorColuna("VL_COMISSAO").ValorDecimal != decimal.Parse(dadosRemuneracao.Rows[0]["VL_REMUNERACAO"].ToString()))
                    {
                        logger.Erro("VL_COMISSAO INVALIDO.");
                        ExplodeFalha();
                    }
                    logger.Escrever("VALOR CORRETO.");
                }
                else
                {
                    logger.Erro($"TP_REMUNERACAO INVALIDO : {dadosRemuneracao.Rows[0]["TP_REMUNERACAO"].ToString()}");
                    ExplodeFalha();
                }

            }
        }

        public void ExecutarEValidarTriplice(FGs fg, CodigoStage? codigoStageCliente, CodigoStage? codigoStageParc, CodigoStage? codigoStageComissao)
        {
            arquivo = triplice.ArquivoCliente;
            SelecionarLinhaParaValidacao(0);
            if (codigoStageCliente.HasValue)
                ExecutarEValidar(triplice.ArquivoCliente, fg, codigoStageCliente.Value);
            else
                ExecutarEValidarEsperandoErro(triplice.ArquivoCliente, fg, codigoStageCliente);

            arquivo = triplice.ArquivoParcEmissao;
            SelecionarLinhaParaValidacao(0);
            if (codigoStageParc.HasValue)
                ExecutarEValidar(triplice.ArquivoParcEmissao, fg, codigoStageParc.Value);
            else
                ExecutarEValidarEsperandoErro(triplice.ArquivoCliente, fg, codigoStageParc);

            arquivo = triplice.ArquivoComissao;
            SelecionarLinhaParaValidacao(0);
            if (codigoStageComissao.HasValue)
                resultadoStageComissao = ExecutarEValidar(triplice.ArquivoComissao, fg, codigoStageComissao.Value);
            else
                ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, fg, codigoStageComissao);


        }

        public void ExecutarEValidarFG04Comissao(string cdContrato, CodigoStage codigoStage, OperadoraEnum operacao)
        {
            ChamarExecucao(FG04_Tarefas.Comissao.ObterTexto());
            var validador = new ValidadorStages(TabelasEnum.Comissao, "", logger, null, null, null);
            validador.ValidarTabela(new string[] { "CD_CONTRATO", "NM_ARQUIVO_TPA"  }, new string[] { cdContrato , $"C01.{operacao.ObterTexto().ToUpper()}.EMSCMS-IN-0001-{DateTime.Now.ToString("yyyyMMdd")}" },
                "DT_MUDANCA DESC", (int)codigoStage, out resultadoStageComissao);
        }

        public void ValidarTabelaDeRetornoVazia(Arquivo arquivo)
        {
            this.arquivo = arquivo;
            SelecionarLinhaParaValidacao(0);
            ValidarTabelaDeRetorno(arquivo,false);
        }

        public void ValidarStageComissaoComParcela()
        {
            logger.AbrirBloco("INICIANDO COMPARACAO ENTRE OS REGISTROS ENCONTRADOS EM PARC E COMISSAO.");
            int count = 0;
            var errosEncontrados = "";
            foreach(var linhaParcela in resultadoStageParcela)
            {
                //if (!linhaParcela.ObterPorColuna("TIPO_REGISTRO").ValorFormatado == resultadoStageComissao[count].ObterPorColuna("TIPO_REGISTRO").ValorFormatado)
                //    errosEncontrados += $"| TIPO_REGISTRO EM PARCELA :{linhaParcela.ObterPorColuna("TIPO_REGISTRO").ValorFormatado} | TIPO_REGISTRO EM COMISSAO : {resultadoStageComissao[count].ObterPorColuna("TIPO_REGISTRO").ValorFormatado} {Environment.NewLine}";
                //if(!linhaParcela.ObterPorColuna("CD_INTERNO_RESSEGURADOR").ValorFormatado == resultadoStageComissao[count].ObterPorColuna("CD_INTERNO_RESSEGURADOR").ValorFormatado)
                //if(!linhaParcela.ObterPorColuna("CD_SEGURADORA").ValorFormatado == resultadoStageComissao[count].ObterPorColuna("CD_SEGURADORA").ValorFormatado)
                //if(!linhaParcela.ObterPorColuna("CD_EXTERNO").ValorFormatado == resultadoStageComissao[count].ObterPorColuna("CD_EXTERNO").ValorFormatado)
                //if(!linhaParcela.ObterPorColuna("CD_RAMO").ValorFormatado == resultadoStageComissao[count].ObterPorColuna("CD_RAMO").ValorFormatado)
                //if(!linhaParcela.ObterPorColuna("CD_CONTRATO").ValorFormatado == resultadoStageComissao[count].ObterPorColuna("CD_CONTRATO").ValorFormatado)
                //if(!linhaParcela.ObterPorColuna("NR_SEQUENCIAL_EMISSAO").ValorFormatado == resultadoStageComissao[count].ObterPorColuna("NR_SEQUENCIAL_EMISSAO").ValorFormatado)
                //if(!linhaParcela.ObterPorColuna("NR_PARCELA").ValorFormatado == resultadoStageComissao[count].ObterPorColuna("NR_PARCELA").ValorFormatado)
                //if(!linhaParcela.ObterPorColuna("NR_ENDOSSO").ValorFormatado == resultadoStageComissao[count].ObterPorColuna("NR_ENDOSSO").ValorFormatado)
                //if(!linhaParcela.ObterPorColuna("CD_ITEM").ValorFormatado == resultadoStageComissao[count].ObterPorColuna("CD_ITEM").ValorFormatado)
                //if(!linhaParcela.ObterPorColuna("CD_TIPO_REMUNERACAO").ValorFormatado == resultadoStageComissao[count].ObterPorColuna("CD_TIPO_REMUNERACAO").ValorFormatado)
                //if(!linhaParcela.ObterPorColuna("CD_COBERTURA").ValorFormatado == resultadoStageComissao[count].ObterPorColuna("CD_COBERTURA").ValorFormatado)
                //if(!linhaParcela.ObterPorColuna("NM_TPA").ValorFormatado == resultadoStageComissao[count].ObterPorColuna("NM_TPA").ValorFormatado)
                //if(!linhaParcela.ObterPorColuna("CD_VERSAO_ARQUIVO").ValorFormatado == resultadoStageComissao[count].ObterPorColuna("CD_VERSAO_ARQUIVO").ValorFormatado)
                /*"CASO  TAB_PRM_REMUNERACAO_7013.TP_REMUNERACAO = 1 -- PERCENTUAL
                                 TAB_STG_PARCELA_1001.VL_PREMIO_LIQUIDO * (TAB_PRM_REMUNERACAO_7013.VL_REMUNERACAO)
                CASO  TAB_PRM_REMUNERACAO_7013.TP_REMUNERACAO = 2-- VALOR FIXO
                               TAB_PRM_REMUNERACAO_7013.VL_REMUNERACAO"
                TAB_STG_PARCELA_1001.VL_PREMIO_LIQUIDO
                "CASO  TAB_PRM_REMUNERACAO_7013.TP_REMUNERACAO = 1 -- PERCENTUAL
                                   TAB_PRM_REMUNERACAO_7013.VL_REMUNERACAO
                CASO  TAB_PRM_REMUNERACAO_7013.TP_REMUNERACAO = 2-- VALOR FIXO
                                   TAB_PRM_REMUNERACAO_7013.VL_REMUNERACAO / VL_PREMIO_LIQUIDO"
                0
                COM'*/
                count++;
            }
        }

        private void ValidaCamposIguais(ILinhaTabela linhaOrigem, ILinhaTabela linhaDestino, string campo)
        {

        }

    }
}
