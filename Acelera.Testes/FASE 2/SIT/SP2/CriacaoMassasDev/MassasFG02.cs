using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Acelera.Testes.FASE_2.SIT.SP2.CriaçãoMassasDev
{
    [TestClass]
    public class MassasFG02 : TestesFG01
    {
        /// <summary>
        /// 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO com DT_FIM_VIGENCIA Maior que DT_INICIO_VIGENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC11()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "PROC11", "FG02 - PROC11 - 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO com DT_FIM_VIGENCIA Maior que DT_INICIO_VIGENCIA");
            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData(ObterValor(1, "DT_INICIO_VIGENCIA"), 1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT");
        }
    }
}
