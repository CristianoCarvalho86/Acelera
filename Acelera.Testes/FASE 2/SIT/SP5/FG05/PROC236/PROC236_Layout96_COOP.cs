using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC236
{
    [TestClass]
    public class PROC236_Layout96_COOP : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9383()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9383", "SAP-9368:FG05 - PROC 236 - C/C - PARCELA - Contrato com registro rejeitado - Mesmo arquivo");
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            AlterarHeader("VERSAO", "9.6");
            contratoRegras.CriarNovoContrato(0,arquivo);
            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            emissaoRegras.AdicionarNovaCoberturaNaEmissao(arquivo, dados);

            AlterarLinha(1, "DT_INICIO_VIGENCIA", SomarData(arquivo[0]["DT_INICIO_VIGENCIA"], 30));
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData(arquivo[0]["DT_FIM_VIGENCIA"], 30));
            AlterarCobertura(false);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "236", 1);
        }
    }
}
