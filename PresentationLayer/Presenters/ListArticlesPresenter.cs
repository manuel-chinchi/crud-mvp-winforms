using BussinesLayer.Services;
using EntityLayer.Models;
using PresentationLayer.Forms;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Presenters
{
    public class ListArticlesPresenter
    {
        IListArticlesView _view { get; set; }
        IArticleService<IEnumerable<Article>> _service { get; set; }

        public ListArticlesPresenter(IListArticlesView view, IArticleService<IEnumerable<Article>> service)
        {
            _view = view;
            _view.Presenter = this;
            _service = service;
        }

        //public void AddArticle(Article article)
        //{
        //    var frm = new CreateArticleForm();
        //    frm.ShowDialog();
        //}

        //public void EditArticle(int id)
        //{
        //    var frm = new CreateArticleForm(true);
        //    frm.ShowDialog();
        //}

        public void DeleteArticle()//ok
        {
            var article = _view.Articles.ToList()[_view.ArticleSelected];
            _service.DeleteArticle(article.Id.ToString());
            //_view.Articles = _service.GetArticles();
        }

        public void LoadArticles()//ok
        {
            _view.Articles = _service.GetArticles();
        }

        public Article GetArticleSelected()
        {
            return _view.Articles.ToArray()[_view.ArticleSelected];
        }
    }
}
