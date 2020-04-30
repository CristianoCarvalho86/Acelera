using Acelera.Domain.Entidades.ConjuntoArquivos;
using Acelera.Domain.Layouts;
using Acelera.Testes.FASE_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    [TestClass]
    public class TestesDashboard : TestesFG02
    {

        [TestMethod]
        public void Teste1()
        {
            TripliceLASA triplice = new TripliceLASA(1, Parametros.pastaOrigem, Parametros.pastaDestino);
            var cdCliente = triplice.ArquivoCliente.ObterValorFormatadoSeExistirCampo(0, "CD_CLIENTE");
            triplice.AlterarParcEComissao(0, "CD_CLIENTE", cdCliente);
            triplice.AlterarParcEComissao(0, "CD_TIPO_EMISSAO", "1");
            triplice.AlterarParcEComissao(0, "NR_PARCELA", "1");
            triplice.AlterarParcEComissao(0, "NR_ENDOSSO", "0");
            triplice.AlterarParcEComissao(0, "CD_COBERTURA", "00005");
            triplice.AlterarParcEComissao(0, "DT_INICIO_VIGENCIA", "20180601");
            triplice.AlterarParcEComissao(0, "DT_FIM_VIGENCIA", "20190701");
            triplice.AlterarParcEComissao(0, "VL_IS", "500");
            triplice.AlterarParcEComissao(0, "VL_LMI", "100");
            triplice.ReplicarLinhaNoParcEComissao(0, 8);

            triplice.AlterarParcEComissao(1, "CD_COBERTURA", "00006");
            triplice.AlterarParcEComissao(1, "DT_INICIO_VIGENCIA", "20190101");
            triplice.AlterarParcEComissao(1, "DT_FIM_VIGENCIA", "20200101");
            triplice.AlterarParcEComissao(1, "VL_IS", "1200");
            triplice.AlterarParcEComissao(1, "VL_LMI", "600");

            triplice.AlterarParcEComissao(2, "CD_COBERTURA", "00014");
            triplice.AlterarParcEComissao(2, "DT_INICIO_VIGENCIA", "20190801");
            triplice.AlterarParcEComissao(2, "DT_FIM_VIGENCIA", "20200801");
            triplice.AlterarParcEComissao(2, "VL_IS", "2500");
            triplice.AlterarParcEComissao(2, "VL_LMI", "2500");

            triplice.AlterarParcEComissao(3, "CD_COBERTURA", "00015");
            triplice.AlterarParcEComissao(3, "DT_INICIO_VIGENCIA", "20200229");
            triplice.AlterarParcEComissao(3, "DT_FIM_VIGENCIA", "20210229");
            triplice.AlterarParcEComissao(3, "VL_IS", "5000");
            triplice.AlterarParcEComissao(3, "VL_LMI", "5000");

            triplice.AlterarParcEComissao(4, "CD_COBERTURA", "00084");
            triplice.AlterarParcEComissao(4, "DT_INICIO_VIGENCIA", "20180615");
            triplice.AlterarParcEComissao(4, "DT_FIM_VIGENCIA", "20190715");
            triplice.AlterarParcEComissao(4, "VL_IS", "10000");
            triplice.AlterarParcEComissao(4, "VL_LMI", "10000");

            triplice.AlterarParcEComissao(5, "CD_COBERTURA", "00110");
            triplice.AlterarParcEComissao(5, "DT_INICIO_VIGENCIA", "20200801");
            triplice.AlterarParcEComissao(5, "DT_FIM_VIGENCIA", "20210731");
            triplice.AlterarParcEComissao(5, "VL_IS", "50000");
            triplice.AlterarParcEComissao(5, "VL_LMI", "50000");

            triplice.AlterarParcEComissao(6, "CD_COBERTURA", "01727");
            triplice.AlterarParcEComissao(6, "DT_INICIO_VIGENCIA", "20200801");
            triplice.AlterarParcEComissao(6, "DT_FIM_VIGENCIA", "20210731");
            triplice.AlterarParcEComissao(6, "VL_IS", "250");
            triplice.AlterarParcEComissao(6, "VL_LMI", "500");

            triplice.AlterarParcEComissao(7, "CD_COBERTURA", "01730");
            triplice.AlterarParcEComissao(7, "DT_INICIO_VIGENCIA", "20200801");
            triplice.AlterarParcEComissao(7, "DT_FIM_VIGENCIA", "20210731");
            triplice.AlterarParcEComissao(7, "VL_IS", "1000");
            triplice.AlterarParcEComissao(7, "VL_LMI", "1000");

            triplice.AlterarParcEComissao(8, "CD_COBERTURA", "01730");
            triplice.AlterarParcEComissao(8, "DT_INICIO_VIGENCIA", "20200801");
            triplice.AlterarParcEComissao(8, "DT_FIM_VIGENCIA", "20210731");
            triplice.AlterarParcEComissao(8, "VL_IS", "2000");
            triplice.AlterarParcEComissao(8, "VL_LMI", "1000");

            triplice.Salvar();
        }

        public override void FimDoTeste()
        {

        }

    }
}
