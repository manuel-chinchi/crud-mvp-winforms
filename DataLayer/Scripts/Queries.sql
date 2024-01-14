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
	('Camisa', 'algodon 100%', 'Adidas', 100), 
	('Zapatilla', 'cuero', 'Nike', 200), 
	('Zapatilla', 'cuero sintetico', 'China', 250), 
	('Camisa', 'algodon 75%', 'Lacoste', 150), 
	('Buso', 'tipo kanguro, c/capucha', 'Topper', 220)
GO


-- ######################################################################################
-- CREATE STORE PROCEDURES
-- ######################################################################################


CREATE PROCEDURE InsertArticle 
    @Name NVARCHAR(100),
    @Description NVARCHAR(100),
    @Brand NVARCHAR(100),
    @Stock INT
AS
INSERT INTO Articles
VALUES (
    @Name,
    @Description,
    @Brand,
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
    @Brand NVARCHAR(100),
    @Stock INT,
    @Id INT
AS
UPDATE Articles
SET Name = @Name,
    Description = @Description,
    Brand = @Brand,
    Stock = @Stock
WHERE Id = @Id
GO