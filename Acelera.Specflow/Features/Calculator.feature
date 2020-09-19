Feature: Teste da PROCX

@mytag
Scenario: Validar ID_TRANSACAO
	Given arquivo 'TIM' de 'Emissao' com 3 linhas
	And ID_TRANSACAO da linha 1 = '99999'
	When executado ate FG02
	Then Esperado erro 'PROCX' na Tabela de Retorno
	Then Esperado erro '120' na Tabela Stage