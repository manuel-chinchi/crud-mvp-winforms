using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Views.Contracts
{
    public interface IReportView
    {
        object ItemSelected { get; set; }
        IEnumerable<string> Reports { get; set; }
        void ShowReport(LocalReport report);
        ReportPresenter Presenter { get; set; }

        event EventHandler SelectReport;

        void ShowView();
        void CloseView();
    }
}
