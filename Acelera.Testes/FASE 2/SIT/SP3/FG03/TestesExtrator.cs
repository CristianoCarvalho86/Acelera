﻿using Acelera.Domain.Entidades.SGS;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Acelera.Testes.DataAccessRep;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG03
{
    [TestClass]
    public class TestesExtrator : TestesFG03
    {

        /// <summary>
        /// Multiplas parcelas
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4727()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4727", "Multiplas parcelas");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            CarregarContratoComMultiplasParcelas(ObterLinha(0));
            //CarregarContratoPeloCodigo("797700282265", ObterLinha(0));


            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            //SelecionarLinhaParaValidacao(0);
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(true, true, false, CodigoStage.AguardandoEmissaoSGS);

            //Garantir operação parametrizada
            ValidarCdTpaNaParametroGlobal(ObterValorHeader("CD_TPA"));

            //Garantir sinistro não possui parcela na ods
            ValidarRegistroNaoExisteNaODSParcela(ObterValorHeader("CD_TPA"), ObterValorFormatado(0, "CD_CONTRATO"), ObterValorFormatado(0, "NR_SEQUENCIAL_EMISSAO"));

            //Executar MASP1602B00
            Executar();

            //Verificar tabelas temporárias estão preenchidas
            ValidaTabelasTemporariasSGS(ObterValorFormatado(0,"CD_CONTRATO"), ObterValorFormatado(0, "CD_CLIENTE"));

            //Executar FG03
            ChamarExecucao(FG03_Tarefas.Sinistro.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNAFG00);
            ValidarStageParcelaAuto(CodigoStage.AprovadoNAFG00);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false,false, true, null);

            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarStageParcelaAuto(CodigoStage.AprovadoNegocioSemDependencia);

        }

        /// <summary>
        /// Parcela única
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4726()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4726", "Parcela única");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            CarregarContratoComUmaParcela(ObterLinha(0));
            SelecionarLinhaParaValidacao(0);
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(true, true, false, CodigoStage.AguardandoEmissaoSGS);

            //Garantir operação parametrizada
            ValidarCdTpaNaParametroGlobal(ObterValorHeader("CD_TPA"));

            //Garantir sinistro não possui parcela na ods
            ValidarRegistroNaoExisteNaODSParcela(ObterValorHeader("CD_TPA"), ObterValor(0, "CD_CONTRATO"), ObterValor(0, "NR_SEQUENCIAL_EMISSAO"));

            //Executar MASP1602B00
            Executar();

            //Verificar tabelas temporárias estão preenchidas
            ValidaTabelasTemporariasSGS(ObterValorFormatado(0, "CD_CONTRATO"), ObterValorFormatado(0, "CD_CLIENTE"));

            //Executar FG03
            ChamarExecucao(FG03_Tarefas.Sinistro.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNAFG00);
            ValidarStageParcela(CodigoStage.AprovadoNAFG00);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false, false, true, null);

            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarStageParcela(CodigoStage.AprovadoNegocioSemDependencia);

        }


        /// <summary>
        /// Dois contratos para o mesmo CD_CLIENTE
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4728()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4728", "Dois contratos para o mesmo CD_CLIENTE");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            CarregarContratoComClienteDeVariosContratos(ObterLinha(0), ObterLinha(1));
            SelecionarLinhaParaValidacao(0);
            SelecionarLinhaParaValidacao(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(true, true, false, CodigoStage.AprovadoNaFG01);

            //Garantir operação parametrizada
            ValidarCdTpaNaParametroGlobal(ObterValorHeader("CD_TPA"));

            //Garantir sinistro não possui parcela na ods
            ValidarRegistroNaoExisteNaODSParcela(ObterValorHeader("CD_TPA"), ObterValor(0, "CD_CONTRATO"), ObterValor(0, "NR_SEQUENCIAL_EMISSAO"));

            //Executar MASP1602B00
            Executar();

            //Verificar tabelas temporárias estão preenchidas
            ValidaTabelasTemporariasSGS(ObterValorFormatado(0, "CD_CONTRATO"), ObterValorFormatado(0, "CD_CLIENTE"), true, null);

            //Executar FG03
            ChamarExecucao(FG03_Tarefas.Sinistro.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNAFG00);
            ValidarStageParcela(CodigoStage.AprovadoNAFG00);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false, false, true, null);

            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarStageParcela(CodigoStage.AprovadoNegocioSemDependencia);

        }


        /// <summary>
        /// Sinistro com parcela/clente/sinistro na ods
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4729()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4729", "Sinistro com parcela/clente/sinistro na ods");


            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem(""));
            RemoverLinhasExcetoAsPrimeiras(1);
            EnviarParaOds(arquivo, true);

            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem(""));
            RemoverLinhasExcetoAsPrimeiras(1);
            EnviarParaOds(arquivo, true);

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem(""));
            RemoverLinhasExcetoAsPrimeiras(1);
            EnviarParaOds(arquivo, true);

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO

            //Tem que alterar movimenteção do sinistro
            ObterLinhaComCdContratoDisponivel();
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(true, true, false, CodigoStage.AguardandoEmissaoSGS);

            //Garantir operação parametrizada
            ValidarCdTpaNaParametroGlobal(ObterValorHeader("CD_TPA"));

            //Garantir sinistro não possui parcela na ods
            ValidarRegistroNaoExisteNaODSParcela(ObterValorHeader("CD_TPA"), ObterValor(0, "CD_CONTRATO"), ObterValor(0, "NR_SEQUENCIAL_EMISSAO"), false);

            //Executar MASP1602B00
            Executar();

            //Verificar tabelas temporárias estão preenchidas
            ValidaTabelasTemporariasSGSVazia(ObterValorFormatado(0, "CD_CONTRATO"), ObterValorFormatado(0, "CD_CLIENTE"));

            //Executar FG03
            ChamarExecucao(FG03_Tarefas.Sinistro.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNAFG00, false);
            ValidarStageParcela(CodigoStage.AprovadoNAFG00, false);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false, false, true, null);
        }

        /// <summary>
        /// Apólice não encontrada na SGS
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4730()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4730", "Apólice não encontrada na SGS");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ValidarCdContratoNaoExiste(ObterValorFormatado(0, "CD_CONTRATO").AlterarUltimosCaracteres("00000001"));
            ObterLinhaComCdContratoDisponivel();
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(true, true, false, CodigoStage.AguardandoEmissaoSGS);

            //Garantir operação parametrizada
            ValidarCdTpaNaParametroGlobal(ObterValorHeader("CD_TPA"));

            //Garantir sinistro não possui parcela na ods
            ValidarRegistroNaoExisteNaODSParcela(ObterValorHeader("CD_TPA"), ObterValor(0, "CD_CONTRATO"), ObterValor(0, "NR_SEQUENCIAL_EMISSAO"));

            //Executar MASP1602B00
            Executar();

            //Verificar tabelas temporárias estão preenchidas
            ValidaTabelasTemporariasSGSVazia(ObterValorFormatado(0, "CD_CONTRATO"), ObterValorFormatado(0, "CD_CLIENTE"));

            //Executar FG03
            ChamarExecucao(FG03_Tarefas.Sinistro.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNAFG00, false);
            ValidarStageParcela(CodigoStage.AprovadoNAFG00, false);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);

        }

        /// <summary>
        /// Sinistro com código menor que 120 (não executa FG01)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4731()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4731", "Apólice não encontrada na SGS");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            ObterLinhaComCdContratoDisponivel();
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(true, false, false, null);

            //Garantir operação parametrizada
            ValidarCdTpaNaParametroGlobal(ObterValorHeader("CD_TPA"));

            //Garantir sinistro não possui parcela na ods
            ValidarRegistroNaoExisteNaODSParcela(ObterValorHeader("CD_TPA"), ObterValor(0, "CD_CONTRATO"), ObterValor(0, "NR_SEQUENCIAL_EMISSAO"));

            //Executar MASP1602B00
            Executar();

            //Verificar tabelas temporárias estão preenchidas
            ValidaTabelasTemporariasSGSVazia(ObterValorFormatado(0, "CD_CONTRATO"), ObterValorFormatado(0, "CD_CLIENTE"));

            //Executar FG03
            ChamarExecucao(FG03_Tarefas.Sinistro.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNAFG00, false);
            ValidarStageParcela(CodigoStage.AprovadoNAFG00, false);
            ValidarStages(CodigoStage.AprovadoNAFG00);

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false, false, true, null);

            ValidarStages(CodigoStage.AprovadoNAFG00);

        }

        /// <summary>
        /// Segunda movimentação de sinistro, sendo o primeiro com 140.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4732()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4732", "Segunda movimentação de sinistro, sendo o primeiro com 140.");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            ObterLinhaComCdContratoDisponivel();
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();
            var arquivo1 = arquivo.Clone();

            ValidarFGsAnteriores(true, true, false, CodigoStage.AprovadoNaFG01);

            //segundo arquivo
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO

            //alterar movimento
            ObterLinhaComCdContratoDisponivel();
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();
            var arquivo2 = arquivo.Clone();

            // INICIANDO VALIDAÇAO DO SEGUNDO

            arquivo = arquivo2;

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(true, true, false, CodigoStage.AprovadoNaFG01);

            //Garantir operação parametrizada
            ValidarCdTpaNaParametroGlobal(ObterValorHeader("CD_TPA"));

            //Garantir sinistro não possui parcela na ods
            ValidarRegistroNaoExisteNaODSParcela(ObterValorHeader("CD_TPA"), ObterValor(0, "CD_CONTRATO"), ObterValor(0, "NR_SEQUENCIAL_EMISSAO"));

            //Executar MASP1602B00
            Executar();

            //Verificar tabelas temporárias estão preenchidas
            ValidaTabelasTemporariasSGS(ObterValorFormatado(0, "CD_CONTRATO"), ObterValorFormatado(0, "CD_CLIENTE"));

            //Executar FG03
            ChamarExecucao(FG03_Tarefas.Sinistro.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNAFG00);
            ValidarStageParcela(CodigoStage.AprovadoNAFG00);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false, true, true, CodigoStage.AprovadoNaFG01);

            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarStageParcela(CodigoStage.AprovadoNegocioSemDependencia);

            //INICIAR VALIDACAO DO PRIMEIRO ARQUIVO

            arquivo = arquivo1;

            //Garantir operação parametrizada
            ValidarCdTpaNaParametroGlobal(ObterValorHeader("CD_TPA"));

            //Garantir sinistro não possui parcela na ods
            ValidarRegistroNaoExisteNaODSParcela(ObterValorHeader("CD_TPA"), ObterValor(0, "CD_CONTRATO"), ObterValor(0, "NR_SEQUENCIAL_EMISSAO"));

            //Verificar tabelas temporárias estão preenchidas
            ValidaTabelasTemporariasSGS(ObterValorFormatado(0, "CD_CONTRATO"), ObterValorFormatado(0, "CD_CLIENTE"));

            //Executar FG03

            ValidarStageCliente(CodigoStage.AprovadoNAFG00);
            ValidarStageParcela(CodigoStage.AprovadoNAFG00);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false, true, true, CodigoStage.AprovadoNaFG01);

            ValidarStageCliente(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarStageParcela(CodigoStage.AprovadoNegocioSemDependencia);

        }

        /// <summary>
        /// Segunda movimentação de sinistro, sendo o primeiro com 160.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4733()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4733", "Segunda movimentação de sinistro, sendo o primeiro com 160.");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            ObterLinhaComCdContratoDisponivel();
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();
            var arquivo1 = arquivo.Clone();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false, false, false, CodigoStage.AprovadoNaFG01);

            //Garantir operação parametrizada
            ValidarCdTpaNaParametroGlobal(ObterValorHeader("CD_TPA"));

            //Garantir sinistro não possui parcela na ods
            ValidarRegistroNaoExisteNaODSParcela(ObterValorHeader("CD_TPA"), ObterValor(0, "CD_CONTRATO"), ObterValor(0, "NR_SEQUENCIAL_EMISSAO"));

            //Executar MASP1602B00
            Executar();

            //Verificar tabelas temporárias estão preenchidas
            ValidaTabelasTemporariasSGS(ObterValorFormatado(0, "CD_CONTRATO"), ObterValorFormatado(0, "CD_CLIENTE"));

            //Executar FG03
            ChamarExecucao(FG03_Tarefas.Sinistro.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNAFG00);
            ValidarStageParcela(CodigoStage.AprovadoNAFG00);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            ObterLinhaComCdContratoDisponivel();
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();
            var arquivo2 = arquivo.Clone();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false, true, true, CodigoStage.AprovadoNaFG01);

            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarStageParcela(CodigoStage.AprovadoNegocioSemDependencia);

            arquivo = arquivo1;

            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarStageCliente(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarStageParcela(CodigoStage.AprovadoNegocioSemDependencia);

        }


        /// <summary>
        /// Contarto cancelado
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4734()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4734", "Contarto cancelado.");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            CarregarContratoCancelado(ObterLinha(0));
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
           ValidarFGsAnteriores(false, false, false, CodigoStage.AprovadoNaFG01);

            //Garantir operação parametrizada
            ValidarCdTpaNaParametroGlobal(ObterValorHeader("CD_TPA"));

            //Garantir sinistro não possui parcela na ods
            ValidarRegistroNaoExisteNaODSParcela(ObterValorHeader("CD_TPA"), ObterValor(0, "CD_CONTRATO"), ObterValor(0, "NR_SEQUENCIAL_EMISSAO"));

            //Executar MASP1602B00
            Executar();

            //Verificar tabelas temporárias estão preenchidas
            ValidaTabelasTemporariasSGS(ObterValorFormatado(0, "CD_CONTRATO"), ObterValorFormatado(0, "CD_CLIENTE"));

            //Executar FG03
            ChamarExecucao(FG03_Tarefas.Sinistro.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNAFG00);
            ValidarStageParcela(CodigoStage.AprovadoNAFG00);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false, true, true, CodigoStage.AprovadoNaFG01);

            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNaFG01);
            ValidarStageParcela(CodigoStage.AprovadoNegocioSemDependencia);

        }

        /// <summary>
        /// CD_OCORRENCIA depois do fim da vigencia
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4735()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4735", "CD_OCORRENCIA depois do fim da vigencia.");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            ObterLinhaComCdContratoDisponivel();
            var contrato = CarregarDadosDoContrato(ObterLinha(0));
            AlterarLinha(0, "CD_OCORRENCIA", SomarData(contrato.DT_FIM_VIGENCIA, 30));
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
           ValidarFGsAnteriores(false, false, false, CodigoStage.AprovadoNaFG01);

            //Garantir operação parametrizada
            ValidarCdTpaNaParametroGlobal(ObterValorHeader("CD_TPA"));

            //Garantir sinistro não possui parcela na ods
            ValidarRegistroNaoExisteNaODSParcela(ObterValorHeader("CD_TPA"), ObterValor(0, "CD_CONTRATO"), ObterValor(0, "NR_SEQUENCIAL_EMISSAO"));

            //Executar MASP1602B00
            Executar();

            //Verificar tabelas temporárias estão preenchidas
            ValidaTabelasTemporariasSGS(ObterValorFormatado(0, "CD_CONTRATO"), ObterValorFormatado(0, "CD_CLIENTE"));

            //Executar FG03
            ChamarExecucao(FG03_Tarefas.Sinistro.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNAFG00);
            ValidarStageParcela(CodigoStage.AprovadoNAFG00);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false, true, true, CodigoStage.AprovadoNaFG01);

            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNaFG01);
            ValidarStageParcela(CodigoStage.AprovadoNegocioSemDependencia);

        }

        /// <summary>
        /// Arquivo que não pertence a SGS
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4736()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4736", "Arquivo que não pertence a SGS.");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-2758-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ObterLinhaComCdContratoDisponivel();
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(true, true, false, CodigoStage.AprovadoNaFG01);

            //Garantir operação parametrizada
            ValidarCdTpaNaParametroGlobal(ObterValorHeader("CD_TPA"), false);

            //Garantir sinistro não possui parcela na ods
            ValidarRegistroNaoExisteNaODSParcela(ObterValorHeader("CD_TPA"), ObterValor(0, "CD_CONTRATO"), ObterValor(0, "NR_SEQUENCIAL_EMISSAO"));

            //Executar MASP1602B00
            Executar();

            //Verificar tabelas temporárias estão preenchidas
            ValidaTabelasTemporariasSGSVazia(ObterValorFormatado(0, "CD_CONTRATO"), ObterValorFormatado(0, "CD_CLIENTE"));

            //Executar FG03
            ChamarExecucao(FG03_Tarefas.Sinistro.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNAFG00,false);
            ValidarStageParcela(CodigoStage.AprovadoNAFG00, false);
            ValidarStages(CodigoStage.AprovadoNaFG01);

        }

    }
}
