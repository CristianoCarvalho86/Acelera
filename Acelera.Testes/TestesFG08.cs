using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Testes.FASE_2.SIT.SP4.FG07;
using Acelera.Testes.Validadores.ODS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public class TestesFG08 : FG07_Base
    {
        ValidadorODS validadorODS;
        public TestesFG08()
        {
            validadorODS = new ValidadorODS(ref logger);
        }

        public void ExecutarEValidarFG08(bool sucesso)
        {
            
            Validar
        }

        protected void ExecutarFG08()
        {
            ChamarExecucaoSemErro(FG08_Tarefas.FGR_08.ObterTexto());
            ChamarExecucaoSemErro(FG08_Tarefas.FGR_08_ODS.ObterTexto());
        }
    }
}
