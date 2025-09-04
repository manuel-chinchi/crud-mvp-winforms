using BussinesLayer.Services;
using BussinesLayer.Services.Contracts;
using EntityLayer.Models;
using PresentationLayer.Presenters.Helpers;
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
        IMainView _viewMain;
        IArticleListView _viewArticleList;
        ICategoryListView _viewCategoryList;
        IReportView _viewReports;
        IArticleService<Article> _articleService { get; set; }
        ICategoryService<Category> _categoryService { get; set; }

        public MainPresenter(
            IMainView view, 
            IArticleListView viewArticleList, 
            ICategoryListView viewCategoryList, 
            IReportView viewReports)
        {
            _viewMain = view;
            _viewMain.Presenter = this;
            _viewArticleList = viewArticleList;
            _viewCategoryList = viewCategoryList;
            _viewReports = viewReports;

            _viewMain.ArticlesClick += _viewMain_ArticlesClick;
            _viewMain.CategoriesClick += _viewMain_CategoriesClick;
            _viewMain.ReportsClick += _viewMain_ReportsClick;

            _articleService = new ArticleService();
            _categoryService = new CategoryService();
        }

        public MainPresenter(IMainView view)
        {
            _viewMain = view;
            _viewMain.Presenter = this;
            _viewArticleList = new ArticleListView();
            _viewCategoryList = new CategoryListView();
            _viewReports = new ReportView();

            _viewMain.ArticlesClick += _viewMain_ArticlesClick;
            _viewMain.CategoriesClick += _viewMain_CategoriesClick;
            _viewMain.ReportsClick += _viewMain_ReportsClick;

            _articleService = new ArticleService();
            _categoryService = new CategoryService();
        }

        private void _viewMain_ArticlesClick(object sender, EventArgs e)
        {
            _viewArticleList.ShowView();
        }

        private void _viewMain_CategoriesClick(object sender, EventArgs e)
        {
            _viewCategoryList.ShowView();
        }

        private void _viewMain_ReportsClick(object sender, EventArgs e)
        {
            this.LoadDefaultReport();
            _viewReports.ShowView();
        }

        public void LoadDefaultReport()
        {
            int index = _viewReports.Reports.ToList().IndexOf((string)_viewReports.SelectedItem);
            object lr = null;
            switch (index)
            {
                case (int)ReportResource.ArticlesReport:
                    {
                        var articles = _articleService.GetArticles();
                        lr = ReportHelper.CreateLocalReport(
                            ReportFiles.ARTICLESREPORT_RESX,
                           "dsArticles", articles);
                    }
                    break;
                case (int)ReportResource.ArticlesReportV2:
                    {
                        var articles = _articleService.GetArticles();
                        lr = ReportHelper.CreateLocalReport(
                           ReportFiles.ARTICLESREPORTV2_RESX,
                           "dsArticles", articles);
                    }
                    break;
                case (int)ReportResource.CategoriesReport:
                    {
                        var categories = _categoryService.GetCategories();
                        lr = ReportHelper.CreateLocalReport(
                           ReportFiles.CATEGORIESREPORT_RESX,
                           "dsCategories",
                           categories);
                    }
                    break;
                case (int)ReportResource.CategoriesReportV2:
                    {
                        var categories = _categoryService.GetCategories();
                        var articles = _articleService.GetArticles();
                        lr = ReportHelper.CreateLocalReport(ReportFiles.CATEGORIESREPORTV2_RESX);
                        ReportHelper.AddDataSource(lr, "dsCategories", categories);
                        ReportHelper.AddDataSource(lr, "dsArticles", articles);
                    }
                    break;
            }
            _viewReports.LoadReport(lr);
        }
    }
}
