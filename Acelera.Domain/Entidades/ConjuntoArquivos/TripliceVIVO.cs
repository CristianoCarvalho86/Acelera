using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.ConjuntoArquivos
{
    public class TripliceVIVO : Triplice<Arquivo_Layout_9_3_Cliente, Arquivo_Layout_9_3_ParcEmissao, Arquivo_Layout_9_3_EmsComissao>
    {
        public TripliceVIVO(int quantidadeCliente, string pastaOrigem, string pastaDestino) : base(quantidadeCliente, pastaOrigem, pastaDestino)
        {

        }

        public override OperadoraEnum Operadora => OperadoraEnum.VIVO;
    }
}
