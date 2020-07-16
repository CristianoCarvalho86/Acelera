using Acelera.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG07
{
    [TestClass]
    public class FG07_TIM: FG07_Base
    {
        [TestMethod]
        public void SAP_6164()
        {
            InicioTesteFG07("6164", "SAP-6164:FG07 - Tim - Geração XML -- Capa e Emissão no msm XML - Comissão C - Novo cliente", OperadoraEnum.TIM);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[0]);

            SalvaExecutaEValidaFG07();

        }
        [TestMethod]
        public void SAP_6165()
        {
            InicioTesteFG07("6165", " SAP-6165:FG07 - Tim - Capa e Emissão em XML diferentes - Comissão P - Novo cliente", OperadoraEnum.TIM);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "P", dados);
            SalvaExecutaEValidaFG07(true,false);


            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            triplice.ArquivoParcEmissao.RemoverLinha(0);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[0], triplice.ArquivoComissao[0]);
            
            SalvaExecutaEValidaFG07(false);

        }

        [TestMethod]
        public void SAP_6166()
        {
            InicioTesteFG07("6166", "SAP-6166:FG07 - Tim - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C - Cli cadastrado", OperadoraEnum.TIM);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[0]);

            SalvaExecutaEValidaFG07(false);

        }

    }
}
