using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.ConjuntoArquivos
{
    public class TripliceSoftbox : Triplice<Arquivo_Layout_9_4_Cliente, Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>
    {
        public TripliceSoftbox(int quantidadeCliente, string pastaOrigem, string pastaDestino) : base(quantidadeCliente, pastaOrigem, pastaDestino)
        {

        }

        public override OperadoraEnum Operadora => throw new NotImplementedException();
    }
}
