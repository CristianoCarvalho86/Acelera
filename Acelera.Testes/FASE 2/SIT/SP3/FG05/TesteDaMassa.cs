using Acelera.Domain.DataAccess;
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
    public class TesteDaMassa : TestesFG05
    {
        [TestMethod]
        public void Teste()
        {
            IniciarTeste(Domain.Enums.TipoArquivo.ParcEmissao, "9999", "teste de criação de massa");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-0511-20200316.TXT"));
            SelecionarLinhaParaValidacao(0);
            SalvarArquivo();
            ValidarFGsAnteriores();
            ValidarTeste();
        }

        [TestMethod]
        public void TestarMultiplos()
        {
            logger = new Mock<IMyLogger>().Object;
            ChamarExecucao(TipoArquivo.OCRCobranca.ObterTarefaFG00Enum().ObterTexto());
            ChamarExecucao(TipoArquivo.OCRCobranca.ObterTarefaFG01Enum().ObterTexto());
            ChamarExecucao(TipoArquivo.OCRCobranca.ObterTarefaFG02Enum().ObterTexto());

            ChamarExecucao(TipoArquivo.ParcEmissao.ObterTarefaFG00Enum().ObterTexto());
            ChamarExecucao(TipoArquivo.ParcEmissao.ObterTarefaFG01Enum().ObterTexto());
            ChamarExecucao(TipoArquivo.ParcEmissao.ObterTarefaFG02Enum().ObterTexto());

            ChamarExecucao(TipoArquivo.ParcEmissaoAuto.ObterTarefaFG00Enum().ObterTexto());
            ChamarExecucao(TipoArquivo.ParcEmissaoAuto.ObterTarefaFG01Enum().ObterTexto());
            ChamarExecucao(TipoArquivo.ParcEmissaoAuto.ObterTarefaFG02Enum().ObterTexto());

            ChamarExecucao(TipoArquivo.Comissao.ObterTarefaFG00Enum().ObterTexto());
            ChamarExecucao(TipoArquivo.Comissao.ObterTarefaFG01Enum().ObterTexto());
            ChamarExecucao(TipoArquivo.Comissao.ObterTarefaFG02Enum().ObterTexto());

            ChamarExecucao(TipoArquivo.Sinistro.ObterTarefaFG00Enum().ObterTexto());
            ChamarExecucao(TipoArquivo.Sinistro.ObterTarefaFG01Enum().ObterTexto());
            ChamarExecucao(TipoArquivo.Sinistro.ObterTarefaFG02Enum().ObterTexto());

            ChamarExecucao(TipoArquivo.LanctoComissao.ObterTarefaFG00Enum().ObterTexto());
            ChamarExecucao(TipoArquivo.LanctoComissao.ObterTarefaFG01Enum().ObterTexto());
            ChamarExecucao(TipoArquivo.LanctoComissao.ObterTarefaFG02Enum().ObterTexto());
        }
        [TestMethod]
        public void TestarMultiplos2()
        {
            var logger = new Mock<IMyLogger>().Object;
            var files = Directory.GetFiles(@"C:\Cristiano\Exportacao\teste\CONSOLIDADO\teste").Where(x => x.Contains("PARCEMS") && !x.Contains("PARCEMSAUTO"));
            DataTable table;
            string resultado = "";
            foreach (var file in files)
            {
                table = DataAccess.Consulta($"select CD_MENSAGEM from HDIQAS_1.TAB_ARQ_RETORNO_8002  WHERE (NM_ARQUIVO_TPA = '{file.Split('\\').Last()}' ) ","", logger);
                if (table.Rows.Count > 0)
                    foreach (DataRow row in table.Rows)
                        resultado += file + ";" + row["CD_MENSAGEM"].ToString() + Environment.NewLine;
            }
            var a = resultado;
        }
    }
}
