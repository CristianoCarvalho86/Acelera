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

        public void Teste2()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "Teste1", "FG09");

            arquivo = EnviarEmissao<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA);
            EnviarCancelamento<Arquivo_Layout_9_4_ParcEmissao>(arquivo.ObterLinha(0), OperadoraEnum.LASA, "11");
            EnviarCancelamento<Arquivo_Layout_9_4_ParcEmissao>(arquivo.ObterLinha(0), OperadoraEnum.LASA, "11");
            /*
Enviar arquivo PARCEMS para ODS com dados de emissão de um contrato
Enviar arquivo PARCEMS com movimentação de cancelamento para este mesmo contrato (CD_TIPO_EMISSAO=11). Preencher todos os campos relativos ao cancelamento
Enviar arquivo PARCEMS com outra movimentação de cancelamento para este mesmo contrato (CD_TIPO_EMISSAO=10). Preencher todos os campos relativos ao cancelamento
             */
        }

        public void EnviarCancelamento<T>(LinhaArquivo linhaArquivoEmissao, OperadoraEnum operadora, string cdTipoEmissao) where T : Arquivo, new()
        {
            arquivo = new T();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, 1);
            var idTransacaoDoArquivoOriginal = arquivo.ObterLinha(0).ObterCampoSeExistir("ID_TRANSACAO").ValorFormatado;
            arquivo.RemoverTodasLinhasDoBody();
            arquivo.AdicionaLinhaNoBody(linhaArquivoEmissao);

            arquivo.AlterarLinhaSeExistirCampo(0, "ID_TRANSACAO_CANC", linhaArquivoEmissao.ObterCampoDoArquivo("ID_TRANSACAO").ValorFormatado);
            arquivo.AlterarLinhaSeExistirCampo(0, "ID_TRANSACAO", idTransacaoDoArquivoOriginal);
            arquivo.AlterarLinhaSeExistirCampo(0, "CD_TIPO_EMISSAO", cdTipoEmissao);
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_ENDOSSO", "1");
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_SEQUENCIAL_EMISSAO", "2");
            arquivo.AlterarLinhaSeExistirCampo(0, "CD_MOVTO_COBRANCA", "02");

            SalvarArquivo(true);

            ExecutarEValidar(arquivo, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(arquivo, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(arquivo, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
        }

        public Arquivo EnviarEmissao<T>(OperadoraEnum operadora, bool alterarLayout = false) where T : Arquivo, new() 
        {
            arquivo = new T();
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, 1);
            arquivo.AlterarLinhaSeExistirCampo(0, "ID_TRANSACAO_CANC", "");
            arquivo.AlterarLinhaSeExistirCampo(0, "CD_TIPO_EMISSAO", "1");
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_ENDOSSO", "0");
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

            Parametros.instanciaDB = "HDIDEV_1";
            DBHelperHana.Instance.SetConnection("Server=zeus.hana.prod.sa-east-1.whitney.dbaas.ondemand.com:20272;UID=CCARVALHO;PWD=Generali@10;encrypt=TRUE;");

            var cobertura = dados.ObterCoberturaSimples(arquivo.ObterLinhaHeader().ObterCampoDoArquivo("CD_TPA").ValorFormatado);
            arquivo.AlterarLinhaSeExistirCampo(0, "CD_COBERTURA", cobertura.CdCobertura);
            arquivo.AlterarLinhaSeExistirCampo(0, "CD_RAMO", cobertura.CdRamo);
            arquivo.AlterarLinhaSeExistirCampo(0, "CD_PRODUTO", cobertura.CdProduto);
            arquivo.AlterarLinhaSeExistirCampo(0, "VL_LMI", arquivo.ObterValorFormatadoSeExistirCampo(0, "VL_IS"));

            DBHelperHana.Instance.SetConnection("Server=zeus.hana.prod.sa-east-1.whitney.dbaas.ondemand.com:20274;UID=CCARVALHO;PWD=Cristiano@03;encrypt=TRUE;Connection Timeout=5000");
            Parametros.instanciaDB = "HDIQAS_1";


            var novoContrato = AlterarUltimasPosicoes(arquivo.ObterValorFormatadoSeExistirCampo(0, "CD_CONTRATO"), GerarNumeroAleatorio(8));
            arquivo.AlterarLinhaSeExistirCampo(0, "CD_CONTRATO", novoContrato);
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_PROPOSTA", novoContrato);
            arquivo.AlterarLinhaSeExistirCampo(0, "NR_APOLICE", novoContrato);

        }
    }
}
