using Acelera.Data;
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
    public class PROC235_Layout96_COOP : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9368()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9368", "SAP-9368:FG05 - PROC 235 - C/C - PARCELA - Ramo da comissão diferente do ramo da parcela");
            //Envia parc normal
            AlterarCobertura(false);
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            contratoRegras.CriarNovoContrato(0,arquivo);

            //SetDev();

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            //SetQA();

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoparc = arquivo.Clone();

            //SetDev();
            arquivo = comissaoRegras.CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.COOP, arquivoparc);
            AlterarHeader("VERSAO", "9.6");

            AlterarLinha(0, "CD_RAMO",  dados.ObterRamoRelacionadoACoberturaDiferenteDe(arquivo[0]["CD_COBERTURA"], arquivo[0]["CD_RAMO"], out string produto));

            SalvarArquivo();

            //SetQA();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "235", 1);
        }
    }
}
