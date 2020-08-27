using Acelera.Domain.Entidades.SGS;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Utils;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.DataAccessRep.ODS;
using Acelera.Testes.FASE_2;
using Acelera.Testes.Repositorio;
using Acelera.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public class TestesFG03 : TestesFG02
    {
        protected SGSData SGS_dados;

        protected IList<Massa_Cliente_Sinistro> clienteSGS;
        protected IList<Massa_Sinistro_Parcela> parcelaSGS;
        protected ClienteSGS cliente;
        protected PaisSGS pais;
        protected IList<EnderecoSGS> enderecos;
        protected EmissaoSGS emissao;

        protected override string NomeFG => "FG03";
        public TestesFG03()
        {

        }

        protected override void IniciarTeste(TipoArquivo tipo, string numeroDoTeste, string nomeDoTeste)
        {
            base.IniciarTeste(tipo, numeroDoTeste, nomeDoTeste);
            SGS_dados = new SGSData(logger);
        }

        //public void CarregarSinistroDoContrato(string cdContrato)
        //{
        //    SGS_dados.CarregarSinistroDoContrato(arquivo, cdContrato);
        //}

        public void ObterLinhaComCdContratoDisponivel()
        {
            logger.AbrirBloco("PROCURANDO CONTRATOS DISPONIVEIS NO ARQUIVO.");
            var contratosUtilizados = ControleCDContratoFG03.Instancia.ObterContratosUtilizados();
            var linha = arquivo.Linhas.Where(x => !contratosUtilizados.Contains(x.ObterCampoDoArquivo("CD_CONTRATO").ValorFormatado)).FirstOrDefault();
            if (linha == null)
            {
                logger.Erro("NAO FORAM ENCONTRADOS CONTRATOS DISPONIVEIS NO ARQUIVO");
            }
            logger.Escrever($"CONTRATO ENCONTRADO : '{linha.ObterCampoDoArquivo("CD_CONTRATO").ValorFormatado}' , Linha: {linha.Index} ");
            arquivo.RemoverExcetoEstas(linha.Index, 1);
            ControleCDContratoFG03.Instancia.AtualizaArquivo(linha.ObterCampoDoArquivo("CD_CONTRATO").ValorFormatado);
            logger.Escrever($"OUTRAS LINHAS DO ARQUIVO REMOVIDOS.");
            arquivo.ReIndexar();
            arquivo.AjustarQtdLinhasNoFooter();
            logger.FecharBloco();
        }

        public void ObterLinhaComCdContratoDisponivelEDeterminadoTipoMovimento(string tipoMovimento)
        {
            logger.AbrirBloco($"PROCURANDO CONTRATOS DISPONIVEIS NO ARQUIVO E DO TIPO MOVIMENTO = {tipoMovimento}");
            var contratosUtilizados = ControleCDContratoFG03.Instancia.ObterContratosUtilizados();
            var linha = arquivo.Linhas.Where(x => !contratosUtilizados.Contains(x.ObterCampoDoArquivo("CD_CONTRATO").ValorFormatado) && x.ObterCampoDoArquivo("CD_TIPO_MOVIMENTO").ValorFormatado == tipoMovimento).FirstOrDefault();
            if (linha == null)
            {
                logger.Erro("NAO FORAM ENCONTRADOS CONTRATOS DISPONIVEIS NO ARQUIVO");
            }
            logger.Escrever($"CONTRATO ENCONTRADO : '{linha.ObterCampoDoArquivo("CD_CONTRATO").ValorFormatado}' , Linha: {linha.Index} ");
            arquivo.RemoverExcetoEstas(linha.Index, 1);
            ControleCDContratoFG03.Instancia.AtualizaArquivo(linha.ObterCampoDoArquivo("CD_CONTRATO").ValorFormatado);
            logger.Escrever($"OUTRAS LINHAS DO ARQUIVO REMOVIDOS.");
            arquivo.ReIndexar();
            arquivo.AjustarQtdLinhasNoFooter();
            logger.FecharBloco();
        }

        public void ObterLinhaPorCdContratoEDeterminadoTipoMovimento(string cdContrato, string tipoMovimento)
        {
            logger.AbrirBloco($"PROCURANDO CONTRATOS DISPONIVEIS NO ARQUIVO PARA O CONTRATO = {cdContrato} E DO TIPO MOVIMENTO = {tipoMovimento}");
            //var contratosUtilizados = ControleCDContratoFG03.Instancia.ObterContratosUtilizados();
            var linha = arquivo.Linhas.Where(x => x.ObterCampoDoArquivo("CD_CONTRATO").ValorFormatado == cdContrato && x.ObterCampoDoArquivo("CD_TIPO_MOVIMENTO").ValorFormatado == tipoMovimento).FirstOrDefault();
            if (linha == null)
            {
                logger.Erro("NAO FORAM ENCONTRADOS CONTRATOS DISPONIVEIS NO ARQUIVO");
            }
            logger.Escrever($"CONTRATO ENCONTRADO : '{linha.ObterCampoDoArquivo("CD_CONTRATO").ValorFormatado}' , Linha: {linha.Index} ");
            arquivo.RemoverExcetoEstas(linha.Index, 1);
            ControleCDContratoFG03.Instancia.AtualizaArquivo(linha.ObterCampoDoArquivo("CD_CONTRATO").ValorFormatado);
            logger.Escrever($"OUTRAS LINHAS DO ARQUIVO REMOVIDOS.");
            arquivo.ReIndexar();
            arquivo.AjustarQtdLinhasNoFooter();
            logger.FecharBloco();
        }

        public void ValidarCdTpaNaParametroGlobal(string cdTpa, bool deveEncontrar = true)
        {
            if (!SGS_dados.ValidarCdTpaNaParametroGlobal(cdTpa, deveEncontrar))
            {
                ExplodeFalha();
            }

        }

        public void ValidarRegistroNaoExisteNaODSParcela(string cdTpa, string cdContrato, string nrSeqEmissao, bool deveEncontrar = false)
        {
            var cdPnOperacao = dados.ObterCdParceiroNegocioParaTPA(cdTpa);
            var registroNaoEncontrado = SGS_dados.ValidarRegistroNaoExisteNaODSParcela(cdPnOperacao, cdContrato, nrSeqEmissao);
            if (registroNaoEncontrado && deveEncontrar)
                ExplodeFalha();
            else if (!registroNaoEncontrado && !deveEncontrar)
                ExplodeFalha();

        }

        public void ValidarRegistroNaoExisteNaODSSinistro(string cdTpa, string cdContrato, string nrSeqEmissao, bool deveEncontrar = false)
        {
            var cdPnOperacao = dados.ObterCdParceiroNegocioParaTPA(cdTpa);
            var registroNaoEncontrado = SGS_dados.ValidarRegistroNaoExisteNaODSSinistro(cdPnOperacao, cdContrato, nrSeqEmissao);
            if (registroNaoEncontrado && deveEncontrar)
                ExplodeFalha();
            else if (!registroNaoEncontrado && !deveEncontrar)
                ExplodeFalha();

        }

        public void ValidaTabelasTemporariasSGSVazia(string cdContrato, string cdCliente)
        {
            SGS_dados.CarregaEntidadesDasTabelasTemporariasSGS(cdContrato, cdCliente, out clienteSGS, out parcelaSGS);
            if ((clienteSGS != null && clienteSGS.Count() > 0) || (parcelaSGS != null && parcelaSGS.Count() > 0))
            {
                logger.Erro($"FORAM ENCONTRADOS REGISTROS NAS TABELAS TEMPORARIAS, CLIENTES : {clienteSGS.Count}, PARCELAS : {parcelaSGS.Count}");
                ExplodeFalha();
            }
        }

        public void ValidaTabelasTemporariasSGS(string cdContrato, string cdCliente)
        {
            SGS_dados.CarregaEntidadesDasTabelasTemporariasSGS(cdContrato, cdCliente, out clienteSGS, out parcelaSGS);
            if (clienteSGS.Count() == 0 || parcelaSGS.Count() == 0)
            {
                logger.Erro($"NAO FORAM ENCONTRADOS REGISTROS NAS 2 TABELAS TEMPORARIAS, CLIENTES : {clienteSGS.Count}, PARCELAS : {parcelaSGS.Count}");
                ExplodeFalha();
            }
        }

        public void ValidaTabelasTemporariasSGS(string cdContrato, string cdCliente, bool? deveHaverMultiplosClientes, bool? deveHaverMultiplasParcelas)
        {
            SGS_dados.CarregaEntidadesDasTabelasTemporariasSGS(cdContrato, cdCliente, out clienteSGS, out parcelaSGS);

            if (deveHaverMultiplosClientes.HasValue && (deveHaverMultiplosClientes.Value && clienteSGS.Count() <= 1) ||
                (deveHaverMultiplasParcelas.Value && parcelaSGS.Count() <= 1))
            {
                logger.Escrever($"FORAM ENCONTRADOS REGISTROS NAS TABELAS TEMPORARIAS, CLIENTES : {clienteSGS.Count}, PARCELAS : {parcelaSGS.Count}");
                logger.Escrever($"ERAM ESPERADOS MULTIPLOS REGISTROS NA TEMPORARIA DE CLIENTES : {deveHaverMultiplosClientes}");
                logger.Escrever($"ERAM ESPERADOS MULTIPLOS REGISTROS NA TEMPORARIA DE PARCELAS : {deveHaverMultiplasParcelas}");
                ExplodeFalha();
            }

            if (deveHaverMultiplosClientes.HasValue && deveHaverMultiplosClientes.Value && clienteSGS.Count() == 1)
            {
                logger.Erro($"ERA ESPERADO APENAS 1 CLIENTE NA TABELA TEMPORARIA, FORAM ENCONTRADOS : {clienteSGS.Count()}.");
                ExplodeFalha();
            }
            if (deveHaverMultiplasParcelas.HasValue && deveHaverMultiplasParcelas.Value && parcelaSGS.Count() == 1)
            {
                logger.Erro($"ERA ESPERADO APENAS 1 PARCELA NA TABELA TEMPORARIA, FORAM ENCONTRADOS : {parcelaSGS.Count()}.");
                ExplodeFalha();
            }
        }


        public void CarregarClienteSGS(string cdCliente)
        {
            SGS_dados.CarregarClienteSGS(cdCliente);
        }

        public QueryContratoParaArquivo CarregarDadosDoContrato(LinhaArquivo linha)
        {
            var contrato = SGS_dados.ObterContratoPeloCodigo(linha.ObterCampoDoArquivo("CD_CONTRATO").ValorFormatado);
            contrato.CarregaLinhaArquivo(linha);
            return contrato;
        }
        public QueryContratoParaArquivo CarregarDadosDoContrato(LinhaArquivo linha, string cdContrato)
        {
            var contrato = SGS_dados.ObterContratoPeloCodigo(cdContrato);
            if(linha != null)
                contrato.CarregaLinhaArquivo(linha);
            return contrato;
        }

        public void CarregarContratoPeloCodigo(string codigo, LinhaArquivo linha)
        {
            var dadosContrato = SGS_dados.ObterContratoPeloCodigo(codigo);
            dadosContrato.CarregaLinhaArquivo(linha);
        }

        public void CarregarContratoComUmaParcela(LinhaArquivo linha)
        {
            var dadosContrato = SGS_dados.ObterCodigoContratoComUmaParcela();
            dadosContrato.CarregaLinhaArquivo(linha);
        }

        public QueryContratoParaArquivo CarregarContratoValido(LinhaArquivo linha)
        {
            var dadosContrato = SGS_dados.ObterContratoValido();
            dadosContrato.CarregaLinhaArquivo(linha);
            return dadosContrato;
        }

        public void CarregarContratoComMultiplasParcelas(LinhaArquivo linha)
        {
            var dadosContrato = SGS_dados.ObterCodigoContratoComMultiplasParcelas();
            dadosContrato.CarregaLinhaArquivo(linha);
        }
        public void CarregarContratoComClienteUnico(LinhaArquivo linha1, LinhaArquivo linha2)
        {
            var dadosContrato = SGS_dados.ObterContratosDoCliente(SGS_dados.ObterClienteComUnicoContrato()).First();
            dadosContrato.CarregaLinhaArquivo(linha1);
            dadosContrato = SGS_dados.ObterContratosDoCliente(SGS_dados.ObterClienteComUnicoContrato()).Where(x => x.CD_CONTRATO != dadosContrato.CD_CONTRATO).First();
            dadosContrato.CarregaLinhaArquivo(linha2);
        }

        public void CarregarContratoComClienteDeVariosContratos(LinhaArquivo linha1, LinhaArquivo linha2)
        {
            var dadosContrato = SGS_dados.ObterContratosDoCliente(SGS_dados.ObterClienteComMultiplosContratos()).First();
            dadosContrato.CarregaLinhaArquivo(linha1);
            dadosContrato = SGS_dados.ObterContratosDoCliente(SGS_dados.ObterClienteComMultiplosContratos()).Where(x => x.CD_CONTRATO != dadosContrato.CD_CONTRATO).First();
            dadosContrato.CarregaLinhaArquivo(linha2);
        }

        public void CarregarContratoCancelado(LinhaArquivo linha)
        {
            var dadosContrato = SGS_dados.ObterContratoPeloCodigo(SGS_dados.ObterContratoCancelado().CD_CONTRATO);
            dadosContrato.CarregaLinhaArquivo(linha);
        }

        public void ValidarCdContratoNaoExiste(string cdContrato)
        {
            if (SGS_dados.ValidaExistenciaCDContrato(cdContrato))
                throw new Exception("CD CONTRATO NAO ERA PARA SER ENCONTRADO NO SGS MAS FOI.");
        }


        public void ValidarStageCliente(CodigoStage codigoEsperado, bool deveEncontrar = true)
        {
            if (!deveEncontrar && (clienteSGS == null || clienteSGS.Count == 0))
            {
                logger.Escrever("NENHUM REGISTRO ENCONTRADO PARA CLIENTE NO SGS.");
                return;
            }
            else if (deveEncontrar && (clienteSGS != null || clienteSGS.Count >= 0))
                foreach (var cliente in clienteSGS)
                {
                    var retorno = SGS_dados.ValidarStageCliente(cliente);
                    if (string.IsNullOrEmpty(retorno))
                        ExplodeFalha();
                    if (!(int.Parse(retorno) == (int)codigoEsperado))
                        ExplodeFalha();
                }
        }

        public void ValidarStageClienteMultiplo(CodigoStage codigoEsperado)
        {
                foreach (var cliente in clienteSGS)
                {
                    var retorno = SGS_dados.ValidarStageClienteMultiplo(cliente);
                    if (retorno == null)
                        ExplodeFalha();
                    foreach(var r in retorno)
                        if (!(int.Parse(r) == (int)codigoEsperado))
                            ExplodeFalha();
                }
        }
        public void ValidarStageParcAutoMultiplo(CodigoStage codigoEsperado)
        {
                foreach (var parcela in parcelaSGS)
                {
                    var retorno = SGS_dados.ValidarStageParcelaAutoMultiplo(parcela);
                    if (retorno == null)
                        ExplodeFalha();
                    foreach(var r in retorno)
                        if (!(int.Parse(r) == (int)codigoEsperado))
                            ExplodeFalha();
                }
        }

        public void ValidarStageParcela(CodigoStage codigoEsperado, bool deveEncontrar = true)
        {
            if (deveEncontrar && (parcelaSGS == null || parcelaSGS.Count == 0))
            {
                logger.Escrever("NENHUM REGISTRO ENCONTRADO PARA PARCELA NO SGS.");
                return;
            }
            else if (deveEncontrar && (parcelaSGS != null || parcelaSGS.Count >= 0))
                foreach (var parcela in parcelaSGS)
                {
                    var retorno = SGS_dados.ValidarStageParcela(parcela);
                    if (string.IsNullOrEmpty(retorno))
                        ExplodeFalha();
                    if (!(int.Parse(retorno) == (int)codigoEsperado))
                        ExplodeFalha();
                }
        }

        public void ValidarStageParcelaAuto(CodigoStage codigoEsperado, bool deveEncontrar = true)
        {
            if (deveEncontrar && (parcelaSGS == null || parcelaSGS.Count == 0))
            {
                logger.Escrever("NENHUM REGISTRO ENCONTRADO PARA PARCELA NO SGS.");
                return;
            }
            else if (deveEncontrar && (parcelaSGS != null || parcelaSGS.Count >= 0))
                foreach (var parcela in parcelaSGS)
                {
                    var retorno = SGS_dados.ValidarStageParcelaAuto(parcela);
                    if (string.IsNullOrEmpty(retorno))
                        ExplodeFalha();
                    if (!(int.Parse(retorno) == (int)codigoEsperado))
                        ExplodeFalha();
                }
        }

        public void Executar()
        {
            SGS_dados.Executar();
        }

        protected override IList<string> ObterProceduresASeremExecutadas(Arquivo _arquivo)
        {
            return RepositorioProcedures.ObterProcedures(FGs.FG02, _arquivo.tipoArquivo);
        }

        public void ValidarFGsAnteriores(bool ValidaFG00, bool ValidaFG01, bool ValidaFG01_1, bool ValidaFG02, CodigoStage? codigoAguardadoNa01_1, Arquivo _arquivo = null)
        {
            SetarArquivoEmUso(ref _arquivo);

            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            if (ValidaFG00)
            {
                logger.EscreverBloco("Inicio da Validação da FG00.");
                //PROCESSAR O ARQUIVO CRIADO
                base.ChamarExecucao(arquivo.tipoArquivo.ObterTarefaFG00Enum().ObterTexto());
                base.ValidarControleArquivo(_arquivo);
                base.ValidarLogProcessamento(_arquivo,true, 1, RepositorioProcedures.ObterProcedures(FGs.FG00, _arquivo.tipoArquivo));
                base.ValidarStages(CodigoStage.AprovadoNAFG00,false, _arquivo);
                ValidarTabelaDeRetornoFG00(false,false, _arquivo);
                logger.EscreverBloco("Fim da Validação da FG00. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
                ValidarTeste();
            }
            if (ValidaFG01)
            {
                logger.EscreverBloco("Inicio da Validação da FG01.");
                //PROCESSAR O ARQUIVO CRIADO
                base.ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaFG01Enum().ObterTexto());
                base.ValidarLogProcessamento(_arquivo,true, 1, RepositorioProcedures.ObterProcedures(FGs.FG01, _arquivo.tipoArquivo));
                base.ValidarStages(CodigoStage.AprovadoNaFG01);
                ValidarTabelaDeRetornoFG01(_arquivo);
                logger.EscreverBloco("Fim da Validação da FG01. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
                ValidarTeste();


            }
            if (ValidaFG01_1)
            {
                base.ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaFG01_1_Enum().ObterTexto());
                base.ValidarStages(codigoAguardadoNa01_1.Value,false, _arquivo);
                ValidarTeste();
            }
            if (ValidaFG02)
            {
                logger.EscreverBloco("Inicio da FG02.");
                ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaFG02Enum().ObterTexto());
                ValidarLogProcessamento(_arquivo,true, 1, RepositorioProcedures.ObterProcedures(FGs.FG02, _arquivo.tipoArquivo));
                ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
                ValidarTabelaDeRetornoSemGerarErro();
                logger.EscreverBloco("Fim da Validação da FG02. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
                ValidarTeste();
            }
        }

        public void EnviarParaODS(string nomeArquivoSinistro)
        {
            foreach (var cliente in clienteSGS)
            {
                ODSInsertClienteData.Insert(cliente, logger);
            }

            foreach (var parcela in parcelaSGS)
            {
                ODSInsertParcAuto.Insert(parcela, logger);
            }
            ODSInsertSinistroData.Insert(nomeArquivoSinistro, logger);
        }


    }
}
