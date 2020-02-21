using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC07_Layout94_Pompeia : TesteBase
    {

        /// <summary>
        /// No Header do arquivo CLIENTE não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_ARQ CD_TPA (Será criticada na C.I)
        /// No Body do arquivo CLIENTE não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos CD_CLIENTE  
        /// No Trailler do arquivo CLIENTE não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos QT_LIN (Será criticada na C.I)
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2410_CLIENTE_SemCampoNum_Header_Body_Trailler()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_ARQ CD_TPA (Será criticada na C.I)
        /// No Body do arquivo PARC_EMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_PARCELA CD_CLIENTE VL_JUROS VL_DESCONTO VL_PREMIO_LIQUIDO VL_IOF VL_ADIC_FRACIONADO VL_CUSTO_APOLICE VL_PREMIO_TOTAL VL_TAXA_MOEDA VL_LMI VL_IS VL_PERCENTUAL_COSSEGURO VL_PREMIO_CEDIDO VL_COMISSAO_CEDIDO VL_FRANQUIA ANO_MODELO VL_PERC_FATOR VL_PERC_BONUS TEMPO_HAB CEP_UTILIZACAO CEP_PERNOITE
        /// No Trailler do arquivo PARC_EMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos QT_LIN (Será criticada na C.I)
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2411_PARC_EMISSAO_SemCampoNum_Header_Body_Trailler()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_ARQ CD_TPA (Será criticada na C.I)
        /// No Body do arquivo EMS_COMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_ITEM VL_COMISSAO VL_BASE_CALCULO PC_COMISSAO PC_PARTICIPACAO 
        /// No Trailler do arquivo EMS_COMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos QT_LIN (Será criticada na C.I)
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2412_EMS_COMISSAO_SemCampoNum_Header_Body_Trailler()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_ARQ CD_TPA (Será criticada na C.I)
        /// No Body do arquivo OCR_COBRANCA não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos CD_TIPO_MOVIMENTO CD_AVISO CD_RAMO CD_CLIENTE CD_MOVIMENTO VL_MOVIMENTO VL_TAXA_PAGTO EN_CEP_BENEFICIARIO CD_BANCO_SEG NR_AGENCIA_SEG NR_CONTA_SEG NR_SEQ_MOV VL_CEDIDO CD_BANCO NR_AGENCIA NR_CONTA
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2413_OCR_COBRANCA_SemCampoNum_Header_Body_Trailler()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_ARQ CD_TPA (Será criticada na C.I)
        /// No Body do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_PARCELA CD_OCORRENCIA VL_DESCONTO VL_PREMIO_PAGO VL_MULTA VL_IOF_RETIDO VL_ADC_FRC VL_ADC_FRC_DVI VL_MULTA_DEVIDO VL_JUROS_COBRADO VL_JUROS_DEVIDO VL_DIF_PREMIO
        /// No Trailler do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos QT_LIN (Será criticada na C.I)
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2414_LANCTO_COMISSAO_SemCampoNum_Header_Body_Trailler()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_ARQ CD_TPA (Será criticada na C.I)
        /// No Body do arquivo SINISTRO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_PARCELA CD_EXTRATO_COMISSAO CD_LANCAMENTO VL_COMISSAO_PAGO CD_TIPO_LANCAMENTO
        /// No Trailler do arquivo SINISTRO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos QT_LIN (Será criticada na C.I)
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2415_SINISTRO_SemCampoNum_Header_Body_Trailler()
        {
        }

        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2525_CLIENTE()
        {
        }

        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2526_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2527_EMS_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2528_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2529_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2530_SINISTRO()
        {
        }

    }
}
