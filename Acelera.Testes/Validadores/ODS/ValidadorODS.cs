using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.Validadores.ODS
{
    public abstract class ValidadorODS
    {

        public bool RegistroEstaNaOds(string nomeArquivo,TabelasEnum tabela)
        {
            return false;
        }

    }
}
