using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC400_Layout93_VIVO : TesteBase
    {
        /// <summary>
        /// No Header do arquivo SINISTRO no campo NOMEARQ informar o nome EMSCMS respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1118_SINISTRO_NOMEARQ_EMSCMS()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo NOMEARQ informar o nome CLIENTE respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1117_LANCTO_COMISSAO_NOMEARQ_CLIENTE()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo NOMEARQ informar o nome PARCEMSAUTO respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1116_OCR_COBRANCA_NOMEARQ_PARCEMSAUTO()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo NOMEARQ informar o nome SINISTRO respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1115_EMS_COMISSAO_NOMEARQ_SINISTRO()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO_AUTO no campo NOMEARQ informar o nome COBRANCA respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1114_PARC_EMISSAO_AUTO_NOMEARQ_COBRANCA()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo NOMEARQ informar o nome LCTCMS respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1113_CLIENTE_NOMEARQ_LCTCMS()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo NOMEARQ informar o código CLIENTE Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1179_CLIENTE_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo NOMEARQ informar o código PARCEMS Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1180_PARC_EMISSAO_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo NOMEARQ informar o código EMSCMS Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1181_EMS_COMISSAO_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo NOMEARQ informar o código COBRANCA Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1182_OCR_COBRANCA_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo NOMEARQ informar o código LCTCMS Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1183_LANCTO_COMISSAO_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo NOMEARQ informar o código SINISTRO Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1184_SINISTRO_NOMEARQ()
        {
        }

    }
}
