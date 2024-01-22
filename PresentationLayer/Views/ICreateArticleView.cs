using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views
{
    public interface ICreateArticleView
    {
        //Article article { get; set; }
        string Id { get; set; }
        string NameA { get; set; }
        string Description { get; set; }
        string Stock { get; set; }

        bool IsEditMode { get; set; }

        void Close();

        Presenters.CreateArticlePresenter Presenter { get; set; }
    }
}
