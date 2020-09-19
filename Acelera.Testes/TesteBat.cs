using Acelera.Domain;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Testes.FASE_2.SIT.SP4.FG06;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    [TestClass]
    public class TesteBat : FG06_Base
    {
        [TestMethod]
        public void SAP_9999_TESTEBAT_CLIENTE()
        {
            IniciarTeste(TipoArquivo.Cliente, "9999", "TESTE DA BAT");
            var _arquivoCliente = new Arquivo_Layout_9_4_Cliente();
            CarregarArquivo(_arquivoCliente, 1, Domain.Enums.OperadoraEnum.LASA);
            SalvarArquivo(_arquivoCliente);
            ExecutarEValidarBatch(_arquivoCliente, Parametros.PastaBatDia + BatEnumDia.Cliente.ObterTexto(), CodigoStage.AprovadoNaFG01_2);
            ValidarTeste();
        }

        [TestMethod]
        public void SAP_9999_TESTEBAT_PARC()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9999", "TESTE DA BAT");
            var _arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(_arquivo, 1, Domain.Enums.OperadoraEnum.LASA);
            SalvarArquivo(_arquivo);
            ExecutarEValidarBatch(_arquivo, Parametros.PastaBatDia + BatEnumDia.ParcEmissao.ObterTexto(), CodigoStage.AprovadoNaFG01_2);
            ValidarTeste();
        }

        [TestMethod]
        public void SAP_9999_TESTEBAT_PARC_AUTO()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "9999", "TESTE DA BAT");
            var _arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            CarregarArquivo(_arquivo, 1, Domain.Enums.OperadoraEnum.VIVO);
            SalvarArquivo(_arquivo);
            ExecutarEValidarBatch(_arquivo, Parametros.PastaBatDia + BatEnumDia.ParcEmissaoAuto.ObterTexto(), CodigoStage.AprovadoNaFG01_2);
            ValidarTeste();
        }

        [TestMethod]
        public void SAP_9999_TESTEBAT_COMISSAO()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "9999", "TESTE DA BAT");
            var _arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(_arquivo, 1, Domain.Enums.OperadoraEnum.LASA);
            SalvarArquivo(_arquivo);
            ExecutarEValidarBatch(_arquivo, Parametros.PastaBatDia + BatEnumDia.Comissao.ObterTexto(), CodigoStage.AprovadoNaFG01_2);
            ValidarTeste();
        }

        [TestMethod]
        public void SAP_9999_TESTEBAT_COBRANCA()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "9999", "TESTE DA BAT");
            var _arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(_arquivo, 1, Domain.Enums.OperadoraEnum.LASA);
            SalvarArquivo(_arquivo);
            ExecutarEValidarBatch(_arquivo, Parametros.PastaBatDia + BatEnumDia.OCRCobranca.ObterTexto(), CodigoStage.AprovadoNaFG01_2);
            ValidarTeste();
        }

        [TestMethod]
        public void SAP_9999_TESTEBAT_SINISTRO()
        {
            var _arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(_arquivo, 1, Domain.Enums.OperadoraEnum.LASA);
            SalvarArquivo(_arquivo);
            ExecutarEValidarBatch(_arquivo, Parametros.PastaBatDia + BatEnumDia.Sinistro.ObterTexto(), CodigoStage.AprovadoNaFG01_2);
        }

        [TestMethod]
        public void SAP_9999_TESTEBAT_LANCTO()
        {
            var _arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            CarregarArquivo(_arquivo, 1, Domain.Enums.OperadoraEnum.LASA);
            SalvarArquivo(_arquivo);
            ExecutarEValidarBatch(_arquivo, Parametros.PastaBatDia + BatEnumDia.LanctoComissao.ObterTexto(), CodigoStage.AprovadoNaFG01_2);
        }
    }
}
