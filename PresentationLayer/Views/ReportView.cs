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
    public partial class ReportView : Form, IReportView
    {
        public object ItemSelected
        {
            get { return cboReport.SelectedItem; }
            set { cboReport.SelectedItem = value; }
        }
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

        public event EventHandler SelectReport;


        public void ShowReport(LocalReport report)
        {
            rpvReport.Reset();
            {
                rpvReport.LocalReport.ReportEmbeddedResource = report.ReportEmbeddedResource;
                rpvReport.LocalReport.DataSources.Clear();
                for (int i = 0; i < report.DataSources.Count; i++)
                {
                    rpvReport.LocalReport.DataSources.Add(report.DataSources[i]);
                }
                rpvReport.LocalReport.SetParameters(new List<ReportParameter>());
            }
            rpvReport.SetDisplayMode(DisplayMode.PrintLayout);
            rpvReport.RefreshReport();
        }

        public ReportView()
        {
            InitializeComponent();
            BindingEvents();
            Presenter = new ReportPresenter(this, new ArticleService(), new CategoryService());
        }

        private void BindingEvents()
        {
            cboReport.SelectedIndexChanged += delegate { SelectReport?.Invoke(this, EventArgs.Empty); };
        }

        public void ShowView()
        {
            this.ShowDialog();
        }

        public void CloseView()
        {
            this.Close();
        }
    }
}
