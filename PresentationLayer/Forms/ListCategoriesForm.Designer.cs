
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
            EntityLayer.Models.Category category1 = new EntityLayer.Models.Category();
            EntityLayer.Models.Category category2 = new EntityLayer.Models.Category();
            EntityLayer.Models.Category category3 = new EntityLayer.Models.Category();
            EntityLayer.Models.Category category4 = new EntityLayer.Models.Category();
            EntityLayer.Models.Category category5 = new EntityLayer.Models.Category();
            this.listCategoriesView1 = new PresentationLayer.Views.ListCategoriesView();
            this.SuspendLayout();
            // 
            // listCategoriesView1
            // 
            category1.DateCreated = new System.DateTime(2024, 1, 17, 0, 0, 0, 0);
            category1.Id = 1;
            category1.Name = "Otro";
            category2.DateCreated = new System.DateTime(2024, 1, 17, 0, 0, 0, 0);
            category2.Id = 2;
            category2.Name = "Pantalones";
            category3.DateCreated = new System.DateTime(2024, 1, 17, 0, 0, 0, 0);
            category3.Id = 3;
            category3.Name = "Camisas";
            category4.DateCreated = new System.DateTime(2024, 1, 25, 21, 27, 14, 277);
            category4.Id = 5;
            category4.Name = "xx";
            category5.DateCreated = new System.DateTime(2024, 1, 25, 21, 34, 8, 117);
            category5.Id = 7;
            category5.Name = "zz";
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Category>().Add(category1);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Category>().Add(category2);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Category>().Add(category3);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Category>().Add(category4);
            new EntityLayer.Models.SortableBindingList<EntityLayer.Models.Category>().Add(category5);
            this.listCategoriesView1.Location = new System.Drawing.Point(0, 0);
            this.listCategoriesView1.MsgError = null;
            this.listCategoriesView1.MsgStatus = null;
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