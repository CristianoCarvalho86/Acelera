using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG00
{
    [TestClass]
    public class PROC95_Layout96_COOP : TestesFG00
    {
        /// <summary>
        /// Não informar o registro do Header no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7163_COMISSAO_SemHeader()
        {
            IniciarTeste(TipoArquivo.Comissao, "1266", " FG00 - PROC95 - Não informar o registro do Header no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            RemoverHeader();

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// Não informar o registro do Header no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7166_SINISTRO_SemHeader()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1269", "FG00 - PROC95 - Não informar o registro do Header no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            RemoverHeader();

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// Não informar o registro do Header no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7164_OCR_COBRANCA_SemHeader()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1267", "FG00 - PROC95 - Não informar o registro do Header no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            RemoverHeader();

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// Não informar o registro do Header no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7162_PARC_EMISSAO_SemHeader()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "7150", "FG00 - PROC95 - Não informar o registro do Header no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            RemoverHeader();

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// Não informar o registro do Header no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7161_CLIENTE_SemHeader()
        {
            IniciarTeste(TipoArquivo.Cliente, "1264", "FG00 - PROC95 - Não informar o registro do Header no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            RemoverHeader();

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7169_EMS_COMISSAO_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.Comissao, "7169", "FG00 - PROC95 -  No Header do arquivo EMS_COMISSAO no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7172_EMS_SINISTRO_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1263", "FG00 - PROC95 - No Header do arquivo SINISTRO no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7170_OCR_COBRANCA_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1261", "FG00 - PROC95 - No Header do arquivo OCR_COBRANCA no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campopo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7168_PARC_EMISSAO_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "1259", "FG00 - PROC95 - No Header do arquivo PARC_EMISSAO no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7167_CLIENTE_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.Cliente, "1258", "FG00 - PROC95 - No Header do arquivo CLIENTE no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Semm Critica")]
        public void SAP_1330_CLIENTE_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Semm Critica")]
        public void SAP_1331_PARC_EMISSAO_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Semm Critica")]
        public void SAP_1332_EMS_COMISSAO_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Semm Critica")]
        public void SAP_1333_OCR_COBRANCA_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Semm Critica")]
        public void SAP_1334_LANCTO_COMISSAO_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Semm Critica")]
        public void SAP_1335_SINISTRO_TipoRegistro01()
        {
        }
    }
}
