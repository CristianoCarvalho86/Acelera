using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG07
{
    [TestClass]
    public class FG07_LASA
    {
        [TestMethod]
        public void SAP_6154()
        {
            //  SAP-6154:FG07 - Lasa - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C - Novo cliente
            InicioTesteFG07("6154", "FG07 - Lasa - Geração XML Sucesso - Emissão 1a parcela - 1 cobertura - Comissão C - Novo cliente", OperadoraEnum.LASA);

            triplice.AlterarParcEComissao(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracaoECobertura
                (triplice.ArquivoComissao.Header[0]["CD_TPA"], "C", triplice.ArquivoParcEmissao[0]["CD_COBERTURA"]));
            triplice.ArquivoComissao.AlterarLinha(0, "CD_TIPO_COMISSAO", "C");
            CriarEmissaoCompleta();
            ChamarExecucao(FG07_Tarefas.Trinca.ObterTexto());
            var linhaStageParc = ValidarStageSucessoFG07();

            validadorXML.ValidarInclusaoNasTabelas(linhaStageParc, "1210", false, out string idArquivo);
            ValidarXMLComTabelasOIM(idArquivo, false);

        }
    }
}
