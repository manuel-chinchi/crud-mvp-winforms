using BussinesLayer.Services;
using EntityLayer.Models;
using PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class ListCategoriesPresenter
    {
        IListCategoriesView _view { get; set; }
        ICategoryService<IEnumerable<Category>> _service { get; set; }

        public ListCategoriesPresenter(IListCategoriesView view, ICategoryService<IEnumerable<Category>> service)
        {
            _view = view;
            _service = service;
        }

        public ListCategoriesPresenter(IListCategoriesView view)
        {
            _view = view;
            _view.DeleteClick += _view_DeleteClick;
            _view.Presenter = this;
            _service = new CategoryService();
        }

        private void _view_DeleteClick(object sender, EventArgs e)
        {
            var category = _view.Categories.ToArray()[_view.ItemSelected];
            if (category.ArticlesRelated == 0)
            {
                _service.DeleteCategory(category.Id.ToString());
                _view.Categories = _service.GetCategories();
                _view.Success = $"Se ha eliminado la categoría '{category.Name}'";
                _view.ShowSuccess = true;
            }
            else
            {
                _view.Error = $"No se puede borrar la categoría '{category.Name}' ya que tiene artículos relacionados";
                _view.ShowError = true;
            }
        }

        public void LoadCategories()
        {
            _view.Categories = _service.GetCategories();
        }

        public void DeleteCategory()
        {
            var category = _view.Categories.ToArray()[_view.ItemSelected];
            _view.Success = "Se ha eliminado la categoría";
            _service.DeleteCategory(category.Id.ToString());
        }
    }
}
