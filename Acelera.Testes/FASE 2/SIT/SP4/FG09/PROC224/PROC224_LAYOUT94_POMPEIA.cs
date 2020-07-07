using Acelera.Data;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Acelera.Domain.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC224
{
    [TestClass]
    public class PROC224_LAYOUT94_POMPEIA : TestesFG09
    {
        private OperadoraEnum operacaoDoTeste => OperadoraEnum.POMPEIA;

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5263()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5263", "FG09 - PROC224 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(operacaoDoTeste,true);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
             
            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10"));


            EnviarParaOds(arquivo);
            var arquivoods2 = arquivo.Clone();

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10", "02", "5"));
             

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "224", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5264()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5264", "FG09 - PROC224 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(operacaoDoTeste);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
           // 
            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "11"));


            EnviarParaOds(arquivo);
            var arquivoods2 = arquivo.Clone();

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "11", "02", "5")); 
            // 

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "224", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5265()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5265", "FG09 - PROC224 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(operacaoDoTeste, false);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
             
            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10"));


            EnviarParaOds(arquivo);
            var arquivoods2 = arquivo.Clone();

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "11", "02", "5")); 
             

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "224", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5266()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5266", "FG09 - PROC224 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(operacaoDoTeste, false, 2);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
             
            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(1), "11"));


            EnviarParaOds(arquivo);
            var arquivoods2 = arquivo.Clone();

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(1), "10", "02", "5"));
             

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "224", 1);

        }

    }
}
