using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Testes.ConjuntoArquivos;
using Acelera.Testes.DataAccessRep;
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
                else if(dadosRemuneracao.Rows[0]["TP_REMUNERACAO"].ToString() == "2")
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
            if (fg != FGs.FG04)
            {
                if (codigoStageCliente.HasValue)
                    ExecutarEValidar(triplice.ArquivoCliente, fg, codigoStageCliente.Value);
                else
                    ExecutarEValidarEsperandoErro(triplice.ArquivoCliente, fg, codigoStageCliente);

                if (codigoStageParc.HasValue)
                    ExecutarEValidar(triplice.ArquivoParcEmissao, fg, codigoStageParc.Value);
                else
                    ExecutarEValidarEsperandoErro(triplice.ArquivoCliente, fg, codigoStageParc);
            }

            if (codigoStageComissao.HasValue)
                resultadoStageComissao = ExecutarEValidar(triplice.ArquivoComissao, fg, codigoStageComissao.Value);
            else
                ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, fg, codigoStageComissao);
        }

    }
}
