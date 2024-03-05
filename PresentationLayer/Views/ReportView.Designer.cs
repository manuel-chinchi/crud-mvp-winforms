
namespace PresentationLayer.Views
{
    partial class ReportView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.cboReport = new System.Windows.Forms.ComboBox();
            this.lblChooseReport = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.rpvReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tlpBottom.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpBottom
            // 
            this.tlpBottom.ColumnCount = 2;
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBottom.Controls.Add(this.cboReport, 0, 0);
            this.tlpBottom.Controls.Add(this.lblChooseReport, 0, 0);
            this.tlpBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpBottom.Location = new System.Drawing.Point(0, 868);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.RowCount = 1;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpBottom.Size = new System.Drawing.Size(803, 35);
            this.tlpBottom.TabIndex = 0;
            // 
            // cboReport
            // 
            this.cboReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReport.FormattingEnabled = true;
            this.cboReport.Location = new System.Drawing.Point(404, 3);
            this.cboReport.Name = "cboReport";
            this.cboReport.Size = new System.Drawing.Size(396, 26);
            this.cboReport.TabIndex = 2;
            this.cboReport.Text = "ArticlesReport.rdlc";
            // 
            // lblChooseReport
            // 
            this.lblChooseReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChooseReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseReport.Location = new System.Drawing.Point(3, 0);
            this.lblChooseReport.Name = "lblChooseReport";
            this.lblChooseReport.Size = new System.Drawing.Size(395, 35);
            this.lblChooseReport.TabIndex = 1;
            this.lblChooseReport.Text = "Choose report:";
            this.lblChooseReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.rpvReport);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(803, 868);
            this.pnlBody.TabIndex = 1;
            // 
            // rpvReport
            // 
            this.rpvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvReport.Location = new System.Drawing.Point(0, 0);
            this.rpvReport.Name = "rpvReport";
            this.rpvReport.ServerReport.BearerToken = null;
            this.rpvReport.Size = new System.Drawing.Size(803, 868);
            this.rpvReport.TabIndex = 0;
            // 
            // ReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 903);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.tlpBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportView";
            this.tlpBottom.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private System.Windows.Forms.Panel pnlBody;
        private Microsoft.Reporting.WinForms.ReportViewer rpvReport;
        private System.Windows.Forms.Label lblChooseReport;
        private System.Windows.Forms.ComboBox cboReport;
    }
}