using DataLayer.Repositories.Contracts;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public static class RepositoryFactory
    {
        private enum ProvidersType
        {
            mssql,
            sqlite,
            mongodb // TODO a futuro
        }

        public static IArticleRepository<Article> CreateArticleRepository()
        {
            string databaseType = ConfigurationManager.AppSettings["DatabaseType"].ToLower();
            IArticleRepository<Article> repository = null;
            switch (databaseType)
            {
                case nameof(ProvidersType.mssql):
                    repository= new Providers.MSSQL.ArticleRepository();
                    break;
                case nameof(ProvidersType.sqlite):
                    repository= new Providers.SQLite.ArticleRepository();
                    break;
                default:
                    throw new Exception($">> Error al crear instancia de repositorio. No se encotro el tipo de base de datos '{databaseType}'");
                    break;
            }
            return repository;
        }

        public static ICategoryRepository<Category> CreateCategoryRepository()
        {
            string databaseType = ConfigurationManager.AppSettings["DatabaseType"].ToLower();
            ICategoryRepository<Category> repository = null;
            switch (databaseType)
            {
                case nameof(ProvidersType.mssql):
                    repository = new Providers.MSSQL.CategoryRepository();
                    break;
                case nameof(ProvidersType.sqlite):
                    repository = new Providers.SQLite.CategoryRepository();
                    break;
                default:
                    throw new Exception($">> Error al crear instancia de repositorio. No se encotro el tipo de base de datos '{databaseType}'");
                    break;
            }
            return repository;
        }
    }
}
