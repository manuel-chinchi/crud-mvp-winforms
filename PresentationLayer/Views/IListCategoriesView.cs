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
        int CategorySelected { get; }
        string MsgError { get; set; }
        string MsgStatus { get; set; }
        IEnumerable<Category> Categories { get; set; }
        ListCategoriesPresenter Presenter { get; set; }
    }
}
