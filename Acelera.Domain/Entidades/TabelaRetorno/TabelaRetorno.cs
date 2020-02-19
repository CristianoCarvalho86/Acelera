﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acelera.Domain.Enums;

namespace Acelera.Domain.Entidades.TabelaRetorno
{
    public class TabelaRetorno : LinhaTabela
    {
        public override TabelasEnum TabelaReferente => TabelasEnum.TabelaRetorno;

        protected override void CarregarCampos()
        {
            AddCampo();
        }
    }
}
