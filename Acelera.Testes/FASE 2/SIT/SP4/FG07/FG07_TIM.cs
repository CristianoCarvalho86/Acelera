using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
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
            IniciarTesteFG07("6164", "SAP-6164:FG07 - Tim - Geração XML -- Capa e Emissão no msm XML - Comissão C - Novo cliente", OperadoraEnum.TIM, true, false);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);

            SalvaExecutaEValidaFG07();

        }


        [TestMethod]
        public void SAP_6165()
        {
            IniciarTesteFG07("6165", " SAP-6165:FG07 - Tim - Capa e Emissão em XML diferentes - Comissão P - Novo cliente", OperadoraEnum.TIM, true, false);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "P", dados);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_6166()
        {
            IniciarTesteFG07("6166", "SAP-6166:FG07 - Tim - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C - Cli cadastrado", OperadoraEnum.TIM, false);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[0]);

            SalvaExecutaEValidaFG07(false);

        }

        [TestMethod]
        public void SAP_6167()
        {
            IniciarTesteFG07("6167", "SAP-6167:FG07 - Tim - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C e P - Novo cliente", OperadoraEnum.TIM, true, false);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);

            AdicionarTipoComissao(triplice.ArquivoComissao, triplice.ArquivoParcEmissao[0]["VL_PREMIO_LIQUIDO"], "P", 0);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_6168()
        {
            IniciarTesteFG07("6168", " SAP-6168:FG07 - Tim - Geração XML Sucesso - Emissão 1a parcela - 2 cobertura - Comissão C - Novo cliente", OperadoraEnum.TIM);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);

            AdicionarNovaCoberturaNaEmissao(triplice.ArquivoParcEmissao, dados, 0);

            triplice.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[1]);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_6169()
        {
            IniciarTesteFG07("6169", "SAP-6169:FG07 - Tim - Geração XML Sucesso - Emissão 1a parcela - 2 cobertura - Comissão C e P - Novo cliente", OperadoraEnum.TIM);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[0]);

            //ALTERACAO PARCELA
            AdicionarNovaCoberturaNaEmissao(triplice.ArquivoParcEmissao, dados, 1);

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
            IniciarTesteFG07("6170", "SAP-6170:FG07 - Tim - Geração XML Sucesso - Emissão 2a parcela - 1 cobertura - Comissão C", OperadoraEnum.TIM);

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
            IniciarTesteFG07("6171", "Tim - Geração XML Sucesso - Emissão 2a parcela - 2 cobertura - Comissão R", OperadoraEnum.TIM);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "R", dados);
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[0]);
            AdicionarNovaCoberturaNaEmissao(triplice.ArquivoParcEmissao, dados, 1);

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
            IniciarTesteFG07("6172", "SAP-6172:FG07 - Tim - Geração XML Sucesso - Emissão 1 e 2 parcelas juntas - 1 cobertura - Comissão R", OperadoraEnum.TIM);
            
            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "P", dados);

            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 1);

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
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200415.txt"));
            SalvarArquivo(arquivo);


            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0002-20200616.txt"));

            CriarNovoContrato(0);

            var contrato = arquivo[0]["CD_CONTRATO"];
            AlterarTodasAsLinhas("CD_CONTRATO", contrato);
            AlterarTodasAsLinhas("NR_APOLICE", contrato);
            AlterarTodasAsLinhas("NR_PROPOSTA", contrato);
            AjustarQtdLinFooter();

            SalvarArquivo(arquivo);

            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0001-20200615.txt"));

            CriarNovoContrato(0);

            AlterarTodasAsLinhas("CD_CONTRATO", contrato);
            AlterarTodasAsLinhas("NR_APOLICE", contrato);
            AlterarTodasAsLinhas("NR_PROPOSTA", contrato);
            AjustarQtdLinFooter();

            SalvarArquivo(arquivo);

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.EMSCMS-EV-0002-20200615.txt"));

            AlterarTodasAsLinhas("CD_CONTRATO", contrato);

            AjustarQtdLinFooter();

            SalvarArquivo(arquivo);
        }
    }
}
