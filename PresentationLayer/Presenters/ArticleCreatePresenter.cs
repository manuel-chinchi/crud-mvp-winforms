using BussinesLayer.Services;
using BussinesLayer.Services.Contracts;
using EntityLayer.Models;
using PresentationLayer.Views.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using Core.Services.Contracts;
using Core.Services;

namespace PresentationLayer.Presenters
{
    public class ArticleCreatePresenter
    {
        IArticleCreateView _viewCreate { get; set; }
        IArticleService<IEnumerable<Article>> _articleService { get; set; }
        ICategoryService<IEnumerable<Category>> _categoryService { get; set; }
        ILanguageService languageService { get; set; } = new LanguageService();

        public ArticleCreatePresenter(IArticleCreateView view, IArticleService<IEnumerable<Article>> service)
        {
            _viewCreate = view;
            _viewCreate.Presenter = this;
            _articleService = service;
            _categoryService = new CategoryService();

            _viewCreate.Categories = _categoryService.GetCategories();
            _viewCreate.AcceptClick += _viewCreate_AcceptClick;
            _viewCreate.CancelClick += _viewCreate_CancelClick;
        }

        public ArticleCreatePresenter(IArticleCreateView view, IArticleService<IEnumerable<Article>> articleService, ICategoryService<IEnumerable<Category>> categoryService)
        {
            _viewCreate = view;
            _viewCreate.Presenter = this;
            _articleService = articleService;
            _categoryService = categoryService;

            _viewCreate.Categories = _categoryService.GetCategories();
            _viewCreate.AcceptClick += _viewCreate_AcceptClick;
            _viewCreate.CancelClick += _viewCreate_CancelClick;
        }

        public ArticleCreatePresenter(IArticleCreateView view)
        {
            _viewCreate = view;
            _viewCreate.Presenter = this;
            _articleService = new ArticleService();
            _categoryService = new CategoryService();

            _viewCreate.Categories = _categoryService.GetCategories();
            _viewCreate.AcceptClick += _viewCreate_AcceptClick;
            _viewCreate.CancelClick += _viewCreate_CancelClick;

            languageService.SetLanguage("en");
        }

        private void _viewCreate_CancelClick(object sender, EventArgs e)
        {
            _viewCreate.CloseView();
        }

        private void _viewCreate_AcceptClick(object sender, EventArgs e)
        {
            string msg="";
            var category = _viewCreate.Categories.ToArray()[_viewCreate.ItemSelected];
            if (_viewCreate.IsEditMode)
            {
                _viewCreate.Categories = _categoryService.GetCategories();
                _articleService.UpdateArticle(_viewCreate.NameA, _viewCreate.Description, _viewCreate.Stock.ToString(), _viewCreate.Id.ToString(), category.Id.ToString());
                // OkArticleUpdated
                //msg = languageService.GetString(LanguageService.Messages.SuccessArticleUpdated);
                _viewCreate.Success = string.Format(msg, _viewCreate.Id.ToString());
                _viewCreate.ShowSuccess = true;
                _viewCreate.IsEditMode = false;
            }
            else
            {
                // TODO: mmm.. check this ¿_view.CategoryId property missing?
                if (string.IsNullOrEmpty(_viewCreate.NameA))
                {
                    // AlertInvalidNameField
                    //msg = languageService.GetString(LanguageService.Messages.InvalidNameField);
                    _viewCreate.Error = msg;
                    _viewCreate.ShowError = true;
                    return;
                }
                _articleService.CreateArticle(_viewCreate.NameA, _viewCreate.Description, _viewCreate.Stock.ToString(), category.Id.ToString());
                // OkArticleCreated
                //msg = languageService.GetString(LanguageService.Messages.SuccessArticleCreated);
                _viewCreate.Success = string.Format(msg, _viewCreate.NameA);
                _viewCreate.ShowSuccess = true;
            }
            _viewCreate.CloseView();
        }

        public void LoadArticleFromEdit(Article article)
        {
            _viewCreate.Id = article.Id.ToString();
            _viewCreate.NameA = article.Name;
            _viewCreate.Description = article.Description;
            _viewCreate.Stock = article.Stock.ToString();
            _viewCreate.ItemSelected = _viewCreate.Categories.ToList().FindIndex(c => c.Id == Convert.ToInt32(article.CategoryId));
            _viewCreate.IsEditMode = true;
        }
    }
}
