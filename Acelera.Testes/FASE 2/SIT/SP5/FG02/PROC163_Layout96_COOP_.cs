using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC163_Layout96_COOP_ : TestesFG02
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8939()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-8939:FG02 - 163 - C/C - COOP - PARCELA - CD_SUCURSAL inválido");

            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            AlterarLinha(0, "CD_SUCURSAL", dados.ObterSucursal(false));
            AlterarHeader("VERSAO", "9.6");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            //ValidarStages(CodigoStage.RecusadoNaFG01);
            //ValidarTabelaDeRetorno("163");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_8940()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-8940:FG02 - 163 - S/C - COOP - PARCELA - CD_SUCURSAL válido");

            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            AlterarLinha(0, "CD_SUCURSAL", dados.ObterSucursal(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_8941()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-8941:FG02 - 163 - S/C - TIM - PARCELA - CD_SUCURSAL inválido");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(0, "CD_SUCURSAL", dados.ObterSucursal(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }
    }
}
