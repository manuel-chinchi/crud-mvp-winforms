using BussinesLayer.Services;
using EntityLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Views;
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
        CategoriesReport,
        CategoriesReportV2
    }

    public class ReportConstants
    {
        public const string ARTICLESREPORT_RESX = "PresentationLayer.Reports.ArticlesReport.rdlc";
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
            _articleService = articleService;
            _categoryService = categoryService;
        }

        public void LoadReport(string reportResx)
        {
            // Add your custom reports here and define in ReportType enum
            LocalReport lr = new LocalReport();
            switch (reportResx)
            {
                case ReportConstants.ARTICLESREPORT_RESX:
                    {
                        var articles = _articleService.GetArticles();
                        lr.ReportEmbeddedResource = ReportConstants.ARTICLESREPORT_RESX;
                        lr.DataSources.Add(new ReportDataSource("dsArticles", articles));
                    }
                    break;

                case ReportConstants.CATEGORIESREPORT_RESX:
                    {
                        var categories = _categoryService.GetCategories();
                        lr.ReportEmbeddedResource = ReportConstants.CATEGORIESREPORT_RESX;
                        lr.DataSources.Add(new ReportDataSource("dsCategories", categories));
                    }
                    break;

                case ReportConstants.CATEGORIESREPORTV2_RESX:
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
