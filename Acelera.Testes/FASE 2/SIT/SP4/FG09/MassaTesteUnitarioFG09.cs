using Acelera.Data;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09
{
    [TestClass]
    public class MassaTesteUnitarioFG09 : TestesFG09
    {
        [TestMethod]
        public void Teste1()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste1", "FG09");

            var arquivoParc = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            var arquivoComissao = new Arquivo_Layout_9_3_EmsComissao();
            //EnviarEmissao(arquivoParc, arquivoComissao, OperadoraEnum.VIVO);
            arquivoParc.Carregar(ObterArquivoOrigem("ODS_TESTE1_FG09_C01.VIVO.PARCEMSAUTO-EV-0386-20200130.TXT"));
            EnviarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto, Arquivo_Layout_9_3_EmsComissao>(arquivoParc.ObterLinha(0), OperadoraEnum.VIVO, "9");
            arquivo = arquivoParc;
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO","50");
            //AlterarLinha(0, "CD_CONTRATO", "7231060360358");
            EnviarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto, Arquivo_Layout_9_3_EmsComissao>(arquivo.ObterLinha(0).Clone(), OperadoraEnum.VIVO, "9",false,"50");
            /*
             Enviar arquivo PARCEMSAUTO para ODS com dados de emissão de um contrato
Enviar arquivo PARCEMSAUTO com movimentação de cancelamento para este mesmo contrato (CD_TIPO_EMISSAO=9). Preencher todos os campos relativos ao cancelamento
Enviar arquivo PARCEMSAUTO com outra movimentação de cancelamento para este mesmo contrato (CD_TIPO_EMISSAO=9). Preencher todos os campos relativos ao cancelamento
             */
        }

        [TestMethod]
        public void Teste2()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste2-FG09", "FG09");

            var arquivoParc = new Arquivo_Layout_9_4_ParcEmissao();
            var arquivoComissao = new Arquivo_Layout_9_4_EmsComissao();
            EnviarEmissao(arquivoParc, arquivoComissao, OperadoraEnum.LASA);
            EnviarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivoParc.ObterLinha(0), OperadoraEnum.LASA, "11");
            EnviarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivoParc.ObterLinha(0), OperadoraEnum.LASA, "10");
            /*
Enviar arquivo PARCEMS para ODS com dados de emissão de um contrato
Enviar arquivo PARCEMS com movimentação de cancelamento para este mesmo contrato (CD_TIPO_EMISSAO=11). Preencher todos os campos relativos ao cancelamento
Enviar arquivo PARCEMS com outra movimentação de cancelamento para este mesmo contrato (CD_TIPO_EMISSAO=10). Preencher todos os campos relativos ao cancelamento
             */
        }

        [TestMethod]
        public void Teste3()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "Teste3-FG09", "FG09");
            var arquivoParc = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            var arquivoComissao = new Arquivo_Layout_9_3_EmsComissao();
            EnviarEmissao(arquivoParc, arquivoComissao, OperadoraEnum.VIVO, "1");
            arquivoParc.AlterarLinhaSeExistirCampo(0, "CD_MODELO", "023105-5");

            EnviarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto, Arquivo_Layout_9_3_EmsComissao>(arquivoParc.ObterLinha(0), OperadoraEnum.VIVO, "10");
            /*
Enviar arquivo PARCEMSAUTO para ODS com dados de emissão de um contrato - Parcela 1
Enviar arquivo PARCEMSAUTO com movimentação de cancelamento para este mesmo contrato (CD_TIPO_EMISSAO=10), referenciando a outro Cd_MODELO.. Preencher todos os campos relativos a cancelamento
             */
        }

        [TestMethod]
        public void Teste4()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste4-FG09", "FG09");

            var arquivoParc = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            var arquivoComissao = new Arquivo_Layout_9_3_EmsComissao();
            EnviarEmissao(arquivoParc, arquivoComissao, OperadoraEnum.VIVO, "", true);
            SetDev();
            AlterarLinha(arquivoParc, 0, "CD_RAMO", dados.ObterRamoDiferente(ObterValor(0, "CD_RAMO")));
            SetQA();
            EnviarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto, Arquivo_Layout_9_3_EmsComissao>(arquivoParc.ObterLinha(0).Clone(), OperadoraEnum.VIVO, "10", true);
            /*
Enviar arquivo PARCEMSAUTO para ODS com dados de emissão de um contrato com ramo parametrizado (tabela 7007)
Enviar arquivo PARCEMSAUTO com o cancelamento da emissão anterior, com um codigo de ramo diferente da emissão, mas parametrizado na 7007
             */
        }

        [TestMethod]
        public void Teste5()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste5-FG09", "FG09");
            var arquivoParc = new Arquivo_Layout_9_4_ParcEmissao();
            var arquivoComissao = new Arquivo_Layout_9_4_EmsComissao();
            EnviarEmissao(arquivoParc, arquivoComissao, OperadoraEnum.POMPEIA, "", true);
            EnviarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivoParc.ObterLinha(0), OperadoraEnum.POMPEIA, "10", true);
            /*
Enviar arquivo PARCEMS para ODS com dados de emissão de um contrato com ramo parametrizado (tabela 7007)
Enviar arquivo PARCEMS com o cancelamento da emissão anterior, com um codigo de ramo igual da emissão
             */
        }

        [TestMethod]
        public void Teste6()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste6-FG09", "FG09");

            var arquivoParc = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            var arquivoComissao = new Arquivo_Layout_9_3_EmsComissao();
            EnviarEmissao(arquivoParc, arquivoComissao, OperadoraEnum.VIVO, "", true);
            arquivo = arquivoParc;
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValor(0, "VL_PREMIO_LIQUIDO", 100M));
            EnviarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto, Arquivo_Layout_9_3_EmsComissao>(arquivo.ObterLinha(0).Clone(), OperadoraEnum.VIVO, "10", true);
            /*
Enviar arquivo PARCEMSAUTO para ODS com dados de emissão de uma única parcela
"Enviar arquivo de cancelamento para esta parcela, informando VL PREMIO LIQUIDO maior que do registro de emissao
Cancelamento deve ser do tipo com restituição (Cd_MOVTO_COBRANÇA=02)"
             */
        }
        [TestMethod]
        public void Teste7()
        {
            //VER COM A LORENA
            //DS_MENSAGEM : Número da Parcela deve ser 1
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste7-FG09", "FG09");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, OperadoraEnum.SOFTBOX, Parametros.pastaOrigem), 1, 1, 1);
            ReplicarLinhaComCorrecao(0, 2);
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_PARCELA", "1");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "100");
            AlterarLinha(0, "VL_IOF", "10");
            AlterarLinha(0, "VL_PREMIO_TOTAL", "110");

            AlterarLinha(1, "ID_TRANSACAO_CANC", "");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "NR_ENDOSSO", "2");
            AlterarLinha(1, "NR_PARCELA", "2");
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(1, "VL_PREMIO_LIQUIDO", "100");
            AlterarLinha(1, "VL_IOF", "10");
            AlterarLinha(1, "VL_PREMIO_TOTAL", "110");

            AlterarLinha(2, "ID_TRANSACAO_CANC", "");
            AlterarLinha(2, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(2, "NR_ENDOSSO", "3");
            AlterarLinha(2, "NR_PARCELA", "3");
            AlterarLinha(2, "NR_SEQUENCIAL_EMISSAO", "3");
            AlterarLinha(2, "VL_PREMIO_LIQUIDO", "100");
            AlterarLinha(2, "VL_IOF", "10");
            AlterarLinha(2, "VL_PREMIO_TOTAL", "110");

            PrepararMassa(arquivo, out string tipoComissao);

            SalvarArquivo(true);

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);


            var arquivoParc = arquivo.Clone();
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, OperadoraEnum.SOFTBOX, Parametros.pastaOrigem), 1, 1, 1);
            ReplicarLinhaComCorrecao(0, 2);
            IgualarCamposQueExistirem(arquivoParc, arquivo);
            AlterarTodasAsLinhas("CD_TIPO_COMISSAO", tipoComissao);

            SalvarArquivo(true);

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            arquivoParc.AlterarLinha(0, "VL_PREMIO_LIQUIDO", "1000");
            EnviarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivoParc.ObterLinha(0), OperadoraEnum.SOFTBOX, "10", false, "4");
            /*
Enviar arquivo PARCEMSAUTO para ODS com dados de emissão de tres parcelas 
"Enviar arquivo de cancelamento para esta parcela, informando VL PREMIO LIQUIDO maior que a soma dos valores de premio liquido das tres parcelas
Cancelamento deve ser do tipo com restituição (Cd_MOVTO_COBRANÇA=02)"
             */
        }

        [TestMethod]
        public void Teste8()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste8-FG09", "FG09");

            var arquivoParc = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            var arquivoComissao = new Arquivo_Layout_9_3_EmsComissao();
            EnviarEmissao(arquivoParc, arquivoComissao, OperadoraEnum.VIVO, "", false);
            arquivo = arquivoParc;
            AlterarLinha(0, "DT_INICIO_VIGENCIA", SomarData(0, "DT_INICIO_VIGENCIA", -2));
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(0, "DT_FIM_VIGENCIA", -2));
            AlterarLinha(0, "DT_EMISSAO", SomarData(0, "DT_INICIO_VIGENCIA", 0));
            EnviarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto, Arquivo_Layout_9_3_EmsComissao>(arquivo.ObterLinha(0).Clone(), OperadoraEnum.VIVO, "10", false);
            /*
Enviar arquivo PARCEMS para ODS com dados de emissão de uma única parcela
Enviar arquivo de cancelamento para esta parcela, informando DT_INICIO_VIGENCIA inferior a DT_INICIO_VIGENCIA da parcela a ser cancelada
             */
        }

        [TestMethod]
        public void Teste9()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste9-FG09", "FG09");

            var arquivoParc = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            var arquivoComissao = new Arquivo_Layout_9_3_EmsComissao();
            EnviarEmissao(arquivoParc, arquivoComissao, OperadoraEnum.VIVO, "", false);
            arquivo = arquivoParc;
            AlterarLinha(0, "DT_INICIO_VIGENCIA", SomarData(0, "DT_INICIO_VIGENCIA", 2));
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(0, "DT_FIM_VIGENCIA", 2));
            AlterarLinha(0, "DT_EMISSAO", SomarData(0, "DT_INICIO_VIGENCIA", 0));
            EnviarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto, Arquivo_Layout_9_3_EmsComissao>(arquivo.ObterLinha(0).Clone(), OperadoraEnum.VIVO, "10", false);
            /*
Enviar arquivo PARCEMS para ODS com dados de emissão de uma única parcela
Enviar arquivo de cancelamento para esta parcela, informando DT_FIM_VIGENCIA superior a DT_FIM_VIGENCIA da parcela a ser cancelada
             */
        }

        [TestMethod]
        public void Teste10()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste10-FG09", "FG09");

            var arquivoParc = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            var arquivoComissao = new Arquivo_Layout_9_3_EmsComissao();
            EnviarEmissao(arquivoParc, arquivoComissao, OperadoraEnum.VIVO, "", true);
            arquivo = arquivoComissao;
            EnviarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto, Arquivo_Layout_9_3_EmsComissao>(arquivoParc.ObterLinha(0).Clone(), OperadoraEnum.VIVO, "10", true, "", SomarValor(0, "VL_COMISSAO", 1000M));

            /*
Enviar arquivo COMISSAO para ODS com dados de emissão de uma única parcela
"Enviar arquivo de cancelamento para esta parcela, informando valor de comissão maior que do registro de emissao
Cancelamento deve ser do tipo com restituição (Cd_MOVTO_COBRANÇA=02)"
             */
        }

        [TestMethod]
        public void Teste11()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste11-FG09", "FG09");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, OperadoraEnum.LASA, Parametros.pastaOrigem), 1, 1, 1);
            ReplicarLinhaComCorrecao(0, 2);
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_PARCELA", "1");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "100");
            AlterarLinha(0, "VL_IOF", "10");
            AlterarLinha(0, "VL_PREMIO_TOTAL", "110");

            AlterarLinha(1, "ID_TRANSACAO_CANC", "");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "NR_ENDOSSO", "2");
            AlterarLinha(1, "NR_PARCELA", "2");
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(1, "VL_PREMIO_LIQUIDO", "100");
            AlterarLinha(1, "VL_IOF", "10");
            AlterarLinha(1, "VL_PREMIO_TOTAL", "110");
            AlterarHeader("VERSAO", "9.6");

            PrepararMassa(arquivo, out string tipoComissao);

            SalvarArquivo(true);

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);


            var arquivoParc = arquivo.Clone();
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, OperadoraEnum.LASA, Parametros.pastaOrigem), 1, 1, 1);
            ReplicarLinhaComCorrecao(0, 2);
            IgualarCamposQueExistirem(arquivoParc, arquivo);
            AlterarTodasAsLinhas("CD_TIPO_COMISSAO", tipoComissao);
            AlterarHeader("VERSAO", "9.6");
            SalvarArquivo(true);

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            EnviarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivoParc.ObterLinha(0), OperadoraEnum.LASA, "10", true, "3", "99999");

            /*
Enviar arquivo COMISSAO para ODS com dados de emissão de duas parcelas 
"Enviar arquivo de cancelamento para esta parcela, informando valor de comissão maior que a soma dos valor de comissao das duas parcelas
Cancelamento deve ser do tipo com restituição (Cd_MOVTO_COBRANÇA=02)"
             */
        }

        [TestMethod]
        public void Teste12()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste12-FG09", "FG09");

            var arquivoParc = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            var arquivoComissao = new Arquivo_Layout_9_3_EmsComissao();
            EnviarEmissao(arquivoParc, arquivoComissao, OperadoraEnum.VIVO, "", true);
            arquivo = arquivoParc;
            AlterarLinha(0, "VL_ADIC_FRACIONADO", SomarValor(0, "VL_ADIC_FRACIONADO", 1000M));
            EnviarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto, Arquivo_Layout_9_3_EmsComissao>(arquivo.ObterLinha(0).Clone(), OperadoraEnum.VIVO, "10", true);

            /*
Enviar arquivo PARCEMSAUTO para ODS com dados de emissão de uma única parcela
"Enviar arquivo de cancelamento para esta parcela, informando VL ADICI. FRACIONAMENTO maior que do registro de emissao
Cancelamento deve ser do tipo com restituição (Cd_MOVTO_COBRANÇA=02)"
             */
        }

        [TestMethod]
        public void Teste13()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste13-FG09", "FG09");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, OperadoraEnum.POMPEIA, Parametros.pastaOrigem), 1, 1, 1);
            ReplicarLinhaComCorrecao(0, 2);
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "NR_PARCELA", "1");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "100");
            AlterarLinha(0, "VL_IOF", "10");
            AlterarLinha(0, "VL_PREMIO_TOTAL", "110");
            AlterarLinha(0, "VL_ADIC_FRACIONADO", "110");

            AlterarLinha(1, "ID_TRANSACAO_CANC", "");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(1, "NR_ENDOSSO", "2");
            AlterarLinha(1, "NR_PARCELA", "2");
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(1, "VL_PREMIO_LIQUIDO", "100");
            AlterarLinha(1, "VL_IOF", "10");
            AlterarLinha(1, "VL_PREMIO_TOTAL", "110");
            AlterarLinha(1, "VL_ADIC_FRACIONADO", "110");

            PrepararMassa(arquivo, out string tipoComissao);

            SalvarArquivo(true);

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);


            var arquivoParc = arquivo.Clone();
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, OperadoraEnum.POMPEIA, Parametros.pastaOrigem), 1, 1, 1);
            ReplicarLinhaComCorrecao(0, 2);
            IgualarCamposQueExistirem(arquivoParc, arquivo);
            AlterarTodasAsLinhas("CD_TIPO_COMISSAO", tipoComissao);

            SalvarArquivo(true);

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            arquivoParc.AlterarLinha(0, "VL_ADIC_FRACIONADO", "1000");
            EnviarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivoParc.ObterLinha(0), OperadoraEnum.POMPEIA, "10", false, "4");

            /*
Enviar arquivo PARCEMSAUTO para ODS com dados de emissão de duas parcelas 
"Enviar arquivo de cancelamento para esta parcela, informando VL ADICI. FRACIONAMENTO maior que a soma dos adi_fraes de premio liquido das duas parcelas
Cancelamento deve ser do tipo com restituição (Cd_MOVTO_COBRANÇA=02)"
             */
        }

        [TestMethod]
        public void Teste14()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste14-FG09", "FG09");

            var arquivoParc = new Arquivo_Layout_9_4_ParcEmissao();
            var arquivoComissao = new Arquivo_Layout_9_4_EmsComissao();
            EnviarEmissao(arquivoParc, arquivoComissao, OperadoraEnum.LASA, "", true);
            arquivo = arquivoParc;
            AlterarLinha(0, "VL_IOF", SomarValor(0, "VL_IOF", 100M));
            EnviarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivo.ObterLinha(0).Clone(), OperadoraEnum.LASA, "10", true);

            /*
Enviar arquivo PARCEMSAUTO para ODS com dados de emissão de uma única parcela
"Enviar arquivo de cancelamento para esta parcela, informando VL IOF maior que do registro de emissao
Cancelamento deve ser do tipo com restituição (Cd_MOVTO_COBRANÇA=02)"
             */
        }

        [TestMethod]
        public void Teste15()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste15-FG09", "FG09");

            var arquivoParc = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            var arquivoComissao = new Arquivo_Layout_9_3_EmsComissao();
            EnviarEmissao(arquivoParc, arquivoComissao, OperadoraEnum.VIVO, "", true);
            arquivo = arquivoParc;
            AlterarLinha(0, "VL_CUSTO_APOLICE", SomarValor(0, "VL_CUSTO_APOLICE", 1000M));
            EnviarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto, Arquivo_Layout_9_3_EmsComissao>(arquivo.ObterLinha(0).Clone(), OperadoraEnum.VIVO, "10", true);

            /*
Enviar arquivo PARCEMSAUTO para ODS com dados de emissão de uma única parcela
"Enviar arquivo de cancelamento para esta parcela, informando VL CUSTO maior que do registro de emissao
Cancelamento deve ser do tipo com restituição (Cd_MOVTO_COBRANÇA=02)"
             */
        }

        [TestMethod]
        public void Teste16()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste16-FG09", "FG09");

            var arquivoParc = new Arquivo_Layout_9_4_ParcEmissao();
            var arquivoComissao = new Arquivo_Layout_9_4_EmsComissao();
            EnviarEmissao(arquivoParc, arquivoComissao, OperadoraEnum.POMPEIA, "", true);
            arquivo = arquivoParc;
            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(arquivo.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            EnviarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivo.ObterLinha(0).Clone(), OperadoraEnum.POMPEIA, "10", true);

            /*
Enviar arquivo PARCEMSAUTO para ODS com dados de emissão de uma parcela com duas coberturas
Enviar cancelamento para apenas uma das coberturas
             */
        }

        [TestMethod]
        public void Teste17()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste17-FG09", "FG09");

            var arquivoParc = new Arquivo_Layout_9_4_ParcEmissao();
            var arquivoComissao = new Arquivo_Layout_9_4_EmsComissao();
            EnviarEmissao(arquivoParc, arquivoComissao, OperadoraEnum.SOFTBOX, "", false);
            arquivo = arquivoParc;
            AlterarLinha(0, "CD_CONTRATO", AlterarUltimasPosicoes(arquivo.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(8)));
            EnviarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivo.ObterLinha(0).Clone(), OperadoraEnum.SOFTBOX, "10", false);

            /*
Enviar arquivo PARCEMSAUTO para ODS com dados de emissão de uma parcela com duas coberturas
Enviar cancelamento para apenas uma das coberturas
             */
        }

        [TestMethod]
        public void Teste18()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste18-FG09", "FG09");

            var arquivoParc = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            var arquivoComissao = new Arquivo_Layout_9_3_EmsComissao();
            EnviarEmissao(arquivoParc, arquivoComissao, OperadoraEnum.VIVO, "", true);
            EnviarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto, Arquivo_Layout_9_3_EmsComissao>(arquivoParc.ObterLinha(0).Clone(), OperadoraEnum.VIVO, "10", true, "", "", "01");

            /*
Enviar arquivo PARCEMSAUTO para ODS com dados de emissão e com status de pagamento PG
Enviar cancelamento dessa parcela com Cd_MOVTO_COBRANCA=01
             */
        }

        [TestMethod]
        public void Teste19()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste19-FG09", "FG09");

            var arquivoParc = new Arquivo_Layout_9_4_ParcEmissao();
            var arquivoComissao = new Arquivo_Layout_9_4_EmsComissao();
            EnviarEmissao(arquivoParc, arquivoComissao, OperadoraEnum.LASA, "", true);
            EnviarCancelamento<Arquivo_Layout_9_4_ParcEmissao, Arquivo_Layout_9_4_EmsComissao>(arquivoParc.ObterLinha(0).Clone(), OperadoraEnum.LASA, "10", true, "50", "", "03");
            /*
Enviar arquivo PARCEMS para ODS com dados de emissão e com status de pagamento PG
Enviar cancelamento dessa parcela com Cd_MOVTO_COBRANCA=03
             */
        }

        public void EnviarCancelamento<T, C>(LinhaArquivo linhaArquivoEmissao, OperadoraEnum operadora, string cdTipoEmissao,
            bool alterarLayout = false, string nrSequencialEmissao = "", string valorComissao = "", string cdMovtoCobranca = "") where T : Arquivo, new() where C : Arquivo, new()
        {
            logger.Escrever($"CRIANDO ARQUIDO DE PARC_EMISSAO PARA CANCELAMENTO - {operadora.ObterTexto()}");
            arquivo = new T();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, 1);
            var idTransacaoDoArquivoOriginal = arquivo.ObterLinha(0).ObterCampoSeExistir("ID_TRANSACAO").ValorFormatado;
            RemoverTodasAsLinhas();
            AdicionarLinha(0, linhaArquivoEmissao.Clone());

            AlterarLinhaSeExistirCampo(arquivo, 0, "ID_TRANSACAO_CANC", linhaArquivoEmissao.ObterCampoDoArquivo("ID_TRANSACAO").ValorFormatado);
            AlterarLinhaSeExistirCampo(arquivo, 0, "ID_TRANSACAO", idTransacaoDoArquivoOriginal);
            AlterarLinhaSeExistirCampo(arquivo, 0, "CD_TIPO_EMISSAO", cdTipoEmissao);
            AlterarLinhaSeExistirCampo(arquivo, 0, "NR_PARCELA", SomarValor(0, "NR_PARCELA", 1M));
            AlterarLinhaSeExistirCampo(arquivo, 0, "NR_ENDOSSO", "4");
            AlterarLinhaSeExistirCampo(arquivo, 0, "NR_SEQUENCIAL_EMISSAO", "2");
            if (!string.IsNullOrEmpty(nrSequencialEmissao))
                AlterarLinhaSeExistirCampo(arquivo, 0, "NR_SEQUENCIAL_EMISSAO", nrSequencialEmissao);

            AlterarLinhaSeExistirCampo(arquivo, 0, "CD_MOVTO_COBRANCA", "02");
            if (!string.IsNullOrEmpty(cdMovtoCobranca))
                AlterarLinhaSeExistirCampo(arquivo, 0, "CD_MOVTO_COBRANCA", cdMovtoCobranca);

            if (alterarLayout)
                arquivo.AlterarHeader("VERSAO", "9.6");

            SalvarArquivo(true);

            logger.Escrever("ARQUIVO CRIADO COM O NOME : " + arquivo.NomeArquivo);

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            var arquivoParc = arquivo.Clone();

            logger.Escrever($"CRIANDO ARQUIDO DE COMISSAO PARA CANCELAMENTO - {operadora.ObterTexto()}");

            arquivo = new C();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, 1);
            IgualarCamposQueExistirem(arquivoParc, arquivo);
            AlterarLinhaSeExistirCampo(arquivo, 0, "CD_TIPO_COMISSAO", operadora == OperadoraEnum.VIVO ? "C" : "P");
            if (!string.IsNullOrEmpty(valorComissao))
                AlterarLinhaSeExistirCampo(arquivo, 0, "VL_COMISSAO", valorComissao);
            SalvarArquivo(true);

            logger.Escrever("ARQUIVO CRIADO COM O NOME : " + arquivo.NomeArquivo);

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
        }

        public void EnviarEmissao(Arquivo arquivoParc, Arquivo arquivoComissao, OperadoraEnum operadora, string nrParcela = "", bool alterarLayout = false, int numeroParcelas = 0, string cdTipoEmissao = "")
        {
            logger.Escrever($"CRIANDO ARQUIDO DE PARC_EMISSAO PARA ODS - {operadora.ObterTexto()}");
            arquivo = arquivoParc;
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, 1);
            AlterarLinhaSeExistirCampo(arquivo, 0, "ID_TRANSACAO_CANC", "");
            AlterarLinhaSeExistirCampo(arquivo, 0, "CD_TIPO_EMISSAO", "1");
            if (!string.IsNullOrEmpty(cdTipoEmissao))
                AlterarLinhaSeExistirCampo(arquivo, 0, "CD_TIPO_EMISSAO", cdTipoEmissao);
            AlterarLinhaSeExistirCampo(arquivo, 0, "NR_ENDOSSO", "0");
            if (!string.IsNullOrEmpty(nrParcela))
                arquivo.AlterarLinhaSeExistirCampo(0, "NR_PARCELA", nrParcela);
            if (alterarLayout)
                arquivo.AlterarHeader("VERSAO", "9.6");

            AlterarLinhaSeExistirCampo(arquivo, 0, "NR_SEQUENCIAL_EMISSAO", "1");

            PrepararMassa(arquivo, out string tipoCorretor);

            SalvarArquivo(true);
            logger.Escrever("ARQUIVO CRIADO COM O NOME : " + arquivo.NomeArquivo);

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            arquivoParc = arquivo.Clone();

            logger.Escrever($"CRIANDO ARQUIDO DE COMISSAO PARA ODS - {operadora.ObterTexto()}");

            arquivo = arquivoComissao;
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, 1);
            IgualarCamposQueExistirem(arquivoParc, arquivo);
            AlterarLinhaSeExistirCampo(arquivo, 0, "CD_TIPO_COMISSAO", tipoCorretor);
            if (alterarLayout)
                arquivo.AlterarHeader("VERSAO", "9.6");
            SalvarArquivo(true);

            logger.Escrever("ARQUIVO CRIADO COM O NOME : " + arquivo.NomeArquivo);

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            arquivoComissao = arquivo.Clone();
        }

        public void PrepararMassa(Arquivo arquivo, out string tipoCorretor)
        {
            tipoCorretor = "";
            //arquivo.AlterarLinhaSeExistirCampo(0, "CD_CLIENTE", GerarNumeroAleatorio(8));

            SetDev();

            var cobertura = dados.ObterCoberturaSimples(arquivo.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado);
            for (int i = 0; i < arquivo.Linhas.Count; i++)
            {
                arquivo.AlterarLinhaSeExistirCampo(i, "CD_COBERTURA", cobertura.CdCobertura);
                arquivo.AlterarLinhaSeExistirCampo(i, "CD_RAMO", cobertura.CdRamo);
                arquivo.AlterarLinhaSeExistirCampo(i, "CD_PRODUTO", cobertura.CdProduto);
                arquivo.AlterarLinhaSeExistirCampo(i, "VL_LMI", arquivo.ObterValorFormatadoSeExistirCampo(0, "VL_IS"));
            }


            SetQA();


            var novoContrato = AlterarUltimasPosicoes(arquivo.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(8));
            for (int i = 0; i < arquivo.Linhas.Count; i++)
            {
                arquivo.AlterarLinhaSeExistirCampo(i, "CD_CONTRATO", novoContrato);
                arquivo.AlterarLinhaSeExistirCampo(i, "NR_PROPOSTA", novoContrato);
                arquivo.AlterarLinhaSeExistirCampo(i, "NR_APOLICE", novoContrato);


                if (operadora == OperadoraEnum.VIVO)
                {
                    arquivo.AlterarLinhaSeExistirCampo(i, "CD_CORRETOR", "7239711");
                    tipoCorretor = "C";
                    //triplice.AlterarTodasAsLinhasQueContenhamOCampo("CD_TIPO_COMISSAO", "C");
                }
                else if (operadora == OperadoraEnum.LASA || operadora == OperadoraEnum.SOFTBOX)
                {
                    arquivo.AlterarLinhaSeExistirCampo(i, "CD_CORRETOR", "7150145");
                    tipoCorretor = "P";
                }
                else if (operadora == OperadoraEnum.POMPEIA)
                {
                    arquivo.AlterarLinhaSeExistirCampo(i, "CD_CORRETOR", "7150166");
                    tipoCorretor = "P";
                }
                else
                    throw new Exception("OPERACAO SEM CORRETOR CADASTRADO.");

            }

        }

        private static void SetQA()
        {
            DBHelperHana.Instance.SetConnection("Server=zeus.hana.prod.sa-east-1.whitney.dbaas.ondemand.com:20274;UID=CCARVALHO;PWD=Cristiano@03;encrypt=TRUE;Connection Timeout=5000");
            Parametros.instanciaDB = "HDIQAS_1";
        }

        private static void SetDev()
        {
            Parametros.instanciaDB = "HDIDEV_1";
            DBHelperHana.Instance.SetConnection("Server=zeus.hana.prod.sa-east-1.whitney.dbaas.ondemand.com:20272;UID=CCARVALHO;PWD=Generali@10;encrypt=TRUE;");
        }
    }
}
