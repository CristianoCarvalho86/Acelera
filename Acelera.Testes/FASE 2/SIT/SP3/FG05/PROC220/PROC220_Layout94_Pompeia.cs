using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC220
{
    [TestClass]
    public class PROC220_Layout94_POMPEIA : TestesFG05
    {

        /// <summary>
        ///Enviar 1 arquivo PARC com emissão de um contrato. 
        ///Em seguida, enviar o 2º arquivo PARC com cancelamento deste contrato com CD_TIPO_MOVTO_COBRANCA=01. 
        ///Após ambos arquivos na ODS, enviar 3o arquivo COBRANCA com movimentação de pagamento para o cancelamento (2o arquivo), informando os campos chave correspondentes
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4619()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "4619", "FG05 - PROC220 - ");
            

            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.POMPEIA);

            arquivoods1.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods1.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            arquivoods1.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOds(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods2 ,1 , OperadoraEnum.POMPEIA);

            IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "01");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO","2");
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000001");


            EnviarParaOds(arquivoods2);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);
            
            IgualarCampos(arquivoods2, arquivo, new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO","NR_PARCELA"});

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "220", 1);
        }


        /// <summary>
        ///Enviar 1 arquivo PARC com emissão de um contrato. 
        ///Em seguida, enviar o 2º arquivo PARC com cancelamento deste contrato com CD_TIPO_MOVTO_COBRANCA=01. 
        ///Após ambos arquivos na ODS, enviar 3o arquivo COBRANCA com movimentação de pagamento para a emissao (1o arquivo), informando os campos chave correspondentes 
        ///Após este arquivo conter na ODS, enviar 4o arquivo COBRANCA com a movimentaçao de baixa da restituição (2o arquivo)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4621()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "4621", "FG05 - PROC220 - ");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.POMPEIA);

            arquivoods1.AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            arquivoods1.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            arquivoods1.AlterarLinha(0, "NR_ENDOSSO", "0");
            var idCanc = arquivoods1.ObterValorFormatadoSeExistirCampo(0, "ID_TRANSACAO");

            EnviarParaOds(arquivoods1);


            //Envia Parc com id cancelamento igual id transição do anterior
            var arquivoods2 = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods2, 1, OperadoraEnum.POMPEIA);

            IgualarCampos(arquivoods1, arquivoods2, new string[] { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA" });
            arquivoods2.AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            arquivoods2.AlterarLinha(0, "ID_TRANSACAO_CANC", idCanc);
            arquivoods2.AlterarLinha(0, "CD_MOVTO_COBRANCA", "01");
            arquivoods2.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            arquivoods2.AlterarLinha(0, "NR_ENDOSSO", "12340000001");

            EnviarParaOds(arquivoods2);

            //enviar cobrança arquivo 1
            var arquivoods3 = arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivoods3, 1, OperadoraEnum.POMPEIA);

            IgualarCampos(arquivoods1, arquivoods3, new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA" });

            EnviarParaOds(arquivoods3);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            IgualarCampos(arquivoods2, arquivo, new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA" });

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }
    }
}
