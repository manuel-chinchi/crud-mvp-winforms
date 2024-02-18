using PresentationLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views
{
    public interface ICreateCategoryView
    {
        string NameC { get; set; }
        string Error { get; set; }
        string Success { get; set; }
        bool ShowSuccess { get; set; }
        bool ShowError { get; set; }

        CreateCategoryPresenter Presenter { get; set; }
        // TODO: Show y Close deberían ir en IBaseView?
        void ShowView();
        void CloseView();
        event EventHandler AcceptClick;
        event EventHandler CancelClick;
    }
}
