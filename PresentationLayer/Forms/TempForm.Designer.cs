
namespace PresentationLayer.Forms
{
    partial class TempForm
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
            this.reportView1 = new PresentationLayer.Views.ReportView();
            this.SuspendLayout();
            // 
            // reportView1
            // 
            this.reportView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportView1.Location = new System.Drawing.Point(0, 0);
            this.reportView1.Name = "reportView1";
            this.reportView1.Size = new System.Drawing.Size(848, 555);
            this.reportView1.TabIndex = 0;
            // 
            // TempForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 555);
            this.Controls.Add(this.reportView1);
            this.Name = "TempForm";
            this.Text = "TempForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Views.ReportView reportView1;
    }
}