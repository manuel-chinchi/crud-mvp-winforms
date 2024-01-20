using BussinesLayer.Services;
using EntityLayer;
using EntityLayer.Models;
using PresentacionLayer.Presenters.Contracts;
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
    public class ArticlePresenter : IArticlePresenter
    {
        public IArticleView view { get; set; }
        public IArticleService<SortableBindingList<Article>> service { get; set; }
        public BindingSource bindingSource = new BindingSource();
        //public IEnumerable<Article> articles;

        public ArticlePresenter(IArticleView view, IArticleService<SortableBindingList<Article>> service)
        {
            // dependency inyection
            this.view = view;
            this.service = service;
            // events
            this.view.LoadArticles += View_LoadArticles;
            this.view.SaveArticle += View_SaveArticle;
            this.view.EditArticle += View_EditArticleEvent;
            this.view.DeleteArticle += View_DeleteArticleEvent;
            this.view.SearchArticle += View_SearchArticle;
            // binding data
            bindingSource.DataSource = service.GetArticles();
            this.view.SetBindingSource(bindingSource);
        }

        private void View_SearchArticle(object sender, EventArgs e)
        {
            var result = service.SearchArticle(view.IncludeName, view.IncludeDescription, view.IncludeBrand, view.Search);
            if ((view.IncludeName != 0 || view.IncludeDescription != 0 || view.IncludeBrand != 0) && result.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados");
            }
            bindingSource.DataSource = result;
            view.SetBindingSource(bindingSource);
        }

        private void View_DeleteArticleEvent(object sender, EventArgs e)
        {
            service.DeleteArticle(view.Id);
            //bindingSource.DataSource = service.GetArticles(); // con esto actualiza la grilla antes de mostrar el msgbox 
            MessageBox.Show("Se ha eliminado el artículo");
            bindingSource.DataSource = service.GetArticles();
            view.SetBindingSource(bindingSource);
        }

        private void View_EditArticleEvent(object sender, EventArgs e)
        {
            if (view.SelectedRows == 1)
            {
                var article = (Article)view.GetBindingSource().Current;
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
                service.InsertArticle(view.NameA, view.Description, view.Brand, view.Stock);
                MessageBox.Show("Se ha agregado el artículo");
                View_LoadArticles(sender, e);
                ClearArticleInputs();
            }
            else
            {
                service.UpdateArticle(view.NameA, view.Description, view.Brand, view.Stock, view.Id);
                MessageBox.Show("Se ha actualizado el artículo");
                View_LoadArticles(sender, e);
                ClearArticleInputs();
                view.IsEdit = false;
            }
        }

        private void View_LoadArticles(object sender, EventArgs e)
        {
            bindingSource.DataSource = service.GetArticles();
            view.SetBindingSource(bindingSource);
        }

        void ClearArticleInputs()
        {
            view.NameA = "";
            view.Description = "";
            view.Brand = "";
            view.Stock = "";
        }
    }
}
