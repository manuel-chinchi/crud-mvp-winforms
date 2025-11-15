/*
    db_schema_and_data.sql

    - Descripción
        Script para generar base de datos de "crud_mvp_winforms" con registros incluidos.

    - Comandos
      - Generar esquema de base de datos:
            sqlite3 ./crud_mvp_winforms.db > db_schema_and_data.sql
    
      - Crear base de datos en base a esquema:
            sqlite3	./crud_mvp_winforms.db < db_schema_and_data.sql
*/

PRAGMA foreign_keys = OFF;
BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Articles" (
    "Id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    "Name"	TEXT,
    "Description"	TEXT,
    "Stock"	INTEGER,
    "CategoryId"	INTEGER,
    "CreatedAt"	TEXT NOT NULL,
    "UpdatedAt"	TEXT
);
INSERT INTO Articles VALUES(6,'Camisa','algodón 100%',10,1,'2024-11-10 22:00:00',NULL);
INSERT INTO Articles VALUES(7,'Zapatilla','cuero',10,1,'2024-11-10 22:00:00',NULL);
INSERT INTO Articles VALUES(8,'Zapatilla','cuero sintético',10,1,'2024-11-10 22:00:00',NULL);
INSERT INTO Articles VALUES(9,'Camisa','algodon 75%',10,1,'2024-11-10 22:00:00',NULL);
INSERT INTO Articles VALUES(10,'Pantalon','deportivo',10,1,'2024-11-10 22:00:00',NULL);
INSERT INTO Articles VALUES(11,'Jean','cuero chupin',10,1,'2024-11-10 22:00:00',NULL);
INSERT INTO Articles VALUES(12,'Buso','tipo canguro c/capucha',10,1,'2024-11-10 22:00:00',NULL);
INSERT INTO Articles VALUES(13,'Gorra','blanca',10,1,'2024-11-10 22:00:00',NULL);
INSERT INTO Articles VALUES(14,'Medias','tipo soquetes p/hombre',10,1,'2024-11-10 22:00:00',NULL);
INSERT INTO Articles VALUES(15,'Medias','tipo soquetes p/mujer',10,1,'2024-11-10 22:00:00',NULL);
INSERT INTO Articles VALUES(18,'','','',1,'2025-07-29 07:48:19',NULL);
CREATE TABLE IF NOT EXISTS "Categories" (
    "Id"	INTEGER PRIMARY KEY AUTOINCREMENT,
    "Name"	TEXT NOT NULL,
    "CreatedAt"	TEXT NOT NULL
);
INSERT INTO Categories VALUES(1,'Otro','2024-11-10 22:00:00');
INSERT INTO Categories VALUES(2,'Medias','2024-11-10 22:00:00');
INSERT INTO Categories VALUES(3,'Camisas','2024-11-10 22:00:00');
INSERT INTO Categories VALUES(4,'Medias','2024-11-10 22:00:00');
DELETE FROM sqlite_sequence;
INSERT INTO sqlite_sequence VALUES('Articles',18);
INSERT INTO sqlite_sequence VALUES('Categories',7);
COMMIT;
