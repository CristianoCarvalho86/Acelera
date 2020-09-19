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

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC230
{
    [TestClass]
    public class PROC230_Layout96_COOP : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9281()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-9281:FG05 - PROC 230 - C/C - COMISSAO - Comissão já processada na ODS");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);
            contratoRegras.CriarNovoContrato(0,arquivo);
            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoParcOds = arquivo.Clone();

            arquivo = comissaoRegras.CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.COOP, arquivoParcOds,false,false);
            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoComissaoOds = arquivo.Clone();

            arquivo = comissaoRegras.CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.COOP, arquivoParcOds, false, false);
            AlterarLinha(0, "CD_ITEM", arquivo[0]["CD_ITEM"].ObterProximoValorInteiro());

            SalvarArquivo();

            ExecutarEValidarAteFg02(arquivo);

        }
    }
}
