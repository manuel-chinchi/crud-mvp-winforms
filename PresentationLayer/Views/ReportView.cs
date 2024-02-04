using BussinesLayer.Services;
using EntityLayer.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    enum ReportSelected
    {
        ArticlesReport = 0,
        CategoriesReport
    }

    public partial class ReportView : UserControl
    {
        IArticleService<IEnumerable<Article>> articleService { get; set; } = new ArticleService();
        ICategoryService<IEnumerable<Category>> categoryService { get; set; } = new CategoryService();

        const string ARTICLESREPORT_RESX = "PresentationLayer.Reports.ArticlesReport.rdlc";
        const string CATEGORIESREPORT_RESX = "PresentationLayer.Reports.CategoriesReport.rdlc";

        public ReportView()
        {
            InitializeComponent();
        }

        private void ReportView_Load(object sender, EventArgs e)
        {
            //FIX: No se puede establecer la directiva de seguridad en MultiDomain despues de cargar ensamblados que no son GAC en AppDomain (Exc de HRESULT: 0x8013101C) en ReportForm.cs
            if (DesignMode) return;

            LoadDataReport();
        }

        private void LoadDataReport()
        {
            cboReport_SelectedIndexChanged(this.cboReport, null);
        }

        private void cboReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = cboReport.SelectedIndex;
            rvReport.Reset();

            switch (index)
            {
                case (int)ReportSelected.ArticlesReport:
                    {
                        var paramS = new List<ReportParameter>();
                        var articles = articleService.GetArticles();
                        rvReport.LocalReport.ReportEmbeddedResource = ARTICLESREPORT_RESX;
                        // FIX: data source not showing loaded data
                        rvReport.LocalReport.DataSources.Clear();
                        rvReport.LocalReport.DataSources.Add(new ReportDataSource("dsArticles", articles));
                        rvReport.LocalReport.SetParameters(new List<ReportParameter>(paramS));
                        //rvReport.RefreshReport();
                    }
                    break;

                case (int)ReportSelected.CategoriesReport:
                    {
                        var paramS = new List<ReportParameter>();
                        var categories = categoryService.GetCategories();
                        rvReport.LocalReport.ReportEmbeddedResource = CATEGORIESREPORT_RESX;
                        // FIX: data source not showing loaded data
                        rvReport.LocalReport.DataSources.Clear();
                        rvReport.LocalReport.DataSources.Add(new ReportDataSource("dsCategories", categories));
                        rvReport.LocalReport.SetParameters(new List<ReportParameter>(paramS));
                        //rvReport.RefreshReport();
                    }
                    break;
                default:
                    break;
            }

            //REF: https://stackoverflow.com/questions/37276185/how-to-get-the-table-at-the-center-of-reportviewer-in-my-form
            rvReport.SetDisplayMode(DisplayMode.PrintLayout);
            rvReport.RefreshReport();
        }
    }
}
