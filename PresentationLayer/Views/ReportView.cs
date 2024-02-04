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
    public partial class ReportView : UserControl
    {
        IArticleService<IEnumerable<Article>> articleService { get; set; } = new ArticleService();
        ICategoryService<IEnumerable<Category>> categoryService { get; set; } = new CategoryService();

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
            var articles = articleService.GetArticles();
            var parms = new List<ReportParameter>();
            string dataSourceName = rvReport.LocalReport.DataSources[0].Name;

            //reportViewer1.LocalReport.DataSources.Add(rds);
            //reportViewer1.LocalReport.SetParameters(parms);
            //reportViewer1.RefreshReport();

            //if (rvReport.LocalReport.ReportPath==null)
            if (1 == 2)
            {
                var rootPath = AppDomain.CurrentDomain.BaseDirectory;
                //rvReport.LocalReport.ReportPath = $"PresentationLayer/Reports/CategoriesReport.rdlc";
                rvReport.LocalReport.ReportEmbeddedResource = "PresentationLayer.Reports.CategoriesReport.rdlc";
                var categories = categoryService.GetCategories();
                rvReport.SetDisplayMode(DisplayMode.PrintLayout);
                
                rvReport.LocalReport.DataSources.Clear();

                rvReport.LocalReport.DataSources.Add(new ReportDataSource("dsCategories", categories));
                rvReport.RefreshReport();
                return;
            }

            //REF: https://stackoverflow.com/questions/37276185/how-to-get-the-table-at-the-center-of-reportviewer-in-my-form
            rvReport.SetDisplayMode(DisplayMode.PrintLayout);
            //rvReport.ZoomMode = ZoomMode.PageWidth;

            // FIX: data source not showing loaded data
            rvReport.LocalReport.DataSources.Clear(); 

            rvReport.LocalReport.DataSources.Add(new ReportDataSource(dataSourceName, articles));
            rvReport.LocalReport.SetParameters(parms);
            rvReport.RefreshReport();
        }
    }
}
