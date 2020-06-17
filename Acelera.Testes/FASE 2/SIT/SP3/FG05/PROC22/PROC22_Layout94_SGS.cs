using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC22
{
    [TestClass]
    public class PROC22_Layout942_SGS : TestesFG05
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
            arquivo = new Arquivo_Layout_9_4_2();
            CarregarArquivo(arquivo ,1 , OperadoraEnum.SGS);

            EnviarParaOds(arquivo, true, "PROC22_4196");
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_2();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SGS);

            //Alterar arquivo
            var campos = dados.ObterAtributosDoLayout(TipoArquivo.Sinistro, "9.4");
            IgualarCampos(arquivoods, arquivo, campos);

            //Salvar e executar
            SalvarArquivo(false, "PROC22_4196");
            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "22", 1);
        }
    }
}
