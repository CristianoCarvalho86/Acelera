﻿using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG07
{
    [TestClass]
    public class FG07_PITZI : FG07_Base
    {
        protected string ClienteCadastradoNoOIM => throw new Exception();

        [TestMethod]
        public void SAP_6154()
        {
            IniciarTeste("6164", "SAP-6164:FG07 - Tim - Geração XML -- Capa e Emissão no msm XML - Comissão C - Novo cliente", OperadoraEnum.PITZI);

            triplice.AlterarLayoutDaTrinca<Arquivo_Layout_9_6_Cliente, Arquivo_Layout_9_6_ParcEmissao, Arquivo_Layout_9_6_EmsComissao>();

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_6155()
        {
            IniciarTeste("6155", "SAP-6155:FG07 - PITZI - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão P - Novo cliente", OperadoraEnum.PITZI);


            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "P", dados);

            SalvaExecutaEValidaFG07();

        }
        [TestMethod]
        public void SAP_6156()
        {
            IniciarTeste("6156", "SAP-6156:FG07 - PITZI - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C - Cli cadastrado", OperadoraEnum.PITZI, false);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);

            triplice.AlterarCliente(0, "CD_CLIENTE", ClienteCadastradoNoOIM);

            SalvaExecutaEValidaFG07(false);

        }

        [TestMethod]
        public void SAP_6157()
        {
            IniciarTeste("6157", "SAP-6157:FG07 - PITZI - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C e P - Novo cliente", OperadoraEnum.PITZI);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);

            AdicionarTipoComissao(triplice.ArquivoComissao, triplice.ArquivoParcEmissao[0]["VL_PREMIO_LIQUIDO"], "P", 0);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_6158()
        {
            IniciarTeste("6158", " SAP-6158:FG07 - PITZI - Geração XML Sucesso - Emissão 1a parcela - 2 cobertura - Comissão C - Novo cliente", OperadoraEnum.PITZI);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);

            AdicionarNovaCoberturaNaEmissao(triplice.ArquivoParcEmissao, dados, 0);

            triplice.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[1]);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_6159()
        {

            IniciarTeste("6159", "SAP-6159:FG07 - PITZI - Geração XML Sucesso - Emissão 1a parcela - 2 cobertura - Comissão C e P - Novo cliente", OperadoraEnum.PITZI);

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

        }

        [TestMethod]
        public void SAP_6160()
        {
            //?
            IniciarTeste("6160", "SAP-6160:FG07 - PITZI - Geração XML Sucesso - Emissão 2a parcela - 1 cobertura - Comissão C", OperadoraEnum.POMPEIA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);

            SalvaExecutaEValidaFG07();

            LimparValidacao();

            EnviarParaOds(triplice.ArquivoCliente, false, false, CodigoStage.AprovadoFG07);

            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao);
            triplice.ArquivoParcEmissao.RemoverLinhaComAjuste(0);

            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[0], triplice.ArquivoComissao[0]);

            SalvaExecutaEValidaFG07(false);
        }

        [TestMethod]
        public void SAP_6161()
        {
            IniciarTeste("6161", "SAP-6161:FG07 - PITZI - Geração XML Sucesso - Emissão 2a parcela - 2 cobertura - Comissão R", OperadoraEnum.PITZI);

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

        }

        [TestMethod]
        public void SAP_6162()
        {

            IniciarTeste("6162", "SAP-6162:FG07 - PITZI - Geração XML Sucesso - Emissão 1 e 2 parcelas juntas - 1 cobertura - Comissão P", OperadoraEnum.POMPEIA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "P", dados);

            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);

            triplice.ArquivoComissao.ReplicarLinha(0, 1);

            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[0], triplice.ArquivoComissao[0]);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[1]);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_0000()
        {
            IniciarTeste(TipoArquivo.Cliente, "1108", "FG00 - PROC101 - No arquivo OCR_COBRANCA repetir 1x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.PITZI.CLIENTE-EV-0001-20200710.txt"));
            SalvarArquivo(arquivo);


            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.PITZI.PARCEMS-EV-0001-20200710.txt"));

            arquivo.SelecionarLinhas("CD_CONTRATO", "717100801049346");
            CriarNovoContrato(0);

            var contrato = arquivo[0]["CD_CONTRATO"];
            AlterarTodasAsLinhas("CD_CONTRATO", contrato);
            AlterarTodasAsLinhas("NR_APOLICE", contrato);
            AlterarTodasAsLinhas("NR_PROPOSTA", contrato);
            AjustarQtdLinFooter();

            SalvarArquivo(arquivo);


            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PITZI.EMSCMS-EV-0001-20200710.txt"));

            arquivo.SelecionarLinhas("CD_CONTRATO", "717100801049346");
            AlterarTodasAsLinhas("CD_CONTRATO", contrato);

            AjustarQtdLinFooter();

            SalvarArquivo(arquivo);
        }

        [TestMethod]
        public void SAP_8888()
        {
            IniciarTeste(TipoArquivo.Comissao, "1108", "FG00 - PROC101 - No arquivo OCR_COBRANCA repetir 1x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir Header");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PITZI.EMSCMS-EV-6385-20200710.TXT"));

            RemoverLinhasExcetoAsPrimeiras(2);

            SalvarArquivo(arquivo);
        }
    }
}
