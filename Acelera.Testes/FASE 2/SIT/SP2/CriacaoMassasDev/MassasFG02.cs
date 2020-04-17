using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Acelera.Testes.FASE_2.SIT.SP2.CriaçãoMassasDev
{
    [TestClass]
    public class MassasFG02 : TestesFG02
    {
        /// <summary>
        /// 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO com DT_FIM_VIGENCIA menor que DT_INICIO_VIGENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC11()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC11", "FG02 - PROC11 - 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO com DT_FIM_VIGENCIA menor que DT_INICIO_VIGENCIA");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData(ObterValor(1, "DT_INICIO_VIGENCIA"), -1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC11-C01.POMPEIA.PARCEMS-EV-/*R*/-20200210.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO, com o VL_IS menos ou igual a zero E  CD_TIPO_EMISSAO = 18
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC13()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC13", "FG02 - PROC13 - 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO, com o VL_IS menos ou igual a zero E  CD_TIPO_EMISSAO = 18");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3162-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "VL_IS", "0");
            AlterarLinha(3, "CD_TIPO_EMISSAO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC13-C01.SOFTBOX.PARCEMS-EV-/*R*/-20200316.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO com CD_TIPO_EMISSAO = '18' E  NR_ENDOSSO igual a zero E NR_PARCELA <> 0"
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC16()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC16", "FG02 - PROC16 - 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO com CD_TIPO_EMISSAO = '18' E  NR_ENDOSSO igual a zero E NR_PARCELA <> 0");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0001-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(6, "NR_ENDOSSO", "0");
            AlterarLinha(6, "CD_TIPO_EMISSAO", "18");
            AlterarLinha(6, "NR_PARCELA", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC16-C01.TIM.PARCEMS-EV-/*R*/-20200214.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO com NR_APOLICE diferente de  12 ou 13, 15, 17 OU 18 caracteres
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC18()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC18", "FG02 - PROC18 - 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO com NR_APOLICE diferente de  12 ou 13, 15, 17 OU 18 caracteres");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(9, "NR_APOLICE", "12345678901");
            AlterarLinha(9, "ID_TRANSACAO", CarregarIdtransacao(arquivo.ObterLinha(9)));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC18-C01.POMPEIA.PARCEMS-EV-/*R*/-20200210.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO com NR_APOLICE diferente da NR_PROPOSTA
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC19()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC19", "FG02 - PROC19 - 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO com NR_APOLICE diferente da NR_PROPOSTA");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3244-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(8, "NR_PROPOSTA", "1234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC19-C01.SOFTBOX.PARCEMS-EV-/*R*/-20200321.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO com NR_APOLICE diferente do CD_CONTRATO
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC20()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC20", "FG02 - PROC20 - 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO com NR_APOLICE diferente do CD_CONTRATO");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0003-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_CONTRATO", "1234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC20-C01.TIM.PARCEMS-EV-/*R*/-20200213.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de  Parcela com 1 (um) ID_REGISTRO com  CD_MOEDA com o numeral um (1) negativo u não esteja cadastrado na tabela de pamametro
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC23()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC23", "FG02 - PROC23 - 1 (um) Arquivo de  Parcela com 1 (um) ID_REGISTRO com  CD_MOEDA com o numeral um (1) negativo u não esteja cadastrado na tabela de pamametro");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3321-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(9, "CD_MOEDA", dados.ObterCDMoeda(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC23-C01.LASA.PARCEMS-EV-/*R*/-20200326.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Parcela auto com 1 (um) ID_REGISTRO com CD_COBERTURA  com o numeral um (1) negativo u não esteja cadastrado na tabela de pamametro
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC24()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "PROC24", "FG02 - PROC24 - 1 (um) Arquivo de Parcela auto com 1 (um) ID_REGISTRO com CD_COBERTURA  com o numeral um (1) negativo u não esteja cadastrado na tabela de pamametro");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(9, "CD_COBERTURA", dados.ObterCobertura(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC24-C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Comissão com 1 (um) ID_REGISTRO com CD_RAMO com o numeral um (1) negativo ou não esteja cadastrado na tabela de pamametro
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC25()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC25", "FG02 - PROC25 - 1 (um) Arquivo de Parcela auto com 1 (um) ID_REGISTRO com CD_COBERTURA  com o numeral um (1) negativo u não esteja cadastrado na tabela de pamametro");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1934-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(9, "CD_RAMO", "-1");
            AlterarLinha(9, "ID_TRANSACAO", CarregarIdtransacao(arquivo.ObterLinha(9)));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC25-C01.POMPEIA.PARCEMS-EV-/*R*/-20200213.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO com CD_PRODUTO = -1 u não esteja cadastrado na tabela de pamametro
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC26()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC26", "FG02 - PROC26 - 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO comCD_PRODUTO = -1 u não esteja cadastrado na tabela de pamametro");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3162-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(9, "CD_PRODUTO", dados.ObterProduto(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC26-C01.SOFTBOX.PARCEMS-EV-/*R*/-20200316.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de  Parcela com 1 (um) ID_REGISTRO com  CD_MOVTO_COBRANCA = -1 ou não esteja cadastrado na tabela de pamametro
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC28()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC28", "FG02 - PROC28 - 1 (um) Arquivo de  Parcela com 1 (um) ID_REGISTRO com  CD_MOVTO_COBRANCA = -1 ou não esteja cadastrado na tabela de pamametro");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(9, "CD_MOVTO_COBRANCA", "-1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC28-C01.POMPEIA.PARCEMS-EV-/*R*/-20200211.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de  Parcela com 1 (um) ID_REGISTRO com  CD_TIPO_EMISSAO igual a reembolso
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC32()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC32", "FG02 - PROC32 - 1 (um) Arquivo de  Parcela com 1 (um) ID_REGISTRO com  CD_TIPO_EMISSAO igual a reembolso");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3162-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(9, "CD_TIPO_EMISSAO", "14");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC32-C01.SOFTBOX.PARCEMS-EV-/*R*/-20200316.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de  Parcela com 1 (um) ID_REGISTRO com  NR_ENDOSSO maior ou igual a 1 (um) e NR_SEQUENCIAL_EMISSAO igual a 1 (um)
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC33()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC33", "FG02 - PROC33 - 1 (um) Arquivo de  Parcela com 1 (um) ID_REGISTRO com  NR_ENDOSSO maior ou igual a 1 (um) e NR_SEQUENCIAL_EMISSAO igual a 1 (um)");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0001-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(9, "NR_ENDOSSO", "2");
            AlterarLinha(9, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(9, "ID_TRANSACAO", CarregarIdtransacao(arquivo.ObterLinha(9)));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC33-C01.TIM.PARCEMS-EV-/*R*/-20200214.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de cliente com 1 (um) ID_REGISTRO com campos obrigatórios cadastrados na tabela de layout para o tipo numerico com valor negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC35()
        {
            IniciarTeste(TipoArquivo.Cliente, "PROC35", "FG02 - PROC35 - 1 (um) Arquivo de cliente com 1 (um) ID_REGISTRO com campos obrigatórios cadastrados na tabela de layout para o tipo numerico com valor negativo");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.CLIENTE-EV-3211-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "CD_CLIENTE", "-1234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC35-C01.SOFTBOX.CLIENTE-EV-/*R*/-20200319.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Comissão com 2 (dois) ID_REGISTRO distintos: o mesmo CD_CONTRATO para a mesma apolice na tabela no arquivo e na tabela de ODS.
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC52()
        {
            IniciarTeste(TipoArquivo.Comissao, "PROC52", "FG02 - PROC52 - 1 (um) Arquivo de Comissão com 2 (dois) ID_REGISTRO distintos: o mesmo CD_CONTRATO para  a mesma apolice na tabela no arquivo e na tabela de ODS.");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.EMSCMS-EV-1929-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "CD_CONTRATO", "12345");
            AlterarLinha(3, "CD_TIPO_COMISSAO", "R");
            AlterarLinha(4, "CD_CONTRATO", "12345");
            AlterarLinha(4, "CD_TIPO_COMISSAO", "R");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC52-C01.POMPEIA.EMSCMS-EV-/*R*/-20200211.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: CD_COBERTURA nulo ou vázio.
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC70()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC70", "FG02 - PROC70 - 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: CD_COBERTURA nulo ou vázio.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_COBERTURA", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC70-C01.POMPEIA.SINISTRO-EV-/*R*/-20200117.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: DT_AVISO maior que a DT_OCORRENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC80()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC80", "FG02 - PROC80 - 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: DT_AVISO maior que a DT_OCORRENCIA");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3300-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_AVISO", SomarData(ObterValor(0,"DT_OCORRENCIA"), -10));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC80-C01.SOFTBOX.SINISTRO-EV-/*R*/-20200324.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: data de ocorrência não esta entre o início e fim de vigência da apólice e/ou endosso.
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC81()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC81", "FG02 - PROC81 - 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: data de ocorrência não esta entre o início e fim de vigência da apólice e/ou endosso.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3312-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(ObterValor(0,"DT_OCORRENCIA"), 30));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC81-C01.LASA.SINISTRO-EV-/*R*/-20200325.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Sinistro com 2 (DOIS) ID_REGISTRO distintos:  com o mesmo CD_MOVIMENTO no arquivo e na tabela de ODS
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC82()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC82", "FG02 - PROC82 - 1 (um) Arquivo de Sinistro com 2 (DOIS) ID_REGISTRO distintos:  com o mesmo CD_MOVIMENTO no arquivo e na tabela de ODS");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_MOVIMENTO", "3");
            AlterarLinha(1, "CD_MOVIMENTO", "3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC82-C01.TIM.SINISTRO-EV-/*R*/-20200213.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: CD_FORMA_PAGTO igual a D e CD_BANCO_SEG nulo
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC85()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC85", "FG02 - PROC85 - 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: CD_FORMA_PAGTO igual a D e CD_BANCO_SEG nulo");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "TP_SINISTRO", "03");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");
            AlterarLinha(0, "CD_BANCO_SEG", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC85-C01.TIM.SINISTRO-EV-/*R*/-20200213.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: CD_FORMA_PAGTO igual a 'D' E NR_AGENCIA_SEG igual a nulo ou vazio
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC86()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC86", "FG02 - PROC86 - 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: CD_FORMA_PAGTO igual a 'D' E NR_AGENCIA_SEG igual a nulo ou vazio");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3232-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");
            AlterarLinha(0, "NR_AGENCIA_SEG", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC86-C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: CD_FORMA_PAGTO igual a 'D' E NR_CONTA_SEG igual a nulo ou vazio
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC87()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC87", "FG02 - PROC87 - 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: CD_FORMA_PAGTO igual a 'D' E NR_CONTA_SEG igual a nulo ou vazio");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");
            AlterarLinha(0, "NR_CONTA_SEG", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC87-C01.POMPEIA.SINISTRO-EV-/*R*/-20200117.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: CD_FORMA_PAGTO igual a 'D' E NR_CONTA_DIG_SEG igual a nulo ou vazio
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC88()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC88", "FG02 - PROC88 - 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: CD_FORMA_PAGTO igual a 'D' E NR_CONTA_DIG_SEG igual a nulo ou vazio");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3232-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");
            AlterarLinha(0, "NR_CONTA_DIG_SEG", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC88-C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Parcela auto com 1 (um) ID_REGISTRO: CD_PRODUTO, CD_RAMO E CD_COBERTURA parametrizados incorretamente para que seja contabilizado de acordo com as regras da Generali.
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC107()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "PROC107", "FG02 - PROC107 - 1 (um) Arquivo de Parcela auto com 1 (um) ID_REGISTRO: CD_PRODUTO, CD_RAMO E CD_COBERTURA parametrizados corretamente para que seja contabilizado de acordo com as regras da Generali.");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            //var cobertura = dados.ObterCobertura();

            AlterarLinha(0, "CD_PRODUTO", dados.ObterProdutoNaoRelacionadoACobertura("01770"));
            AlterarLinha(0, "CD_RAMO", dados.ObterRamoNaoRelacionadoACobertura("01770"));
            AlterarLinha(0, "CD_COBERTURA", "01770");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC107-C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: com CD_SINISTRO fora da formação da regra esperada.
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC111()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC111", "FG02 - PROC111 - 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: com CD_SINISTRO fora da formação da regra esperada.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3232-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            var texto = "20" + ObterValorHeader("CD_TPA") + ObterValorFormatado(0, "CD_RAMO") + "71" + "00006";

            AlterarLinha(0, "CD_SINISTRO", texto);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC111-C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO:  CD_FORMA_PAGTO nulo ou vázio para CD_TIPO_MOVIMENTO de pagamento cadastrado na tabela de parametro
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC119()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC119", "FG02 - PROC119 - 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO:  CD_FORMA_PAGTO nulo ou vázio para CD_TIPO_MOVIMENTO de pagamento cadastrado na tabela de parametro");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_FORMA_PAGTO", "0");
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", dados.ObterTipoMovimento(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC119-C01.TIM.SINISTRO-EV-/*R*/-20200212.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de  Parcela com 2 (dois) ID_REGISTRO:  Um que o CD_FORMA_PAGTO que não consta cadastrado na tabela de parametro e outro que o CD_FORMA_PAGTO  seja igual a menos 1 (um), negativo.
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC120()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC120", "FG02 - PROC120 - 1 (um) Arquivo de  Parcela com 2 (dois) ID_REGISTRO:  Um que o CD_FORMA_PAGTO que não consta cadastrado na tabela de parametro e outro que o CD_FORMA_PAGTO  seja igual a menos 1 (um), negativo.");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3240-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_FORMA_PAGTO", dados.ObterCDFormaPagamento(false));
            AlterarLinha(1, "CD_FORMA_PAGTO", "-1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC120-C01.LASA.PARCEMS-EV-/*R*/-20200321.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de  Parcela com 1 (um) ID_REGISTRO:  onde o campo CD_MOVTO_COBRANCA seja diferente de 3 para os tipos de emissão 18
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC122()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC122", "FG02 - PROC122 - 1 (um) Arquivo de  Parcela com 1 (um) ID_REGISTRO:  onde o campo CD_MOVTO_COBRANCA seja diferente de 3 para os tipos de emissão 18");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "01");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "18");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC122-C01.POMPEIA.PARCEMS-EV-/*R*/-20200211.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Parcela auto com 1 (um) ID_REGISTRO:  DT_EMISSAO maior que a data atual.
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC123()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "PROC123", "FG02 - PROC123 - 1 (um) Arquivo de Parcela auto com 1 (um) ID_REGISTRO:  DT_EMISSAO maior que a data atual.");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_EMISSAO",SomarData(dados.ObterDataDoBanco(), 30));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC123_C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de  Baixa Parcela com 1 (um) ID_REGISTRO: data de ocorrência maior que a data atual
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC124()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "PROC124", "FG02 - PROC124 -  1 (um) Arquivo de  Baixa Parcela com 1 (um) ID_REGISTRO: data de ocorrência que a data atual");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.COBRANCA-EV-2784-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_OCORRENCIA", SomarData(dados.ObterDataDoBanco(), 30));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC124-C01.LASA.COBRANCA-EV-/*R*/-20200214.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Parcela auto com 1 (um) ID_REGISTRO:  Incluir um ID_TRANSACAO_CANC igual ao ID_TRANSACAO
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC127()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC127", "FG02 - PROC127 -  1 (um) Arquivo de Parcela auto com 1 (um) ID_REGISTRO:  Incluir um ID_TRANSACAO_CANC igual ao ID_TRANSACAO");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(0, "ID_TRANSACAO_CANC", ObterValor(0,"ID_TRANSACAO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC127-C01.POMPEIA.PARCEMS-EV-/*R*/-20200210.TXT");
        }

        /// <summary>
        /// 2 (um) Arquivos de Sinistro com 2 (dois) ID_REGISTRO distintos: com CD_SINISTRO iguais e Tipo de movimento de abertura iguais, em arquivos distintos.
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC128()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC128", "FG02 - PROC128 -  2 (um) Arquivos de Sinistro com 2 (dois) ID_REGISTRO distintos: com CD_SINISTRO iguais e Tipo de movimento de abertura iguais, em arquivos distintos.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cdSinistro = ObterValor(0, "CD_SINISTRO");
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC128-C01.POMPEIA.SINISTRO-EV-/*R*/-20200127.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0002-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", cdSinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC128-C01.POMPEIA.SINISTRO-EV-/*R*/-20191220.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: DT_MOVIMENTO maior que a data atual
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC130()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC130", "FG02 - PROC130 -  1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: DT_MOVIMENTO maior que a data atual");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3333-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(dados.ObterDataDoBanco(), 365));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC130-C01.SOFTBOX.SINISTRO-EV-/*R*/-20200326.TXT");
        }

        /// <summary>
        /// 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: com DT_REGISTRO diferente dos damais DT_REGISTRO do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC131()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC131", "FG02 - PROC131 -  1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: com DT_REGISTRO diferente dos damais DT_REGISTRO do arquivo");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_REGISTRO", "20200330");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC131-C01.POMPEIA.SINISTRO-EV-/*R*/-20200211.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: DT_MOVIMENTO maior que a DT_AVISO 
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC132()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC132", "FG02 - PROC132 -  1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: DT_MOVIMENTO maior que a DT_AVISO ");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3331-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", SomarData(ObterValor(0,"DT_AVISO"), -50));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC132-C01.LASA.SINISTRO-EV-/*R*/-20200326.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de  Parcela com 1(um) ID_REGISTRO: com ID_TRANSACAO_CANC preenchido para CD_TIPO_EMISSAO cancelamento.
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC155()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC155", "FG02 - PROC155 -  1 (um) Arquivo de  Parcela com 1(um) ID_REGISTRO: com ID_TRANSACAO_CANC preenchido para CD_TIPO_EMISSAO cancelamento. ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3256-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC155-C01.LASA.PARCEMS-EV-/*R*/-20200322.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de  Parcela com 2 (DOIS) ID_REGISTRO Distintos: Com datas de amissão do endosso menor que a data de emissão da apolice
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC162()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC162", "FG02 - PROC162 - 1 (um) Arquivo de  Parcela com 2 (DOIS) ID_REGISTRO Distintos: Com datas de amissão do endosso menor que a data de emissão da apolice");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3224-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "18");
            AlterarLinha(1, "CD_CONTRATO", ObterValor(0, "CD_CONTRATO"));
            AlterarLinha(1, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(1, "NR_ENDOSSO", "1");
            AlterarLinha(1, "DT_EMISSAO", SomarData(0, "DT_EMISSAO", -10));
            AlterarLinha(1, "ID_TRANSACAO", CarregarIdtransacao(arquivo.ObterLinha(1)));
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC162-C01.LASA.PARCEMS-EV-/*R*/-20200320.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: NR_DOCUMENTO vazio ou nulo para os tipos de movimento de sinistro despesa
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC164()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC164", "FG02 - PROC164 - 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: NR_DOCUMENTO vazio ou nulo para os tipos de movimento de sinistro despesa");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "TP_SINISTRO", "02");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC164-C01.SGS.SINISTRO-EV-/*R*/-20200209.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: NR_DOCUMENTO vazio ou nulo para forma de pagamento CHEQUE
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC176()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC176", "FG02 - PROC176 - 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: NR_DOCUMENTO vazio ou nulo para os tipos de movimento de sinistro despesa");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_FORMA_PAGTO", "C");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC176-C01.SGS.SINISTRO-EV-/*R*/-20200213.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: com CD_BANCO_SEG não cadastrado na tabela de parametro esperado pela Generali.
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC177()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC177", "FG02 - PROC177 - 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: NR_DOCUMENTO vazio ou nulo para os tipos de movimento de sinistro despesa");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");
            AlterarLinha(0, "CD_BANCO_SEG", dados.ObterCDBancoSeg(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC177-C01.TIM.SINISTRO-EV-/*R*/-20200213.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: com CD_BANCO vazio ou nulo para movimento de pagamento de sinistro
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC178()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC178", "FG02 - PROC178 - 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: com CD_BANCO vazio ou nulo para movimento de pagamento de sinistro");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_BANCO", "");
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC178-C01.TIM.SINISTRO-EV-/*R*/-20200213.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: com TP_SINISTRO diferente de 01, 02, 03 e/ou 04
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC182()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC182", "FG02 - PROC182 - 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: com TP_SINISTRO diferente de 01, 02, 03 e/ou 04");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3331-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_BANCO", "05");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC182-C01.LASA.SINISTRO-EV-/*R*/-20200326.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: com CD_TIPO_MOVIMENTO não aceito na Validação da Generali
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC184()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC184", "FG02 - PROC184 - 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: com CD_TIPO_MOVIMENTO não aceito na Validação da Generali");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3331-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", dados.ObterCDTipoMovimentoParaAtuacao("SN", false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC184-C01.LASA.SINISTRO-EV-/*R*/-20200326.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: DT_REGISTRO Menor que a data do Sinistro (DT_AVISO)
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC185()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC185", "FG02 - PROC185 - 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: com CD_TIPO_MOVIMENTO não aceito na Validação da Generali");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_REGISTRO", SomarData(ObterValor(0, "DT_AVISO"), -5));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC185-C01.POMPEIA.SINISTRO-EV-/*R*/-20200127.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Parcela auto com 1 (um) ID_REGISTRO: CD_TIPO_EMISSAO igual a 12 para o CD_MOVTO_COBRANCA igual a 02
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC191()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "PROC191", "FG02 - PROC191 - 1 (um) Arquivo de Parcela auto com 1 (um) ID_REGISTRO: CD_TIPO_EMISSAO igual a 12 para o CD_MOVTO_COBRANCA igual a 02");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));


            //ALTERAR O VALOR SELECIONADO
            var idTransacao = SomarValores(ObterValorFormatado(0, "ID_TRANSACAO"),"1");
            ReplicarLinha(0, 1);
            AumentarLinhasNoFooter(1);
            AlterarLinha(1, "CD_TIPO_EMISSAO", "12");
            AlterarLinha(1, "CD_MOVTO_COBRANCA", "02");
            AlterarLinha(1, "ID_TRANSACAO_CANC", idTransacao);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC191-C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Parcela auto com 1 (um) ID_REGISTRO:  com o VL_PREMIO_TOTAL  diferente da soma entre o premio liquido mais o IOF, para os tipos de emissão 1 e 20.
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC215()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "PROC215", "FG02 - PROC215 - 1 (um) Arquivo de Parcela auto com 1 (um) ID_REGISTRO:  com o VL_PREMIO_TOTAL  diferente da soma entre o premio liquido mais o IOF, para os tipos de emissão 1 e 20.");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValores(SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO","VL_IOF"),10));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC215-C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Comissao auto com 1 (um) ID_REGISTRO:  onde o CD_TIPO_COMISSAO diferente do CD_TIPO_REMUNERACAO
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC218()
        {
            IniciarTeste(TipoArquivo.Comissao, "PROC218", "FG02 - PROC218 - 1 (um) Arquivo de Parcela auto com 1 (um) ID_REGISTRO:  onde o CD_TIPO_COMISSAO diferente do CD_TIPO_REMUNERACAO");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.EMSCMS-EV-0002-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(0, "CD_CORRETOR", "333");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC218-C01.TIM.EMSCMS-EV-/*R*/-20200214.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de  Parcela com 1 (um) ID_REGISTRO: com CD_MOVTO_COBRANCA igual a 1 quando o movimento de cobrança for cancelamento
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC223()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC223", "FG02 - PROC223 - 1 (um) Arquivo de  Parcela com 1 (um) ID_REGISTRO: com CD_MOVTO_COBRANCA igual a 1 quando o movimento de cobrança for cancelamento");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "01");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "12345");


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC223-C01.POMPEIA.PARCEMS-EV-/*R*/-20200211.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Cliente com 1 (um) ID_REGISTRO: Com data de nascimento menor que 18 anos
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC267()
        {
            IniciarTeste(TipoArquivo.Cliente, "PROC267", "FG02 - PROC267 - 1 (um) Arquivo de Cliente com 1 (um) ID_REGISTRO: Com data de nascimento menor que 18 anos");
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1835-20200205.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_NASCIMENTO", "20050330");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC267-C01.VIVO.CLIENTE-EV-/*R*/-20200205.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO: onde a combinação CD_tpa e CD_PRODUTO nao esteja associado na parametrização
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1002()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC1002", "FG02 - PROC1002 - 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO: onde a combinação CD_tpa e CD_PRODUTO nao esteja associado na parametrização");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3276-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_PRODUTO", "71725");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1002-C01.SOFTBOX.PARCEMS-EV-/*R*/-20200323.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Parcela Auto com 1 (um) ID_REGISTRO: onde a combinação CD_COBERTURA e CD_PRODUTO nao esteja associado na parametrização
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1003()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "PROC1003", "FG02 - PROC1003 - 1 (um) Arquivo de Parcela Auto com 1 (um) ID_REGISTRO: onde a combinação CD_COBERTURA e CD_PRODUTO nao esteja associado na parametrização");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3272-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cdProduto = dados.ObterProduto(true);
            AlterarLinha(0, "CD_PRODUTO", cdProduto);
            AlterarLinha(0, "CD_COBERTURA", dados.ObterCoberturaNaoRelacionadaAProduto(cdProduto));
            

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1003-C01.LASA.PARCEMS-EV-/*R*/-20200323.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO: onde a diferença DT_FIM_VIGENCIA e DT_INICIO_VIGENCIA seja maior que 12 meses
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1024()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC1024", "FG02 - PROC1024 - 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO: onde a diferença DT_FIM_VIGENCIA e DT_INICIO_VIGENCIA seja maior que 12 meses");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3208-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData( ObterValor(0, "DT_INICIO_VIGENCIA"), 500));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1024-C01.LASA.PARCEMS-EV-/*R*/-20200319.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Cliente com 1 (um) ID_REGISTRO: onde CD_SEXO seja diferente de M ou F para as operações do averbador 
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1039()
        {
            IniciarTeste(TipoArquivo.Cliente, "PROC1039", "FG02 - PROC1024 - 1 (um) Arquivo de Cliente com 1 (um) ID_REGISTRO: onde CD_SEXO seja diferente de M ou F para as operações do averbador ");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.CLIENTE-EV-3291-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "SEXO","X");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1039-C01.SOFTBOX.CLIENTE-EV-/*R*/-20200324.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Cliente com 1 (um) ID_REGISTRO: onde NR_CNPJ_CPF seja preenchido um numero de tamanho diferente do CPF para as operações do averbador 
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1040()
        {
            IniciarTeste(TipoArquivo.Cliente, "PROC1040", "FG02 - PROC1040 -1 (um) Arquivo de Cliente com 1 (um) ID_REGISTRO: onde NR_CNPJ_CPF seja preenchido um numero de tamanho diferente do CPF para as operações do averbador ");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.CLIENTE-EV-3243-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "NR_CNPJ_CPF", "77812487000131");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1040-C01.SOFTBOX.CLIENTE-EV-/*R*/-20200321.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Cliente com 1 (um) ID_REGISTRO: onde TP_PESSOA seja diferente de 'F' para as operações do averbador 
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1041()
        {
            IniciarTeste(TipoArquivo.Cliente, "PROC1041", "FG02 - PROC1041 - 1 (um) Arquivo de Cliente com 1 (um) ID_REGISTRO: onde TP_PESSOA seja diferente de 'F' para as operações do averbador");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.CLIENTE-EV-3273-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "TIPO", "J");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1041-C01.LASA.CLIENTE-EV-/*R*/-20200323.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Parcela Auto com 1 (um) ID_REGISTRO: onde DT_INICIO_VIGENCIA seja igual do DT_EMISSAO
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1046()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC1046", "FG02 - PROC1046 -1 (um) Arquivo de Parcela Auto com 1 (um) ID_REGISTRO: onde DT_INICIO_VIGENCIA seja igual do DT_EMISSAO");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3179-20200317.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_INICIO_VIGENCIA", ObterValor(0, "DT_EMISSAO"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1046-C01.SOFTBOX.PARCEMS-EV-/*R*/-20200317.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Comissao com 1 (um) ID_REGISTRO: onde a combinação CD_SEGURADORA não esteja cadastrado nos parametros
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1048()
        {
            IniciarTeste(TipoArquivo.Comissao, "PROC1048", "FG02 - PROC1048 -1 (um) Arquivo de Comissao com 1 (um) ID_REGISTRO: onde a combinação CD_SEGURADORA não esteja cadastrado nos parametros");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.EMSCMS-EV-3180-20200317.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "4180484");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1048-C01.SOFTBOX.EMSCMS-EV-/*R*/-20200317.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO: onde a combinação CD_TIPO_EMISSAO e CD_TPA_OPERACAO não é permitida de acordo com as regras de negócio da generali.
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1056()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC1056", "FG02 - PROC1056 -1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO: onde a combinação CD_TIPO_EMISSAO e CD_TPA_OPERACAO não é permitida de acordo com as regras de negócio da generali.");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3158-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1056-C01.LASA.PARCEMS-EV-/*R*/-20200316.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Parcela Auto com 1 (um) ID_REGISTRO: onde CD_TIPO_EMISSAO seja igual a 1(um) e  NR_PARCELA seja diferente de 1 (um)
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1065()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC1065", "FG02 - PROC1065 - 1 (um) Arquivo de Parcela Auto com 1 (um) ID_REGISTRO: onde CD_TIPO_EMISSAO seja igual a 1(um) e  NR_PARCELA seja diferente de 1 (um)");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3212-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_PARCELA", "3");
            AlterarLinha(0, "ID_TRANSACAO", CarregarIdtransacao(arquivo.ObterLinha(0)));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1065-C01.SOFTBOX.PARCEMS-EV-/*R*/-20200319.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO: onde CD_SUCURSAL não esteja cadastrada para ser contabilizada na operação em questão nas regras de negócio da Generali. 
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1067()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC1067", "FG02 - PROC1067 - 1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO: onde CD_SUCURSAL não esteja cadastrada para ser contabilizada na operação em questão nas regras de negócio da Generali. ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3228-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_SUCURSAL", dados.ObterParceiroNegocio("SU",false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1067-C01.SOFTBOX.PARCEMS-EV-/*R*/-20200320.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Parcela Auto com 1 (um) ID_REGISTRO: onde DT_VENCIMENTO seja menor que DT_EMISSAO 
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1083()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC1083", "FG02 - PROC1083 - 1 (um) Arquivo de Parcela Auto com 1 (um) ID_REGISTRO: onde DT_VENCIMENTO seja menor que DT_EMISSAO ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3292-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_VENCIMENTO", SomarData(ObterValor(0,"DT_EMISSAO"), -20));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1083-C01.SOFTBOX.PARCEMS-EV-/*R*/-20200324.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO: onde VL_LMI seja diferente do VL_IS
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1091()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC1091", "FG02 - PROC1091 - 1 (um) Arquivo de Parcela Auto com 1 (um) ID_REGISTRO: onde DT_VENCIMENTO seja menor que DT_EMISSAO ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3276-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_LMI", SomarValor(0,"VL_IS",1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1091-C01.SOFTBOX.PARCEMS-EV-/*R*/-20200323.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Parcela Auto com 1 (um) ID_REGISTRO: onde CD_FRANQUIA não esteja cadastrado na DIM_PRM_FRANQUIA_7010
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1092()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC1092", "FG02 - PROC1092 - 1 (um) Arquivo de Parcela Auto com 1 (um) ID_REGISTRO: onde CD_FRANQUIA não esteja cadastrado na DIM_PRM_FRANQUIA_7010");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3192-20200318.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_FRANQUIA", "13");
            AlterarLinha(0, "ID_TRANSACAO", CarregarIdtransacao(arquivo.ObterLinha(0)));
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1092-C01.LASA.PARCEMS-EV-/*R*/-20200318.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: com CD_TIPO_EMISSAO do tipo de emissão de cancelamento.
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC181()
        {
            IniciarTeste(TipoArquivo.Sinistro, "PROC181", "FG02 - PROC181 - 1 (um) Arquivo de Sinistro com 1 (um) ID_REGISTRO: com CD_TIPO_EMISSAO do tipo de emissão de cancelamento.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0002-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC181-C01.TIM.SINISTRO-EV-/*R*/-20200212.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de  Baixa Comissão com 1 (um) ID_REGISTRO que não conste o CD_OCORRENCIA cadastrado na tabela de dominio
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1167()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "PROC1167", "FG02 - PROC1167 - 1 (um) Arquivo de  Baixa Comissão com 1 (um) ID_REGISTRO que não conste o CD_OCORRENCIA cadastrado na tabela de dominio");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.COBRANCA-EV-2987-20200302.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_OCORRENCIA", dados.ObterCDOcorrencia(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1167-C01.LASA.COBRANCA-EV-/*R*/-20200302.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO: VL_JUROS maior que o VL_JUROS_MAIOR cadastrado na DIM_PRM_PERCENT_PREMIO_7012
        ///1 (um) ID_REGISTRO: VL_JUROS menor que o VL_JUROS_MENOR cadastrado na DIM_PRM_PERCENT_PREMIO_7012
        ///ambos respeitando o cadastro do averbador da relação CD_OPERACAO, CD_SUCURSAL, CD_COBERTURA, CD_PRODUTO e CD_RAMO dos que estão sujeitos a essa validação
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1182()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC1182", "FG02 - PROC1182 - 1(um) Arquivo de Parcela com 1(um) ID_REGISTRO: VL_JUROS maior que o VL_JUROS_MAIOR cadastrado na DIM_PRM_PERCENT_PREMIO_70121(um) ID_REGISTRO: VL_JUROS menor que o VL_JUROS_MENOR cadastrado na DIM_PRM_PERCENT_PREMIO_7012ambos respeitando o cadastro do averbador da relação CD_OPERACAO, CD_SUCURSAL, CD_COBERTURA, CD_PRODUTO e CD_RAMO dos que estão sujeitos a essa validação");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3212-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura();
            AlterarLinha(0, "CD_COBERTURA",cobertura.CdCobertura);
            AlterarLinha(0, "VL_DESCONTO", SomarValores(cobertura.ValorDescontoMenor,"-1"));
            AlterarLinha(1, "CD_COBERTURA",cobertura.CdCobertura);
            AlterarLinha(1, "VL_DESCONTO", SomarValores(cobertura.ValorDescontoMaior, "1"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1182-C01.SOFTBOX.PARCEMS-EV-/*R*/-20200319.TXT");
        }

        /// <summary>
        ///"1 (um) Arquivo de Parcela Auto com 1 (um) ID_REGISTRO: VL_JUROS maior que o VL_JUROS_MAIOR cadastrado na DIM_PRM_PERCENT_PREMIO_7012
        ///1 (um) ID_REGISTRO: VL_JUROS menor que o VL_JUROS_MENOR cadastrado na DIM_PRM_PERCENT_PREMIO_7012
        ///ambos respeitando o cadastro do averbador da relação CD_OPERACAO, CD_SUCURSAL, CD_COBERTURA, CD_PRODUTO e CD_RAMO dos que estão sujeitos a essa validação"
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1183()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC1183", "FG02 - PROC1183 - 1(um) Arquivo de Parcela Auto com 1(um) ID_REGISTRO: VL_JUROS maior que o VL_JUROS_MAIOR cadastrado na DIM_PRM_PERCENT_PREMIO_70121(um) ID_REGISTRO: VL_JUROS menor que o VL_JUROS_MENOR cadastrado na DIM_PRM_PERCENT_PREMIO_7012ambos respeitando o cadastro do averbador da relação CD_OPERACAO, CD_SUCURSAL, CD_COBERTURA, CD_PRODUTO e CD_RAMO dos que estão sujeitos a essa validação");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3224-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_COBERTURA", "104670");
            AlterarLinha(0, "VL_JUROS", "0.10");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1183-C01.LASA.PARCEMS-EV-/*R*/-20200320.TXT");
        }

        /// <summary>
        ///"1 (um) Arquivo de Parcela com 1 (um) ID_REGISTRO: VL_ADIC_FRACIONADO maior que o VL_ADIC_FRAC_MAIOR cadastrado na DIM_PRM_PERCENT_PREMIO_7012
        ///1(um) ID_REGISTRO: VL_ADIC_FRACIONADO menor que o VL_ADIC_FRAC_MENOR cadastrado na DIM_PRM_PERCENT_PREMIO_7012
        ///ambos respeitando o cadastro do averbador da relação CD_OPERACAO, CD_SUCURSAL, CD_COBERTURA, CD_PRODUTO e CD_RAMO dos que estão sujeitos a essa validação"
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1184()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "PROC1184", "FG02 - PROC1184 - 1(um) Arquivo de Parcela com 1(um) ID_REGISTRO: VL_ADIC_FRACIONADO maior que o VL_ADIC_FRAC_MAIOR cadastrado na DIM_PRM_PERCENT_PREMIO_70121(um) ID_REGISTRO: VL_ADIC_FRACIONADO menor que o VL_ADIC_FRAC_MENOR cadastrado na DIM_PRM_PERCENT_PREMIO_7012ambos respeitando o cadastro do averbador da relação CD_OPERACAO, CD_SUCURSAL, CD_COBERTURA, CD_PRODUTO e CD_RAMO dos que estão sujeitos a essa validação");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3212-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura();
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "VL_ADIC_FRACIONADO", SomarValores(cobertura.ValorAdicionalMenor, "-1"));
            AlterarLinha(1, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "VL_ADIC_FRACIONADO", SomarValores(cobertura.ValorAdicionalMaior, "1"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1184-C01.SOFTBOX.PARCEMS-EV-/*R*/-20200319.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Lançamento de Comissão com 1 (um) ID_REGISTRO: TP_LANCAMENTO diferente de 3 (três)
        /// </summary>
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1190()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "PROC1190", "FG02 - PROC1190 - 1 (um) Arquivo de Lançamento de Comissão com 1 (um) ID_REGISTRO: TP_LANCAMENTO diferente de 3 (três)");
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9623-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_LANCAMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1190-C01.LASA.LCTCMS-EV-/*R*/-20190311.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Lançamento de Comissão com 1 (um) ID_REGISTRO: CD_EXTRATO_COMISSAO diferente de 1 (um)
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1191()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "PROC1191", "FG02 - PROC1191 - 1 (um) Arquivo de Lançamento de Comissão com 1 (um) ID_REGISTRO: CD_EXTRATO_COMISSAO diferente de 1 (um)");
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9623-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_EXTRATO_COMISSAO", "0");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1191-C01.LASA.LCTCMS-EV-/*R*/-20190311.TXT");
        }

        /// <summary>
        ///1 (um) Arquivo de Lançamento de Comissão com 1 (um) ID_REGISTRO: CD_LANCAMENTO diferente de 0 (zero)
        [TestMethod]
        [TestCategory("Criacao de massa")]
        public void Criacao_Massa_PRROC1193()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "PROC1193", "FG02 - PROC1193 - 1 (um) Arquivo de Lançamento de Comissão com 1 (um) ID_REGISTRO: CD_LANCAMENTO diferente de 0 (zero)");
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9623-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_LANCAMENTO", "3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"PROC1193-C01.LASA.LCTCMS-EV-/*R*/-20190311.TXT");
        }
    }
}
