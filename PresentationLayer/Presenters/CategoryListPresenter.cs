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
using static PresentationLayer.Views.Helpers.Enums;

namespace PresentationLayer.Presenters
{
    public class CategoryListPresenter
    {
        ICategoryListView _viewList { get; set; }
        ICategoryCreateView _viewCreate { get; set; }
        ICategoryService<Category> _service { get; set; }

        public CategoryListPresenter(ICategoryListView view, ICategoryService<Category> service)
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

            //if (!string.IsNullOrEmpty(_viewCreate.Success))
            {
                //_viewList.Success = _viewCreate.Success;
                //_viewList.ShowSuccess = _viewCreate.ShowSuccess;
                _viewList.Categories = _service.GetCategories();
            }
        }

        private void _view_DeleteClick(object sender, EventArgs e)
        {
            var indices = _viewList.SelectedIndices;
            var categories = _viewList
                .Categories
                .Where((item, index) => indices.Contains(index))
                .ToList();

            if (categories.Count > 0)
            {
                // filtro solo las categorias que no tengan articulos relacionados
                var filter = categories.Where(item => item.ArticlesRelated == 0).ToList();
                if (filter.Count != categories.Count)
                {
                    _viewList.Alert("Categories that contain articles cannot be deleted", "Info", AlertButtons.OK);
                    return;
                }

                AlertResult result = _viewList.Alert("You want to delete the selected items?", "Alert", AlertButtons.YesNo);

                if (result == AlertResult.Yes)
                {
                    int count = categories.Count;

                    DeleteCategories(categories);
                    //_viewList.Success = $"{count} categories were deleted";
                    //_viewList.ShowSuccess = true;
                    LoadCategories();
                }
            }
            else
            {
                _viewList.Alert("Select an category", "Info", AlertButtons.OK);
            }
        }

        private void DeleteCategories(List<Category> categories)
        {
            foreach (var category in categories)
            {
                _service.DeleteCategory(category.Id.ToString());
            }
        }

        private void LoadCategories()
        {
            _viewList.Categories = _service.GetCategories();
        }
    }
}
