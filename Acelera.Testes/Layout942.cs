using System;
using System.Configuration;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes
{
    [TestClass]
    public class Layout942
    {
        private string pastaOrigem = ConfigurationManager.AppSettings.Get("PastaOrigem");
        private string pastaDestino = ConfigurationManager.AppSettings.Get("PastaDestino");
        [TestMethod]
        public void Altera_NM_BENEFICIARIO_Valor_Incorreto()
        {
            //CARREGAR O ARQUIVO BASE
            var arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(pastaOrigem + "C01.SGS.SINISTRO-EV-000001-20200209.txt");

            //ALTERAR O VALOR SELECIONADO
            arquivo.AlterarLinha(50, "NM_BENEFICIARIO", "TESTANDO BLABLA");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(pastaDestino + "C01.SGS.SINISTRO-EV-000001-20200209-ALTERADO.txt");

            //PROCESSAR O ARQUIVO CRIADO

            //VALIDAR NO BANCO A ALTERACAO


        }
        [TestMethod]
        public void Altera_EN_BENEFICIARIO_Valor_Incorreto()
        {
            //throw new Exception();


        }
    }
}
