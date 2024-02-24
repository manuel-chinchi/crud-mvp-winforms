using BussinesLayer.Services;
using EntityLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters;
using PresentationLayer.Views.Contracts;
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
        public IEnumerable<string> Reports
        {
            get
            {
                var bs = (BindingSource)cboReport.DataSource;
                var list = (IEnumerable<string>)bs.DataSource;
                return list;
            }
            set
            {
                var bs = new BindingSource();
                bs.DataSource = new SortableBindingList<string>(value.ToList());
                cboReport.DataSource = bs;
            }
        }

        public ReportPresenter Presenter { get; set; }

        public object ItemSelected
        {
            get { return cboReport.SelectedItem; }
            set { cboReport.SelectedItem = value; }
        }

        public event EventHandler SelectReport;

        public ReportView()
        {
            InitializeComponent();

            Presenter = new ReportPresenter(this, new ArticleService(), new CategoryService());
        }

        private void ReportView_Load(object sender, EventArgs e)
        {
            //FIX: No se puede establecer la directiva de seguridad en MultiDomain despues de cargar ensamblados que no son GAC en AppDomain (Exc de HRESULT: 0x8013101C) en ReportForm.cs
            if (DesignMode) return;
        }

        private void cboReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectReport?.Invoke(cboReport.SelectedIndex, EventArgs.Empty);
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
