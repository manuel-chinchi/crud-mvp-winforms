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
        IArticleCreateView _viewCreate { get; set; }
        IArticleService<Article> _articleService { get; set; }
        ICategoryService<Category> _categoryService { get; set; }

        public ArticleCreatePresenter(
            IArticleCreateView view, 
            IArticleService<Article> articleService, 
            ICategoryService<Category> categoryService)
        {
            _viewCreate = view;
            _viewCreate.Presenter = this;
            _articleService = articleService;
            _categoryService = categoryService;

            _viewCreate.Categories = _categoryService.GetCategories();
            _viewCreate.AcceptClick += _viewCreate_AcceptClick;
            _viewCreate.CancelClick += _viewCreate_CancelClick;
        }

        public ArticleCreatePresenter(IArticleCreateView view, IArticleService<Article> service)
        {
            _viewCreate = view;
            _viewCreate.Presenter = this;
            _articleService = service;
            _categoryService = new CategoryService();

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
        }

        private void _viewCreate_CancelClick(object sender, EventArgs e)
        {
            _viewCreate.CloseView();
        }

        private void _viewCreate_AcceptClick(object sender, EventArgs e)
        {
            var category = _viewCreate.Categories.ToArray()[_viewCreate.ItemSelected];
            if (_viewCreate.IsEditMode)
            {
                _viewCreate.Categories = _categoryService.GetCategories();
                if (string.IsNullOrEmpty(_viewCreate.Stock))
                {
                    _viewCreate.Stock = "0";
                }
                _articleService.UpdateArticle(
                    new Article
                    {
                        Id =  Convert.ToInt32(_viewCreate.Id),
                        Name = _viewCreate.NameA,
                        Description = _viewCreate.Description,
                        Stock = Convert.ToInt32(_viewCreate.Stock),
                        CategoryId = category.Id.ToString()
                    });
                //_viewCreate.Success = $"'Article id={_viewCreate.Id.ToString()}' has been updated.";
                //_viewCreate.ShowSuccess = true;
                _viewCreate.IsEditMode = false;
            }
            else
            {
                if (string.IsNullOrEmpty(_viewCreate.NameA))
                {
                    //_viewCreate.Error = "The 'Name' field cannot be empty";
                    //_viewCreate.ShowError = true;
                    return;
                }
                if (string.IsNullOrEmpty(_viewCreate.Stock))
                {
                    _viewCreate.Stock = "0";
                }
                _articleService.CreateArticle(
                    new Article
                    {
                        Name = _viewCreate.NameA,
                        Description = _viewCreate.Description,
                        Stock = Convert.ToInt32(_viewCreate.Stock, 10),
                        CategoryId = category.Id.ToString()
                    });
                //_viewCreate.Success = $"The article '{_viewCreate.NameA}' has been created";
                //_viewCreate.ShowSuccess = true;
            }
            _viewCreate.CloseView();
        }

        public void LoadArticleFromEdit(Article article)
        {
            _viewCreate.Id = article.Id.ToString();
            _viewCreate.NameA = article.Name;
            _viewCreate.Description = article.Description;
            _viewCreate.Stock = article.Stock.ToString();
            _viewCreate.ItemSelected = _viewCreate
                .Categories
                .ToList()
                .FindIndex(c => c.Id == Convert.ToInt32(article.CategoryId));
            _viewCreate.IsEditMode = true;
        }
    }
}
