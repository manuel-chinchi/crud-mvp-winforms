using EntityLayer.Models;
using PresentationLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views
{
    public interface ICreateArticleView
    {
        string Id { get; set; }
        string NameA { get; set; }
        string Description { get; set; }
        string Stock { get; set; }
        string Category { get; set; }
        bool IsEditMode { get; set; }
        string Error { get; set; }
        string Success { get; set; }
        bool ShowSuccess { get; set; }
        bool ShowError { get; set; }

        IEnumerable<Category> Categories { get; set; }
        int ItemSelected { get; set; }
        CreateArticlePresenter Presenter { get; set; }
        void Close();
        void CloseView();
        void ShowView();

        event EventHandler AcceptClick;
        event EventHandler CancelClick;
    }
}
