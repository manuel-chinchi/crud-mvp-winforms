
namespace PresentationLayer.Views
{
    partial class ReportView
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rvReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ArticleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ArticleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvReport
            // 
            this.rvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsArticles";
            reportDataSource1.Value = this.ArticleBindingSource;
            this.rvReport.LocalReport.DataSources.Add(reportDataSource1);
            this.rvReport.LocalReport.ReportEmbeddedResource = "PresentationLayer.Reports.ArticlesReport.rdlc";
            this.rvReport.Location = new System.Drawing.Point(0, 0);
            this.rvReport.Name = "rvReport";
            this.rvReport.ServerReport.BearerToken = null;
            this.rvReport.Size = new System.Drawing.Size(500, 700);
            this.rvReport.TabIndex = 0;
            // 
            // ArticleBindingSource
            // 
            this.ArticleBindingSource.DataSource = typeof(EntityLayer.Models.Article);
            // 
            // ReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rvReport);
            this.Name = "ReportView";
            this.Size = new System.Drawing.Size(500, 700);
            this.Load += new System.EventHandler(this.ReportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ArticleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvReport;
        private System.Windows.Forms.BindingSource ArticleBindingSource;
    }
}
