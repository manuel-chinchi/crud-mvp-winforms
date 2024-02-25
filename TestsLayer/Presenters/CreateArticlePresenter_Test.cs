using BussinesLayer.Services.Contracts;
using EntityLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.Presenters;
using PresentationLayer.Views.Contracts;
using System;
using System.Collections.Generic;

namespace TestsLayer.Presenters
{
    [TestClass]
    public class CreateArticlePresenter_Test
    {
        private readonly ArticleService_Test _service = new ArticleService_Test();

        [TestMethod]
        public void ArticleNameIsEmpty_Error()
        {
            var view = new CreateArticleView_Test();
            var presenter = new CreateArticlePresenter(view);

            view.NameA = "";
            view.Accept();
            Assert.AreEqual("El campo 'Nombre' no puede ser vacío", view.Error);
        }

        // TODO System.NullReferenceException -> Agregar instancia de CategoryService en el constructor
        [TestMethod]
        public void ArticleNameIsNotValid_Error()
        {
            var view = new CreateArticleView_Test();
            var presenter = new CreateArticlePresenter(view, _service);

            view.NameA = "Rop@";
            view.Accept();
            Assert.AreEqual(null, view.Error);
        }

        // TODO System.NullReferenceException -> Agregar instancia de CategoryService en el constructor
        // TODO cambiar el mensaje a "Se ha creado el artículo 'x'" para que concida con el de categorias
        [TestMethod]
        public void ArticleNameValid_Success()
        {
            var view = new CreateArticleView_Test();
            var presenter = new CreateArticlePresenter(view, _service);

            view.NameA = "Art3";
            view.Description = "";
            view.Stock = "";
            view.Accept();
            Assert.AreEqual("Se ha creado el artículo 'Art3'", view.Success);
        }
    }

    public class ArticleService_Test : IArticleService<IEnumerable<Article>>
    {
        public void CreateArticle(string name, string description, string stock, string categoryId) { }
        public void DeleteArticle(string id) { }
        public IEnumerable<Article> GetArticles()
        {
            return new List<Article>()
            {
                new Article { Name = "Art1" },
                new Article { Name = "Art2" }
            };
        }
        public IEnumerable<Article> SearchArticle(int includeName, int includeDescription, string search) { return null; }
        public void UpdateArticle(string name, string description, string stock, string id, string categoryId) { }
    }

    public class CreateArticleView_Test : ICreateArticleView
    {
        public string Id { get; set; }
        public string NameA { get;set; }
        public string Description { get;set; }
        public string Stock { get;set; }
        public string Category { get;set; }
        public bool IsEditMode { get; set; }
        public int ItemSelected { get;set; }
        public IEnumerable<Category> Categories { get;set; }
        public CreateArticlePresenter Presenter { get;set; }
        public string Error { get;set; }
        public bool ShowError { get;set; }
        public string Success { get;set; }
        public bool ShowSuccess { get;set; }

        public event EventHandler AcceptClick;
        public event EventHandler CancelClick;

        public void Accept() => AcceptClick?.Invoke(this, EventArgs.Empty);

        public void CloseView() { }
        public void ShowView() { }
    }
}
