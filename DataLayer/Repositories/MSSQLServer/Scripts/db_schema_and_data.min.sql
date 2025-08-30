-- database schema for crud_mvp_winforms, 
-- proyect repo https://github.com/manuel-chinchi/crud-mvp-winforms/tree/master

USE [crud_mvp_winforms]
GO

-- ######################################################################################
-- tables 
-- ######################################################################################

CREATE TABLE [dbo].[Categories](
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    DateCreated DATETIME NOT NULL
)
GO

CREATE TABLE [dbo].[Articles](
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(100) null,
    Stock INT,
    DateCreated DATETIME NOT NULL,
    DateUpdated DATETIME NULL,

    CategoryId INT NOT NULL
    FOREIGN KEY (CategoryId) REFERENCES [dbo].[Categories](Id)
)
GO

-- ######################################################################################
-- dataset test
-- ######################################################################################

INSERT INTO [dbo].[Categories] 
VALUES 
    ('Otro', '2024-01-15 00:00:00'),
    ('Pantalones', '2024-01-15 00:00:00'),
    ('Remeras', '2024-01-15 00:00:00'),
    ('Camisas', '2024-01-15 00:00:00'),
    ('Busos', '2024-01-15 00:00:00'),
    ('Gorras', '2024-01-15 00:00:00')
GO

INSERT INTO [dbo].[Articles]
VALUES
    ('Zapatilla', 'talle 40, cuero', 200, '2024-01-10 00:00:00', NULL, 1),
    ('Zapatilla', 'talle 42, cuero, mujer', 200, '2024-01-10 00:00:00', NULL, 1),
    ('Camisa', 'talle l', 400, '2024-01-10 00:00:00', NULL, 4),
    ('Camisa', 'talle m, lisa',350, '2024-01-15 00:00:00', NULL, 4),
    ('Jean', 'talle 41-43 chupin', 150, '2024-01-15 00:00:00', NULL, 2),
    ('Gorra', 'varios colores, lisas', 500, '2024-01-15 00:00:00', NULL, 6),
    ('Medias', 'medianas', 200, '2024-01-30 00:00:00', NULL, 1),
    ('Zapato', 'unisex, talle 40, sintetico', 350, '2024-01-30 00:00:00', NULL, 1),
    ('Zapatilla', 'talle 48', 350, '2024-01-30 00:00:00', NULL, 1),
    ('Gorra', 'lisa blanca', 350, '2024-01-30 00:00:00', NULL, 6)
GO

-- ######################################################################################
-- stored procedures
-- ######################################################################################

-- Articles

CREATE PROCEDURE GetArticle @Id INT
AS
SELECT *
FROM Articles
WHERE Id = @Id
GO

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
    SYSDATETIME(),
    NULL,
    @CategoryId
    )
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
    DateUpdated = SYSDATETIME(),
    CategoryId = @CategoryId
WHERE Id = @Id
GO

CREATE PROCEDURE DeleteArticle @Id INT
AS
DELETE
FROM Articles
WHERE Id = @Id
GO

CREATE PROCEDURE GetArticles
AS
SELECT a.*, c.Name as CategoryName
FROM Articles a, Categories c
WHERE a.CategoryId = c.Id
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

-- Categories

CREATE PROCEDURE InsertCategory
    @Name VARCHAR(100)
AS
    INSERT INTO Categories
    VALUES (@Name, SYSDATETIME())
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
