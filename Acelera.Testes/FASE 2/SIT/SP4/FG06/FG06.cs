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

namespace Acelera.Testes.FASE_2.SIT.SP4.FG06
{
    [TestClass]
    public class FG06 : TestesFG06
    {
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4921()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "4921", "");

            CarregarTriplice(OperadoraEnum.LASA);

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
        [TestCategory("Sem Critica")]
        public void SAP_4922()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "4922", "");

            CarregarTriplice(OperadoraEnum.LASA);

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

            ExecutarEValidarFG06(triplice, CodigoStage.RecusadoNaFG01, CodigoStage.AprovadoFG06, CodigoStage.AprovadoFG06, "41", "", "");

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4923()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "4923", "");

            CarregarTriplice(OperadoraEnum.LASA);

            AlteracoesPadraoDaTrinca(triplice);
            triplice.AlterarParcEComissao(0, "VL_COMISSAO", "a");

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

            ExecutarEValidarFG06(triplice, CodigoStage.AprovadoFG06, CodigoStage.RecusadoNaFG01, CodigoStage.AprovadoFG06, "", "07", "");

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4924()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "4924", "");

            CarregarTriplice(OperadoraEnum.LASA);

            AlteracoesPadraoDaTrinca(triplice);
            triplice.AlterarParcEComissao(0, "CD_INTERNO_RESSEGURADOR", "");

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

            ExecutarEValidarFG06(triplice, CodigoStage.AprovadoFG06, CodigoStage.AprovadoFG06, CodigoStage.AprovadoFG06, "", "", "05");

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4925()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "4925", "");

            CarregarTriplice(OperadoraEnum.LASA);

            AlteracoesPadraoDaTrinca(triplice);
            triplice.AlterarParcEComissao(0, "NR_APOLICE", "0000000000");

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
    }
}
