using BussinesLayer.Services;
using EntityLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters;
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
    public partial class ReportView : UserControl, IReportView
    {
        public ReportPresenter Presenter { get; set; }

        public ReportView()
        {
            InitializeComponent();

            Presenter = new ReportPresenter(this, new ArticleService(), new CategoryService());
        }

        private void ReportView_Load(object sender, EventArgs e)
        {
            //FIX: No se puede establecer la directiva de seguridad en MultiDomain despues de cargar ensamblados que no son GAC en AppDomain (Exc de HRESULT: 0x8013101C) en ReportForm.cs
            if (DesignMode) return;

            Presenter.LoadReport(ReportConstants.ARTICLESREPORT_RESX);
        }

        private void cboReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = cboReport.SelectedIndex;
            switch (index)
            {
                case (int)ReportType.ArticlesReport:
                    Presenter.LoadReport(ReportConstants.ARTICLESREPORT_RESX);
                    break;
                case (int)ReportType.ArticlesReportV2:
                    Presenter.LoadReport(ReportConstants.ARTICLESREPORTV2_RESX);
                    break;
                case (int)ReportType.CategoriesReport:
                    Presenter.LoadReport(ReportConstants.CATEGORIESREPORT_RESX);
                    break;
                case (int)ReportType.CategoriesReportV2:
                    Presenter.LoadReport(ReportConstants.CATEGORIESREPORTV2_RESX);
                    break;
            }
        }

        public void ShowReport(LocalReport report)
        {
            rvReport.Reset();
            {
                rvReport.LocalReport.ReportEmbeddedResource = report.ReportEmbeddedResource;
                rvReport.LocalReport.DataSources.Clear();
                for (int i = 0; i < report.DataSources.Count; i++)
                {
                    rvReport.LocalReport.DataSources.Add(report.DataSources[i]);
                }
                rvReport.LocalReport.SetParameters(new List<ReportParameter>());
            }
            //REF: https://stackoverflow.com/questions/37276185/how-to-get-the-table-at-the-center-of-reportviewer-in-my-form
            rvReport.SetDisplayMode(DisplayMode.PrintLayout);
            rvReport.RefreshReport();
        }
    }
}
