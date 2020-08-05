using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC199
{
    [TestClass]
    public class PROC199_LAYOUT96_LASA : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_6106()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6106", "FG09 - PROC199 - ");
            AlterarCobertura(false);

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 1, "", false);
            AlterarLinha(0, "CD_CORRETOR", "0002783");
            AlterarLinha(0, "CD_COBERTURA", "01592");
            AlterarLinha(0, "CD_RAMO", "71");
            AlterarLinha(0, "CD_PRODUTO", "71724");

            EnviarParaOdsAlterandoCliente(arquivoodsParcela);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true, false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");

            EnviarParaOdsAlterandoCliente(arquivoodsComissao);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, arquivoodsParcela, true);


            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "199", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_6107()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6107", "FG09 - PROC199 - ");
            AlterarCobertura(false);

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 1, "", false);
            AlterarLinha(0, "CD_CORRETOR", "0002783");
            AlterarLinha(0, "CD_COBERTURA", "01592");
            AlterarLinha(0, "CD_RAMO", "71");
            AlterarLinha(0, "CD_PRODUTO", "71724");

            EnviarParaOdsAlterandoCliente(arquivoodsParcela);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true, false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");

            EnviarParaOdsAlterandoCliente(arquivoodsComissao);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, arquivoodsParcela, true);


            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela, true);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "199", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_6108()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6108", "FG09 - PROC199 - ");
            AlterarCobertura(false);

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 1, "", false);
            AlterarLinha(0, "CD_CORRETOR", "0002783");
            AlterarLinha(0, "CD_COBERTURA", "01592");
            AlterarLinha(0, "CD_RAMO", "71");
            AlterarLinha(0, "CD_PRODUTO", "71724");

            EnviarParaOdsAlterandoCliente(arquivoodsParcela);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true, false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");

            EnviarParaOdsAlterandoCliente(arquivoodsComissao);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, arquivoodsParcela, true);


            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "A");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "199", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_6109()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6109", "FG09 - PROC199 - ");
            AlterarCobertura(false);

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 1, "", false);
            AlterarLinha(0, "CD_CORRETOR", "0002783");
            AlterarLinha(0, "CD_COBERTURA", "01592");
            AlterarLinha(0, "CD_RAMO", "71");
            AlterarLinha(0, "CD_PRODUTO", "71724");

            EnviarParaOdsAlterandoCliente(arquivoodsParcela);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true, false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");

            EnviarParaOdsAlterandoCliente(arquivoodsComissao);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, arquivoodsParcela, true);


            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "CA");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "199", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_6110()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6110", "FG09 - PROC199 - ");
            AlterarCobertura(false);

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 1, "", false);
            AlterarLinha(0, "CD_CORRETOR", "0002783");
            AlterarLinha(0, "CD_COBERTURA", "01592");
            AlterarLinha(0, "CD_RAMO", "71");
            AlterarLinha(0, "CD_PRODUTO", "71724");

            EnviarParaOdsAlterandoCliente(arquivoodsParcela);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true, false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");

            EnviarParaOdsAlterandoCliente(arquivoodsComissao);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, arquivoodsParcela, true);


            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "199", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_6111()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6111", "FG09 - PROC199 - ");
            AlterarCobertura(false);

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 1, "", false);
            AlterarLinha(0, "CD_CORRETOR", "0002783");
            AlterarLinha(0, "CD_COBERTURA", "01592");
            AlterarLinha(0, "CD_RAMO", "71");
            AlterarLinha(0, "CD_PRODUTO", "71724");

            EnviarParaOdsAlterandoCliente(arquivoodsParcela);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true, false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");

            EnviarParaOdsAlterandoCliente(arquivoodsComissao);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, arquivoodsParcela, true);


            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "A");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "199", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_6112()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6110", "FG09 - PROC199 - ");
            AlterarCobertura(false);

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 1, "", false);
            AlterarLinha(0, "CD_CORRETOR", "0002783");
            AlterarLinha(0, "CD_COBERTURA", "01592");
            AlterarLinha(0, "CD_RAMO", "71");
            AlterarLinha(0, "CD_PRODUTO", "71724");

            EnviarParaOdsAlterandoCliente(arquivoodsParcela);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true, false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");

            EnviarParaOdsAlterandoCliente(arquivoodsComissao);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, arquivoodsParcela, true);


            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela, true);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "CA");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "199", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_6113()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6113", "FG09 - PROC199 - ");
            AlterarCobertura(false);

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 1, "", false);
            AlterarLinha(0, "CD_CORRETOR", "0002783");
            AlterarLinha(0, "CD_COBERTURA", "01592");
            AlterarLinha(0, "CD_RAMO", "71");
            AlterarLinha(0, "CD_PRODUTO", "71724");

            EnviarParaOdsAlterandoCliente(arquivoodsParcela);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true, false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "A");

            EnviarParaOdsAlterandoCliente(arquivoodsComissao);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, arquivoodsParcela, true);


            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela, true);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "199", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_6114()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6114", "FG09 - PROC199 - ");
            AlterarCobertura(false);

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 1, "", false);
            AlterarLinha(0, "CD_CORRETOR", "0002783");
            AlterarLinha(0, "CD_COBERTURA", "01592");
            AlterarLinha(0, "CD_RAMO", "71");
            AlterarLinha(0, "CD_PRODUTO", "71724");

            EnviarParaOdsAlterandoCliente(arquivoodsParcela);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true, false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "A");

            EnviarParaOdsAlterandoCliente(arquivoodsComissao);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, arquivoodsParcela, true);


            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela, true);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "199", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_6115()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6115", "FG09 - PROC199 - ");
            AlterarCobertura(false);

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 1, "", false);
            AlterarLinha(0, "CD_CORRETOR", "0002783");
            AlterarLinha(0, "CD_COBERTURA", "01592");
            AlterarLinha(0, "CD_RAMO", "71");
            AlterarLinha(0, "CD_PRODUTO", "71724");

            EnviarParaOdsAlterandoCliente(arquivoodsParcela);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true, false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "A");

            EnviarParaOdsAlterandoCliente(arquivoodsComissao);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, arquivoodsParcela, true);


            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela, true);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "CA");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "199", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_6116()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6116", "FG09 - PROC199 - ");
            AlterarCobertura(false);

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 1, "", false);
            AlterarLinha(0, "CD_CORRETOR", "0002783");
            AlterarLinha(0, "CD_COBERTURA", "01592");
            AlterarLinha(0, "CD_RAMO", "71");
            AlterarLinha(0, "CD_PRODUTO", "71724");

            EnviarParaOdsAlterandoCliente(arquivoodsParcela);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true, false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "CA");

            EnviarParaOdsAlterandoCliente(arquivoodsComissao);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, arquivoodsParcela, true);


            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela, true);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "199", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_6117()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6117", "FG09 - PROC199 - ");
            AlterarCobertura(false);

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 1, "", false);
            AlterarLinha(0, "CD_CORRETOR", "0002783");
            AlterarLinha(0, "CD_COBERTURA", "01592");
            AlterarLinha(0, "CD_RAMO", "71");
            AlterarLinha(0, "CD_PRODUTO", "71724");

            EnviarParaOdsAlterandoCliente(arquivoodsParcela);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true, false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");

            EnviarParaOdsAlterandoCliente(arquivoodsComissao);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, arquivoodsParcela, true);
            AlterarHeader("VERSAO", "9.6");


            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela, true);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_6118()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6118", "FG09 - PROC199 - ");
            AlterarCobertura(false);

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 1, "", false);
            AlterarLinha(0, "CD_CORRETOR", "0002783");
            AlterarLinha(0, "CD_COBERTURA", "01592");
            AlterarLinha(0, "CD_RAMO", "71");
            AlterarLinha(0, "CD_PRODUTO", "71724");

            EnviarParaOdsAlterandoCliente(arquivoodsParcela);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true, false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");

            EnviarParaOdsAlterandoCliente(arquivoodsComissao);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, arquivoodsParcela, true);


            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela, true);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_6119()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6119", "FG09 - PROC199 - ");
            AlterarCobertura(false);

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 1, "", false);
            AlterarLinha(0, "CD_CORRETOR", "0002783");
            AlterarLinha(0, "CD_COBERTURA", "01592");
            AlterarLinha(0, "CD_RAMO", "71");
            AlterarLinha(0, "CD_PRODUTO", "71724");

            EnviarParaOdsAlterandoCliente(arquivoodsParcela);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true, false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");

            EnviarParaOdsAlterandoCliente(arquivoodsComissao);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, arquivoodsParcela, true);
            AlterarHeader("VERSAO", "9.6");


            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela, true);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_6120()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6120", "FG09 - PROC199 - ");
            AlterarCobertura(false);

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 1, "", false);
            AlterarLinha(0, "CD_CORRETOR", "0002783");
            AlterarLinha(0, "CD_COBERTURA", "01592");
            AlterarLinha(0, "CD_RAMO", "71");
            AlterarLinha(0, "CD_PRODUTO", "71724");

            EnviarParaOdsAlterandoCliente(arquivoodsParcela);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true, false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "CA");

            EnviarParaOdsAlterandoCliente(arquivoodsComissao);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, arquivoodsParcela, true);


            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela, true);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "CA");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_6121()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6121", "FG09 - PROC199 - ");
            AlterarCobertura(false);

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 1, "", false);
            AlterarLinha(0, "CD_CORRETOR", "0002783");
            AlterarLinha(0, "CD_COBERTURA", "01592");
            AlterarLinha(0, "CD_RAMO", "71");
            AlterarLinha(0, "CD_PRODUTO", "71724");

            EnviarParaOdsAlterandoCliente(arquivoodsParcela);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela,"", false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "A");

            EnviarParaOdsAlterandoCliente(arquivoodsComissao);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, arquivoodsParcela, true);


            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "A");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }
    }
}
