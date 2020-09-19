using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC235
{
    [TestClass]
    public class PROC235_Layout96_PAPCARD : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9372()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9368", "SAP-9368:FG05 - PROC 235 - C/C - PARCELA - Ramo da comissão diferente do ramo da parcela");
            //Envia parc normal
            AlterarCobertura(false);
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(ref arquivo);
            contratoRegras.CriarNovoContrato(0,arquivo);

            var cobertura = dados.ObterCobertura(arquivo.Header[0]["CD_TPA"], 0, true);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoparc = arquivo.Clone();

            arquivo = comissaoRegras.CriarComissao<Arquivo_Layout_9_4_2_new_EmsComissao>(OperadoraEnum.COOP, arquivoparc);
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_EmsComissao>(ref arquivo);

            AlterarLinha(0, "CD_RAMO", dados.ObterRamoRelacionadoACoberturaDiferenteDe(arquivo[0]["CD_COBERTURA"], arquivo[0]["CD_RAMO"], out string produto));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "235", 1);
        }

    }
}
