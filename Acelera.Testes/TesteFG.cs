using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.DataAccessRep.ODS;
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

        protected abstract IList<string> ObterProceduresASeremExecutadas();

        public void ValidarLogProcessamento(bool Sucesso, int vezesExecutado = 1)
        {
            ValidarLogProcessamento(Sucesso, vezesExecutado, ObterProceduresASeremExecutadas());
        }

        protected void ValidarLogProcessamento(bool Sucesso, int vezesExecutado, IList<string> proceduresASeremExecutadas)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            var proceduresEsperadas = proceduresASeremExecutadas;

            if (operadora != OperadoraEnum.LASA && operadora != OperadoraEnum.SOFTBOX)
            {
                proceduresEsperadas = proceduresEsperadas.Where(x => x.ObterParteNumericaDoTexto() < 1000 || x.ObterParteNumericaDoTexto() == 200000).ToList();
            }

            try
            {
                var consulta = new Consulta();
                consulta.AdicionarConsulta("NM_ARQUIVO_TPA", arquivo.NomeArquivo);
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

        public abstract void ValidarTabelaDeRetorno(Arquivo arquivo,bool naoDeveEncontrar = false, bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados);

        public virtual IList<ILinhaTabela> ValidarStages(Arquivo _arquivo ,bool deveHaverRegistro, int codigoEsperado = 0, bool aoMenosUmCodigoEsperado = false)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return null;

            var linhasEncontradas = new List<ILinhaTabela>();
            try
            {
                logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{arquivo.tipoArquivo.ObterTabelaStageEnum().ObterTexto()}");
                var validador = new ValidadorStages(_arquivo.tipoArquivo.ObterTabelaStageEnum(), _arquivo.NomeArquivo, logger,
                    valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter);


                if (validador.ValidarTabela(deveHaverRegistro, out linhasEncontradas, codigoEsperado, aoMenosUmCodigoEsperado))
                    logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{arquivo.tipoArquivo.ObterTabelaStageEnum().ObterTexto()}");
                else
                    ExplodeFalha();
            }
            catch (Exception ex)
            {
                TratarErro($" Validação da Stage : {arquivo.tipoArquivo.ObterTabelaStageEnum().ObterTexto()} - {ex.Message}");
            }

            return linhasEncontradas;
        }

        public void ExecutarEValidarFG01_2(Arquivo arquivo)
        {
            logger.EscreverBloco("Inicio da Validação da FG01_2.");
            ChamarExecucao(arquivo.tipoArquivo.ObterTarefaFG01_2Enum().ObterTexto());
            ValidarStages(CodigoStage.AprovadoNaFG01_2,false, arquivo);
            ValidarTabelaDeRetorno(arquivo,false);
            logger.EscreverBloco("Fim da Validação da FG01_2. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
        }

        public void EnviarParaOds(Arquivo arquivo, bool executaFGs = true, bool alterarCdCliente = true, CodigoStage codigoesperadostg = CodigoStage.AprovadoNaFG01_2)
        {

            this.arquivo = arquivo;

            if (alterarCdCliente && operadora != OperadoraEnum.SGS)
            {
                int i = 0;
                foreach (var linha in arquivo.Linhas)
                    arquivo.AlterarLinhaSeExistirCampo(i++, "CD_CLIENTE", ParametrosBanco.ObterCDClienteCadastrado(operadora));
            }


            if (Parametros.ModoExecucao != ModoExecucaoEnum.Completo)
            {
                SalvarArquivo();
                return;
            }


            if (executaFGs)
            {
                SalvarArquivo();
                ChamarExecucao(arquivo.tipoArquivo.ObterTarefaFG00Enum().ObterTexto());
                ChamarExecucao(arquivo.tipoArquivo.ObterTarefaFG01Enum().ObterTexto());
                ChamarExecucao(arquivo.tipoArquivo.ObterTarefaFG01_2Enum().ObterTexto());
            }
            var linhas = ValidarStages(codigoesperadostg);

            if (arquivo.tipoArquivo == TipoArquivo.ParcEmissaoAuto)
                foreach (var linha in linhas)
                {
                    if (new string[] { "10", "11", "9", "12", "13", "21" }.Contains(linha.ObterPorColuna("CD_TIPO_EMISSAO").ValorFormatado))
                    {
                        ODSInsertParcAutoCancelamento.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                        ODSUpdateParcCancelamento.Update(logger);
                    }
                    else
                        ODSInsertParcAuto.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                }
            if (arquivo.tipoArquivo == TipoArquivo.ParcEmissao)
                foreach (var linha in linhas)
                {
                    if (new string[] { "10", "11" }.Contains(linha.ObterPorColuna("CD_TIPO_EMISSAO").ValorFormatado))
                    {
                        ODSInsertParcCancelamento.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                        ODSUpdateParcCancelamento.Update(logger);
                    }
                    else
                        ODSInsertParcData.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                }
            else if (arquivo.tipoArquivo == TipoArquivo.Cliente)
                foreach (var linha in linhas)
                    ODSInsertClienteData.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
            
            else if (arquivo.tipoArquivo == TipoArquivo.Comissao)
                foreach (var linha in linhas)
                    ODSInsertComissaoData.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);


        }

        public void EnviarParaOdsAlterandoCliente(Arquivo arquivo, bool alterarCdCliente = true)
        {
            EnviarParaOds(arquivo, true, alterarCdCliente);
        }


        public IList<ILinhaTabela> ValidarStages(CodigoStage codigo, bool aoMenosUmComCodigoEsperado = false, Arquivo arquivo = null)
        {
            arquivo = arquivo == null ? this.arquivo : arquivo;
            AoMenosUmComCodigoEsperado = aoMenosUmComCodigoEsperado;
            var linhas = ValidarStages(arquivo,true, (int)codigo);
            AoMenosUmComCodigoEsperado = false;
            return linhas;
        }


        protected void AjustarEntradaErros(ref string[] erros)
        {
            if (erros == null || (erros.Length == 1 && erros.Contains(string.Empty)))
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

        public void ConfereQtdLinhas(Arquivo arquivo, int numeroDeLinhasEsperado)
        {
            if (arquivo.Linhas.Count != numeroDeLinhasEsperado)
                ExplodeFalha($"ERRO NA CONFERENCIA DE QTD LINHAS. ESPERADO :{numeroDeLinhasEsperado}; OBTIDO :{arquivo.Linhas.Count}");
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
            logger.DefinirSucesso(sucessoDoTeste);
            var sucesso = sucessoDoTeste ? "SUCESSO" : "FALHA";
            logger.EscreverBloco($"RESULTADO DO TESTE {NomeFG} : {sucesso}");
            var nomeArquivoDeLog = string.Empty;
            if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
                nomeArquivoDeLog = arquivo.NomeArquivo.ToUpper().Replace(".TXT", $"-Teste-{numeroDoTeste}-{NomeFG}-{sucesso}-Data-{DateTime.Now.ToString("ddMMyy_hhmm")}.TXT");


            if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
                File.Copy(Parametros.pastaDestino + arquivo.NomeArquivo, Parametros.pastaLogArquivo + nomeArquivoDeLog);

            if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo && !string.IsNullOrEmpty(Parametros.pastaLogArquivoCopia))
                File.Copy(pathOrigem, Parametros.pastaLogArquivoCopia + nomeArquivoDeLog);

            //if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo && File.Exists(Parametros.pastaLogArquivo + nomeArquivoDeLog))
            //    File.Delete(Parametros.pastaDestino + arquivo.NomeArquivo);

            else if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
                logger.EscreverBloco("Erro ao copiar arquivo para pasta de log.");

            if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
                logger.EscreverBloco("Nome do arquivo de log criado : " + Parametros.pastaLogArquivo + nomeArquivoDeLog);


            operacao = arquivo.NomeArquivo.Split('.').Take(2).Reverse().First().Replace(".", "");
            if (operacao.Length > 5)
                operacao = operacao.Substring(0, 5);


            logger.FimDoArquivo(numeroDoLote, operacao, Parametros.pastaLogCopia, Parametros.ModoExecucao);
        }

        public void AlterarDadosDeCobertura(int posicaoLinha, Cobertura cobertura, Arquivo _arquivo = null)
        {
            if (_arquivo == null)
                _arquivo = arquivo;
            var operadora = EnumUtils.ObterOperadoraDoArquivo(_arquivo.NomeArquivo);

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

        public decimal CalcularValorPremioLiquido(Cobertura cobertura,decimal valorPremioTotal)
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
            var operadora = EnumUtils.ObterOperadoraDoArquivo(arquivoParc.NomeArquivo);
            if (operadora == OperadoraEnum.TIM)
                CriarNovaLinhaEmissaoTim(arquivoParc);
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
            var operadora = EnumUtils.ObterOperadoraDoArquivo(arquivoParcEmissao.NomeArquivo);
            IgualarCamposQueExistirem(arquivoParcEmissao, arquivo);
            arquivoCobranca.AlterarLinha(0, "NR_PARCELA", arquivoParcEmissao[linhaReferenciaParc]["NR_PARCELA"]);
            arquivoCobranca.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", ParametrosRegrasEmissao.CarregaProximoNumeroSequencialEmissao(arquivoParcEmissao[linhaReferenciaParc], operadora));
            arquivoCobranca.AlterarLinha(0, "CD_OCORRENCIA", cdOcorrencia);
            arquivoCobranca.AlterarLinha(0, "DT_OCORRENCIA", SomarData(arquivoParcEmissao[linhaReferenciaParc]["DT_EMISSAO"], 10));
            arquivoCobranca.AlterarLinha(0, "VL_PREMIO_PAGO", arquivoParcEmissao[linhaReferenciaParc]["VL_PREMIO_TOTAL"]);
        }

        private void CriarNovaLinhaEmissaoTim(Arquivo arquivoParc)
        {
            arquivoParc.AdicionarLinha(ParametrosLinhaEmissao.CarregaLinhaEmissaoTIM(arquivoParc[0], arquivoParc.Linhas.Count - 1));
            var camposASeremIgualados = arquivoParc[0].Campos.Where(x => !x.ColunaArquivo.StartsWith("VL_") && x.ColunaArquivo != "CD_TIPO_EMISSAO").Select(x => x.ColunaArquivo).ToArray();
            IgualarCampos(arquivoParc[0], arquivoParc[arquivoParc.Linhas.Count - 1], camposASeremIgualados);
        }

        public void CriarNovaLinhaParaEmissaoComMesmoEndossoEParcela(Arquivo arquivoParc, int linhaDeReferencia = 0)
        {
            arquivoParc.AdicionarLinha(arquivoParc.ObterLinha(linhaDeReferencia).Clone());
            var operadora = EnumUtils.ObterOperadoraDoArquivo(arquivoParc.NomeArquivo);
            var index = arquivoParc.Linhas.Count - 1;
            arquivoParc.AlterarLinha(index, "CD_TIPO_EMISSAO", ParametrosRegrasEmissao.CarregaTipoEmissaoParaSegundaLinhaDaEmissao(operadora));
            arquivoParc.AlterarLinha(index, "NR_ENDOSSO", arquivoParc[linhaDeReferencia]["NR_ENDOSSO"]);
            arquivoParc.AlterarLinha(index, "NR_PARCELA", arquivoParc[linhaDeReferencia]["NR_PARCELA"]);
            arquivoParc.AlterarLinha(index, "NR_SEQUENCIAL_EMISSAO", arquivoParc[linhaDeReferencia]["NR_SEQUENCIAL_EMISSAO"]);
        }


        public void AlterarLinhaParaPrimeiraEmissao(Arquivo arquivoParc, int linhaDeReferencia = 0)
        {
            var operadora = EnumUtils.ObterOperadoraDoArquivo(arquivoParc.NomeArquivo);
            arquivoParc.AlterarLinha(linhaDeReferencia, "CD_TIPO_EMISSAO", ParametrosRegrasEmissao.CarregaTipoEmissaoParaPrimeiraLinhaDaEmissao(operadora));
            arquivoParc.AlterarLinha(linhaDeReferencia, "NR_ENDOSSO", ParametrosRegrasEmissao.CarregaPrimeiroNumeroEndosso(arquivoParc[linhaDeReferencia], operadora));
            arquivoParc.AlterarLinha(linhaDeReferencia, "NR_PARCELA", ParametrosRegrasEmissao.CarregaPrimeiroNrParcela(operadora));
            arquivoParc.AlterarLinha(linhaDeReferencia, "NR_SEQUENCIAL_EMISSAO", ParametrosRegrasEmissao.CarregaPrimeiroNumeroSequencialEmissao(operadora));
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

            cobertura = cobertura == null ? dados.ObterCoberturaDiferenteDe(arquivoParc[arquivoParc.Linhas.Count - 1]["CD_COBERTURA"], arquivoParc.Header[0]["CD_TPA"], false) : cobertura;
             AlterarDadosDeCobertura(arquivoParc.Linhas.Count - 1, cobertura, arquivoParc);
        }

        protected void AdicionarTipoComissao(Arquivo arquivo, string valorPremioLiquido, string cdTipoComissao, int posicaoLinha)
        {
            var valor = valorPremioLiquido.ObterValorDecimal() / 2;
            arquivo.AlterarLinha(posicaoLinha, "VL_COMISSAO", valor.ValorFormatado());
            arquivo.ReplicarLinha(posicaoLinha, 1);
            arquivo.AlterarLinha(arquivo.Linhas.Count - 1, "CD_TIPO_COMISSAO", cdTipoComissao);
            arquivo.AlterarLinha(arquivo.Linhas.Count - 1, "VL_COMISSAO", valor.ValorFormatado());
            arquivo.AlterarLinha(arquivo.Linhas.Count - 1, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracaoECobertura
                (arquivo.Header[0]["CD_TPA"], cdTipoComissao, arquivo[arquivo.Linhas.Count - 1]["CD_COBERTURA"]));
        }
    }
}
