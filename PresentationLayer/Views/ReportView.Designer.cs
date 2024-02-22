
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblChooseReport = new System.Windows.Forms.Label();
            this.cboReport = new System.Windows.Forms.ComboBox();
            this.rvReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblChooseReport, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboReport, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 665);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 35);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblChooseReport
            // 
            this.lblChooseReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChooseReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseReport.Location = new System.Drawing.Point(3, 0);
            this.lblChooseReport.Name = "lblChooseReport";
            this.lblChooseReport.Size = new System.Drawing.Size(244, 35);
            this.lblChooseReport.TabIndex = 0;
            this.lblChooseReport.Text = "Choose report:";
            this.lblChooseReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboReport
            // 
            this.cboReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReport.FormattingEnabled = true;
            this.cboReport.Location = new System.Drawing.Point(253, 3);
            this.cboReport.Name = "cboReport";
            this.cboReport.Size = new System.Drawing.Size(244, 28);
            this.cboReport.TabIndex = 1;
            this.cboReport.Text = "ArticlesReport.rdlc";
            this.cboReport.SelectedIndexChanged += new System.EventHandler(this.cboReport_SelectedIndexChanged);
            // 
            // rvReport
            // 
            this.rvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvReport.DocumentMapWidth = 91;
            reportDataSource2.Name = "dsArticles";
            reportDataSource2.Value = null;
            this.rvReport.LocalReport.DataSources.Add(reportDataSource2);
            this.rvReport.LocalReport.ReportEmbeddedResource = "PresentationLayer.Reports.ArticlesReport.rdlc";
            this.rvReport.Location = new System.Drawing.Point(0, 0);
            this.rvReport.Name = "rvReport";
            this.rvReport.ServerReport.BearerToken = null;
            this.rvReport.Size = new System.Drawing.Size(500, 665);
            this.rvReport.TabIndex = 2;
            // 
            // ReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rvReport);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReportView";
            this.Size = new System.Drawing.Size(500, 700);
            this.Load += new System.EventHandler(this.ReportView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblChooseReport;
        private System.Windows.Forms.ComboBox cboReport;
        private Microsoft.Reporting.WinForms.ReportViewer rvReport;
    }
}
