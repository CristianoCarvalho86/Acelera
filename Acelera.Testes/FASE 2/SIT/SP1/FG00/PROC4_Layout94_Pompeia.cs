using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC4_Layout94_Pompeia : TesteBase
    {
        /// <summary>
        /// Não informar o registro do Trailler no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1377_SINISTRO_SemTrailler()
        {
        }

        /// <summary>
        /// Não informar o registro do Trailler no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1376_LANCTO_COMISSAO_SemTrailler()
        {
        }

        /// <summary>
        /// Não informar o registro do Trailler no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1375_OCR_COBRANCA_SemTrailler()
        {
        }

        /// <summary>
        /// Não informar o registro do Trailler no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1374_COMISSAO_SemTrailler()
        {
        }

        /// <summary>
        /// Não informar o registro do Trailler no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1373_PARC_EMISSAO_SemTrailler()
        {
        }

        /// <summary>
        /// Não informar o registro do Trailler no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1372_CLIENTE_SemTrailler()
        {
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1467_SINISTRO_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1466_LANCTO_COMISSAO_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1462_CLIENTE_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1465_OCR_COBRANCA_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1464_EMS_COMISSAO_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO_AUTO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1463_PARC_EMISSAO_AUTO_QT_LIN()
        {
        }

    }
}
