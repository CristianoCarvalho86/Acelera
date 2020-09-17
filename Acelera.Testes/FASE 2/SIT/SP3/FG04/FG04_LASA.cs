using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Acelera.Logger;
using Acelera.Testes.DataAccessRep;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG04
{
    [TestClass]
    public class FG04 : TestesFG04
    {
        private string nomeDoArquivoParaValidacao = $"C01.LASA.EMSCMS-IN-0001-{DateTime.Now.ToString("yyyyMMdd")}.TXT";

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4831()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "4831", "");

            CarregarTriplice(OperadoraEnum.LASA);

            var cobertura = dados.ObterCoberturaSimples(trinca.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado);

            trinca.AlterarParcEComissao(0, "CD_COBERTURA", cobertura.CdCobertura);
            trinca.AlterarParcEComissao(0, "CD_RAMO", cobertura.CdRamo);
            trinca.AlterarParcEComissao(0, "CD_PRODUTO", cobertura.CdProduto);

            trinca.AlterarParcEComissao(0, "VL_LMI", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "VL_IS"));
            trinca.AlterarParcEComissao(0, "CD_CONTRATO", AlterarUltimasPosicoes(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            trinca.AlterarParcEComissao(0, "NR_APOLICE", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarParcEComissao(0, "NR_PROPOSTA", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(7));

            trinca.Salvar();

            ValidarFlComissaoCalculada(trinca.ArquivoComissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado, "S");

            ExecutarEValidarTriplice(FGs.FG00, CodigoStage.AprovadoNAFG00, CodigoStage.AprovadoNAFG00, null);

            ValidarTabelaDeRetornoVazia(trinca.ArquivoComissao);

            ExecutarEValidarTriplice(FGs.FG01, CodigoStage.AprovadoNaFG01, CodigoStage.AprovadoNaFG01, null);

            ExecutarEValidarFG04Comissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, CodigoStage.AprovadoNAFG00);

            ValidarVlComissaoNaStage(
                trinca.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado,
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_SUCURSAL"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_COBERTURA"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_PRODUTO"), "1", "N", null);

            ValidarDadosDaStageComissao();

            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidarTriplice(FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia, CodigoStage.AprovadoNegocioSemDependencia, null);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4833()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "4833", "");

            CarregarTriplice(OperadoraEnum.LASA);

            //var cobertura = dados.ObterCoberturaSimples(triplice.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado);

            trinca.AlterarParcEComissao(0, "CD_COBERTURA", "01589");
            trinca.AlterarParcEComissao(0, "CD_RAMO","71");
            trinca.AlterarParcEComissao(0, "CD_PRODUTO", "71724");

            trinca.AlterarParcEComissao(0, "CD_CORRETOR", "7150145");
            trinca.AlterarParcEComissao(0, "CD_TIPO_COMISSAO", "P");
            trinca.AlterarParcEComissao(0, "CD_CONTRATO", AlterarUltimasPosicoes(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            trinca.AlterarParcEComissao(0, "NR_APOLICE", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarParcEComissao(0, "NR_PROPOSTA", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(7));

            trinca.Salvar();

            ValidarFlComissaoCalculada(trinca.ArquivoComissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado, "S");

            ExecutarEValidarTriplice(FGs.FG00, CodigoStage.AprovadoNAFG00, CodigoStage.AprovadoNAFG00, null);

            ValidarTabelaDeRetornoVazia(trinca.ArquivoComissao);

            ExecutarEValidarTriplice(FGs.FG01, CodigoStage.AprovadoNaFG01, CodigoStage.AprovadoNaFG01, null);

            ExecutarEValidarFG04Comissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, CodigoStage.AprovadoNAFG00);

            ValidarVlComissaoNaStage(
                trinca.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado,
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_SUCURSAL"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_COBERTURA"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_PRODUTO"), "2", "N", null);

            ValidarDadosDaStageComissao();

            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
               nomeDoArquivoParaValidacao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4834()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "4834", "");

            //não enviar comissao
            CarregarTriplice(OperadoraEnum.LASA);

            trinca.AlterarParcEComissao(0, "CD_CONTRATO", AlterarUltimasPosicoes(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            trinca.AlterarParcEComissao(0, "NR_APOLICE", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarParcEComissao(0, "NR_PROPOSTA", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(7));

            trinca.Salvar(true, true, false);

            ValidarFlComissaoCalculada(trinca.ArquivoComissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado, "S");

            ExecutarEValidarTriplice(FGs.FG00, CodigoStage.AprovadoNAFG00, CodigoStage.AprovadoNAFG00, null);

            ValidarTabelaDeRetornoVazia(trinca.ArquivoComissao);

            ExecutarEValidarTriplice(FGs.FG01, CodigoStage.AprovadoNaFG01, CodigoStage.AprovadoNaFG01, null);

            ExecutarEValidarFG04Comissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, CodigoStage.AprovadoNAFG00);

            ValidarVlComissaoNaStage(
                trinca.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado,
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_SUCURSAL"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_COBERTURA"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_PRODUTO"), "1", "N", null);

            ValidarDadosDaStageComissao();

            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4835()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "4835", "");


            CarregarTriplice(OperadoraEnum.LASA);

            trinca.AlterarParcEComissao(0, "CD_CONTRATO", AlterarUltimasPosicoes(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            trinca.AlterarParcEComissao(0, "NR_APOLICE", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarParcEComissao(0, "NR_PROPOSTA", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(7));

            trinca.Salvar();

            ValidarFlComissaoCalculada(trinca.ArquivoComissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado, "S");

            ExecutarEValidarTriplice(FGs.FG00, CodigoStage.AprovadoNAFG00, CodigoStage.AprovadoNAFG00, null);

            ValidarTabelaDeRetornoVazia(trinca.ArquivoComissao);

            ExecutarEValidarTriplice(FGs.FG01, CodigoStage.AprovadoNaFG01, CodigoStage.AprovadoNaFG01, null);

            ExecutarEValidarFG04Comissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, CodigoStage.AprovadoNAFG00);

            ValidarVlComissaoNaStage(
                trinca.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado,
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_SUCURSAL"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_COBERTURA"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_PRODUTO"), "1", "N", null);

            ValidarDadosDaStageComissao();

            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            CarregarTriplice(OperadoraEnum.LASA);

            trinca.AlterarParcEComissao(0, "CD_CONTRATO", AlterarUltimasPosicoes(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            trinca.AlterarParcEComissao(0, "NR_APOLICE", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarParcEComissao(0, "NR_PROPOSTA", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(7));

            trinca.Salvar();

            ValidarFlComissaoCalculada(trinca.ArquivoComissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado, "S");

            ExecutarEValidarTriplice(FGs.FG00, CodigoStage.AprovadoNAFG00, CodigoStage.AprovadoNAFG00, null);

            ValidarTabelaDeRetornoVazia(trinca.ArquivoComissao);

            ExecutarEValidarTriplice(FGs.FG01, CodigoStage.AprovadoNaFG01, CodigoStage.AprovadoNaFG01, null);

            ExecutarEValidarFG04Comissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, CodigoStage.AprovadoNAFG00);

            ValidarVlComissaoNaStage(
                trinca.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado,
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_SUCURSAL"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_COBERTURA"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_PRODUTO"), "1", "N", null);

            ValidarDadosDaStageComissao();

            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4836()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "4836", "");

            CarregarTriplice(OperadoraEnum.LASA);

            trinca.AlterarParcEComissao(0, "CD_CORRETOR", "");
            trinca.AlterarParcEComissao(0, "CD_TIPO_COMISSAO", "C");
            trinca.AlterarParcEComissao(0, "CD_CONTRATO", AlterarUltimasPosicoes(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            trinca.AlterarParcEComissao(0, "NR_APOLICE", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarParcEComissao(0, "NR_PROPOSTA", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(7));

            trinca.Salvar();

            ValidarFlComissaoCalculada(trinca.ArquivoComissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado, "S");

            ExecutarEValidarTriplice(FGs.FG00, CodigoStage.AprovadoNAFG00, CodigoStage.AprovadoNAFG00, null);

            ValidarTabelaDeRetornoVazia(trinca.ArquivoComissao);

            ExecutarEValidarTriplice(FGs.FG01, CodigoStage.AprovadoNaFG01, CodigoStage.AprovadoNaFG01, null);

            ExecutarEValidarFG04Comissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, CodigoStage.AprovadoNAFG00);

            ValidarVlComissaoNaStage(
                trinca.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado,
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_SUCURSAL"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_COBERTURA"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_PRODUTO"), "1", "N", null);

            ValidarDadosDaStageComissao();

            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4837()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "4837", "");

            CarregarTriplice(OperadoraEnum.LASA);

            trinca.AlterarParcEComissao(0, "CD_CORRETOR", "");
            trinca.AlterarParcEComissao(0, "CD_TIPO_COMISSAO", "P");
            trinca.AlterarParcEComissao(0, "CD_CONTRATO", AlterarUltimasPosicoes(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            trinca.AlterarParcEComissao(0, "NR_APOLICE", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarParcEComissao(0, "NR_PROPOSTA", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(7));

            trinca.Salvar();

            ValidarFlComissaoCalculada(trinca.ArquivoComissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado, "S");

            ExecutarEValidarTriplice(FGs.FG00, CodigoStage.AprovadoNAFG00, CodigoStage.AprovadoNAFG00, null);

            ValidarTabelaDeRetornoVazia(trinca.ArquivoComissao);

            ExecutarEValidarTriplice(FGs.FG01, CodigoStage.AprovadoNaFG01, CodigoStage.AprovadoNaFG01, null);

            ExecutarEValidarFG04Comissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, CodigoStage.AprovadoNAFG00);

            ValidarVlComissaoNaStage(
                trinca.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado,
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_SUCURSAL"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_COBERTURA"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_PRODUTO"), "1", "N", null);

            ValidarDadosDaStageComissao();

            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4838()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "4838", "");

            CarregarTriplice(OperadoraEnum.LASA);

            trinca.AlterarParcEComissao(0, "CD_COBERTURA", "01589");
            trinca.AlterarParcEComissao(0, "CD_RAMO", "71");
            trinca.AlterarParcEComissao(0, "CD_PRODUTO", "71724");

            trinca.AlterarParcEComissao(0, "CD_CORRETOR", "7150145");
            trinca.AlterarParcEComissao(0, "CD_TIPO_COMISSAO", "R");
            trinca.AlterarParcEComissao(0, "CD_CONTRATO", AlterarUltimasPosicoes(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            trinca.AlterarParcEComissao(0, "NR_APOLICE", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarParcEComissao(0, "NR_PROPOSTA", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(7));

            trinca.Salvar();

            ValidarFlComissaoCalculada(trinca.ArquivoComissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado, "S");

            ExecutarEValidarTriplice(FGs.FG00, CodigoStage.AprovadoNAFG00, CodigoStage.AprovadoNAFG00, null);

            ValidarTabelaDeRetornoVazia(trinca.ArquivoComissao);

            ExecutarEValidarTriplice(FGs.FG01, CodigoStage.AprovadoNaFG01, CodigoStage.AprovadoNaFG01, null);

            ExecutarEValidarFG04Comissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, CodigoStage.AprovadoNAFG00);

            ValidarVlComissaoNaStage(
                trinca.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado,
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_SUCURSAL"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_COBERTURA"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_PRODUTO"), "1", "N", null);

            ValidarDadosDaStageComissao();

            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4839()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "4839", "");

            CarregarTriplice(OperadoraEnum.POMPEIA);

            trinca.AlterarParcEComissao(0, "CD_CONTRATO", AlterarUltimasPosicoes(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            trinca.AlterarParcEComissao(0, "NR_APOLICE", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarParcEComissao(0, "NR_PROPOSTA", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(7));

            trinca.Salvar();

            ValidarFlComissaoCalculada(trinca.ArquivoComissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado, "N");

            //Validar que não tem
            ValidarVlComissaoNaStage(
                trinca.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado,
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_SUCURSAL"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_COBERTURA"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_PRODUTO"), "1", "N", null);

            ExecutarEValidarTriplice(FGs.FG00, CodigoStage.AprovadoNAFG00, CodigoStage.AprovadoNAFG00, null);

            ValidarTabelaDeRetornoVazia(trinca.ArquivoComissao);

            ExecutarEValidarTriplice(FGs.FG01, CodigoStage.AprovadoNaFG01, CodigoStage.AprovadoNaFG01, null);

            ExecutarEValidarFG04Comissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, CodigoStage.AprovadoNAFG00);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4840()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "4840", "");

            CarregarTriplice(OperadoraEnum.LASA);

            trinca.AlterarParcEComissao(0, "CD_CONTRATO", AlterarUltimasPosicoes(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            trinca.AlterarParcEComissao(0, "NR_APOLICE", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarParcEComissao(0, "NR_PROPOSTA", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(7));

            trinca.Salvar();

            ValidarFlComissaoCalculada(trinca.ArquivoComissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado, "S");

            ExecutarEValidarTriplice(FGs.FG00, CodigoStage.AprovadoNAFG00, CodigoStage.AprovadoNAFG00, null);

            ValidarTabelaDeRetornoVazia(trinca.ArquivoComissao);

            ExecutarEValidarTriplice(FGs.FG01, CodigoStage.AprovadoNaFG01, CodigoStage.AprovadoNaFG01, null);

            ExecutarEValidarFG04Comissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, CodigoStage.AprovadoNAFG00);

            ValidarVlComissaoNaStage(
                trinca.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado,
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_SUCURSAL"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_COBERTURA"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_PRODUTO"), "1", "N", null);

            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4846()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "4846", "");

            CarregarTriplice(OperadoraEnum.LASA);

            //var cobertura = dados.ObterCoberturaSimples(triplice.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado);

            trinca.AlterarParcEComissao(0, "CD_COBERTURA", "01589");
            trinca.AlterarParcEComissao(0, "CD_RAMO", "71");
            trinca.AlterarParcEComissao(0, "CD_PRODUTO", "71724");

            trinca.AlterarParcEComissao(0, "CD_CORRETOR", "7150145");
            trinca.AlterarParcEComissao(0, "CD_TIPO_COMISSAO", "P");
            trinca.AlterarParcEComissao(0, "CD_CONTRATO", AlterarUltimasPosicoes(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            trinca.AlterarParcEComissao(0, "NR_APOLICE", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarParcEComissao(0, "NR_PROPOSTA", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(7));

            trinca.Salvar();

            ValidarFlComissaoCalculada(trinca.ArquivoComissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado, "S");

            ExecutarEValidarTriplice(FGs.FG00, CodigoStage.AprovadoNAFG00, CodigoStage.AprovadoNAFG00, null);

            ValidarTabelaDeRetornoVazia(trinca.ArquivoComissao);

            ExecutarEValidarTriplice(FGs.FG01, CodigoStage.AprovadoNaFG01, CodigoStage.AprovadoNaFG01, null);

            ExecutarEValidarFG04Comissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, CodigoStage.AprovadoNAFG00);

            ValidarVlComissaoNaStage(
                trinca.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado,
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_SUCURSAL"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_COBERTURA"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_PRODUTO"), "3", "N", null);

            ValidarDadosDaStageComissao();

            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
               nomeDoArquivoParaValidacao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4847()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "4847", "");

            CarregarTriplice(OperadoraEnum.LASA);

            //var cobertura = dados.ObterCoberturaSimples(triplice.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado);

            trinca.AlterarParcEComissao(0, "CD_COBERTURA", "01589");
            trinca.AlterarParcEComissao(0, "CD_RAMO", "71");
            trinca.AlterarParcEComissao(0, "CD_PRODUTO", "71724");

            trinca.AlterarParcEComissao(0, "CD_CORRETOR", "7150145");
            trinca.AlterarParcEComissao(0, "CD_TIPO_COMISSAO", "P");
            trinca.AlterarParcEComissao(0, "CD_CONTRATO", AlterarUltimasPosicoes(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            trinca.AlterarParcEComissao(0, "NR_APOLICE", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarParcEComissao(0, "NR_PROPOSTA", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(7));

            trinca.Salvar();

            ValidarFlComissaoCalculada(trinca.ArquivoComissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado, "S");

            ExecutarEValidarTriplice(FGs.FG00, CodigoStage.AprovadoNAFG00, CodigoStage.AprovadoNAFG00, null);

            ValidarTabelaDeRetornoVazia(trinca.ArquivoComissao);

            ExecutarEValidarTriplice(FGs.FG01, CodigoStage.AprovadoNaFG01, CodigoStage.AprovadoNaFG01, null);

            ExecutarEValidarFG04Comissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, CodigoStage.AprovadoNAFG00);

            ValidarVlComissaoNaStage(
                trinca.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado,
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_SUCURSAL"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_COBERTURA"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_PRODUTO"), "4", "N", null);

            ValidarDadosDaStageComissao();

            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
               nomeDoArquivoParaValidacao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4848()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "4848", "");

            CarregarTriplice(OperadoraEnum.LASA);

            //var cobertura = dados.ObterCoberturaSimples(triplice.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado);

            trinca.AlterarParcEComissao(0, "CD_COBERTURA", "01589");
            trinca.AlterarParcEComissao(0, "CD_RAMO", "71");
            trinca.AlterarParcEComissao(0, "CD_PRODUTO", "71724");

            trinca.AlterarParcEComissao(0, "CD_CORRETOR", "7150145");
            trinca.AlterarParcEComissao(0, "CD_TIPO_COMISSAO", "P");
            trinca.AlterarParcEComissao(0, "CD_CONTRATO", AlterarUltimasPosicoes(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            trinca.AlterarParcEComissao(0, "NR_APOLICE", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarParcEComissao(0, "NR_PROPOSTA", trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            trinca.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(7));

            trinca.Salvar();

            ValidarFlComissaoCalculada(trinca.ArquivoComissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado, "S");

            ExecutarEValidarTriplice(FGs.FG00, CodigoStage.AprovadoNAFG00, CodigoStage.AprovadoNAFG00, null);

            ValidarTabelaDeRetornoVazia(trinca.ArquivoComissao);

            ExecutarEValidarTriplice(FGs.FG01, CodigoStage.AprovadoNaFG01, CodigoStage.AprovadoNaFG01, null);

            ExecutarEValidarFG04Comissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, CodigoStage.AprovadoNAFG00);

            ValidarVlComissaoNaStage(
                trinca.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado,
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_SUCURSAL"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_COBERTURA"),
                trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_PRODUTO"), "4", "S", null);

            ValidarDadosDaStageComissao();

            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
               nomeDoArquivoParaValidacao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarStageComissao(trinca.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
        }
    }
}
