using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters.Helpers
{
    public static class ReportHelper
    {
        public static LocalReport CreateLocalReport(
            string embeddedResource, 
            string dataSource, 
            IEnumerable<object> values)
        {
            LocalReport lr = new LocalReport();
            lr.ReportEmbeddedResource = embeddedResource;
            lr.DataSources.Add(new ReportDataSource(dataSource, values));
            return lr;
        }

        public static LocalReport CreateLocalReport(
            string embeddedResource
            )
        {
            LocalReport lr = new LocalReport();
            lr.ReportEmbeddedResource = embeddedResource;
            return lr;
        }

        public static void AddDataSource(
            object localReport, 
            string dataSource,
            IEnumerable<object> values)
        {
            LocalReport lr = (LocalReport)localReport;
            lr.DataSources.Add(new ReportDataSource(dataSource, values));
        }
    }
}
