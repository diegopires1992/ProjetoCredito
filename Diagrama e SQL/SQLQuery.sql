USE master

CREATE TABLE CLIENTE
(
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(50) NOT NULL,
    UF VARCHAR(2) NOT NULL,
    Celular NVARCHAR(18)
)

INSERT INTO CLIENTE
VALUES('Diego Pires', 'SP', '41999028210')
INSERT INTO CLIENTE
VALUES('Edimara Pires', 'SP', '41999028210')
INSERT INTO CLIENTE
VALUES('Jose Pires', 'SP', '41999028210')
INSERT INTO CLIENTE
VALUES('Roberto Pires', 'SP', '41999028210')
INSERT INTO CLIENTE
VALUES('Flavia Pires', 'SP', '41999028210')
INSERT INTO CLIENTE
VALUES('Bruno Pires', 'SP', '41999028210')
SELECT * FROM CLIENTE

CREATE TABLE TIPOFINANCIAMENTO
(
    Id INT IDENTITY PRIMARY KEY,
    Nome NVARCHAR(50)NOT NULL,
    Taxa DECIMAL(6,4),
)

INSERT INTO TIPOFINANCIAMENTO
VALUES('Credito Consignado',2)

SELECT * FROM TIPOFINANCIAMENTO

CREATE TABLE FINANCIAMENTO
(
    Id INT IDENTITY PRIMARY KEY,
    DataVencimento DATE,
    ValorTotal DECIMAL(10,4),
    TipoFinanciamento INT NOT NULL,
    ClienteId INT NOT NULL

    CONSTRAINT FK_ID_FINANCIAMENTO FOREIGN KEY(ClienteId) 
    REFERENCES CLIENTE(Id),
	CONSTRAINT FK_ID_TIPOFINANCIAMENTO FOREIGN KEY(TipoFinanciamento) 
    REFERENCES TIPOFINANCIAMENTO(Id)
)

INSERT INTO FINANCIAMENTO
VALUES('2022-01-31',10000,1, 1)
INSERT INTO FINANCIAMENTO
VALUES('2022-01-31',10000,1, 2)
INSERT INTO FINANCIAMENTO
VALUES('2022-01-31',10000,1, 3)
INSERT INTO FINANCIAMENTO
VALUES('2022-11-12',9000,1, 4)
INSERT INTO FINANCIAMENTO
VALUES('2022-11-12',10000,1, 5)
INSERT INTO FINANCIAMENTO
VALUES('2022-11-12',10000,1, 6)

SELECT * FROM FINANCIAMENTO


CREATE TABLE PARCELA
(
    Id INT IDENTITY PRIMARY KEY,
	NumeroParcela INT NOT NULL,
    ValorParcela DECIMAL(10,4) NOT NULL,
    DataVencimento DATE NOT NULL,
    DataPagamento DATE,
    FinanciamentoId INT NOT NULL

    CONSTRAINT FK_ID_PARCELA FOREIGN KEY(FinanciamentoId) 
    REFERENCES FINANCIAMENTO(Id)
)

INSERT INTO PARCELA
VALUES(1,1000,'2021-01-28','2021-01-28', 1)
INSERT INTO PARCELA
VALUES(2,1000,'2021-02-28','2021-01-28', 1)
INSERT INTO PARCELA
VALUES(3,1000,'2021-03-28','2022-02-28', 1)
INSERT INTO PARCELA
VALUES(4,1000,'2021-04-28','2022-02-28', 1)
INSERT INTO PARCELA
VALUES(5,1000,'2021-05-28','2022-02-28', 1)
INSERT INTO PARCELA
VALUES(6,1000,'2021-06-28','2022-02-28', 1)
INSERT INTO PARCELA
VALUES(7,1000,'2022-07-28',NULL, 1)
INSERT INTO PARCELA
VALUES(8,1000,'2022-08-28',NULL, 1)
INSERT INTO PARCELA
VALUES(9,1000,'2022-09-28',NULL, 1)
INSERT INTO PARCELA
VALUES(10,1000,'2022-10-28',NULL, 1)

INSERT INTO PARCELA
VALUES(1,1000,'2021-01-28',NULL, 2)
INSERT INTO PARCELA
VALUES(2,1000,'2022-02-28',NULL, 2)
INSERT INTO PARCELA
VALUES(3,1000,'2022-02-28',NULL, 2)
INSERT INTO PARCELA
VALUES(4,1000,'2022-02-28',NULL, 2)
INSERT INTO PARCELA
VALUES(5,1000,'2022-02-28',NULL, 2)
INSERT INTO PARCELA
VALUES(6,1000,'2022-02-28',NULL, 2)
INSERT INTO PARCELA
VALUES(7,1000,'2022-02-28','2022-02-28', 2)
INSERT INTO PARCELA
VALUES(8,1000,'2022-02-28','2022-02-28', 2)
INSERT INTO PARCELA
VALUES(9,1000,'2022-02-28','2022-02-28', 2)
INSERT INTO PARCELA
VALUES(10,1000,'2022-02-28','2022-02-28', 2)

INSERT INTO PARCELA
VALUES(1,1000,'2021-01-28','2021-01-28', 3)
INSERT INTO PARCELA
VALUES(2,1000,'2022-02-28','2021-01-28', 3)
INSERT INTO PARCELA
VALUES(3,1000,'2022-02-28','2022-02-28', 3)
INSERT INTO PARCELA
VALUES(4,1000,'2022-02-28','2022-02-28', 3)
INSERT INTO PARCELA
VALUES(5,1000,'2022-02-28','2022-02-28', 3)
INSERT INTO PARCELA
VALUES(6,1000,'2022-02-28','2022-02-28', 3)
INSERT INTO PARCELA
VALUES(7,1000,'2022-02-28','2022-02-28', 3)
INSERT INTO PARCELA
VALUES(8,1000,'2022-02-28','2022-02-28', 3)
INSERT INTO PARCELA
VALUES(9,1000,'2022-02-28','2022-02-28', 3)
INSERT INTO PARCELA
VALUES(10,1000,'2022-02-28','2022-02-28', 3)

INSERT INTO PARCELA
VALUES(1,1000,'2021-01-28',NULL,7)
INSERT INTO PARCELA
VALUES(2,1000,'2022-02-28',NULL,7)
INSERT INTO PARCELA
VALUES(3,1000,'2022-02-28',NULL,7)
INSERT INTO PARCELA
VALUES(4,1000,'2022-02-28',NULL,7)
INSERT INTO PARCELA
VALUES(5,1000,'2022-02-28',NULL,7)
INSERT INTO PARCELA
VALUES(6,1000,'2022-02-28',NULL,7)
INSERT INTO PARCELA
VALUES(7,1000,'2022-02-28',NULL,7)
INSERT INTO PARCELA
VALUES(8,1000,'2022-02-28',NULL,7)
INSERT INTO PARCELA
VALUES(9,1000,'2022-02-28',NULL,7)
INSERT INTO PARCELA
VALUES(10,1000,'2022-02-28',NULL,7)

SELECT * FROM PARCELA

SELECT C.*
FROM CLIENTE C
	INNER JOIN FINANCIAMENTO F ON C.Id = F.ClienteId
	INNER JOIN PARCELA P ON F.Id = P.FinanciamentoId
	WHERE C.UF = 'SP'
	GROUP BY C.Id,C.Celular,C.Nome,C.UF
	HAVING cast ((count(DataPagamento)*100) / count(NumeroParcela) as decimal(10,2)) >= 60


SELECT top 4 C.*
FROM CLIENTE C
INNER JOIN FINANCIAMENTO F
ON C.Id = F.ClienteId
INNER JOIN PARCELA P
ON P.FinanciamentoId = F.Id
WHERE DataPagamento IS NULL
GROUP BY C.Id, C.Nome, C.UF, C.Celular, P.DataVencimento
HAVING DATEDIFF(DAY,P.DataVencimento, GETDATE()) > 5



SELECT TOP 4 C.Id,C.Celular,C.Nome,C.UF
FROM CLIENTE C
    INNER JOIN FINANCIAMENTO F ON C.Id = F.ClienteId
        AND C.UF = 'SP'
		WHERE C.Id IN (SELECT ClienteId FROM FINANCIAMENTO as f
		WHERE Id IN (SELECT FinanciamentoId FROM PARCELA 
			WHERE DataPagamento > DATEADD(DAY, 5, DataVencimento) OR DataPagamento is NULL))


SELECT a.* FROM CLIENTE a
	inner join FINANCIAMENTO b
	ON a.Id = b.ClienteId
	inner join (SELECT FinanciamentoId FROM PARCELA P
	WHERE p.DataPagamento is null
	GROUP BY p.FinanciamentoId
	HAVING COUNT(p.NumeroParcela) >=2 )y
	ON y.FinanciamentoId = b.Id
	inner join (select a.FinanciamentoId, a.NumeroParcela from PARCELA a
	WHERE a.DataPagamento is null
	GROUP BY a.FinanciamentoId, a.DataVencimento, a.NumeroParcela
	HAVING DATEDIFF(DAY, a.DataVencimento, GETDATE()) > 10 )x
	ON x.FinanciamentoId = y.FinanciamentoId
	WHERE b.ValorTotal >= 10000
	GROUP BY A.Id, A.NOME, A.UF, A.CELULAR
	HAVING count(x.NumeroParcela) >=2

SELECT * FROM PARCELA