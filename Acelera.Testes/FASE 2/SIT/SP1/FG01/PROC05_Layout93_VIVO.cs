using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC05_Layout93_VIVO : TesteBase
    {

        /// <summary>
        /// No Body do arquivo CLIENTE não informar valor nos seguintes campos: CD_CLIENTE NM_CLIENTE NR_CNPJ_CPF EN_ENDERECO EN_NUMERO EN_BAIRRO EN_CIDADE EN_UF EN_CEP EN_PAIS TIPO SEXO DT_NASCIMENTO
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2228_CLIENTE_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO_AUTO não informar valor nos seguintes campos: CD_INTERNO_RESSEGURADOR CD_RAMO CD_MOVTO_COBRANCA CD_SEGURADORA CD_SUCURSAL CD_CORRETOR CD_TIPO_OPERACAO CD_TIPO_EMISSAO CD_FORMA_PAGTO CD_CATEGORIA CD_FRANQUIA CD_SUSEP_CONTRATO CD_SISTEMA CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_COBERTURA CD_ITEM CD_CLIENTE CD_MOEDA DT_REFERENCIA NR_PROPOSTA DT_PROPOSTA DT_EMISSAO DT_INICIO_VIGENCIA DT_FIM_VIGENCIA
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2229_PARC_EMISSAO_AUTO_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo EMS_COMISSAO não informar valor nos seguintes campos: CD_INTERNO_RESSEGURADOR CD_SEGURADORA CD_CORRETOR CD_RAMO CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_ITEM CD_TIPO_COMISSAO CD_COBERTURA VL_COMISSAO VL_BASE_CALCULO PC_COMISSAO PC_PARTICIPACAO CD_SISTEMA
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2230_EMS_COMISSAO_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA não informar valor nos seguintes campos: CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_OCORRENCIA DT_OCORRENCIA VL_PREMIO_PAGO CD_SISTEMA
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2231_OCR_COBRANCA_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos: CD_RAMO CD_CORRETOR CD_CONTRATO NR_SEQ_EMISSAO CD_TIPO_COMISSAO NR_PARCELA NR_APOLICE NR_ENDOSSO CD_EXTRATO_COMISSAO NR_MES_REFERENCIA CD_LANCAMENTO VL_COMISSAO_PAGO DT_PAGAMENTO DT_BAIXA CD_SISTEMA CD_TIPO_LANCAMENTO
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2232_LANCTO_COMISSAO_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo SINISTRO não informar valor nos seguintes campos: CD_INTERNO_RESSEGURADOR CD_SEGURADORA CD_TIPO_MOVIMENTO DT_MOVIMENTO CD_AVISO CD_SINISTRO CD_RAMO CD_CLIENTE DT_AVISO DT_OCORRENCIA DT_REGISTRO CD_CAUSA CD_CONTRATO NR_SEQ_EMISSAO NR_APOLICE CD_ITEM CD_MOVIMENTO VL_MOVIMENTO TP_SINISTRO
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2233_OCR_SINISTRO_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2227_SINISTRO_SemCampObrig_Header()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2224_EMS_COMISSAO_SemCampObrig_Header()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2225_OCR_COBRANCA_SemCampObrig_Header()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2226_LANCTO_COMISSAO_SemCampObrig_Header()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO_AUTO não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2223_PARC_EMISSAO_AUTO_SemCampObrig_Header()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2222_CLIENTE_SemCampObrig_Header()
        {
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2234_CLIENTE_SemCampObrig_Trailler()
        {
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO_AUTO não informar valor nos seguintes campos: NR_APOLICE NR_ENDOSSO DT_VENCIMENTO VL_PREMIO_LIQUIDO VL_IOF VL_PREMIO_TOTAL VL_TAXA_MOEDA CD_STATUS_EMISSAO VL_IS VL_FRANQUIA CD_PRODUTO ID_TRANSACAO CD_UF_RISCO CD_MODALIDADE CD_MODELO ANO_MODELO VL_PERC_FATOR VL_PERC_BONUS CD_CLASSE_BONUS SEXO_CONDUTOR DT_NASC_CONDUTOR TEMPO_HAB CD_UTILIZACAO CEP_UTILIZACAO CEP_PERNOITE 
        /// No Trailler do arquivo PARC_EMISSAO_AUTO não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2235_PARC_EMISSAO_AUTO_SemCampObrig_Body_Trailler()
        {
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2236_PARC_EMS_COMISSAO_SemCampObrig_Trailler()
        {
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2237_OCR_COBRANCA_SemCampObrig_Trailler()
        {
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2238_LANCTO_COMISSAO_SemCampObrig_Trailler()
        {
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2239_SINISTRO_SemCampObrig_Trailler()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2475_CLIENTE()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2476_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2477_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2478_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2479_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2480_SINISTRO()
        {
        }

    }
}
