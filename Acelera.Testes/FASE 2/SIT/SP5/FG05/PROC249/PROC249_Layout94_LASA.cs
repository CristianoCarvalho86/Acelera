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
    public class PROC249_Layout94_LASA : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9471()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-9471:FG05 - PROC 249 - LASA - PARCELA - NR_ENDOSSO já processado - Parcela 3 - Msm arquivo");
            
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);
            contratoRegras.CriarNovoContrato(0,arquivo);
            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoOds = arquivo.Clone();
            LimparValidacao();

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            CriarNovaLinhaParaEmissao(arquivo);

            CriarNovaLinhaParaEmissao(arquivo, 1);
            AlterarLinha(2, "NR_ENDOSSO", arquivo[1]["NR_ENDOSSO"]);
            AlterarLinha(2, "NR_SEQUENCIAL_EMISSAO", arquivo[1]["NR_SEQUENCIAL_EMISSAO"]);
            AlterarLinha(2, "CD_ITEM", "12345");
            RemoverLinhaComAjusteDeFooter(0);
            
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "249", 1);
        }
    }
}
