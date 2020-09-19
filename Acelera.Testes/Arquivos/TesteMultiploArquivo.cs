using Acelera.Domain;
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
    public class TesteMultiploArquivo
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

            var arquivosLasa = ArquivoOrigem.ObterArquivos(TipoArquivo.Cliente, OperadoraEnum.VIVO, Parametros.pastaOrigem);
            arquivoClienteGig.Carregar(arquivosLasa.First());
            arquivoClienteNovo.Header = arquivoClienteGig.Header;
            arquivoClienteNovo.Footer = arquivoClienteGig.Footer;
            arquivoClienteNovo.RemoverTodasLinhasDoBody();
            for (int i = 1; i < arquivosLasa.Count; i++)
            {
                arquivoClienteGig.CarregarNovasLinhasNoBody(arquivosLasa[i]);
            }

            arquivosLasa = ArquivoOrigem.ObterArquivos(TipoArquivo.ParcEmissao, OperadoraEnum.VIVO, Parametros.pastaOrigem);
            arquivoParcGig.Carregar(arquivosLasa.First());
            arquivoParcNovo.Header = arquivoParcGig.Header;
            arquivoParcNovo.Footer = arquivoParcGig.Footer;
            arquivoParcNovo.RemoverTodasLinhasDoBody();
            for (int i = 1; i < arquivosLasa.Count; i++)
            {
                arquivoParcGig.CarregarNovasLinhasNoBody(arquivosLasa[i]);
            }

            arquivosLasa = ArquivoOrigem.ObterArquivos(TipoArquivo.Comissao, OperadoraEnum.VIVO, Parametros.pastaOrigem);
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
                var cdCliente = linha.ObterCampoDoArquivo("CD_CLIENTE").ValorFormatado;
                var cdClienteNoArquivoDeCliente = clientesTestados.Contains(cdCliente);

                var linhasCliente = cdClienteNoArquivoDeCliente ? null : arquivoClienteGig.ObterLinhasComValores("CD_CLIENTE", cdCliente);
                var linhasComissao = arquivoComissaoGig.ObterLinhasComValores(
                    new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO","NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_CORRETOR" },
                    new string[] { linha.ObterCampoDoArquivo("CD_CONTRATO").ValorFormatado,
                        linha.ObterCampoDoArquivo("NR_SEQUENCIAL_EMISSAO").ValorFormatado,
                        linha.ObterCampoDoArquivo("NR_PARCELA").ValorFormatado,
                        linha.ObterCampoDoArquivo("CD_COBERTURA").ValorFormatado,
                        linha.ObterCampoDoArquivo("CD_ITEM").ValorFormatado,
                        linha.ObterCampoDoArquivo("CD_CORRETOR").ValorFormatado});

                if (linhasComissao == null || linhasComissao.Count() == 0)
                    continue;
                if( (linhasCliente == null || linhasCliente.Count == 0) && !cdClienteNoArquivoDeCliente)
                    continue;

                if (!cdClienteNoArquivoDeCliente)
                {
                    arquivoClienteNovo.AdicionaLinhaNoBody(linhasCliente.First());
                    clientesTestados.Add(cdCliente);
                }
                foreach (var l in linhasComissao)
                    arquivoComissaoNovo.AdicionaLinhaNoBody(l);

                arquivoParcNovo.AdicionaLinhaNoBody(linha);

            }

            arquivoClienteNovo.RemoverLinhasRepetidas();
            arquivoParcNovo.RemoverLinhasRepetidas();
            arquivoComissaoNovo.RemoverLinhasRepetidas();

            arquivoClienteNovo.Salvar(Parametros.pastaDestino + "TESTE_CLIENTE_VIVO.TXT");
            arquivoParcNovo.Salvar(Parametros.pastaDestino + "TESTE_PARCEMS_VIVO.TXT");
            arquivoComissaoNovo.Salvar(Parametros.pastaDestino + "TESTE_COMISSAO_VIVO.TXT");

        }
    }
}
