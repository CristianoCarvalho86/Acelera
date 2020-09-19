using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC232
{
    [TestClass]
    public class PROC232_Layout96_PAPCARD : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9310()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9319", "SAP-9310:FG05 - PROC 232 - C/C - PAPCARD - PARCELA - ID_TRANSACAO já processado");
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(ref arquivo);
            contratoRegras.CriarNovoContrato(0,arquivo);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            SalvarArquivo();
            //EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods1 = arquivo.Clone();

            CriarNovaLinhaParaEmissao(arquivo, 0);
            RemoverLinhaComAjusteDeFooter(0);
            AlterarLinha(0, "NR_PARCELA", arquivoods1[0]["NR_PARCELA"]);
            AlterarLinha(0, "NR_PARCELA", arquivoods1[0]["NR_PARCELA"]);

            SalvarArquivo();

            ExecutarEValidarAteFg02(arquivo);
        }

    }
}
