using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG07
{
    [TestClass]
    public class FG07_VIVO : FG07_Base
    {
        protected string ClienteCadastradoNoOIM => throw new Exception();

        [TestMethod]
        public void SAP_6154()
        {
            IniciarTesteFG07("6154", "FG07 - VIVO - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C - Novo cliente", OperadoraEnum.VIVO);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_6155()
        {
            IniciarTesteFG07("6155", "SAP-6155:FG07 - VIVO - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão P - Novo cliente", OperadoraEnum.VIVO);


            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "P", dados);

            SalvaExecutaEValidaFG07();

        }
        [TestMethod]
        public void SAP_6156()
        {
            IniciarTesteFG07("6156", "SAP-6156:FG07 - VIVO - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C - Cli cadastrado", OperadoraEnum.VIVO, false);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);

            triplice.AlterarCliente(0, "CD_CLIENTE", ClienteCadastradoNoOIM);

            SalvaExecutaEValidaFG07(false);

        }

        [TestMethod]
        public void SAP_6157()
        {
            IniciarTesteFG07("6157", "SAP-6157:FG07 - VIVO - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C e P - Novo cliente", OperadoraEnum.VIVO);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);

            AdicionarTipoComissao(triplice.ArquivoComissao, triplice.ArquivoParcEmissao[0]["VL_PREMIO_LIQUIDO"], "P", 0);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_6158()
        {
            IniciarTesteFG07("6158", " SAP-6158:FG07 - VIVO - Geração XML Sucesso - Emissão 1a parcela - 2 cobertura - Comissão C - Novo cliente", OperadoraEnum.VIVO);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);

            AdicionarNovaCoberturaNaEmissao(triplice.ArquivoParcEmissao, dados, 0);

            triplice.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[1]);

            SalvaExecutaEValidaFG07();

        }

        [TestMethod]
        public void SAP_6159()
        {

            IniciarTesteFG07("6159", "SAP-6159:FG07 - VIVO - Geração XML Sucesso - Emissão 1a parcela - 2 cobertura - Comissão C e P - Novo cliente", OperadoraEnum.VIVO);

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
            IniciarTesteFG07("6160", "SAP-6160:FG07 - VIVO - Geração XML Sucesso - Emissão 2a parcela - 1 cobertura - Comissão C", OperadoraEnum.POMPEIA);

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
            IniciarTesteFG07("6161", "SAP-6161:FG07 - VIVO - Geração XML Sucesso - Emissão 2a parcela - 2 cobertura - Comissão R", OperadoraEnum.VIVO);

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

            IniciarTesteFG07("6162", "SAP-6162:FG07 - VIVO - Geração XML Sucesso - Emissão 1 e 2 parcelas juntas - 1 cobertura - Comissão P", OperadoraEnum.POMPEIA);

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
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-702-20190320.txt"));

            var cliente = GerarNumeroAleatorio(8);
            AlterarLinha(0, "CD_CLIENTE", cliente);
            SalvarArquivo(arquivo);

            var arquivoCliente = arquivo.Clone();

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1844-20200206.txt"));

            arquivo.SelecionarLinhas("CD_CONTRATO", "7231000082501");
            CriarNovoContrato(0);

            var contrato = arquivo[0]["CD_CONTRATO"];
            AlterarTodasAsLinhas("CD_CONTRATO", contrato);
            AlterarTodasAsLinhas("NR_APOLICE", contrato);
            AlterarTodasAsLinhas("NR_PROPOSTA", contrato);
            AlterarTodasAsLinhas("CD_CLIENTE", cliente);
            AjustarQtdLinFooter();

            SalvarArquivo(arquivo);

            var arquivoParc = arquivo.Clone();


            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1845-20200206.txt"));

            arquivo.SelecionarLinhas("CD_CONTRATO", "7231000082501");
            AlterarTodasAsLinhas("CD_CONTRATO", contrato);

            AjustarQtdLinFooter();

            SalvarArquivo(arquivo);

            var arquivoComissao = arquivo.Clone();

            ExecutarEValidar(arquivoCliente, FGs.FG00 , FGs.FG00.ObterCodigoDeSucessoOuFalha(true));
            ExecutarEValidar(arquivoCliente, FGs.FG01, FGs.FG01.ObterCodigoDeSucessoOuFalha(true));
            ExecutarEValidar(arquivoCliente, FGs.FG01_2, FGs.FG01_2.ObterCodigoDeSucessoOuFalha(true));

            ExecutarEValidar(arquivoComissao, FGs.FG00, FGs.FG00.ObterCodigoDeSucessoOuFalha(true));
            ExecutarEValidar(arquivoComissao, FGs.FG01, FGs.FG01.ObterCodigoDeSucessoOuFalha(true));
            ExecutarEValidar(arquivoComissao, FGs.FG01_2, FGs.FG01_2.ObterCodigoDeSucessoOuFalha(true));

            ExecutarEValidar(arquivoParc, FGs.FG00, FGs.FG00.ObterCodigoDeSucessoOuFalha(true));
            ExecutarEValidar(arquivoParc, FGs.FG01, FGs.FG01.ObterCodigoDeSucessoOuFalha(true));
            ExecutarEValidar(arquivoParc, FGs.FG01_2, FGs.FG01_2.ObterCodigoDeSucessoOuFalha(true));
            ExecutarEValidar(arquivoParc, FGs.FGR_DT_EMISSAO_MES_CONTABIL_PARCELA_AUTO, FGs.FGR_DT_EMISSAO_MES_CONTABIL_PARCELA_AUTO.ObterCodigoDeSucessoOuFalha(true));


            ExecutarEValidar(arquivoCliente, FGs.FG02, FGs.FG02.ObterCodigoDeSucessoOuFalha(true));
            ExecutarEValidar(arquivoCliente, FGs.FG05, FGs.FG02.ObterCodigoDeSucessoOuFalha(true));

            ExecutarEValidar(arquivoParc, FGs.FG02, FGs.FG02.ObterCodigoDeSucessoOuFalha(true));
            ExecutarEValidar(arquivoParc, FGs.FG05, FGs.FG02.ObterCodigoDeSucessoOuFalha(true));

            
            ExecutarEValidar(arquivoComissao, FGs.FG02, FGs.FG02.ObterCodigoDeSucessoOuFalha(true));
            ExecutarEValidar(arquivoComissao, FGs.FG05, FGs.FG02.ObterCodigoDeSucessoOuFalha(true));
            ExecutarEValidar(arquivoComissao, FGs.FG06, FGs.FG06.ObterCodigoDeSucessoOuFalha(true));
            ExecutarEValidar(arquivoComissao, FGs.FG07, FGs.FG07.ObterCodigoDeSucessoOuFalha(true));

        }

    }
}
