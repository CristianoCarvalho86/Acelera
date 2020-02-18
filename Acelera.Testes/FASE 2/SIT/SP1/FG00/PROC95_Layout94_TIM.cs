using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC95_Layout94_TIM : TesteBase
    {
        /// <summary>
        /// Não informar o registro do Header no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1266_COMISSAO_SemHeader()
        {
        }

        /// <summary>
        /// Não informar o registro do Header no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1269_SINISTRO_SemHeader()
        {
        }

        /// <summary>
        /// Não informar o registro do Header no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1268_LANCTO_COMISSAO_SemHeader()
        {
        }

        /// <summary>
        /// Não informar o registro do Header no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1267_OCR_COBRANCA_SemHeader()
        {
        }

        /// <summary>
        /// Não informar o registro do Header no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1265_PARC_EMISSAO_SemHeader()
        {
        }

        /// <summary>
        /// Não informar o registro do Header no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1264_CLIENTE_SemHeader()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1260_EMS_COMISSAO_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1263_EMS_SINISTRO_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1262_LANCTO_COMISSAO_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1261_OCR_COBRANCA_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campopo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1259_PARC_EMISSAO_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1258_CLIENTE_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Semm Critica")]
        public void SAP_1330_CLIENTE_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Semm Critica")]
        public void SAP_1331_PARC_EMISSAO_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Semm Critica")]
        public void SAP_1332_EMS_COMISSAO_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Semm Critica")]
        public void SAP_1333_OCR_COBRANCA_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Semm Critica")]
        public void SAP_1334_LANCTO_COMISSAO_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Semm Critica")]
        public void SAP_1335_SINISTRO_TipoRegistro01()
        {
        }
    }
}
