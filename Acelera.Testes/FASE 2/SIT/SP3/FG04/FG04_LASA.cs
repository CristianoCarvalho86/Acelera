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
    public class Clientesods : TestesFG04
    {
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4830()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "", "");

            CarregarTriplice(OperadoraEnum.LASA);

            triplice.AlterarParcEComissao(0, "CD_CONTRATO", AlterarUltimasPosicoes(triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            triplice.AlterarParcEComissao(0, "NR_APOLICE", triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            triplice.AlterarParcEComissao(0, "NR_PROPOSTA", triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));

            triplice.Salvar();

            ValidarFlComissaoCalculada(triplice.ArquivoComissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado, "S");

            ExecutarEValidarTriplice(FGs.FG00, CodigoStage.AprovadoNAFG00, CodigoStage.AprovadoNAFG00, null);

            ExecutarEValidarTriplice(FGs.FG01, CodigoStage.AprovadoNaFG01, CodigoStage.AprovadoNaFG01, null);

            ExecutarEValidarFG04Comissao(ObterValorFormatado(0, "CD_CONTRATO"), CodigoStage.AprovadoNAFG00, OperadoraEnum.LASA);

            ValidarVlComissaoNaStage(
                triplice.ArquivoParcEmissao.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado,
                triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_SUCURSAL"),
                triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_COBERTURA"),
                triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_PRODUTO"));

            ValidarStageComissaoComParcela();

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

        }

    }
}
