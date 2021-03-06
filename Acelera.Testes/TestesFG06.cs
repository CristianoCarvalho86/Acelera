﻿using Acelera.Contratos;
using Acelera.Data;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Utils;
using Acelera.Testes.ConjuntoArquivos;
using Acelera.Testes.DataAccessRep.ODS;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    [TestClass]
    public class TestesFG06 : TestesFG04
    {
        protected override string NomeFG => "FG06";

        protected virtual void ExecutarEValidarFG06(ITrinca triplice,
            CodigoStage? codigoEsperadoStageCliente,
            CodigoStage? codigoEsperadoStageParcela,
            CodigoStage? codigoEsperadoStageComissao,
            string msgTabelaDeRetornoCliente,
            string msgTabelaDeRetornoParcela,
            string msgTabelaDeRetornoComissao)
        {
            ChamarExecucao(FG06_Tarefas.Trinca.ObterTexto());

            if (codigoEsperadoStageCliente.HasValue)
            {
                ValidarStages(triplice.ArquivoCliente, true, (int)codigoEsperadoStageCliente.Value);
                ValidarTabelaDeRetorno(triplice.ArquivoCliente, false, false, new string[] { msgTabelaDeRetornoCliente });
            }
            if (codigoEsperadoStageParcela.HasValue)
            {
                ValidarStages(triplice.ArquivoParcEmissao, true, (int)codigoEsperadoStageParcela.Value);
                ValidarTabelaDeRetorno(triplice.ArquivoParcEmissao, false, false, new string[] { msgTabelaDeRetornoParcela });
            }
            if (codigoEsperadoStageComissao.HasValue)
            {
                ValidarStages(triplice.ArquivoComissao, true, (int)codigoEsperadoStageComissao.Value);
                ValidarTabelaDeRetorno(triplice.ArquivoComissao, false, false, new string[] { msgTabelaDeRetornoComissao });
            }
            ValidarTeste();
        }

        public override void CarregarTrinca(OperadoraEnum operadora)
        {
            if (operadora == OperadoraEnum.LASA)
                trinca = new TripliceLASA(1, logger, ref arquivosSalvos);
            else if (operadora == OperadoraEnum.SOFTBOX)
                trinca = new TripliceSoftbox(1, logger, ref arquivosSalvos);
            else if (operadora == OperadoraEnum.POMPEIA)
                trinca = new TriplicePOMPEIA(1, logger, ref arquivosSalvos);
            else if (operadora == OperadoraEnum.VIVO)
                trinca = new TripliceVIVO(1, logger, ref arquivosSalvos);
            else if (operadora == OperadoraEnum.TIM)
                trinca = new TripliceTIM(1, logger, ref arquivosSalvos);
            else if (operadora == OperadoraEnum.QUEROQUERO)
                trinca = new TripliceQUEROQUERO(1, logger, ref arquivosSalvos);
            else if (operadora == OperadoraEnum.PITZI)
                trinca = new TriplicePITZI(1, logger, ref arquivosSalvos);
            else if (operadora == OperadoraEnum.AGREGUE)
                trinca = new TripliceAGREGUE(1, logger, ref arquivosSalvos);
            else if (operadora == OperadoraEnum.AGREGUEDEALERS)
                trinca = new TripliceAGREGUEDEALERS(1, logger, ref arquivosSalvos);
            
        }

        protected void AlteracoesPadraoDaTrinca(ITrinca triplice, bool geraCliente = true, bool geraArquivoCapa = true)
        {
            triplice.AlterarParcEComissao(0, "ID_TRANSACAO_CANC", "");
            triplice.AlterarParcEComissao(0, "CD_TIPO_EMISSAO", ParametrosRegrasEmissao.CarregaTipoEmissaoParaPrimeiraLinhaDaEmissao(triplice.Operadora));
            triplice.AlterarParcEComissao(0, "NR_ENDOSSO", ParametrosRegrasEmissao.CarregaPrimeiroNumeroEndosso(triplice.ArquivoParcEmissao[0], triplice.Operadora));
            triplice.AlterarParcEComissao(0, "NR_PARCELA", ParametrosRegrasEmissao.CarregaPrimeiroNrParcela(triplice.Operadora));
            triplice.AlterarParcEComissao(0, "NR_SEQUENCIAL_EMISSAO", ParametrosRegrasEmissao.CarregaPrimeiroNumeroSequencialEmissao(triplice.Operadora));

            contratoRegras.CriarNovoContrato(0, triplice.ArquivoParcEmissao);
            triplice.AlterarParcEComissao(0, "CD_CONTRATO", triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            triplice.AlterarParcEComissao(0, "NR_APOLICE", triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            triplice.AlterarParcEComissao(0, "NR_PROPOSTA", triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            if (geraCliente)
            {
                triplice.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(7));
                triplice.AlterarCliente(0, "NR_CNPJ_CPF", GeneralUtils.GerarNumeroValidadorCpf(GerarNumeroAleatorio(9)));
                triplice.AlterarCliente(0, "NM_CLIENTE", GeneralUtils.GerarTextoAleatorio(40));
            }
            else
                triplice.AlterarCliente(0, "CD_CLIENTE", dados.ObterCdClienteParceiro(true, triplice.ArquivoParcEmissao.Header[0]["CD_TPA"]));


            triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_MOVTO_COBRANCA", "01");
            var data = dados.ObterDataDoBanco();
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("DT_EMISSAO", data);
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("DT_INICIO_VIGENCIA", data);
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("DT_FIM_VIGENCIA", SomarData(data, 365));

            if(ParametrosRegrasEmissao.OperadorasComCapa.Contains(triplice.Operadora))
            {
                CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
                AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao[1], triplice.ArquivoComissao[0]);
                triplice.AlterarParcEComissao(0, "CD_MOVTO_COBRANCA", "03");
                triplice.AlterarParcEComissao(1, "CD_MOVTO_COBRANCA", "01");

                triplice.ArquivoParcEmissao.AlterarLinha(1, "VL_LMI", triplice.ArquivoParcEmissao[0]["VL_IS"]);
                triplice.ArquivoParcEmissao.AlterarLinha(1, "VL_IS", triplice.ArquivoParcEmissao[0]["VL_IS"]);
                if (geraArquivoCapa)
                {
                    var arquivoCapa = triplice.ArquivoParcEmissao.Clone();
                    arquivoCapa.RemoverLinhaComAjuste(1);
                    SalvarArquivo(arquivoCapa);
                    triplice.ArquivoParcEmissao.RemoverLinhaComAjuste(0);
                }

            }

        }

         protected void AtualizarLinhaDeReferenciaParaComissao(ILinhaArquivo linhaParc, ILinhaArquivo linhaComissao)
        {
            ArquivoUtils.IgualarCamposQueExistirem(linhaParc, linhaComissao, logger);
        }

        public override void FinalizarAlteracaoArquivo(IArquivo _arquivo)
        {
            base.FinalizarAlteracaoArquivo(_arquivo);
        }

        protected override void SalvarArquivo()
        {
            base.SalvarArquivo();
        }
    }
}
