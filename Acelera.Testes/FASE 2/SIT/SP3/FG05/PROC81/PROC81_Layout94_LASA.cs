using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC81
{
    [TestClass]
    public class PROC81_Layout94_LASA : TestesFG05
    {

        /// <summary>
        /// Enviar primeiro arquivo PARC para a ODS com DT_INICIO_VIGENCIA e DT_FIM VIGENCIA. 
        /// Após registro gravado, enviar outro arquivo SINISTRO cuja DT_OCORRENCIA seja inferior a DT_INICIO_VIGENCIA da apólice (do 1o arquivo)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4457()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4457", "FG02 - PROC1002 - ");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "DT_INICIO_VIGENCIA", "20200101");
            AlterarLinha(0, "DT_FIM_VIGENCIA", "20210101");

            EnviarParaOds(arquivo, true, "PROC81");
            var arquivoods = arquivo.Clone();

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE" });
            AlterarLinha(0, "DT_OCORRENCIA", "20191201");

            SalvarArquivo(true, "PROC81");

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "81", 1);
        }

        /// <summary>
        /// Enviar primeiro arquivo PARC para a ODS com DT_INICIO_VIGENCIA e DT_FIM VIGENCIA. 
        /// Após registro gravado, enviar outro arquivo SINISTRO cuja DT_OCORRENCIA seja Superior a DT_FIM_VIGENCIA da apólice (do 1o arquivo)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4458()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4458", "FG02 - PROC1002 - ");

            var arquivoods = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.LASA);

            arquivoods.AlterarLinha(0, "DT_INICIO_VIGENCIA", "20200101");
            arquivoods.AlterarLinha(0, "DT_FIM_VIGENCIA", "20210101");

            EnviarParaOds(arquivoods);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE" });
            AlterarLinha(0, "DT_OCORRENCIA", "20210201");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "81", 1);
        }

        /// <summary>
        /// Enviar primeiro arquivo PARC para a ODS com DT_INICIO_VIGENCIA e DT_FIM VIGENCIA. 
        /// Após registro gravado, enviar outro arquivo SINISTRO cuja DT_OCORRENCIA seja inferior a DT_INICIO_VIGENCIA da apólice (do 1o arquivo)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4459()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4459", "FG02 - PROC1002 - ");

            var arquivoods = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.LASA);

            arquivoods.AlterarLinha(0, "DT_INICIO_VIGENCIA", "20200101");
            arquivoods.AlterarLinha(0, "DT_FIM_VIGENCIA", "20210101");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE" });
            AlterarLinha(0, "DT_OCORRENCIA", "20191201");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "81", 1);
        }


        /// <summary>
        /// Enviar primeiro arquivo PARC para a ODS com DT_INICIO_VIGENCIA e DT_FIM VIGENCIA. 
        /// Após registro gravado, enviar outro arquivo SINISTRO cuja DT_OCORRENCIA seja inferior a DT_INICIO_VIGENCIA da apólice (do 1o arquivo)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4460()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4460", "FG02 - PROC1002 - ");

            var arquivoods = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.LASA);

            arquivoods.AlterarLinha(0, "DT_INICIO_VIGENCIA", "20200101");
            arquivoods.AlterarLinha(0, "DT_FIM_VIGENCIA", "20210101");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE" });
            AlterarLinha(0, "DT_OCORRENCIA", "20210201");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "81", 1);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4461()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4461", "FG02 - PROC1002 - ");

            var arquivoods = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.LASA);

            arquivoods.AlterarLinha(0, "DT_INICIO_VIGENCIA", "20200101");
            arquivoods.AlterarLinha(0, "DT_FIM_VIGENCIA", "20210101");

            EnviarParaOds(arquivoods);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE" });
            AlterarLinha(0, "DT_OCORRENCIA", "20200201");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4462()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4462", "FG02 - PROC1002 - ");

            var arquivoods = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.LASA);

            arquivoods.AlterarLinha(0, "DT_INICIO_VIGENCIA", "20200101");
            arquivoods.AlterarLinha(0, "DT_FIM_VIGENCIA", "20210101");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCampos(arquivoods, arquivo, new string[] { "CD_CONTRATO", "NR_APOLICE" });
            AlterarLinha(0, "DT_OCORRENCIA", "20200201");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

    }
}
