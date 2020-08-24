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
        private string nomeDoArquivoParaValidacao = $"C01.SOFTBOX.EMSCMS-IN-0001-{DateTime.Now.ToString("yyyyMMdd")}.TXT";
        [TestMethod]
        public void Teste1_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste1-FG06", "Teste1-FG06");
            triplice = new TripliceVIVO(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.VIVO);
            triplice.Salvar();
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        public void Teste2_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste2-FG06", "Teste2-FG06");
            triplice = new TripliceLASA(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.LASA);
            triplice.Salvar();
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidarEsperandoErro(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            //ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            //ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            //ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            //ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            //ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            //ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG05, CodigoStage.ReprovadoNegocioComDependencia);
        }

        [TestMethod]
        public void Teste3_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste3-FG06", "Teste1-FG06");
            triplice = new TriplicePOMPEIA(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.POMPEIA);

            //triplice.ArquivoParcEmissao.AlterarLinha(0,"CD_UF_RISCO", "PP"); //Rejeitar na 01
            triplice.ArquivoParcEmissao.AlterarLinha(0, "CD_RAMO", "00");
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
            //FG 06 - Emissão - LASA - CLI rejeitado, PARC sucesso e CMS ñ enviado
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste4-FG06", "Teste4-FG06");
            triplice = new TripliceLASA(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.LASA);
            triplice.ArquivoCliente.AlterarLinha(0, "NR_CNPJ_CPF", "1111");
            triplice.Salvar(true, true, false);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoCliente, FGs.FG01, CodigoStage.RecusadoNaFG01);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        public void Teste5_FG06()
        {
            //FG 06 - Emissão - SOFTBOX - CLI rejeitado, PARC ñ enviado e CMS sucesso
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste5-FG06", "Teste1-FG06");
            triplice = new TripliceSoftbox(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.SOFTBOX);
            triplice.ArquivoCliente.AlterarLinha(0, "NR_CNPJ_CPF", "1111");//Rejeitar na 02
            triplice.Salvar(true, false);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoCliente, FGs.FG01, CodigoStage.RecusadoNaFG01);

            //NAO TESTAR O PARC, E CMS NAO RODA PARA SOFTBOX
        }

        [TestMethod]
        public void Teste6_FG06()
        {
            //FG 06 - Cancelamento - VIVO - PARC sucesso e CMS sucesso
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "Teste6-FG06", "Teste6-FG06");

            var arquivoEmissao = EnviarEmissao<Arquivo_Layout_9_3_ParcEmissaoAuto, Arquivo_Layout_9_3_EmsComissao>(OperadoraEnum.VIVO);

            CarregarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto, Arquivo_Layout_9_3_EmsComissao>(arquivoEmissao.ObterLinha(0), false, false, OperadoraEnum.VIVO, "10", false);
        }

        [TestMethod]
        public void Teste7_FG06()
        {
            //FG 06 - Cancelamento - LASA - PARC sucesso e CMS sucesso
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "Teste7-FG06", "Teste7-FG06");

            var arquivoEmissao = EnviarEmissao<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA);

            CarregarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivoEmissao.ObterLinha(0), false, false, OperadoraEnum.LASA, "10", false);
        }

        [TestMethod]
        public void Teste8_FG06()
        {
            //FG 06 - Cancelamento - POMPEIA -PARC rejeitado e CMS sucesso
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "Teste8-FG06", "Teste8-FG06");

            var arquivoEmissao = EnviarEmissao<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA);

            CarregarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivoEmissao.ObterLinha(0), true, false, OperadoraEnum.POMPEIA, "10", false);

        }

        [TestMethod]
        public void Teste9_FG06()
        {
            //FG 06 - Cancelamento - LASA - PARC sucesso e CMS ñ enviado
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "Teste9-FG06", "Teste9-FG06");

            var arquivoEmissao = EnviarEmissao<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA);

            CarregarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivoEmissao.ObterLinha(0), false, false, OperadoraEnum.POMPEIA, "10", false);

        }

        [TestMethod]
        public void Teste10_FG06()
        {
            //FG 06 - Cancelamento - SOFTBOX -PARC ñ enviado e CMS sucesso
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "Teste10-FG06", "Teste10-FG06");

            var arquivoEmissao = EnviarEmissao<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.SOFTBOX);

            CarregarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivoEmissao.ObterLinha(0), true, false, OperadoraEnum.SOFTBOX, "10", false);

        }

        [TestMethod]
        public void Teste12_FG06()
        {
            //FG 06 - Emissão - TIM - CLI rejeitado, PARC sucesso e CMS sucesso - apenas dupla - emissão capa
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste12-FG06", "Teste12-FG06");
            triplice = new TripliceTIM(1, logger);
            //triplice.ArquivoParcEmissao.Carregar()
            PrepararMassaParaTrinca(OperadoraEnum.TIM);

            triplice.ArquivoCliente.AlterarLinha(0, "NR_CNPJ_CPF", "1111");//Rejeitar na 01
            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoCliente, FGs.FG01, CodigoStage.RecusadoNaFG01);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        public void Teste13_FG06()
        {
            //FG 06 - Emissão - TIM - CLI sucesso, PARC rejeitado e CMS sucesso - apenas dupla - emissão capa
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste13-FG06", "Teste13-FG06");
            triplice = new TripliceTIM(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.TIM);

            //triplice.ArquivoParcEmissao.AlterarLinha(0,"CD_UF_RISCO", "PP"); //Rejeitar na 01
            triplice.ArquivoParcEmissao.AlterarLinha(0, "CD_RAMO", "00");
            //triplice.ArquivoCliente.AlterarLinha(0, "SEXO", "1");//Rejeitar na 02
            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);
        }

        [TestMethod]
        public void Teste14_FG06()
        {
            //FG 06 - Emissão - TIM - CLI rejeitado, PARC rejeitado e CMS sucesso - apenas dupla - emissão capa
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste14-FG06", "Teste14-FG06");
            triplice = new TripliceTIM(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.TIM);

            triplice.ArquivoParcEmissao.AlterarLinha(0, "CD_RAMO", "00");
            triplice.ArquivoCliente.AlterarLinha(0, "NR_CNPJ_CPF", "1111");

            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoCliente, FGs.FG01, CodigoStage.RecusadoNaFG01);


            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);
        }

        [TestMethod]
        public void Teste15_FG06()
        {
            //FG 06 - Emissão - TIM - CLI rejeitado, PARC sucesso e CMS rejeitado
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste15-FG06", "Teste15-FG06");
            triplice = new TripliceTIM(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.TIM);

            var novoParc = new Arquivo_Layout_9_4_ParcEmissao().Carregar(ObterArquivoOrigem("ABC_C01.TIM.PARCEMS-EV-0005-20191210.txt"));
            IgualarCampos(triplice.ArquivoParcEmissao, novoParc, new string[] {"CD_CORRETOR", "CD_CONTRATO", "NR_PROPOSTA", "NR_APOLICE", "CD_CLIENTE","CD_COBERTURA", "CD_PRODUTO", "CD_RAMO" }, true, false);

            CarregarComissao("P", novoParc, triplice.ArquivoComissao,1);

            var novoParc18 = novoParc.Clone();
            novoParc18.RemoverExcetoEstas(0, 1);

            triplice.ArquivoComissao.AlterarLinha(0, "CD_RAMO", "00");//Rejeitar na 02


            //triplice.Salvar(false,false,false);

            arquivo = triplice.ArquivoCliente;
            EnviarParaOdsAlterandoCliente(triplice.ArquivoCliente);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            arquivo = novoParc18;
            EnviarParaOdsAlterandoCliente(arquivo);
            ExecutarEValidar(novoParc18, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(novoParc18, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            var novoParc20 = novoParc.Clone();
            novoParc20.RemoverExcetoEstas(1, 1);
            arquivo = novoParc20;
            SalvarArquivo();
            ExecutarEValidar(novoParc20, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(novoParc20, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(novoParc20, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(novoParc20, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            triplice.Salvar(false, false, true);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);


        }

        [TestMethod]
        public void Teste16_FG06()
        {
            //FG 06 - Emissão - TIM - CLI sucesso, PARC ñ enviado e CMS ñ enviado
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste16-FG06", "Teste16-FG06");
            triplice = new TripliceTIM(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.TIM);

            triplice.Salvar(true, false, false);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        public void Teste17_FG06()
        {
            ////FG 06 - Cancelamento - TIM - CLI sucesso, PARC rejeitado e CMS ñ enviado
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste17_FG06", "Teste17_FG06");

            triplice = new TripliceTIM(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.TIM);

            var novoParc = new Arquivo_Layout_9_4_ParcEmissao().Carregar(ObterArquivoOrigem("ABC_C01.TIM.PARCEMS-EV-0005-20191210.txt"));
            IgualarCampos(triplice.ArquivoParcEmissao, novoParc, new string[] { "CD_CORRETOR", "CD_CONTRATO", "NR_PROPOSTA", "NR_APOLICE", "CD_CLIENTE", "CD_COBERTURA", "CD_PRODUTO", "CD_RAMO" }, true, false);

            CarregarComissao("P", novoParc, triplice.ArquivoComissao, 1);

            var novoParc18 = novoParc.Clone();
            novoParc18.RemoverExcetoEstas(0, 1);

            //triplice.Salvar(false,false,false);

            arquivo = triplice.ArquivoCliente;
            EnviarParaOdsAlterandoCliente(triplice.ArquivoCliente);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            arquivo = novoParc18;
            EnviarParaOdsAlterandoCliente(novoParc18);
            ExecutarEValidar(novoParc18, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(novoParc18, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            var novoParc20 = novoParc.Clone();
            novoParc20.RemoverExcetoEstas(1, 1);
            arquivo = novoParc20;
            SalvarArquivo();
            ExecutarEValidar(novoParc20, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(novoParc20, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(novoParc20, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(novoParc20, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            triplice.Salvar(false, false, true);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);



            CarregarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(novoParc20.ObterLinha(0), true, false, OperadoraEnum.TIM, "10");
        }

        [TestMethod]
        public void Teste18_FG06()
        {
            //FG 06 - Emissão - TIM - CLI ñ sucesso, PARC rejeitado e CMS sucesso - apenas dupla

            IniciarTeste(TipoArquivo.ParcEmissao, "Teste18-FG06", "Teste18-FG06");
            triplice = new TripliceTIM(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.TIM);

            triplice.ArquivoParcEmissao.AlterarLinha(0, "CD_RAMO", "00");
            triplice.ArquivoCliente.AlterarLinha(0, "NR_CNPJ_CPF", "1111");
            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarEsperandoErro(triplice.ArquivoCliente, FGs.FG01, CodigoStage.RecusadoNaFG01);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);


        }

        [TestMethod]
        public void Teste19_FG06()
        {
            //FG06 - Emissão - TIM - CLI sucesso, PARC rejeitado e CMS ñ enviado
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste19_FG06", "Teste19_FG06");
            triplice = new TripliceTIM(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.TIM);

            var novoParc = new Arquivo_Layout_9_4_ParcEmissao().Carregar(ObterArquivoOrigem("ABC_C01.TIM.PARCEMS-EV-0005-20191210.txt"));
            IgualarCampos(triplice.ArquivoParcEmissao, novoParc, new string[] { "CD_CORRETOR", "CD_CONTRATO", "NR_PROPOSTA", "NR_APOLICE", "CD_CLIENTE", "CD_COBERTURA", "CD_PRODUTO", "CD_RAMO" }, true, false);

            CarregarComissao("P", novoParc, triplice.ArquivoComissao, 1);

            var novoParc18 = novoParc.Clone();
            novoParc18.RemoverExcetoEstas(0, 1);

            arquivo = triplice.ArquivoCliente;
            EnviarParaOdsAlterandoCliente(triplice.ArquivoCliente);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            arquivo = novoParc18;
            SalvarArquivo();
            ExecutarEValidar(novoParc18, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(novoParc18, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(novoParc18, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(novoParc18, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            var novoParc20 = novoParc.Clone();
            novoParc20.RemoverExcetoEstas(1, 1);
            novoParc20.AlterarLinha(0, "CD_RAMO", "00");
            arquivo = novoParc20;
            SalvarArquivo();
            ExecutarEValidar(novoParc20, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(novoParc20, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(novoParc20, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);
        }
        [TestMethod]
        public void Teste20_FG06()
        {
            //FG 06 - Emissão - TIM - CLI sucesso, PARC sucesso e CMS rejeitado
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste15-FG06", "Teste15-FG06");
            triplice = new TripliceTIM(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.TIM);

            var novoParc = new Arquivo_Layout_9_4_ParcEmissao().Carregar(ObterArquivoOrigem("ABC_C01.TIM.PARCEMS-EV-0005-20191210.txt"));
            IgualarCampos(triplice.ArquivoParcEmissao, novoParc, new string[] { "CD_CORRETOR", "CD_CONTRATO", "NR_PROPOSTA", "NR_APOLICE", "CD_CLIENTE", "CD_COBERTURA", "CD_PRODUTO", "CD_RAMO" }, true, false);

            CarregarComissao("P", novoParc, triplice.ArquivoComissao, 1);

            var novoParc18 = novoParc.Clone();
            novoParc18.RemoverExcetoEstas(0, 1);

            triplice.ArquivoComissao.AlterarLinha(0, "CD_RAMO", "00");//Rejeitar na 02


            //triplice.Salvar(false,false,false);

            arquivo = triplice.ArquivoCliente;
            EnviarParaOdsAlterandoCliente(triplice.ArquivoCliente);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            arquivo = novoParc18;
            SalvarArquivo();
            ExecutarEValidar(novoParc18, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(novoParc18, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(novoParc18, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(novoParc18, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            var novoParc20 = novoParc.Clone();
            novoParc20.RemoverExcetoEstas(1, 1);
            arquivo = novoParc20;
            SalvarArquivo();
            ExecutarEValidar(novoParc20, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(novoParc20, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(novoParc20, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(novoParc20, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            triplice.Salvar(false, false, true);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);

        }

        [TestMethod]
        public void Teste21_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste21-FG06", "Teste21-FG06");
            triplice = new TripliceTIM(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.TIM);

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
            triplice = new TripliceTIM(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.TIM);

            arquivo = triplice.ArquivoComissao;
            AlterarLinha(0, "CD_RAMO", "00");//Rejeitar na 02

            triplice.Salvar(true, false);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarEsperandoErro(triplice.ArquivoComissao, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
        }

        [TestMethod]
        public void Teste23_FG06()
        {
            //FG 06 - Emissão - TIM - CLI ñ enviado, PARC sucesso e CMS sucesso - apenas dupla
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste23-FG06", "Teste23-FG06");
            triplice = new TripliceTIM(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.TIM);

            triplice.Salvar(false,true,false);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        public void Teste24_FG06()
        {
            //FG 06 - Emissão - TIM - CLI sucesso, PARC ñ enviado e CMS sucesso
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste24-FG06", "Teste24-FG06");
            triplice = new TripliceTIM(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.TIM);

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
            triplice = new TripliceTIM(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.TIM);

            triplice.Salvar(true, false);

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
            triplice = new TripliceTIM(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.TIM);

            triplice.Salvar(true, true, false);

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
            //FG 06 - Cancelamento - TIM - CLI sucesso, PARC sucesso e CMS ñ enviado

            IniciarTeste(TipoArquivo.ParcEmissao, "Teste27-FG06", "Teste27-FG06");
            triplice = new TripliceTIM(1, logger);
            PrepararMassaParaTrinca(OperadoraEnum.TIM);

            var novoParc = new Arquivo_Layout_9_4_ParcEmissao().Carregar(ObterArquivoOrigem("ABC_C01.TIM.PARCEMS-EV-0005-20191210.txt"));
            IgualarCampos(triplice.ArquivoParcEmissao, novoParc, new string[] { "CD_CORRETOR", "CD_CONTRATO", "NR_PROPOSTA", "NR_APOLICE", "CD_CLIENTE", "CD_COBERTURA", "CD_PRODUTO", "CD_RAMO" }, true, false);

            CarregarComissao("P", novoParc, triplice.ArquivoComissao, 1);

            var novoParc18 = novoParc.Clone();
            novoParc18.RemoverExcetoEstas(0, 1);

            //triplice.Salvar(false,false,false);

            arquivo = triplice.ArquivoCliente;
            EnviarParaOdsAlterandoCliente(triplice.ArquivoCliente);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            arquivo = novoParc18;
            EnviarParaOdsAlterandoCliente(novoParc18);
            ExecutarEValidar(novoParc18, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(novoParc18, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            var novoParc20 = novoParc.Clone();
            novoParc20.RemoverExcetoEstas(1, 1);
            arquivo = novoParc20;
            SalvarArquivo();
            ExecutarEValidar(novoParc20, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(novoParc20, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(novoParc20, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(novoParc20, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            triplice.Salvar(false, false, true);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            CarregarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(novoParc20.ObterLinha(0), false, false, OperadoraEnum.TIM, "10");
        }

        [TestMethod]
        public void Teste28_FG06()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste27-FG06", "Teste27-FG06");
            triplice = new TripliceTIM(1, logger);
            arquivo = triplice.ArquivoParcEmissao;
            PrepararMassaParaTrinca(OperadoraEnum.TIM);

            triplice.Salvar(false, true, false);
        }


        public Arquivo EnviarEmissao<T, C>(OperadoraEnum operadora, bool clienteEnviado = true) where T : Arquivo, new() where C : Arquivo, new()
        {
            arquivo = new T();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, 1);
            arquivo.AlterarLinhaSeExistirCampo(0, "ID_TRANSACAO_CANC", "");
            arquivo.AlterarLinhaSeExistirCampo(0, "CD_TIPO_EMISSAO", ParametrosRegrasEmissao.CarregaTipoEmissaoParaPrimeiraLinhaDaEmissao(operadora));
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_ENDOSSO", "0");
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_PARCELA", ParametrosRegrasEmissao.CarregaPrimeiroNrParcela(operadora));
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO", "1");
            PrepararMassaParaParcela(arquivo, operadora, out string tipoComissao);

            if (!clienteEnviado)
                arquivo.AlterarLinhaSeExistirCampo(0, "CD_CLIENTE", GerarNumeroAleatorio(8));

            SalvarArquivo();

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(arquivo, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            var arquivoParc = arquivo.Clone();

            arquivo = new C();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, 1);
            CarregarComissao(tipoComissao, arquivoParc,arquivo);

            SalvarArquivo();

            if (operadora != OperadoraEnum.LASA && operadora != OperadoraEnum.SOFTBOX)
            {
                ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
                ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
                ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
                ExecutarEValidar(arquivo, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
            }
            //ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            //ExecutarEValidar(arquivo, FGs.FG05, CodigoStage.ReprovadoNegocioComDependencia, "54");

            return arquivoParc.Clone();
        }

        private void CarregarComissao(string tipoComissao, Arquivo arquivoParc, Arquivo arquivoComissao, int indexLinhaParc = 0)
        {
            IgualarCamposQueExistirem(arquivoParc.ObterLinha(indexLinhaParc), arquivoComissao.ObterLinha(0));
            if (arquivoParc.ObterValorFormatado(indexLinhaParc, "VL_PREMIO_LIQUIDO").ObterValorDecimal() > 0M)
                arquivoComissao.AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoParc.ObterValorFormatado(indexLinhaParc, "VL_PREMIO_LIQUIDO"), "-0.05"));
            else
                arquivoComissao.AlterarLinha(0, "VL_COMISSAO", ObterValorFormatado(0, "VL_PREMIO_LIQUIDO"));

            if (tipoComissao != "")
                arquivoComissao.AlterarLinhaSeExistirCampo(0, "CD_TIPO_COMISSAO", tipoComissao);
        }

        public void CarregarCancelamento<T, C>(LinhaArquivo linhaArquivoEmissao, bool erroEmParc, bool erroEmComissao, OperadoraEnum operadora, string cdTipoEmissao,
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

            var codigoRamoCorreto = linhaArquivoEmissao.ObterValorFormatado("CD_RAMO");
            if (erroEmParc)
            {
                AlterarLinha(0, "CD_RAMO", "00");//Rejeitar na 02
            }

            SalvarArquivo();

            logger.Escrever("ARQUIVO CRIADO COM O NOME : " + arquivo.NomeArquivo);

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            if (erroEmParc)
                ExecutarEValidarEsperandoErro(arquivo, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);
            else
            {
                ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            }
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
            else
                AlterarLinha(0, "CD_RAMO", codigoRamoCorreto);

            if(arquivoParc.ObterValorFormatado(0, "VL_PREMIO_LIQUIDO").ObterValorDecimal() > 0)
                AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoParc.ObterValorFormatado(0, "VL_PREMIO_LIQUIDO"), "-0.05"));
            else
                AlterarLinha(0, "VL_COMISSAO", "0");

            if (ObterValorFormatado(0,"VL_COMISSAO").ObterValorDecimal() < 0)
                throw new Exception("VL_COMISSAO INVALIDO.");

            SalvarArquivo();

            logger.Escrever("ARQUIVO CRIADO COM O NOME : " + arquivo.NomeArquivo);
            if (operadora != OperadoraEnum.LASA && operadora != OperadoraEnum.SOFTBOX)
            {
                ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
                ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);

                if (erroEmComissao)
                    ExecutarEValidarEsperandoErro(arquivo, FGs.FG02, CodigoStage.ReprovadoNegocioSemDependencia);
                else
                {
                    ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
                }
            }
        }



        public void PrepararMassaParaTrinca(OperadoraEnum operadora, bool alterarCorretor = true)
        {
            //NA TRINCA GERAR O CLIENTE
            triplice.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(8));

            triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_TIPO_EMISSAO", ParametrosRegrasEmissao.CarregaTipoEmissaoParaPrimeiraLinhaDaEmissao(operadora));

            triplice.AlterarTodasAsLinhasQueContenhamOCampo("NR_SEQUENCIAL_EMISSAO", "1");
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("NR_ENDOSSO", "0");
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("ID_TRANSACAO_CANC", "");

            triplice.AlterarTodasAsLinhasQueContenhamOCampo("NR_PARCELA", ParametrosRegrasEmissao.CarregaPrimeiroNrParcela(operadora));

            SetDev();

            var cobertura = dados.ObterCoberturaSimples(triplice.ArquivoCliente.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado);
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_COBERTURA", cobertura.CdCobertura);
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_RAMO", cobertura.CdRamoCobertura);
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_PRODUTO", cobertura.CdProduto);
            triplice.ArquivoParcEmissao.AlterarTodasAsLinhas("VL_LMI", triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "VL_IS"));

            triplice.ArquivoParcEmissao.AlterarTodasAsLinhas("VL_PREMIO_TOTAL", SomarValores(triplice.ArquivoParcEmissao.ObterValorFormatado(0, "VL_PREMIO_LIQUIDO"), triplice.ArquivoParcEmissao.ObterValorFormatado(0, "VL_IOF")));
            if(triplice.ArquivoParcEmissao.ObterValorFormatado(0, "VL_PREMIO_LIQUIDO").ObterValorDecimal() > 0)
                triplice.AlterarTodasAsLinhasQueContenhamOCampo("VL_COMISSAO", SomarValores(triplice.ArquivoParcEmissao.ObterValorFormatado(0, "VL_PREMIO_LIQUIDO"), "-0.05"));
            else
                triplice.AlterarTodasAsLinhasQueContenhamOCampo("VL_COMISSAO", triplice.ArquivoParcEmissao.ObterValorFormatado(0, "VL_PREMIO_LIQUIDO"));
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

        public void PrepararMassaParaParcela(Arquivo arquivo, OperadoraEnum operadora, out string tipoCorretor)
        {
            tipoCorretor = "";

            SetDev();

            var cobertura = dados.ObterCoberturaSimples(arquivo.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado);
            for (int i = 0; i < arquivo.Linhas.Count; i++)
            {
                arquivo.AlterarLinhaSeExistirCampo(i, "CD_COBERTURA", cobertura.CdCobertura);
                arquivo.AlterarLinhaSeExistirCampo(i, "CD_RAMO", cobertura.CdRamoCobertura);
                arquivo.AlterarLinhaSeExistirCampo(i, "CD_PRODUTO", cobertura.CdProduto);
                arquivo.AlterarLinhaSeExistirCampo(i, "VL_LMI", arquivo.ObterValorFormatadoSeExistirCampo(0, "VL_IS"));
                //no arquivo de parcela, fora da trinca, envia-se um cliente cadastrado
                arquivo.AlterarLinhaSeExistirCampo(i, "CD_CLIENTE", ParametrosBanco.ObterCDClienteCadastrado(operadora));
            }


            SetQA();


            var novoContrato = AlterarUltimasPosicoes(arquivo.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(8));
            for (int i = 0; i < arquivo.Linhas.Count; i++)
            {
                arquivo.AlterarLinhaSeExistirCampo(i, "CD_CONTRATO", novoContrato);
                arquivo.AlterarLinhaSeExistirCampo(i, "NR_PROPOSTA", novoContrato);
                arquivo.AlterarLinhaSeExistirCampo(i, "NR_APOLICE", novoContrato);
                arquivo.AlterarLinhaSeExistirCampo(i, "VL_PREMIO_TOTAL", SomarValores(arquivo.ObterValorFormatado(i, "VL_PREMIO_LIQUIDO"), arquivo.ObterValorFormatado(i, "VL_IOF")));


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
            //DBHelperHana.Instance.SetConnection("Server=zeus.hana.prod.sa-east-1.whitney.dbaas.ondemand.com:20274;UID=CCARVALHO;PWD=Cristiano@03;encrypt=TRUE;Connection Timeout=5000");
            //Parametros.instanciaDB = "HDIQAS_1";
        }

        private static void SetDev()
        {
            //Parametros.instanciaDB = "HDIDEV_1";
            //DBHelperHana.Instance.SetConnection("Server=zeus.hana.prod.sa-east-1.whitney.dbaas.ondemand.com:20272;UID=CCARVALHO;PWD=Generali@10;encrypt=TRUE;");
        }

        private void ValidarFG04(Arquivo _arquivo)
        {
            ExecutarEValidarFG04Comissao(_arquivo.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
    nomeDoArquivoParaValidacao, CodigoStage.AprovadoNAFG00);
            ExecutarEValidarStageComissao(_arquivo.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
                nomeDoArquivoParaValidacao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidarStageComissao(_arquivo.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
    nomeDoArquivoParaValidacao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidarStageComissao(_arquivo.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"),
    nomeDoArquivoParaValidacao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
        }

        private void CarregaLinhaTim(Arquivo arquivoTimCapa)
        {
            var arq = new Arquivo_Layout_9_4_ParcEmissao().Carregar("Tipo20_C01.TIM.PARCEMS-EV-0005-20191212.txt");
            arquivoTimCapa.AdicionarLinha(arq.ObterLinha(0));
            IgualarCampos(arquivoTimCapa.ObterLinha(0), arquivoTimCapa.ObterLinha(1), new string[] { "CD_CONTRATO" });
        }
    }
}
