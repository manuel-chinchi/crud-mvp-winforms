using BussinesLayer.Services;
using BussinesLayer.Services.Contracts;
using EntityLayer.Models;
using PresentationLayer.Views.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class CategoryCreatePresenter
    {
        ICategoryCreateView _viewCreate { get; set; }
        ICategoryService<IEnumerable<Category>> _service { get; set; }
        
        public CategoryCreatePresenter(ICategoryCreateView view, ICategoryService<IEnumerable<Category>> service)
        {
            _viewCreate = view;
            _viewCreate.Presenter = this;
            _service = service;

            _viewCreate.AcceptClick += _viewCreate_AcceptClick;
            _viewCreate.CancelClick += _viewCreate_CancelClick;
        }

        public CategoryCreatePresenter(ICategoryCreateView view)
        {
            _viewCreate = view;
            _viewCreate.Presenter = this;
            _service = new CategoryService();

            _viewCreate.AcceptClick += _viewCreate_AcceptClick;
            _viewCreate.CancelClick += _viewCreate_CancelClick;
        }

        private void _viewCreate_CancelClick(object sender, EventArgs e)
        {
            _viewCreate.CloseView();
        }

        private void _viewCreate_AcceptClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_viewCreate.NameC))
            {
                _service.CreateCategory(_viewCreate.NameC);
                _viewCreate.Success = $"The category '{_viewCreate.NameC}' has been created";
                _viewCreate.ShowSuccess = true;
                _viewCreate.CloseView();
            }
            else
            {
                _viewCreate.Error = "The 'Name' field cannot be empty";
                _viewCreate.ShowError = true;
            }
        }

        public void SaveCategory()
        {
            _service.CreateCategory(_viewCreate.NameC);
            _viewCreate.Success = "Category has been created";
            _viewCreate.ShowSuccess = true;
        }
    }
}
