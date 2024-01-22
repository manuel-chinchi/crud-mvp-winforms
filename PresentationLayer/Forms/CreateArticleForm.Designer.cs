
namespace PresentacionLayer.Forms
{
    partial class CreateArticleForm
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
            this.createArticleView1 = new PresentacionLayer.Views.CreateArticleView();
            this.SuspendLayout();
            // 
            // createArticleView1
            // 
            this.createArticleView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createArticleView1.Location = new System.Drawing.Point(0, 0);
            this.createArticleView1.Name = "createArticleView1";
            this.createArticleView1.Size = new System.Drawing.Size(265, 268);
            this.createArticleView1.TabIndex = 0;
            // 
            // CreateArticleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(265, 268);
            this.Controls.Add(this.createArticleView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateArticleForm";
            this.ShowIcon = false;
            this.Text = "CreateArticle";
            this.ResumeLayout(false);

        }

        #endregion

        private Views.CreateArticleView createArticleView1;
    }
}