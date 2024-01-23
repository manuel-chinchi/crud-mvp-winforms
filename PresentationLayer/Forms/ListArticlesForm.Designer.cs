
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
            EntityLayer.Models.Article article1 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article2 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article3 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article4 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article5 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article6 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article7 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article8 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article9 = new EntityLayer.Models.Article();
            EntityLayer.Models.Article article10 = new EntityLayer.Models.Article();
            this.listArticlesView1 = new PresentationLayer.Views.ListArticlesView();
            this.SuspendLayout();
            // 
            // listArticlesView1
            // 
            article1.Description = "algodon 100%";
            article1.Id = 1;
            article1.Name = "Camisa";
            article1.Stock = 100;
            article2.Description = "cuero";
            article2.Id = 2;
            article2.Name = "Zapatilla";
            article2.Stock = 200;
            article3.Description = "cuero sintético";
            article3.Id = 3;
            article3.Name = "Zapatilla";
            article3.Stock = 250;
            article4.Description = "algodon 75%";
            article4.Id = 4;
            article4.Name = "Camisa";
            article4.Stock = 150;
            article5.Description = "deportivo";
            article5.Id = 5;
            article5.Name = "Pantalon";
            article5.Stock = 200;
            article6.Description = "cuero chupin";
            article6.Id = 6;
            article6.Name = "Jean";
            article6.Stock = 220;
            article7.Description = "tipo kanguro, c/capucha";
            article7.Id = 7;
            article7.Name = "Buso";
            article7.Stock = 120;
            article8.Description = "blanca";
            article8.Id = 8;
            article8.Name = "Gorra";
            article8.Stock = 500;
            article9.Description = "tipo soquetes p/hombre";
            article9.Id = 9;
            article9.Name = "Medias";
            article9.Stock = 500;
            article10.Description = "tipo soquetes p/mujer";
            article10.Id = 10;
            article10.Name = "Medias";
            article10.Stock = 400;
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article1);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article2);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article3);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article4);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article5);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article6);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article7);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article8);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article9);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Article>().Add(article10);
            this.listArticlesView1.Location = new System.Drawing.Point(0, 0);
            this.listArticlesView1.Name = "listArticlesView1";
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
            this.Name = "ListArticlesForm";
            this.ShowIcon = false;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListArticlesForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Views.ListArticlesView listArticlesView1;
    }
}