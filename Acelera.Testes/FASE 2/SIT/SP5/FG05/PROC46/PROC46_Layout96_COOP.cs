using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC46
{
    [TestClass]
    public class PROC46_Layout96_COOP : TestesFG05
    {

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9247_Cancelamento()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-9247:FG05 - PROC 46 - C/C - COOP - PARCELA - Cancelamento e nr_seq_emissão=1");

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);
            AlterarHeader("VERSAO", "9.6");
            CriarNovoContrato(0);

            AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            EnviarParaOds(arquivo);

            LimparValidacao();

            arquivo.AdicionarLinha(CriarLinhaCancelamento(arquivo[0], "10", "02", "1"));
            AlterarLinha(1, "CD_ITEM", "12345");
            RemoverLinhaComAjusteDeFooter(0);
            //NAO PRECISA COLOCAR O NR_SEQUENCIAL_EMISSAO, POIS O METODOS DE CRIAR LINHA DE CANCELAMENTO JÁ ESTÁ FAZENDO

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9188()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "FG05 - PROC46 - SAP-9188:FG05 - PROC 46 - C/C - PARCELA - Segunda parcela e nr_seq_emissão=1");
            

            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.COOP);

            AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);

            EnviarParaOds(arquivoods1);

            CriarNovaLinhaParaEmissao(arquivoods1);
            RemoverLinha(0);
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9189()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "FG05 - PROC46 - SAP-9189:FG05 - PROC 46 - C/C - PARCELA - cd_tipo_emissao=7 e nr_seq_emissão=1");

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);
            AlterarHeader("VERSAO","9.6");
            CriarNovoContrato(0, arquivo);

            AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            
            EnviarParaOds(arquivo);
            var arquivoODS = arquivo.Clone();

            CriarNovaLinhaParaEmissao(arquivo);
            RemoverLinha(0);
            AjustarQtdLinFooter();
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_PARCELA", "2");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9190()
        {
            IniciarTeste(TipoArquivo.Comissao, "", "FG05 - PROC46 - SAP-9190:FG05 - PROC 46 - C/C - COMISSAO - Segunda parcela e nr_seq_emissão=1");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.COOP);

            AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            EnviarParaOds(arquivoods1);

            CriarNovaLinhaParaEmissao(arquivoods1);
            RemoverLinha(0);
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9191()
        {
            IniciarTeste(TipoArquivo.Comissao, "", "FG05 - PROC46 - SAP-9191:FG05 - PROC 46 - C/C - COMISSAO - cd_tipo_emissao=7 e nr_seq_emissão=1");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.COOP);

            AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            EnviarParaOds(arquivoods1);

            CriarNovaLinhaParaEmissao(arquivoods1);
            RemoverLinha(0);
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "7");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9192()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "FG05 - PROC46 - SAP-9192:FG05 - PROC 46 - S/C - PARCELA - Segunda parcela e nr_seq_emissão>1");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.COOP);

            AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            EnviarParaOds(arquivoods1);

            CriarNovaLinhaParaEmissao(arquivoods1);
            RemoverLinha(0);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9193()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "FG05 - PROC46 - SAP-9193:FG05 - PROC 46 - S/C - PARCELA - Primeira parcela e nr_seq_emissão=1 ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.COOP);

            AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9194()
        {
            IniciarTeste(TipoArquivo.Comissao, "", "FG05 - PROC46 - SAP-9194:FG05 - PROC 46 - S/C - COMISSAO - Segunda parcela e nr_seq_emissão>1");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.COOP);

            AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            EnviarParaOds(arquivoods1);

            CriarNovaLinhaParaEmissao(arquivoods1);
            RemoverLinha(0);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9195()
        {
            IniciarTeste(TipoArquivo.Comissao, "", "FG05 - PROC46 - SAP-9195:FG05 - PROC 46 - S/C - COMISSAO - Primeira parcela e nr_seq_emissão=1");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.COOP);

            AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }
    }
}
