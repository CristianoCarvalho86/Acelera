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
        public DeleteStages(IMyLogger logger)
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
                    int count1 = DataAccess.ObterTotalLinhas(tab.ObterTexto(), _logger);
                    DataAccess.ExecutarComando($"DELETE FROM {Parametros.instanciaDB}.{tab.ObterTexto()} where CD_STATUS_PROCESSAMENTO = '{(int)codigoABuscar}'", DBEnum.Hana, _logger);
                    _logger.Escrever($"REGISTROS COM CODIGO {(int)codigoABuscar} APAGADOS COM SUCESSO.");
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
