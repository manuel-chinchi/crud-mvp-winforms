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

        ListArticlesPresenter Presenter { get; set; }
    }
}
