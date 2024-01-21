using BussinesLayer.Services.Contracts;
using EntityLayer;
using EntityLayer.Models;
using EntityLayer.Models.Utils;
using PresentacionLayer.Views.Contracts;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionLayer.Presenters
{
    public class ArticlePresenter
    {
        public IArticleView view { get; set; }
        public IArticleService<IEnumerable<Article>> service { get; set; }

        public ArticlePresenter(IArticleView view, IArticleService<IEnumerable<Article>> service)
        {
            this.view = view;
            this.service = service;

            this.view.LoadArticles += View_LoadArticles;
            this.view.SaveArticle += View_SaveArticle;
            this.view.EditArticle += View_EditArticleEvent;
            this.view.DeleteArticle += View_DeleteArticleEvent;
            this.view.SearchArticle += View_SearchArticle;
        }

        private void View_SearchArticle(object sender, EventArgs e)
        {
            var result = service.SearchArticle(view.IncludeName, view.IncludeDescription, view.IncludeBrand, view.Search);
            if ((view.IncludeName != 0 || view.IncludeDescription != 0 || view.IncludeBrand != 0) && result.Count() == 0)
            {
                MessageBox.Show("No se encontraron resultados");
            }
            RefreshArticleList(result);
        }

        private void View_DeleteArticleEvent(object sender, EventArgs e)
        {
            service.DeleteArticle(view.Id);
            //bindingSource.DataSource = service.GetArticles(); // con esto actualiza la grilla antes de mostrar el msgbox 
            MessageBox.Show("Se ha eliminado el artículo");
            RefreshArticleList();
        }

        private void View_EditArticleEvent(object sender, EventArgs e)
        {
            if (view.SelectedRows == 1)
            {
                var article = (Article)view.DataSource.Current;
                view.IsEdit = true;
                view.NameA = article.Name;
                view.Description = article.Description;
                view.Brand = article.Brand;
                view.Stock = article.Stock.ToString();
                view.Id = article.Id.ToString();
            }
            else if (view.SelectedRows == 0)
            {
                MessageBox.Show("Seleccione al menos 1 fila");
            }
            else
            {
                MessageBox.Show("Seleccione 1 sola fila");
            }
        }

        private void View_SaveArticle(object sender, EventArgs e)
        {
            if (view.IsEdit == false)
            {
                service.CreateArticle(view.NameA, view.Description, view.Brand, view.Stock);
                MessageBox.Show("Se ha agregado el artículo");
                RefreshArticleList();
                ClearArticleForm();
            }
            else
            {
                service.UpdateArticle(view.NameA, view.Description, view.Brand, view.Stock, view.Id);
                MessageBox.Show("Se ha actualizado el artículo");
                View_LoadArticles(sender, e);
                ClearArticleForm();
                view.IsEdit = false;
            }
        }

        private void View_LoadArticles(object sender, EventArgs e)
        {
            RefreshArticleList();
        }

        void ClearArticleForm()
        {
            view.NameA = "";
            view.Description = "";
            view.Brand = "";
            view.Stock = "";
        }

        void RefreshArticleList(IEnumerable<Article> data = null)
        {
            BindingSource bindingSource = new BindingSource();
            if (data != null)
            {
                bindingSource.DataSource = new SortableBindingList<Article>(data.ToList());
            }
            else
            {
                bindingSource.DataSource = new SortableBindingList<Article>(service.GetArticles().ToList());
            }
            view.DataSource = bindingSource;
        }
    }
}
