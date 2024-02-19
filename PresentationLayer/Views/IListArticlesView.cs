using EntityLayer.Models;
using PresentationLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views
{
    public interface IListArticlesView : IBaseView
    {
        int ItemSelected { get; }
        bool IncludeName { get; set; }
        bool IncludeDescription { get; set; }
        string Search { get; set; }
        IEnumerable<Article> Articles { get; set; }
        ListArticlesPresenter Presenter { get; set; }

        event EventHandler AddClick;
        event EventHandler EditClick;
        event EventHandler DeleteClick;
        event EventHandler SearchAllClick;
    }
}
