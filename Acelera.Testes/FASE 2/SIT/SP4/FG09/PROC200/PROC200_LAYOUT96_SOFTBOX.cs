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
    public class PROC200_LAYOUT96_SOFTBOX : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5630()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5630", "FG09 - PROC200 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.SOFTBOX, true);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.SOFTBOX, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.SOFTBOX, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.SOFTBOX, arquivoParcela, true);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), 1000));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5531()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5531", "FG09 - PROC200 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.SOFTBOX, true, 2);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.SOFTBOX, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.SOFTBOX, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.SOFTBOX, arquivoParcela,true);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), 1000));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5532()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5532", "FG09 - PROC200 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.SOFTBOX, true, 3);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.SOFTBOX, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.SOFTBOX, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.SOFTBOX, arquivoParcela);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), 1000));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5533()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5533", "FG09 - PROC200 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.SOFTBOX, true, 2);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.SOFTBOX, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.SOFTBOX, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.SOFTBOX, arquivoParcela);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), 0));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5534()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5534", "FG09 - PROC200 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.SOFTBOX, true);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.SOFTBOX, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.SOFTBOX, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.SOFTBOX, arquivoParcela);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), -1));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }
    }
}
