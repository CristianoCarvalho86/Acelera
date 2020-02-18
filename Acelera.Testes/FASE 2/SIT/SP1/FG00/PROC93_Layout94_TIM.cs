using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC93_Layout94_TIM : TesteBase
    {
        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1241_PARC_EMISSAO_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1242_EMS_COMISSAO_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1243_OCR_COBRANCA_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1244_LANCTO_COMISSAO_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1245_SINISTRO_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1240_CLIENTE_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1239_SINISTRO_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1238_LANCTO_COMISSAO_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1237_OCR_COBRANCA_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Trailler do arquivo COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1236_COMISSAO_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1234_CLIENTE_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1323_SINISTRO_TipoRegistro09()
        {
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1322_LANCTO_COMISSAO_TipoRegistro09()
        {
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1321_OCR_COBRANCA_TipoRegistro09()
        {
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1320_EMS_COMISSAO_TipoRegistro09()
        {
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1319_PARC_EMISSAO_TipoRegistro09()
        {
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1318_CLIENTE_TipoRegistro09()
        {
        }
    }
}
