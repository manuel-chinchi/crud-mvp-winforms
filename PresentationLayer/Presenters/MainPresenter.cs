using PresentationLayer.Views;
using PresentationLayer.Views.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class MainPresenter
    {
        IMainView _mainView;
        IArticleListView _articleListView;
        ICategoryListView _categoryListView;
        IReportView _reportsView;

        public MainPresenter(IMainView mainView, IArticleListView articleListView, ICategoryListView categoryListView, IReportView reportsView)
        {
            _mainView = mainView;
            _mainView.Presenter = this;
            _articleListView = articleListView;
            _categoryListView = categoryListView;
            _reportsView = reportsView;

            _mainView.ArticlesClick += _mainView_ArticlesClick;
            _mainView.CategoriesClick += _mainView_CategoriesClick;
            _mainView.ReportsClick += _mainView_ReportsClick;
        }

        public MainPresenter(IMainView view)
        {
            _mainView = view;
            _mainView.Presenter = this;
            _articleListView = new ArticleListView();
            _categoryListView = new CategoryListView();
            _reportsView = new ReportView();

            _mainView.ArticlesClick += _mainView_ArticlesClick;
            _mainView.CategoriesClick += _mainView_CategoriesClick;
            _mainView.ReportsClick += _mainView_ReportsClick;
        }

        private void _mainView_ArticlesClick(object sender, EventArgs e)
        {
            _articleListView.ShowView();
        }

        private void _mainView_CategoriesClick(object sender, EventArgs e)
        {
            _categoryListView.ShowView();
        }

        private void _mainView_ReportsClick(object sender, EventArgs e)
        {
        }
    }
}
