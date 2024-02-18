using EntityLayer.Models;
using PresentationLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views
{
    public interface IListCategoriesView
    {
        int ItemSelected { get; }
        string Error { get; set; }
        bool ShowError { get; set; }
        string Success { get; set; }
        bool ShowSuccess { get; set; }
        IEnumerable<Category> Categories { get; set; }
        ListCategoriesPresenter Presenter { get; set; }

        event EventHandler DeleteClick;
    }
}
