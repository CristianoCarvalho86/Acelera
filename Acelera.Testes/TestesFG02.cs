using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.Repositorio;
using Acelera.Testes.Validadores;
using Acelera.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public class TestesFG02 : TestesFG01
    {
        protected override string NomeFG => "FG02";
        public TestesFG02():base()
        {
            
        }

        protected override void IniciarTeste(TipoArquivo tipo, string numeroDoTeste, string nomeDoTeste)
        {
            sucessoDoTeste = true;

            base.IniciarTeste(tipo, this.numeroDoTeste, nomeDoTeste);
            
        }

        public override void ValidarFGsAnteriores(Arquivo _arquivo = null)
        {
            SetarArquivoEmUso(ref _arquivo);

            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            base.ValidarFGsAnteriores(_arquivo);

            logger.EscreverBloco("Inicio da Validação da FG01.");
            //PROCESSAR O ARQUIVO CRIADO
            base.ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaFG01Enum().ObterTexto());
            base.ValidarLogProcessamento(_arquivo,true, 1, RepositorioProcedures.ObterProcedures(FGs.FG01,_arquivo.tipoArquivo));
            base.ValidarStages(CodigoStage.AprovadoNaFG01,false, _arquivo);
            ValidarTabelaDeRetornoFG01(_arquivo);
            logger.EscreverBloco("Fim da Validação da FG01. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
            if(_arquivo.tipoArquivo == TipoArquivo.Sinistro)
            {
                logger.EscreverBloco("Inicio da Execução da FG01_1.");
                base.ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaFG01_1_Enum().ObterTexto());
                logger.EscreverBloco("Fim da Execução da FG01_1. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
            }

            var fgDTEmissao = _arquivo.NomeArquivo.Contains(TipoArquivo.ParcEmissaoAuto.ObterPrefixoOperadoraNoArquivo()) ? 
                FGs.FGR_DT_EMISSAO_MES_CONTABIL_PARCELA_AUTO : FGs.FGR_DT_EMISSAO_MES_CONTABIL_PARCELA;

            logger.EscreverBloco($"Inicio da Execução da {fgDTEmissao.ObterTexto()}.");
            ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaDaFG(fgDTEmissao));
            base.ValidarStages(fgDTEmissao.ObterCodigoDeSucessoOuFalha(true));
            ValidarTabelaDeRetornoFG01(_arquivo);
            logger.EscreverBloco($"Fim da Execução da {fgDTEmissao.ObterTexto()}. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));

            logger.EscreverBloco("Inicio da Execução da FG01_2.");
            ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaFG01_2Enum().ObterTexto());
            base.ValidarStages(CodigoStage.AprovadoNaFG01_2);
            ValidarTabelaDeRetornoFG01(_arquivo);
            logger.EscreverBloco("Fim da Execução da FG01_2. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));


            ValidarTeste();
            logger.EscreverBloco("Inicio da FG02.");
        }

        public void ValidarTabelaDeRetorno(bool naoDeveEncontarOsErrosDefinidos, params string[] codigosDeErroEsperados)
        {
            ValidarTabelaDeRetorno(naoDeveEncontarOsErrosDefinidos, false, codigosDeErroEsperados);
        }

        public override void ValidarTabelaDeRetorno(Arquivo _arquivo, bool naoDeveEncontrarOsErrosDefinidos,bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            try
            {
                AjustarEntradaErros(ref codigosDeErroEsperados);
                logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
                var validador = new ValidadorTabelaRetorno(_arquivo.NomeArquivo, logger,_arquivo);

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

            ValidarTabelaDeRetorno(naoDeveEncontrar, true, erros);
        }
        public new void ValidarTabelaDeRetorno(Arquivo _arquivo = null,params string[] codigosDeErroEsperados)
        {
            _arquivo = _arquivo == null ? arquivo : _arquivo;
            ValidarTabelaDeRetorno(_arquivo,false, false, codigosDeErroEsperados);
        }

        protected void ValidarStagesSemGerarErro(CodigoStage codigo, bool aoMenosUmComCodigoEsperado = false, Arquivo _arquivo = null)
        {
            _arquivo = _arquivo == null ? arquivo : _arquivo;
            var statusAtualDoTeste = sucessoDoTeste;
            try
            {
                ValidarStages(codigo, aoMenosUmComCodigoEsperado, _arquivo);
            }
            catch(Exception ex)
            {
                if (statusAtualDoTeste)
                    sucessoDoTeste = true;
            }
        }

        protected void ValidarTabelaDeRetornoSemGerarErro(Arquivo _arquivo = null)
        {
            SetarArquivoEmUso(ref _arquivo);
            var statusAtualDoTeste = sucessoDoTeste;
            try
            {
                ValidarTabelaDeRetorno(_arquivo);
                sucessoDoTeste = statusAtualDoTeste;
            }
            catch (Exception ex)
            {
                if (statusAtualDoTeste)
                    sucessoDoTeste = true;
            }
        }


        protected string CarregarIdtransacao(LinhaArquivo linha)
        {
            return linha.ObterCampoDoArquivo("NR_APOLICE").ValorFormatado + linha.ObterCampoDoArquivo("NR_ENDOSSO").ValorFormatado + linha.ObterCampoDoArquivo("CD_RAMO").ValorFormatado + linha.ObterCampoDoArquivo("NR_PARCELA").ValorFormatado;
        }

        public override void FinalizarAlteracaoArquivo(Arquivo _arquivo = null)
        {
            SetarArquivoEmUso(ref _arquivo);
            if (_arquivo.tipoArquivo != TipoArquivo.ParcEmissao && _arquivo.tipoArquivo != TipoArquivo.ParcEmissaoAuto)
                return;

            Parallel.ForEach(_arquivo.Linhas, linha => {
                var idTransacaoOld = linha["ID_TRANSACAO"];
                var idTransacaoNew = CarregarIdtransacao(linha);
                _arquivo.AlterarLinha(linha.Index, "ID_TRANSACAO", idTransacaoNew);
                _arquivo.AlterarLinhaComCampoIgualAValor("ID_TRANSACAO_CANC", idTransacaoOld, "ID_TRANSACAO_CANC", idTransacaoNew);
            });
            base.FinalizarAlteracaoArquivo(_arquivo);
        }

        public virtual IList<ILinhaTabela> ExecutarEValidar(Arquivo _arquivo, FGs fG, CodigoStage codigoEsperado, string cdMensagemNaTabelaDeRetorno = "", bool deveHaverRegistro = true)
        {
            SelecionarLinhaParaValidacao(0,false, _arquivo);
            ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaDaFG(fG));

            ValidarTabelaDeRetorno(_arquivo, false, true, new string[] { cdMensagemNaTabelaDeRetorno });

            return ValidarStages(_arquivo, deveHaverRegistro, (int)codigoEsperado);
        }

        public virtual IList<ILinhaTabela> ExecutarEValidarBatch(Arquivo _arquivo, string batch, CodigoStage codigoEsperado, string cdMensagemNaTabelaDeRetorno = "", bool deveHaverRegistro = true)
        {
            SelecionarLinhaParaValidacao(0, false, _arquivo);

            logger.Escrever($"CHAMADA DA BAT : {batch}");

            CommandUtils.RunBatch(batch, out string output, out string erro);

            logger.Escrever($"EXECUÇÃO DA BAT : {Environment.NewLine}{output}");
            if(!string.IsNullOrEmpty(erro))
                TratarErro($"CONSOLE DE EXECUÇÃO DA BAT RETORNOU UM ERRO : {erro}");
            
            ValidarTabelaDeRetorno(_arquivo, false, true, new string[] { cdMensagemNaTabelaDeRetorno });

            return ValidarStages(_arquivo, deveHaverRegistro, (int)codigoEsperado);
        }

        protected void ExecutarEValidarAteFg02(Arquivo _arquivo, string mensagemErroNaTabelaDeRetorno = "")
        {
            ExecutarEValidar(_arquivo, FGs.FG00, FGs.FG00.ObterCodigoDeSucessoOuFalha(true));
            ValidarControleArquivo();
            ValidarLogProcessamento(_arquivo,true, 1, RepositorioProcedures.ObterProcedures(FGs.FG00, _arquivo.tipoArquivo));

            ExecutarEValidar(_arquivo, FGs.FG01, FGs.FG01.ObterCodigoDeSucessoOuFalha(true));
            ValidarLogProcessamento(_arquivo,true, 1, RepositorioProcedures.ObterProcedures(FGs.FG01, _arquivo.tipoArquivo));

            ExecutarEValidar(_arquivo, FGs.FG01_2, FGs.FG01_2.ObterCodigoDeSucessoOuFalha(true));

            ExecutarEValidar(_arquivo, FGs.FG02, FGs.FG02.ObterCodigoDeSucessoOuFalha(string.IsNullOrEmpty(mensagemErroNaTabelaDeRetorno)), mensagemErroNaTabelaDeRetorno);
            ValidarLogProcessamento(_arquivo,true, 1, RepositorioProcedures.ObterProcedures(FGs.FG02, _arquivo.tipoArquivo));

            ValidarTeste();
        }

        public virtual IList<ILinhaTabela> ExecutarEValidarEsperandoErro(Arquivo _arquivo, FGs fG, CodigoStage? codigoEsperado, bool aoMenosUmCodigoEsperado = false)
        {
            SelecionarLinhaParaValidacao(0);
            ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaDaFG(fG));

            ValidarTabelaDeRetornoSemGerarErro();

            if (codigoEsperado == null)
            {
                return ValidarStages(_arquivo, false);
            }
            return ValidarStages(_arquivo, true, (int)codigoEsperado, aoMenosUmCodigoEsperado);
        }

        public virtual IList<ILinhaTabela> ValidarEsperandoErro(Arquivo _arquivo, CodigoStage? codigoEsperado, bool aoMenosUmCodigoEsperado = false)
        {
            SelecionarLinhaParaValidacao(0);

            ValidarTabelaDeRetornoSemGerarErro();

            if (codigoEsperado == null)
            {
                return ValidarStages(_arquivo, false);
            }
            
            var linhas = ValidarStages(_arquivo, true, (int)codigoEsperado, aoMenosUmCodigoEsperado);
            ValidarTeste();
            return linhas;
        }

        protected override IList<string> ObterProceduresASeremExecutadas(Arquivo _arquivo)
        {
            return RepositorioProcedures.ObterProcedures(FGs.FG02, _arquivo.tipoArquivo);
        }

    }
}
