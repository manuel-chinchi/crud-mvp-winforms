using BussinesLayer.Services;
using BussinesLayer.Services.Contracts;
using EntityLayer.Models;
using PresentationLayer.Views;
using PresentationLayer.Views.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class ArticleListPresenter
    {
        IArticleListView _viewList { get; set; }
        IArticleCreateView _viewCreate { get; set; }
        IArticleService<IEnumerable<Article>> _service { get; set; }

        public ArticleListPresenter(IArticleListView view, IArticleService<IEnumerable<Article>> service)
        {
            _viewList = view;
            _viewList.Presenter = this;
            _service = service;
            
            _viewList.AddClick += _viewList_AddClick;
            _viewList.EditClick += _viewList_EditClick;
            _viewList.DeleteClick += _viewList_DeleteClick;
            _viewList.SearchClick += _viewList_SearchClick;
            _viewList.ShowAllClick += _viewList_ShowAllClick;
            _viewList.ViewLoad += _viewList_ViewLoad;
        }

        public ArticleListPresenter(IArticleListView view)
        {
            _viewList = view;
            _viewList.Presenter = this;
            _service = new ArticleService();

            _viewList.AddClick += _viewList_AddClick;
            _viewList.EditClick += _viewList_EditClick;
            _viewList.DeleteClick += _viewList_DeleteClick;
            _viewList.SearchClick += _viewList_SearchClick;
            _viewList.ShowAllClick += _viewList_ShowAllClick;
            _viewList.ViewLoad += _viewList_ViewLoad;
        }

        private void _viewList_ViewLoad(object sender, EventArgs e)
        {
            _viewList.Articles = _service.GetArticles();
        }

        private void _viewList_ShowAllClick(object sender, EventArgs e)
        {
            _viewList.Articles = _service.GetArticles();
            _viewList.ShowSuccess = false;
        }

        private void _viewList_SearchClick(object sender, EventArgs e)
        {
            this.SearchArticle();
        }

        private void _viewList_DeleteClick(object sender, EventArgs e)
        {
            var article = _viewList.Articles.ToArray()[_viewList.ItemSelected];
            var result = System.Windows.Forms.MessageBox.Show($"Do you want to delete article '{article.Name}'?", "Alert", System.Windows.Forms.MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.DeleteArticle();
                _viewList.Success = $"The article '{article.Name}' has been removed";
                _viewList.ShowSuccess = true;
            }
            this.LoadArticles();
        }

        private void _viewList_EditClick(object sender, EventArgs e)
        {
            var article = _viewList.Articles.ToArray()[_viewList.ItemSelected];
            _viewCreate = new ArticleCreateView();
            _viewCreate.Presenter.LoadArticleFromEdit(article);
            _viewCreate.ShowView();

            if (!string.IsNullOrEmpty(_viewCreate.Success))
            {
                _viewList.Success = _viewCreate.Success;
                _viewList.ShowSuccess = true;
                _viewList.Articles = _service.GetArticles();
            }
        }

        private void _viewList_AddClick(object sender, EventArgs e)
        {
            _viewCreate = new ArticleCreateView();
            _viewCreate.ShowView();

            if (!string.IsNullOrEmpty(_viewCreate.Success))
            {
                _viewList.Success = _viewCreate.Success;
                _viewList.ShowSuccess = true;
                _viewList.Articles = _service.GetArticles();
            }
        }

        public void DeleteArticle()
        {
            var article = _viewList.Articles.ToList()[_viewList.ItemSelected];
            _service.DeleteArticle(article.Id.ToString());
            _viewList.Success = "Article has been removed";
            _viewList.ShowSuccess = true;
        }

        public void LoadArticles()
        {
            _viewList.Articles = _service.GetArticles();
            _viewList.IncludeName = false;
            _viewList.IncludeDescription = false;
        }

        public Article GetArticleSelected()
        {
            return _viewList.Articles.ToArray()[_viewList.ItemSelected];
        }

        public void SearchArticle()
        {
            var result = _service.SearchArticle(Convert.ToInt32(_viewList.IncludeName), Convert.ToInt32(_viewList.IncludeDescription), _viewList.Search);
            _viewList.Error = "";

            if (_viewList.IncludeName == false && _viewList.IncludeDescription == false)
            {
                _viewList.Warning = "Please select a search filter";
                _viewList.ShowWarning = true;
                return;
            }
            else if ((_viewList.IncludeName || _viewList.IncludeDescription) && result.Count() == 0)
            {
                _viewList.Success = "No results found";
                _viewList.ShowSuccess = true;
            }
            else
            {
                _viewList.Success = $"'{result.Count()}' results found";
                _viewList.ShowSuccess = true;
            }

            _viewList.Articles = result;
        }
    }
}
