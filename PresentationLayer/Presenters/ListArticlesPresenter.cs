using BussinesLayer.Services;
using EntityLayer.Models;
using PresentationLayer.Forms;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class ListArticlesPresenter
    {
        IListArticlesView _view { get; set; }
        ICreateArticleView _viewCreateArticle { get; set; }
        IArticleService<IEnumerable<Article>> _service { get; set; }

        public ListArticlesPresenter(IListArticlesView view, IArticleService<IEnumerable<Article>> service)
        {
            _view = view;
            _view.AddClick += _view_AddClick;
            _view.EditClick += _view_EditClick;
            _view.DeleteClick += _view_DeleteClick;
            _view.SearchClick += _view_SearchClick;
            _view.ShowAllClick += _view_ShowAllClick;
            _view.Presenter = this;
            _service = service;
        }

        private void _view_ShowAllClick(object sender, EventArgs e)
        {
            _view.Articles = _service.GetArticles();
        }

        private void _view_SearchClick(object sender, EventArgs e)
        {
            this.SearchArticle();
            //if (!string.IsNullOrEmpty(_view.Error))
            //{
            //    System.Windows.Forms.MessageBox.Show(_view.Error);
            //}
        }

        private void _view_DeleteClick(object sender, EventArgs e)
        {
            var article = _view.Articles.ToArray()[_view.ItemSelected];
            var result = System.Windows.Forms.MessageBox.Show($"¿Desea eliminar el artículo {article.Name}?", "Alerta", System.Windows.Forms.MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.DeleteArticle();
            }
            this.LoadArticles();
        }

        private void _view_EditClick(object sender, EventArgs e)
        {
            var article = _view.Articles.ToArray()[_view.ItemSelected];
            _viewCreateArticle = (ICreateArticleView)(new CreateArticleForm(article)).GetView();
            _viewCreateArticle.ShowView();

            if (!string.IsNullOrEmpty(_viewCreateArticle.Success))
            {
                _view.Success = _viewCreateArticle.Success;
                _view.ShowSuccess = true;
                _view.Articles = _service.GetArticles();
            }
        }

        private void _view_AddClick(object sender, EventArgs e)
        {
            _viewCreateArticle = (ICreateArticleView)(new CreateArticleForm()).GetView();
            _viewCreateArticle.ShowView();

            if (!string.IsNullOrEmpty(_viewCreateArticle.Success))
            {
                _view.Success = _viewCreateArticle.Success;
                _view.ShowSuccess = true;
                _view.Articles = _service.GetArticles();
            }
        }

        public void DeleteArticle()
        {
            var article = _view.Articles.ToList()[_view.ItemSelected];
            _view.Success = "Se ha eliminado el artículo";
            _view.ShowSuccess = true;
            _service.DeleteArticle(article.Id.ToString());
        }

        public void LoadArticles()
        {
            _view.Articles = _service.GetArticles();
            _view.IncludeName = false;
            _view.IncludeDescription = false;
        }

        public Article GetArticleSelected()
        {
            return _view.Articles.ToArray()[_view.ItemSelected];
        }

        public void SearchArticle()
        {
            var result = _service.SearchArticle(Convert.ToInt32(_view.IncludeName), Convert.ToInt32(_view.IncludeDescription), _view.Search);
            _view.Error = "";

            if (_view.IncludeName == false && _view.IncludeDescription == false)
            {
                _view.Warning = "Por favor seleccione un filtro de busqueda";
                _view.ShowWarning = true;
                return;
            }
            else if ((_view.IncludeName || _view.IncludeDescription) && result.Count() == 0)
            {
                _view.Success = "Nos se encontraron resultados";
                _view.ShowSuccess = true;
            }
            else
            {
                _view.Success = $"Se encontraron '{result.Count()}' resultados";
                _view.ShowSuccess = true;
            }

            _view.Articles = result;
        }
    }
}
