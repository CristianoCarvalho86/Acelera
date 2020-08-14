﻿using Acelera.Data;
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

        protected virtual void ExecutarEValidarFG06(ITriplice triplice,
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
            //ValidarTeste();
        }

        public override void CarregarTriplice(OperadoraEnum operadora)
        {
            if (operadora == OperadoraEnum.LASA)
                triplice = new TripliceLASA(1, logger, ref valoresAlteradosBody);
            else if (operadora == OperadoraEnum.SOFTBOX)
                triplice = new TripliceSoftbox(1, logger, ref valoresAlteradosBody);
            else if (operadora == OperadoraEnum.POMPEIA)
                triplice = new TriplicePOMPEIA(1, logger, ref valoresAlteradosBody);
            else if (operadora == OperadoraEnum.VIVO)
                triplice = new TripliceVIVO(1, logger, ref valoresAlteradosBody);
            else if (operadora == OperadoraEnum.TIM)
                triplice = new TripliceTIM(1, logger, ref valoresAlteradosBody);
            else if (operadora == OperadoraEnum.QUEROQUERO)
                triplice = new TripliceQUEROQUERO(1, logger, ref valoresAlteradosBody);
        }

        protected void AlteracoesPadraoDaTrinca(ITriplice triplice, bool geraCliente = true)
        {
            triplice.AlterarParcEComissao(0, "ID_TRANSACAO_CANC", "");
            triplice.AlterarParcEComissao(0, "CD_TIPO_EMISSAO", ParametrosRegrasEmissao.CarregaTipoEmissaoParaPrimeiraLinhaDaEmissao(triplice.Operadora));
            triplice.AlterarParcEComissao(0, "NR_ENDOSSO", ParametrosRegrasEmissao.CarregaPrimeiroNumeroEndosso(triplice.ArquivoParcEmissao[0], triplice.Operadora));
            triplice.AlterarParcEComissao(0, "NR_PARCELA", ParametrosRegrasEmissao.CarregaPrimeiroNrParcela(triplice.Operadora));
            triplice.AlterarParcEComissao(0, "NR_SEQUENCIAL_EMISSAO", ParametrosRegrasEmissao.CarregaPrimeiroNumeroSequencialEmissao(triplice.Operadora));

            CriarNovoContrato(0, triplice.ArquivoParcEmissao);
            triplice.AlterarParcEComissao(0, "CD_CONTRATO", triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            triplice.AlterarParcEComissao(0, "NR_APOLICE", triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            triplice.AlterarParcEComissao(0, "NR_PROPOSTA", triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            if (geraCliente)
                triplice.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(7));
            else
                triplice.AlterarCliente(0, "CD_CLIENTE", dados.ObterCdClienteParceiro(true, triplice.ArquivoParcEmissao.Header[0]["CD_TPA"]));


            triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_MOVTO_COBRANCA", "01");
            var data = dados.ObterDataDoBanco();
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("DT_EMISSAO", data);
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("DT_INICIO_VIGENCIA", data);
            triplice.AlterarTodasAsLinhasQueContenhamOCampo("DT_FIM_VIGENCIA", SomarData(data, 365));
        }

         protected void AtualizarLinhaDeReferenciaParaComissao(LinhaArquivo linhaParc, LinhaArquivo linhaComissao)
        {
            IgualarCamposQueExistirem(linhaParc, linhaComissao);
        }

        public override void FinalizarAlteracaoArquivo()
        {
            base.FinalizarAlteracaoArquivo();
        }

        protected override void SalvarArquivo()
        {
            base.SalvarArquivo();
        }
    }
}
