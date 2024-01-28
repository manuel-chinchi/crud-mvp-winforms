using EntityLayer.Models;
using PresentationLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views
{
    public interface IListArticlesView
    {
        int ItemSelected { get; }
        bool IncludeName { get; set; }
        bool IncludeDescription { get; set; }
        string Search { get; set; }
        string MsgError { get; set; }
        string MsgStatus { get; set; }
        IEnumerable<Article> Articles { get; set; }
        ListArticlesPresenter Presenter { get; set; }
    }
}
