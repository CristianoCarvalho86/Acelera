using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG00
{
    [TestClass]
    public class PROC93_Layout94_COOP : TestesFG00
    {
        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7257_PARC_EMISSAO_TipoRegistro01()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "7257", "FG00 - PROC93 - No Trailler do arquivo PARC_EMISSAO no campo TIPO_REGISTRO informar código 01");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "01");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7258_EMS_COMISSAO_TipoRegistro01()
        {
            IniciarTeste(TipoArquivo.Comissao, "7258", "FG00 - PROC93 - No Trailler do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 01");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "01");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7259_OCR_COBRANCA_TipoRegistro01()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "7259", "FG00 - PROC93 - No Trailler do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 01");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "01");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7261_SINISTRO_TipoRegistro01()
        {
            IniciarTeste(TipoArquivo.Sinistro, "7261", "FG00 - PROC93 - No Trailler do arquivo SINISTRO no campo TIPO_REGISTRO informar código 01");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "01");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7262_CLIENTE_TipoRegistro01()
        {
            IniciarTeste(TipoArquivo.Cliente, "7262", "FG00 - PROC93 - No Trailler do arquivo CLIENTE no campo TIPO_REGISTRO informar código 01");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "01");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7267_SINISTRO_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.Sinistro, "7267", "FG00 - PROC93 - No Trailler do arquivo SINISTRO no campo TIPO_REGISTRO não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages(false);
            ValidarTeste();
        }


        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7265_OCR_COBRANCA_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "7265", "FG00 - PROC93 - No Trailler do arquivo OCR_COBRANCA no campo TIPO_REGISTRO não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7264_COMISSAO_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.Comissao, "7264", "FG00 - PROC93 - No Trailler do arquivo EMS_COMISSAO no campo TIPO_REGISTRO não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo ParcEmissao no campo TIPO_REGISTRO, não informar valor
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7263_PARC_EMISSAO_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "7263", "FG00 - PROC93 - No Trailler do arquivo COMISSAO no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7262_CLIENTE_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.Cliente, "7262", "FG00 - PROC93 - No Trailler do arquivo CLIENTE no campo TIPO_REGISTRO não informar valor, campo em branco, respeitando a tamanho do campo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1323_SINISTRO_TipoRegistro09()
        {
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1322_LANCTO_COMISSAO_TipoRegistro09()
        {
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1321_OCR_COBRANCA_TipoRegistro09()
        {
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1320_EMS_COMISSAO_TipoRegistro09()
        {
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1319_PARC_EMISSAO_TipoRegistro09()
        {
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1318_CLIENTE_TipoRegistro09()
        {
        }
    }
}
