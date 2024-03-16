using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class StoredProcedures_SQLite
    {
        public const string SP_GETCATEGORIES = @"
        SELECT c.*, IFNULL(sub.ArticlesRelated, 0) AS ArticlesRelated
        FROM Categories c
        LEFT JOIN
        (
            SELECT CategoryId, COUNT(*) AS ArticlesRelated
            FROM Articles
            GROUP BY CategoryId
        ) AS sub
        ON c.Id = sub.CategoryId;
        ";
        public const string SP_INSERTCATEGORY = @"
        INSERT INTO Categories (Name,DateCreated)
        VALUES 
            (@Name, @DateCreated)
        ";
        public const string SP_DELTECATEGORY = @"
        DELETE FROM Categories 
        WHERE Id = @Id
        ";


        public const string SP_GETARTICLES = @"
        SELECT a.*, c.name as CategoryName
        FROM
        Articles a, Categories c
        WHERE a.CategoryId = c.id
        ";
        public const string SP_DELETEARTICLE = @"
        DELETE FROM Articles 
        where Id = @Id
        ";
        public const string SP_INSERTARTICLE = @"
        INSERT INTO Articles (Name, Description, Stock, DateCreated, DateUpdated, CategoryId)
        VALUES
            (@Name, @Description, @Stock, @DateCreated, @DateUpdated, @CategoryId)
        ";
        public const string SP_UPDATEARTICLE = @"
        UPDATE Articles
        SET Name = @Name,
            Description = @Description,
            Stock = @Stock,
            DateUpdated = CURRENT_TIMESTAMP,
            CategoryId = @CategoryId
        WHERE Id = @Id
        ";
        public const string SP_SEARCHARTICLE = @"
        SELECT
            a.*, c.Name CategoryName
        FROM
            Articles a, Categories c
        WHERE
            (
                (@IncludeName = 1 AND a.Name LIKE '%' || @Search || '%')
                OR
                (@IncludeDesc = 1 AND a.Description LIKE '%' || @Search || '%')
            )
            AND
            @Search <> ''
            AND
            a.CategoryId = c.Id
        ";
    }
}
