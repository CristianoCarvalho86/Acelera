using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC100_Layout93_VIVO : TestesFG00
    {
        /// <summary>
        /// No Header do arquivo CLIENTE no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1065_CLIENTE_SemCD_TPA()
        {
            IniciarTeste(TipoArquivo.Cliente,"1065", "No Header do arquivo CLIENTE no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo");
            
            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.CLIENTE-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TPA", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.SGS.SINISTRO-EV-/*R*/-20200211.txt"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Codigo do tpa nao encontrado.");
            ValidarTabelaDeRetorno("100");
            ValidarStages<LinhaClienteStage>(TabelasEnum.Cliente, false);
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1070_SINISTRO_SemCD_TPA()
        {
            IniciarTeste(TipoArquivo.Sinistro ,"1070", "No Header do arquivo SINISTRO no campo CD_TPA não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_TPA", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.SINISTRO-EV-/*R*/-20200209.txt"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Codigo do tpa nao encontrado.");
            ValidarTabelaDeRetorno("100");
            ValidarStages<LinhaClienteStage>(TabelasEnum.Cliente, false);
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1069_LANCTO_COMISSAO_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1068_OCR_COBRANCA_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1067_EMS_COMISSAO_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1066_PARC_EMISSAO_SemCD_TPA()
        {
        }


        /// <summary>
        /// No Header do arquivo SINISTRO no campo CD_TPA informar código 004
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1166_SINISTRO_CD_TPA_004()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo CD_TPA informar código 004
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1165_LANCTO_COMISSAO_CD_TPA_004()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo CD_TPA informar código 004
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1164_OCR_COBRANCA_CD_TPA_004()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo CD_TPA informar código 004
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1163_EMS_COMISSAO_CD_TPA_004()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO_AUTO no campo CD_TPA informar código 004
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1162_PARC_EMISSAO_AUTO_CD_TPA_004()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo CD_TPA informar código 004
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1161_CLIENTE_CD_TPA_004()
        {
        }

    }
}
