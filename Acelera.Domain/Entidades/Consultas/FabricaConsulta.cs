﻿using Acelera.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.Consultas
{
    public static class FabricaConsulta
    {
       public static Consulta  MontarConsultaParaStage(TabelasEnum tabela, AlteracoesArquivo valoresAlteradosBody, Consulta consulta)
        {
            if (tabela == TabelasEnum.Cliente)
            {
                consulta.AdicionarConsulta("CD_CLIENTE", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CLIENTE").Valor);
            }
            else if (tabela == TabelasEnum.ParcEmissao || tabela == TabelasEnum.ParcEmissaoAuto)
            {
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CONTRATO").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("NR_PARCELA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_PARCELA").Valor);
                consulta.AdicionarConsulta("CD_COBERTURA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_COBERTURA").Valor);
            }
            else if (tabela == TabelasEnum.Comissao)
            {
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CONTRATO").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("NR_PARCELA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_PARCELA").Valor);
                consulta.AdicionarConsulta("CD_COBERTURA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_COBERTURA").Valor);
                consulta.AdicionarConsulta("CD_TIPO_COMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_TIPO_COMISSAO").Valor);
            }
            else if (tabela == TabelasEnum.OCRCobranca)
            {
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CONTRATO").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("NR_PARCELA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_PARCELA").Valor);
            }
            else if (tabela == TabelasEnum.LanctoComissao)
            {
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CONTRATO").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("NR_PARCELA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_PARCELA").Valor);
                consulta.AdicionarConsulta("CD_TIPO_COMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_TIPO_COMISSAO").Valor);
            }
            else if (tabela == TabelasEnum.Sinistro)
            {
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CONTRATO").Valor);
                //consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("VL_MOVIMENTO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("VL_MOVIMENTO").Valor);
                consulta.AdicionarConsulta("NM_BENEFICIARIO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NM_BENEFICIARIO").Valor);
                consulta.AdicionarConsulta("CD_COBERTURA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_COBERTURA").Valor);
                consulta.AdicionarConsulta("CD_SINISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_SINISTRO").Valor);

            }
            return consulta;
        }

        public static Consulta MontarConsultaParaTabelaDeRetorno(TabelasEnum tabela, AlteracoesArquivo valoresAlteradosBody)
        {
            if (valoresAlteradosBody.Alteracoes.Count == 0)
                throw new Exception("NENHUMA LINHA ALTERADA OU SELECIONADA.");

            var consulta = new Consulta();

            if (tabela == TabelasEnum.Cliente)
            {
                consulta.AdicionarConsulta("CD_CLIENTE", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CLIENTE").Valor);
                consulta.AdicionarConsulta("TIPO_REGISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("TIPO_REGISTRO").Valor);
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CONTRATO").Valor);
            }
            else if (tabela == TabelasEnum.Sinistro)
            {
                consulta.AdicionarConsulta("TIPO_REGISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("TIPO_REGISTRO").Valor);
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CONTRATO").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("CD_SINISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_SINISTRO").Valor);
            }
            else
            {
                consulta.AdicionarConsulta("TIPO_REGISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("TIPO_REGISTRO").Valor);
                consulta.AdicionarConsulta("CD_CONTRATO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("CD_CONTRATO").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("NR_PARCELA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampo("NR_PARCELA").Valor);
            }
            return consulta;
        }
    }
}
