using Acelera.Data;
using Acelera.Domain.Enums;
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

namespace Acelera.Testes
{
    [TestClass]
    public class TestesFG09 : TestesFG05
    {
        [TestMethod]
        public void Teste1()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste1", "FG09");

            arquivo = EnviarEmissao<Arquivo_Layout_9_3_ParcEmissaoAuto>(OperadoraEnum.VIVO);
            EnviarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto>(arquivo.ObterLinha(0), OperadoraEnum.VIVO, "9");
            EnviarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto>(arquivo.ObterLinha(0), OperadoraEnum.VIVO, "9");
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

            arquivo = EnviarEmissao<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA);
            EnviarCancelamento<Arquivo_Layout_9_4_ParcEmissao>(arquivo.ObterLinha(0), OperadoraEnum.LASA, "10");
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

            arquivo = EnviarEmissao<Arquivo_Layout_9_3_ParcEmissaoAuto>(OperadoraEnum.VIVO,"1");
            arquivo.AlterarLinhaSeExistirCampo(0, "CD_MODELO", "023105-5");

            EnviarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto>(arquivo.ObterLinha(0).Clone(), OperadoraEnum.VIVO, "10");
            /*
Enviar arquivo PARCEMSAUTO para ODS com dados de emissão de um contrato - Parcela 1
Enviar arquivo PARCEMSAUTO com movimentação de cancelamento para este mesmo contrato (CD_TIPO_EMISSAO=10), referenciando a outro Cd_MODELO.. Preencher todos os campos relativos a cancelamento
             */
        }

        [TestMethod]
        public void Teste4()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste4-FG09", "FG09");

            arquivo = EnviarEmissao<Arquivo_Layout_9_4_ParcEmissaoAuto>(OperadoraEnum.VIVO,"",false);
            SetDev();
            AlterarLinha(0, "CD_RAMO", dados.ObterRamoDiferente(ObterValor(0, "CD_RAMO")));
            SetQA();
            EnviarCancelamento<Arquivo_Layout_9_4_ParcEmissaoAuto>(arquivo.ObterLinha(0).Clone(), OperadoraEnum.VIVO, "10",false);
            /*
Enviar arquivo PARCEMSAUTO para ODS com dados de emissão de um contrato com ramo parametrizado (tabela 7007)
Enviar arquivo PARCEMSAUTO com o cancelamento da emissão anterior, com um codigo de ramo diferente da emissão, mas parametrizado na 7007
             */
        }

        [TestMethod]
        public void Teste5()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste5-FG09", "FG09");

            arquivo = EnviarEmissao<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.POMPEIA, "", false);
            EnviarCancelamento<Arquivo_Layout_9_4_ParcEmissao>(arquivo.ObterLinha(0), OperadoraEnum.POMPEIA, "10", false);
            /*
Enviar arquivo PARCEMS para ODS com dados de emissão de um contrato com ramo parametrizado (tabela 7007)
Enviar arquivo PARCEMS com o cancelamento da emissão anterior, com um codigo de ramo igual da emissão
             */
        } 
        
        [TestMethod]
        public void Teste6()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste6-FG09", "FG09");

            arquivo = EnviarEmissao<Arquivo_Layout_9_3_ParcEmissaoAuto>(OperadoraEnum.VIVO, "", false);
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValor(0, "VL_PREMIO_LIQUIDO", 100M));
            EnviarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto>(arquivo.ObterLinha(0), OperadoraEnum.VIVO, "10", false);
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

            PrepararMassa(arquivo);

            SalvarArquivo(true);

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "1000");

            EnviarCancelamento<Arquivo_Layout_9_3_ParcEmissaoAuto>(arquivo.ObterLinha(0), OperadoraEnum.VIVO, "10", false, "4");
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

            arquivo = EnviarEmissao<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.SOFTBOX, "", false);
            AlterarLinha(0, "DT_INICIO_VIGENCIA", SomarData(0, "DT_INICIO_VIGENCIA", -2));
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(0, "DT_FIM_VIGENCIA", -2));
            AlterarLinha(0, "DT_EMISSAO", SomarData(0, "DT_INICIO_VIGENCIA", 0));
            EnviarCancelamento<Arquivo_Layout_9_4_ParcEmissao>(arquivo.ObterLinha(0).Clone(), OperadoraEnum.SOFTBOX, "10", false);
            /*
Enviar arquivo PARCEMS para ODS com dados de emissão de uma única parcela
Enviar arquivo de cancelamento para esta parcela, informando DT_INICIO_VIGENCIA inferior a DT_INICIO_VIGENCIA da parcela a ser cancelada
             */
        }

        public void EnviarCancelamento<T>(LinhaArquivo linhaArquivoEmissao, OperadoraEnum operadora, string cdTipoEmissao, bool alterarLayout = false, string nrSequencialEmissao = "") where T : Arquivo, new()
        {
            arquivo = new T();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, 1);
            var idTransacaoDoArquivoOriginal = arquivo.ObterLinha(0).ObterCampoSeExistir("ID_TRANSACAO").ValorFormatado;
            arquivo.RemoverTodasLinhasDoBody();
            arquivo.AdicionaLinhaNoBody(linhaArquivoEmissao.Clone());

            arquivo.AlterarLinhaSeExistirCampo(0, "ID_TRANSACAO_CANC", linhaArquivoEmissao.ObterCampoDoArquivo("ID_TRANSACAO").ValorFormatado);
            arquivo.AlterarLinhaSeExistirCampo(0, "ID_TRANSACAO", idTransacaoDoArquivoOriginal);
            arquivo.AlterarLinhaSeExistirCampo(0, "CD_TIPO_EMISSAO", cdTipoEmissao);
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_PARCELA", SomarValor(0, "NR_PARCELA", 1M));
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_ENDOSSO", "4");
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO", "2");
            if (!string.IsNullOrEmpty(nrSequencialEmissao))
                arquivo.AlterarLinhaSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO", nrSequencialEmissao);

            arquivo.AlterarLinhaSeExistirCampo(0, "CD_MOVTO_COBRANCA", "02");

            if (alterarLayout)
                arquivo.AlterarHeader("VERSAO", "9.6");

            SalvarArquivo(true);

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
        }

        public Arquivo EnviarEmissao<T>(OperadoraEnum operadora, string nrParcela = "", bool alterarLayout = false, int numeroParcelas = 0, string cdTipoEmissao = "") where T : Arquivo, new() 
        {
            arquivo = new T();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, 1);
            arquivo.AlterarLinhaSeExistirCampo(0, "ID_TRANSACAO_CANC", "");
            arquivo.AlterarLinhaSeExistirCampo(0, "CD_TIPO_EMISSAO", "1");
            if (!string.IsNullOrEmpty(cdTipoEmissao))
                arquivo.AlterarLinhaSeExistirCampo(0, "CD_TIPO_EMISSAO", cdTipoEmissao);
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_ENDOSSO", "0");
            if(!string.IsNullOrEmpty(nrParcela))
                arquivo.AlterarLinhaSeExistirCampo(0, "NR_PARCELA", nrParcela);

            arquivo.AlterarLinhaSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO", "1");

            PrepararMassa(arquivo);

            if (alterarLayout)
                arquivo.AlterarHeader("VERSAO", "9.6");

            SalvarArquivo(true);

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            return arquivo.Clone();
        }

        public void PrepararMassa(Arquivo arquivo)
        {
            arquivo.AlterarLinhaSeExistirCampo(0, "CD_CLIENTE", GerarNumeroAleatorio(8));

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
