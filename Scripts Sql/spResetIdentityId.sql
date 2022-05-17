--sp para ajustar o valor do Id em caso de alguma exclusão e posterior inclusão de dados em uma tabela

CREATE OR ALTER PROCEDURE [spResetIdentityId] 
    @tblName VARCHAR(100) , @Id INT 
    AS 
        DBCC CHECKIDENT (@tblName, RESEED, @Id)
GO