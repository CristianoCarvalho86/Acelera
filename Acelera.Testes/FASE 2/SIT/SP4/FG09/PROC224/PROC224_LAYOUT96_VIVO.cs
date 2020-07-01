﻿using Acelera.Data;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Acelera.Domain.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC224
{
    [TestClass]
    public class PROC224_LAYOUT96_VIVO : TestesFG09
    {
        private OperadoraEnum operacaoDoTeste => OperadoraEnum.VIVO;

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5255()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5255", "FG09 - PROC224 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "9"));
            

            EnviarParaOds(arquivo);
            var arquivoods2 = arquivo.Clone();

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods2.ObterLinha(0), "9");
            
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "224", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5256()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5256", "FG09 - PROC224 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste,true);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
            AlterarHeader("VERSAO", "9.6");
            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10"));


            EnviarParaOds(arquivo);
            var arquivoods2 = arquivo.Clone();

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods2.ObterLinha(0), "10");
            
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "224", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5257()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5257", "FG09 - PROC224 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
            AlterarHeader("VERSAO", "9.6");
            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "11"));


            EnviarParaOds(arquivo);
            var arquivoods2 = arquivo.Clone();

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods2.ObterLinha(0), "11");
            
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "224", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5258()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5258", "FG09 - PROC224 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
            AlterarHeader("VERSAO", "9.6");
            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "12"));


            EnviarParaOds(arquivo);
            var arquivoods2 = arquivo.Clone();

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods2.ObterLinha(0), "12");
            
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "224", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5259()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5259", "FG09 - PROC224 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
            AlterarHeader("VERSAO", "9.6");
            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "13"));


            EnviarParaOds(arquivo);
            var arquivoods2 = arquivo.Clone();

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods2.ObterLinha(0), "13");
            
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "224", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5260()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5260", "FG09 - PROC224 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
            AlterarHeader("VERSAO", "9.6");
            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "21"));


            EnviarParaOds(arquivo);
            var arquivoods2 = arquivo.Clone();

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods2.ObterLinha(0), "21");
            
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "224", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5261()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5261", "FG09 - PROC224 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
            AlterarHeader("VERSAO", "9.6");
            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "11"));


            EnviarParaOds(arquivo);
            var arquivoods2 = arquivo.Clone();

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods2.ObterLinha(0), "21");
            
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "224", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5262()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5262", "FG09 - PROC224 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true, "5", 2);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
            AlterarHeader("VERSAO", "9.6");
            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(1), "11"));


            EnviarParaOds(arquivo);
            var arquivoods2 = arquivo.Clone();

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "21");
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "224", 1);

        }

    }
}
