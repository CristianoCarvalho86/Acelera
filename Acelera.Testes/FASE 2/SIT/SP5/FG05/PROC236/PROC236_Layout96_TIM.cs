using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC236
{
    [TestClass]
    public class PROC236_Layout96_TIM : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9386()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-9386:FG05 - PROC 236 - tim - PARCELA - Registros do mesmo contrato c/ vig. Dif. - Arquivos diferentes");
            //Envia parc normal
            AlterarCobertura(false);
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-9999-20200831.txt"));
            RemoverLinhaComAjusteDeFooter(0);
            RemoverLinhaComAjusteDeFooter(2);

            CriarNovoContrato(0,arquivo,"",true);
            var cdContrato = arquivo[0]["CD_CONTRATO"];


            SelecionarLinhaParaValidacao(0);
            //EnviarParaOds(arquivo);
            SalvarArquivo();
            //SelecionarLinhaParaValidacao(0);
            ValidarFGsAnteriores();

            var cdCliente = arquivo[0]["CD_CLIENTE"];

            LimparValidacao();

            //recarregando o arquivo e colocando apenas a segunda cobertura
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-9999-20200831.txt"));
            RemoverLinhaComAjusteDeFooter(1);
            RemoverLinhaComAjusteDeFooter(1);

            CriarNovoContrato(0, arquivo, cdContrato, true);

            arquivo.AlterarTodasAsLinhas("CD_CLIENTE", cdCliente);

            //SalvarArquivo();

            //ValidarFGsAnteriores();

            AlterarLinha(0, "DT_INICIO_VIGENCIA", SomarData(arquivo[0]["DT_INICIO_VIGENCIA"], 30));
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(arquivo[0]["DT_FIM_VIGENCIA"], 30));
            AlterarLinha(1, "DT_INICIO_VIGENCIA", SomarData(arquivo[0]["DT_INICIO_VIGENCIA"], 30));
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData(arquivo[0]["DT_FIM_VIGENCIA"], 30));


            SelecionarLinhaParaValidacao(0);
            SalvarArquivo();

            ValidarFGsAnteriores();
            //ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "236", 1);
        }
    }
}
