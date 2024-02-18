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
            _view.Presenter = this;
            _service = service;
        }

        private void _view_AddClick(object sender, EventArgs e)
        {
            //var frm = new CreateArticleForm();
            //frm.ShowDialog();

            _viewCreateArticle = (ICreateArticleView)(new CreateArticleForm()).GetView();
            _viewCreateArticle.ShowView();

            if (!string.IsNullOrEmpty(_viewCreateArticle.Success))
            {
                System.Windows.Forms.MessageBox.Show(_viewCreateArticle.Success); 
                _view.Articles = _service.GetArticles();
            }
        }

        public void DeleteArticle()
        {
            var article = _view.Articles.ToList()[_view.ItemSelected];
            _view.MsgStatus = "Se ha eliminado el artículo";
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
            _view.MsgError = "";

            if (_view.IncludeName == false && _view.IncludeDescription == false)
            {
                _view.MsgError = "Por favor seleccione un filtro de busqueda";
                return;
            }
            else if ((_view.IncludeName || _view.IncludeDescription) && result.Count() == 0)
            {
                _view.MsgError = "Nos se encontraron resultados";
            }

            _view.Articles = result;
        }

        public string GetError() { return _view.MsgError; }

        public string GetStatus() { return _view.MsgStatus; }
    }
}
