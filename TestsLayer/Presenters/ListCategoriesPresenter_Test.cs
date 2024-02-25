using BussinesLayer.Services.Contracts;
using EntityLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.Presenters;
using PresentationLayer.Views.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsLayer.Presenters
{
    [TestClass]
    public class ListCategoriesPresenter_Test
    {
        private readonly CategoryService_2_Test _service = new CategoryService_2_Test();

        [TestMethod]
        public void CategoryToDeleteHasRelatedArticles_Error()
        {
            var view = new ListCategoriesView_Test();
            var presenter = new ListCategoriesPresenter(view, _service);

            view.Show();
            view.ItemSelected = 0;
            view.Delete();
            Assert.AreEqual("No se puede borrar la categoría 'Cat1' porque tiene artículos relacionados", view.Error);
        }

        // required input 'Yes' on popup
        [TestMethod]
        public void CategoryDeleted_Success()
        {
            var view = new ListCategoriesView_Test();
            var presenter = new ListCategoriesPresenter(view, _service);

            view.Show();
            view.ItemSelected = 1;
            view.Delete();
            Assert.AreEqual("Se ha eliminado la categoría 'Cat2'", view.Success);
        }
    }

    public class CategoryService_2_Test : ICategoryService<IEnumerable<Category>>
    {
        public void CreateCategory(string name) { }
        public void DeleteCategory(string id) { }
        public IEnumerable<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category { Name="Cat1",ArticlesRelated=1 },
                new Category { Name="Cat2",ArticlesRelated=0 },
            };
        }
    }

    public class ListCategoriesView_Test : IListCategoriesView
    {
        public int ItemSelected { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public ListCategoriesPresenter Presenter { get; set; }
        public string Error { get; set; }
        public bool ShowError { get; set; }
        public string Success { get; set; }
        public bool ShowSuccess { get; set; }

        public event EventHandler DeleteClick;
        public event EventHandler AddClick;
        public event EventHandler ViewLoad;

        public void Show() => ViewLoad?.Invoke(this, EventArgs.Empty);
        public void Delete() => DeleteClick?.Invoke(this, EventArgs.Empty);
    }
}
