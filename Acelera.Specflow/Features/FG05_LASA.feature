Feature: FG05_TIM

Scenario: SAP-9225:FG05 - PROC 219 - C/C - PARCELA - Mais de um cliente para mesmo NR_APOLICE
	Given um arquivo 'TIM' de 'ParcEmissao'
	And contendo '2' parcelas
	And na linha '1' o 'CD_CLIENTE' = '9999'
	And na linha '1' o 'CD_ITEM' = '1'
    When dados no arquivo
    | CD_CLIENTE | CD_ITEM  |
    |   9999     |     1    |
    |   9999     |     2    |
	When executado até a 'FGR_05'
	Then espera-se status = '520' na Stage
	Then espera-se erro '219' na Tabela de Retorno

