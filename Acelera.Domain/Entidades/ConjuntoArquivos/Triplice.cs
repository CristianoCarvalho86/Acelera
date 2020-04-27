using Acelera.Domain.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.ConjuntoArquivos
{
    public abstract class Triplice<T1, T2, T3> where T1 : Arquivo, new() where T2 : Arquivo, new() where T3 : Arquivo, new()
    {
        public T1 Arquivo1 { get; protected set; }
        public T2 Arquivo2 { get; protected set; }
        public T3 Arquivo3 { get; protected set; }

        public Triplice()
        {
            Arquivo1 = new T1();
            Arquivo2 = new T2();
            Arquivo3 = new T3();
        }

    }
}
