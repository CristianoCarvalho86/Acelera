using Acelera.Domain.Entidades;
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
    [Serializable]
    public class TripliceVIVO : Triplice<Arquivo_Layout_9_3_Cliente, Arquivo_Layout_9_3_ParcEmissaoAuto, Arquivo_Layout_9_3_EmsComissao>
    {
        public TripliceVIVO(int quantidadeCliente, IMyLogger logger, ref List<string> arquivosSalvos) : base(quantidadeCliente, logger, ref arquivosSalvos)
        {

        }

        public override OperadoraEnum Operadora => OperadoraEnum.VIVO;
        public override bool EhParcAuto => true;
    }
}
