using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
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

        public void SetarArquivoEmUso(ref Arquivo _arquivo)
        {
            _arquivo = _arquivo == null ? arquivo : _arquivo;
        }
        public void ValidarLogProcessamento(bool Sucesso, int vezesExecutado = 1, Arquivo _arquivo = null)
        {
            SetarArquivoEmUso(ref _arquivo);
            ValidarLogProcessamento(_arquivo, Sucesso, vezesExecutado, ObterProceduresASeremExecutadas(_arquivo));
        }

        public bool ValidarTabelaDeRetornoVazia(Arquivo _arquivo, bool deveHaverRegistros = true)
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

        protected void ValidarLogProcessamento(Arquivo _arquivo, bool Sucesso, int vezesExecutado, IList<string> proceduresASeremExecutadas)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao || !Parametros.ValidaLogProcessamento)
                return;

            var proceduresEsperadas = proceduresASeremExecutadas;

            if (_arquivo.Operadora != OperadoraEnum.LASA && _arquivo.Operadora != OperadoraEnum.SOFTBOX)
            {
                proceduresEsperadas = proceduresEsperadas.Where(x => x.ObterParteNumericaDoTexto() < 1000 || x.ObterParteNumericaDoTexto() == 200000).ToList();
            }

            try
            {
                var consulta = new Consulta();
                consulta.AdicionarConsulta("NM_ARQUIVO_TPA", _arquivo.NomeArquivo);
                var consultas = new ConjuntoConsultas();
                consultas.AdicionarConsulta(consulta);
                var lista = DataAccess.ChamarConsultaAoBanco<LinhaLogProcessamento>(consultas, logger);

                logger.InicioOperacao(OperacaoEnum.ValidarResultado, "Tabela:LogProcessamento");

                var falha = false;
                if (!Validar(lista.Count(), proceduresEsperadas.Count * vezesExecutado, "Quantidade de Procedures executadas"))
                    falha = true;
                if (!falha && !Validar((lista.All(x => x.ObterPorColuna("CD_STATUS").Valor == "S")), true, "Todos os CD_STATUS sao igual a 'S'"))
                    falha = true;



                var procedureNaoEncontrada = proceduresEsperadas.Where(x => !lista.Any(z => z.ObterPorColuna("CD_PROCEDURE").Valor.Contains(x))); //lista.Where(x => proceduresEsperadas.Any(z => x.ObterPorColuna("CD_PROCEDURE").Valor.Contains(z)) == false);
                if (!Validar(procedureNaoEncontrada.Count() > 0, false, $"Existem PROCEDURES NAO ENCONTRADAS : {procedureNaoEncontrada.ToList().ObterListaConcatenada(" ,")}"))
                    falha = true;

                var proceduresAMais = lista.Where(x => !proceduresEsperadas.Any(z => x.ObterPorColuna("CD_PROCEDURE").Valor.Contains(z))).ToList(); //lista.Where(x => proceduresEsperadas.Any(z => x.ObterPorColuna("CD_PROCEDURE").Valor.Contains(z)) == false);
                if (!Validar(proceduresAMais.Count() > 0, false, $"Existem PROCEDURES EXECUTADAS A MAIS : {proceduresAMais.Select(x => x.ObterPorColuna("CD_PROCEDURE").Valor).ObterListaConcatenada(" ,")}"))
                    falha = true;

                if (Sucesso && falha || !Sucesso && !falha)
                {
                    ExplodeFalha();
                }
                logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, "Tabela:LogProcessamento");
            }
            catch (Exception ex)
            {
                TratarErro("Validação da LogProcessamento");
            }
        }

        public abstract void ValidarTabelaDeRetorno(Arquivo _arquivo, bool naoDeveEncontrar = false, bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados);

        public virtual IList<ILinhaTabela> ValidarStages(Arquivo _arquivo, bool deveHaverRegistro, int codigoEsperado = 0, bool aoMenosUmCodigoEsperado = false)
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

        public void ExecutarEValidarFG01_2(Arquivo _arquivo)
        {
            logger.EscreverBloco("Inicio da Validação da FG01_2.");
            ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaFG01_2Enum().ObterTexto());
            ValidarStages(CodigoStage.AprovadoNaFG01_2, false, _arquivo);
            ValidarTabelaDeRetorno(_arquivo, false);
            logger.EscreverBloco("Fim da Validação da FG01_2. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
        }

        public void EnviarParaOds(Arquivo _arquivo, bool executaFGs = true, bool alterarCdCliente = true, CodigoStage codigoesperadostg = CodigoStage.AprovadoNegocioSemDependencia)
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
            }
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

        public void EnviarParaOdsAlterandoCliente(Arquivo _arquivo, bool alterarCdCliente = true)
        {
            EnviarParaOds(_arquivo, true, alterarCdCliente);
        }


        public IList<ILinhaTabela> ValidarStages(CodigoStage codigo, bool aoMenosUmComCodigoEsperado = false, Arquivo _arquivo = null)
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

        protected bool Validar(bool obtido, bool esperado, string tituloValidacao)
        {
            logger.EscreveValidacao(obtido.ToString(), esperado.ToString(), tituloValidacao);

            if (esperado == obtido)
                return true;
            return false;
        }

        protected bool Validar(int obtido, int esperado, string tituloValidacao)
        {
            logger.EscreveValidacao(obtido.ToString(), esperado.ToString(), tituloValidacao);

            if (esperado == obtido)
                return true;
            return false;
        }

        public void ConfereQtdLinhas(Arquivo _arquivo, int numeroDeLinhasEsperado)
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

        public void AlterarDadosDeCobertura(int posicaoLinha, Cobertura cobertura, Arquivo _arquivo = null)
        {
            if (_arquivo == null)
                _arquivo = arquivo;
            var operadora = _arquivo.Operadora;

            if (operadora == OperadoraEnum.LASA || operadora == OperadoraEnum.SOFTBOX)
            {
                //var premioTotal = CalcularValorPremioTotal(cobertura, _arquivo[posicaoLinha]["VL_IS"].ObterValorDecimal());
                //_arquivo.AlterarLinha(posicaoLinha, "VL_PREMIO_TOTAL", premioTotal.ValorFormatado());

                //var premioLiquido = CalcularValorPremioLiquido(cobertura, premioTotal);
                //_arquivo.AlterarLinha(posicaoLinha, "VL_PREMIO_LIQUIDO", premioLiquido.ValorFormatado());

                //premioTotal = premioTotal + 1M;
                //premioLiquido = premioLiquido + 1M;

                //_arquivo.AlterarLinha(posicaoLinha, "VL_IOF", (premioTotal - premioLiquido).ValorFormatado());

                _arquivo.AlterarLinha(1, "VL_PREMIO_LIQUIDO", "23.27");
                _arquivo.AlterarLinha(1, "VL_IOF", "1.72");
                _arquivo.AlterarLinha(1, "VL_PREMIO_TOTAL", "24.99");

            }
            _arquivo.AlterarLinha(posicaoLinha, "CD_COBERTURA", cobertura.CdCobertura);
            _arquivo.AlterarLinha(posicaoLinha, "CD_PRODUTO", cobertura.CdProduto);
            _arquivo.AlterarLinha(posicaoLinha, "CD_RAMO", cobertura.CdRamoCobertura);

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

        public void CriarNovaLinhaParaEmissao(Arquivo arquivoParc, int linhaDeReferencia = 0)
        {
            var operadora = arquivoParc.Operadora;
            if (operadora == OperadoraEnum.TIM)
                CriarNovaLinhaEmissaoTim(arquivoParc);
            else if (operadora == OperadoraEnum.PITZI)
                CriarNovaLinhaEmissaoPitzi(arquivoParc);
            else
                arquivoParc.AdicionarLinha(arquivoParc.ObterLinha(linhaDeReferencia).Clone());

            var index = arquivoParc.Linhas.Count - 1;
            arquivoParc.AlterarLinha(index, "CD_TIPO_EMISSAO", ParametrosRegrasEmissao.CarregaTipoEmissaoParaSegundaLinhaDaEmissao(operadora));
            arquivoParc.AlterarLinha(index, "NR_ENDOSSO", ParametrosRegrasEmissao.CarregaProximoNumeroEndosso(arquivoParc[linhaDeReferencia]));
            arquivoParc.AlterarLinha(index, "NR_PARCELA", arquivoParc[linhaDeReferencia]["NR_PARCELA"].ObterProximoValorInteiro());
            arquivoParc.AlterarLinha(index, "NR_SEQUENCIAL_EMISSAO", ParametrosRegrasEmissao.CarregaProximoNumeroSequencialEmissao(arquivoParc[linhaDeReferencia], operadora));
            arquivoParc.AjustarQtdLinhasNoFooter();
        }

        public void AjustarArquivoDeBaixaParaParcela(Arquivo arquivoParcEmissao, Arquivo arquivoCobranca, int linhaReferenciaParc, string cdOcorrencia)
        {
            IgualarCamposQueExistirem(arquivoParcEmissao.ObterLinha(linhaReferenciaParc), arquivoCobranca.ObterLinha(0));
            arquivoCobranca.AlterarLinha(0, "NR_PARCELA", arquivoParcEmissao[linhaReferenciaParc]["NR_PARCELA"]);
            arquivoCobranca.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", arquivoParcEmissao[linhaReferenciaParc]["NR_SEQUENCIAL_EMISSAO"]);
            arquivoCobranca.AlterarLinha(0, "CD_OCORRENCIA", cdOcorrencia);
            arquivoCobranca.AlterarLinha(0, "DT_OCORRENCIA", arquivoParcEmissao[linhaReferenciaParc]["DT_EMISSAO"]);
            arquivoCobranca.AlterarLinha(0, "VL_PREMIO_PAGO", arquivoParcEmissao[linhaReferenciaParc]["VL_PREMIO_TOTAL"]);
        }

        private void CriarNovaLinhaEmissaoTim(Arquivo arquivoParc)
        {
            arquivoParc.AdicionarLinha(ParametrosLinhaEmissao.CarregaLinhaEmissaoTIM(arquivoParc[0], arquivoParc.Linhas.Count - 1));
            var camposASeremIgualados = arquivoParc[0].Campos.Where(x => !x.ColunaArquivo.StartsWith("VL_") && x.ColunaArquivo != "CD_TIPO_EMISSAO").Select(x => x.ColunaArquivo).ToArray();
            IgualarCampos(arquivoParc[0], arquivoParc[arquivoParc.Linhas.Count - 1], camposASeremIgualados);
        }

        public LinhaArquivo CriarNovaLinhaCapa(LinhaArquivo linhaReferencia)
        {
            var linhaCapa = ParametrosLinhaEmissao.CarregaLinhaCapaTIM(linhaReferencia);
            var camposASeremIgualados = linhaReferencia.Campos.Where(x => !x.ColunaArquivo.StartsWith("VL_") && x.ColunaArquivo != "CD_TIPO_EMISSAO").Select(x => x.ColunaArquivo).ToArray();
            IgualarCampos(linhaReferencia, linhaCapa, camposASeremIgualados);
            return linhaCapa;
        }

        private void CriarNovaLinhaEmissaoPitzi(Arquivo arquivoParc)
        {
            arquivoParc.AdicionarLinha(ParametrosLinhaEmissao.CarregaLinhaEmissaoPITZI(arquivoParc[0], arquivoParc.Linhas.Count - 1));
            var camposASeremIgualados = arquivoParc[0].Campos.Where(x => !x.ColunaArquivo.StartsWith("VL_") && x.ColunaArquivo != "CD_TIPO_EMISSAO").Select(x => x.ColunaArquivo).ToArray();
            IgualarCampos(arquivoParc[0], arquivoParc[arquivoParc.Linhas.Count - 1], camposASeremIgualados);
        }

        public void CriarNovaLinhaParaEmissaoComMesmoEndossoEParcela(Arquivo arquivoParc, int linhaDeReferencia = 0)
        {
            arquivoParc.AdicionarLinha(arquivoParc.ObterLinha(linhaDeReferencia).Clone());
            var index = arquivoParc.Linhas.Count - 1;
            arquivoParc.AlterarLinha(index, "CD_TIPO_EMISSAO", ParametrosRegrasEmissao.CarregaTipoEmissaoParaSegundaLinhaDaEmissao(arquivoParc.Operadora));
            arquivoParc.AlterarLinha(index, "NR_ENDOSSO", arquivoParc[linhaDeReferencia]["NR_ENDOSSO"]);
            arquivoParc.AlterarLinha(index, "NR_PARCELA", arquivoParc[linhaDeReferencia]["NR_PARCELA"]);
            arquivoParc.AlterarLinha(index, "NR_SEQUENCIAL_EMISSAO", arquivoParc[linhaDeReferencia]["NR_SEQUENCIAL_EMISSAO"]);
        }


        public void AlterarLinhaParaPrimeiraEmissao(Arquivo arquivoParc, int linhaDeReferencia = 0)
        {
            if (arquivoParc.Operadora == OperadoraEnum.PAPCARD)


                arquivoParc.AlterarLinha(linhaDeReferencia, "ID_TRANSACAO_CANC", "");
            arquivoParc.AlterarLinha(linhaDeReferencia, "CD_TIPO_EMISSAO", ParametrosRegrasEmissao.CarregaTipoEmissaoParaPrimeiraLinhaDaEmissao(arquivoParc.Operadora));
            arquivoParc.AlterarLinha(linhaDeReferencia, "NR_ENDOSSO", ParametrosRegrasEmissao.CarregaPrimeiroNumeroEndosso(arquivoParc[linhaDeReferencia], arquivoParc.Operadora));
            arquivoParc.AlterarLinha(linhaDeReferencia, "NR_PARCELA", ParametrosRegrasEmissao.CarregaPrimeiroNrParcela(arquivoParc.Operadora));
            arquivoParc.AlterarLinha(linhaDeReferencia, "NR_SEQUENCIAL_EMISSAO", ParametrosRegrasEmissao.CarregaPrimeiroNumeroSequencialEmissao(arquivoParc.Operadora));
            if (arquivoParc.Operadora == OperadoraEnum.PAPCARD)
            {
                arquivoParc.AlterarLinha(linhaDeReferencia, "NR_PROPOSTA", ParametrosRegrasEmissao.GerarNrApolicePapCard());
            }
        }

        public void AlterarCdCorretorETipoComissaoDaTriplice(ITriplice triplice, string tipoComissao, TabelaParametrosData dados)
        {
            triplice.AlterarParcEComissao(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracaoECobertura
            (triplice.ArquivoComissao.Header[0]["CD_TPA"], tipoComissao, triplice.ArquivoParcEmissao[0]["CD_COBERTURA"]));
            triplice.ArquivoComissao.AlterarLinha(0, "CD_TIPO_COMISSAO", tipoComissao);
        }

        public void AdicionarNovaCoberturaNaEmissao(Arquivo arquivoParc, TabelaParametrosData dados, int posicaoLinha = 0, Cobertura cobertura = null)
        {
            arquivoParc.ReplicarLinha(posicaoLinha, 1);
            var cdRamo = arquivoParc.Operadora == OperadoraEnum.TIM ? arquivoParc[arquivoParc.Linhas.Count - 1]["CD_RAMO"] : "";
            cobertura = cobertura == null ? dados.ObterCoberturaDiferenteDe(arquivoParc[arquivoParc.Linhas.Count - 1]["CD_COBERTURA"], arquivoParc.Header[0]["CD_TPA"], true) : cobertura;
            AlterarDadosDeCobertura(arquivoParc.Linhas.Count - 1, cobertura, arquivoParc);
        }

        protected void AdicionarTipoComissao(Arquivo _arquivo, string valorPremioLiquido, string cdTipoComissao, int posicaoLinha)
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
