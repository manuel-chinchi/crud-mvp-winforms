﻿-- ######################################################################################
-- Tables
-- ######################################################################################

CREATE TABLE Articles (
    Id    INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Name  TEXT NOT NULL,
    Description   TEXT,
    Stock INTEGER,
    DateCreated   TEXT NOT NULL,
    DateUpdated   TEXT,
    CategoryId    INTEGER
);

CREATE TABLE Categories (
    Id    INTEGER PRIMARY KEY AUTOINCREMENT,
    Name  TEXT NOT NULL,
    DateCreated   TEXT NOT NULL
);

-- ######################################################################################
-- Data sets
-- ######################################################################################

INSERT INTO Articles 
    (Name, Description, Stock, DateCreated, DateUpdated, CategoryId)
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
    ('Gorra', 'lisa blanca', 350, '2024-01-30 00:00:00', NULL, 6);

INSERT INTO Categories
    (Name, DateCreated)
VALUES
    ('Otro', '2024-01-15 00:00:00'),
    ('Pantalones', '2024-01-15 00:00:00'),
    ('Remeras', '2024-01-15 00:00:00'),
    ('Camisas', '2024-01-15 00:00:00'),
    ('Busos', '2024-01-15 00:00:00'),
    ('Gorras', '2024-01-15 00:00:00');
