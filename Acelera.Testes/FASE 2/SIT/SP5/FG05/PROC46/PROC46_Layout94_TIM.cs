﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC46
{
    [TestClass]
    public class PROC46_Layout94_TIM : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9221_Cancelamento()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-9221:FG05 - PROC 46 - C/C - TIM - PARCELA - Cancelamento e nr_seq_emissão=1");

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);
            contratoRegras.CriarNovoContrato(0,arquivo);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            CriarNovaLinhaParaEmissao(arquivo, 0);

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoParc1 = arquivo.Clone();
            LimparValidacao();

            arquivo = comissaoRegras.CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.TIM, arquivo);
            RemoverLinhaComAjusteDeFooter(0);
            EnviarParaOdsAlterandoCliente(arquivo);
            LimparValidacao();

            arquivo = arquivoParc1.Clone();
            arquivo.AdicionarLinha(cancelamentoRegras.CriarLinhaCancelamento(arquivoParc1[0], "10", "02", "1"));
            RemoverLinhaComAjusteDeFooter(0);
            RemoverLinhaComAjusteDeFooter(0);
            SalvarArquivo();
            SelecionarLinhaParaValidacao(0);
            ExecutarEValidarAteFg02(arquivo, "33");
            //ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);

            LimparValidacao();
            arquivo = comissaoRegras.CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.TIM, arquivo);

            SalvarArquivo();
            SelecionarLinhaParaValidacao(0);
            ValidarFGsAnteriores();
            //ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }


        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9180()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9180", "FG05 - PROC46 - ");
            

            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);

            EnviarParaOdsAlterandoCliente(arquivoods1);

            CriarNovaLinhaParaEmissao(arquivoods1);
            RemoverLinha(0);
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9181()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9181", "FG05 - PROC46 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            EnviarParaOdsAlterandoCliente(arquivoods1);

            CriarNovaLinhaParaEmissao(arquivoods1);
            RemoverLinha(0);
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "7");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9182()
        {
            IniciarTeste(TipoArquivo.Comissao, "9182", "FG05 - PROC46 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            EnviarParaOdsAlterandoCliente(arquivoods1);

            CriarNovaLinhaParaEmissao(arquivoods1);
            RemoverLinha(0);
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9183()
        {
            IniciarTeste(TipoArquivo.Comissao, "9183", "FG05 - PROC46 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            EnviarParaOdsAlterandoCliente(arquivoods1);

            CriarNovaLinhaParaEmissao(arquivoods1);
            RemoverLinha(0);
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "7");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9184()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9184", "FG05 - PROC46 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            EnviarParaOdsAlterandoCliente(arquivoods1);

            CriarNovaLinhaParaEmissao(arquivoods1);
            RemoverLinha(0);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9185()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9185", "FG05 - PROC46 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9186()
        {
            IniciarTeste(TipoArquivo.Comissao, "9186", "FG05 - PROC46 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            EnviarParaOdsAlterandoCliente(arquivoods1);

            CriarNovaLinhaParaEmissao(arquivoods1);
            RemoverLinha(0);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9187()
        {
            IniciarTeste(TipoArquivo.Comissao, "9187", "FG05 - PROC46 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivoods1, 0);


            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }
    }
}
