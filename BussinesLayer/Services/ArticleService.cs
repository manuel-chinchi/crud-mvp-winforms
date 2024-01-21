﻿using DataLayer.Repositories;
using DataLayer.Repositories.Contracts;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Contracts
{
    public class ArticleService : IArticleService<IEnumerable<Article>>
    {
        private IArticleRepository<IEnumerable<Article>> _repository = new ArticleRepository();

        public IEnumerable<Article> GetArticles()
        {
            return _repository.GetArticles();
        }

        public void DeleteArticle(string id)
        {
            _repository.DeleteArticle(id);
        }

        public void InsertArticle(string name, string description, string brand, string stock)
        {
            _repository.InsertArticle(name, description, brand, stock);
        }

        public IEnumerable<Article> SearchArticle(int includeName, int includeDescription, int includeBrand, string search)
        {
            return _repository.SearchArticle(includeName, includeDescription, includeBrand, search).ToList();
        }

        public void UpdateArticle(string name, string description, string brand, string stock, string id)
        {
            _repository.EditArticle(name, description, brand, stock, id);
        }
    }
}
