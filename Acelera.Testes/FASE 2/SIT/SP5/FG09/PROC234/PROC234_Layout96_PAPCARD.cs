using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG09.PROC234
{
    [TestClass]
    public class PROC234_Layout96_PAPCARD: TestesFG09
    {
        [TestMethod]
        public void SAP_9495()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-9495:FG09 - PROC 234 - COMISSAO - Cancelamento de comissão sem emissão de comissão");

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(ref arquivo);
            CriarNovoContrato(0);

            AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            SalvarArquivo();

            //EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoParc1 = arquivo.Clone();
            LimparValidacao();


            arquivo.AdicionarLinha(CriarLinhaCancelamento(arquivoParc1[0], "10", "02"));
            RemoverLinhaComAjusteDeFooter(0);
            SalvarArquivo();

            //ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);

            arquivo = CriarComissao<Arquivo_Layout_9_4_2_new_EmsComissao>(OperadoraEnum.PAPCARD, arquivo);
            AlterarLayout<Arquivo_Layout_9_6_EmsComissao>(ref arquivo);

            SalvarArquivo();
            //ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }
    }
}
