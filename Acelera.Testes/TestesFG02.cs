﻿using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.Validadores.FG01;
using Acelera.Testes.Validadores.FG02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2
{
    public class TestesFG02 : TestesFG01
    {
        public TabelaParametrosData dados { get; private set; }

        protected override string NomeFG => "FG02";
        public TestesFG02():base()
        {
            
        }

        protected override void IniciarTeste(TipoArquivo tipo, string numeroDoTeste, string nomeDoTeste)
        {
            base.IniciarTeste(tipo, numeroDoTeste, nomeDoTeste);
            dados = new TabelaParametrosData(logger);
        }

        public override void ValidarFGsAnteriores()
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            base.ValidarFGsAnteriores();

            logger.EscreverBloco("Inicio da Validação da FG01.");
            //PROCESSAR O ARQUIVO CRIADO
            base.ChamarExecucao(tipoArquivoTeste.ObterTarefaFG01Enum().ObterTexto());
            base.ValidarLogProcessamento(true, 1, base.ObterProceduresASeremExecutadas());
            base.ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetornoFG01();
            logger.EscreverBloco("Fim da Validação da FG01. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
            ValidarTeste();
            logger.EscreverBloco("Inicio da FG02.");
        }

        protected override IList<string> ObterProceduresASeremExecutadas()
        {
            return base.ObterProceduresASeremExecutadas().Concat(ObterProcedures(tipoArquivoTeste)).ToList();
        }

        public void ValidarTabelaDeRetorno(bool naoDeveEncontarOsErrosDefinidos, params string[] codigosDeErroEsperados)
        {
            ValidarTabelaDeRetorno(naoDeveEncontarOsErrosDefinidos, false, codigosDeErroEsperados);
        }

        public override void ValidarTabelaDeRetorno(bool naoDeveEncontrarOsErrosDefinidos,bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            try
            {
                AjustarEntradaErros(ref codigosDeErroEsperados);
                logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
                var validador = new ValidadorTabelaRetornoFG02(tipoArquivoTeste.ObterTabelaStageEnum(), nomeArquivo, logger,
                    valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter);

                if (validador.ValidarTabela(TabelasEnum.TabelaRetorno, naoDeveEncontrarOsErrosDefinidos, validaQuantidadeErros, codigosDeErroEsperados))
                    logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
                else
                    ExplodeFalha();
            }
            catch (Exception)
            {
                TratarErro($" Validação da Tabela Retorno");
            }
        }

        public void ValidarTabelaDeRetorno(int quantidadeErro, string codigoDeErroEsperado, bool naoDeveEncontrar = false)
        {
            if (string.IsNullOrEmpty(codigoDeErroEsperado) || quantidadeErro == 0)
                throw new Exception("DEVE EXISTIR UM CODIGO DE ERRO A SER PASSADO E QUANTIDADE");

            var erros = new string[quantidadeErro];
            for (int i = 0; i < quantidadeErro; i++)
            {
                erros[i] = codigoDeErroEsperado;
            }

            ValidarTabelaDeRetornoFG02(naoDeveEncontrar, true, erros);
        }
        public void ValidarTabelaDeRetorno(params string[] codigosDeErroEsperados)
        {
            ValidarTabelaDeRetornoFG02(false, false, codigosDeErroEsperados);
        }

        public void ValidarTabelaDeRetornoFG02(bool naoDeveEncontrar = false, bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            try
            {
                AjustarEntradaErros(ref codigosDeErroEsperados);
                logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
                var validador = new ValidadorTabelaRetornoFG02(tipoArquivoTeste.ObterTabelaStageEnum(), nomeArquivo, logger,
                    valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter);

                if (validador.ValidarTabela(TabelasEnum.TabelaRetorno, naoDeveEncontrar, validaQuantidadeErros, codigosDeErroEsperados))
                    logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
                else
                    ExplodeFalha();
            }
            catch (Exception)
            {
                TratarErro($" Validação da Tabela Retorno");
            }
        }

        protected void ValidarStagesSemGerarErro(CodigoStage codigo, bool aoMenosUmComCodigoEsperado = false)
        {
            var statusAtualDoTeste = sucessoDoTeste;
            try
            {
                ValidarStages(codigo, aoMenosUmComCodigoEsperado);
            }
            catch(Exception ex)
            {
                if (statusAtualDoTeste)
                    sucessoDoTeste = true;
            }
        }

        protected string CarregarIdtransacao(LinhaArquivo linha)
        {
            return linha.ObterCampoDoArquivo("NR_APOLICE").ValorFormatado + linha.ObterCampoDoArquivo("NR_ENDOSSO").ValorFormatado + linha.ObterCampoDoArquivo("CD_RAMO").ValorFormatado + linha.ObterCampoDoArquivo("NR_PARCELA").ValorFormatado;
        }

        public override void FinalizarAlteracaoArquivo()
        {
            if (tipoArquivoTeste != TipoArquivo.ParcEmissao && tipoArquivoTeste != TipoArquivo.ParcEmissaoAuto)
                return;

            var linhas = valoresAlteradosBody.LinhasAlteradas();
            var linhasAColocarIdTransacao = new List<int>();
            foreach (var linha in linhas)
            {
                var alteracoes = valoresAlteradosBody.AlteracoesPorLinha(linha).ToList();
                foreach (var alteracao in alteracoes)
                {
                    //nr_apolice, nr_endosso, cd_ramo ou nr_parcela
                    if (alteracao.CamposAlterados.Any(x => x.Coluna == "NR_APOLICE"
                    || x.Coluna == "NR_ENDOSSO"
                    || x.Coluna == "CD_RAMO"
                    || x.Coluna == "NR_PARCELA"))
                        linhasAColocarIdTransacao.Add(alteracao.PosicaoDaLinha);
                }
            }
            foreach(var linha in linhasAColocarIdTransacao)
                AlterarLinha(linha, "ID_TRANSACAO", CarregarIdtransacao(arquivo.ObterLinha(linha)));

        }

        #region Procedures
        public static IList<string> ObterProcedures(TipoArquivo tipoArquivoTeste)
        {
            var lista = new List<string>();
            switch (tipoArquivoTeste)
            {
                case TipoArquivo.Cliente:
                    lista.Add("PRC_0035");
                    lista.Add("PRC_1039");
                    lista.Add("PRC_1040");
                    lista.Add("PRC_1041");
                    lista.Add("PRC_0267");

                    break;
                case TipoArquivo.ParcEmissao:
                    lista.Add("PRC_0011");
                    lista.Add("PRC_0013");
                    lista.Add("PRC_0016");
                    lista.Add("PRC_0018");
                    lista.Add("PRC_0019");
                    lista.Add("PRC_0020");
                    lista.Add("PRC_0033");
                    lista.Add("PRC_0035");
                    lista.Add("PRC_0023");
                    lista.Add("PRC_0024");
                    lista.Add("PRC_0025");
                    lista.Add("PRC_0026");
                    lista.Add("PRC_0028");
                    lista.Add("PRC_0032");
                    lista.Add("PRC_0107");
                    lista.Add("PRC_0120");
                    lista.Add("PRC_0122");
                    lista.Add("PRC_0123");
                    lista.Add("PRC_0127");
                    lista.Add("PRC_0155");
                    lista.Add("PRC_0162");
                    lista.Add("PRC_0191");
                    lista.Add("PRC_0215");
                    lista.Add("PRC_0223");
                    lista.Add("PRC_1002");
                    lista.Add("PRC_1003");
                    lista.Add("PRC_1024");
                    lista.Add("PRC_1046");
                    lista.Add("PRC_1048");
                    //lista.Add("PRC_1056");
                    lista.Add("PRC_1065");
                    lista.Add("PRC_1067");
                    lista.Add("PRC_1083");
                    lista.Add("PRC_1091");
                    lista.Add("PRC_1092");
                    //lista.Add("PRC_1182");
                    //lista.Add("PRC_1183");
                    //lista.Add("PRC_1184");

                    break;

                case TipoArquivo.ParcEmissaoAuto:
                    lista.Add("PRC_0011");
                    lista.Add("PRC_0013");
                    lista.Add("PRC_0016");
                    lista.Add("PRC_0018");
                    lista.Add("PRC_0019");
                    lista.Add("PRC_0020");
                    lista.Add("PRC_0033");
                    lista.Add("PRC_0035");
                    lista.Add("PRC_0023");
                    lista.Add("PRC_0024");
                    lista.Add("PRC_0025");
                    lista.Add("PRC_0026");
                    lista.Add("PRC_0028");
                    lista.Add("PRC_0032");
                    lista.Add("PRC_0107");
                    lista.Add("PRC_0120");
                    lista.Add("PRC_0122");
                    lista.Add("PRC_0123");
                    lista.Add("PRC_0127");
                    lista.Add("PRC_0155");
                    lista.Add("PRC_0162");
                    lista.Add("PRC_0191");
                    lista.Add("PRC_0215");
                    lista.Add("PRC_0223");
                    lista.Add("PRC_1002");
                    lista.Add("PRC_1003");
                    lista.Add("PRC_1024");
                    lista.Add("PRC_1046");
                    lista.Add("PRC_1048");
                    //lista.Add("PRC_1056");
                    lista.Add("PRC_1065");
                    lista.Add("PRC_1067");
                    lista.Add("PRC_1083");
                    lista.Add("PRC_1091");
                    lista.Add("PRC_1092");
                    //lista.Add("PRC_1182");
                    //lista.Add("PRC_1183");
                    //lista.Add("PRC_1184");
                    break;
                case TipoArquivo.Comissao:
                    lista.Add("PRC_0033");
                    lista.Add("PRC_0035");
                    lista.Add("PRC_0024");
                    lista.Add("PRC_0025");
                    lista.Add("PRC_0052");
                    lista.Add("PRC_0218");
                    lista.Add("PRC_1048");
                    //lista.Add("PRC_1049");
                    //lista.Add("PRC_1111");
                    break;

                case TipoArquivo.LanctoComissao:
                    lista.Add("PRC_0033");
                    lista.Add("PRC_0035");
                    lista.Add("PRC_0026");
                    lista.Add("PRC_0124");
                    lista.Add("PRC_1190");
                    lista.Add("PRC_1191");
                    lista.Add("PRC_1193");
                    break;
                case TipoArquivo.OCRCobranca:
                    lista.Add("PRC_0033");
                    lista.Add("PRC_0035");
                    lista.Add("PRC_1167");
                    lista.Add("PRC_0124");

                    break;
                case TipoArquivo.Sinistro:
                    lista.Add("PRC_0033");
                    lista.Add("PRC_0035");
                    lista.Add("PRC_0023");
                    lista.Add("PRC_0024");
                    lista.Add("PRC_0025");
                    lista.Add("PRC_0026");
                    //lista.Add("PRC_0027");
                    //lista.Add("PRC_0070");
                    lista.Add("PRC_0080");
                    //lista.Add("PRC_0081");
                    lista.Add("PRC_0082");
                    lista.Add("PRC_0085");
                    lista.Add("PRC_0086");
                    lista.Add("PRC_0087");
                    lista.Add("PRC_0088");
                    lista.Add("PRC_0107");
                    lista.Add("PRC_0111");
                    lista.Add("PRC_0119");
                    lista.Add("PRC_0120");
                    lista.Add("PRC_0128");
                    lista.Add("PRC_0130");
                    lista.Add("PRC_0131");
                    lista.Add("PRC_0132");
                    lista.Add("PRC_0164");
                    lista.Add("PRC_0176");
                    lista.Add("PRC_0177");
                    lista.Add("PRC_0178");
                    //lista.Add("PRC_0181");
                    lista.Add("PRC_0182");
                    lista.Add("PRC_0184");
                    lista.Add("PRC_0185");
                    lista.Add("PRC_1048");
                    lista.Add("PRC_0129");
                    lista.Add("PRC_0267");

                    break;
                default:
                    throw new Exception("TIPO ARQUIVO NAO ENCONTRADO.");

            }

            return lista;
        }
        #endregion

    }
}
