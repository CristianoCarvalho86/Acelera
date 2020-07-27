using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC46
{
    [TestClass]
    public class PROC46_Layout94_PAPCARD : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9180()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9180", "FG05 - PROC46 - ");
            

            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);

            EnviarParaOds(arquivoods1);

            CriarNovaLinhaParaEmissao(arquivoods1);
            RemoverLinha(0);
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9181()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9181", "FG05 - PROC46 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            EnviarParaOds(arquivoods1);

            CriarNovaLinhaParaEmissao(arquivoods1);
            RemoverLinha(0);
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "7");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9182()
        {
            IniciarTeste(TipoArquivo.Comissao, "9182", "FG05 - PROC46 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            EnviarParaOds(arquivoods1);

            CriarNovaLinhaParaEmissao(arquivoods1);
            RemoverLinha(0);
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9183()
        {
            IniciarTeste(TipoArquivo.Comissao, "9183", "FG05 - PROC46 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            EnviarParaOds(arquivoods1);

            CriarNovaLinhaParaEmissao(arquivoods1);
            RemoverLinha(0);
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "7");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9184()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9184", "FG05 - PROC46 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            EnviarParaOds(arquivoods1);

            CriarNovaLinhaParaEmissao(arquivoods1);
            RemoverLinha(0);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9185()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9185", "FG05 - PROC46 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9186()
        {
            IniciarTeste(TipoArquivo.Comissao, "9186", "FG05 - PROC46 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            EnviarParaOds(arquivoods1);

            CriarNovaLinhaParaEmissao(arquivoods1);
            RemoverLinha(0);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9187()
        {
            IniciarTeste(TipoArquivo.Comissao, "9187", "FG05 - PROC46 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }
    }
}
