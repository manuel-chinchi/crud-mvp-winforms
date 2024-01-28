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

        public void SaveCategory()
        {
            _service.CreateCategory(_view.NameC);
            _view.MsgStatus = "Se ha creado la categoría";
            _view.StatusResult = true;
        }
    }
}
