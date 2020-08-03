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
    public class PROC200_LAYOUT96_VIVO : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5620()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5620", "FG09 - PROC200 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissaoAuto>(OperadoraEnum.VIVO, true);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.VIVO, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.VIVO, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "222", 1);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.VIVO, arquivoParcela, "9.6");
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), 1000));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "200", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5621()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5621", "FG09 - PROC200 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissaoAuto>(OperadoraEnum.VIVO, true, 2);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.VIVO, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.VIVO, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.VIVO, arquivoParcela, true);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), 1000));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5522()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5522", "FG09 - PROC200 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissaoAuto>(OperadoraEnum.VIVO, true, 3);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.VIVO, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.VIVO, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.VIVO, arquivoParcela, true);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), 1000));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5523()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5528", "FG09 - PROC200 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissaoAuto>(OperadoraEnum.VIVO, true, 2);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.VIVO, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.VIVO, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.VIVO, arquivoParcela, true);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), 0));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5524()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5529", "FG09 - PROC200 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissaoAuto>(OperadoraEnum.VIVO, true);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.VIVO, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.VIVO, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.VIVO, arquivoParcela, "9.6");
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), -1));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }
    }
}
