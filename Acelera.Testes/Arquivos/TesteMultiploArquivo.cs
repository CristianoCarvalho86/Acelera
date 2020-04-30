using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Utils;
using Acelera.Testes.FASE_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.Arquivos
{
    [TestClass]
    public class TesteMultiploArquivo : TestesFG02
    {
        [TestMethod]
        public void ObterTrincas()
        {
            var arquivoClienteNovo = new Arquivo_Layout_9_4_Cliente();
            var arquivoParcNovo = new Arquivo_Layout_9_4_ParcEmissao();
            var arquivoComissaoNovo = new Arquivo_Layout_9_4_EmsComissao();

            var arquivoClienteGig = new Arquivo_Layout_9_4_Cliente();
            var arquivoParcGig = new Arquivo_Layout_9_4_ParcEmissao();
            var arquivoComissaoGig = new Arquivo_Layout_9_4_EmsComissao();

            var arquivosLasa = ArquivoOrigem.ObterArquivos(TipoArquivo.Cliente, OperadoraEnum.LASA, Parametros.pastaOrigem);
            arquivoClienteGig.Carregar(arquivosLasa.First());
            arquivoClienteNovo.Header = arquivoClienteGig.Header;
            arquivoClienteNovo.Footer = arquivoClienteGig.Footer;
            arquivoClienteNovo.RemoverTodasLinhasDoBody();
            for (int i = 1; i < arquivosLasa.Count; i++)
            {
                arquivoClienteGig.CarregarNovasLinhasNoBody(arquivosLasa[i]);
            }

            arquivosLasa = ArquivoOrigem.ObterArquivos(TipoArquivo.ParcEmissao, OperadoraEnum.LASA, Parametros.pastaOrigem);
            arquivoParcGig.Carregar(arquivosLasa.First());
            arquivoParcNovo.Header = arquivoParcGig.Header;
            arquivoParcNovo.Footer = arquivoParcGig.Footer;
            arquivoParcNovo.RemoverTodasLinhasDoBody();
            for (int i = 1; i < arquivosLasa.Count; i++)
            {
                arquivoParcGig.CarregarNovasLinhasNoBody(arquivosLasa[i]);
            }

            arquivosLasa = ArquivoOrigem.ObterArquivos(TipoArquivo.Comissao, OperadoraEnum.LASA, Parametros.pastaOrigem);
            arquivoComissaoGig.Carregar(arquivosLasa.First());
            arquivoComissaoNovo.Header = arquivoComissaoGig.Header;
            arquivoComissaoNovo.Footer = arquivoComissaoGig.Footer;
            arquivoComissaoNovo.RemoverTodasLinhasDoBody();
            for (int i = 1; i < arquivosLasa.Count; i++)
            {
                arquivoComissaoGig.CarregarNovasLinhasNoBody(arquivosLasa[i]);
            }

            var clientesTestados = new List<string>();
            foreach(var linha in arquivoParcGig.Linhas)
            {
                if (clientesTestados.Contains(linha.ObterCampoDoArquivo("CD_CLIENTE").ValorFormatado))
                    continue;

                clientesTestados.Add(linha.ObterCampoDoArquivo("CD_CLIENTE").ValorFormatado);

                var linhasCliente = arquivoClienteGig.ObterLinhasComValores("CD_CLIENTE", linha.ObterCampoDoArquivo("CD_CLIENTE").ValorFormatado);
                var linhasComissao = arquivoComissaoGig.ObterLinhasComValores(
                    new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO","NR_PARCELA", "CD_COBERTURA" },
                    new string[] { linha.ObterCampoDoArquivo("CD_CONTRATO").ValorFormatado,
                        linha.ObterCampoDoArquivo("NR_SEQUENCIAL_EMISSAO").ValorFormatado,
                        linha.ObterCampoDoArquivo("NR_PARCELA").ValorFormatado,
                        linha.ObterCampoDoArquivo("CD_COBERTURA").ValorFormatado});

                if (!(linhasCliente != null && linhasCliente.Count() > 0))
                    continue;
                if (!(linhasComissao != null && linhasComissao.Count() > 0))
                    continue;

                foreach (var l in linhasCliente)
                    arquivoClienteNovo.AdicionaLinhaNoBody(l);

                foreach (var l in linhasComissao)
                    arquivoComissaoNovo.AdicionaLinhaNoBody(l);

                arquivoParcNovo.AdicionaLinhaNoBody(linha);

            }

            arquivoClienteNovo.Salvar(Parametros.pastaDestino + "TESTE_CLIENTE_LASA.TXT");
            arquivoParcNovo.Salvar(Parametros.pastaDestino + "TESTE_PARCEMS_LASA.TXT");
            arquivoComissaoNovo.Salvar(Parametros.pastaDestino + "TESTE_COMISSAO_LASA.TXT");

        }
    }
}
