using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC95_Layout94_TIM : TestesFG00
    {
        /// <summary>
        /// Não informar o registro do Header no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1266_COMISSAO_SemHeader()
        {
            IniciarTeste(TipoArquivo.Comissao, "1266", " FG00 - PROC95 - Não informar o registro do Header no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.EMSCMS-EV-0002-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverHeader();

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.EMSCMS-EV-/*R*/-20200213.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
        }

        /// <summary>
        /// Não informar o registro do Header no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1269_SINISTRO_SemHeader()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1269", "FG00 - PROC95 - Não informar o registro do Header no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverHeader();

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.SINISTRO-EV-/*R*/-20200209.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
        }

        /// <summary>
        /// Não informar o registro do Header no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1268_LANCTO_COMISSAO_SemHeader()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "1268", "FG00 - PROC95 - Não informar o registro do Header no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9999-20190531.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverHeader();

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.LASA.LCTCMS-EV-/*R*/-20190531.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
        }

        /// <summary>
        /// Não informar o registro do Header no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1267_OCR_COBRANCA_SemHeader()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1267", "FG00 - PROC95 - Não informar o registro do Header no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.COBRANCA-EV-9995-20191229.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverHeader();

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.COBRANCA-EV-/*R*/-20191229.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
        }

        /// <summary>
        /// Não informar o registro do Header no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1265_PARC_EMISSAO_SemHeader()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "1265", "FG00 - PROC95 - Não informar o registro do Header no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0002-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverHeader();

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.PARCEMS-EV-/*R*/-20200214.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
        }

        /// <summary>
        /// Não informar o registro do Header no arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1264_CLIENTE_SemHeader()
        {
            IniciarTeste(TipoArquivo.Cliente, "1264", "FG00 - PROC95 - Não informar o registro do Header no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverHeader();

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.CLIENTE-EV-/*R*/-20200212.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1260_EMS_COMISSAO_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.Comissao, "1260", "FG00 - PROC95 -  No Header do arquivo EMS_COMISSAO no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.EMSCMS-EV-0002-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.EMSCMS-EV-/*R*/-20200213.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1263_EMS_SINISTRO_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1263", "FG00 - PROC95 - No Header do arquivo SINISTRO no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.SINISTRO-EV-/*R*/-20200209.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1262_LANCTO_COMISSAO_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "1262", "FG00 - PROC95 - No Header do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-0073-20190531.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.LASA.LCTCMS-EV-/*R*/-20190531.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1261_OCR_COBRANCA_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1261", "FG00 - PROC95 - No Header do arquivo OCR_COBRANCA no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.COBRANCA-EV-9995-20191229.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.COBRANCA-EV-/*R*/-20191229.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campopo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1259_PARC_EMISSAO_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "1259", "FG00 - PROC95 - No Header do arquivo PARC_EMISSAO no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0002-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.PARCEMS-EV-/*R*/-20200214.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1258_CLIENTE_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.Cliente, "1258", "FG00 - PROC95 - No Header do arquivo CLIENTE no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.CLIENTE-EV-/*R*/-20200212.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages(false);
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
