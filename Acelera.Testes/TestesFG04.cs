using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Layouts;
using Acelera.Testes.ConjuntoArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public class TestesFG04 : TestesFG02
    {
        protected ITriplice triplice;

        public TestesFG04()
        {

        }

        public void CarregarTriplice(OperadoraEnum operadora)
        {
            if (operadora == OperadoraEnum.LASA)
                triplice = new TripliceLASA(1, logger);
            else if (operadora == OperadoraEnum.SOFTBOX)
                triplice = new TripliceSoftbox(1, logger);
            else
                throw new Exception("OPERACAO NAO PERMITIDA NOS TESTES DA FG04.");
        }

        public void ExecutarEValidar(Arquivo arquivo ,FGs fG, CodigoStage codigoEsperado)
        {

        }

        public void Calculo()
        {
            //VL_COMISSAO deve ser VL PREMIO LIQUIDO * VL_REMUNERACAO (7013)
        }
    }
}
