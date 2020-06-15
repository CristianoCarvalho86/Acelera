﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.Interfaces
{
    public interface ILinhaTabela : ICloneable
    {
        List<Campo> Campos { get; set; }
        string ObterNomeTabela();

        void CarregarLinhaPeloCMD(string retornoQuery);

        void CarregarLinha(DataRow row);

        bool Validar(string campo, string valorEsperado);

        Campo ObterPorColuna(string coluna);
    }
}
