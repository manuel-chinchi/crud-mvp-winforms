using EntityLayer.Models;
using PresentationLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IListArticlesView
    {
        IEnumerable<Article> Articles { get; set; }

        int ArticleSelected { get; }

        bool IncludeName { get; set; }

        bool IncludeDescription { get; set; }

        string Search { get; set; }

        ListArticlesPresenter Presenter { get; set; }

        string MsgError { get; set; }
        string MsgStatus { get; set; }
    }
}
