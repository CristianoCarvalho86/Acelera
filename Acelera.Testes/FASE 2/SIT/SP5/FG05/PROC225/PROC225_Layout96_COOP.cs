﻿using Acelera.Domain.Entidades.Stages;
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
    public class PROC225_Layout96_COOP : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9251()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-9251:FG05 - PROC 225 - C/C - PARCELA - Enviar 2x o mesmo endosso - 2 parcelas - Mesmo arquivo");


            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);
            contratoRegras.CriarNovoContrato(0,arquivo);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo,0);
            
            CriarNovaLinhaParaEmissao(arquivo, 0);
            CriarNovaLinhaParaEmissao(arquivo, 1);

            ArquivoUtils.IgualarCampos(arquivo.ObterLinha(1), arquivo.ObterLinha(0), new string[]{ "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO", "CD_COBERTURA","NR_SEQUENCIAL_EMISSAO","CD_TIPO_EMISSAO", "NR_ENDOSSO" });


            SalvarArquivo();

            //SelecionarLinhaParaValidacao(0);
            //ValidarFGsAnteriores();
            //ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "219", 1);
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9252()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-9252:FG05 - PROC 225 - C/C - PARCELA - Enviar 2x o mesmo endosso - Diferentes contratos - Mesmo arquivo");

            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.COOP);

            contratoRegras.CriarNovoContrato(0,arquivo);
            //arquivoods1.AlterarLinha(0, "CD_CD_TIPO_EMISSAO", "1");
            //arquivoods1.AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            //arquivoods1.AlterarLinha(0, "NR_ENDOSSO", "0");

            EnviarParaOdsAlterandoCliente(arquivoods1);

            IniciarTeste(TipoArquivo.ParcEmissao, "9180", "FG05 - PROC46 - ");

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivoods1, 1, OperadoraEnum.PAPCARD);
            var campos = new string[]
            { "CD_CONTRATO", "NR_APOLICE", "NR_PROPOSTA", "ID_TRANSACAO", "CD_COBERTURA","NR_SEQ_EMISSAO","CD_TIPO_EMISSAO", "NR_ENDOSSO" };

            ArquivoUtils.IgualarCampos(arquivoods1.ObterLinha(0), arquivo.ObterLinha(0), campos);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "46", 1);
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9253()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-9254:FG05 - PROC 225 - S/C - PARCELA - Enviar contrato único");


            //Envia parc normal
            var arquivoods1 = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivoods1, 2, OperadoraEnum.COOP);

            contratoRegras.CriarNovoContrato(0,arquivo);
            contratoRegras.CriarNovoContrato(1, arquivo);
            var campos = new string[]
            { "CD_COBERTURA","NR_SEQ_EMISSAO","CD_TIPO_EMISSAO", "NR_ENDOSSO" };
            ArquivoUtils.IgualarCampos(arquivoods1.ObterLinha(0), arquivoods1.ObterLinha(1), campos);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }
    }
}
