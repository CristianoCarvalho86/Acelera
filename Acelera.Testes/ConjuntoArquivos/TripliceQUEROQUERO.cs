using Acelera.Domain.Entidades;
using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.ConjuntoArquivos
{
    [Serializable]
    public class TripliceQUEROQUERO : Triplice<Arquivo_Layout_9_4_Cliente, Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>
    {
        public TripliceQUEROQUERO(int quantidadeCliente, IMyLogger logger, ref List<string> arquivosSalvos) : base(quantidadeCliente, logger, ref arquivosSalvos)
        {

        }

        public override OperadoraEnum Operadora => OperadoraEnum.QUEROQUERO;
        public override bool EhParcAuto => false;
    }
}
