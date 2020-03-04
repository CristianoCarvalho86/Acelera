using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public class TestesFG01 : TestesFG00
    {
        protected override IList<string> ObterProceduresASeremExecutadas()
        {
            var lista = new List<string>();
            lista.Add("PRC_0110");
            lista.Add("PRC_0001");
            lista.Add("PRC_0005");
            lista.Add("PRC_0006");
            lista.Add("PRC_0007");
            lista.Add("PRC_0008");
            lista.Add("PRC_0014");
            lista.Add("PRC_0015");
            lista.Add("PRC_0062");
            lista.Add("PRC_0066");
            lista.Add("PRC_0074");
            lista.Add("PRC_0092");
            lista.Add("PRC_0126");
            lista.Add("PRC_200000");
            return lista;
        }

        public void ValidarFG00() 
        {
            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(tipoArquivoTeste.ObterTarefaFG00Enum().ObterTexto());
            ValidarLogProcessamento(true);
            ValidarControleArquivo();
            ValidarTabelaDeRetorno();
        }

    }
}
