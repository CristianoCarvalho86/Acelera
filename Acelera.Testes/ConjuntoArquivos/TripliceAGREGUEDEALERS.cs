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
    public class TripliceAGREGUEDEALERS : Triplice<Arquivo_Layout_9_4_Cliente, Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>
    {
        public TripliceAGREGUEDEALERS(int quantidadeCliente, IMyLogger logger, ref AlteracoesArquivo alteracoesArquivo) : base(quantidadeCliente, logger, ref alteracoesArquivo)
        {

        }

        public override OperadoraEnum Operadora => OperadoraEnum.AGREGUEDEALERS;
    }
}
