﻿using Acelera.Contratos;
using Acelera.Domain;
using Acelera.Domain.DataAccess;
using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.RegrasNegocio;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.DataAccessRep.ODS;
using Acelera.Testes.Validadores;
using Acelera.Testes.Validadores.FG02;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Acelera.Testes
{
    public abstract class TesteFG : TesteBase
    {
        protected abstract string NomeFG { get; }
        protected bool FinalizaTeste { get; set; }

        public TesteFG()
        {
            FinalizaTeste = true;
        }

        public void SetarArquivoEmUso(ref IArquivo _arquivo)
        {
            _arquivo = _arquivo == null ? arquivo : _arquivo;
        }
        public void ValidarLogProcessamento(bool Sucesso, int vezesExecutado = 1, IArquivo _arquivo = null)
        {
            SetarArquivoEmUso(ref _arquivo);
            if (!execucaoRegras.ValidarLogProcessamento(_arquivo, Sucesso, vezesExecutado, ObterProceduresASeremExecutadas(_arquivo)))
                ExplodeFalha();
        }       

        public bool ValidarTabelaDeRetornoVazia(IArquivo _arquivo, bool deveHaverRegistros = true)
        {
            var validadorTabelaDeRetorno = new ValidadorTabelaRetorno(_arquivo.NomeArquivo, logger, _arquivo);
            var linhasDaTabelaDeRetorno = validadorTabelaDeRetorno.RetornarRegistrosDaTabelaDeRetorno();
            if (!deveHaverRegistros && linhasDaTabelaDeRetorno.Count > 0)
            {
                TratarErro($"FORAM ENCONTRADOS ERROS NA TABELA DE RETORNO : {linhasDaTabelaDeRetorno.Select(x => x.ObterPorColuna("CD_MENSAGEM").ValorFormatado).ObterListaConcatenada(" ,")}");
                return false;
            }
            if (deveHaverRegistros && linhasDaTabelaDeRetorno.Count == 0)
            {
                TratarErro($"NAO FORAM ENCONTRADOS ERROS NA TABELA DE RETORNO - ERAM ESPERADOS ERROS");
                return false;
            }
            return true;
        }


        public abstract void ValidarTabelaDeRetorno(IArquivo _arquivo, bool naoDeveEncontrar = false, bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados);

        public virtual IList<ILinhaTabela> ValidarStages(IArquivo _arquivo, bool deveHaverRegistro, int codigoEsperado = 0, bool aoMenosUmCodigoEsperado = false)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return null;

            var linhasEncontradas = new List<ILinhaTabela>();
            try
            {
                logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{_arquivo.tipoArquivo.ObterTabelaStageEnum().ObterTexto()}");
                var validador = new ValidadorStages(_arquivo.tipoArquivo.ObterTabelaStageEnum(), _arquivo.NomeArquivo, logger, _arquivo);


                if (validador.ValidarTabela(deveHaverRegistro, out linhasEncontradas, codigoEsperado, aoMenosUmCodigoEsperado))
                    logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{_arquivo.tipoArquivo.ObterTabelaStageEnum().ObterTexto()}");
                else
                    ExplodeFalha();
            }
            catch (Exception ex)
            {
                TratarErro($" Validação da Stage : {_arquivo.tipoArquivo.ObterTabelaStageEnum().ObterTexto()} - {ex.Message}");
            }

            return linhasEncontradas;
        }

        public void ExecutarEValidarFG01_2(IArquivo _arquivo)
        {
            logger.EscreverBloco("Inicio da Validação da FG01_2.");
            ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaFG01_2Enum().ObterTexto());
            ValidarStages(CodigoStage.AprovadoNaFG01_2, false, _arquivo);
            ValidarTabelaDeRetorno(_arquivo, false);
            logger.EscreverBloco("Fim da Validação da FG01_2. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
        }

        public void EnviarParaOds(IArquivo _arquivo, bool executaFGs = true, bool alterarCdCliente = true, CodigoStage codigoesperadostg = CodigoStage.AprovadoNegocioSemDependencia)
        {
            if (alterarCdCliente && _arquivo.Operadora != OperadoraEnum.SGS)
            {
                int i = 0;
                foreach (var linha in _arquivo.Linhas)
                    _arquivo.AlterarLinhaSeExistirCampo(i++, "CD_CLIENTE", dados.ObterCdClienteParceiro(true, _arquivo.Header[0]["CD_TPA"]) /* ParametrosBanco.ObterCDClienteCadastrado(_arquivo.Operadora)*/);
            }


            if (Parametros.ModoExecucao != ModoExecucaoEnum.Completo)
            {
                SalvarArquivo(_arquivo);
                arquivosSalvosODS.Add(_arquivo.EnderecoCompletoArquivoSalvo);
                return;
            }


            if (executaFGs)
            {
                SalvarArquivo(_arquivo);
                arquivosSalvosODS.Add(_arquivo.EnderecoCompletoArquivoSalvo);
                ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaFG00Enum().ObterTexto());
                ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaFG01Enum().ObterTexto());
                //ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaFG01_1_Enum().ObterTexto());
                ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaFG01_2Enum().ObterTexto());
                ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaFG02Enum().ObterTexto());
                if(_arquivo.tipoArquivo == TipoArquivo.Sinistro)
                    ChamarExecucao("FGR_NR_ITEM_TP_ITEM_SINISTRO");
            }

            _arquivo.valoresAlteradosBody = new AlteracoesArquivo();
            SelecionarLinhaParaValidacao(0);
            var linhas = ValidarStages(codigoesperadostg, false, _arquivo);

            ValidarTeste();

            if (_arquivo.tipoArquivo == TipoArquivo.ParcEmissaoAuto)
                foreach (var linha in linhas)
                {
                    if (new string[] { "10", "11", "9", "12", "13", "21" }.Contains(linha.ObterPorColuna("CD_TIPO_EMISSAO").ValorFormatado))
                    {
                        ODSInsertParcAutoCancelamento.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                        ODSUpdateParcCancelamento.Update(logger);
                    }
                    else
                    {
                        ODSInsertParcAuto.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                        ODSInsertParcCobertura.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, TabelasEnum.ParcEmissaoAuto, logger);
                    }
                }
            if (_arquivo.tipoArquivo == TipoArquivo.ParcEmissao)
                foreach (var linha in linhas)
                {
                    if (new string[] { "10", "11" }.Contains(linha.ObterPorColuna("CD_TIPO_EMISSAO").ValorFormatado))
                    {
                        ODSInsertParcCancelamento.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                        ODSInsertParcCobertura.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, TabelasEnum.ParcEmissao, logger);
                        ODSUpdateParcCancelamento.Update(logger);
                    }
                    else
                    {
                        ODSInsertParcData.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                        ODSInsertParcCobertura.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, TabelasEnum.ParcEmissao, logger);
                    }
                }
            else if (_arquivo.tipoArquivo == TipoArquivo.Cliente)
                foreach (var linha in linhas)
                    ODSInsertClienteData.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);

            else if (_arquivo.tipoArquivo == TipoArquivo.Comissao)
                foreach (var linha in linhas)
                {
                    if (new string[] { "10", "11" }.Contains(dados.ObterLinhaStageParcelaReferenteALinhaComissao(linha).ObterPorColuna("CD_TIPO_EMISSAO").ValorFormatado))
                    {
                        ODSInsertComissaoCancelamentoData.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                        ODSInsertComissaoCoberturaCancelamentoData.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                    }
                    else
                    {
                        ODSInsertComissaoData.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                        ODSInsertComissaoCoberturaData.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                    }
                }
            else if (_arquivo.tipoArquivo == TipoArquivo.Sinistro)
            {
                ODSInsertSinistroData.Insert(_arquivo.NomeArquivo, logger);
                ODSInsertMovimentoSinistro.Insert(_arquivo[0]["CD_AVISO"], logger);
            }

            else if (_arquivo.tipoArquivo == TipoArquivo.OCRCobranca)
            {
                ODSUpdateCobrancaPaga.Update(_arquivo.NomeArquivo, logger);
                if (!ODSUpdateCobrancaPaga.ValidaApolicePaga(_arquivo[0]["CD_CONTRATO"], logger))
                    ExplodeFalha("Apólice não foi marcada como paga");
            }

        }

        public void EnviarParaOdsAlterandoCliente(IArquivo _arquivo, bool alterarCdCliente = true)
        {
            EnviarParaOds(_arquivo, true, alterarCdCliente);
        }


        public IList<ILinhaTabela> ValidarStages(CodigoStage codigo, bool aoMenosUmComCodigoEsperado = false, IArquivo _arquivo = null)
        {
            _arquivo = _arquivo == null ? this.arquivo : _arquivo;
            AoMenosUmComCodigoEsperado = aoMenosUmComCodigoEsperado;
            var linhas = ValidarStages(_arquivo, true, (int)codigo);
            AoMenosUmComCodigoEsperado = false;
            return linhas;
        }


        protected void AjustarEntradaErros(ref string[] erros)
        {
            if (erros == null || (erros.Length == 1 && (erros.Contains(string.Empty) || erros.Contains(null))))
                erros = new string[] { };

        }

        protected void ExplodeFalha(string descricao = null)
        {
            TesteComErro(descricao);
            Assert.Fail();
        }

        protected void TesteComErro(string descricao = null)
        {
            if (!string.IsNullOrEmpty(descricao))
                logger.Erro(descricao);
            sucessoDoTeste = false;
            logger.TesteComFalha();
        }


        public void ConfereQtdLinhas(IArquivo _arquivo, int numeroDeLinhasEsperado)
        {
            if (_arquivo.Linhas.Count != numeroDeLinhasEsperado)
                ExplodeFalha($"ERRO NA CONFERENCIA DE QTD LINHAS. ESPERADO :{numeroDeLinhasEsperado}; OBTIDO :{_arquivo.Linhas.Count}");
        }


        protected void ValidarTeste()
        {
            if (!sucessoDoTeste)
                throw new Exception("Exceção encontrada no fim do teste : " + localDoErro);
        }

        protected void TratarErro(string erro)
        {
            logger.EscreverBloco("Houve um erro no teste -> " + erro);
            sucessoDoTeste = false;
            localDoErro += erro + ";";
        }

        [TestCleanup]
        public virtual void FimDoTeste()
        {
            if (!FinalizaTeste)
                return;

            logger.DefinirSucesso(sucessoDoTeste);
            var sucesso = sucessoDoTeste ? "SUCESSO" : "FALHA";
            logger.EscreverBloco($"RESULTADO DO TESTE {NomeFG} : {sucesso}");
            var nomeArquivoDeLog = string.Empty;

            if (arquivosSalvos != null && arquivosSalvos.Count > 0)
                foreach (var arqSalvo in arquivosSalvos)
                {
                    if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
                    {
                        nomeArquivoDeLog = arqSalvo.Split('\\').Last().ToUpper().Replace(".TXT", $"-Teste-{numeroDoTeste}-{NomeFG}-{sucesso}-Data-{DateTime.Now.ToString("ddMMyy_hhmm")}.TXT");
                        var prefixo = "";
                        if (arquivosSalvosODS.Contains(arqSalvo))
                            prefixo = "ODS_";


                        File.Copy(arqSalvo, Parametros.pastaLogArquivo + prefixo + nomeArquivoDeLog);
                        logger.EscreverBloco("Nome do arquivo de log criado : " + Parametros.pastaLogArquivo + nomeArquivoDeLog);
                        if (File.Exists(Parametros.pastaLogArquivo + nomeArquivoDeLog))
                        {
                            File.Delete(arqSalvo);
                            logger.EscreverBloco("Arquivo deletado : " + arqSalvo);
                        }
                    }
                }

            //if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo && !string.IsNullOrEmpty(Parametros.pastaLogArquivoCopia))
            //    File.Copy(pathOrigem, Parametros.pastaLogArquivoCopia + nomeArquivoDeLog);

            var op = arquivosSalvos[0].Split('\\').Last().Split('.').Take(2).Reverse().First().Replace(".", "");
            if (op.Length > 10)
                op = op.Substring(0, 10);


            logger.FimDoArquivo(numeroDoLote, op, Parametros.pastaLogCopia, Parametros.ModoExecucao);
        }

        public decimal CalcularValorPremioTotal(Cobertura cobertura, decimal vl_is)
        {
            decimal valorTotal = 0;
            valorTotal = ObterValorPremioTotalBruto(vl_is, cobertura);

            if (cobertura.TP_APLICACAO_PREMIO_BR == "PC")
                valorTotal = valorTotal - (valorTotal * cobertura.ValorPremioBrutoMenorDecimal);
            //Valor do Prêmio Aceito = Valor do Prêmio calculado – (Valor do Prêmio calculado * Menor valor parametrizado)
            else
                valorTotal = valorTotal - cobertura.ValorPremioBrutoMenorDecimal;

            return valorTotal;
        }

        public decimal CalcularValorPremioLiquido(Cobertura cobertura, decimal valorPremioTotal)
        {
            decimal valorTotalLiq = valorPremioTotal;

            if (cobertura.TP_APLICACAO_PREMIO_LQ == "PC")
                valorTotalLiq = valorTotalLiq - (valorTotalLiq * cobertura.ValorPremioLiquidoMenorDecimal);
            else
                valorTotalLiq = valorTotalLiq - cobertura.ValorPremioLiquidoMenorDecimal;


            return valorTotalLiq;
        }

        public decimal CalcularValorIOF(Cobertura cobertura, decimal valorIs)
        {
            var valorIof = ObterValorCalculadoIOF(valorIs, cobertura);

            if (cobertura.TP_APLICACAO_IOF == "PC")
                valorIof = valorIof - (valorIof * cobertura.VL_IOF_MENOR_decimal);
            else
                valorIof = valorIof - cobertura.VL_IOF_MENOR_decimal;
            return valorIof;
        }

        protected decimal ObterValorCalculadoIOF(decimal valorIS, Cobertura cobertura)
        {
            return (ObterValorPremioTotalLiquido(valorIS, cobertura) * (cobertura.ValorPercentualAlicotaIofDecimal * 100) / 100) *
                    (cobertura.VL_PERC_DISTRIBUICAO_decimal * 100);
        }

        protected decimal ObterValorPremioTotalBruto(decimal valorIS, Cobertura cobertura)
        {
            return valorIS * cobertura.VL_PERC_DISTRIBUICAO_decimal * cobertura.VL_PERC_TAXA_SEGURO_decimal;
            //(VL_IS * VL_PERC_TAXA_SEGURO) * VL_PERC_DISTRIBUICAO)
        }

        protected decimal ObterValorPremioTotalLiquido(decimal valorIS, Cobertura cobertura)
        {
            return ObterValorPremioTotalBruto(valorIS, cobertura) *
                (((1M + (cobertura.ValorPercentualAlicotaIofDecimal * 100)) / 100) * (cobertura.VL_PERC_DISTRIBUICAO_decimal * 100));
        }

        public void CriarNovaLinhaParaEmissao(IArquivo arquivoParc, int linhaDeReferencia = 0)
        {
            emissaoRegras.CriarNovaLinhaParaEmissao(arquivoParc, linhaDeReferencia);
        }

        public void AjustarArquivoDeBaixaParaParcela(IArquivo arquivoParcEmissao, IArquivo arquivoCobranca, int linhaReferenciaParc, string cdOcorrencia)
        {
            ArquivoUtils.IgualarCamposQueExistirem(arquivoParcEmissao.ObterLinha(linhaReferenciaParc), arquivoCobranca.ObterLinha(0),logger);
            arquivoCobranca.AlterarLinha(0, "NR_PARCELA", arquivoParcEmissao[linhaReferenciaParc]["NR_PARCELA"]);
            arquivoCobranca.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", arquivoParcEmissao[linhaReferenciaParc]["NR_SEQUENCIAL_EMISSAO"]);
            arquivoCobranca.AlterarLinha(0, "CD_OCORRENCIA", cdOcorrencia);
            arquivoCobranca.AlterarLinha(0, "DT_OCORRENCIA", arquivoParcEmissao[linhaReferenciaParc]["DT_EMISSAO"]);
            arquivoCobranca.AlterarLinha(0, "VL_PREMIO_PAGO", arquivoParcEmissao[linhaReferenciaParc]["VL_PREMIO_TOTAL"]);
        }
        

        public void AlterarCdCorretorETipoComissaoDaTrinca(ITrinca triplice, string tipoComissao, DadosParametrosData dados)
        {
            var cdCorretor = dados.ObterCdCorretorParaTipoRemuneracaoECobertura
                    (triplice.ArquivoComissao.Header[0]["CD_TPA"], tipoComissao, triplice.ArquivoParcEmissao[0]["CD_COBERTURA"]);
            for (int i = 0; i < triplice.ArquivoParcEmissao.Linhas.Count; i++)
            {
                triplice.ArquivoParcEmissao.AlterarLinha(i, "CD_CORRETOR", cdCorretor);
            }
            for (int i = 0; i < triplice.ArquivoComissao.Linhas.Count; i++)
            {
                triplice.ArquivoComissao.AlterarLinha(i, "CD_CORRETOR", cdCorretor);
                triplice.ArquivoComissao.AlterarLinha(i, "CD_TIPO_COMISSAO", tipoComissao);
            }
        }

        protected void AdicionarTipoComissao(IArquivo _arquivo, string valorPremioLiquido, string cdTipoComissao, int posicaoLinha)
        {
            var valor = valorPremioLiquido.ObterValorDecimal() / 2;
            _arquivo.AlterarLinha(posicaoLinha, "VL_COMISSAO", valor.ValorFormatado());
            _arquivo.ReplicarLinha(posicaoLinha, 1);
            _arquivo.AlterarLinha(_arquivo.Linhas.Count - 1, "CD_TIPO_COMISSAO", cdTipoComissao);
            _arquivo.AlterarLinha(_arquivo.Linhas.Count - 1, "VL_COMISSAO", valor.ValorFormatado());
            _arquivo.AlterarLinha(_arquivo.Linhas.Count - 1, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracaoECobertura
                (_arquivo.Header[0]["CD_TPA"], cdTipoComissao, _arquivo[_arquivo.Linhas.Count - 1]["CD_COBERTURA"]));
        }
    }
}
