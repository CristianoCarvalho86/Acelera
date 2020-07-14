using Acelera.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG06
{
    [TestClass]
    public class Emissao_FG06 : FG06_Base
    {

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5921()
        {
            //5921:FG06 - VIVO - CLI sucesso, PARC sucesso e CMS sucesso
            InicioTesteFG06("5927", "", OperadoraEnum.VIVO);

            CriarEmissaoCompleta();

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5922()
        {
            //5922:FG06 - VIVO - CLI rejeitado, PARC sucesso e CMS sucesso
            InicioTesteFG06("5927", "", OperadoraEnum.VIVO);

            AdicionaErro(TipoArquivo.Cliente);

            SalvarTrinca();
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5923()
        {
            //FG06 - VIVO - CLI sucesso, PARC rejeitado e CMS sucesso
            InicioTesteFG06("5927", "", OperadoraEnum.POMPEIA);

            AdicionaErro(TipoArquivo.ParcEmissao);

            SalvarTrinca();
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5924()
        {
            //5924:FG06 - VIVO - CLI sucesso, PARC sucesso e CMS rejeitado
            InicioTesteFG06("5927", "", OperadoraEnum.VIVO);

            AdicionaErro(TipoArquivo.Comissao);

            SalvarTrinca();
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5925()
        {
            //POMPEIA - CLI rejeitado, PARC rejeitado e CMS sucesso
            InicioTesteFG06("5927", "", OperadoraEnum.POMPEIA);

            AdicionaErro(TipoArquivo.Cliente);
            AdicionaErro(TipoArquivo.ParcEmissao);

            SalvarTrinca();
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5926()
        {
            //POMPEIA - CLI sucesso, PARC rejeitado e CMS rejeitado
            InicioTesteFG06("5927", "", OperadoraEnum.POMPEIA);

            AdicionaErro(TipoArquivo.ParcEmissao);
            AdicionaErro(TipoArquivo.Comissao);

            SalvarTrinca();
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5927()
        {
            // POMPEIA - CLI rejeitado, PARC sucesso e CMS rejeitado
            InicioTesteFG06("5927", "", OperadoraEnum.POMPEIA);

            AdicionaErro(TipoArquivo.Cliente);
            AdicionaErro(TipoArquivo.Comissao);

            SalvarTrinca();
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5928()
        {
            // SAP-5928:FG06 - POMPEIA - CLI rejeitado, PARC rejeitado e CMS rejeitado
            InicioTesteFG06("5928", "SAP-5928:FG06 - POMPEIA - CLI rejeitado, PARC rejeitado e CMS rejeitado", OperadoraEnum.POMPEIA);

            AdicionaErro(TipoArquivo.Cliente);
            AdicionaErro(TipoArquivo.Comissao);
            AdicionaErro(TipoArquivo.ParcEmissao);

            SalvarTrinca();
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5929()
        {
            // SAP-5929:FG06 - POMPEIA - CLI rejeitado, PARC ñ enviado e CMS sucesso
            InicioTesteFG06("5929", "FG06 - POMPEIA - CLI rejeitado, PARC ñ enviado e CMS sucesso", OperadoraEnum.POMPEIA);

            AdicionaErro(TipoArquivo.Cliente);

            SalvarTrinca(true, false, true);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5930()
        {
            // SAP-5930:FG06 - LASA - CLI rejeitado, PARC sucesso e CMS ñ enviado
            InicioTesteFG06("5930", "FG06 - POMPEIA - CLI rejeitado, PARC ñ enviado e CMS sucesso", OperadoraEnum.POMPEIA);

            AdicionaErro(TipoArquivo.Cliente);

            SalvarTrinca(true, true, false);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5931()
        {
            // FG06 - LASA - CLI rejeitado ODS, PARC sucesso e CMS sucesso
            InicioTesteFG06("5931", "FG06 - LASA - CLI rejeitado ODS, PARC sucesso e CMS sucesso", OperadoraEnum.LASA);

            AdicionaErro(TipoArquivo.Cliente);

            SalvarTrinca();
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5932()
        {
            // FG06 - LASA - CLI rejeitado, PARC ñ enviado e ñ enviado
            InicioTesteFG06("5932", "FG06 - LASA - CLI rejeitado, PARC ñ enviado e ñ enviado", OperadoraEnum.LASA);

            AdicionaErro(TipoArquivo.Cliente);

            SalvarTrinca(true,false,false);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5933()
        {
            // FG06 - LASA - CLI rejeitado ODS, PARC sucesso e CMS sucesso
            InicioTesteFG06("5933", " SAP-5933:FG06 - LASA - CLI sucesso, PARC rejeitado e CMS ñ enviado", OperadoraEnum.LASA);

            AdicionaErro(TipoArquivo.Cliente);

            SalvarTrinca(true,true,false);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5934()
        {
            //  SAP-5934:FG06 - LASA - CLI ñ enviado, PARC rejeitado e CMS sucesso
            InicioTesteFG06("5934", "SAP-5934:FG06 - LASA - CLI ñ enviado, PARC rejeitado e CMS sucesso", OperadoraEnum.LASA);

            AdicionaErro(TipoArquivo.ParcEmissao);

            SalvarTrinca(false, true, true);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5935()
        {
            InicioTesteFG06("5935", "SAP-5935:FG06 - SOFTBOX - CLI ñ enviado, PARC rejeitado e CMS ñ enviado", OperadoraEnum.TIM);

            AdicionaErro(TipoArquivo.ParcEmissao);

            SalvarTrinca(false, true, false);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5936()
        {
            InicioTesteFG06("5936", "SAP-5936:FG06 - SOFTBOX - CLI ñ enviado, PARC sucesso e CMS rejeitado", OperadoraEnum.TIM);

            AdicionaErro(TipoArquivo.Comissao);

            SalvarTrinca(false, true, true);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5937()
        {
            InicioTesteFG06("5937", "SOFTBOX - CLI sucesso, PARC ñ enviado e CMS rejeitado", OperadoraEnum.TIM);

            AdicionaErro(TipoArquivo.Comissao);

            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao);



            SalvarTrinca(true, false, true);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5938()
        {
            InicioTesteFG06("5938", "SOFTBOX - CLI ñ enviado, PARC ñ enviado e CMS rejeitado", OperadoraEnum.SOFTBOX);

            AdicionaErro(TipoArquivo.Comissao);

            SalvarTrinca(false, false, true);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5939()
        {
            InicioTesteFG06("5939", "SOFTBOX - CLI ñ enviado, PARC sucesso e CMS sucesso", OperadoraEnum.SOFTBOX);


            SalvarTrinca(false, true, true);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5940()
        {
            InicioTesteFG06("5940", "SOFTBOX - CLI sucesso, PARC ñ enviado e CMS sucesso", OperadoraEnum.SOFTBOX);


            SalvarTrinca(true, false, true);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5941()
        {
            InicioTesteFG06("5941", "SOFTBOX - CLI sucesso, PARC sucesso e CMS ñ enviado", OperadoraEnum.SOFTBOX);


            SalvarTrinca(true, true, false);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5942()
        {
            InicioTesteFG06("5942", "VIVO - CLI ñ enviado, PARC ñ enviado e CMS sucesso", OperadoraEnum.VIVO);
            // parc não enviado, erro na comissão

            SalvarTrinca(false, false, true);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5944()
        {
            InicioTesteFG06("5944", "VIVO - CLI ñ enviado, PARC sucesso e CMS ñ enviado", OperadoraEnum.VIVO);
            // sem cliente da erro antes

            SalvarTrinca(false, true, false);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoComErro();
        }
    }
}
