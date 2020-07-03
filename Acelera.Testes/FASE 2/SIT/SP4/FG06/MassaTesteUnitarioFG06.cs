using Acelera.Data;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Utils;
using Acelera.Testes.ConjuntoArquivos;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG06
{
    [TestClass]
    public class MassaTesteUnitarioFG06 : TestesFG06
    {

        [TestMethod]
        public void Teste1_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste1-FG06", "Teste1-FG06");
            triplice = new TripliceVIVO(1, logger,ref valoresAlteradosBody);
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
            triplice = new TripliceLASA(1, logger, ref valoresAlteradosBody);
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
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste3-FG06", "Teste1-FG06");
            triplice = new TriplicePOMPEIA(1, logger, ref valoresAlteradosBody);
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
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01, true);
        }

        [TestMethod]
        public void Teste4_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste4-FG06", "Teste4-FG06");
            triplice = new TripliceLASA(1, logger, ref valoresAlteradosBody);
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
            triplice = new TripliceSoftbox(1, logger, ref valoresAlteradosBody);
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
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "Teste6-FG06", "Teste6-FG06");

            var arquivoEmissao = EnviarEmissao<Arquivo_Layout_9_3_ParcEmissaoAuto, Arquivo_Layout_9_3_EmsComissao>(OperadoraEnum.VIVO);

            CarregarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto, Arquivo_Layout_9_3_EmsComissao>(arquivoEmissao.ObterLinha(0),false,false, OperadoraEnum.VIVO, "10",false );
        }

        [TestMethod]
        public void Teste7_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "Teste7-FG06", "Teste7-FG06");

            var arquivoEmissao = EnviarEmissao<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA);

            CarregarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivoEmissao.ObterLinha(0), false, false, OperadoraEnum.LASA, "10", false);
        }

        [TestMethod]
        public void Teste8_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "Teste8-FG06", "Teste8-FG06");

            var arquivoEmissao = EnviarEmissao<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA);

            CarregarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivoEmissao.ObterLinha(0), true, false,  OperadoraEnum.POMPEIA, "10", false);

        }

        [TestMethod]
        public void Teste9_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "Teste9-FG06", "Teste9-FG06");

            var arquivoEmissao = EnviarEmissao<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA);

            CarregarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivoEmissao.ObterLinha(0), true, true, OperadoraEnum.LASA, "10", false);

        }

        [TestMethod]
        public void Teste10_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "Teste10-FG06", "Teste10-FG06");

            var arquivoEmissao = EnviarEmissao<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.SOFTBOX);

            CarregarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivoEmissao.ObterLinha(0), true, true, OperadoraEnum.SOFTBOX, "10", false);

        }



        public void CarregarCancelamento<T,C>(LinhaArquivo linhaArquivoEmissao, bool erroEmParc, bool erroEmComissao, OperadoraEnum operadora, string cdTipoEmissao,
        bool alterarLayout = false, string nrSequencialEmissao = "", string valorComissao = "", string cdMovtoCobranca = "") where T : Arquivo, new() where C : Arquivo, new()
        {
            logger.Escrever($"CRIANDO ARQUIDO DE PARC_EMISSAO PARA CANCELAMENTO - {operadora.ObterTexto()}");
            arquivo = new T();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, 1);
            var idTransacaoDoArquivoOriginal = arquivo.ObterLinha(0).ObterCampoSeExistir("ID_TRANSACAO").ValorFormatado;
            RemoverTodasAsLinhas();
            AdicionarLinha(0, linhaArquivoEmissao.Clone());


            AlterarLinhaSeExistirCampo(arquivo, 0, "ID_TRANSACAO_CANC", linhaArquivoEmissao.ObterCampoDoArquivo("ID_TRANSACAO").ValorFormatado);
            AlterarLinhaSeExistirCampo(arquivo, 0, "ID_TRANSACAO", idTransacaoDoArquivoOriginal);
            AlterarLinhaSeExistirCampo(arquivo, 0, "CD_TIPO_EMISSAO", cdTipoEmissao);
            AlterarLinhaSeExistirCampo(arquivo, 0, "NR_PARCELA", SomarValor(0, "NR_PARCELA", 1M));
            AlterarLinhaSeExistirCampo(arquivo, 0, "NR_ENDOSSO", "4");
            AlterarLinhaSeExistirCampo(arquivo, 0, "NR_SEQUENCIAL_EMISSAO", "2");
            if (!string.IsNullOrEmpty(nrSequencialEmissao))
                AlterarLinhaSeExistirCampo(arquivo, 0, "NR_SEQUENCIAL_EMISSAO", nrSequencialEmissao);

            AlterarLinhaSeExistirCampo(arquivo, 0, "CD_MOVTO_COBRANCA", "02");
            if (!string.IsNullOrEmpty(cdMovtoCobranca))
                AlterarLinhaSeExistirCampo(arquivo, 0, "CD_MOVTO_COBRANCA", cdMovtoCobranca);

            if (alterarLayout)
                arquivo.AlterarHeader("VERSAO", "9.6");

            if(erroEmParc)
            {
                AlterarLinha(0, "CD_RAMO", "00");//Rejeitar na 02
            }

            SalvarArquivo();

            logger.Escrever("ARQUIVO CRIADO COM O NOME : " + arquivo.NomeArquivo);

            //ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            //ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            //if(erroEmParc)
            //    ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);
            //else
            //    ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            var arquivoParc = arquivo.Clone();

            logger.Escrever($"CRIANDO ARQUIDO DE COMISSAO PARA CANCELAMENTO - {operadora.ObterTexto()}");

            arquivo = new C();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, 1);
            IgualarCamposQueExistirem(arquivoParc, arquivo);
            AlterarLinhaSeExistirCampo(arquivo, 0, "CD_TIPO_COMISSAO", operadora == OperadoraEnum.VIVO ? "C" : "P");
            if (!string.IsNullOrEmpty(valorComissao))
                AlterarLinhaSeExistirCampo(arquivo, 0, "VL_COMISSAO", valorComissao);

            if (erroEmComissao)
            {
                AlterarLinha(0, "CD_RAMO", "00");//Rejeitar na 02
            }

            SalvarArquivo();

            logger.Escrever("ARQUIVO CRIADO COM O NOME : " + arquivo.NomeArquivo);

            //ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            //ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            //if(erroEmComissao)
            //    ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);
            //else
            //    ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
        }


        [TestMethod]
        public void Teste12_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste12-FG06", "Teste12-FG06");
            triplice = new TripliceTIM(1, logger, ref valoresAlteradosBody);
            PrepararMassa(OperadoraEnum.TIM);

            triplice.ArquivoCliente.AlterarLinha(0, "SEXO", "1");//Rejeitar na 02
            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01, true);
        }

        [TestMethod]
        public void Teste13_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste13-FG06", "Teste13-FG06");
            triplice = new TripliceTIM(1, logger, ref valoresAlteradosBody);
            PrepararMassa(OperadoraEnum.TIM);

            //triplice.ArquivoParcEmissao.AlterarLinha(0,"CD_UF_RISCO", "PP"); //Rejeitar na 01
            arquivo = triplice.ArquivoParcEmissao;
            ReplicarLinhaComCorrecao(0, 1);
            //triplice.ArquivoCliente.AlterarLinha(0, "SEXO", "1");//Rejeitar na 02
            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01, true);
        }

        [TestMethod]
        public void Teste14_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste14-FG06", "Teste14-FG06");
            triplice = new TripliceTIM(1, logger, ref valoresAlteradosBody);
            PrepararMassa(OperadoraEnum.TIM);

            //triplice.ArquivoParcEmissao.AlterarLinha(0,"CD_UF_RISCO", "PP"); //Rejeitar na 01
            arquivo = triplice.ArquivoParcEmissao;
            ReplicarLinhaComCorrecao(0, 1);
            arquivo = triplice.ArquivoCliente;
            AlterarLinha(0, "SEXO", "1");//Rejeitar na 02
            //triplice.ArquivoCliente.AlterarLinha(0, "SEXO", "1");//Rejeitar na 02
            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01, true);
        }

        [TestMethod]
        public void Teste15_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste15-FG06", "Teste15-FG06");
            triplice = new TripliceTIM(1, logger, ref valoresAlteradosBody);
            PrepararMassa(OperadoraEnum.TIM);

            arquivo = triplice.ArquivoCliente;
            AlterarLinha(0, "SEXO", "1");//Rejeitar na 02

            arquivo = triplice.ArquivoComissao;
            AlterarLinha(0, "CD_RAMO", "00");//Rejeitar na 02

            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01, true);
        }

        [TestMethod]
        public void Teste16_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste16-FG06", "Teste16-FG06");
            triplice = new TripliceTIM(1, logger, ref valoresAlteradosBody);
            PrepararMassa(OperadoraEnum.TIM);

            arquivo = triplice.ArquivoCliente;
            AlterarLinha(0, "SEXO", "1");//Rejeitar na 02

            arquivo = triplice.ArquivoParcEmissao;
            ReplicarLinhaComCorrecao(0, 1);

            triplice.Salvar(true,true,false);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoCliente, FGs.FG01, CodigoStage.RecusadoNaFG01, true);
            //ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            //ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01, true);

            //ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            //ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            //ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);


        }

        [TestMethod]
        public void Teste17_FG06()
        {
            //FG 06 - Cancelamento - TIM - CLI sucesso, PARC rejeitado e CMS ñ enviado
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste17_FG06", "Teste17_FG06");

            var arquivoEmissao = EnviarEmissao<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.TIM);

            CarregarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivoEmissao.ObterLinha(0), true, false, OperadoraEnum.TIM, "10", false);
        }

        [TestMethod]
        public void Teste18_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste18_FG06", "Teste18_FG06");
            triplice = new TripliceTIM(1, logger, ref valoresAlteradosBody);
            PrepararMassa(OperadoraEnum.TIM);
            
            arquivo = triplice.ArquivoParcEmissao;
            ReplicarLinhaComCorrecao(0, 1);

            triplice.Salvar(false, true, true);

            //ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            //ExecutarEValidarEsperandoErro(triplice.ArquivoCliente, FGs.FG01, CodigoStage.RecusadoNaFG01, true);
            //ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            //ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            //ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            //ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01, true);

            //ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            //ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            //ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);


        }

        [TestMethod]
        public void Teste21_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste21-FG06", "Teste21-FG06");
            triplice = new TripliceTIM(1, logger, ref valoresAlteradosBody);
            PrepararMassa(OperadoraEnum.TIM);

            arquivo = triplice.ArquivoComissao;
            AlterarLinha(0, "CD_RAMO", "00");//Rejeitar na 02

            triplice.Salvar(false);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01, true);
        }

        [TestMethod]
        public void Teste22_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste22-FG06", "Teste22-FG06");
            triplice = new TripliceTIM(1, logger, ref valoresAlteradosBody);
            PrepararMassa(OperadoraEnum.TIM);

            arquivo = triplice.ArquivoComissao;
            AlterarLinha(0, "CD_RAMO", "00");//Rejeitar na 02

            triplice.Salvar(true,false);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01, true);
        }

        [TestMethod]
        public void Teste23_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste23-FG06", "Teste23-FG06");
            triplice = new TripliceTIM(1, logger, ref valoresAlteradosBody);
            PrepararMassa(OperadoraEnum.TIM);

            arquivo = triplice.ArquivoComissao;
            AlterarLinha(0, "CD_RAMO", "00");//Rejeitar na 02

            triplice.Salvar(false, false);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01, true);
        }

        [TestMethod]
        public void Teste24_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste24-FG06", "Teste24-FG06");
            triplice = new TripliceTIM(1, logger, ref valoresAlteradosBody);
            PrepararMassa(OperadoraEnum.TIM);

            //triplice.ArquivoParcEmissao.AlterarLinha(0,"CD_UF_RISCO", "PP"); //Rejeitar na 01
            //arquivo = triplice.ArquivoParcEmissao;
            //ReplicarLinhaComCorrecao(0, 1);
            //arquivo = triplice.ArquivoCliente;
            //AlterarLinha(0, "SEXO", "1");//Rejeitar na 02

            //arquivo = triplice.ArquivoComissao;
            //AlterarLinha(0, "CD_RAMO", "00");//Rejeitar na 02

            triplice.Salvar(false);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01, true);
        }

        [TestMethod]
        public void Teste25_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste25-FG06", "Teste25-FG06");
            triplice = new TripliceTIM(1, logger, ref valoresAlteradosBody);
            PrepararMassa(OperadoraEnum.TIM);

            triplice.Salvar(true,false);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01, true);
        }

        [TestMethod]
        public void Teste26_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste26-FG06", "Teste26-FG06");
            triplice = new TripliceTIM(1, logger, ref valoresAlteradosBody);
            PrepararMassa(OperadoraEnum.TIM);

            triplice.Salvar(true, true,false);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01, true);
        }

        [TestMethod]
        public void Teste27_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste27-FG06", "Teste27-FG06");
            triplice = new TripliceTIM(1, logger, ref valoresAlteradosBody);
            PrepararMassa(OperadoraEnum.TIM);

            triplice.Salvar(false, false, true);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01, true);
        }

        [TestMethod]
        public void Teste28_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste27-FG06", "Teste27-FG06");
            triplice = new TripliceTIM(1, logger, ref valoresAlteradosBody);
            arquivo = triplice.ArquivoParcEmissao;
            PrepararMassa(OperadoraEnum.TIM);

            triplice.Salvar(false, true, false);
        }


        public Arquivo EnviarEmissao<T, C>(OperadoraEnum operadora) where T : Arquivo, new() where C : Arquivo, new()
        {
            arquivo = new T();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, 1);
            arquivo.AlterarLinhaSeExistirCampo(0, "ID_TRANSACAO_CANC", "");
            arquivo.AlterarLinhaSeExistirCampo(0, "CD_TIPO_EMISSAO", "1");
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_ENDOSSO", "0");
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_PARCELA", "1");
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO", "1");
            PrepararMassa(arquivo, operadora, out string tipoComissao);

            SalvarArquivo();

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            //ExecutarEValidar(arquivo, FGs.FG05, CodigoStage.ReprovadoNegocioComDependencia, "227");

            var arquivoParc = arquivo.Clone();

            arquivo = new C();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, 1);
            IgualarCamposQueExistirem(arquivoParc, arquivo);
            arquivo.AlterarLinhaSeExistirCampo(0, "ID_TRANSACAO_CANC", "");
            arquivo.AlterarLinhaSeExistirCampo(0, "CD_TIPO_EMISSAO", "1");
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_ENDOSSO", "0");
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_PARCELA", "1");
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO", "1");
            if (tipoComissao != "")
                arquivo.AlterarLinhaSeExistirCampo(0, "CD_TIPO_COMISSAO", tipoComissao);
            SalvarArquivo();

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            //ExecutarEValidar(arquivo, FGs.FG05, CodigoStage.ReprovadoNegocioComDependencia, "54");

            return arquivoParc.Clone();
        }


        public void PrepararMassa(OperadoraEnum operadora, bool alterarCorretor = true)
        {
           triplice.AlterarCliente(0, "CD_CLIENTE", ParametrosBanco.ObterCDClienteCadastrado(operadora));

            SetDev();

            var cobertura = dados.ObterCoberturaSimples(triplice.ArquivoCliente.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado);
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_COBERTURA", cobertura.CdCobertura);
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_RAMO", cobertura.CdRamo);
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_PRODUTO", cobertura.CdProduto);
            triplice.ArquivoParcEmissao.AlterarTodasAsLinhas("VL_LMI", triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "VL_IS"));

            //triplice.ArquivoParcEmissao.AlterarTodasAsLinhas("VL_PREMIO_TOTAL", (cobertura.ValorPremioLiquidoMaiorDecimal - 0.01M).ValorFormatado());
            triplice.ArquivoParcEmissao.AlterarTodasAsLinhas("VL_IOF", "0");
            //triplice.ArquivoParcEmissao.AlterarTodasAsLinhas("VL_PREMIO_LIQUIDO", (cobertura.ValorPremioLiquidoMaiorDecimal - 0.01M).ValorFormatado());

            if (alterarCorretor)
            {
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
                else if (operadora == OperadoraEnum.TIM)
                {
                    triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_CORRETOR", "7950129");
                    triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_TIPO_COMISSAO", "P");
                }
                else
                    throw new Exception("OPERACAO SEM CORRETOR CADASTRADO.");
            }

            SetQA();

            var novoContrato = AlterarUltimasPosicoes(triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(8));
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_CONTRATO", novoContrato);
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("NR_PROPOSTA", novoContrato);
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("NR_APOLICE", novoContrato);

        }

        public void PrepararMassa(Arquivo arquivo, OperadoraEnum operadora, out string tipoCorretor)
        {
            tipoCorretor = "";
            //arquivo.AlterarLinhaSeExistirCampo(0, "CD_CLIENTE", GerarNumeroAleatorio(8));

            SetDev();

            var cobertura = dados.ObterCoberturaSimples(arquivo.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado);
            for (int i = 0; i < arquivo.Linhas.Count; i++)
            {
                arquivo.AlterarLinhaSeExistirCampo(i, "CD_COBERTURA", cobertura.CdCobertura);
                arquivo.AlterarLinhaSeExistirCampo(i, "CD_RAMO", cobertura.CdRamo);
                arquivo.AlterarLinhaSeExistirCampo(i, "CD_PRODUTO", cobertura.CdProduto);
                arquivo.AlterarLinhaSeExistirCampo(i, "VL_LMI", arquivo.ObterValorFormatadoSeExistirCampo(0, "VL_IS"));
                arquivo.AlterarLinhaSeExistirCampo(i, "CD_CLIENTE", ParametrosBanco.ObterCDClienteCadastrado(operadora));
            }


            SetQA();


            var novoContrato = AlterarUltimasPosicoes(arquivo.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(8));
            for (int i = 0; i < arquivo.Linhas.Count; i++)
            {
                arquivo.AlterarLinhaSeExistirCampo(i, "CD_CONTRATO", novoContrato);
                arquivo.AlterarLinhaSeExistirCampo(i, "NR_PROPOSTA", novoContrato);
                arquivo.AlterarLinhaSeExistirCampo(i, "NR_APOLICE", novoContrato);


                if (operadora == OperadoraEnum.VIVO)
                {
                    arquivo.AlterarLinhaSeExistirCampo(i, "CD_CORRETOR", "7239711");
                    tipoCorretor = "C";
                    //triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_TIPO_COMISSAO", "C");
                }
                else if (operadora == OperadoraEnum.LASA || operadora == OperadoraEnum.SOFTBOX)
                {
                    arquivo.AlterarLinhaSeExistirCampo(i, "CD_CORRETOR", "7150145");
                    tipoCorretor = "P";
                }
                else if (operadora == OperadoraEnum.POMPEIA)
                {
                    arquivo.AlterarLinhaSeExistirCampo(i, "CD_CORRETOR", "7150166");
                    tipoCorretor = "P";
                }
                else if (operadora == OperadoraEnum.TIM)
                {
                    arquivo.AlterarLinhaSeExistirCampo(i, "CD_CORRETOR", "7950129");
                    tipoCorretor = "P";
                }
                else
                    throw new Exception("OPERACAO SEM CORRETOR CADASTRADO.");

            }

        }

        private static void SetQA()
        {
            DBHelperHana.Instance.SetConnection("Server=zeus.hana.prod.sa-east-1.whitney.dbaas.ondemand.com:20274;UID=CCARVALHO;PWD=Cristiano@03;encrypt=TRUE;Connection Timeout=5000");
            Parametros.instanciaDB = "HDIQAS_1";
        }

        private static void SetDev()
        {
            Parametros.instanciaDB = "HDIDEV_1";
            DBHelperHana.Instance.SetConnection("Server=zeus.hana.prod.sa-east-1.whitney.dbaas.ondemand.com:20272;UID=CCARVALHO;PWD=Generali@10;encrypt=TRUE;");
        }
    }
}
