using Acelera.Contratos;
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
        protected ITrinca trinca;

        protected IList<ILinhaTabela> resultadoStageComissao;

        protected IList<ILinhaTabela> resultadoStageParcela;

        protected string VlRemuneracao7013;
        protected string TPRemuneracao7013;
        protected string NomeDoTeste;

        public TestesFG04()
        {

        }

        protected override void IniciarTeste(TipoArquivo tipo, string numeroDoTeste, string nomeDoTeste)
        {
            NomeDoTeste = numeroDoTeste;
            base.IniciarTeste(tipo, numeroDoTeste, nomeDoTeste);
        }

        public virtual void CarregarTrinca(OperadoraEnum operadora)
        {
            if (operadora == OperadoraEnum.LASA)
                trinca = new TripliceLASA(1, logger, ref arquivosSalvos);
            else if (operadora == OperadoraEnum.SOFTBOX)
                trinca = new TripliceSoftbox(1, logger, ref arquivosSalvos);
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

        public void ValidarVlComissaoNaStage(string cdTpa, string cdSucursal, string cdCobertura, string cdProduto, string tpRemuneracao, string flRemuInformada, string cdTipoRemuneracao)
        {
            logger.AbrirBloco("INICIANDO VALIDAÇÃO DO VL_COMISSAO ENCONTRADO NA STAGE.");
            var dadosRemuneracao = dados.ObterValorRemuneracaoParaFG04(cdTpa, cdSucursal, cdCobertura, cdProduto, tpRemuneracao, flRemuInformada, cdTipoRemuneracao);

            //logger.Escrever("VL_REMUNERACAO ENCONTRADO NA TABELA 7013 : " + dadosRemuneracao.Rows[0]["VL_REMUMERACAO"].ToString());
            //logger.Escrever("TP_REMUNERACAO ENCONTRADO NA TABELA 7013 : " + dadosRemuneracao.Rows[0]["TP_REMUNERACAO"].ToString());

            foreach (var linha in resultadoStageComissao)
            {
                var cdPnCorretor = dados.ObterCdPNCorretor(linha.ObterPorColuna("CD_CORRETOR").ValorFormatado);
                var dadosDaRemuneracao = dadosRemuneracao.Select($"CD_PN_CORRETOR = '{cdPnCorretor}' AND CD_TIPO_REMUNERACAO = '{linha.ObterPorColuna("CD_TIPO_COMISSAO").ValorFormatado}'");
                if(dadosDaRemuneracao.Count() != 1)
                {
                    ExplodeFalha($"DADOS INCORRETOS VINDOS DA 7013 PARA CD_PN_CORRETOR = '{cdPnCorretor}' AND CD_TIPO_REMUNERACAO = '{linha.ObterPorColuna("CD_TIPO_COMISSAO").ValorFormatado}'");
                }

                if (dadosDaRemuneracao[0]["CD_TIPO_REMUNERACAO"].ToString() != linha.ObterPorColuna("CD_TIPO_COMISSAO").ValorFormatado)
                {
                    ExplodeFalha($"CD_TIPO_REMUNERACAO ESPERADO : {dadosDaRemuneracao[0]["CD_TIPO_REMUNERACAO"].ToString()} , OBTIDO : {linha.ObterPorColuna("CD_TIPO_REMUNERACAO").ValorFormatado}");
                }

                if (dadosDaRemuneracao[0]["TP_REMUNERACAO"].ToString() == "1")
                {
                    //VL_COMISSAO
                    logger.Escrever($"VL_COMISSAO ENCONTRADO NA STAGE COMISSAO: {linha.ObterPorColuna("VL_COMISSAO")};");
                    logger.Escrever("VL_COMISSAO DEVE SER : TAB_STG_PARCELA_1001.VL_PREMIO_LIQUIDO * (TAB_PRM_REMUNERACAO_7013.VL_REMUNERACAO)");
                    if (linha.ObterPorColuna("VL_COMISSAO").ValorDecimal !=
                       resultadoStageParcela[0].ObterPorColuna("VL_PREMIO_LIQUIDO").ValorDecimal * (decimal.Parse(dadosDaRemuneracao[0]["VL_REMUMERACAO"].ToString())/100M))
                    {
                        ExplodeFalha("VL_COMISSAO INVALIDO.");
                    }
                    logger.Escrever("VALOR CORRETO.");

                    //PC_COMISSAO
                    logger.Escrever($"PC_COMISSAO ENCONTRADO NA STAGE COMISSAO: {linha.ObterPorColuna("PC_COMISSAO")};");
                    logger.Escrever("PC_COMISSAO DEVE SER : TAB_PRM_REMUNERACAO_7013.VL_REMUNERACAO");
                    if (linha.ObterPorColuna("PC_COMISSAO").ValorDecimal != decimal.Parse(dadosDaRemuneracao[0]["VL_REMUMERACAO"].ToString()))
                    {
                        ExplodeFalha("PC_COMISSAO INVALIDO.");
                    }
                    logger.Escrever("VALOR CORRETO.");

                }
                else if (dadosDaRemuneracao[0]["TP_REMUNERACAO"].ToString() == "2")
                {
                    //VL_COMISSAO
                    logger.Escrever($"VL_COMISSAO ENCONTRADO NA STAGE COMISSAO: {linha.ObterPorColuna("VL_COMISSAO")};");
                    logger.Escrever("VL_COMISSAO DEVE SER : TAB_PRM_REMUNERACAO_7013.VL_REMUNERACAO");
                    if (linha.ObterPorColuna("VL_COMISSAO").ValorDecimal != decimal.Parse(dadosDaRemuneracao[0]["VL_REMUMERACAO"].ToString()))
                    {
                        ExplodeFalha("VL_COMISSAO INVALIDO.");
                    }
                    logger.Escrever("VALOR CORRETO.");

                    //PC_COMISSAO
                    logger.Escrever($"PC_COMISSAO ENCONTRADO NA STAGE COMISSAO: {linha.ObterPorColuna("PC_COMISSAO")};");
                    logger.Escrever("PC_COMISSAO DEVE SER : TAB_PRM_REMUNERACAO_7013.VL_REMUNERACAO / VL_PREMIO_LIQUIDO");
                    var vlRemuneracaoCortado = decimal.Parse((decimal.Parse(dadosDaRemuneracao[0]["VL_REMUMERACAO"].ToString()) / resultadoStageParcela[0].ObterPorColuna("VL_PREMIO_LIQUIDO").ValorDecimal).ToString("0.00"));
                    if (linha.ObterPorColuna("PC_COMISSAO").ValorDecimal != vlRemuneracaoCortado)
                    {
                        ExplodeFalha("PC_COMISSAO INVALIDO.");
                    }
                    logger.Escrever("VALOR CORRETO.");
                }
                else
                {
                    ExplodeFalha($"TP_REMUNERACAO INVALIDO : {dadosDaRemuneracao[0]["TP_REMUNERACAO"].ToString()}");
                }
            }
        }

        public void ExecutarEValidarTriplice(FGs fg, CodigoStage? codigoStageCliente, CodigoStage? codigoStageParc, CodigoStage? codigoStageComissao)
        {
            arquivo = trinca.ArquivoCliente;
            SelecionarLinhaParaValidacao(0);
            if (codigoStageCliente.HasValue)
                ExecutarEValidar(trinca.ArquivoCliente, fg, codigoStageCliente.Value);
            else
                ExecutarEValidarEsperandoErro(trinca.ArquivoCliente, fg, codigoStageCliente);

            arquivo = trinca.ArquivoParcEmissao;
            SelecionarLinhaParaValidacao(0);
            if (codigoStageParc.HasValue)
                resultadoStageParcela = ExecutarEValidar(trinca.ArquivoParcEmissao, fg, codigoStageParc.Value);
            else
                ExecutarEValidarEsperandoErro(trinca.ArquivoCliente, fg, codigoStageParc);

            arquivo = trinca.ArquivoComissao;
            SelecionarLinhaParaValidacao(0);
            if (codigoStageComissao.HasValue)
                resultadoStageComissao = ExecutarEValidar(trinca.ArquivoComissao, fg, codigoStageComissao.Value);
            else
                ExecutarEValidarEsperandoErro(trinca.ArquivoComissao, fg, codigoStageComissao);


        }

        public void ExecutarEValidarFG04Comissao(string cdContrato, string nomeArquivo, CodigoStage codigoStage)
        {
            ChamarExecucao(FG04_Tarefas.Comissao.ObterTexto());
            var validador = new ValidadorStages(TabelasEnum.Comissao, "", logger, null);
            if (!validador.ValidarTabela(new string[] { "CD_CONTRATO", "NM_ARQUIVO_TPA" }, new string[] { cdContrato, nomeArquivo },
                "DT_MUDANCA DESC", (int)codigoStage, out resultadoStageComissao))
                ExplodeFalha("ERRO NA VALIDACAO DA STAGE COMISSAO APOS EXECUCAO DA FG04");
        }

        public void ExecutarEValidarStageComissao(string cdContrato, string nomeArquivo,FGs fgAExecutar, CodigoStage codigoStage)
        {
            ChamarExecucao(TipoArquivo.Comissao.ObterTarefaDaFG(fgAExecutar));
            var validador = new ValidadorStages(TabelasEnum.Comissao, "", logger, null);
            if (!validador.ValidarTabela(new string[] { "CD_CONTRATO", "NM_ARQUIVO_TPA" }, new string[] { cdContrato, nomeArquivo },
                "DT_MUDANCA DESC", (int)codigoStage, out resultadoStageComissao))
                ExplodeFalha($"ERRO NA VALIDACAO DA STAGE COMISSAO APOS EXECUCAO DA {fgAExecutar.ObterTexto()}");
        }

        public void ValidarTabelaDeRetornoVazia(IArquivo arquivo)
        {
            this.arquivo = arquivo;
            SelecionarLinhaParaValidacao(0);
            ValidarTabelaDeRetorno(arquivo,false);
        }

        public void ValidarDadosDaStageComissao()
        {
            logger.AbrirBloco("INICIANDO COMPARACAO ENTRE OS REGISTROS ENCONTRADOS EM PARC E COMISSAO.");
            int count = 0;
            var errosEncontrados = "";
            foreach(var linhaParcela in resultadoStageParcela)
            {
                ValidaCamposIguais(linhaParcela, resultadoStageComissao[count], "TIPO_REGISTRO", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela, resultadoStageComissao[count], "CD_INTERNO_RESSEGURADOR", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"CD_SEGURADORA", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"CD_RAMO", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"CD_CONTRATO", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"NR_SEQUENCIAL_EMISSAO", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"NR_PARCELA", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"NR_ENDOSSO", ref errosEncontrados); 
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"CD_ITEM", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"CD_COBERTURA", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"NM_TPA", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela, resultadoStageComissao[count], "CD_VERSAO_ARQUIVO", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela, resultadoStageComissao[count], "VL_PREMIO_LIQUIDO", "VL_BASE_CALCULO", ref errosEncontrados);

                if (resultadoStageComissao[count].ObterPorColuna("PC_PARTICIPACAO").ValorDecimal != 0)
                {
                    errosEncontrados += $"PC_PARTICIPACAO ESPERADO = 0 OBTIDO : {resultadoStageComissao[count].ObterPorColuna("PC_COMISSAO").ValorDecimal}";
                }

                if (resultadoStageComissao[count].ObterPorColuna("CD_SISTEMA").ValorFormatado != "COM")
                {
                    errosEncontrados += $"PC_PARTICIPACAO ESPERADO = COM OBTIDO : {resultadoStageComissao[count].ObterPorColuna("CD_SISTEMA").ValorFormatado}";
                }

                count++;
            }

            if (!string.IsNullOrEmpty(errosEncontrados))
                ExplodeFalha(errosEncontrados);
        }

        private void ValidaCamposIguais(ILinhaTabela linhaOrigem, ILinhaTabela linhaDestino, string campo, ref string erro)
        {
            ValidaCamposIguais(linhaOrigem, linhaDestino, campo, campo, ref erro);
        }

        private void ValidaCamposIguais(ILinhaTabela linhaOrigem, ILinhaTabela linhaDestino, string campo1, string campo2, ref string erro)
        {
            if (linhaOrigem.ObterPorColuna(campo1).ValorFormatado != linhaDestino.ObterPorColuna(campo2).ValorFormatado)
                erro += $"ERRO : {campo1} EM PARCELA :{linhaOrigem.ObterPorColuna(campo1).ValorFormatado} | {campo2} EM COMISSAO : {linhaDestino.ObterPorColuna(campo2).ValorFormatado} {Environment.NewLine}";
        }

    }
}
