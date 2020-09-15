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
    public class FG08_LASA : TestesFG08
    {
        private FG07_LASA testeFG07;

        public FG08_LASA()
        {
            testeFG07 = new FG07_LASA();
        }

        [TestMethod]
        public void SAP_9867()
        {
            IniciarTesteFG08("6162", "SAP-6162:FG07 - Lasa - Geração XML Sucesso - Emissão 1 e 2 parcelas juntas - 1 cobertura - Comissão P", OperadoraEnum.POMPEIA);

            DeletarRegistrosAntigosDaStage();

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "P", dados);

            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);

            triplice.ArquivoComissao.ReplicarLinha(0, 1);

            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[0], triplice.ArquivoComissao[0]);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[1]);

            SalvaExecutaEValidaFG07();

            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9865()
        {
            IniciarTesteFG08("6160", "SAP-6160:FG07 - Lasa - Geração XML Sucesso - Emissão 2a parcela - 1 cobertura - Comissão C", OperadoraEnum.POMPEIA, false);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);

            SalvaExecutaEValidaFG07();

            LimparValidacao();

            EnviarParaOds(triplice.ArquivoCliente, false, false, CodigoStage.AprovadoFG07);

            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao);
            triplice.ArquivoParcEmissao.RemoverLinhaComAjuste(0);

            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[0], triplice.ArquivoComissao[0]);

            SalvaExecutaEValidaFG07(false);
            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9866()
        {
            //NAO ENCONTROU NEHUM CORRETOR COM R
            IniciarTesteFG08("9866", "SAP-6161:FG07 - Lasa - Geração XML Sucesso - Emissão 2a parcela - 2 cobertura - Comissão R", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "R", dados);
            AdicionarNovaCoberturaNaEmissao(triplice.ArquivoParcEmissao, dados);

            triplice.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[1]);

            SalvaExecutaEValidaFG07();

            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 1);
            triplice.ArquivoParcEmissao.RemoverLinha(0);
            triplice.ArquivoParcEmissao.RemoverLinha(1);

            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[0], triplice.ArquivoComissao[0]);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[1]);

            SalvaExecutaEValidaFG07(false);
            ExecutarEValidarFG08(true);
        }
        [TestMethod]
        public void SAP_9864()
        {
            IniciarTesteFG08("9864", "SAP-6159:FG07 - Lasa - Geração XML Sucesso - Emissão 1a parcela - 2 cobertura - Comissão C e P - Novo cliente", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados); //COLOCAR CD_CORRETOR com C e P,

            //ALTERACAO PARCELA
            AdicionarNovaCoberturaNaEmissao(triplice.ArquivoParcEmissao, dados);

            //ALTERACAO COMISSAO

            triplice.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[1]);

            AdicionarTipoComissao(triplice.ArquivoComissao, triplice.ArquivoParcEmissao[0]["VL_PREMIO_LIQUIDO"], "P", 1);

            triplice.ArquivoComissao.RemoverLinhaComAjuste(0);
            triplice.ArquivoComissao.RemoverLinhaComAjuste(0);

            SalvaExecutaEValidaFG07();
            ExecutarEValidarFG08(true);
        }
        [TestMethod]
        public void SAP_9863()
        {
            IniciarTesteFG08("9863", " SAP-6158:FG07 - Lasa - Geração XML Sucesso - Emissão 1a parcela - 2 cobertura - Comissão C - Novo cliente", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);

            triplice.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201010");

            AdicionarNovaCoberturaNaEmissao(triplice.ArquivoParcEmissao, dados, 0);

            triplice.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[1]);

            SalvaExecutaEValidaFG07();
            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9862()
        {
            IniciarTesteFG08("9862", "9862 : SAP-6157:FG07 - Lasa - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C e P - Novo cliente", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);

            AdicionarTipoComissao(triplice.ArquivoComissao, triplice.ArquivoParcEmissao[0]["VL_PREMIO_LIQUIDO"], "P", 0);

            triplice.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201010");

            SalvaExecutaEValidaFG07();
            
            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9861()
        {
            numeroDoTeste = "9861";
            testeFG07.SAP_6156();
            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9860()
        {
            IniciarTesteFG08("9860", "FG08: 9860 - SAP-6155:FG07 - Lasa - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão P - Novo cliente", OperadoraEnum.LASA);


            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "P", dados);

            triplice.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201010");

            SalvaExecutaEValidaFG07();
            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9859()
        {
            IniciarTesteFG08("9859", "6154 - FG07 - Lasa - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C - Novo cliente", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);

            triplice.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201010");

            SalvaExecutaEValidaFG07();
            ExecutarEValidarFG08(true);
        }

        [TestMethod]
        public void SAP_9858()
        {
            //nao da pra rodar para LASA
            IniciarTesteFG08("9858", "9762 - FG07 - Lasa - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C - Novo cliente", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);

            triplice.AlterarParcEComissao(0, "VL_PREMIO_TOTAL", "0");
            triplice.AlterarParcEComissao(0, "VL_PREMIO_LIQUIDO", "0");
            triplice.AlterarParcEComissao(0, "VL_IOF", "0");

            triplice.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201010");

            SalvaExecutaEValidaFG07();

            ExecutarEValidarFG08(true);
        }
    }
}
