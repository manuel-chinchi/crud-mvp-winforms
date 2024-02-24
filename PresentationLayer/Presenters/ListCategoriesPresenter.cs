using BussinesLayer.Services;
using BussinesLayer.Services.Contracts;
using EntityLayer.Models;
using PresentationLayer.Forms;
using PresentationLayer.Views.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class ListCategoriesPresenter
    {
        IListCategoriesView _viewList { get; set; }
        ICreateCategoryView _viewCreate { get; set; }
        ICategoryService<IEnumerable<Category>> _service { get; set; }

        public ListCategoriesPresenter(IListCategoriesView view, ICategoryService<IEnumerable<Category>> service)
        {
            _viewList = view;
            _viewList.Presenter = this;
            _service = service;

            _viewList.DeleteClick += _view_DeleteClick;
            _viewList.AddClick += _view_AddClick;
            _viewList.ViewLoad += _view_ViewLoad;
        }

        public ListCategoriesPresenter(IListCategoriesView view)
        {
            _viewList = view;
            _viewList.Presenter = this;
            _service = new CategoryService();
            
            _viewList.DeleteClick += _view_DeleteClick;
            _viewList.AddClick += _view_AddClick;
            _viewList.ViewLoad += _view_ViewLoad;
        }

        private void _view_ViewLoad(object sender, EventArgs e)
        {
            _viewList.Categories = _service.GetCategories();
        }

        private void _view_AddClick(object sender, EventArgs e)
        {
            // TODO: Revisar como mejorar esto. 
            _viewCreate = (ICreateCategoryView)new CreateCategoryForm().GetView();
            _viewCreate.ShowView();

            if (!string.IsNullOrEmpty(_viewCreate.Success))
            {
                _viewList.Success = _viewCreate.Success;
                _viewList.ShowSuccess = _viewCreate.ShowSuccess;
                _viewList.Categories = _service.GetCategories(); // refresh datagridview categories
            }
        }

        private void _view_DeleteClick(object sender, EventArgs e)
        {
            var category = _viewList.Categories.ToArray()[_viewList.ItemSelected];
            if (category.ArticlesRelated == 0)
            {
                var result = System.Windows.Forms.MessageBox.Show($"¿Desea eliminar la categoría '{category.Name}'?", "", System.Windows.Forms.MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    _service.DeleteCategory(category.Id.ToString());
                    _viewList.Categories = _service.GetCategories();
                    _viewList.Success = $"Se ha eliminado la categoría '{category.Name}'";
                    _viewList.ShowSuccess = true;
                }
            }
            else
            {
                _viewList.Error = $"No se puede borrar la categoría '{category.Name}' porque tiene artículos relacionados";
                _viewList.ShowError = true;
            }
        }
    }
}
