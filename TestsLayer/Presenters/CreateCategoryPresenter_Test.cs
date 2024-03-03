using BussinesLayer.Services.Contracts;
using EntityLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.Presenters;
using PresentationLayer.Views.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestsLayer.Presenters
{
    [TestClass]
    public class CreateCategoryPresenter_Test
    {
        private readonly CategoryService_Test _service = new CategoryService_Test();

        [TestMethod]
        public void CategoryNameIsEmpty_Error()
        {
            var view = new CreateCategoryView_Test();
            var presenter = new CategoryCreatePresenter(view, _service);

            view.NameC = "";
            view.Accept();
            Assert.AreEqual(expected: "The 'Name' field cannot be empty", actual: view.Error);
        }

        // TODO Agregar validacion para evitar caracteres no validos
        [TestMethod]
        public void CategoryNameIsNotValid_Error()
        {
            var view = new CreateCategoryView_Test();
            var presenter = new CategoryCreatePresenter(view, _service);

            view.NameC = "Rop@";
            view.Accept();
            Assert.AreEqual("El nombre de categoría no es válido", view.Error);
        }

        // TODO Agregar logica, revisar stored procedure
        [TestMethod]
        public void CategoryNameAlreadyExists_Error()
        {
            var view = new CreateCategoryView_Test();
            var service = new CategoryService_Test();
            var presenter = new CategoryCreatePresenter(view, service);

            view.NameC = "Cat1";
            view.Accept();
            Assert.AreEqual(expected: "La categoría 'Cat1' ya existe", actual: view.Error);
        }

        [TestMethod]
        public void CategoryNameValid_Success()
        {
            var view = new CreateCategoryView_Test();
            var presenter = new CategoryCreatePresenter(view, _service);

            view.NameC = "Cat2";
            view.Accept();
            Assert.AreEqual("The category 'Cat2' has been created", view.Success);
        }
    }

    public class CategoryService_Test : ICategoryService<IEnumerable<Category>>
    {
        public void CreateCategory(string name) { }
        public void DeleteCategory(string id) { }
        public IEnumerable<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category { Name = "Cat1" },
                new Category { Name = "Cat2" }
            };
        }
    }

    public class CreateCategoryView_Test : ICategoryCreateView
    {
        public string NameC { get; set; }
        public string Error { get; set; }
        public string Success { get; set; }
        public bool ShowSuccess { get; set; }
        public CategoryCreatePresenter Presenter { get; set; }
        public bool ShowError { get; set; }

        public event EventHandler AcceptClick;
        public event EventHandler CancelClick;

        public void CloseView() { }
        public void Accept() => AcceptClick?.Invoke(this, EventArgs.Empty);
        public void Cancel() => CancelClick?.Invoke(this, EventArgs.Empty);
        public void ShowView() { }
    }
}
