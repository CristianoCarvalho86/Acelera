using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Acelera.Logger;
using Acelera.Testes.DataAccessRep;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05
{
    [TestClass]
    public class Clientesods : TestesFG05
    {
        [TestMethod]
        public void Teste()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.Cliente, "9999", "");

            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("ODS_CLIENTES_LASA_C01.LASA.CLIENTE-EV-0271-20200324.TXT"));

            EnviarParaOdsAlterandoCliente(arquivo);

            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-0272-20200228.TXT"));

            EnviarParaOdsAlterandoCliente(arquivo);

            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("ODS_CLIENTES_SOFTBOX_C01.SOFTBOX.CLIENTE-EV-0273-20200322.TXT"));

            EnviarParaOdsAlterandoCliente(arquivo);

            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("ODS_CLIENTES_VIVO_C01.VIVO.CLIENTE-EV-0270-20200201.TXT"));

            EnviarParaOdsAlterandoCliente(arquivo);

            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("ODS_CLIENTES_VIVO_C01.VIVO.CLIENTE-EV-0270-20200201.TXT"));

            EnviarParaOdsAlterandoCliente(arquivo);
        }

        [TestMethod]
        public void Teste1()
        {

            IniciarTeste(Domain.Enums.TipoArquivo.Cliente, "9999", "");

            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-0272-20200228.TXT"));

            EnviarParaOdsAlterandoCliente(arquivo, false);
        }

    }
}
