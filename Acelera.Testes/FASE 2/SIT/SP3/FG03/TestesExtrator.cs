using Acelera.Domain.Entidades.SGS;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Testes.DataAccessRep;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG03
{
    [TestClass]
    public class TestesExtrator : TestesFG03
    {

        /// <summary>
        /// Informar no campo Cd_PRODUTO um produto parametrizado para o CD_TPA (CD_OPERAÇÃO) na tabela TAB_PRM_PRD_COBERTURA_7009
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4726()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4726", "");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem(""));

            //ALTERAR O VALOR SELECIONADO
            RemoverLinhasExcetoAsPrimeiras(1);
            SelecionarLinhaParaValidacao(0);
            ValidarCdContratoDisponivel(ObterValor(0, "CD_CONTRATO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(true, false);

            //Garantir operação parametrizada
            ValidarCdTpaNaParametroGlobal(ObterValorHeader("CD_TPA"));

            //Garantir sinistro não possui parcela na ods
            ValidarRegistroNaoExisteNaODSParcela(ObterValorHeader("CD_TPA"), ObterValor(0, "CD_CONTRATO"), ObterValor(0, "NR_SEQUENCIAL_EMISSAO"));

            //Executar MASP1602B00
            Executar();

            //Verificar tabelas temporárias estão preenchidas
            ValidaTabelasTemporariasSGS(ObterValorHeader("CD_ITEM"), ObterValorHeader("CD_CONTRATO"), ObterValor(0, "NR_SEQUENCIAL_EMISSAO"), ObterValor(0, "CD_CLIENTE"));

            //Executar FG03
            ChamarExecucao(FG03_Tarefas.Sinistro.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNAFG00);
            ValidarStageParcela(CodigoStage.AprovadoNAFG00);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false,true);

            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNaFG01);
            ValidarStageParcela(CodigoStage.AprovadoNegocioSemDependencia);

        }

    }
}
