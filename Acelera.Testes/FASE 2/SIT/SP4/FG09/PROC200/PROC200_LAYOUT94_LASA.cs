using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC200
{
    [TestClass]
    public class PROC200_LAYOUT96_LASA : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5525()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5525", "FG09 - PROC200 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela, true);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao[0]["VL_COMISSAO"], "1000"));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5526()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5525", "FG09 - PROC200 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 2);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela, true);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao[0]["VL_COMISSAO"], "1000"));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }
    }
}
