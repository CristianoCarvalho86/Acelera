using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC22
{
    [TestClass]
    public class PROC22_Layout94_LASA : TestesFG05
    {

        /// <summary>
        /// Gerar um arquivo anteriormente que popule a tabela ODS que não possua nenhum item a ser criticado. 
        /// Em outro arquivo, enviar as mesmas informações do arquivo anterior nos campos da tabela TAB_PRM_LAYOUT_7016 para o NM_TIPO_ARQUIVO= SINISTRO, CD_VERSAO_ARQUIVO=9.4, TP_REGISTRO=3 e ID_PRIMARY_KEY=1.
        /// Todos os campos exibidos nessa consulta na coluna NM_ATRIBUTO_LAYOUT devem ser iguais aos do primeiro arquivo.
        /// </summary>
        [TestMethod]
        [TestCategory("Comm Critica")]
        public void SAP_4196()
        {
            //iniciar
            IniciarTeste(TipoArquivo.Sinistro, "4196", "FG05 - PROC22");

            //Carregar arquivo ods
            var arquivoods = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivoods ,1 , OperadoraEnum.LASA);
            EnviarParaOds(arquivoods);

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Sinistro, "9.4");
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
        public void SAP_4191()
        {
            //iniciar
            IniciarTeste(TipoArquivo.ParcEmissao, "4191", "FG05 - PROC22");

            //Carregar arquivo ods
            var arquivoods = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.LASA);
            EnviarParaOds(arquivoods);

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.ParcEmissao, "9.4");
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
            var arquivoods = new Arquivo_Layout_9_4_Cliente();
            CarregarArquivo(arquivoods, 1, OperadoraEnum.LASA);
            EnviarParaOds(arquivoods);

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

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
            IniciarTeste(TipoArquivo.Comissao, "4193", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            EnviarParaOds(arquivo, true, "PROC22_4193");
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Comissao, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            //Salvar e executar
            SalvarArquivo(true, "PROC22_4193");
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
            IniciarTeste(TipoArquivo.OCRCobranca, "4194", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            EnviarParaOds(arquivo, true, "PROC22_4194");
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.OCRCobranca, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            //Salvar e executar
            SalvarArquivo(true, "PROC22_4194");
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "22", 1);
        }

        /// <summary>
        /// Gerar um arquivo anteriormente que popule a tabela ODS que não possua nenhum item a ser criticado. 
        /// Em outro arquivo, enviar as mesmas informações do arquivo anterior nos campos da tabela TAB_PRM_LAYOUT_7016 para o NM_TIPO_ARQUIVO= SINISTRO, CD_VERSAO_ARQUIVO=9.4, TP_REGISTRO=3 e ID_PRIMARY_KEY=1.
        /// Todos os campos exibidos nessa consulta na coluna NM_ATRIBUTO_LAYOUT devem ser iguais aos do primeiro arquivo.
        /// </summary>
        [TestMethod]
        [TestCategory("Comm Critica")]
        public void SAP_4195()
        {
            //iniciar
            IniciarTeste(TipoArquivo.LanctoComissao, "4195", "FG05 - PROC22");

            //Carregar arquivo ods
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            EnviarParaOds(arquivo, true, "PROC22_4195");
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.LanctoComissao, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            //Salvar e executar
            SalvarArquivo(true, "PROC22_4195");
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "22", 1);
        }
    }
}
