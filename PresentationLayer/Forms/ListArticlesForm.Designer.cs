
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
            EntityLayer.Models.Article article21 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article22 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article23 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article24 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article25 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article26 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article27 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article28 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article29 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article30 = new EntityLayer.Models.Article();
            this.listArticlesView1 = new PresentationLayer.Views.ListArticlesView();
            this.SuspendLayout();
            // 
            // listArticlesView1
            // 
            article21.Description = "cuero";
            article21.Id = 2;
            article21.Name = "Zapatilla";
            article21.Stock = 200;
            article22.Description = "cuero sintético";
            article22.Id = 3;
            article22.Name = "Zapatilla";
            article22.Stock = 250;
            article23.Description = "algodon 75%";
            article23.Id = 4;
            article23.Name = "Camisa";
            article23.Stock = 150;
            article24.Description = "deportivo";
            article24.Id = 5;
            article24.Name = "Pantalon";
            article24.Stock = 200;
            article25.Description = "cuero chupin";
            article25.Id = 6;
            article25.Name = "Jean";
            article25.Stock = 220;
            article26.Description = "tipo kanguro, c/capucha";
            article26.Id = 7;
            article26.Name = "Buso";
            article26.Stock = 120;
            article27.Description = "blanca";
            article27.Id = 8;
            article27.Name = "Gorra";
            article27.Stock = 500;
            article28.Description = "tipo soquetes p/hombre";
            article28.Id = 9;
            article28.Name = "Medias";
            article28.Stock = 500;
            article29.Description = "tipo soquetes p/mujer";
            article29.Id = 10;
            article29.Name = "Medias";
            article29.Stock = 400;
            article30.Description = "sintetico, deportivo";
            article30.Id = 24;
            article30.Name = "zapatos";
            article30.Stock = 90;
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article21);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article22);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article23);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article24);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article25);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article26);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article27);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article28);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article29);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article30);
            this.listArticlesView1.IncludeDescription = false;
            this.listArticlesView1.IncludeName = false;
            this.listArticlesView1.Location = new System.Drawing.Point(0, 0);
            this.listArticlesView1.MsgError = null;
            this.listArticlesView1.MsgStatus = null;
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
            this.Text = "ListArticles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListArticlesForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Views.ListArticlesView listArticlesView1;
    }
}