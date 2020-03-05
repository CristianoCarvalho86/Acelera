using Acelera.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.Consultas
{
    public static class FabricaConsulta
    {
       public static Consulta  MontarConsultaParaStage(TabelasEnum tabela, string nomeArquivo, AlteracoesArquivo valoresAlteradosBody)
        {
            var consulta = new Consulta();
            consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);
            if (valoresAlteradosBody == null || valoresAlteradosBody.Alteracoes.Count == 0 || valoresAlteradosBody.Alteracoes.First().SemHeaderOuFooter)
            {
                return consulta;
            }

            if (tabela == TabelasEnum.Cliente)
            {
                consulta.AdicionarConsulta("CD_CLIENTE", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("CD_CLIENTE").Valor);
            }
            else if (tabela == TabelasEnum.ParcEmissao || tabela == TabelasEnum.ParcEmissaoAuto)
            {
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("CD_CONTRATO").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("NR_PARCELA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_PARCELA").Valor);
                consulta.AdicionarConsulta("CD_COBERTURA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("CD_COBERTURA").Valor);
            }
            else if (tabela == TabelasEnum.Comissao)
            {
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("CD_CONTRATO").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("NR_PARCELA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_PARCELA").Valor);
                consulta.AdicionarConsulta("CD_COBERTURA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("CD_COBERTURA").Valor);
                consulta.AdicionarConsulta("CD_TIPO_COMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("CD_TIPO_COMISSAO").Valor);
            }
            else if (tabela == TabelasEnum.OCRCobranca)
            {
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("CD_CONTRATO").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("NR_PARCELA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_PARCELA").Valor);
            }
            else if (tabela == TabelasEnum.LanctoComissao)
            {
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("CD_CONTRATO").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("NR_PARCELA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_PARCELA").Valor);
                consulta.AdicionarConsulta("CD_TIPO_COMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("CD_TIPO_COMISSAO").Valor);
            }
            else if (tabela == TabelasEnum.Sinistro)
            {
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("CD_CONTRATO").Valor);
                //consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("VL_MOVIMENTO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("VL_MOVIMENTO").Valor);
                consulta.AdicionarConsulta("NM_BENEFICIARIO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NM_BENEFICIARIO").Valor);
                consulta.AdicionarConsulta("CD_COBERTURA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("CD_COBERTURA").Valor);
                consulta.AdicionarConsulta("CD_SINISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("CD_SINISTRO").Valor);

            }
            return consulta;
        }

        public static Consulta MontarConsultaParaTabelaDeRetorno(TabelasEnum tabela, string nomeArquivo, AlteracoesArquivo valoresAlteradosBody)
        {
            var consulta = new Consulta();
            consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);
            if (valoresAlteradosBody.Alteracoes.First().SemHeaderOuFooter)
            {
                return consulta;
            }

            if (tabela == TabelasEnum.Cliente)
            {
                consulta.AdicionarConsulta("CD_CLIENTE", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("CD_CLIENTE").Valor);
                consulta.AdicionarConsulta("TP_REGISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("TIPO_REGISTRO").Valor);
            }
            else if (tabela == TabelasEnum.Sinistro)
            {
                consulta.AdicionarConsulta("TP_REGISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("TIPO_REGISTRO").Valor);
                consulta.AdicionarConsulta("NR_APOLICE", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_APOLICE").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("CD_SINISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("CD_SINISTRO").Valor);
            }
            else
            {
                consulta.AdicionarConsulta("TP_REGISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("TIPO_REGISTRO").Valor);
                consulta.AdicionarConsulta("NR_APOLICE", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_APOLICE").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("NR_PARCELA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_PARCELA").Valor);
            }
            return consulta;
        }
    }
}
