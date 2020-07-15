using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG07
{
    [TestClass]
    public class FG07_LASA : FG07_Base
    {
        protected string ClienteCadastradoNoOIM => throw new Exception();

        [TestMethod]
        public void SAP_6154()
        {
            InicioTesteFG07("6154", "FG07 - Lasa - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C - Novo cliente", OperadoraEnum.LASA);

            triplice.AlterarParcEComissao(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracaoECobertura
                (triplice.ArquivoComissao.Header[0]["CD_TPA"], "C", triplice.ArquivoParcEmissao[0]["CD_COBERTURA"]));
            triplice.ArquivoComissao.AlterarLinha(0, "CD_TIPO_COMISSAO", "C");
            CriarEmissaoCompleta();
            ChamarExecucao(FG07_Tarefas.Trinca.ObterTexto());
            var linhaStageParc = ValidarStageSucessoFG07();

            validadorXML.ValidarInclusaoNasTabelas(linhaStageParc, "1210", false, out string idArquivo);
            ValidarXMLComTabelasOIM(idArquivo, false);

        }
        [TestMethod]
        public void SAP_6155()
        {
            InicioTesteFG07("6155", "SAP-6155:FG07 - Lasa - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão P - Novo cliente", OperadoraEnum.LASA);

            triplice.AlterarParcEComissao(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracaoECobertura
                (triplice.ArquivoComissao.Header[0]["CD_TPA"], "P", triplice.ArquivoParcEmissao[0]["CD_COBERTURA"]));
            triplice.ArquivoComissao.AlterarLinha(0, "CD_TIPO_COMISSAO", "P");
            CriarEmissaoCompleta();
            ChamarExecucao(FG07_Tarefas.Trinca.ObterTexto());
            var linhaStageParc = ValidarStageSucessoFG07();

            validadorXML.ValidarInclusaoNasTabelas(linhaStageParc, "1210", false, out string idArquivo);
            ValidarXMLComTabelasOIM(idArquivo, false);

        }
        [TestMethod]
        public void SAP_6156()
        {
            InicioTesteFG07("6156", "SAP-6156:FG07 - Lasa - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C - Cli cadastrado", OperadoraEnum.LASA);

            triplice.AlterarParcEComissao(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracaoECobertura
                (triplice.ArquivoComissao.Header[0]["CD_TPA"], "C", triplice.ArquivoParcEmissao[0]["CD_COBERTURA"]));
            triplice.ArquivoComissao.AlterarLinha(0, "CD_TIPO_COMISSAO", "C");
            triplice.AlterarCliente(0, "CD_CLIENTE", ClienteCadastradoNoOIM);
            CriarEmissaoCompleta(false);
            ChamarExecucao(FG07_Tarefas.Trinca.ObterTexto());
            var linhaStageParc = ValidarStageSucessoFG07();

            validadorXML.ValidarInclusaoNasTabelas(linhaStageParc, "1210", false, out string idArquivo);
            ValidarXMLComTabelasOIM(idArquivo, false);

        }

        [TestMethod]
        public void SAP_6157()
        {
            //?
            InicioTesteFG07("6157", "SAP-6157:FG07 - Lasa - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C e P - Novo cliente", OperadoraEnum.LASA);

            triplice.AlterarParcEComissao(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracaoECobertura
                (triplice.ArquivoComissao.Header[0]["CD_TPA"], "C", triplice.ArquivoParcEmissao[0]["CD_COBERTURA"]));//COLOCAR CD_CORRETOR com C e P,
            triplice.ArquivoComissao.AlterarLinha(0, "CD_TIPO_COMISSAO", "C");

            var valor = triplice.ArquivoParcEmissao[0]["VL_PREMIO_LIQUIDO"].ObterValorDecimal() / 2;
            triplice.ArquivoComissao.AlterarLinha(0, "VL_COMISSAO",valor.ValorFormatado());
            triplice.ArquivoComissao.ReplicarLinha(0,1);
            triplice.ArquivoComissao.AlterarLinha(1, "CD_TIPO_COMISSAO", "P");
            triplice.ArquivoComissao.AlterarLinha(1, "VL_COMISSAO", valor.ValorFormatado());

            CriarEmissaoCompleta();
            ChamarExecucao(FG07_Tarefas.Trinca.ObterTexto());
            var linhaStageParc = ValidarStageSucessoFG07();

            validadorXML.ValidarInclusaoNasTabelas(linhaStageParc, "1210", false, out string idArquivo);
            ValidarXMLComTabelasOIM(idArquivo, false);

        }

        [TestMethod]
        public void SAP_6158()
        {
            //?
            InicioTesteFG07("6158", " SAP-6158:FG07 - Lasa - Geração XML Sucesso - Emissão 1a parcela - 2 cobertura - Comissão C - Novo cliente", OperadoraEnum.LASA);

            triplice.AlterarParcEComissao(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracaoECobertura
                (triplice.ArquivoComissao.Header[0]["CD_TPA"], "C", triplice.ArquivoParcEmissao[0]["CD_COBERTURA"]));
            triplice.ArquivoComissao.AlterarLinha(0, "CD_TIPO_COMISSAO", "C");


            triplice.ArquivoParcEmissao.ReplicarLinha(0, 1);
            var cobertura = dados.ObterCoberturaDiferenteDe(triplice.ArquivoParcEmissao[0]["CD_COBERTURA"], triplice.ArquivoParcEmissao.Header[0]["CD_TPA"]);
            AlterarDadosDeCobertura(1, cobertura, triplice.ArquivoParcEmissao);
            
            CriarEmissaoCompleta();
            ChamarExecucao(FG07_Tarefas.Trinca.ObterTexto());
            var linhaStageParc = ValidarStageSucessoFG07();

            validadorXML.ValidarInclusaoNasTabelas(linhaStageParc, "1210", false, out string idArquivo);
            ValidarXMLComTabelasOIM(idArquivo, false);

        }

        [TestMethod]
        public void SAP_6159()
        {

            InicioTesteFG07("6159", "SAP-6159:FG07 - Lasa - Geração XML Sucesso - Emissão 1a parcela - 2 cobertura - Comissão C e P - Novo cliente", OperadoraEnum.LASA);

            triplice.AlterarParcEComissao(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracaoECobertura //COLOCAR CD_CORRETOR com C e P,
                (triplice.ArquivoComissao.Header[0]["CD_TPA"], "C", triplice.ArquivoParcEmissao[0]["CD_COBERTURA"]));
            triplice.ArquivoComissao.AlterarLinha(0, "CD_TIPO_COMISSAO", "C");

            //ALTERACAO PARCELA
            triplice.ArquivoParcEmissao.ReplicarLinha(0, 1);
            
            var cobertura = dados.ObterCoberturaDiferenteDe(triplice.ArquivoParcEmissao[0]["CD_COBERTURA"], triplice.ArquivoParcEmissao.Header[0]["CD_TPA"]);
            AlterarDadosDeCobertura(1, cobertura, triplice.ArquivoParcEmissao);

            //ALTERACAO COMISSAO
            triplice.ArquivoComissao.ReplicarLinha(0, 1);
            var valor = triplice.ArquivoParcEmissao[0]["VL_PREMIO_LIQUIDO"].ObterValorDecimal() / 2;
            triplice.ArquivoComissao.AlterarLinha(0, "VL_COMISSAO", valor.ValorFormatado());
            triplice.ArquivoComissao.AlterarLinha(1, "CD_TIPO_COMISSAO", "P");
            triplice.ArquivoComissao.AlterarLinha(1, "VL_COMISSAO", valor.ValorFormatado());

            triplice.ArquivoComissao.ReplicarLinha(0, 2);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[2]);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[3]);
            triplice.ArquivoComissao.AlterarLinha(3, "CD_TIPO_COMISSAO", "P");
                       

            CriarEmissaoCompleta();
            ChamarExecucao(FG07_Tarefas.Trinca.ObterTexto());
            var linhaStageParc = ValidarStageSucessoFG07();

            validadorXML.ValidarInclusaoNasTabelas(linhaStageParc, "1210", false, out string idArquivo);
            ValidarXMLComTabelasOIM(idArquivo, false);

        }

        [TestMethod]
        public void SAP_6160()
        {
            //?
            InicioTesteFG07("6160", "SAP-6160:FG07 - Lasa - Geração XML Sucesso - Emissão 2a parcela - 1 cobertura - Comissão C", OperadoraEnum.LASA);

            triplice.AlterarParcEComissao(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracaoECobertura
                (triplice.ArquivoComissao.Header[0]["CD_TPA"], "C", triplice.ArquivoParcEmissao[0]["CD_COBERTURA"]));
            triplice.ArquivoComissao.AlterarLinha(0, "CD_TIPO_COMISSAO", "C");

            CriarEmissaoCompleta();
            ChamarExecucao(FG07_Tarefas.Trinca.ObterTexto());
            var linhaStageParc = ValidarStageSucessoFG07();

            validadorXML.ValidarInclusaoNasTabelas(linhaStageParc, "1210", false, out string idArquivo);
            ValidarXMLComTabelasOIM(idArquivo, false);


            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao);
            triplice.ArquivoParcEmissao.RemoverLinha(0);

            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[0], triplice.ArquivoComissao[0]);

            CriarEmissaoCompleta();
            ChamarExecucao(FG07_Tarefas.Trinca.ObterTexto());
            linhaStageParc = ValidarStageSucessoFG07();

            validadorXML.ValidarInclusaoNasTabelas(linhaStageParc, "1210", false, out idArquivo);
            ValidarXMLComTabelasOIM(idArquivo, false);

        }

        [TestMethod]
        public void SAP_6161()
        {

            InicioTesteFG07("6161", "SAP-6161:FG07 - Lasa - Geração XML Sucesso - Emissão 2a parcela - 2 cobertura - Comissão R", OperadoraEnum.LASA);

            triplice.AlterarParcEComissao(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracaoECobertura
                (triplice.ArquivoComissao.Header[0]["CD_TPA"], "R", triplice.ArquivoParcEmissao[0]["CD_COBERTURA"]));
            triplice.ArquivoComissao.AlterarLinha(0, "CD_TIPO_COMISSAO", "R");

            //ALTERACAO PARCELA
            triplice.ArquivoParcEmissao.ReplicarLinha(0, 1);

            var cobertura = dados.ObterCoberturaDiferenteDe(triplice.ArquivoParcEmissao[0]["CD_COBERTURA"], triplice.ArquivoParcEmissao.Header[0]["CD_TPA"]);
            AlterarDadosDeCobertura(1, cobertura, triplice.ArquivoParcEmissao);


            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao);
            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao,1);

            //ALTERACAO COMISSAO
            triplice.ArquivoComissao.ReplicarLinha(0, 3);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[1]);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[2], triplice.ArquivoComissao[2]);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[3], triplice.ArquivoComissao[3]);

            CriarEmissaoCompleta();
            ChamarExecucao(FG07_Tarefas.Trinca.ObterTexto());
            var linhaStageParc = ValidarStageSucessoFG07();

            validadorXML.ValidarInclusaoNasTabelas(linhaStageParc, "1210", false, out string idArquivo);
            ValidarXMLComTabelasOIM(idArquivo, false);

        }

    }
}
