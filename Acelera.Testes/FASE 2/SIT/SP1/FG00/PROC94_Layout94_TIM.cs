using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC94_Layout94_TIM : TesteBase
    {
        /// <summary>
        /// No Body do arquivo CLIENTE no campo TIPO_REGISTRO informar código 03
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1324_CLIENTE_TipoRegistro03()
        {

        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO no campo TIPO_REGISTRO informar código 03
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1325_PARC_EMISSAO_TipoRegistro03()
        {

        }

        /// <summary>
        /// No Body do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 03
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1326_EMS_COMISSAO_TipoRegistro03()
        {

        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 03
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1327_OCR_COBRANCA_TipoRegistro03()
        {

        }

        /// <summary>
        /// No Body do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO informar código 03
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1328_LANCTO_COMISSAO_TipoRegistro03()
        {

        }

        /// <summary>
        /// No Body do arquivo SINISTRO no campo TIPO_REGISTRO informar código 03
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1329_SINISTRO_TipoRegistro03()
        {

        }

        /// <summary>
        /// Não informar nenhum registro do Body no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1254_COMISSAO_SemBody()
        {
        }

        /// <summary>
        /// Não informar nenhum registro do Body no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1257_SINISTRO_SemBody()
        {
        }

        /// <summary>
        /// Não informar nenhum registro do Body no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1256_LANCTO_COMISSAO_SemBody()
        {
        }

        /// <summary>
        /// Não informar nenhum registro do Body no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1255_OCR_COBRANCA_SemBody()
        {
        }

        /// <summary>
        /// Não informar nenhum registro do Body no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1253_PARC_EMISSAO_SemBody()
        {
        }

        /// <summary>
        /// Não informar nenhum registro do Body no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1252_CLIENTE_SemBody()
        {
        }

        /// <summary>
        /// No Body do arquivo SINISTRO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1251_SINISTRO_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Body do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1250_LANCTO_COMISSAO_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1249_OCR_COBRANCA_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Body do arquivo EMS_COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1248_COMISSAO_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1247_PARC_EMISSAO_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Body do arquivo CLIENTE no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1246_CLIENTE_SemTipoRegistro()
        {
        }
    }
}
