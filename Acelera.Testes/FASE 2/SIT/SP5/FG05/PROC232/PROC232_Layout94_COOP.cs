using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
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
    public class PROC232_Layout94_COOP : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9308()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9319", "SAP-9308:FG05 - PROC 232 - C/C - PARCELA - ID_TRANSACAO já processado");
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);
            CriarNovoContrato(0);

            AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            EnviarParaOdsAlterandoCliente(arquivo);
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
