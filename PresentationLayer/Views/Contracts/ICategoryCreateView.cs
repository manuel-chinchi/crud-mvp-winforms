using PresentationLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views.Contracts
{
    public interface ICategoryCreateView : IBaseView
    {
        string NameC { get; set; }
        CategoryCreatePresenter Presenter { get; set; }

        event EventHandler AcceptClick;
        event EventHandler CancelClick;

        void ShowView();
        void CloseView();
    }
}
