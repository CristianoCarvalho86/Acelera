using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    [TestClass]
    public class Teste1
    {

        [TestMethod]
        public void TesteCPF_Criacao()
        {
            var arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(@"C:\Cristiano\Origem\C01.LASA.PARCEMS-EV-3304-20200325.TXT");

            arquivo.AlterarLinha(0, "CD_SISTEMA", "AAA");

            arquivo.AlterarHeader("CD_TPA", "ABC");

            arquivo.AlterarTodasAsLinhas("CD_SISTEMA", "a12");

            arquivo.Salvar(@"C:\Cristiano\Destino\C01.LASA.PARCEMS-EV-000x-20200325.TXT");


        }

        //[TestMethod]
        //public void TesteCPF_Validacao()
        //{
        //    var arquivoRetorno = new Arquivo_Layout_9_4_ParcEmissao();
        //    arquivoRetorno.Carregar(@"C:\Cristiano\Origem\C01.LASA.PARCEMS-EV-000x-20200325-RETORNO.TXT");

        //    var arquivoEnvio = new Arquivo_Layout_9_4_ParcEmissao();
        //    arquivoEnvio.Carregar(@"C:\Cristiano\Origem\C01.LASA.PARCEMS-EV-000x-20200325.TXT");

        //    CompararCamposChavesEntreOsArquivos(arquivoEnvio, arquivoRetorno);

        //    ValidarMensagemDeErro(arquivoRetorno, "MENSAGEM DE ERRO QUE EU ESPERO");
        //}

        //private Arquivo ObterLayout()
        //{

        //}






    }
}
