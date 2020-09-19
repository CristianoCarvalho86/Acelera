using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC233
{
    [TestClass]
    public class PROC233_Layout96_PAPCARD : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9339()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-9339:FG05 - PROC 233 - C/C - PAPCARD - COMISSAO - Contrato com registro rejeitado - Arquivos diferentes");
            //Envia parc normal
            AlterarCobertura(false);

            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(ref arquivo);
            contratoRegras.CriarNovoContrato(0,arquivo);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo);
            AdicionarNovaCoberturaNaEmissao(arquivo, dados);

            SalvarArquivo();

            //EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoParc = arquivo.Clone();


            arquivo = comissaoRegras.CriarComissao<Arquivo_Layout_9_4_2_new_EmsComissao>(OperadoraEnum.PAPCARD, arquivoParc);
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_EmsComissao>(ref arquivo);
            AlterarLinha(0, "CD_RAMO", "00");
            RemoverLinhaComAjusteDeFooter(1);

            SalvarArquivo();

            arquivo = comissaoRegras.CriarComissao<Arquivo_Layout_9_4_2_new_EmsComissao>(OperadoraEnum.PAPCARD, arquivoParc);
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_EmsComissao>(ref arquivo);
            RemoverLinhaComAjusteDeFooter(0);
            SalvarArquivo();

            //ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "233", 1);
        }

    }
}
