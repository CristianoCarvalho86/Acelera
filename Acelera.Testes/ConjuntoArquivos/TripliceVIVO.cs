using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.ConjuntoArquivos
{
    public class TripliceVIVO : Triplice<Arquivo_Layout_9_3_Cliente, Arquivo_Layout_9_3_ParcEmissao, Arquivo_Layout_9_3_EmsComissao>
    {
        public TripliceVIVO(int quantidadeCliente, IMyLogger logger) : base(quantidadeCliente, logger)
        {

        }

        public override OperadoraEnum Operadora => OperadoraEnum.VIVO;
    }
}
