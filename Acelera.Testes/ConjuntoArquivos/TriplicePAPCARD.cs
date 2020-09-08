using Acelera.Domain.Entidades;
using Acelera.Domain.Enums;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Acelera.Logger;
using Acelera.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.ConjuntoArquivos
{
    [Serializable]
    public class TriplicePAPCARD : Triplice<Arquivo_Layout_9_6_Cliente, Arquivo_Layout_9_6_ParcEmissao, Arquivo_Layout_9_6_EmsComissao>
    {
        public TriplicePAPCARD(int quantidadeCliente, IMyLogger logger, ref List<string> arquivosSalvos) : base(quantidadeCliente, logger, ref arquivosSalvos)
        {

        }

        public override OperadoraEnum Operadora => OperadoraEnum.PAPCARD;

        public override bool EhParcAuto => false;

        public override void FinalizarAlteracao(Arquivo arquivo)
        {
            AlteracoesPapCardEmissao(arquivo);
            base.FinalizarAlteracao(arquivo);
        }

        private void AlteracoesPapCardEmissao(Arquivo _arquivo)
        {
            for (int i = 0; i < _arquivo.Linhas.Count; i++)
            {
                _arquivo.AlterarLinha(i, "NR_SEQUENCIAL_EMISSAO_EST", _arquivo[i]["NR_SEQUENCIAL_EMISSAO"]);
                _arquivo.AlterarLinha(i, "NR_SEQUENCIAL_EMISSAO", "");
            }
        }

        protected void AlteracoesIniciaisPapcard(Arquivo _arquivo)
        {
            for (int i = 0; i < _arquivo.Linhas.Count; i++)
            {
                _arquivo.AlterarLinha(i, "NR_ENDOSSO", ParametrosRegrasEmissao.CarregaProximoNumeroEndosso(_arquivo.Linhas[i]));
                _arquivo.AlterarLinha(i, "NR_PROPOSTA", ParametrosRegrasEmissao.GerarNrApolicePapCard());
                _arquivo.AlterarLinha(i, "NR_SEQUENCIAL_EMISSAO", ParametrosRegrasEmissao.CarregaProximoNumeroSequencialEmissao(_arquivo.Linhas[i], OperadoraEnum.PAPCARD));
                _arquivo.AlterarLinha(i, "CD_CONTRATO", "759303900006209");
                _arquivo.AlterarLinha(i, "NR_APOLICE", "759303900006209");
                _arquivo.AlterarLinha(i, "CD_CLIENTE", RandomNumber.GerarNumeroAleatorio(8));
            }
        }
    }
}
