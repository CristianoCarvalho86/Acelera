using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC22
{
    [TestClass]
    public class PROC216_Layout93_VIVO : TestesFG05
    {

        /// <summary>
        /// Em 1 arquivo PARC, informar valor
        /// total do prêmio total da cobertura. Este arquivo deve estar na ODS. 
        /// Em outro arquivo COMISSAO, após o PARC estar na STAGE, 
        /// informar apenas uma linha com este contrato e cobertura, 
        /// sendo o VL_COMISSAO superior ao VL_PREMIO_TOTAL do arquivo PARC
        /// </summary>
        [TestMethod]
        [TestCategory("Comm Critica")]
        public void SAP_4567()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4567", "FG05 - PROC216");

            //Carregar arquivo ods
            var arquivoods = new Arquivo_Layout_9_3_ParcEmissao();
            CarregarArquivo(arquivoods ,1 , OperadoraEnum.VIVO);
            arquivoods.AlterarLinha(0, "VL_PREMIO_TOTAL", "100");
            EnviarParaOds(arquivoods);

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO","CD_COBERTURA"};
            IgualarCampos(arquivoods, arquivo, campos);
            AlterarLinha(0, "VL_COMISSAO", "110");

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "216", 1);
        }

    }
}
