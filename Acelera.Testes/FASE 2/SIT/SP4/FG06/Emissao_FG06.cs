using Acelera.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG06
{
    public class Emissao_FG06 : FG06_Base
    {

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5921()
        {
            //5921:FG06 - VIVO - CLI sucesso, PARC sucesso e CMS sucesso
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "5921", "");

            CarregarTriplice(OperadoraEnum.VIVO);

            AlteracoesPadraoDaTrinca(triplice);

            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidarFG06(triplice, CodigoStage.AprovadoFG06, CodigoStage.AprovadoFG06, CodigoStage.AprovadoFG06, "", "", "");

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5922()
        {
            //5922:FG06 - VIVO - CLI rejeitado, PARC sucesso e CMS sucesso
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "5922", "");

            CarregarTriplice(OperadoraEnum.VIVO);

            AlteracoesPadraoDaTrinca(triplice);
            triplice.AlterarCliente(0, "NR_CNPJ_CPF", "00000-00000");

            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.RecusadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);


            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidarFG06(triplice, CodigoStage.RecusadoNaFG01, CodigoStage.ReprovadoFG06, CodigoStage.ReprovadoFG06, "41", "103", "105");

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5923()
        {
            //FG06 - VIVO - CLI sucesso, PARC rejeitado e CMS sucesso
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "5923", "");

            CarregarTriplice(OperadoraEnum.VIVO);

            AlteracoesPadraoDaTrinca(triplice);
            triplice.AlterarParcEComissao(0, "VL_PREMIO_LIQUIDO", "abc");


            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidarFG06(triplice, CodigoStage.ReprovadoFG06, CodigoStage.RecusadoNaFG01, CodigoStage.ReprovadoFG06, "403", "07", "105");

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5924()
        {
            //5924:FG06 - VIVO - CLI sucesso, PARC sucesso e CMS rejeitado
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "5924", "");

            CarregarTriplice(OperadoraEnum.VIVO);

            AlteracoesPadraoDaTrinca(triplice);

            triplice.AlterarParcEComissao(0, "VL_COMISSAO", "a");

            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.RecusadoNaFG01);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidarFG06(triplice, CodigoStage.ReprovadoFG06, CodigoStage.ReprovadoFG06, CodigoStage.RecusadoNaFG01, "403", "103", "07");

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5925()
        {
            //POMPEIA - CLI rejeitado, PARC rejeitado e CMS sucesso
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "5925", "");

            CarregarTriplice(OperadoraEnum.POMPEIA);

            AlteracoesPadraoDaTrinca(triplice);
            triplice.AlterarParcEComissao(0, "VL_PREMIO_LIQUIDO", "abc");
            triplice.AlterarCliente(0, "NR_CNPJ_CPF", "00000-00000");

            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.RecusadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidarFG06(triplice, CodigoStage.RecusadoNaFG01, CodigoStage.RecusadoNaFG01, CodigoStage.ReprovadoFG06, "41", "07", "105");
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5926()
        {
            //POMPEIA - CLI rejeitado, PARC rejeitado e CMS sucesso
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "5926", "");

            CarregarTriplice(OperadoraEnum.POMPEIA);

            AlteracoesPadraoDaTrinca(triplice);
            triplice.AlterarParcEComissao(0, "VL_PREMIO_LIQUIDO", "abc");
            triplice.AlterarParcEComissao(0, "VL_COMISSAO", "a");


            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.RecusadoNaFG01);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidarFG06(triplice, CodigoStage.RecusadoNaFG01, CodigoStage.RecusadoNaFG01, CodigoStage.ReprovadoFG06, "403", "07", "07");
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5927()
        {
            // POMPEIA - CLI rejeitado, PARC sucesso e CMS rejeitado
            InicioTesteFG06("5927", "", OperadoraEnum.POMPEIA);

            AdicionaErro(TipoArquivo.Cliente);
            AdicionaErro(TipoArquivo.Comissao);

            SalvarTrinca();
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5928()
        {
            // SAP-5928:FG06 - POMPEIA - CLI rejeitado, PARC rejeitado e CMS rejeitado
            InicioTesteFG06("5928", "SAP-5928:FG06 - POMPEIA - CLI rejeitado, PARC rejeitado e CMS rejeitado", OperadoraEnum.POMPEIA);

            AdicionaErro(TipoArquivo.Cliente);
            AdicionaErro(TipoArquivo.Comissao);
            AdicionaErro(TipoArquivo.ParcEmissao);

            SalvarTrinca();
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5929()
        {
            // SAP-5929:FG06 - POMPEIA - CLI rejeitado, PARC ñ enviado e CMS sucesso
            InicioTesteFG06("5929", "FG06 - POMPEIA - CLI rejeitado, PARC ñ enviado e CMS sucesso", OperadoraEnum.POMPEIA);

            AdicionaErro(TipoArquivo.Cliente);

            SalvarTrinca(true, false, true);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5930()
        {
            // SAP-5930:FG06 - LASA - CLI rejeitado, PARC sucesso e CMS ñ enviado
            InicioTesteFG06("5930", "FG06 - POMPEIA - CLI rejeitado, PARC ñ enviado e CMS sucesso", OperadoraEnum.POMPEIA);

            AdicionaErro(TipoArquivo.Cliente);
            AdicionaErro(TipoArquivo.Comissao);

            SalvarTrinca(true, true, true);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5931()
        {
            // FG06 - LASA - CLI rejeitado ODS, PARC sucesso e CMS sucesso
            InicioTesteFG06("5931", "FG06 - LASA - CLI rejeitado ODS, PARC sucesso e CMS sucesso", OperadoraEnum.LASA);

            AdicionaErro(TipoArquivo.Cliente);

            SalvarTrinca();
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5932()
        {
            // FG06 - LASA - CLI rejeitado, PARC ñ enviado e ñ enviado
            InicioTesteFG06("5932", "FG06 - LASA - CLI rejeitado, PARC ñ enviado e ñ enviado", OperadoraEnum.LASA);

            AdicionaErro(TipoArquivo.Cliente);

            SalvarTrinca(true,false,false);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5933()
        {
            // FG06 - LASA - CLI rejeitado ODS, PARC sucesso e CMS sucesso
            InicioTesteFG06("5933", " SAP-5933:FG06 - LASA - CLI sucesso, PARC rejeitado e CMS ñ enviado", OperadoraEnum.LASA);

            AdicionaErro(TipoArquivo.Cliente);

            SalvarTrinca(true,true,false);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5934()
        {
            //  SAP-5934:FG06 - LASA - CLI ñ enviado, PARC rejeitado e CMS sucesso
            InicioTesteFG06("5934", "SAP-5934:FG06 - LASA - CLI ñ enviado, PARC rejeitado e CMS sucesso", OperadoraEnum.LASA);

            AdicionaErro(TipoArquivo.ParcEmissao);

            SalvarTrinca(false, true, true);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5935()
        {
            InicioTesteFG06("5935", "SAP-5935:FG06 - SOFTBOX - CLI ñ enviado, PARC rejeitado e CMS ñ enviado", OperadoraEnum.SOFTBOX);

            AdicionaErro(TipoArquivo.ParcEmissao);

            SalvarTrinca(false, true, false);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5936()
        {
            InicioTesteFG06("5936", "SAP-5936:FG06 - SOFTBOX - CLI ñ enviado, PARC sucesso e CMS rejeitado", OperadoraEnum.SOFTBOX);

            AdicionaErro(TipoArquivo.Comissao);

            SalvarTrinca(false, true, true);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }
    }
}
