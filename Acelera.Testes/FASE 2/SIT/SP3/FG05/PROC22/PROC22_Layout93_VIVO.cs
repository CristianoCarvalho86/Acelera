using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC22
{
    [TestClass]
    public class PROC22_Layout93_VIVO : TestesFG05
    {
        /// <summary>
        /// Gerar um arquivo anteriormente que popule a tabela ODS que não possua nenhum item a ser criticado. 
        /// Em outro arquivo, enviar as mesmas informações do arquivo anterior nos campos da tabela TAB_PRM_LAYOUT_7016 para o NM_TIPO_ARQUIVO= SINISTRO, CD_VERSAO_ARQUIVO=9.4, TP_REGISTRO=3 e ID_PRIMARY_KEY=1.
        /// Todos os campos exibidos nessa consulta na coluna NM_ATRIBUTO_LAYOUT devem ser iguais aos do primeiro arquivo.
        /// </summary>
        [TestMethod]
        [TestCategory("Comm Critica")]
        public void SAP_4191()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4191", "FG05 - PROC22");

            //Carregar arquivo ods
            var arquivoods = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.VIVO);
            EnviarParaOds(arquivoods);

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissaoAuto, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "22", 1);
        }

        /// <summary>
        /// Gerar um arquivo anteriormente que popule a tabela ODS que não possua nenhum item a ser criticado. 
        /// Em outro arquivo, enviar as mesmas informações do arquivo anterior nos campos da tabela TAB_PRM_LAYOUT_7016 para o NM_TIPO_ARQUIVO= SINISTRO, CD_VERSAO_ARQUIVO=9.4, TP_REGISTRO=3 e ID_PRIMARY_KEY=1.
        /// Todos os campos exibidos nessa consulta na coluna NM_ATRIBUTO_LAYOUT devem ser iguais aos do primeiro arquivo.
        /// </summary>
        [TestMethod]
        [TestCategory("Comm Critica")]
        public void SAP_4192()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Cliente, "4192", "FG05 - PROC22");

            //Carregar arquivo ods
            var arquivoods = new Arquivo_Layout_9_3_Cliente();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.VIVO);
            EnviarParaOds(arquivoods);

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Cliente, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "22", 1);
        }

        /// <summary>
        /// Gerar um arquivo anteriormente que popule a tabela ODS que não possua nenhum item a ser criticado. 
        /// Em outro arquivo, enviar as mesmas informações do arquivo anterior nos campos da tabela TAB_PRM_LAYOUT_7016 para o NM_TIPO_ARQUIVO= SINISTRO, CD_VERSAO_ARQUIVO=9.4, TP_REGISTRO=3 e ID_PRIMARY_KEY=1.
        /// Todos os campos exibidos nessa consulta na coluna NM_ATRIBUTO_LAYOUT devem ser iguais aos do primeiro arquivo.
        /// </summary>
        [TestMethod]
        [TestCategory("Comm Critica")]
        public void SAP_4193()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Comissao, "4196", "FG05 - PROC22");

            //Carregar arquivo ods
            var arquivoods = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.VIVO);
            EnviarParaOds(arquivoods);

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "22", 1);
        }

        /// <summary>
        /// Gerar um arquivo anteriormente que popule a tabela ODS que não possua nenhum item a ser criticado. 
        /// Em outro arquivo, enviar as mesmas informações do arquivo anterior nos campos da tabela TAB_PRM_LAYOUT_7016 para o NM_TIPO_ARQUIVO= SINISTRO, CD_VERSAO_ARQUIVO=9.4, TP_REGISTRO=3 e ID_PRIMARY_KEY=1.
        /// Todos os campos exibidos nessa consulta na coluna NM_ATRIBUTO_LAYOUT devem ser iguais aos do primeiro arquivo.
        /// </summary>
        [TestMethod]
        [TestCategory("Comm Critica")]
        public void SAP_4194()
        {
            //iniciar
            IniciarTeste(TipoArquivo.OCRCobranca, "4196", "FG05 - PROC22");

            //Carregar arquivo ods
            var arquivoods = new Arquivo_Layout_9_3_OcrCobranca();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.VIVO);
            EnviarParaOds(arquivoods);

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.OCRCobranca, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            //Salvar e executar
            SalvarArquivo();
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "22", 1);
        }
    }
}
