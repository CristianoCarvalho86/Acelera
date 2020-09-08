using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC242
{
    [TestClass]
    public class PROC242_Layout94_PAPCARD : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9401()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9401", "SAP-9401:FG05 - PROC 242 - PAPCARD - PARCELA - NR_SEQ_EMISSAO já processado - Parcela 2");
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(ref arquivo);
            CriarNovoContrato(0);

            AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            var nrseq = ObterValorFormatado(0, "NR_SEQUENCIAL_EMISSAO");

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoOds = arquivo.Clone();

            //LimparValidacao();

            CriarNovaLinhaParaEmissao(arquivo);
            RemoverLinhaComAjusteDeFooter(0);

            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", nrseq);

            SalvarArquivo();

            ExecutarEValidarAteFg02(arquivo);
        }
    }
}
