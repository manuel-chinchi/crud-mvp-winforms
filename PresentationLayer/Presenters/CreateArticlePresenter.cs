using BussinesLayer.Services;
using EntityLayer.Models;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Presenters
{
    public class CreateArticlePresenter
    {
        ICreateArticleView _view { get; set; }
        IArticleService<IEnumerable<Article>> _service { get; set; }

        public CreateArticlePresenter(ICreateArticleView view, IArticleService<IEnumerable<Article>> service)
        {
            _view = view;
            _view.Presenter = this;
            _service = service;
        }

        public void LoadArticleFromEdit(Article article)
        {
            _view.Id = article.Id.ToString();
            _view.NameA = article.Name;
            _view.Description = article.Description;
            _view.Stock = article.Stock.ToString();
        }

        public void AddArticle(Article article)
        {
            _service.CreateArticle(article.Name, article.Description, article.Stock.ToString());
        }

        public void ActivateEditMode()
        {
            _view.IsEditMode = true;
        }

        public void SaveArticle()
        {
            _service.CreateArticle(_view.NameA, _view.Description, _view.Stock.ToString());
            _view.Close();
        }

        public void UpdateArticle()
        {
            _service.UpdateArticle(_view.NameA, _view.Description, _view.Stock.ToString(), _view.Id.ToString());
            _view.Close();
        }
    }
}
