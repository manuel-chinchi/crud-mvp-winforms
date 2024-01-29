using BussinesLayer.Services;
using EntityLayer.Models;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class CreateArticlePresenter
    {
        ICreateArticleView _view { get; set; }
        IArticleService<IEnumerable<Article>> _articleService { get; set; }
        ICategoryService<IEnumerable<Category>> _categoryService { get; set; }

        public CreateArticlePresenter(ICreateArticleView view, IArticleService<IEnumerable<Article>> service)
        {
            _view = view;
            _view.Presenter = this;
            _articleService = service;
            _view.Category = "";
        }

        public CreateArticlePresenter(ICreateArticleView view, IArticleService<IEnumerable<Article>> articleService, ICategoryService<IEnumerable<Category>> categoryService)
        {
            _view = view;
            //_view.Presenter = this;
            _articleService = articleService;
            _categoryService = categoryService;
            _view.Categories = _categoryService.GetCategories();
        }

        public void SaveArticle()
        {
            // TODO: mmm.. check this ¿_view.CategoryId property missing?
            var category = _view.Categories.ToArray()[_view.ItemSelected];
            _articleService.CreateArticle(_view.NameA, _view.Description, _view.Stock.ToString(), category.Id.ToString());
            _view.MsgStatus = "Se ha agregado el artículo";
            _view.StatusResult = true;
        }

        public void UpdateArticle()
        {
            var category = _view.Categories.ToArray()[_view.ItemSelected];
            _articleService.UpdateArticle(_view.NameA, _view.Description, _view.Stock.ToString(), _view.Id.ToString(), category.Id.ToString());
            _view.MsgStatus = "Se ha actualizado el artículo";
            _view.StatusResult = true;
        }

        public void LoadArticleFromEdit(Article article)
        {
            _view.Id = article.Id.ToString();
            _view.NameA = article.Name;
            _view.Description = article.Description;
            _view.Stock = article.Stock.ToString();
            _view.ItemSelected = _view.Categories.ToList().FindIndex(c => c.Id == Convert.ToInt32(article.CategoryId));
        }

        public void LoadCategories()
        {
            _view.Categories = _categoryService.GetCategories();
        }

        public void ActivateEditMode()
        {
            _view.IsEditMode = true;
        }

        public string GetError() { return _view.MsgError; }

        public string GetStatus() { return _view.MsgStatus; }


    }
}
