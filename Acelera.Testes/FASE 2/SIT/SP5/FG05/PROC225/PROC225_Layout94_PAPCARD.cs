using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC225
{
    [TestClass]
    public class PROC225_Layout94_PAPCARD : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9255()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9255", "FG05 - PROC219 - ");


            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 2, OperadoraEnum.PAPCARD);
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(ref arquivo);

            contratoRegras.CriarNovoContrato(0,arquivo);
            var campos = new string[] 
            { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO", "CD_COBERTURA","NR_SEQUENCIAL_EMISSAO","TIPO_EMISSAO", "NR_ENDOSSO" };

            ArquivoUtils.IgualarCampos(arquivo.ObterLinha(0), arquivo.ObterLinha(1), campos);

            SalvarArquivo();

            ExecutarEValidarAteFg02(arquivo);
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9256()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9256", "FG05 - PROC46 - ");

            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);

            contratoRegras.CriarNovoContrato(0,arquivo);
            //arquivoods1.AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            //arquivoods1.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            //arquivoods1.AlterarLinha(0, "NR_ENDOSSO", "0");

            EnviarParaOdsAlterandoCliente(arquivoods1);

            IniciarTeste(TipoArquivo.ParcEmissao, "9180", "FG05 - PROC46 - ");

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);
            var campos = new string[]
            { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO", "CD_COBERTURA","NR_SEQ_EMISSAO","TIPO_EMISSAO", "NR_ENDOSSO" };

            ArquivoUtils.IgualarCampos(arquivoods1.ObterLinha(0), arquivo.ObterLinha(0), campos);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9257()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9257", "SAP-9257:FG05 - PROC 225 - C/C - PAPCARD - PARCELA - Enviar 2x o mesmo endosso - Arquivos diferentes");

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(ref arquivo);

            contratoRegras.CriarNovoContrato(0,arquivo);
            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            var parc1 = arquivo.Clone();

            EnviarParaOdsAlterandoCliente(arquivo);


            arquivo = parc1;
            ReplicarLinhaComCorrecao(0, 1);

            AlterarLinha(1, "CD_CLIENTE", dados.ObterCdClienteParceiro(false));

            RemoverLinhaComAjusteDeFooter(0);

            SalvarArquivo();

            ExecutarEValidarAteFg02(arquivo);
        }
    }
}
