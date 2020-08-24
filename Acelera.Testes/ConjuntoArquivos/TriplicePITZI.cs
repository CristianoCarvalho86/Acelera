﻿using Acelera.Domain.Entidades;
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
    public class TriplicePITZI : Triplice<Arquivo_Layout_9_4_Cliente, Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>
    {
        public TriplicePITZI(int quantidadeCliente, IMyLogger logger) : base(quantidadeCliente, logger)
        {

        }

        public override OperadoraEnum Operadora => OperadoraEnum.PITZI;
        public override bool EhParcAuto => false;
    }
}