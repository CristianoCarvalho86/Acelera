using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.DataAccessRep
{
    public class DeleteStages
    {
        private IMyLogger _logger;
        public DeleteStages(ref IMyLogger logger)
        {
            _logger = logger;
        }
        public bool DeletarRegistros(TabelasEnum[] tabelasParaDeletar, CodigoStage codigoABuscar)
        {
            foreach(var tab in tabelasParaDeletar)
            {
                _logger.Escrever($"INICIANDO DELECAO DOS REGISTROS DA STAGE '{tab.ObterTexto()}' COM CD_STATUS_PROCESSAMENTO = {(int)codigoABuscar}");
                try
                {
                    int count1 = int.Parse(DataAccess.ObterTotalLinhas(tab.ObterTexto(), _logger, $"CD_STATUS_PROCESSAMENTO = '{(int)codigoABuscar}'"));
                    DataAccess.ExecutarComando($"DELETE FROM {Parametros.instanciaDB}.{tab.ObterTexto()} where CD_STATUS_PROCESSAMENTO = '{(int)codigoABuscar}'", DBEnum.Hana, _logger);
                    int count2 = int.Parse(DataAccess.ObterTotalLinhas(tab.ObterTexto(), _logger, $"CD_STATUS_PROCESSAMENTO = '{(int)codigoABuscar}'"));
                    if(count1 != 0 && count1 == count2)
                    {
                        throw new Exception("NENHUMA LINHA DELETADA");
                    }    

                    _logger.Escrever($"{count1 - count2} REGISTROS COM CODIGO {(int)codigoABuscar} APAGADOS COM SUCESSO.");
                }
                catch (Exception ex)
                {
                    _logger.Erro(ex);
                    return false;
                }
            }
            return true;

        }

        public bool DeletarRegistrosTrinca(CodigoStage codigoADeletar, bool EhParcAuto = false)
        {
            if (EhParcAuto)
                return DeletarRegistros(new TabelasEnum[] { TabelasEnum.Cliente, TabelasEnum.ParcEmissaoAuto, TabelasEnum.Comissao }, codigoADeletar);
            else
                return DeletarRegistros(new TabelasEnum[] { TabelasEnum.Cliente, TabelasEnum.ParcEmissao, TabelasEnum.Comissao }, codigoADeletar);
        }

    }
}
