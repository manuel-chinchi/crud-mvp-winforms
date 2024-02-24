using BussinesLayer.Services.Contracts;
using EntityLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Views.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public enum ReportType
    {
        ArticlesReport = 0,
        ArticlesReportV2,
        CategoriesReport,
        CategoriesReportV2
    }

    public class ReportConstants
    {
        public const string ARTICLESREPORT_RESX = "PresentationLayer.Reports.ArticlesReport.rdlc";
        public const string ARTICLESREPORTV2_RESX = "PresentationLayer.Reports.ArticlesReportV2.rdlc";
        public const string CATEGORIESREPORT_RESX = "PresentationLayer.Reports.CategoriesReport.rdlc";
        public const string CATEGORIESREPORTV2_RESX = "PresentationLayer.Reports.CategoriesReportV2.rdlc";
    }

    public class ReportPresenter
    {
        IReportView _view { get; set; }
        IArticleService<IEnumerable<Article>> _articleService { get; set; }
        ICategoryService<IEnumerable<Category>> _categoryService { get; set; }

        public ReportPresenter(IReportView view, IArticleService<IEnumerable<Article>> articleService, ICategoryService<IEnumerable<Category>> categoryService)
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
            LocalReport lr = new LocalReport();

            switch (index)
            {
                case (int)ReportType.ArticlesReport:
                    {
                        var articles = _articleService.GetArticles();
                        lr.ReportEmbeddedResource = ReportConstants.ARTICLESREPORT_RESX;
                        lr.DataSources.Add(new ReportDataSource("dsArticles", articles));
                    }
                    break;
                case (int)ReportType.ArticlesReportV2:
                    {
                        var articles = _articleService.GetArticles();
                        lr.ReportEmbeddedResource = ReportConstants.ARTICLESREPORTV2_RESX;
                        lr.DataSources.Add(new ReportDataSource("dsArticles", articles));
                    }
                    break;
                case (int)ReportType.CategoriesReport:
                    {
                        var categories = _categoryService.GetCategories();
                        lr.ReportEmbeddedResource = ReportConstants.CATEGORIESREPORT_RESX;
                        lr.DataSources.Add(new ReportDataSource("dsCategories", categories));
                    }
                    break;
                case (int)ReportType.CategoriesReportV2:
                    {
                        var categories = _categoryService.GetCategories();
                        var articles = _articleService.GetArticles();
                        lr.ReportEmbeddedResource = ReportConstants.CATEGORIESREPORTV2_RESX;
                        lr.DataSources.Add(new ReportDataSource("dsCategories", categories));
                        lr.DataSources.Add(new ReportDataSource("dsArticles", articles));
                    }
                    break;
            }
            _view.ShowReport(lr);
        }
    }
}
