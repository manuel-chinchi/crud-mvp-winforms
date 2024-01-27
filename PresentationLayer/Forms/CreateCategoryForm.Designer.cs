
namespace PresentationLayer.Forms
{
    partial class CreateCategoryForm
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
            this.createCategoryView1 = new PresentationLayer.Views.CreateCategoryView();
            this.SuspendLayout();
            // 
            // createCategoryView1
            // 
            this.createCategoryView1.Location = new System.Drawing.Point(0, 0);
            this.createCategoryView1.Name = "createCategoryView1";
            this.createCategoryView1.Size = new System.Drawing.Size(330, 247);
            this.createCategoryView1.TabIndex = 0;
            // 
            // CreateCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(302, 193);
            this.Controls.Add(this.createCategoryView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateCategoryForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateCategoryForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Views.CreateCategoryView createCategoryView1;
    }
}