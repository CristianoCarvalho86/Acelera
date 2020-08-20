using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
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
        public void GeraTeste()
        {
            var listaOperacoesNovas = new string[] {OperadoraEnum.COOP.ObterTexto(), OperadoraEnum.PAPCARD.ObterTexto(), OperadoraEnum.PITZI.ObterTexto() };
            var arquivosDeTestes = Directory.GetFiles(@"C:\Cristiano\Projetos\Acelera\Acelera.Testes\FASE 2\SIT\SP2\FG02").Where(x => x.ToUpper().Contains(OperadoraEnum.POMPEIA.ObterTexto()));
            var destino = @"C:\Cristiano\Projetos\Acelera\Acelera.Testes\FASE 2\SIT\SP5\FG02\";
            var oldNamespace = "Acelera.Testes.FASE_2.SIT.SP2.FG02";
            var newNamespace = "Acelera.Testes.FASE_2.SIT.SP5.FG02";
            foreach (var arquivo in arquivosDeTestes)
            {
                foreach (var operacao in listaOperacoesNovas)
                    File.WriteAllText(destino + arquivo.Split('\\').Last().Replace(OperadoraEnum.POMPEIA.ObterTexto(), operacao).Replace("Pompeia", operacao).Replace("pompeia", operacao),
                        File.ReadAllText(arquivo).Replace(OperadoraEnum.POMPEIA.ObterTexto(), operacao).Replace("Pompeia", operacao).Replace("pompeia", operacao)
                        .Replace(oldNamespace,newNamespace));
            }

        }

        [TestMethod]
        public void Busca()
        {
            var arquivosTim = Directory.GetFiles(Parametros.pastaOrigem).Where(x => x.Contains("TIM"));
            Arquivo_Layout_9_4_ParcEmissao arquivo1;
            IList<KeyValuePair<string, string>> contratoRamo = new List<KeyValuePair<string, string>>();
            KeyValuePair<string, string> temp;
            foreach (var arquivoTim in arquivosTim)
            {
                arquivo1 = new Arquivo_Layout_9_4_ParcEmissao();
                arquivo1.Carregar(arquivoTim);
                foreach(var linha in arquivo1.Linhas)
                {
                    if (contratoRamo.Any(x => x.Key == linha["CD_CONTRATO"] && x.Value != linha["CD_RAMO"]))
                        throw new Exception("CONTRATO ENCONTRADO COM MAIS DE UM CD_RAMO");
                    else
                        contratoRamo.Add(new KeyValuePair<string, string>(linha["CD_CONTRATO"], linha["CD_RAMO"]));
                }
            }
        }

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
