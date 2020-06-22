using Acelera.Data;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Utils;
using Acelera.Testes.ConjuntoArquivos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    [TestClass]
    public class TestesFG06 : TestesFG04
    {
        protected override string NomeFG => "FG06";
        [TestMethod]
        public void Teste1_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste1-FG06", "Teste1-FG06");
            triplice = new TripliceVIVO(1, logger);
            PrepararMassa(OperadoraEnum.VIVO);
            triplice.Salvar();
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG05, CodigoStage.ReprovadoNegocioComDependencia);
        }

        [TestMethod]
        public void Teste2_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste2-FG06", "Teste2-FG06");
            triplice = new TripliceLASA(1, logger);
            PrepararMassa(OperadoraEnum.LASA);
            triplice.Salvar();
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidarEsperandoErro(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG05, CodigoStage.ReprovadoNegocioComDependencia);
        }

        [TestMethod]
        public void Teste3_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste1-FG06", "Teste1-FG06");
            triplice = new TriplicePOMPEIA(1, logger);
            PrepararMassa(OperadoraEnum.POMPEIA);

            //triplice.ArquivoParcEmissao.AlterarLinha(0,"CD_UF_RISCO", "PP"); //Rejeitar na 01
            triplice.ArquivoParcEmissao.ReplicarLinhaComAjusteFooter(0, 1);
            triplice.ArquivoComissao.AlterarLinha(0, "CD_RAMO", "00");//Rejeitar na 02
            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01,true);
        }

        [TestMethod]
        public void Teste4_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste4-FG06", "Teste4-FG06");
            triplice = new TripliceLASA(1, logger);
            PrepararMassa(OperadoraEnum.LASA);
            triplice.ArquivoCliente.RemoverHeader();
            triplice.Salvar();

            ExecutarEValidarEsperandoErro(triplice.ArquivoCliente, FGs.FG00, null);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG05, CodigoStage.ReprovadoNegocioComDependencia);
        }

        [TestMethod]
        public void Teste5_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste5-FG06", "Teste1-FG06");
            triplice = new TripliceSoftbox(1, logger);
            PrepararMassa(OperadoraEnum.SOFTBOX);
            triplice.ArquivoCliente.AlterarLinha(0, "SEXO", "1");//Rejeitar na 02
            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoCliente, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        public void Teste6_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste1-FG06", "Teste1-FG06");

            var arquivoEmissao = EnviarEmissao<Arquivo_Layout_9_3_ParcEmissao, Arquivo_Layout_9_3_EmsComissao>(OperadoraEnum.VIVO);

            triplice = new TripliceVIVO(1, logger);
            PrepararMassa(OperadoraEnum.VIVO);
            CarregarDadosCancelamento(triplice.ArquivoParcEmissao, arquivoEmissao.ObterLinha(0));
            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, triplice.ArquivoComissao);
            
            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        public void Teste7_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste1-FG06", "Teste1-FG06");
            triplice = new TripliceLASA(1, logger);
            PrepararMassa(OperadoraEnum.LASA);
            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        public void Teste8_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste1-FG06", "Teste1-FG06");
            triplice = new TriplicePOMPEIA(1, logger);
            PrepararMassa(OperadoraEnum.POMPEIA);
            triplice.ArquivoParcEmissao.AlterarLinha(0, "CD_RAMO", "00");//Rejeitar na 02
            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);

        }


        public void CarregarDadosCancelamento(Arquivo arquivoDeCancelamento, LinhaArquivo linhaArquivoEmissao)
        {
            var idTransacaoDoArquivoOriginal = arquivoDeCancelamento.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");
            arquivoDeCancelamento.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivoDeCancelamento.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, 1);
            arquivoDeCancelamento.RemoverTodasLinhasDoBody();

            arquivoDeCancelamento.AdicionaLinhaNoBody(linhaArquivoEmissao.Clone());
            arquivoDeCancelamento.AlterarLinha(0, "ID_TRANSACAO_CANC", linhaArquivoEmissao.ObterCampoDoArquivo("ID_TRANSACAO").ValorFormatado);
            arquivoDeCancelamento.AlterarLinha(0, "ID_TRANSACAO", idTransacaoDoArquivoOriginal);
            arquivoDeCancelamento.AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            arquivoDeCancelamento.AlterarLinha(0, "NR_ENDOSSO", "1");
            arquivoDeCancelamento.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            arquivoDeCancelamento.AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");
            arquivoDeCancelamento.AlterarLinha(0, "NR_PARCELA", (linhaArquivoEmissao.ObterCampoDoArquivo("NR_PARCELA").ValorInteiro + 1).ToString());
        }

        public Arquivo EnviarEmissao<T, C>(OperadoraEnum operadora) where T : Arquivo, new() where C : Arquivo, new()
        {
            arquivo = new T();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, 1);
            arquivo.AlterarLinhaSeExistirCampo(0, "ID_TRANSACAO_CANC", "");
            arquivo.AlterarLinhaSeExistirCampo(0, "CD_TIPO_EMISSAO", "1");
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_ENDOSSO", "0");
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO", "1");
            SalvarArquivo();

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            var arquivoParc = arquivo.Clone();

            arquivo = new C();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, 1);
            IgualarCamposQueExistirem(arquivoParc, arquivo);
            arquivo.AlterarLinhaSeExistirCampo(0, "ID_TRANSACAO_CANC", "");
            arquivo.AlterarLinhaSeExistirCampo(0, "CD_TIPO_EMISSAO", "1");
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_ENDOSSO", "0");
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO", "1");
            SalvarArquivo();

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            return arquivoParc.Clone();
        }


        public void PrepararMassa(OperadoraEnum operadora)
        {
            triplice.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(8));

            Parametros.instanciaDB = "HDIDEV_1";
            DBHelperHana.Instance.SetConnection("Server=zeus.hana.prod.sa-east-1.whitney.dbaas.ondemand.com:20272;UID=CCARVALHO;PWD=Generali@10;encrypt=TRUE;");

            var cobertura = dados.ObterCoberturaSimples(triplice.ArquivoCliente.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado);
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_COBERTURA", cobertura.CdCobertura);
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_RAMO", cobertura.CdRamo);
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_PRODUTO", cobertura.CdProduto);
            triplice.ArquivoParcEmissao.AlterarTodasAsLinhas("VL_LMI", triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0,"VL_IS"));

            //triplice.ArquivoParcEmissao.AlterarTodasAsLinhas("VL_PREMIO_TOTAL", (cobertura.ValorPremioLiquidoMaiorDecimal - 0.01M).ValorFormatado());
            triplice.ArquivoParcEmissao.AlterarTodasAsLinhas("VL_IOF", "0");
            //triplice.ArquivoParcEmissao.AlterarTodasAsLinhas("VL_PREMIO_LIQUIDO", (cobertura.ValorPremioLiquidoMaiorDecimal - 0.01M).ValorFormatado());

            DBHelperHana.Instance.SetConnection("Server=zeus.hana.prod.sa-east-1.whitney.dbaas.ondemand.com:20274;UID=CCARVALHO;PWD=Cristiano@03;encrypt=TRUE;Connection Timeout=5000");
            Parametros.instanciaDB = "HDIQAS_1";

            if (operadora == OperadoraEnum.VIVO)
            {
                triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_CORRETOR", "7239711");
                triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_TIPO_COMISSAO", "C");
            }
            else if (operadora == OperadoraEnum.LASA || operadora == OperadoraEnum.SOFTBOX)
            {
                triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_CORRETOR", "7150145");
                triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_TIPO_COMISSAO", "P");
            }
            else if (operadora == OperadoraEnum.POMPEIA)
            {
                triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_CORRETOR", "7150166");
                triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_TIPO_COMISSAO", "P");
            }
            else
                throw new Exception("OPERACAO SEM CORRETOR CADASTRADO.");

            var novoContrato = AlterarUltimasPosicoes(triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(8));
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_CONTRATO", novoContrato);
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("NR_PROPOSTA", novoContrato);
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("NR_APOLICE", novoContrato);

        }
    }
}
