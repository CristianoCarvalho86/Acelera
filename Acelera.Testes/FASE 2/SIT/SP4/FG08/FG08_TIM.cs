using Acelera.Domain.Enums;
using Acelera.Logger;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.FASE_2.SIT.SP4.FG07;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG08
{
    [TestClass]
    public class FG08_TIM : TestesFG08
    {
        private FG07_TIM testeFG07;

        public FG08_TIM()
        {
            testeFG07 = new FG07_TIM();
        }

        [TestMethod]
        public void SAP_9888()
        {
            IniciarTesteFG08("9888", "SAP-6164:FG07 - Tim - Geração XML -- Capa e Emissão no msm XML - Comissão C - Novo cliente", OperadoraEnum.TIM, true, false);

            AlterarCdCorretorETipoComissaoDaTrinca(trinca, "C", dados);
            trinca.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201010");

            SalvaExecutaEValidaFG07();

            ExecutarEValidarFG08(true);
        }



        [TestMethod]
        public void SAP_9889()
        {
            IniciarTesteFG08("9889"," SAP-6165:FG07 - Tim - Capa e Emissão em XML diferentes - Comissão P - Novo cliente", OperadoraEnum.TIM, true, false);

            AlterarCdCorretorETipoComissaoDaTrinca(trinca, "P", dados);


            SalvaExecutaEValidaFG07();

            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9890()
        {
            //nao rodar
            IniciarTesteFG08("9890", " SAP-6165:FG07 - Tim - Capa e Emissão em XML diferentes - Comissão P - Novo cliente", OperadoraEnum.TIM, true, false);

            testeFG07.SAP_6166();

            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9891()
        {
            IniciarTesteFG08("9891", "SAP-6167:FG07 - Tim - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C e P - Novo cliente", OperadoraEnum.TIM, true, true);

            AlterarCdCorretorETipoComissaoDaTrinca(trinca, "C", dados);

            AdicionarTipoComissao(trinca.ArquivoComissao, trinca.ArquivoParcEmissao[0]["VL_PREMIO_LIQUIDO"], "P", 0);

            trinca.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201010");

            SalvaExecutaEValidaFG07();

            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9892()
        {
            IniciarTesteFG08("9892", "SAP-6168:FG07 - Tim - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C e P - Novo cliente", OperadoraEnum.TIM, true, false);

            testeFG07.SAP_6168();//erro de coberturas

            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9893()
        {
            IniciarTesteFG08("9893", "SAP-6169:FG07 - Tim - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C e P - Novo cliente", OperadoraEnum.TIM, true, false);

            testeFG07.SAP_6168();//erro de coberturas

            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9894()
        {
            IniciarTesteFG08("9894", "SAP-6170:FG07 - Tim - Geração XML Sucesso - Emissão 2a parcela - 1 cobertura - Comissão C", OperadoraEnum.TIM);

            AlterarCdCorretorETipoComissaoDaTrinca(trinca, "C", dados);

            trinca.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201010");

            CriarNovaLinhaParaEmissao(trinca.ArquivoParcEmissao, 0);

            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao[1], trinca.ArquivoComissao[0]);

            SalvaExecutaEValidaFG07();

            ExecutarEValidarFG08(true);

            DeletarRegistrosAntigosDaStage();

            CriarNovaLinhaParaEmissao(trinca.ArquivoParcEmissao, 1);
            trinca.ArquivoParcEmissao.RemoverLinha(0);
            trinca.ArquivoParcEmissao.RemoverLinha(1);

            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao[0], trinca.ArquivoComissao[0]);

            SalvaExecutaEValidaFG07(false);

            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9896()
        {
            IniciarTesteFG08("9896", "SAP-6172:FG07 - Tim - Geração XML Sucesso - Emissão 1 e 2 parcelas juntas - 1 cobertura - Comissão R", OperadoraEnum.TIM,true, true);

            AlterarCdCorretorETipoComissaoDaTrinca(trinca, "P", dados);
            trinca.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201010");

            CriarNovaLinhaParaEmissao(trinca.ArquivoParcEmissao, 1);

            trinca.ArquivoComissao.ReplicarLinha(0, 1);

            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao[0], trinca.ArquivoComissao[0]);
            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao[1], trinca.ArquivoComissao[1]);

            SalvaExecutaEValidaFG07();

            ExecutarEValidarFG08(true);
        }

    }
}
