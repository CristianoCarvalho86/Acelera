using Acelera.Domain.Entidades.SGS;
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
            ValidarFGsAnteriores(true, true, true, false, CodigoStage.AguardandoEmissaoSGS);

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
            ValidarFGsAnteriores(false,false, false, true, null);

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
            ValidarFGsAnteriores(true, true, true, false, CodigoStage.AguardandoEmissaoSGS);

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
            ValidarStageParcelaAuto(CodigoStage.AprovadoNAFG00);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false, false, false, true, null);

            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarStageParcelaAuto(CodigoStage.AprovadoNegocioSemDependencia);

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
            var cdCliente = ObterLinha(1).Clone();
            SelecionarLinhaParaValidacao(0);
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(true, true, true, false, CodigoStage.AguardandoEmissaoSGS);

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
            ValidarStageParcelaAuto(CodigoStage.AprovadoNAFG00);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false, false, false, true, null);

            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarStageParcelaAuto(CodigoStage.AprovadoNegocioSemDependencia);


            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverTodasAsLinhas();
            AdicionarLinha(0, cdCliente);
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(true, true, true, false, CodigoStage.AguardandoEmissaoSGS);

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
            ValidarStageParcelaAuto(CodigoStage.AprovadoNAFG00);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false, false, false, true, null);

            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            ValidarStageCliente(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarStageParcelaAuto(CodigoStage.AprovadoNegocioSemDependencia);
        }


        /// <summary>
        /// Sinistro com parcela/clente/sinistro na ods
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4729()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4729", "Sinistro com parcela/clente/sinistro na ods");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO

            //Tem que alterar movimenteção do sinistro
            ObterLinhaComCdContratoDisponivelEDeterminadoTipoMovimento("1");
            var registroODS = ObterLinha(0).Clone();
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(true, true, true, false, CodigoStage.AguardandoEmissaoSGS);

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

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverTodasAsLinhas();
            AdicionarLinha(0, registroODS);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "30");
            AlterarLinha(0, "DT_MOVIMENTO", SomarData("DT_MOVIMENTO", 5));
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(true, true, true, false, CodigoStage.AprovadoNaFG01);

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
            ValidarStageParcelaAuto(CodigoStage.AprovadoNAFG00, false);
            ValidarStages(CodigoStage.AprovadoNaFG01);

            //VALIDAR FG's ANTERIORES
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);

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
            AlterarLinha(0, "CD_CONTRATO", ObterValorFormatado(0, "CD_CONTRATO").AlterarUltimosCaracteres("00000001"));
            ValidarCdContratoNaoExiste(ObterValorFormatado(0, "CD_CONTRATO"));
            SelecionarLinhaParaValidacao(0);
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(true, true, true, false, CodigoStage.AguardandoEmissaoSGS);

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
            ValidarStageParcelaAuto(CodigoStage.AprovadoNAFG00, false);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);

        }

        /// <summary>
        /// Sinistro com código menor que 120 (não executa FG01)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
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
            ValidarFGsAnteriores(true, false, true, false, CodigoStage.AprovadoNAFG00);

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
            ValidarStageParcelaAuto(CodigoStage.AprovadoNAFG00, false);
            ValidarStages(CodigoStage.AprovadoNAFG00);

            //VALIDAR FG's ANTERIORES
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

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
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ObterLinhaComCdContratoDisponivelEDeterminadoTipoMovimento("1");

            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();
            var arquivo1 = arquivo.Clone();

            ValidarFGsAnteriores(true, true, true, false, CodigoStage.AguardandoEmissaoSGS);

            //segundo arquivo
            var arquivo2 = arquivo1.Clone();
            arquivo = arquivo2;
            
            //ALTERAR O VALOR SELECIONADO

            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "30");
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0, "DT_MOVIMENTO"), 5));
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();            

            // INICIANDO VALIDAÇAO DO SEGUNDO

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(true, true, true, false, CodigoStage.AguardandoEmissaoSGS);

            //Garantir operação parametrizada
            ValidarCdTpaNaParametroGlobal(ObterValorHeader("CD_TPA"));

            //Garantir sinistro não possui parcela na ods
            ValidarRegistroNaoExisteNaODSParcela(ObterValorHeader("CD_TPA"), ObterValor(0, "CD_CONTRATO"), ObterValor(0, "NR_SEQUENCIAL_EMISSAO"));

            //Executar MASP1602B00
            Executar();

            //Verificar tabelas temporárias estão preenchidas
            var c = CarregarDadosDoContrato(null, ObterValorFormatado(0, "CD_CONTRATO"));
            ValidaTabelasTemporariasSGS(ObterValorFormatado(0, "CD_CONTRATO"), c.CD_CLIENTE);

            //Executar FG03
            ChamarExecucao(FG03_Tarefas.Sinistro.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNAFG00);
            ValidarStageParcelaAuto(CodigoStage.AprovadoNAFG00);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false, false, false, true, null);

            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarStageParcelaAuto(CodigoStage.AprovadoNegocioSemDependencia);

            //INICIAR VALIDACAO DO PRIMEIRO ARQUIVO

            arquivo = arquivo1;

            //Garantir operação parametrizada
            ValidarCdTpaNaParametroGlobal(ObterValorHeader("CD_TPA"));

            //Garantir sinistro não possui parcela na ods
            ValidarRegistroNaoExisteNaODSParcela(ObterValorHeader("CD_TPA"), ObterValor(0, "CD_CONTRATO"), ObterValor(0, "NR_SEQUENCIAL_EMISSAO"));

            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);

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
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ObterLinhaComCdContratoDisponivel();
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();
            var arquivo1 = arquivo.Clone();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(true, true, true, false, CodigoStage.AguardandoEmissaoSGS);

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
            ValidarStageParcelaAuto(CodigoStage.AprovadoNAFG00);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);


            //Segundo arquivo
            var arquivo2 = arquivo1.Clone();
            arquivo = arquivo2;

            //ALTERAR O VALOR SELECIONADO

            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "30");
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0, "DT_MOVIMENTO"), 5));
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FGs ANTERIORES
            ValidarFGsAnteriores(true, true, true, false, CodigoStage.AguardandoEmissaoSGS);

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
            ValidarStageParcelaAuto(CodigoStage.AprovadoNAFG00);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false, false, false, true, null);

            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarStageParcelaAuto(CodigoStage.AprovadoNegocioSemDependencia);

            arquivo = arquivo1;

            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarStageCliente(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarStageParcelaAuto(CodigoStage.AprovadoNegocioSemDependencia);

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
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(true, true, true, false, CodigoStage.AguardandoEmissaoSGS);

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
            ValidarStageParcelaAuto(CodigoStage.AprovadoNAFG00);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false, false, false, true, null);

            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarStageParcelaAuto(CodigoStage.AprovadoNegocioSemDependencia);

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
            var contrato = CarregarContratoValido(ObterLinha(0));
            AlterarLinha(0, "DT_OCORRENCIA", SomarData(contrato.DT_FIM_VIGENCIA, 30));
            SelecionarLinhaParaValidacao(0);
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
           ValidarFGsAnteriores(true, true, true, false, CodigoStage.AguardandoEmissaoSGS);

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
            ValidarStageParcelaAuto(CodigoStage.AprovadoNAFG00);
            ValidarStages(CodigoStage.ExtracaoDaParcelaEDoCliente);

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores(false, false,false, true, null);

            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            ValidarStageCliente(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarStageParcelaAuto(CodigoStage.AprovadoNegocioSemDependencia);

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
            ValidarFGsAnteriores(true, true, true, false, CodigoStage.AprovadoNaFG01);

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
            ValidarStageParcelaAuto(CodigoStage.AprovadoNAFG00, false);
            ValidarStages(CodigoStage.AprovadoNaFG01);

        }

    }
}
