using System;
using System.Windows.Forms;

namespace PresentacionLayer.Views.Contracts
{
    public interface IArticleView
    {
        string Id { get; set; }
        string NameA { get; set; }
        string Description { get; set; }
        string Brand { get; set; }
        string Stock { get; set; }
        int IncludeName { get; set; }
        int IncludeDescription { get; set; }
        int IncludeBrand { get; set; }
        string Search { get; set; }
        bool IsEdit { get; set; }
        int SelectedRows { get; }

        event EventHandler LoadArticles;
        event EventHandler SaveArticle;
        event EventHandler EditArticle;
        event EventHandler DeleteArticle;
        event EventHandler SearchArticle;

        BindingSource DataSource { get; set; }
    }
}