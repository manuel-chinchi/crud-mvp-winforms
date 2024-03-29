USE [crud_mvp_winforms]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 5/3/2024 10:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[Stock] [int] NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NULL,
	[CategoryId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/3/2024 10:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([Id], [Name], [Description], [Stock], [DateCreated], [DateUpdated], [CategoryId]) VALUES (1, N'Zapatilla', N'talle 40, cuero', 200, CAST(N'2024-01-10T00:00:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Articles] ([Id], [Name], [Description], [Stock], [DateCreated], [DateUpdated], [CategoryId]) VALUES (2, N'Zapatilla', N'talle 42, cuero, mujer', 200, CAST(N'2024-01-10T00:00:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Articles] ([Id], [Name], [Description], [Stock], [DateCreated], [DateUpdated], [CategoryId]) VALUES (3, N'Camisa', N'talle l', 400, CAST(N'2024-01-10T00:00:00.000' AS DateTime), NULL, 4)
INSERT [dbo].[Articles] ([Id], [Name], [Description], [Stock], [DateCreated], [DateUpdated], [CategoryId]) VALUES (4, N'Camisa', N'talle m, lisa', 350, CAST(N'2024-01-15T00:00:00.000' AS DateTime), NULL, 4)
INSERT [dbo].[Articles] ([Id], [Name], [Description], [Stock], [DateCreated], [DateUpdated], [CategoryId]) VALUES (5, N'Jean', N'talle 41-43 chupin', 150, CAST(N'2024-01-15T00:00:00.000' AS DateTime), NULL, 2)
INSERT [dbo].[Articles] ([Id], [Name], [Description], [Stock], [DateCreated], [DateUpdated], [CategoryId]) VALUES (6, N'Gorra', N'varios colores, lisas', 500, CAST(N'2024-01-15T00:00:00.000' AS DateTime), NULL, 6)
INSERT [dbo].[Articles] ([Id], [Name], [Description], [Stock], [DateCreated], [DateUpdated], [CategoryId]) VALUES (7, N'Medias', N'medianas', 200, CAST(N'2024-01-30T00:00:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Articles] ([Id], [Name], [Description], [Stock], [DateCreated], [DateUpdated], [CategoryId]) VALUES (8, N'Zapato', N'unisex, talle 40, sintetico', 350, CAST(N'2024-01-30T00:00:00.000' AS DateTime), NULL, 1)
INSERT [dbo].[Articles] ([Id], [Name], [Description], [Stock], [DateCreated], [DateUpdated], [CategoryId]) VALUES (9, N'Zapatilla', N'talle 48', 350, CAST(N'2024-01-30T00:00:00.000' AS DateTime), CAST(N'2024-03-03T15:14:47.673' AS DateTime), 1)
INSERT [dbo].[Articles] ([Id], [Name], [Description], [Stock], [DateCreated], [DateUpdated], [CategoryId]) VALUES (10, N'Gorra', N'lisa blanca', 350, CAST(N'2024-01-30T00:00:00.000' AS DateTime), NULL, 6)
SET IDENTITY_INSERT [dbo].[Articles] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [DateCreated]) VALUES (1, N'Otro', CAST(N'2024-01-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Categories] ([Id], [Name], [DateCreated]) VALUES (2, N'Pantalones', CAST(N'2024-01-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Categories] ([Id], [Name], [DateCreated]) VALUES (3, N'Remeras', CAST(N'2024-01-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Categories] ([Id], [Name], [DateCreated]) VALUES (4, N'Camisas', CAST(N'2024-01-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Categories] ([Id], [Name], [DateCreated]) VALUES (5, N'Busos', CAST(N'2024-01-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Categories] ([Id], [Name], [DateCreated]) VALUES (6, N'Gorras', CAST(N'2024-01-15T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[DeleteArticle]    Script Date: 5/3/2024 10:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteArticle] @Id INT
AS
DELETE
FROM Articles
WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategory]    Script Date: 5/3/2024 10:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCategory]
    @Id INT
AS
    DELETE FROM Categories WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GetArticle]    Script Date: 5/3/2024 10:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetArticle] @Id INT
AS
SELECT *
FROM Articles
WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[GetArticles]    Script Date: 5/3/2024 10:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetArticles]
AS
SELECT a.*, c.Name as CategoryName
FROM Articles a, Categories c
WHERE a.CategoryId = c.Id
GO
/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 5/3/2024 10:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategories]
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
/****** Object:  StoredProcedure [dbo].[InsertArticle]    Script Date: 5/3/2024 10:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertArticle] 
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
/****** Object:  StoredProcedure [dbo].[InsertCategory]    Script Date: 5/3/2024 10:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertCategory]
    @Name VARCHAR(100)
AS
INSERT INTO Categories
VALUES (
    @Name, 
    SYSDATETIME()
    )
GO
/****** Object:  StoredProcedure [dbo].[SearchArticle]    Script Date: 5/3/2024 10:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchArticle]
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
/****** Object:  StoredProcedure [dbo].[UpdateArticle]    Script Date: 5/3/2024 10:42:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateArticle] 
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
