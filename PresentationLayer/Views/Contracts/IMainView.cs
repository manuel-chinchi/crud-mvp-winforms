using PresentationLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views.Contracts
{
    public interface IMainView : IBaseView
    {
        MainPresenter Presenter { get; set; }

        event EventHandler ArticlesClick;
        event EventHandler CategoriesClick;
        event EventHandler ReportsClick;
    }
}
