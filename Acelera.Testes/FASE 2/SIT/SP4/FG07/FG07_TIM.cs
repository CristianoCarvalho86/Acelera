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
    public class FG07_TIM : FG07_Base
    {
        [TestMethod]
        public void SAP_6164()
        {
            IniciarTeste("6164", "SAP-6164:FG07 - Tim - Geração XML -- Capa e Emissão no msm XML - Comissão C - Novo cliente", OperadoraEnum.TIM);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[0]);

            SalvaExecutaEValidaFG07();

        }
        [TestMethod]
        public void SAP_6165()
        {
            IniciarTeste("6165", " SAP-6165:FG07 - Tim - Capa e Emissão em XML diferentes - Comissão P - Novo cliente", OperadoraEnum.TIM);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "P", dados);
            SalvaExecutaEValidaFG07(true, false);


            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            triplice.ArquivoParcEmissao.RemoverLinha(0);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[0], triplice.ArquivoComissao[0]);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_6166()
        {
            IniciarTeste("6166", "SAP-6166:FG07 - Tim - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C - Cli cadastrado", OperadoraEnum.TIM, false);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[0]);

            SalvaExecutaEValidaFG07(false);

        }

        [TestMethod]
        public void SAP_6167()
        {
            IniciarTeste("6167", "SAP-6167:FG07 - Tim - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C e P - Novo cliente", OperadoraEnum.TIM);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[0]);

            AdicionarTipoComissao(triplice.ArquivoComissao, triplice.ArquivoParcEmissao[0]["VL_PREMIO_LIQUIDO"], "P", 0);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_6168()
        {
            IniciarTeste("6168", " SAP-6168:FG07 - Tim - Geração XML Sucesso - Emissão 1a parcela - 2 cobertura - Comissão C - Novo cliente", OperadoraEnum.TIM);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[0]);

            AdicionarNovaCoberturaNaEmissao(triplice.ArquivoParcEmissao, dados, 1);

            triplice.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[2], triplice.ArquivoComissao[1]);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_6169()
        {
            IniciarTeste("6169", "SAP-6169:FG07 - Tim - Geração XML Sucesso - Emissão 1a parcela - 2 cobertura - Comissão C e P - Novo cliente", OperadoraEnum.TIM);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[0]);

            //ALTERACAO PARCELA
            AdicionarNovaCoberturaNaEmissao(triplice.ArquivoParcEmissao, dados);

            //ALTERACAO COMISSAO
            AdicionarTipoComissao(triplice.ArquivoComissao, triplice.ArquivoParcEmissao[1]["VL_PREMIO_LIQUIDO"], "P", 0);

            triplice.ArquivoComissao.ReplicarLinha(0, 2);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[2], triplice.ArquivoComissao[2]);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[2], triplice.ArquivoComissao[3]);
            triplice.ArquivoComissao.AlterarLinha(3, "CD_TIPO_COMISSAO", "P");



            SalvaExecutaEValidaFG07();
        }
        [TestMethod]
        public void SAP_6170()
        {
            IniciarTeste("6170", "SAP-6170:FG07 - Tim - Geração XML Sucesso - Emissão 2a parcela - 1 cobertura - Comissão C", OperadoraEnum.TIM);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[0]);

            SalvaExecutaEValidaFG07();

            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 1);
            triplice.ArquivoParcEmissao.RemoverLinha(0);
            triplice.ArquivoParcEmissao.RemoverLinha(1);

            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[0], triplice.ArquivoComissao[0]);

            SalvaExecutaEValidaFG07(false);
        }
        [TestMethod]
        public void SAP_6171()
        {
            IniciarTeste("6171", "Tim - Geração XML Sucesso - Emissão 2a parcela - 2 cobertura - Comissão R", OperadoraEnum.TIM);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "R", dados);
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[0]);
            AdicionarNovaCoberturaNaEmissao(triplice.ArquivoParcEmissao, dados);

            triplice.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[2], triplice.ArquivoComissao[1]);

            SalvaExecutaEValidaFG07();

            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 1);
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 2);
            triplice.ArquivoParcEmissao.RemoverLinha(0);
            triplice.ArquivoParcEmissao.RemoverLinha(1);
            triplice.ArquivoParcEmissao.RemoverLinha(2);

            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[0], triplice.ArquivoComissao[0]);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[1]);

            SalvaExecutaEValidaFG07(false);
        }
        [TestMethod]
        public void SAP_6172()
        {
            IniciarTeste("6172", "SAP-6172:FG07 - Tim - Geração XML Sucesso - Emissão 1 e 2 parcelas juntas - 1 cobertura - Comissão R", OperadoraEnum.TIM);
            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "R", dados);
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[0]);

            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 1);

            triplice.ArquivoComissao.ReplicarLinha(0, 1);

            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[0]);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[2], triplice.ArquivoComissao[1]);

            SalvaExecutaEValidaFG07();
        }
    }
}
