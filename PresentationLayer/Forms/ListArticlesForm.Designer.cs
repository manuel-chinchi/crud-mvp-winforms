
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
            this.articleView1 = new PresentationLayer.Views.ArticleView();
            this.SuspendLayout();
            // 
            // articleView1
            // 
            this.articleView1.Location = new System.Drawing.Point(0, 0);
            this.articleView1.Name = "articleView1";
            this.articleView1.Size = new System.Drawing.Size(1069, 560);
            this.articleView1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(892, 374);
            this.Controls.Add(this.articleView1);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListArticlesForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Views.ArticleView articleView1;
    }
}