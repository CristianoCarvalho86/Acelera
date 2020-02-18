using System;
using System.Configuration;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_4_2;
using Acelera.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes
{
    [TestClass]
    public class Layout942 : TesteBase
    {
        [TestMethod]
        public void Altera_NM_BENEFICIARIO_Valor_Incorreto()
        {
            var logger = ObterLogger("NUMERO_DO_TESTE", "Altera_NM_BENEFICIARIO_Valor_Incorreto");
            //CARREGAR O ARQUIVO BASE
            var arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt", logger));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(arquivo, 50, "NM_BENEFICIARIO", "TESTANDO BLABLA", logger);
            ReplicarLinha(arquivo, 50, 10, logger);
            RemoverLinha(arquivo, 50, logger);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.SGS.SINISTRO-EV-000001-20200209-ALTERADO.txt", logger));

            //PROCESSAR O ARQUIVO CRIADO
             var retorno  = ChamarExecucao(logger, "select (CONCAT('resultado:',host)) as host, 'fim' from m_database");

            //VALIDAR NO BANCO A ALTERACAO
            Validar("abacaxi", retorno , logger);

        }
        [TestMethod]
        public void Altera_EN_BENEFICIARIO_Valor_Incorreto()
        {
            //throw new Exception();


        }
    }
}
