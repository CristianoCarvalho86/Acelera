using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC249
{
    [TestClass]
    public class PROC249_Layout94_PAPCARD : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9471()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-9471:FG05 - PROC 249 - PAPCARD - PARCELA - NR_ENDOSSO já processado - Parcela 3 - Msm arquivo");
            
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(ref arquivo);
            CriarNovoContrato(0);
            AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            SalvarArquivo();

            ExecutarEValidarAteFg02(arquivo);
            var arquivoOds = arquivo.Clone();
            //LimparValidacao();

            CriarNovaLinhaParaEmissao(arquivo);

            CriarNovaLinhaParaEmissao(arquivo, 1);
            AlterarLinha(2, "NR_SEQUENCIAL_EMISSAO", arquivo[1]["NR_SEQUENCIAL_EMISSAO"]);
            RemoverLinhaComAjusteDeFooter(0);
            
            SalvarArquivo();

            ExecutarEValidarAteFg02(arquivo);
        }
    }
}
