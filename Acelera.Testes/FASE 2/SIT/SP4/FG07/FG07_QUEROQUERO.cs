﻿using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG07
{
    [TestClass]
    public class FG07_QUEROQUERO : FG07_Base
    {
        protected string ClienteCadastradoNoOIM => throw new Exception();

        [TestMethod]
        public void SAP_6154()
        {
            IniciarTesteFG07("6154", "FG07 - QUEROQUERO - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C - Novo cliente", OperadoraEnum.QUEROQUERO);
            
            AlterarCdCorretorETipoComissaoDaTrinca(trinca,"C",dados);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_6155()
        {
            IniciarTesteFG07("6155", "SAP-6155:FG07 - QUEROQUERO - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão P - Novo cliente", OperadoraEnum.QUEROQUERO);


            AlterarCdCorretorETipoComissaoDaTrinca(trinca, "P", dados);

            SalvaExecutaEValidaFG07();

        }
        [TestMethod]
        public void SAP_6156()
        {
            IniciarTesteFG07("6156", "SAP-6156:FG07 - QUEROQUERO - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C - Cli cadastrado", OperadoraEnum.QUEROQUERO);

            AlterarCdCorretorETipoComissaoDaTrinca(trinca, "C", dados);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_6157()
        {
            IniciarTesteFG07("6157", "SAP-6157:FG07 - QUEROQUERO - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C e P - Novo cliente", OperadoraEnum.QUEROQUERO);

            AlterarCdCorretorETipoComissaoDaTrinca(trinca, "C", dados);

            AdicionarTipoComissao(trinca.ArquivoComissao,trinca.ArquivoParcEmissao[0]["VL_PREMIO_LIQUIDO"],"P",0);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_6158()
        {
            IniciarTesteFG07("6158", " SAP-6158:FG07 - QUEROQUERO - Geração XML Sucesso - Emissão 1a parcela - 2 cobertura - Comissão C - Novo cliente", OperadoraEnum.QUEROQUERO);

            AlterarCdCorretorETipoComissaoDaTrinca(trinca, "C", dados);

            emissaoRegras.AdicionarNovaCoberturaNaEmissao(trinca.ArquivoParcEmissao, dados, 0);
            
            trinca.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao[1], trinca.ArquivoComissao[1]);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_6159()
        {

            IniciarTesteFG07("6159", "SAP-6159:FG07 - QUEROQUERO - Geração XML Sucesso - Emissão 1a parcela - 2 cobertura - Comissão C e P - Novo cliente", OperadoraEnum.QUEROQUERO);

            AlterarCdCorretorETipoComissaoDaTrinca(trinca, "C", dados); //COLOCAR CD_CORRETOR com C e P,

            //ALTERACAO PARCELA
            emissaoRegras.AdicionarNovaCoberturaNaEmissao(trinca.ArquivoParcEmissao,dados);

            //ALTERACAO COMISSAO

            trinca.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao[1], trinca.ArquivoComissao[1]);

            AdicionarTipoComissao(trinca.ArquivoComissao, trinca.ArquivoParcEmissao[0]["VL_PREMIO_LIQUIDO"], "P", 1);

            trinca.ArquivoComissao.RemoverLinhaComAjuste(0);
            trinca.ArquivoComissao.RemoverLinhaComAjuste(0);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_6160()
        {
            //?
            IniciarTesteFG07("6160", "SAP-6160:FG07 - QUEROQUERO - Geração XML Sucesso - Emissão 2a parcela - 1 cobertura - Comissão C", OperadoraEnum.POMPEIA, false);

            AlterarCdCorretorETipoComissaoDaTrinca(trinca, "C", dados);

            SalvaExecutaEValidaFG07();

            LimparValidacao();

            EnviarParaOds(trinca.ArquivoCliente, false, false,CodigoStage.AprovadoFG07);

            CriarNovaLinhaParaEmissao(trinca.ArquivoParcEmissao);
            trinca.ArquivoParcEmissao.RemoverLinhaComAjuste(0);
            
            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao[0], trinca.ArquivoComissao[0]);

            SalvaExecutaEValidaFG07(false);
        }

        [TestMethod]
        public void SAP_6161()
        {
            IniciarTesteFG07("6161", "SAP-6161:FG07 - QUEROQUERO - Geração XML Sucesso - Emissão 2a parcela - 2 cobertura - Comissão R", OperadoraEnum.QUEROQUERO);

            AlterarCdCorretorETipoComissaoDaTrinca(trinca, "R", dados);
            emissaoRegras.AdicionarNovaCoberturaNaEmissao(trinca.ArquivoParcEmissao, dados);
            
            trinca.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao[1], trinca.ArquivoComissao[1]);

            SalvaExecutaEValidaFG07();

            CriarNovaLinhaParaEmissao(trinca.ArquivoParcEmissao,0);
            CriarNovaLinhaParaEmissao(trinca.ArquivoParcEmissao, 1);
            trinca.ArquivoParcEmissao.RemoverLinha(0);
            trinca.ArquivoParcEmissao.RemoverLinha(1);

            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao[0], trinca.ArquivoComissao[0]);
            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao[1], trinca.ArquivoComissao[1]);

            SalvaExecutaEValidaFG07(false);

        }

        [TestMethod]
        public void SAP_6162()
        {

            IniciarTesteFG07("6162", "SAP-6162:FG07 - QUEROQUERO - Geração XML Sucesso - Emissão 1 e 2 parcelas juntas - 1 cobertura - Comissão P", OperadoraEnum.QUEROQUERO);

            AlterarCdCorretorETipoComissaoDaTrinca(trinca, "P", dados);
              
            CriarNovaLinhaParaEmissao(trinca.ArquivoParcEmissao, 0);

            trinca.ArquivoComissao.ReplicarLinha(0, 1);

            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao[0], trinca.ArquivoComissao[0]);
            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao[1], trinca.ArquivoComissao[1]);

            SalvaExecutaEValidaFG07();

        }

    }
}
