Feature: Teste da PROC_199 LASA
Definição da PROC Tipo Comissao do Cancelamento deve ser igual ao da emissão;

Scenario:  SAP-6106:FG09 - PROC 199-c/C - Layout 9.4 LASA - COMISS - CD_TIPO_COMISSAO diferente - C e R
	Given uma trinca 'LASA' de emissao
	And com 'TIPO_COMISSAO' = 'C' 
	And trinca enviada para ODS

	Given uma trinca 'LASA' de cancelamento
	And com 'TIPO_COMISSAO' = 'R' 

	When trinca executada até a 'FGR_09'
	Then espera-se status = '920' na Stage
	Then espera-se erro '199' na Tabela de Retorno