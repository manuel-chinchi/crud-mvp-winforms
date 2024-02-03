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

        public ReportView()
        {
            InitializeComponent();
        }

        private void ReportView_Load(object sender, EventArgs e)
        {
            //FIX: No se puede establecer la directiva de seguridad en MultiDomain despues de cargar ensamblados que no son GAC en AppDomain (Exc de HRESULT: 0x8013101C) en ReportForm.cs
            if (!DesignMode)
            {
                LoadDataReport();
            }
        }

        private void LoadDataReport()
        {
            var articles = articleService.GetArticles();
            var parms = new List<ReportParameter>();
            string dataSourceName = rvReport.LocalReport.DataSources[0].Name;

            //reportViewer1.LocalReport.DataSources.Add(rds);
            //reportViewer1.LocalReport.SetParameters(parms);
            //reportViewer1.RefreshReport();


            // FIX: data source not showing loaded data
            rvReport.LocalReport.DataSources.Clear(); 

            rvReport.LocalReport.DataSources.Add(new ReportDataSource(dataSourceName, articles));
            rvReport.LocalReport.SetParameters(parms);
            rvReport.RefreshReport();
        }
    }
}
