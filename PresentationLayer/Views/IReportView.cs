using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views
{
    public interface IReportView
    {
        void ShowReport(LocalReport report);
        ReportPresenter Presenter { get; set; }
    }
}
