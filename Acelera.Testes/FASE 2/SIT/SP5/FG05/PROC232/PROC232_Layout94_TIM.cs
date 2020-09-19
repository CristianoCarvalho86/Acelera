using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC232
{
    [TestClass]
    public class PROC232_Layout94_TIM : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9318()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9319", "SAP-9318:FG05 - PROC 232 - C/C - PARCELA - ID_TRANSACAO já processado - Capa");
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            arquivo.AlterarLinha(0, "CD_MOVTO_COBRANCA", "01");

            EnviarParaOdsAlterandoCliente(arquivo);

            var arquivoods1 = arquivo.Clone();

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);
            ArquivoUtils.IgualarCamposQueExistirem(arquivoods1, arquivo);
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "232", 1);
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9319()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9319", "SAP-9319:FG05 - PROC 232 - C/C - PARCELA - ID_TRANSACAO já processado - Emissão");
            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.TIM);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);
            CriarNovaLinhaParaEmissao(arquivoods1, 0);
            arquivoods1.AlterarLinha(0, "CD_MOVTO_COBRANCA", "01");
            arquivoods1.AlterarLinha(1, "CD_MOVTO_COBRANCA", "01");

            EnviarParaOdsAlterandoCliente(arquivoods1);

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 2, OperadoraEnum.TIM);
            ArquivoUtils.IgualarCamposQueExistirem(arquivoods1, arquivo);
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "02");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "232", 1);
        }
    }
}
