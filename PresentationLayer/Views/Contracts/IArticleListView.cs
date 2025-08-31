using EntityLayer.Models;
using PresentationLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views.Contracts
{
    public interface IArticleListView : IBaseView
    {
        List<int> SelectedIndices { get; }
        bool FilterIncludeName { get; set; }
        bool FilterIncludeDescription { get; set; }
        string Search { get; set; }
        IEnumerable<Article> Articles { get; set; }
        ArticleListPresenter Presenter { get; set; }

        event EventHandler AddClick;
        event EventHandler EditClick;
        event EventHandler DeleteClick;
        event EventHandler SearchClick;
        event EventHandler ShowAllClick;
        event EventHandler ViewLoad;

        //string Warning { get; set; }
        //bool ShowWarning { get; set; }

        void ShowView();
        void CloseView();
    }
}
