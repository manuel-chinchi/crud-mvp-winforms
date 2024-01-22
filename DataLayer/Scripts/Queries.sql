-- ######################################################################################
-- CREATE DATABASE AND TABLES
-- ######################################################################################


CREATE DATABASE crud_mvp_winforms
GO

USE crud_mvp_winforms

CREATE TABLE Articles (
    Id INT identity(1, 1) PRIMARY KEY,
    Name NVARCHAR(100),
    Description NVARCHAR(100),
    Brand NVARCHAR(100),
    Stock INT
    )

-- ######################################################################################
-- LOAD DATASETS IN DB
-- ######################################################################################


INSERT INTO Articles
VALUES 
	('Camisa', 'algodon 100%', 100), 
	('Zapatilla', 'cuero', 200), 
	('Zapatilla', 'cuero sintético', 250), 
	('Camisa', 'algodon 75%',  150), 
	('Pantalon', 'deportivo', 200),
	('Jean', 'cuero chupin', 220),
	('Buso', 'tipo canguro, c/capucha', 120),
	('Gorra', 'blanca', 500),
	('Medias', 'tipo soquetes, p/hombre', 500),
	('Medias', 'tipo soquetes p/mujer', 400)
GO


-- ######################################################################################
-- CREATE STORE PROCEDURES
-- ######################################################################################


CREATE PROCEDURE InsertArticle 
    @Name NVARCHAR(100),
    @Description NVARCHAR(100),
    @Stock INT
AS
INSERT INTO Articles
VALUES (
    @Name,
    @Description,
    @Stock
    )
GO


CREATE PROCEDURE GetArticle @Id INT
AS
SELECT *
FROM Articles
WHERE Id = @Id
GO


CREATE PROCEDURE GetArticles
AS
SELECT *
FROM Articles
GO


CREATE PROCEDURE DeleteArticle @Id INT
AS
DELETE
FROM Articles
WHERE Id = @Id
GO


CREATE PROCEDURE UpdateArticle 
    @Name NVARCHAR(100),
    @Description NVARCHAR(100),
    @Stock INT,
    @Id INT
AS
UPDATE Articles
SET Name = @Name,
    Description = @Description,
    Stock = @Stock
WHERE Id = @Id
GO


CREATE PROCEDURE SearchArticle
    @IncludeName BIT,
    @IncludeDesc BIT,
    @Search VARCHAR(100)
AS
SELECT
    *
FROM
    Articles a
WHERE
    (
        (@IncludeName = 1 AND a.Name LIKE '%' + @Search + '%')
        OR
        (@IncludeDesc = 1 AND a.Description LIKE '%' + @Search + '%')
    )
    AND
    @Search <> ''
GO
