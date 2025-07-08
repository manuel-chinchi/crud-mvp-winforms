using BussinesLayer.Services;
using BussinesLayer.Services.Contracts;
using Core.Services;
using Core.Services.Contracts;
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
        ILanguageService languageService { get; set; } = new LanguageService();

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

            this.languageService.SetLanguage("en");
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
            string msg="";
            var indices = _viewList.SelectedIndices;
            var categories = _viewList.Categories.Where((item, index) => indices.Contains(index)).ToList();

            if (categories.Count > 0)
            {
                // filtro solo las categorias que no tengan articulos relacionados
                var filter = categories.Where(item => item.ArticlesRelated == 0).ToList();
                if (filter.Count != categories.Count)
                {
                    // AlertCategoryDeleted
                    //msg = languageService.GetString(LanguageService.Messages.ErrorOnDeleteCategory) ?? "0";
                    System.Windows.Forms.MessageBox.Show(msg);
                    return;
                }

                // AskDeleteSelectedItems
                //msg = languageService.GetString(LanguageService.Messages.QuestionConfirmDeleteItem) ?? "0";
                var result = System.Windows.Forms.MessageBox.Show(msg, "Alert", System.Windows.Forms.MessageBoxButtons.YesNo);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    int count = categories.Count;

                    DeleteCategories(categories);
                    // OkCategoriesDeleted
                    //msg = languageService.GetString(LanguageService.Messages.SuccessCategoriesDeleted) ?? "0";
                    _viewList.Success = string.Format(msg, count);
                    _viewList.ShowSuccess = true;
                    LoadCategories();
                }
            }
            else
            {
                // AlertSelectACategory
                //msg = languageService.GetString(LanguageService.Messages.WarningSelectCategory) ?? "0";
                System.Windows.Forms.MessageBox.Show(msg);
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
