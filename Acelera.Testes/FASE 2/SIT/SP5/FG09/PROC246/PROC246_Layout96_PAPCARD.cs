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
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(ref arquivo);
            contratoRegras.CriarNovoContrato(0,arquivo);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            AdicionarNovaCoberturaNaEmissao(arquivo, dados, 0, dados.ObterCoberturaPeloCodigo("01433",true));
            ConfereQtdLinhas(arquivo, 2);

            var arquivoParc1 = arquivo.Clone();
            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoParc2 = arquivo.Clone();
            //LimparValidacao();

            arquivo = comissaoRegras.CriarComissao<Arquivo_Layout_9_4_2_new_EmsComissao>(OperadoraEnum.PAPCARD, arquivo);
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_EmsComissao>(ref arquivo);
            arquivo.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "");
            arquivo.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO_EST", arquivoParc2[0]["NR_SEQUENCIAL_EMISSAO_EST"]);
            arquivo.AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", "");
            arquivo.AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO_EST", arquivoParc2[0]["NR_SEQUENCIAL_EMISSAO_EST"]);

            EnviarParaOdsAlterandoCliente(arquivo);

            ConfereQtdLinhas(arquivo, 2);
            //LimparValidacao();

            arquivo = arquivoParc1;
            arquivo.AdicionarLinha(cancelamentoRegras.CriarLinhaCancelamento(arquivoParc1[0], "10", "02"));
            RemoverLinhaComAjusteDeFooter(0);
            RemoverLinhaComAjusteDeFooter(0);
            ConfereQtdLinhas(arquivo, 1);
            SelecionarLinhaParaValidacao(0);
            AlterarLinha(0, "ID_TRANSACAO_CANC", arquivoParc2[1]["ID_TRANSACAO"]);
            SalvarArquivo();
            var arquivoParccanc = arquivo.Clone();

            ExecutarEValidarAteFg02(arquivo);

            arquivo = comissaoRegras.CriarComissao<Arquivo_Layout_9_4_2_new_EmsComissao>(OperadoraEnum.PAPCARD, arquivo);
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_EmsComissao>(ref arquivo);
            arquivo.AlterarLinha(0, "CD_TIPO_COMISSAO", "P");
            arquivo.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "");
            arquivo.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO_EST", arquivoParccanc[0]["NR_SEQUENCIAL_EMISSAO_EST"]);

            ConfereQtdLinhas(arquivo, 1);
            SalvarArquivo();
            ExecutarEValidarAteFg02(arquivo);
        }
    }
}
