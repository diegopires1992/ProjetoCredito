# ProjetoCredito

. Em um determinado banco, você foi designado para desenhar o novo processamento de liberação 
de crédito.
Existem 5 tipos de créditos, cujos :
Credito Direto - Taxa de 2% ao mês
Credito Consignado - Taxa de 1% ao mês
Credito Pessoa Jurídica - Taxa de 5% ao mês
Credito Pessoa Física - Taxa de 3% ao mês
Credito Imobiliário - Taxa de 9% ao ano
Cada crédito tem uma forma de validação diferente, porém, todos precisam passar neste método de 
validação para liberação do crédito.
Implemente as classes que você julgue necessárias para implementação do processamento, e 
demonstre exemplos em uma aplicação simples de console.
Defina como entradas as seguintes variáveis:
- Valor do crédito
- Tipo de crédito
- Quantidade de parcelas
- Data do primeiro vencimento
As validações das entradas são as seguintes:
- O valor máximo a ser liberado para qualquer tipo de empréstimo é de R$ 1.000.000,00
- A quantidade de parcelas máximas é de 72x e a mínima é de 5x
- Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de R$ 15.000,00
- A data do primeiro vencimento sempre será no mínimo D+15 (Dia atual + 15 dias), e no máximo, 
D+40 (Dia atual + 40 dias)
Os resultados precisam conter as seguintes informações :
- Status do crédito (Aprovado ou recusado, de acordo com as premissas acima)
- Valor total com juros
- Valor do juros
Para este exercício, os juros são calculados da seguinte forma, incremente a porcentagem de juros 
no valor total do crédito. 
ORACLE ou SQL Server 
2. Modele uma estrutura de dados do seguinte caso:
- Um cliente tem os seguintes campos : Nome, Id Cliente, UF, Celular
- Um cliente tem N financiamentos.
- Um financiamento tem os seguintes campos : Id Cliente, Tipo Financiamento, Valor Total, Data 
Vencimento
- Cada financiamento tem N parcelas, cujas tem os seguintes campos : Id Financiamento, Número 
da Parcela, Valor Parcela, Data Vencimento, Data Pagamento;
Crie as tabelas que julgue necessárias e insira alguns registros de testes na mesma.
Elabore as seguintes querys:
- Listar todos os clientes do estado de SP que tenham mais de 60% das parcelas pagas.
- Listar os primeiros 4 clientes que tenham alguma parcela com mais de 05 dias atrasadas (Data 
Vencimento maior que data atual E data pagamento nula)
- Listar todos os clientes que já atrasaram em algum momento duas ou mais parcelas em mais de 10 
dias, e que o valor do financiamento seja maior que R$ 10.000,00.
