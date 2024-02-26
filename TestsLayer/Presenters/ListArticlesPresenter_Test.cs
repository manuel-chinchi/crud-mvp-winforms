using BussinesLayer.Services.Contracts;
using EntityLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.Presenters;
using PresentationLayer.Views.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestsLayer.Presenters
{
    [TestClass]
    public class ListArticlesPresenter_Test
    {
        private readonly ArticleService_2_Test _service = new ArticleService_2_Test();

        [TestMethod]
        public void ArticleDeleted_Success()
        {
            var view = new ListArticlesView_Test();
            var presenter = new ListArticlesPresenter(view, _service);

            view.Load();
            view.ItemSelected = 0;
            view.Delete();
            Assert.AreEqual("Se ha eliminado el artículo 'Art1'", view.Success);
        }

        [TestMethod]
        public void ArticleSearchNoResults_Warning()
        {
            var view = new ListArticlesView_Test();
            var presenter = new ListArticlesPresenter(view, _service);

            //view.Show();
            view.Search = "Art1";
            view.SearchItem();
            Assert.AreEqual("Por favor seleccione un filtro de busqueda", view.Warning);
        }
    }

    public class ArticleService_2_Test : IArticleService<IEnumerable<Article>>
    {
        private IEnumerable<Article> articles = new List<Article>()
            {
                new Article { Name = "Art1" },
                new Article { Name = "Art2" }
            };
        public void CreateArticle(string name, string description, string stock, string categoryId) { }
        public void DeleteArticle(string id) { }
        public IEnumerable<Article> GetArticles() { return articles; }
        public IEnumerable<Article> SearchArticle(int includeName, int includeDescription, string search) { return articles; }
        public void UpdateArticle(string name, string description, string stock, string id, string categoryId) { }
    }

    class ListArticlesView_Test : IListArticlesView
    {
        public int ItemSelected { get; set; }
        public bool IncludeName { get; set; }
        public bool IncludeDescription { get; set; }
        public string Search { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        public ListArticlesPresenter Presenter { get; set; }
        public string Warning { get; set; }
        public bool ShowWarning { get; set; }
        public string Error { get; set; }
        public bool ShowError { get; set; }
        public string Success { get; set; }
        public bool ShowSuccess { get; set; }

        public event EventHandler AddClick;
        public event EventHandler EditClick;
        public event EventHandler DeleteClick;
        public event EventHandler SearchClick;
        public event EventHandler ShowAllClick;
        public event EventHandler ViewLoad;

        public void SearchItem() => SearchClick?.Invoke(this, EventArgs.Empty);
        public void Delete() => DeleteClick?.Invoke(this, EventArgs.Empty);
        public void Load() => ViewLoad?.Invoke(this, EventArgs.Empty);
    }
}
