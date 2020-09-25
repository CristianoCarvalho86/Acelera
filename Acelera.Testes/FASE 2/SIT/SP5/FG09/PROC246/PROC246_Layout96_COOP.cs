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
    public class PROC246_Layout96_COOP: TestesFG09
    {
        [TestMethod]
        public void SAP_9512()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-9512:FG09 - PROC 246 - COOP - COMISSAO - Cancelamento de comissão diferente do emitido - 2 tipos");

            AlterarCobertura(false);
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);
            contratoRegras.CriarNovoContrato(0,arquivo);
            
            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            emissaoRegras.AdicionarNovaCoberturaNaEmissao(arquivo, dados, 0, dados.ObterCoberturaPeloCodigo("00494", true));
            ConfereQtdLinhas(arquivo, 2);
            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoParc1 = arquivo.Clone();


            arquivo = comissaoRegras.CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.COOP, arquivo, false, false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");
            AlterarLinha(1, "CD_TIPO_COMISSAO", "P");
            EnviarParaOdsAlterandoCliente(arquivo);
            //ConfereQtdLinhas(arquivo, 2);

            arquivo = arquivoParc1;
            arquivo.AdicionarLinha(cancelamentoRegras.CriarLinhaCancelamento(arquivoParc1[1], "10", "02"));
            RemoverLinhaComAjusteDeFooter(0);
            RemoverLinhaComAjusteDeFooter(0);
            ConfereQtdLinhas(arquivo, 1);
            SelecionarLinhaParaValidacao(0);
            SalvarArquivo();

            ExecutarEValidarAteFg02(arquivo);


            arquivo = comissaoRegras.CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.COOP, arquivo, false, false);
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");
            ConfereQtdLinhas(arquivo, 1);
            SalvarArquivo();
            ExecutarEValidarAteFg02(arquivo);
        }
    }
}
