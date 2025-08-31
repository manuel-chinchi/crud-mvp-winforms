using BussinesLayer.Services.Contracts;
using EntityLayer.Models;
using PresentationLayer.Presenters.Helpers;
using PresentationLayer.Views.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public enum ReportResource
    {
        ArticlesReport = 0,
        ArticlesReportV2,
        CategoriesReport,
        CategoriesReportV2
    }

    public class ReportFiles
    {
        public const string ARTICLESREPORT_RESX = "PresentationLayer.Reports.ArticlesReport.rdlc";
        public const string ARTICLESREPORTV2_RESX = "PresentationLayer.Reports.ArticlesReportV2.rdlc";
        public const string CATEGORIESREPORT_RESX = "PresentationLayer.Reports.CategoriesReport.rdlc";
        public const string CATEGORIESREPORTV2_RESX = "PresentationLayer.Reports.CategoriesReportV2.rdlc";
    }
    // TODO list
    // 1.   si actualizan datos en vista Categories o Articles aqui no se actualizan. arreglar.s
    public class ReportPresenter
    {
        IReportView _view { get; set; }
        IArticleService<Article> _articleService { get; set; }
        ICategoryService<Category> _categoryService { get; set; }

        public ReportPresenter(IReportView view, IArticleService<Article> articleService, ICategoryService<Category> categoryService)
        {
            _view = view;
            _view.Presenter = this;

            _view.SelectReport += _view_SelectReport;
            _articleService = articleService;
            _categoryService = categoryService;

            IEnumerable<string> items = new List<string>()
            {
                "ArticlesReport.rdlc",
                "ArticlesReportV2.rdlc",
                "CategoriesReport.rdlc",
                "CategoriesReportV2.rdlc"
            };
            int itemSelect = 1;
            _view.Reports = items;
            _view.ItemSelected = items.ToArray()[itemSelect];
            _view_SelectReport(itemSelect, EventArgs.Empty);
        }

        private void _view_SelectReport(object sender, EventArgs e)
        {
            int index = _view.Reports.ToList().IndexOf((string)_view.ItemSelected);
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
            _view.LoadReport(lr);
        }
    }
}
