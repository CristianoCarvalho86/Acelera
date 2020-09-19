using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC231
{
    [TestClass]
    public class PROC231_Layout94_TIM : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9305()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9305", "FG05 - PROC231 - ");
            

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            SalvarArquivo();
            //EnviarParaOdsAlterandoCliente(arquivo);

            arquivo = comissaoRegras.CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.TIM, arquivo);

            AlterarLinha(0, "VL_COMISSAO", "100");

            SalvarArquivo();

           // ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "231", 1);
        }


        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9306()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9306", "FG05 - PROC231 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.TIM);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);
            CriarNovaLinhaParaEmissao(arquivoods1, 0);

            EnviarParaOdsAlterandoCliente(arquivoods1);

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.TIM);

            arquivo = comissaoRegras.CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.TIM, arquivoods1);

            AlterarLinha(0, "VL_COMISSAO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9307()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9307", "FG05 - PROC231 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.TIM);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);

            EnviarParaOdsAlterandoCliente(arquivoods1);

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.TIM);

            arquivo = comissaoRegras.CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.TIM, arquivoods1);

            AlterarLinha(0, "VL_COMISSAO", "0");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

    }
}
