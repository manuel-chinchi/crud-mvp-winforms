
namespace PresentationLayer.Forms
{
    partial class ListArticlesForm
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
            this.listArticlesView1 = new PresentationLayer.Views.ListArticlesView();
            this.SuspendLayout();
            // 
            // listArticlesView1
            // 
            this.listArticlesView1.IncludeDescription = false;
            this.listArticlesView1.IncludeName = false;
            this.listArticlesView1.Location = new System.Drawing.Point(0, 0);
            this.listArticlesView1.Error = null;
            this.listArticlesView1.Success = null;
            this.listArticlesView1.Name = "listArticlesView1";
            this.listArticlesView1.Search = "";
            this.listArticlesView1.Size = new System.Drawing.Size(883, 483);
            this.listArticlesView1.TabIndex = 0;
            // 
            // ListArticlesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(729, 377);
            this.Controls.Add(this.listArticlesView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListArticlesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListArticles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListArticlesForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Views.ListArticlesView listArticlesView1;
    }
}