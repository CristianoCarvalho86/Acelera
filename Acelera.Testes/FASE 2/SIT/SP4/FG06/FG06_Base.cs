using Acelera.Contratos;
using Acelera.Domain;
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
using Acelera.Testes.Repositorio;
using Acelera.Utils;
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

        protected void AdicionaErro(TipoArquivo tipo, int posicaoLinha = 0)
        {
            logger.AbrirBloco("ADICIONANDO ERRO NO ARQUIVO DE " + tipo.ObterTexto());
            if (tipo == TipoArquivo.Cliente)
            {
                ClienteTemErro = true;
                logger.Escrever("DEFINIDO : DT_NASCIMENTO = 20120416 ESPERANDO ERRO NA FG02");
                trinca.ArquivoCliente.AlterarLinha(posicaoLinha, "DT_NASCIMENTO", "20120416");
            }
            else if (tipo == TipoArquivo.ParcEmissao || tipo == TipoArquivo.ParcEmissaoAuto)
            {
                ParcelaTemErro = true;
                logger.Escrever("DEFINIDO : CD_RAMO = 00 ESPERANDO ERRO NA FG02");
                trinca.ArquivoParcEmissao.AlterarLinha(posicaoLinha, "CD_RAMO", "00");
            }
            else if (tipo == TipoArquivo.Comissao)
            {
                ComissaoTemErro = true;
                logger.Escrever("DEFINIDO : CD_RAMO = 00 ESPERANDO ERRO NA FG02");
                trinca.ArquivoComissao.AlterarLinha(posicaoLinha, "CD_RAMO", "00");
            }
            else
                throw new Exception("TIPO ARQUIVO NAO DEFINIDO.");
        }

        protected void AdicionaErro(TipoArquivo tipo, Arquivo arquivo, int posicaoLinha = 0)
        {
            logger.AbrirBloco("ADICIONANDO ERRO NO ARQUIVO DE " + tipo.ObterTexto());
            if (tipo == TipoArquivo.Cliente)
            {
                logger.Escrever("DEFINIDO : DT_NASCIMENTO = 20120416 ESPERANDO ERRO NA FG02");
                arquivo.AlterarLinha(posicaoLinha, "DT_NASCIMENTO", "20120416");
            }
            else if (tipo == TipoArquivo.ParcEmissao || tipo == TipoArquivo.ParcEmissaoAuto || tipo == TipoArquivo.Comissao)
            {
                logger.Escrever("DEFINIDO : CD_RAMO = 00 ESPERANDO ERRO NA FG02");
                arquivo.AlterarLinha(posicaoLinha, "CD_RAMO", "00");
            }
            else
                throw new Exception("TIPO ARQUIVO NAO DEFINIDO.");
        }

        protected void SalvarTrinca(bool salvaCliente = true, bool salvaParcela = true, bool salvaComissao = true, ITrinca _triplice = null)
        {
            _triplice = _triplice == null ? trinca : _triplice;
            ClienteEnviado = salvaCliente;
            ParcelaEnviado = salvaParcela;
            ComissaoEnviado = salvaComissao;
            _triplice.Salvar(salvaCliente, salvaParcela, salvaComissao);
        }

        public void InicioTesteFG06(string numeroTeste, string descricao, OperadoraEnum operadora)
        {
            //5922:FG06 - VIVO - CLI rejeitado, PARC sucesso e CMS sucesso
            IniciarTeste(TipoArquivo.Comissao, numeroTeste, descricao);

            CarregarTrinca(operadora);

            AlteracoesPadraoDaTrinca(trinca);
        }


        protected void CriarEmissaoCompleta()
        {
            SalvarTrinca();
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoSucesso();

            EnviarParaOds(trinca.ArquivoCliente, true, false, CodigoStage.AprovadoFG06);
            EnviarParaOds(trinca.ArquivoComissao, true, false, CodigoStage.AprovadoFG06);
            EnviarParaOds(trinca.ArquivoParcEmissao, true, false, CodigoStage.AprovadoFG06);
        }

        protected void CriarCancelamento(bool erroEmParc, bool erroEmComissao, OperadoraEnum operadora, string cdTipoEmissao,
            out IArquivo arquivoParcCriado, out IArquivo arquivoComissaoCriado,
bool alterarLayout = false, string nrSequencialEmissao = "", string valorComissao = "", string cdMovtoCobranca = "")
        {
            CarregarCancelamento(0, erroEmParc, erroEmComissao, operadora,
                cdTipoEmissao, out arquivoParcCriado, out arquivoComissaoCriado, false,
                nrSequencialEmissao, valorComissao, cdMovtoCobranca);
        }

        public void ValidarFGsAnterioresEErros(FGs executarAteFG = FGs.FG05)
        {
            IList<FGs> listaFgs = new List<FGs>();
            if (Parametros.ExecutaPelaBat)
            {
                if (ClienteEnviado)
                    ExecutarEValidarBatch(trinca.ArquivoCliente, Parametros.PastaBatDia + BatEnumDia.Cliente.ObterTexto(), CodigoStage.AprovadoNaFG01);
                if (ParcelaEnviado)
                {
                    BatEnumDia bat = trinca.EhParcAuto ? BatEnumDia.ParcEmissaoAuto : BatEnumDia.ParcEmissao;
                    ExecutarEValidarBatch(trinca.ArquivoParcEmissao, Parametros.PastaBatDia + bat.ObterTexto(), CodigoStage.AprovadoNaFG01);
                }
                if (ComissaoEnviado)
                {
                    ExecutarEValidarBatch(trinca.ArquivoCliente, Parametros.PastaBatDia + BatEnumDia.Comissao.ObterTexto(), CodigoStage.AprovadoNaFG01);
                }
                listaFgs.Add(FGs.FG02);
                listaFgs.Add(FGs.FG05);
            }
            else
            {
                if (!trinca.EhParcAuto)
                    listaFgs = new FGs[] { FGs.FG00, FGs.FG01, FGs.FGR_DT_EMISSAO_MES_CONTABIL_PARCELA, FGs.FG01_2,  FGs.FG02, FGs.FG05 };
                else
                    listaFgs = new FGs[] { FGs.FG00, FGs.FG01, FGs.FGR_DT_EMISSAO_MES_CONTABIL_PARCELA_AUTO, FGs.FG01_2,  FGs.FG02, FGs.FG05 };
            }

            foreach (var fg in listaFgs)
            {
                if(ClienteEnviado)
                    ExecFgs(!ClienteTemErro, fg, trinca.ArquivoCliente);
                if (ParcelaEnviado)
                    ExecFgs(!ParcelaTemErro, fg, trinca.ArquivoParcEmissao);
                if (ComissaoEnviado)
                    ExecFgs(!ComissaoTemErro, fg, trinca.ArquivoComissao);

                ValidarTeste();

                if (fg == executarAteFG)
                    break;
            }
        }

        public void ValidarFGsAnterioresEErros_Cancelamento( IArquivo _arquivo, bool esperaSucesso = true)
        {
            FGs[] listaFgs;
            if (!trinca.EhParcAuto)
                listaFgs = new FGs[] {FGs.FG00, FGs.FG01, FGs.FGR_DT_EMISSAO_MES_CONTABIL_PARCELA, FGs.FG01_2, FGs.FG02, FGs.FG09 };
            else
                listaFgs = new FGs[] { FGs.FG00, FGs.FG01, FGs.FGR_DT_EMISSAO_MES_CONTABIL_PARCELA_AUTO, FGs.FG01_2,  FGs.FG02, FGs.FG09 };

            foreach (var fg in listaFgs)
            {
                if (!esperaSucesso && fg == FGs.FG02)
                {
                    ExecutarEValidarEsperandoErro(arquivo, fg, fg.ObterCodigoDeSucessoOuFalha(false));
                    break;
                }

                ExecutarEValidar(arquivo, fg, fg.ObterCodigoDeSucessoOuFalha(true));


                if(fg == FGs.FG00)
                {
                    ValidarControleArquivo();
                }

                if (RepositorioProcedures.FgsQueRodamProcedures.Contains(fg))
                    if (!execucaoRegras.ValidarLogProcessamento(arquivo, true, 1, RepositorioProcedures.ObterProcedures(fg, arquivo.tipoArquivo)))
                        ExplodeFalha();

                //ValidarTeste();
            }
        }

        protected void ExecutarEValidarFG06EmissaoComErro(ITrinca _triplice = null)
        {
            _triplice = _triplice == null ? trinca : _triplice;
            ExecutarEValidarFG06(_triplice,
                ClienteEnviado ? ClienteTemErro ? (CodigoStage?)CodigoStage.ReprovadoNegocioSemDependencia : CodigoStage.ReprovadoFG06 : null,
                ParcelaEnviado ? ParcelaTemErro ? (CodigoStage?)CodigoStage.ReprovadoNegocioSemDependencia : CodigoStage.ReprovadoFG06 : null,
                ComissaoEnviado ? ComissaoTemErro ? (CodigoStage?)CodigoStage.ReprovadoNegocioSemDependencia : CodigoStage.ReprovadoFG06 : null,
                ClienteTemErro ? "267" : "403",//SE CLIENTE NAO FOI ADICIONADO, ESPERA-SE O ERRO DA TRINCA. - TESTE PARA CENARIOS COM ERRO.
                ParcelaTemErro ? "25" : "103",
                ComissaoTemErro ? "25" : "105");
        }

        protected void ExecutarEValidarFG06EmissaoSucesso(bool validaCliente = true, bool validaComissao = true)
        {
            var codigoStgCliente = validaCliente ? (CodigoStage?)CodigoStage.AprovadoFG06 : null;
            var codigoStgComissao = validaComissao ? (CodigoStage?)CodigoStage.AprovadoFG06 : null;

            ExecutarEValidarFG06(trinca, codigoStgCliente, CodigoStage.AprovadoFG06, codigoStgComissao, "", "", "");
        }

        private void ExecFgs(bool sucesso, FGs fg, IArquivo arquivo)
        {
            if (sucesso || (int)fg <= (int)FGs.FG01_2)
            {
                ExecutarEValidar(arquivo, fg, fg.ObterCodigoDeSucessoOuFalha(true));
                if (fg == FGs.FG00)
                {
                    execucaoRegras.ValidarControleArquivo(arquivo);
                }
            }
            else if (fg == FGs.FG02)
            {
                ExecutarEValidarEsperandoErro(arquivo, fg, fg.ObterCodigoDeSucessoOuFalha(false));
            }
            if(RepositorioProcedures.FgsQueRodamProcedures.Contains(fg))
                if (!execucaoRegras.ValidarLogProcessamento(arquivo, true, 1, RepositorioProcedures.ObterProcedures(fg, arquivo.tipoArquivo)))
                    ExplodeFalha();
        }

        public void CarregarCancelamento(int indexLinhaArquivoEmissao, bool erroEmParc, bool erroEmComissao, OperadoraEnum operadora, string cdTipoEmissao,
            out IArquivo arquivoParcCriado,out IArquivo arquivoComissaoCriado,
bool alterarLayout = false, string nrSequencialEmissao = "", string valorComissao = "", string cdMovtoCobranca = "")
        {
            logger.Escrever($"CRIANDO ARQUIDO DE PARC_EMISSAO PARA CANCELAMENTO - {operadora.ObterTexto()}");
            arquivo = trinca.ArquivoParcEmissao.Clone();
            var idTransacaoDoArquivoOriginal = arquivo[indexLinhaArquivoEmissao]["ID_TRANSACAO"];
            RemoverLinhasExcetoAsPrimeiras(1);

            var data = dados.ObterDataDoBanco();
            AlterarLinhaSeExistirCampo(arquivo, 0, "DT_EMISSAO", data);
            AlterarLinhaSeExistirCampo(arquivo, 0, "DT_EMISSAO_ORIGINAL", data);
            AlterarLinhaSeExistirCampo(arquivo, 0, "DT_INICIO_VIGENCIA", data);
            AlterarLinhaSeExistirCampo(arquivo, 0, "DT_FIM_VIGENCIA", SomarData(data, 365));
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


            logger.Escrever("ARQUIVO CRIADO COM O NOME : " + arquivo.NomeArquivo);

            var arquivoParc = arquivo.Clone();

            logger.Escrever($"CRIANDO ARQUIDO DE COMISSAO PARA CANCELAMENTO - {operadora.ObterTexto()}");
            arquivoParcCriado = arquivo.Clone();

            //COMISSAO

            arquivo = trinca.ArquivoComissao.Clone();
            RemoverLinhasExcetoAsPrimeiras(1);
            ArquivoUtils.IgualarCamposQueExistirem(arquivoParc, arquivo);
           // AlterarLinha(arquivo, 0, "CD_TIPO_COMISSAO", operadora == OperadoraEnum.VIVO ? "C" : "P");
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


            logger.Escrever("ARQUIVO CRIADO COM O NOME : " + arquivo.NomeArquivo);

            arquivoComissaoCriado = arquivo.Clone();
        }
    }
}
