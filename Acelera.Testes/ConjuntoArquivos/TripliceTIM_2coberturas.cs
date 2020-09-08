//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Acelera.Testes.ConjuntoArquivos
//{
//    public class TripliceTIM_2coberturas : TripliceTIM
//    {
//        protected override void CarregarArquivos()
//        {
//            ArquivoCliente.Carregar(ArquivoOrigem.ObterArquivoAleatorio(TipoArquivo.Cliente, Operadora, PastaOrigem), 1, 1, QuantidadeInicialCliente);

//            if (Operadora == OperadoraEnum.VIVO)
//                ArquivoParcEmissao.Carregar(ArquivoOrigem.ObterArquivoAleatorio(TipoArquivo.ParcEmissaoAuto, Operadora, PastaOrigem), 1, 1, 1);
//            else
//                ArquivoParcEmissao.Carregar(ArquivoOrigem.ObterArquivoAleatorio(TipoArquivo.ParcEmissao, Operadora, PastaOrigem), 1, 1, 1);

//            ArquivoComissao.Carregar(ArquivoOrigem.ObterArquivoAleatorio(TipoArquivo.Comissao, Operadora, PastaOrigem), 1, 1, 1);
//        }
//    }
//}
