using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG01
{
    [TestClass]
    public class PROC06_Layout94_PITZI : TestesFG01
    {
        /// <summary>
        /// No Body do arquivo CLIENTE no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_NASCIMENTO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7717_CLIENTE_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.Cliente, "2399", "FG01 - PROC6 - No Header do arquivo CLIENTE no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_NASCIMENTO");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_NASCIMENTO", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO nos campos abaixo informar data inválida (Ex. 32131234) DT_INICIO_VIGENCIA DT_FIM_VIGENCIA DT_VENCIMENTO DT_NASC_CONDUTOR
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7718_PARC_EMISSAO_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2400", "FG01 - PROC6 - No Body do arquivo PARC_EMISSAO nos campos abaixo informar data inválida (Ex. 32131234) DT_REFERENCIA DT_PROPOSTA DT_EMISSAO DT_EMISSAO_ORIGINAL");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0,"DT_REFERENCIA", "32131234");
            AlterarLinha(0,"DT_PROPOSTA", "32131234");
            AlterarLinha(0,"DT_EMISSAO", "32131234");
            AlterarLinha(0, "DT_EMISSAO_ORIGINAL", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA nos campos abaixo informar data inválida (Ex. 32131234) DT_OCORRENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7719_OCR_COBRANCA_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2401", "FG01 - PROC6 - No Body do arquivo OCR_COBRANCA nos campos abaixo informar data inválida (Ex. 32131234) DT_OCORRENCIA");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_OCORRENCIA", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
            ValidarTeste();
        }


        /// <summary>
        /// No Body do arquivo SINISTRO nos campos abaixo informar data inválida (Ex. 32131234) DT_REGISTRO DT_NASC_BENEFICIARIO DT_PAGAMENTO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7721_SINISTRO_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2403", "FG01 - PROC6 - No Body do arquivo SINISTRO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_REGISTRO DT_NASC_BENEFICIARIO DT_PAGAMENTO");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0,"DT_REGISTRO", "32131234");
            AlterarLinha(0,"DT_NASC_BENEFICIARIO", "32131234");
            AlterarLinha(0, "DT_PAGAMENTO", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
            ValidarTeste();
        }

    }
}
