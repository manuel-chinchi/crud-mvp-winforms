
namespace PresentationLayer.Forms
{
    partial class ListCategoriesForm
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
            this.listCategoriesView1 = new PresentationLayer.Views.ListCategoriesView();
            this.SuspendLayout();
            // 
            // listCategoriesView1
            // 
            this.listCategoriesView1.Location = new System.Drawing.Point(0, 0);
            this.listCategoriesView1.Error = null;
            this.listCategoriesView1.Success = null;
            this.listCategoriesView1.Name = "listCategoriesView1";
            this.listCategoriesView1.Size = new System.Drawing.Size(764, 400);
            this.listCategoriesView1.TabIndex = 0;
            // 
            // ListCategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(697, 328);
            this.Controls.Add(this.listCategoriesView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListCategoriesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListCategories";
            this.ResumeLayout(false);

        }

        #endregion

        private Views.ListCategoriesView listCategoriesView1;
    }
}