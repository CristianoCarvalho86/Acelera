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
    public class PROC200_LAYOUT96_POMPEIA : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5635()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5635", "FG09 - PROC200 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.POMPEIA, true);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA, arquivoParcela, true);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), 1000));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5536()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5536", "FG09 - PROC200 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.POMPEIA, true, 2);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA, arquivoParcela, true);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), 1000));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5537()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5537", "FG09 - PROC200 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.POMPEIA, true, 3);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA, arquivoParcela, true);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), 1000));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5538()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5538", "FG09 - PROC200 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.POMPEIA, true, 2);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA, arquivoParcela, true);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), 0));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5539()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5539", "FG09 - PROC200 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.POMPEIA, true);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.POMPEIA, arquivoParcela, true);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), -1));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }
    }
}
