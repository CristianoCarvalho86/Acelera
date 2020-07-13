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

        protected virtual void ExecutarEValidarFG06(ITriplice triplice,
            CodigoStage? codigoEsperadoStageCliente,
            CodigoStage? codigoEsperadoStageParcela,
            CodigoStage? codigoEsperadoStageComissao,
            string msgTabelaDeRetornoCliente,
            string msgTabelaDeRetornoParcela,
            string msgTabelaDeRetornoComissao)
        {
            //Executar FG06
            ChamarExecucao(FG06_Tarefas.Trinca.ObterTexto());

            if (codigoEsperadoStageCliente.HasValue)
            {
                ValidarStages(triplice.ArquivoCliente, triplice.ArquivoCliente.tipoArquivo.ObterTabelaStageEnum(), true, (int)codigoEsperadoStageCliente.Value);
                ValidarTabelaDeRetorno(triplice.ArquivoCliente, false, false, new string[] { msgTabelaDeRetornoCliente });
            }
            if (codigoEsperadoStageParcela.HasValue)
            {
                ValidarStages(triplice.ArquivoParcEmissao, triplice.ArquivoParcEmissao.tipoArquivo.ObterTabelaStageEnum(), true, (int)codigoEsperadoStageParcela.Value);
                ValidarTabelaDeRetorno(triplice.ArquivoParcEmissao, false, false, new string[] { msgTabelaDeRetornoParcela });
            }
            if (codigoEsperadoStageComissao.HasValue)
            {
                ValidarStages(triplice.ArquivoComissao, triplice.ArquivoComissao.tipoArquivo.ObterTabelaStageEnum(), true, (int)codigoEsperadoStageComissao.Value);
                ValidarTabelaDeRetorno(triplice.ArquivoComissao, false, false, new string[] { msgTabelaDeRetornoComissao });
            }
            ValidarTeste();
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
        }

        protected void AlteracoesPadraoDaTrinca(ITriplice triplice)
        {
            arquivo.AlterarLinhaSeExistirCampo(0, "ID_TRANSACAO_CANC", "");
            arquivo.AlterarLinhaSeExistirCampo(0, "CD_TIPO_EMISSAO", ParametrosRegrasEmissao.CarregaTipoEmissaoParaPrimeiraLinhaDaEmissao(triplice.Operadora));
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_ENDOSSO", "0");
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_PARCELA", ParametrosRegrasEmissao.CarregaPrimeiroNrParcela(triplice.Operadora));
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO", "1");

            triplice.AlterarParcEComissao(0, "CD_CONTRATO", AlterarUltimasPosicoes(triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(7)));
            triplice.AlterarParcEComissao(0, "NR_APOLICE", triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            triplice.AlterarParcEComissao(0, "NR_PROPOSTA", triplice.ArquivoParcEmissao.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"));
            triplice.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(7));
        }

        public void EnviarParaOds(Arquivo arquivo, string nomeProc = "")
        {
            SalvarArquivo();

            if (Parametros.ModoExecucao != ModoExecucaoEnum.Completo)
                return;

            ChamarExecucao(arquivo.tipoArquivo.ObterTarefaFG00Enum().ObterTexto());
            ChamarExecucao(arquivo.tipoArquivo.ObterTarefaFG01Enum().ObterTexto());

            var linhas = ValidarStages(CodigoStage.AprovadoNaFG01);

            if (arquivo.tipoArquivo == TipoArquivo.ParcEmissaoAuto)
                foreach (var linha in linhas)
                {
                    if (new string[] { "10", "11", "9", "12", "13", "21" }.Contains(linha.ObterPorColuna("CD_TIPO_EMISSAO").ValorFormatado))
                    {
                        ODSInsertParcAutoCancelamento.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                        ODSUpdateParcCancelamento.Update(logger);
                    }
                    else
                        ODSInsertParcAuto.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                }
            if (arquivo.tipoArquivo == TipoArquivo.ParcEmissao)
                foreach (var linha in linhas)
                {
                    if (new string[] { "10", "11" }.Contains(linha.ObterPorColuna("CD_TIPO_EMISSAO").ValorFormatado))
                    {
                        ODSInsertParcCancelamento.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                        ODSUpdateParcCancelamento.Update(logger);
                    }
                    else
                        ODSInsertParcData.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                }
            else if (arquivo.tipoArquivo == TipoArquivo.Cliente)
                foreach (var linha in linhas)
                    ODSInsertClienteData.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);

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
