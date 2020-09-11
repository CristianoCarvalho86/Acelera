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
    public class PROC246_Layout96_PAPCARD: TestesFG09
    {
        [TestMethod]
        public void SAP_9507()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", ":SAP-9507:FG09 - PROC 246 - PAPCARD - COMISSAO - Cancelamento de comissão diferente do emitido - 2 tipos");

            AlterarCobertura(false);
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(ref arquivo);
            CriarNovoContrato(0);

            AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            AdicionarNovaCoberturaNaEmissao(arquivo, dados, 0, dados.ObterCoberturaPeloCodigo("01433",true));
            ConfereQtdLinhas(arquivo, 2);

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoParc1 = arquivo.Clone();
            //LimparValidacao();

            arquivo = CriarComissao<Arquivo_Layout_9_4_2_new_EmsComissao>(OperadoraEnum.PAPCARD, arquivo);
            AlterarLayout<Arquivo_Layout_9_6_EmsComissao>(ref arquivo);
            EnviarParaOdsAlterandoCliente(arquivo);

            ConfereQtdLinhas(arquivo, 2);
            //LimparValidacao();

            arquivo = arquivoParc1;
            arquivo.AdicionarLinha(CriarLinhaCancelamento(arquivoParc1[0], "10", "02"));
            RemoverLinhaComAjusteDeFooter(0);
            RemoverLinhaComAjusteDeFooter(0);
            ConfereQtdLinhas(arquivo, 1);
            SelecionarLinhaParaValidacao(0);

            SalvarArquivo();
            ExecutarEValidarAteFg02(arquivo);

            arquivo = CriarComissao<Arquivo_Layout_9_4_2_new_EmsComissao>(OperadoraEnum.PAPCARD, arquivo);
            AlterarLayout<Arquivo_Layout_9_6_EmsComissao>(ref arquivo);
            ConfereQtdLinhas(arquivo, 1);
            SalvarArquivo();
            ExecutarEValidarAteFg02(arquivo);
        }
    }
}
