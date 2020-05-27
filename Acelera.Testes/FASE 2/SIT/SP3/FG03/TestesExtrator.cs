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
        public void SAP_3801_PARCEMS_AUTO_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem(""));

            //ALTERAR O VALOR SELECIONADO
            RemoverLinhasExcetoAsPrimeiras(1);
            SelecionarLinhaParaValidacao(0);
            ValidarCdContratoDisponivel(ObterValor(0, "CD_CONTRATO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            ValidarCdTpaNaParametroGlobal(ObterValorHeader("CD_TPA"));

            ValidarRegistroNaoExisteNaODSParcela(ObterValorHeader("CD_TPA"), ObterValor(0, "CD_CONTRATO"), ObterValor(0, "NR_SEQUENCIAL_EMISSAO"));

            ValidaTabelasTemporariasSGS(ObterValorHeader("CD_ITEM"), ObterValorHeader("CD_CONTRATO"), ObterValor(0, "NR_SEQUENCIAL_EMISSAO"), ObterValor(0, "CD_CLIENTE"));

            ChamarExecucao(FG03_Tarefas.Sinistro.ObterTexto());

            ValidarStageCliente();


        }

    }
}
