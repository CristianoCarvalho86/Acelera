using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC93_Layout93_VIVO : TestesFG00
    {
        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo TIPO_REGISTRO informar código 10
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1083_CLIENTE_TipoRegistro10()
        {
            IniciarTeste(TipoArquivo.Cliente, "1083", "No Trailler do arquivo CLIENTE no campo TIPO_REGISTRO informar código 10");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "10");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages<LinhaClienteStage>(TabelasEnum.Cliente, false);
        }
        
        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO informar código 14
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1087_LANCTO_COMISSAO_TipoRegistro14()
        {
            //----------------------------------------------SEM MASSA-------------------------------------------------------
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 13
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1086_OCR_COBRANCA_TipoRegistro13()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1086", " No Trailler do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 13");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1870-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "13");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.COBRANCA-EV-/*R*/-20200212.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages<LinhaOCRCobrancaStage>(TabelasEnum.OCRCobranca, false);
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 12
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1085_EMS_COMISSAO_TipoRegistro12()
        {
            IniciarTeste(TipoArquivo.Comissao, "1085", "No Trailler do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 12");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1869-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "12");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.EMSCMS-EV-/*R*/-20200212.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages<LinhaComissaoStage>(TabelasEnum.Comissao, false);
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO_AUTO no campo TIPO_REGISTRO informar código 11
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1084_PARC_EMISSAO_AUTO_TipoRegistro11()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "1084", "No Trailler do arquivo PARC_EMISSAO_AUTO no campo TIPO_REGISTRO informar código 11");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "11");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages<LinhaParcEmissaoAutoStage>(TabelasEnum.ParcEmissaoAuto, false);
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1050_OCR_COBRANCA_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1050", "No Trailler do arquivo OCR_COBRANCA no campo TIPO_REGISTRO, não informar valor, campo em branco");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1866-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.COBRANCA-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages<LinhaOCRCobrancaStage>(TabelasEnum.OCRCobranca, false);
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1051_LANCTO_COMISSAO_SemTipoRegistro()
        {
            //----------------------------------------------SEM MASSA-------------------------------------------------------
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1049_EMS_COMISSAO_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.Comissao, "1049", "No Trailler do arquivo EMS_COMISSAO no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1869-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.EMSCMS-EV-/*R*/-20200212.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages<LinhaComissaoStage>(TabelasEnum.Comissao, false);
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO_AUTO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1048_OCR_PARC_EMISSAO_AUTO_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "1048", "No Trailler do arquivo PARC_EMISSAO_AUTO no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages<LinhaParcEmissaoAutoStage>(TabelasEnum.ParcEmissaoAuto, false);
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1047_CLIENTE_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.Cliente, "1047", "No Trailler do arquivo CLIENTE no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages<LinhaClienteStage>(TabelasEnum.Cliente, false);

        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP1147_LANCTO_COMISSAO_TipoRegistro09()
        {
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP1146_OCR_COBRANCA_TipoRegistro09()
        {
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP1145_EMS_COMISSAO_TipoRegistro09()
        {
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO_AUTO no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP1144_PARC_EMISSAO_AUTO_TipoRegistro09()
        {
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP1143_CLIENTE_TipoRegistro09()
        {
        }
    }
}
