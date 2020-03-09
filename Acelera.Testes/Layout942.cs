﻿using System;
using System.Configuration;
using System.Linq;
using Acelera.Data;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Acelera.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes
{
    [TestClass]
    public class Layout942 : TestesFG00
    {
        [TestMethod]
        public void Altera_NM_BENEFICIARIO_Valor_Incorreto()
        {
            IniciarTeste(TipoArquivo.ParcEmissao,"NUMERO_DO_TESTE", "Altera_NM_BENEFICIARIO_Valor_Incorreto");
            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0005-20200103.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(1);
            //ReplicarFooter(2);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.PARCEMS-EV-0005-20200103.txt", false));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());
            //ValidarLogProcessamento(true);

            ////VALIDAR NO BANCO A ALTERACAO
            ValidarStages(true, (int)CodigoStage.AprovadoNAFG00);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");

        }

        [TestMethod]
        public void TesteOCRCObranca()
        {
            IniciarTeste(TipoArquivo.OCRCobranca,"NUMERO_DO_TESTE", "Altera_NM_BENEFICIARIO_Valor_Incorreto");
            //CARREGAR O ARQUIVO BASE
            var arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.COBRANCA-EV-9994-20191230.txt"));

            //ALTERAR O VALOR SELECIONADO
            //RemoverHeader(arquivo);
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.COBRANCA-EV-/*R*/-20191230.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao("FGR_00_BAIXA_PARCELA");

            //VALIDAR NO BANCO A ALTERACAO
            ValidarStages(true, 110);
            //ValidarLogProcessamento(true);
            ValidarControleArquivo(new string[] {});
            ValidarTabelaDeRetorno(new string[] {});


        } 
        [TestMethod]
        public void TesteCliente()
        {
            IniciarTeste(TipoArquivo.Cliente,"NUMERO_DO_TESTE", "Altera_NM_BENEFICIARIO_Valor_Incorreto");
            //CARREGAR O ARQUIVO BASE
            var arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverHeader();
            //SelecionarLinhaParaValidacao(arquivo, 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao("FGR_00_CLIENTE");

            //VALIDAR NO BANCO A ALTERACAO
            ValidarStages<LinhaOCRCobrancaStage>(TabelasEnum.Cliente, false);
            //ValidarLogProcessamento(true);
            ValidarControleArquivo(new string[] { "Estrutura de header (01) nao encontrada" });
            ValidarTabelaDeRetorno(new string[] {"95"});


        }

        [TestMethod]
        public void ABC()
        {
            DBHelper helper = DBHelper.Instance;
            var table = helper.GetData("select now() from dummy");

        }
        [Ignore]
        [TestMethod]
        public void Altera_EN_BENEFICIARIO_Valor_Incorreto()
        {
            //throw new Exception();


        }
    }
}
