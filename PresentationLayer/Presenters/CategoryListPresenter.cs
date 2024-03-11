using BussinesLayer.Services;
using BussinesLayer.Services.Contracts;
using EntityLayer.Models;
using PresentationLayer.Views;
using PresentationLayer.Views.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class CategoryListPresenter
    {
        ICategoryListView _viewList { get; set; }
        ICategoryCreateView _viewCreate { get; set; }
        ICategoryService<IEnumerable<Category>> _service { get; set; }

        public CategoryListPresenter(ICategoryListView view, ICategoryService<IEnumerable<Category>> service)
        {
            _viewList = view;
            _viewList.Presenter = this;
            // TODO review
            //_viewCreate = new CategoryCreateView();
            _service = service;

            _viewList.DeleteClick += _view_DeleteClick;
            _viewList.AddClick += _view_AddClick;
            _viewList.ViewLoad += _view_ViewLoad;
        }

        public CategoryListPresenter(ICategoryListView view)
        {
            _viewList = view;
            _viewList.Presenter = this;
            // TODO review
            //_viewCreate = new CategoryCreateView();
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
            _viewCreate = new CategoryCreateView();
            _viewCreate.ShowView();

            if (!string.IsNullOrEmpty(_viewCreate.Success))
            {
                _viewList.Success = _viewCreate.Success;
                _viewList.ShowSuccess = _viewCreate.ShowSuccess;
                _viewList.Categories = _service.GetCategories();
            }
        }

        private void _view_DeleteClick(object sender, EventArgs e)
        {
            var category = _viewList.Categories.ToArray()[_viewList.ItemSelected];
            if (category.ArticlesRelated == 0)
            {
                var result = System.Windows.Forms.MessageBox.Show($"Do you want to delete the category '{category.Name}'?", "Alert", System.Windows.Forms.MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    _service.DeleteCategory(category.Id.ToString());
                    _viewList.Categories = _service.GetCategories();
                    _viewList.Success = $"The category '{category.Name}' has been removed";
                    _viewList.ShowSuccess = true;
                }
            }
            else
            {
                _viewList.Error = $"Cannot delete category '{category.Name}' because it has related articles";
                _viewList.ShowError = true;
            }
        }
    }
}
