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

        protected string VlRemuneracao7013;
        protected string TPRemuneracao7013;

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
            logger.Escrever("VL_REMUNERACAO ENCONTRADO NA TABELA 7013 : " + dadosRemuneracao.Rows[0]["VL_REMUMERACAO"].ToString());
            logger.Escrever("TP_REMUNERACAO ENCONTRADO NA TABELA 7013 : " + dadosRemuneracao.Rows[0]["TP_REMUNERACAO"].ToString());

            var count = 0;
            foreach (var linha in resultadoStageComissao)
            {
                if (dadosRemuneracao.Rows[0]["TP_REMUNERACAO"].ToString() == "1")
                {
                    //VL_COMISSAO
                    logger.Escrever($"VL_COMISSAO ENCONTRADO NA STAGE : {linha.ObterPorColuna("VL_COMISSAO")};");
                    logger.Escrever("VL_COMISSAO DEVE SER : TAB_STG_PARCELA_1001.VL_PREMIO_LIQUIDO * (TAB_PRM_REMUNERACAO_7013.VL_REMUNERACAO)");
                    if (linha.ObterPorColuna("VL_COMISSAO").ValorDecimal !=
                       resultadoStageParcela[count].ObterPorColuna("VL_PREMIO_LIQUIDO").ValorDecimal * decimal.Parse(dadosRemuneracao.Rows[0]["VL_REMUMERACAO"].ToString()))
                    {
                        logger.Erro("VL_COMISSAO INVALIDO.");
                        ExplodeFalha();
                    }
                    logger.Escrever("VALOR CORRETO.");

                    //PC_COMISSAO
                    logger.Escrever($"PC_COMISSAO ENCONTRADO NA STAGE : {linha.ObterPorColuna("PC_COMISSAO")};");
                    logger.Escrever("PC_COMISSAO DEVE SER : TAB_PRM_REMUNERACAO_7013.VL_REMUNERACAO");
                    if (linha.ObterPorColuna("PC_COMISSAO").ValorDecimal != decimal.Parse(dadosRemuneracao.Rows[0]["VL_REMUMERACAO"].ToString()))
                    {
                        logger.Erro("PC_COMISSAO INVALIDO.");
                        ExplodeFalha();
                    }
                    logger.Escrever("VALOR CORRETO.");

                }
                else if (dadosRemuneracao.Rows[0]["TP_REMUNERACAO"].ToString() == "2")
                {
                    //VL_COMISSAO
                    logger.Escrever($"VL_COMISSAO ENCONTRADO NA STAGE : {linha.ObterPorColuna("VL_COMISSAO")};");
                    logger.Escrever("VL_COMISSAO DEVE SER : TAB_PRM_REMUNERACAO_7013.VL_REMUNERACAO");
                    if (linha.ObterPorColuna("VL_COMISSAO").ValorDecimal != decimal.Parse(dadosRemuneracao.Rows[0]["VL_REMUMERACAO"].ToString()))
                    {
                        logger.Erro("VL_COMISSAO INVALIDO.");
                        ExplodeFalha();
                    }
                    logger.Escrever("VALOR CORRETO.");

                    //PC_COMISSAO
                    logger.Escrever($"PC_COMISSAO ENCONTRADO NA STAGE : {linha.ObterPorColuna("PC_COMISSAO")};");
                    logger.Escrever("PC_COMISSAO DEVE SER : TAB_PRM_REMUNERACAO_7013.VL_REMUNERACAO / VL_PREMIO_LIQUIDO");
                    if (linha.ObterPorColuna("PC_COMISSAO").ValorDecimal.ToString("C2") !=
                        (decimal.Parse(dadosRemuneracao.Rows[0]["VL_REMUMERACAO"].ToString()) / linha.ObterPorColuna("VL_PREMIO_LIQUIDO").ValorDecimal).ToString("C2"))
                    {
                        logger.Erro("PC_COMISSAO INVALIDO.");
                        ExplodeFalha();
                    }
                    logger.Escrever("VALOR CORRETO.");
                }
                else
                {
                    logger.Erro($"TP_REMUNERACAO INVALIDO : {dadosRemuneracao.Rows[0]["TP_REMUNERACAO"].ToString()}");
                    ExplodeFalha();
                }
                count++;
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

        public void ExecutarEValidarFG04Comissao(string cdContrato, string nomeArquivo, CodigoStage codigoStage)
        {
            ChamarExecucao(FG04_Tarefas.Comissao.ObterTexto());
            var validador = new ValidadorStages(TabelasEnum.Comissao, "", logger, null, null, null);
            validador.ValidarTabela(new string[] { "CD_CONTRATO", "NM_ARQUIVO_TPA"  }, new string[] { cdContrato , nomeArquivo },
                "DT_MUDANCA DESC", (int)codigoStage, out resultadoStageComissao);
        }

        public void ExecutarEValidarStage(string cdContrato, string nomeArquivo, CodigoStage codigoStage)
        {
            ChamarExecucao(FG04_Tarefas.Comissao.ObterTexto());
            var validador = new ValidadorStages(TabelasEnum.Comissao, "", logger, null, null, null);
            validador.ValidarTabela(new string[] { "CD_CONTRATO", "NM_ARQUIVO_TPA" }, new string[] { cdContrato, nomeArquivo },
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
                ValidaCamposIguais(linhaParcela, resultadoStageComissao[count], "TIPO_REGISTRO", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela, resultadoStageComissao[count], "CD_INTERNO_RESSEGURADOR", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"CD_SEGURADORA", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"CD_EXTERNO", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"CD_RAMO", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"CD_CONTRATO", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"NR_SEQUENCIAL_EMISSAO", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"NR_PARCELA", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"NR_ENDOSSO", ref errosEncontrados); 
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"CD_ITEM", ref errosEncontrados);
                ValidaCamposIguais(linhaParcela,resultadoStageComissao[count],"CD_TIPO_REMUNERACAO", ref errosEncontrados);
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
            {
                logger.Erro(errosEncontrados);
                ExplodeFalha();
            }
        }

        private void ValidaCamposIguais(ILinhaTabela linhaOrigem, ILinhaTabela linhaDestino, string campo, ref string erro)
        {
            if (linhaOrigem.ObterPorColuna(campo).ValorFormatado != linhaDestino.ObterPorColuna(campo).ValorFormatado) ;
                erro += $"ERRO : {campo} EM PARCELA :{linhaOrigem.ObterPorColuna(campo).ValorFormatado} | {campo} EM COMISSAO : {linhaDestino.ObterPorColuna(campo).ValorFormatado} {Environment.NewLine}";
        }

        private void ValidaCamposIguais(ILinhaTabela linhaOrigem, ILinhaTabela linhaDestino, string campo1, string campo2, ref string erro)
        {
            if (linhaOrigem.ObterPorColuna(campo1).ValorFormatado != linhaDestino.ObterPorColuna(campo2).ValorFormatado) ;
            erro += $"ERRO : {campo1} EM PARCELA :{linhaOrigem.ObterPorColuna(campo1).ValorFormatado} | {campo2} EM COMISSAO : {linhaDestino.ObterPorColuna(campo2).ValorFormatado} {Environment.NewLine}";
        }

    }
}
