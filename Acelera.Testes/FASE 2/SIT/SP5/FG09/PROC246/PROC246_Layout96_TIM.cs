using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG09.PROC246
{
    [TestClass]
    public class PROC246_Layout96_TIM: TestesFG09
    {
        [TestMethod]
        public void SAP_9512()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", ":SAP-9512:FG09 - PROC 246 - TIM - COMISSAO - Cancelamento de comissão diferente do emitido - 2 tipos");

            AlterarCobertura(false);
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-9999-20200831.txt"));
            CriarNovoContrato(0, arquivo, "", true);
            AlterarTodasAsLinhas( "CD_CLIENTE", dados.ObterCdClienteParceiro(true, arquivo.Header[0]["CD_TPA"]));

            EnviarParaOdsAlterandoCliente(arquivo);

            var arquivoParc1 = arquivo.Clone();

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.TIM, arquivo);
            RemoverLinhaComAjusteDeFooter(0);
            RemoverLinhaComAjusteDeFooter(0);

            EnviarParaOdsAlterandoCliente(arquivo);

            arquivo = arquivoParc1;
            arquivo.AdicionarLinha(CriarLinhaCancelamento(arquivoParc1[2], "10", "02"));
            arquivo.AdicionarLinha(CriarLinhaCancelamento(arquivoParc1[3], "10", "02"));
            RemoverLinhaComAjusteDeFooter(0);
            RemoverLinhaComAjusteDeFooter(0);
            RemoverLinhaComAjusteDeFooter(0);
            RemoverLinhaComAjusteDeFooter(0);
            ConfereQtdLinhas(arquivo, 2);
            //SelecionarLinhaParaValidacao(0);
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
            LimparValidacao();

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.TIM, arquivo);
            RemoverLinhaComAjusteDeFooter(0);
            ConfereQtdLinhas(arquivo, 1);
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }
    }
}
