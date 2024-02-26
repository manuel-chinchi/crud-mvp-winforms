using BussinesLayer.Services;
using BussinesLayer.Services.Contracts;
using EntityLayer.Models;
using PresentationLayer.Forms;
using PresentationLayer.Views.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class ListArticlesPresenter
    {
        IListArticlesView _viewList { get; set; }
        ICreateArticleView _viewCreate { get; set; }
        IArticleService<IEnumerable<Article>> _service { get; set; }

        public ListArticlesPresenter(IListArticlesView view, IArticleService<IEnumerable<Article>> service)
        {
            _viewList = view;
            _viewList.Presenter = this;
            _service = service;
            
            _viewList.AddClick += _view_AddClick;
            _viewList.EditClick += _view_EditClick;
            _viewList.DeleteClick += _view_DeleteClick;
            _viewList.SearchClick += _view_SearchClick;
            _viewList.ShowAllClick += _view_ShowAllClick;
            _viewList.ViewLoad += _viewList_ViewLoad;
        }

        public ListArticlesPresenter(IListArticlesView view)
        {
            _viewList = view;
            _viewList.Presenter = this;
            _service = new ArticleService();

            _viewList.AddClick += _view_AddClick;
            _viewList.EditClick += _view_EditClick;
            _viewList.DeleteClick += _view_DeleteClick;
            _viewList.SearchClick += _view_SearchClick;
            _viewList.ShowAllClick += _view_ShowAllClick;
            _viewList.ViewLoad += _viewList_ViewLoad;
        }

        private void _viewList_ViewLoad(object sender, EventArgs e)
        {
            //_viewList.Articles = _service.GetArticles();
        }

        private void _view_ShowAllClick(object sender, EventArgs e)
        {
            _viewList.Articles = _service.GetArticles();
            _viewList.ShowSuccess = false;
        }

        private void _view_SearchClick(object sender, EventArgs e)
        {
            this.SearchArticle();
        }

        private void _view_DeleteClick(object sender, EventArgs e)
        {
            var article = _viewList.Articles.ToArray()[_viewList.ItemSelected];
            var result = System.Windows.Forms.MessageBox.Show($"¿Desea eliminar el artículo '{article.Name}'?", "Alerta", System.Windows.Forms.MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.DeleteArticle();
                _viewList.Success = $"Se ha eliminado el artículo '{article.Name}'";
                _viewList.ShowSuccess = true;
            }
            this.LoadArticles();
        }

        private void _view_EditClick(object sender, EventArgs e)
        {
            var article = _viewList.Articles.ToArray()[_viewList.ItemSelected];
            _viewCreate = (ICreateArticleView)(new CreateArticleForm(article)).GetView();
            _viewCreate.ShowView();

            if (!string.IsNullOrEmpty(_viewCreate.Success))
            {
                _viewList.Success = _viewCreate.Success;
                _viewList.ShowSuccess = true;
                _viewList.Articles = _service.GetArticles();
            }
        }

        private void _view_AddClick(object sender, EventArgs e)
        {
            _viewCreate = (ICreateArticleView)(new CreateArticleForm()).GetView();
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
            _viewList.Success = "Se ha eliminado el artículo";
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
                _viewList.Warning = "Por favor seleccione un filtro de busqueda";
                _viewList.ShowWarning = true;
                return;
            }
            else if ((_viewList.IncludeName || _viewList.IncludeDescription) && result.Count() == 0)
            {
                _viewList.Success = "No se encontraron resultados";
                _viewList.ShowSuccess = true;
            }
            else
            {
                _viewList.Success = $"Se encontraron '{result.Count()}' resultados";
                _viewList.ShowSuccess = true;
            }

            _viewList.Articles = result;
        }
    }
}
