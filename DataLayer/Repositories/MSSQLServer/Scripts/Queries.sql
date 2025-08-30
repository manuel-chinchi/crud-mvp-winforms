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

CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    DateCreated DATETIME
)
INSERT INTO Categories
VALUES
    ('Otro', sysdatetime()),
    ('Pantalones', sysdatetime()),
    ('Camisas', sysdatetime())
GO

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

INSERT INTO Categories
VALUES
    ('Otro'),
    ('Pantalones'),
    ('Camisas'),
    ('Medias')
GO

-- ######################################################################################
-- CREATE STORE PROCEDURES
-- ######################################################################################


CREATE PROCEDURE InsertArticle 
    @Name NVARCHAR(100),
    @Description NVARCHAR(100),
    @Stock INT,
    @CategoryId INT
AS
INSERT INTO Articles
VALUES (
    @Name,
    @Description,
    @Stock,
    @CategoryId,
    SYSDATETIME(),
    NULL
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
SELECT a.*, c.Name as CategoryName
FROM Articles a, Categories c
WHERE a.CategoryId = c.Id
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
    @Id INT,
    @CategoryId INT
AS
UPDATE Articles
SET Name = @Name,
    Description = @Description,
    Stock = @Stock,
    CategoryId = @CategoryId,
    DateUpdated = SYSDATETIME()
WHERE Id = @Id
GO


CREATE PROCEDURE SearchArticle
    @IncludeName BIT,
    @IncludeDesc BIT,
    @Search VARCHAR(100)
AS
SELECT
    a.*, c.Name CategoryName
FROM
    Articles a, Categories c
WHERE
    (
        (@IncludeName = 1 AND a.Name LIKE '%' + @Search + '%')
        OR
        (@IncludeDesc = 1 AND a.Description LIKE '%' + @Search + '%')
    )
    AND
    @Search <> ''
    AND
    a.CategoryId = c.Id
GO


-- ######################################################################################
-- CREATE STORE PROCEDURES
-- ######################################################################################

CREATE PROCEDURE InsertCategory
    @Name VARCHAR(100)
AS
INSERT INTO Categories
VALUES (
    @Name,
    SYSDATETIME()
    )
GO


CREATE PROCEDURE GetCategories
AS
SELECT c.*, ISNULL(sub.ArticlesRelated, 0) AS ArticlesRelated
FROM Categories c
LEFT JOIN
(
    SELECT CategoryId, COUNT(*) AS ArticlesRelated
    FROM Articles
    GROUP BY CategoryId
) AS sub
ON c.Id = sub.CategoryId;
GO


CREATE PROCEDURE DeleteCategory
    @Id INT
AS
    DELETE FROM Categories WHERE Id = @Id
GO


-- ######################################################################################
-- CREATE FOREIGN KEY Articles.CategoryId AND DateCreated,DateUpdated PROPERTIES
-- ######################################################################################

ALTER TABLE Articles ADD CategoryId INT NOT NULL DEFAULT (1)
--ALTER TABLE Articles DROP COLUMN CategoryId
ALTER TABLE Articles ADD FOREIGN KEY (CategoryId) REFERENCES Categories(Id)

ALTER TABLE Articles ADD DateCreated DATETIME NOT NULL DEFAULT GETDATE()
ALTER TABLE Articles ADD DateUpdated DATETIME DEFAULT NULL
