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
    public class CreateCategoryPresenter
    {
        ICreateCategoryView _view { get; set; }
        ICategoryService<IEnumerable<Category>> _service { get; set; }
        
        public CreateCategoryPresenter(ICreateCategoryView view, ICategoryService<IEnumerable<Category>> service)
        {
            _view = view;
            //_view.Presenter = this;
            _service = service;
        }

        public CreateCategoryPresenter(ICreateCategoryView view)
        {
            _view = view;
            _view.AcceptClick += _view_SaveClick;
            _view.Presenter = this;
            _service = new CategoryService();
        }

        private void _view_SaveClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_view.NameC))
            {
                _service.CreateCategory(_view.NameC);
                _view.MsgStatus = "Se ha creado la categoría";
                _view.StatusResult = true;
            }
            else
            {
                _view.Error = "El campo nombre no puede ser vacío";
                _view.ShowError = true;
            }
        }

        public void SaveCategory()
        {
            _service.CreateCategory(_view.NameC);
            _view.MsgStatus = "Se ha creado la categoría";
            _view.StatusResult = true;
        }
    }
}
