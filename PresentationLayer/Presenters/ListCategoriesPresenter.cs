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

        public void LoadCategories()
        {
            _view.Categories = _service.GetCategories();
        }

        public void DeleteCategory()
        {
            var category = _view.Categories.ToArray()[_view.ItemSelected];
            _view.MsgStatus = "Se ha eliminado la categoría";
            _service.DeleteCategory(category.Id.ToString());
        }
    }
}
