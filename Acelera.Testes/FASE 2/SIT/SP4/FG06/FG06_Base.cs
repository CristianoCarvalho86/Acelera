using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Acelera.Domain.Utils;
using Acelera.Logger;
using Acelera.Testes.DataAccessRep;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG06
{
    [TestClass]
    public class FG06_Base : TestesFG06
    {
        private bool ClienteTemErro;
        private bool ParcelaTemErro;
        private bool ComissaoTemErro;
        private bool ClienteEnviado;
        private bool ParcelaEnviado;
        private bool ComissaoEnviado;

        [TestInitialize]
        private void IniciaTeste()
        {
            ClienteTemErro = false;
            ParcelaTemErro = false;
            ComissaoTemErro = false;
        }

        protected void AdicionaErro(TipoArquivo tipo)
        {
            logger.AbrirBloco("ADICIONANDO ERRO NO ARQUIVO DE " + tipo.ObterTexto());
            if (tipo == TipoArquivo.Cliente)
            {
                ClienteTemErro = true;
                logger.Escrever("DEFINIDO : DT_NASCIMENTO = 20120416 ESPERANDO ERRO NA FG02");
                triplice.ArquivoCliente.AlterarLinha(0, "DT_NASCIMENTO", "20120416");
            }
            else if (tipo == TipoArquivo.ParcEmissao || tipo == TipoArquivo.ParcEmissaoAuto)
            {
                ParcelaTemErro = true;
                logger.Escrever("DEFINIDO : CD_RAMO = 00 ESPERANDO ERRO NA FG02");
                triplice.ArquivoParcEmissao.AlterarLinha(0, "CD_RAMO", "00");
            }
            else if (tipo == TipoArquivo.Comissao)
            {
                ComissaoTemErro = true;
                logger.Escrever("DEFINIDO : CD_RAMO = 00 ESPERANDO ERRO NA FG02");
                triplice.ArquivoComissao.AlterarLinha(0, "CD_RAMO", "00");
            }
            else
                throw new Exception("TIPO ARQUIVO NAO DEFINIDO.");
        }

        protected void SalvarTrinca(bool salvaCliente = true, bool salvaParcela = true, bool salvaComissao = true)
        {
            ClienteEnviado = salvaCliente;
            ParcelaEnviado = salvaParcela;
            ComissaoEnviado = salvaComissao;
            triplice.Salvar(salvaCliente, salvaParcela, salvaComissao);
        }

        public void InicioTesteFG06(string numeroTeste, string descricao, OperadoraEnum operadora)
        {
            //5922:FG06 - VIVO - CLI rejeitado, PARC sucesso e CMS sucesso
            IniciarTeste(TipoArquivo.Comissao, numeroTeste, descricao);

            CarregarTriplice(operadora);

            AlteracoesPadraoDaTrinca(triplice);
        }


        protected void CriarEmissaoCompleta()
        {
            SalvarTrinca();
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoSucesso();
        }

        protected void CriarCancelamento(bool erroEmParc, bool erroEmComissao, OperadoraEnum operadora, string cdTipoEmissao,
            out Arquivo arquivoParcCriado, out Arquivo arquivoComissaoCriado,
bool alterarLayout = false, string nrSequencialEmissao = "", string valorComissao = "", string cdMovtoCobranca = "")
        {
            CarregarCancelamento(0, erroEmParc, erroEmComissao, operadora,
                cdTipoEmissao, out arquivoParcCriado, out arquivoComissaoCriado, false,
                nrSequencialEmissao, valorComissao, cdMovtoCobranca);
        }

        public void ValidarFGsAnterioresEErros()
        {
            var listaFgs = new FGs[] { FGs.FG00, FGs.FG01, FGs.FG02, FGs.FG05 };

            foreach (var fg in listaFgs)
            {
                if(ClienteEnviado)
                    ExecFgs(!ClienteTemErro, fg, triplice.ArquivoCliente);
                if (ParcelaEnviado)
                    ExecFgs(!ParcelaTemErro, fg, triplice.ArquivoParcEmissao);
                if (ComissaoEnviado)
                    ExecFgs(!ComissaoTemErro, fg, triplice.ArquivoComissao);
            }
        }

        protected void ExecutarEValidarFG06EmissaoComErro()
        {
            ExecutarEValidarFG06(triplice,
                ClienteEnviado ? ClienteTemErro ? (CodigoStage?)CodigoStage.ReprovadoNegocioSemDependencia : CodigoStage.ReprovadoFG06 : null,
                ParcelaEnviado ? ParcelaTemErro ? (CodigoStage?)CodigoStage.ReprovadoNegocioSemDependencia : CodigoStage.ReprovadoFG06 : null,
                ComissaoEnviado ? ComissaoTemErro ? (CodigoStage?)CodigoStage.ReprovadoNegocioSemDependencia : CodigoStage.ReprovadoFG06 : null,
                ClienteTemErro ? "267" : "403",//SE CLIENTE NAO FOI ADICIONADO, ESPERA-SE O ERRO DA TRINCA. - TESTE PARA CENARIOS COM ERRO.
                ParcelaTemErro ? "25" : "103",
                ComissaoTemErro ? "25" : "105");
        }

        protected void ExecutarEValidarFG06EmissaoSucesso()
        {
            ExecutarEValidarFG06(triplice, CodigoStage.AprovadoFG06, CodigoStage.AprovadoFG06, CodigoStage.AprovadoFG06, "", "", "");
        }

        private void ExecFgs(bool sucesso, FGs fg, Arquivo arquivo)
        {
            if (sucesso || fg == FGs.FG00 || fg == FGs.FG01)
            {
                ExecutarEValidar(arquivo, fg, fg.ObterCodigoDeSucessoOuFalha(true));
            }
            else if (fg == FGs.FG02)
            {
                ExecutarEValidarEsperandoErro(arquivo, fg, fg.ObterCodigoDeSucessoOuFalha(false));
            }
        }

        public void CarregarCancelamento(int indexLinhaArquivoEmissao, bool erroEmParc, bool erroEmComissao, OperadoraEnum operadora, string cdTipoEmissao,
            out Arquivo arquivoParcCriado,out Arquivo arquivoComissaoCriado,
bool alterarLayout = false, string nrSequencialEmissao = "", string valorComissao = "", string cdMovtoCobranca = "")
        {
            logger.Escrever($"CRIANDO ARQUIDO DE PARC_EMISSAO PARA CANCELAMENTO - {operadora.ObterTexto()}");
            arquivo = triplice.ArquivoParcEmissao.Clone();
            var idTransacaoDoArquivoOriginal = arquivo[indexLinhaArquivoEmissao]["ID_TRANSACAO"];
            RemoverLinhasExcetoAsPrimeiras(1);

            AlterarLinhaSeExistirCampo(arquivo, 0, "ID_TRANSACAO_CANC", arquivo[0]["ID_TRANSACAO"]);
            AlterarLinhaSeExistirCampo(arquivo, 0, "ID_TRANSACAO", idTransacaoDoArquivoOriginal);
            AlterarLinhaSeExistirCampo(arquivo, 0, "CD_TIPO_EMISSAO", cdTipoEmissao);
            AlterarLinhaSeExistirCampo(arquivo, 0, "NR_PARCELA", SomarValor(0, "NR_PARCELA", 1M));
            AlterarLinhaSeExistirCampo(arquivo, 0, "NR_ENDOSSO", GerarNumeroAleatorio(5));
            AlterarLinhaSeExistirCampo(arquivo, 0, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1M));
            if (!string.IsNullOrEmpty(nrSequencialEmissao))
                AlterarLinhaSeExistirCampo(arquivo, 0, "NR_SEQUENCIAL_EMISSAO", nrSequencialEmissao);

            AlterarLinhaSeExistirCampo(arquivo, 0, "CD_MOVTO_COBRANCA", "02");
            if (!string.IsNullOrEmpty(cdMovtoCobranca))
                AlterarLinhaSeExistirCampo(arquivo, 0, "CD_MOVTO_COBRANCA", cdMovtoCobranca);

            if (alterarLayout)
                arquivo.AlterarHeader("VERSAO", "9.6");

            var codigoRamoCorreto = arquivo[0]["CD_RAMO"];
            if (erroEmParc)
            {
                AlterarLinha(0, "CD_RAMO", "00");//Rejeitar na 02
            }

            SalvarArquivo();

            logger.Escrever("ARQUIVO CRIADO COM O NOME : " + arquivo.NomeArquivo);

            var arquivoParc = arquivo.Clone();

            logger.Escrever($"CRIANDO ARQUIDO DE COMISSAO PARA CANCELAMENTO - {operadora.ObterTexto()}");
            arquivoParcCriado = arquivo.Clone();

            //COMISSAO

            arquivo = triplice.ArquivoParcEmissao.Clone();
            RemoverLinhasExcetoAsPrimeiras(1);
            IgualarCamposQueExistirem(arquivoParc, arquivo);
            AlterarLinhaSeExistirCampo(arquivo, 0, "CD_TIPO_COMISSAO", operadora == OperadoraEnum.VIVO ? "C" : "P");
            if (!string.IsNullOrEmpty(valorComissao))
                AlterarLinhaSeExistirCampo(arquivo, 0, "VL_COMISSAO", valorComissao);

            if (erroEmComissao)
            {
                AlterarLinha(0, "CD_RAMO", "00");//Rejeitar na 02
            }
            else
                AlterarLinha(0, "CD_RAMO", codigoRamoCorreto);

            if (arquivoParc.ObterValorFormatado(0, "VL_PREMIO_LIQUIDO").ObterValorDecimal() > 0)
                AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoParc.ObterValorFormatado(0, "VL_PREMIO_LIQUIDO"), "-0.05"));
            else
                AlterarLinha(0, "VL_COMISSAO", "0");

            if (ObterValorFormatado(0, "VL_COMISSAO").ObterValorDecimal() < 0)
                throw new Exception("VL_COMISSAO INVALIDO.");

            SalvarArquivo();

            logger.Escrever("ARQUIVO CRIADO COM O NOME : " + arquivo.NomeArquivo);

            arquivoComissaoCriado = arquivo.Clone();
        }
    }
}
