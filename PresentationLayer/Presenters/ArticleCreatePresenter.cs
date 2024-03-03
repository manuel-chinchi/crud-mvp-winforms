using BussinesLayer.Services;
using BussinesLayer.Services.Contracts;
using EntityLayer.Models;
using PresentationLayer.Views.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class ArticleCreatePresenter
    {
        IArticleCreateView _view { get; set; }
        IArticleService<IEnumerable<Article>> _articleService { get; set; }
        ICategoryService<IEnumerable<Category>> _categoryService { get; set; }

        public ArticleCreatePresenter(IArticleCreateView view, IArticleService<IEnumerable<Article>> service)
        {
            _view = view;
            _view.Presenter = this;
            _articleService = service;
            _categoryService = new CategoryService();

            _view.Categories = _categoryService.GetCategories();
            _view.AcceptClick += _view_AcceptClick;
            _view.CancelClick += _view_CancelClick;
        }

        public ArticleCreatePresenter(IArticleCreateView view, IArticleService<IEnumerable<Article>> articleService, ICategoryService<IEnumerable<Category>> categoryService)
        {
            _view = view;
            _view.Presenter = this;
            _articleService = articleService;
            _categoryService = categoryService;

            _view.Categories = _categoryService.GetCategories();
            _view.AcceptClick += _view_AcceptClick;
            _view.CancelClick += _view_CancelClick;
        }

        public ArticleCreatePresenter(IArticleCreateView view)
        {
            _view = view;
            _view.Presenter = this;
            _articleService = new ArticleService();
            _categoryService = new CategoryService();

            _view.Categories = _categoryService.GetCategories();
            _view.AcceptClick += _view_AcceptClick;
            _view.CancelClick += _view_CancelClick;
        }

        private void _view_CancelClick(object sender, EventArgs e)
        {
            _view.CloseView();
        }

        private void _view_AcceptClick(object sender, EventArgs e)
        {
            var category = _view.Categories.ToArray()[_view.ItemSelected];
            if (_view.IsEditMode)
            {
                _view.Categories = _categoryService.GetCategories();
                _articleService.UpdateArticle(_view.NameA, _view.Description, _view.Stock.ToString(), _view.Id.ToString(), category.Id.ToString());
                _view.Success = $"Se ha actualizado el artículo 'id={_view.Id.ToString()}'";
                _view.ShowSuccess = true;
                _view.IsEditMode = false;
            }
            else
            {
                // TODO: mmm.. check this ¿_view.CategoryId property missing?
                if (string.IsNullOrEmpty(_view.NameA))
                {
                    _view.Error = "El campo 'Nombre' no puede ser vacío";
                    _view.ShowError = true;
                    return;
                }
                _articleService.CreateArticle(_view.NameA, _view.Description, _view.Stock.ToString(), category.Id.ToString());
                _view.Success = $"Se ha creado el artículo '{_view.NameA}'";
                _view.ShowSuccess = true;
            }
            _view.CloseView();
        }

        public void LoadArticleFromEdit(Article article)
        {
            _view.Id = article.Id.ToString();
            _view.NameA = article.Name;
            _view.Description = article.Description;
            _view.Stock = article.Stock.ToString();
            _view.ItemSelected = _view.Categories.ToList().FindIndex(c => c.Id == Convert.ToInt32(article.CategoryId));
        }

        public void ActivateEditMode()
        {
            _view.IsEditMode = true;
        }
    }
}
