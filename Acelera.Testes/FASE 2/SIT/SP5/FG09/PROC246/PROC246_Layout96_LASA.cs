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
    public class PROC246_Layout96_LASA: TestesFG09
    {
        [TestMethod]
        public void SAP_9512()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-9512:FG09 - PROC 246 - LASA - COMISSAO - Cancelamento de comissão diferente do emitido - 2 tipos");

            AlterarCobertura(false);
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);
            CriarNovoContrato(0);

            AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            AdicionarNovaCoberturaNaEmissao(arquivo, dados, 0);
            ConfereQtdLinhas(arquivo, 2);
            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoParc1 = arquivo.Clone();
            LimparValidacao();

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivo);
            AlterarLinha(1, "CD_TIPO_COMISSAO", "P");
            EnviarParaOdsAlterandoCliente(arquivo);
            ConfereQtdLinhas(arquivo, 2);
            LimparValidacao();

            arquivo = arquivoParc1;
            arquivo.AdicionarLinha(CriarLinhaCancelamento(arquivoParc1[0], "10", "02"));
            RemoverLinhaComAjusteDeFooter(0);
            RemoverLinhaComAjusteDeFooter(0);
            ConfereQtdLinhas(arquivo, 1);
            SelecionarLinhaParaValidacao(0);
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
            LimparValidacao();

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivo);
            ConfereQtdLinhas(arquivo, 1);
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }

    }
}
