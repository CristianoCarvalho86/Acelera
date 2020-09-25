Feature: FG02 - LASA

Scenario: SAP-2702:FG01 - Proc 20 - C/C - Layout 9.4 LASA - PARC_EMISSAO - Informar CD_CONTRATO dif. NR_APOLICE
	Given um arquivo 'LASA' de 'ParcEmissao', com '1' linhas
	And na linha '1' o 'CD_CONTRATO' = '5555'
	And na linha '1' o 'NR_APOLICE' = '55155'
	When executado até a 'FGR_02'
	Then espera-se status = '220' na Stage
	Then espera-se erro '20' na Tabela de Retorno

