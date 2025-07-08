using BussinesLayer.Services;
using BussinesLayer.Services.Contracts;
using Core.Services;
using Core.Services.Contracts;
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
        ILanguageService languageService { get; set; } = new LanguageService();

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

            languageService.SetLanguage("en");
        }

        private void _viewList_ViewLoad(object sender, EventArgs e)
        {
            LoadArticles();
        }

        private void _viewList_ShowAllClick(object sender, EventArgs e)
        {
            LoadArticles();
            _viewList.ShowSuccess = false;
        }

        private void _viewList_SearchClick(object sender, EventArgs e)
        {
            SearchArticle();
        }

        private void _viewList_DeleteClick(object sender, EventArgs e)
        {
            string msg="";
            var indices = _viewList.SelectedIndices;
            var articles = _viewList.Articles.Where((item, index) => indices.Contains(index)).ToList();

            if (articles.Count > 0)
            {
                // AskDeleteSelectedItems
                //msg = languageService.GetString(LanguageService.Messages.QuestionConfirmDeleteItem);
                var result = System.Windows.Forms.MessageBox.Show(msg, "Alert", System.Windows.Forms.MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    int count = articles.Count;
                    foreach (var article in articles)
                    {
                        _service.DeleteArticle(article.Id.ToString());
                    }
                    // OkArticlesDeleted
                    _viewList.Success = $"Se eliminaron {count} artículos";
                    _viewList.ShowSuccess = true;

                    LoadArticles();
                    _viewList.FilterIncludeName = false;
                    _viewList.FilterIncludeDescription = false;
                }
            }
            else
            {
                // AlertSelectOneArticle
                System.Windows.Forms.MessageBox.Show("Seleccione al menos 1 artículo");
            }
        }

        private void _viewList_EditClick(object sender, EventArgs e)
        {
            var indices = _viewList.SelectedIndices;
            var articles = _viewList.Articles.Where((item, index) => indices.Contains(index)).ToList();

            if (articles.Count == 1)
            {
                // TODO por ahí habría que crear una vista ArticleEditView en vez de LoadArticleFromEdit
                _viewCreate = new ArticleCreateView();
                _viewCreate.Presenter.LoadArticleFromEdit(articles[0]);
                _viewCreate.ShowView();
                
                if (!string.IsNullOrEmpty(_viewCreate.Success))
                {
                    _viewList.Success = _viewCreate.Success;
                    _viewList.ShowSuccess = true;
                    LoadArticles();
                }
            }
            else
            {
                // AlertSelectOneArticle
                System.Windows.Forms.MessageBox.Show("Seleccione 1 artículo");
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
                LoadArticles();
            }
        }

        private void LoadArticles()
        {
            _viewList.Articles = _service.GetArticles();
        }

        private void SearchArticle()
        {
            var result = _service.SearchArticle(Convert.ToInt32(_viewList.FilterIncludeName), Convert.ToInt32(_viewList.FilterIncludeDescription), _viewList.Search);
            _viewList.Error = "";

            if (_viewList.FilterIncludeName == false && _viewList.FilterIncludeDescription == false)
            {
                // WarningSelectAFilter
                // AlertSelectAFilter
                _viewList.Warning = "Please select a search filter";
                _viewList.ShowWarning = true;
                return;
            }
            else if ((_viewList.FilterIncludeName || _viewList.FilterIncludeDescription) && result.Count() == 0)
            {
                // ErrorNoResults
                // OkNoFindResults
                _viewList.Success = "No results found";
                _viewList.ShowSuccess = true;
            }
            else
            {
                // SuccessFilterResults
                // OkCountFindResults
                _viewList.Success = $"'{result.Count()}' results found";
                _viewList.ShowSuccess = true;
            }

            _viewList.Articles = result;
        }
    }
}
